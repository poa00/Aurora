﻿using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;
using AuroraRgb.Utils.Steam;
using MessageBox = System.Windows.MessageBox;

namespace AuroraRgb.Profiles.Witcher3;

/// <summary>
/// Interaction logic for Control_Witcher3.xaml
/// </summary>
public partial class Control_Witcher3
{
    public Control_Witcher3(Application _)
    {
        InitializeComponent();
    }

    //Overview
        
    private void install_mod_button_Click(object? sender, RoutedEventArgs e)
    {
        var installpath = SteamUtils.GetGamePath(292030);
        if (!string.IsNullOrWhiteSpace(installpath))//if we find the path through steam
        {
            InstallMod(installpath);
        }
        else//user could have the GOG version of the game
        {
            MessageBox.Show("Witcher 3 was not installed through steam, please pick the path manually");
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                InstallMod(dialog.SelectedPath);
            }
        }
    }

    private void uninstall_mod_button_Click(object? sender, RoutedEventArgs e)
    {
        var installPath = SteamUtils.GetGamePath(292030);
        if (!string.IsNullOrWhiteSpace(installPath))
        {
            UninstallMod(installPath);
        }
        else
        {
            MessageBox.Show("Witcher 3 was not installed through steam, please pick the path manually");
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UninstallMod(dialog.SelectedPath);
            }
        }
    }

    private void Hyperlink_RequestNavigate(object? sender, RequestNavigateEventArgs e)
    {
        Process.Start("explorer", e.Uri.AbsoluteUri);
        e.Handled = true;
    }

    private void InstallMod(string root)
    {
        if (!Directory.Exists(root))
        {
            MessageBox.Show("Witcher 3 directory not found");
            return;
        }

        try
        {
            ExtractZip(root);
            AddConfigLines(root);
            MessageBox.Show("Witcher 3 mod installed.");
        }
        catch (Exception e)
        {
            Global.logger.Error("Error installing the Witcher 3 mod", e);
            MessageBox.Show("Witcher 3 directory is not found.\r\nCould not install the mod.");
        }
    }

    private static void ExtractZip(string root)
    {
        using var w3Mod = new MemoryStream(Properties.Resources.witcher3_mod);
        using var zip = new ZipArchive(w3Mod);
        foreach (var entry in zip.Entries)
        {
            var lowerByte = (byte)(entry.ExternalAttributes & 0x00FF);
            var attributes = (FileAttributes)lowerByte;
            if (attributes.HasFlag(FileAttributes.Directory))
            {
                Directory.CreateDirectory(Path.Combine(root, entry.FullName));
            }
            else
            {
                entry.ExtractToFile(Path.Combine(root, entry.FullName), true);
            }
        }
    }

    private static void AddConfigLines(string root)
    {
        var folder = Path.Combine(root, "bin\\config\\r4game\\user_config_matrix\\pc");
        var dx11File = Path.Combine(folder, "dx11filelist.txt");
        var dx12File = Path.Combine(folder, "dx12filelist.txt");

        AddConfigLine(dx11File);
        AddConfigLine(dx12File);
    }

    private static void AddConfigLine(string file)
    {
        if (File.ReadAllLines(file).Any(line => line.Equals("artemis.xml;")))
        {
            return;
        }

        File.AppendAllLines(file, new []{"\nartemis.xml;"});
    }

    private void UninstallMod(string root)
    {
        if (!Directory.Exists(root))
        {
            MessageBox.Show("Witcher 3 directory not found");
            return;
        }

        var modfolder = Path.Combine(root, "mods", "modArtemis");
        var cfgfile = Path.Combine(root, "bin", "config", "r4game", "user_config_matrix", "pc", "artemis.xml");
        try
        {
            var previouslyInstalled = false;
            if (Directory.Exists(modfolder))
            {
                previouslyInstalled = true;
                Directory.Delete(modfolder, true);
            }
            if (File.Exists(cfgfile))
            {
                previouslyInstalled = true;
                File.Delete(cfgfile);
            }

            if(previouslyInstalled)
                MessageBox.Show("Witcher 3 mod uninstalled successfully!");
            else
                MessageBox.Show("Witcher 3 mod already uninstalled!");
        }
        catch (Exception e)
        {
            Global.logger.Error("Error uninstalling witcher 3 mod", e);
            MessageBox.Show("Witcher 3 mod uninstall failed!");
        }
    }
}