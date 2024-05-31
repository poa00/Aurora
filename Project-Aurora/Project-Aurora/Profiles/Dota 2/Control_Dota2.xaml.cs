﻿using System;
using System.IO;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using AuroraRgb.Profiles.Dota_2.GSI;
using AuroraRgb.Profiles.Dota_2.GSI.Nodes;
using AuroraRgb.Settings;
using AuroraRgb.Utils.Steam;

namespace AuroraRgb.Profiles.Dota_2;

/// <summary>
/// Interaction logic for Control_Dota2.xaml
/// </summary>
public partial class Control_Dota2
{
    private readonly Application _profileManager;

    private int _respawnTime = 15;
    private readonly Timer _previewRespawnTimer;
    private int _killstreak;

    public Control_Dota2(Application profile)
    {
        InitializeComponent();

        _profileManager = profile;

        SetSettings();

        _previewRespawnTimer = new Timer(1000);
        _previewRespawnTimer.Elapsed += preview_respawn_timer_Tick;

        //Copy cfg file if needed
        if (!(_profileManager.Settings as FirstTimeApplicationSettings).IsFirstTimeInstalled)
        {
            InstallGsi();
            (_profileManager.Settings as FirstTimeApplicationSettings).IsFirstTimeInstalled = true;
        }

        _profileManager.ProfileChanged += Control_Dota2_ProfileChanged;

    }

    private void Control_Dota2_ProfileChanged(object? sender, EventArgs e)
    {
        SetSettings();
    }

    private void SetSettings()
    {
        if (preview_team.HasItems) return;
        preview_team.Items.Add(PlayerTeam.None);
        preview_team.Items.Add(PlayerTeam.Dire);
        preview_team.Items.Add(PlayerTeam.Radiant);
    }

    private void preview_respawn_timer_Tick(object? sender, EventArgs e)
    {
        Dispatcher.Invoke(
            () =>
            {
                if (_respawnTime < 0)
                {
                    (_profileManager.Config.Event._game_state as GameStateDota2).Hero.IsAlive = true;

                    preview_killplayer.IsEnabled = true;

                    _previewRespawnTimer.Stop();
                }
                else
                {
                    preview_respawn_time.Content = "Seconds to respawn: " + _respawnTime;
                    (_profileManager.Config.Event._game_state as GameStateDota2).Hero.SecondsToRespawn = _respawnTime;

                    _respawnTime--;
                }
            });
    }

    //Overview

    private void patch_button_Click(object? sender, RoutedEventArgs e)
    {
        if (InstallGsi())
            MessageBox.Show("Aurora GSI Config file installed successfully.");
        else
            MessageBox.Show("Aurora GSI Config file could not be installed.\r\nGame is not installed.");
    }

    private void unpatch_button_Click(object? sender, RoutedEventArgs e)
    {
        if (UninstallGsi())
            MessageBox.Show("Aurora GSI Config file uninstalled successfully.");
        else
            MessageBox.Show("Aurora GSI Config file could not be uninstalled.\r\nGame is not installed.");
    }

    ////Preview

    private void preview_team_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        (_profileManager.Config.Event._game_state as GameStateDota2).Player.Team = (PlayerTeam)preview_team.SelectedItem;
    }

    private void preview_health_slider_ValueChanged(object? sender, RoutedPropertyChangedEventArgs<double> e)
    {
        var hp_val = (int)preview_health_slider.Value;
        if (preview_health_amount is not Label) return;
        preview_health_amount.Content = hp_val + "%";
                
        (_profileManager.Config.Event._game_state as GameStateDota2).Hero.Health = hp_val;
        (_profileManager.Config.Event._game_state as GameStateDota2).Hero.MaxHealth = 100;
        (_profileManager.Config.Event._game_state as GameStateDota2).Hero.HealthPercent = hp_val;
    }

    private void preview_mana_slider_ValueChanged(object? sender, RoutedPropertyChangedEventArgs<double> e)
    {
        var mana_val = (int)preview_mana_slider.Value;
        if (preview_mana_amount is not Label) return;
        preview_mana_amount.Content = mana_val + "%";

        (_profileManager.Config.Event._game_state as GameStateDota2).Hero.Mana = mana_val;
        (_profileManager.Config.Event._game_state as GameStateDota2).Hero.MaxMana = 100;
        (_profileManager.Config.Event._game_state as GameStateDota2).Hero.ManaPercent = mana_val;
    }

    private void preview_killplayer_Click(object? sender, RoutedEventArgs e)
    {
        (_profileManager.Config.Event._game_state as GameStateDota2).Hero.IsAlive = false;

        _respawnTime = 15;
        (_profileManager.Config.Event._game_state as GameStateDota2).Hero.SecondsToRespawn = _respawnTime;
        preview_killplayer.IsEnabled = false;
        (_profileManager.Config.Event._game_state as GameStateDota2).Player.KillStreak = _killstreak = 0;
        preview_killstreak_label.Content = "Killstreak: " + _killstreak;

        _previewRespawnTimer.Start();
    }

    private void preview_addkill_Click(object? sender, RoutedEventArgs e)
    {
        (_profileManager.Config.Event._game_state as GameStateDota2).Player.KillStreak = _killstreak++;
        (_profileManager.Config.Event._game_state as GameStateDota2).Player.Kills++;
        preview_killstreak_label.Content = "Killstreak: " + _killstreak;
    }

    private bool InstallGsi()
    {
        var installPath = SteamUtils.GetGamePath(570);
        if (string.IsNullOrWhiteSpace(installPath)) return false;
        var path = Path.Combine(installPath, "game", "dota", "cfg", "gamestate_integration", "gamestate_integration_aurora.cfg");

        if (!File.Exists(path))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }

        using var cfgStream = File.Create(path);
        cfgStream.Write(Properties.Resources.gamestate_integration_aurora_dota2, 0, Properties.Resources.gamestate_integration_aurora_dota2.Length);

        return true;

    }

    private bool UninstallGsi()
    {
        var installPath = SteamUtils.GetGamePath(570);
        if (string.IsNullOrWhiteSpace(installPath)) return false;
        var path = Path.Combine(installPath, "game", "dota", "cfg", "gamestate_integration", "gamestate_integration_aurora.cfg");

        if (File.Exists(path))
            File.Delete(path);

        return true;

    }
}