﻿using Aurora.Settings;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Aurora.Profiles.Overwatch
{
    /// <summary>
    /// Interaction logic for Control_Overwatch.xaml
    /// </summary>
    public partial class Control_Overwatch : UserControl
    {
        private ProfileManager profile_manager;

        public Control_Overwatch()
        {
            InitializeComponent();

            profile_manager = Global.Configuration.ApplicationProfiles["Overwatch"];

            SetSettings();
        }

        private void SetSettings()
        {
            this.game_enabled.IsChecked = (profile_manager.Settings as OverwatchSettings).isEnabled;
        }

        private void patch_button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if(result == System.Windows.Forms.DialogResult.OK)
            {
                using (BinaryWriter razer_wrapper_86 = new BinaryWriter(new FileStream(System.IO.Path.Combine(dialog.SelectedPath, "RzChromaSDK.dll"), FileMode.Create)))
                {
                    razer_wrapper_86.Write(Properties.Resources.Aurora_RazerLEDWrapper86);
                }

                using (BinaryWriter razer_wrapper_64 = new BinaryWriter(new FileStream(System.IO.Path.Combine(dialog.SelectedPath, "RzChromaSDK64.dll"), FileMode.Create)))
                {
                    razer_wrapper_64.Write(Properties.Resources.Aurora_RazerLEDWrapper64);
                }

                MessageBox.Show("Aurora Wrapper Patch for Razer applied to\r\n" + dialog.SelectedPath);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Global.geh.SetPreview(PreviewType.Predefined, "overwatch.exe");
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Global.geh.SetPreview(PreviewType.Desktop);
        }

        private void game_enabled_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                (profile_manager.Settings as OverwatchSettings).isEnabled = (this.game_enabled.IsChecked.HasValue) ? this.game_enabled.IsChecked.Value : false;
                profile_manager.SaveProfiles();
            }
        }
    }
}
