using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using MyToolkit.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PictDIFFER.Views.Popup
{
    public sealed partial class Result_Pixel : ContentDialog
    {
        public Result_Pixel()
        {
            InitializeComponent();
            ViewBinding(50);
        }

        #region SetTheme
        private void Init_Theme()
        {
            string value = (string)ApplicationData.Current.LocalSettings.Values["BG_set"];
            var setTheme = Process.Theme.GetTheme(value) == true ? RequestedTheme = ElementTheme.Light : RequestedTheme = ElementTheme.Dark;
            if (setTheme == ElementTheme.Light)
            {
                CVR_lbl_xy.Foreground = new SolidColorBrush(Colors.Black);
                CVR_lbl_b.Foreground = new SolidColorBrush(Colors.Black);
                CVR_lbl_g.Foreground = new SolidColorBrush(Colors.Black);
                CVR_lbl_r.Foreground = new SolidColorBrush(Colors.Black);
                CVR_lbl_a.Foreground = new SolidColorBrush(Colors.Black);

                STG_lbl_xy.Foreground = new SolidColorBrush(Colors.Black);
                STG_lbl_b.Foreground = new SolidColorBrush(Colors.Black);
                STG_lbl_g.Foreground = new SolidColorBrush(Colors.Black);
                STG_lbl_r.Foreground = new SolidColorBrush(Colors.Black);
                STG_lbl_a.Foreground = new SolidColorBrush(Colors.Black);
            }
            Process.Theme.SetTheme(setTheme.ToString());
        }
        #endregion

        private void ContentDialog_Loading(FrameworkElement sender, object args)
        {
            Init_Theme();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Process.GetData.DataResult.Clear();
        }

        private void ViewBinding(int limit)
        {
            var CVR_List = new List<Point_CVR>();
            var STG_List = new List<Point_STG>();
            for (int i = 0; i < limit; i++)
            {
                CVR_List.Add(new Point_CVR()
                {
                    CVR_XY = ((string[])Process.GetData.DataResult[Data.Misc.CVR_XY])[i],
                    CVR_B = ((byte[])Process.GetData.DataResult[Data.Misc.CVR_B])[i].ToString(),
                    CVR_G = ((byte[])Process.GetData.DataResult[Data.Misc.CVR_G])[i].ToString(),
                    CVR_R = ((byte[])Process.GetData.DataResult[Data.Misc.CVR_R])[i].ToString(),
                    CVR_A = ((byte[])Process.GetData.DataResult[Data.Misc.CVR_A])[i].ToString(),
                });

                STG_List.Add(new Point_STG()
                {
                    STG_XY = ((string[])Process.GetData.DataResult[Data.Misc.STG_XY])[i],
                    STG_B = ((byte[])Process.GetData.DataResult[Data.Misc.STG_B])[i].ToString(),
                    STG_G = ((byte[])Process.GetData.DataResult[Data.Misc.STG_G])[i].ToString(),
                    STG_R = ((byte[])Process.GetData.DataResult[Data.Misc.STG_R])[i].ToString(),
                    STG_A = ((byte[])Process.GetData.DataResult[Data.Misc.STG_A])[i].ToString(),
                });
            }
            CVR_DataGrid.ItemsSource = CVR_List;
            STG_DataGrid.ItemsSource = STG_List;
        }

        #region for Data Binding
        public class Point_CVR
        {
            public string CVR_XY { get; set; }
            public string CVR_B { get; set; }
            public string CVR_G { get; set; }
            public string CVR_R { get; set; }
            public string CVR_A { get; set; }
        }

        public class Point_STG
        {
            public string STG_XY { get; set; }
            public string STG_B { get; set; }
            public string STG_G { get; set; }
            public string STG_R { get; set; }
            public string STG_A { get; set; }
        }
        #endregion

    }
}
