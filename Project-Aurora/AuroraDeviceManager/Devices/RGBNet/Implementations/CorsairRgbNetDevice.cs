﻿using AuroraDeviceManager.Utils;
using Common.Devices;
using Common.Utils;
using RGB.NET.Core;
using RGB.NET.Devices.CorsairLegacy;

namespace AuroraDeviceManager.Devices.RGBNet.Implementations;

public class CorsairRgbNetDevice : RgbNetDevice
{
    protected override CorsairLegacyDeviceProvider Provider => CorsairLegacyDeviceProvider.Instance;

    public override string DeviceName => "Corsair (RGB.NET)";

    protected override void RegisterVariables(VariableRegistry variableRegistry)
    {
        base.RegisterVariables(variableRegistry);

        variableRegistry.Register($"{DeviceName}_exclusive", false, "Request exclusive control");
    }

    protected override bool OnShutdown()
    {
        base.OnShutdown();

        return !App.Closing;
    }

    protected override async Task ConfigureProvider(CancellationToken cancellationToken)
    {
        await base.ConfigureProvider(cancellationToken);

        var waitSessionUnlock = await DesktopUtils.WaitSessionUnlock();
        if (waitSessionUnlock)
        {
            Global.Logger.Information("Waiting for Corsair to load after unlock");
            await Task.Delay(5000, cancellationToken);
        }
        
        var isIcueRunning = ProcessUtils.IsProcessRunning("icue");
        if (!isIcueRunning)
        {
            throw new DeviceProviderException(new ApplicationException("iCUE is not running!"), false);
        }

        if (!IsNamedPipeOpen("iCUESDKv4"))
        {
            throw new DeviceProviderException(new ApplicationException("iCUE SDK not started yet!"), false);
        }

        //give iCUE some time to initialize
        await Task.Delay(1500, cancellationToken);

        //var exclusive = Global.DeviceConfig.VarRegistry.GetVariable<bool>($"{DeviceName}_exclusive");

        //Provider.ExclusiveAccess = exclusive;
        //Provider.ConnectionTimeout = new TimeSpan(0, 0, 5);

        //Provider.SessionStateChanged += SessionStateChanged;
    }

    /*
    private void SessionStateChanged(object? sender, CorsairSessionState e)
    {
        if (e != CorsairSessionState.Closed) return;
        Provider.SessionStateChanged -= SessionStateChanged;

        IsInitialized = false;
    }
    */

    private static bool IsNamedPipeOpen(string pipeName)
    {
        try
        {
            using var fileStream = new FileStream(@"\\.\pipe\" + pipeName, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            // If the FileStream can be opened, the named pipe exists and is open
            return true;
        }
        catch (IOException)
        {
            // IOException will be thrown if the pipe does not exist or is not available
            return false;
        }
        catch (UnauthorizedAccessException)
        {
            // Handle access issues if necessary
            return false;
        }
    }
}