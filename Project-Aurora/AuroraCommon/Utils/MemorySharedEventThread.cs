﻿using Common.Data;
using Microsoft.Scripting.Utils;

namespace Common.Utils;

internal static class MemorySharedEventThread
{
    private static readonly List<HandlesAndThread> HandleThreads = [];

    internal static void AddObject(SignaledMemoryObject o)
    {
        var handleThread = HandleThreads.Find(ht => ht.HasSpace(2));
        if (handleThread == null)
        {
            handleThread = new HandlesAndThread();
            HandleThreads.Add(handleThread);
        }
        
        handleThread.AddToThread(o);
    }

    internal static void RemoveObject(SignaledMemoryObject o)
    {
        foreach (var handlesAndThread in HandleThreads)
        {
            handlesAndThread.RemoveIfExists(o);
        }
    }

    private sealed class HandlesAndThread
    {
        private const int MaxHandles = 64;
    
        private CancellationTokenSource _cancellation = new();
        private CancellationTokenSource CancelToken
        {
            get => _cancellation;
            set
            {
                var old = _cancellation;
                _cancellation = value;
                _handles[0] = value.Token.WaitHandle;
                old.Cancel();
                old.Dispose();
            }
        }
        
        private Thread _thread = new(() => { });
        
        private Action[] _actions = [() => { }];
        private WaitHandle[] _handles;
        
        private readonly SemaphoreSlim _semaphore = new(1);

        internal HandlesAndThread()
        {
            _handles = [CancelToken.Token.WaitHandle];
            _thread.Start();
        }

        private Thread CreateThread()
        {
            return new Thread(() =>
            {
                if (_handles.Length <= 1)
                {
                    // stop thread if only handle is cancel token
                    return;
                }
                while (true)
                {
                    var i = WaitHandle.WaitAny(_handles);
                    switch (i)
                    {
                        case 0:
                            return;
                        default:
                            Task.Run(() =>
                            {
                                _actions[i].Invoke();
                            });
                            break;
                    }
                }
            })
            {
                Name = "Memory Share Event Thread",
                IsBackground = true,
            };
        }

        internal void AddToThread(SignaledMemoryObject o)
        {
            _semaphore.Wait();

            try
            {
                _actions = _actions.Concat(new[]
                {
                    o.OnUpdated,
                    o.OnUpdateRequested
                }).ToArray();
                _handles = _handles.Concat(new[]
                {
                    o.ObjectUpdatedHandle,
                    o.UpdateRequestedHandle
                }).ToArray();

                CancelToken = new CancellationTokenSource();
                _thread = CreateThread();
                _thread.Start();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        internal void RemoveIfExists(SignaledMemoryObject o)
        {
            _semaphore.Wait();

            try
            {
                var updatedHandle = _handles.FindIndex(h => o.ObjectUpdatedHandle == h);
                var requestedHandle = _handles.FindIndex(h => o.UpdateRequestedHandle == h);
                _actions = _actions.Where((_, i) => i != updatedHandle && i != requestedHandle).ToArray();
                _handles = _handles.Where((_, i) => i != updatedHandle && i != requestedHandle).ToArray();

                CancelToken = new CancellationTokenSource();
                _thread = CreateThread();
                _thread.Start();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        internal bool HasSpace(int handleCount)
        {
            return _handles.Length + handleCount < MaxHandles;
        }
    }
}