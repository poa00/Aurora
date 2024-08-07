﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AuroraRgb.Modules.Updates;
using Common.Utils;
using Microsoft.Win32;

namespace AuroraRgb.Modules;

public sealed class UpdateModule : AuroraModule
{
    private readonly TaskCompletionSource<AuroraChangelog[]> _changelogsTaskSource = new();
    public Task<AuroraChangelog[]> Changelogs => _changelogsTaskSource.Task;
    
    protected override async Task Initialize()
    {
        var readChangelogs = await ReadChangelogs();
        _changelogsTaskSource.TrySetResult(readChangelogs);

        if (Global.Configuration.UpdatesCheckOnStartUp)
        {
            await CheckUpdate();
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }
    }

    private async void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
    {
        if (e.Reason != SessionSwitchReason.SessionUnlock)
        {
            return;
        }
        await CheckUpdate();
    }

    public static async Task CheckUpdate()
    {
        var updaterPath = Path.Combine(Global.ExecutingDirectory, "Aurora-Updater.exe");

        if (!File.Exists(updaterPath)) return;
        await DesktopUtils.WaitSessionUnlock();
        try
        {
            var arguments = "-silent";
            if (!Global.isDebug && Global.Configuration.UpdateBackground)
            {
                arguments += " -background";
            }
            var updaterProc = new ProcessStartInfo
            {
                FileName = updaterPath,
                Arguments = arguments
            };
            Process.Start(updaterProc);
        }
        catch (Exception exc)
        {
            Global.logger.Error(exc, "Could not start Aurora Updater");
        }
    }

    private static Task<AuroraChangelog[]> ReadChangelogs()
    {
        var changelogsFolder = Path.Join(Global.ExecutingDirectory, "changelogs");
        if (!Path.Exists(changelogsFolder))
        {
            return Task.FromResult<AuroraChangelog[]>([]);
        }
        var fileContents = Directory.EnumerateFiles(changelogsFolder)
            .OrderDescending()
            .Select(ReadChangelog);

        return Task.WhenAll(fileContents);
    }

    private static async Task<AuroraChangelog> ReadChangelog(string changelogPath)
    {
        var versionTag = Path.GetFileNameWithoutExtension(changelogPath);
        var content = await File.ReadAllTextAsync(changelogPath);

        return new AuroraChangelog(versionTag, content);
    }

    public override ValueTask DisposeAsync()
    {
        SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
        return ValueTask.CompletedTask;
    }

    public void ClearChangelogs()
    {
        var changelogsFolder = Path.Join(Global.ExecutingDirectory, "changelogs");
        foreach (var changelogFile in Directory.EnumerateFiles(changelogsFolder))
        {
            File.Delete(changelogFile);
        }
    }
}