﻿using System;
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
                        Info_Page.Visibility = Visibility.Visible;
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
                var statusBar = StatusBar.GetForCurrentView();
            }
        }

    }
}
