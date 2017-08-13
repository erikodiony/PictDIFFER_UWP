using PictDIFFER.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PictDIFFER.Views.Popup
{
    public sealed partial class Result_Histogram : ContentDialog
    {
        public Result_Histogram()
        {
            InitializeComponent();
        }

        #region SetTheme
        private void Init_Theme()
        {
            string value = (string)ApplicationData.Current.LocalSettings.Values["BG_set"];
            var setTheme = Process.Theme.GetTheme(value) == true ? RequestedTheme = ElementTheme.Light : RequestedTheme = ElementTheme.Dark;
            if ((setTheme == ElementTheme.Light) == true)
            {
                CVR_B_border.BorderBrush = new SolidColorBrush(Colors.Black);
                CVR_G_border.BorderBrush = new SolidColorBrush(Colors.Black);
                CVR_R_border.BorderBrush = new SolidColorBrush(Colors.Black);
                STG_B_border.BorderBrush = new SolidColorBrush(Colors.Black);
                STG_G_border.BorderBrush = new SolidColorBrush(Colors.Black);
                STG_R_border.BorderBrush = new SolidColorBrush(Colors.Black);
            }
            else
            {
                CVR_B_border.BorderBrush = new SolidColorBrush(Colors.White);
                CVR_G_border.BorderBrush = new SolidColorBrush(Colors.White);
                CVR_R_border.BorderBrush = new SolidColorBrush(Colors.White);
                STG_B_border.BorderBrush = new SolidColorBrush(Colors.White);
                STG_G_border.BorderBrush = new SolidColorBrush(Colors.White);
                STG_R_border.BorderBrush = new SolidColorBrush(Colors.White);
            }
            Process.Theme.SetTheme(setTheme.ToString());
        }
        #endregion

        private void ContentDialog_Loading(FrameworkElement sender, object args)
        {
            Init_Theme();

            blue_cover.Points = (PointCollection)Process.GetData.DataResult[Data.Misc.CVR_B];
            green_cover.Points = (PointCollection)Process.GetData.DataResult[Data.Misc.CVR_G];
            red_cover.Points = (PointCollection)Process.GetData.DataResult[Data.Misc.CVR_R];

            blue_stego.Points = (PointCollection)Process.GetData.DataResult[Data.Misc.STG_B];
            green_stego.Points = (PointCollection)Process.GetData.DataResult[Data.Misc.STG_G];
            red_stego.Points = (PointCollection)Process.GetData.DataResult[Data.Misc.STG_R];

            Process.GetData.DataResult.Clear();
        }
    }
}
