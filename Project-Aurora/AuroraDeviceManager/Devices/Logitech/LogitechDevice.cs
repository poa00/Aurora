﻿using System.ComponentModel;
using AuroraDeviceManager.Utils;
using Common;
using Common.Devices;
using Common.Devices.Logitech;
using Microsoft.Win32;

namespace AuroraDeviceManager.Devices.Logitech;

public class LogitechDevice : DefaultDevice
{
    public override string DeviceName => "Logitech";

    private readonly byte[] _logitechBitmap = new byte[LogitechGSDK.LOGI_LED_BITMAP_SIZE];
    private SimpleColor _speakers;
    private SimpleColor _mousepad;
    private readonly SimpleColor[] _mouse = new SimpleColor[3];
    private readonly SimpleColor[] _headset = new SimpleColor[3];
    private DeviceKeys _genericKey;

    protected override async Task<bool> DoInitialize()
    {
        _genericKey = Global.DeviceConfig.VarRegistry.GetVariable<DeviceKeys>($"{DeviceName}_devicekey");
        var ghubRunning = ProcessUtils.IsProcessRunning("lghub_agent");
        var lgsRunning = ProcessUtils.IsProcessRunning("lcore");

        if (!ghubRunning && !lgsRunning)
        {
            IsInitialized = false;
            return false;
        }

        if (Global.DeviceConfig.VarRegistry.GetVariable<bool>($"{DeviceName}_override_dll"))
            LogitechGSDK.GHUB = Global.DeviceConfig.VarRegistry.GetVariable<LGDLL>($"{DeviceName}_override_dll_option") == LGDLL.GHUB;
        else
            LogitechGSDK.GHUB = ghubRunning;

        LogInfo($"Trying to initialize Logitech using the dll for {(LogitechGSDK.GHUB ? "GHUB" : "LGS")}");

        if (LogitechGSDK.LogiLedInit() && LogitechGSDK.LogiLedSaveCurrentLighting())
        {
            //logitech says to wait a bit of time between Init() and SetLighting()
            //This didnt seem to be needed in the past but I feel like 100ms might 
            //fix some weird issues without any noticeable disadvantages
            await Task.Delay(100).ConfigureAwait(false);
            if (Global.DeviceConfig.VarRegistry.GetVariable<bool>($"{DeviceName}_set_default"))
                LogitechGSDK.LogiLedSetLighting(Global.DeviceConfig.VarRegistry.GetVariable<SimpleColor>($"{DeviceName}_default_color"));
            IsInitialized = true;
            return true;
        }

        SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;

        IsInitialized = false;
        return false;
    }

    protected override Task Shutdown()
    {
        LogitechGSDK.LogiLedRestoreLighting();
        LogitechGSDK.LogiLedShutdown();
        SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
        IsInitialized = false;
        return Task.CompletedTask;
    }

    // Handle Logon Event
    async void SystemEvents_SessionSwitch(object? sender, SessionSwitchEventArgs e)
    {
        switch (e.Reason)
        {
            case SessionSwitchReason.SessionLock:
            case SessionSwitchReason.SessionLogoff:
                try
                {
                    await Shutdown();
                }catch{ /* ignore */}
                SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
                SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
                break;
            case SessionSwitchReason.SessionLogon:
            case SessionSwitchReason.SessionUnlock:
                await Task.Delay(TimeSpan.FromSeconds(4));
                await Initialize();
                break;
        }
    }

    protected override Task<bool> UpdateDevice(Dictionary<DeviceKeys, SimpleColor> keyColors, DoWorkEventArgs e, bool forced = false)
    {
        if (!IsInitialized)
            return Task.FromResult(false);

        //reset keys to peripheral_logo here so if we dont find any better color for them,
        //at least the leds wont turn off :)
        if (keyColors.TryGetValue(_genericKey, out var periph))
        {
            _speakers = periph;
            _mousepad = periph;
            _mouse[0] = periph;
            _mouse[1] = periph;
            _headset[0] = periph;
            _headset[1] = periph;
        }

        foreach (var key in keyColors)
        {
            if (key.Key == DeviceKeys.Peripheral)
            {
                LogitechGSDK.LogiLedSetLighting(key.Value);
                continue;
            }

            #region keyboard
            if (LedMaps.BitmapMap.TryGetValue(key.Key, out var index))
            {
                _logitechBitmap[index] = key.Value.B;
                _logitechBitmap[index + 1] = key.Value.G;
                _logitechBitmap[index + 2] = key.Value.R;
                _logitechBitmap[index + 3] = key.Value.A;
            }

            if (!Global.DeviceConfig.DevicesDisableKeyboard && LedMaps.KeyMap.TryGetValue(key.Key, out var logiKey))
                IsInitialized &= LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(logiKey, key.Value);
            #endregion

            #region peripherals
            if (LedMaps.PeripheralMap.TryGetValue(key.Key, out var peripheral))
            {
                switch (peripheral.type)
                {
                    case DeviceType.Mouse:
                        _mouse[peripheral.zone] = key.Value;
                        break;
                    case DeviceType.Mousemat:
                        _mousepad = key.Value;
                        break;
                    case DeviceType.Headset:
                        _headset[peripheral.zone] = key.Value;
                        break;
                    case DeviceType.Speaker:
                        _speakers = key.Value;
                        break;
                }
            }
            #endregion
        }

        if (!Global.DeviceConfig.DevicesDisableMouse)
        {
            for (var i = 0; i < _mouse.Length; i++)
            {
                LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Mouse, i, _mouse[i]);
            }

            LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Mousemat, 0, _mousepad);
        }
        if (!Global.DeviceConfig.DevicesDisableHeadset)
        {
            for (var i = 0; i < _headset.Length; i++)
            {
                LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Headset, i, _headset[i]);
            }

            for (var i = 0; i < 4; i++)//speakers have 4 leds
            {
                LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Speaker, i, _speakers);
            }
        }
        if (!Global.DeviceConfig.DevicesDisableKeyboard)
        {
            IsInitialized &= LogitechGSDK.LogiLedSetLightingFromBitmap(_logitechBitmap);
        }

        return Task.FromResult(IsInitialized);
    }

    protected override void RegisterVariables(VariableRegistry variableRegistry)
    {
        variableRegistry.Register($"{DeviceName}_set_default", false, "Set Default Color");
        variableRegistry.Register($"{DeviceName}_default_color", SimpleColor.FromArgb(255, 255, 255), "Default Color");
        variableRegistry.Register($"{DeviceName}_override_dll", false, "Override DLL", null, null, "Requires restart to take effect");
        variableRegistry.Register($"{DeviceName}_override_dll_option", LGDLL.GHUB, "Override DLL Selection", null, null, "Requires restart to take effect");
        variableRegistry.Register($"{DeviceName}_devicekey", DeviceKeys.Peripheral_Logo, "Key to Use", DeviceKeys.MOUSEPADLIGHT15, DeviceKeys.Peripheral);
    }
}