﻿using System;
using System.Linq;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PictDIFFER
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            ShowStatusBar();
            Init_Theme();
            Init_Transition();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MyFrame.Navigate(typeof(Views.Home_Page));
            Header.Text = "Home";
            Header.FontSize = 17;
            HomeRadioBtn.IsChecked = true;
        }

        private void SplitTogleBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuList.IsPaneOpen = !MenuList.IsPaneOpen;
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button != null)
            {
                switch (button.Content.ToString())
                {
                    case "Home":
                        Info_Page.Visibility = Visibility.Collapsed;
                        MyFrame.Navigate(typeof(Views.Home_Page));
                        break;
                    case "Stego Image Test":
                        Info_Page.Visibility = Visibility.Visible;
                        MyFrame.Navigate(typeof(Views.StegoImage_Page));
                        break;
                    case "Embedded File Test":
                        Info_Page.Visibility = Visibility.Visible;
                        MyFrame.Navigate(typeof(Views.EmbeddedFile_Page));
                        break;
                    case "Settings":
                        Info_Page.Visibility = Visibility.Visible;
                        MyFrame.Navigate(typeof(Views.Settings_Page));
                        break;
                    case "About":
                        Info_Page.Visibility = Visibility.Visible;
                        MyFrame.Navigate(typeof(Views.About_Page));
                        break;
                }
                Header.Text = button.Content.ToString();
                if (int.Parse(((Frame)Window.Current.Content).ActualWidth.ToString()) < 1024)
                {
                    MenuList.IsPaneOpen = false;
                }
            }
        }

        // show the StatusBar
        public static void ShowStatusBar()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                StatusBar.GetForCurrentView();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Init_Tips();
        }

        private bool CheckStatusTips()
        {
            return true;
        }


        #region Initializing Animation
        private void Init_Transition()
        {
            string value = (string)ApplicationData.Current.LocalSettings.Values["Effect_set"];
            Transitions = Process.Transition.GetTransition(value);
            Process.Transition.SetTransition(value);
        }
        private void Init_Theme()
        {
            string value = (string)ApplicationData.Current.LocalSettings.Values["BG_set"];
            var setTheme = Process.Theme.GetTheme(value) == true ? RequestedTheme = ElementTheme.Light : RequestedTheme = ElementTheme.Dark;
            Process.Theme.SetTheme(setTheme.ToString());
        }
        #endregion

        #region Initializing Tips
        private void Init_Tips()
        {
            string value = (string)ApplicationData.Current.LocalSettings.Values["Tips_set"];
            var setTips = Process.Tips.GetTips(value) == false ? Toggle_Tips.IsOn = false : Toggle_Tips.IsOn = true;
            Process.Tips.SetTips(setTips.ToString());
        }
        #endregion

        private void Toggle_Tips_Toggled(object sender, RoutedEventArgs e)
        {
            string value = String.Empty;
            if (Toggle_Tips.IsOn == true) value = "True"; else value = "False";
            Process.Tips.SetTips(value);
            MyFrame.Navigate(MyFrame.SourcePageType);
        }
    }
}
