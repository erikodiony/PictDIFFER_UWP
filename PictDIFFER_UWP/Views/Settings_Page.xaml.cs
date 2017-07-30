﻿using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PictDIFFER.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings_Page : Page
    {
        public Settings_Page()
        {
            InitializeComponent();
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            Init_Theme();
            Init_Transition();
            HeaderInfo.Text = Data.Prop_Page.SettingsPage;
        }

        #region Trigger Toggle Switch
        private void Toggle_BG_Toggled(object sender, RoutedEventArgs e)
        {
            if (Toggle_BG.IsOn == true)
            {
                ApplicationData.Current.LocalSettings.Values["BG_set"] = "Dark";
                RequestedTheme = ElementTheme.Dark;
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values["BG_set"] = "Light";
                RequestedTheme = ElementTheme.Light;
            }
        }
        #endregion
        #region Trigger ComboBox
        private void cb_effect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_effect.SelectedValue.ToString() == "Effect 1")
            {
                ApplicationData.Current.LocalSettings.Values["Effect_set"] = "Continuum";
            }
            else if (cb_effect.SelectedValue.ToString() == "Effect 2")
            {
                ApplicationData.Current.LocalSettings.Values["Effect_set"] = "Common";
            }
            else if (cb_effect.SelectedValue.ToString() == "Effect 3")
            {
                ApplicationData.Current.LocalSettings.Values["Effect_set"] = "Slide";
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values["Effect_set"] = "Off";
            }
        }
        #endregion
        #region Initializing Animation
        private void Init_Transition()
        {
            string value = (string)ApplicationData.Current.LocalSettings.Values["Effect_set"];
            Transitions = Process.Transition.GetTransition(value);
            cb_effect.SelectedValue = Process.Transition.SetTransitionStatus(value);
            Process.Transition.SetTransition(value);

        }
        private void Init_Theme()
        {
            string value = (string)ApplicationData.Current.LocalSettings.Values["BG_set"];
            var setTheme = Process.Theme.GetTheme(value) == true ? RequestedTheme = ElementTheme.Light : RequestedTheme = ElementTheme.Dark;
            if (RequestedTheme == ElementTheme.Light) Toggle_BG.IsOn = false; else Toggle_BG.IsOn = true;
            Process.Theme.SetTheme(setTheme.ToString());
        }
        #endregion
    }
}