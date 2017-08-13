using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using MyToolkit.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;
using PictDIFFER.Controls;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PictDIFFER.Views.Popup
{
    public sealed partial class Result_Pixel : ContentDialog
    {
        public List<int> limit = new List<int>()
        {
            100,
            250,
            500,
        };

        public Result_Pixel()
        {
            InitializeComponent();
            cmb.ItemsSource = limit;
            cmb.SelectedIndex = 0;
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

        private async void ContentDialog_Loading(FrameworkElement sender, object args)
        {
            Init_Theme();
            await ViewBinding(100);
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Process.GetData.DataResult.Clear();
        }

        private async Task ViewBinding(int limit)
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

            await Task.Delay(3500);

            CVR_DataGrid.ItemsSource = CVR_List;
            STG_DataGrid.ItemsSource = STG_List;
        }

        private async Task ViewBindingCustom(string x, string y)
        {
            var CVR_List = new List<Point_CVR>();
            var STG_List = new List<Point_STG>();

            int point_CVR = Array.IndexOf(((string[])Process.GetData.DataResult[Data.Misc.CVR_XY]), String.Format("{0},{1}", x, y));
            int point_STG = Array.IndexOf(((string[])Process.GetData.DataResult[Data.Misc.STG_XY]), String.Format("{0},{1}", x, y));

            if (point_CVR > -1 && point_STG > -1)
            {
                p_ring_xy.Visibility = Visibility.Visible;

                CVR_List.Add(new Point_CVR()
                {
                    CVR_XY = ((string[])Process.GetData.DataResult[Data.Misc.CVR_XY])[point_CVR],
                    CVR_B = ((byte[])Process.GetData.DataResult[Data.Misc.CVR_B])[point_CVR].ToString(),
                    CVR_G = ((byte[])Process.GetData.DataResult[Data.Misc.CVR_G])[point_CVR].ToString(),
                    CVR_R = ((byte[])Process.GetData.DataResult[Data.Misc.CVR_R])[point_CVR].ToString(),
                    CVR_A = ((byte[])Process.GetData.DataResult[Data.Misc.CVR_A])[point_CVR].ToString(),
                });

                STG_List.Add(new Point_STG()
                {
                    STG_XY = ((string[])Process.GetData.DataResult[Data.Misc.STG_XY])[point_STG],
                    STG_B = ((byte[])Process.GetData.DataResult[Data.Misc.STG_B])[point_STG].ToString(),
                    STG_G = ((byte[])Process.GetData.DataResult[Data.Misc.STG_G])[point_STG].ToString(),
                    STG_R = ((byte[])Process.GetData.DataResult[Data.Misc.STG_R])[point_STG].ToString(),
                    STG_A = ((byte[])Process.GetData.DataResult[Data.Misc.STG_A])[point_STG].ToString(),
                });

                await Task.Delay(3500);
                CVR_DataGrid.ItemsSource = CVR_List;
                STG_DataGrid.ItemsSource = STG_List;
            }
            else
            {
                lbl_err.Visibility = Visibility.Visible;
                await Task.Delay(3500);
                lbl_err.Visibility = Visibility.Collapsed;
            }
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

        private async void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_ring_limit.Visibility = Visibility.Visible;
            Task x = ViewBinding(int.Parse(cmb.SelectedValue.ToString()));
            await x;
            if (x.IsCompleted) p_ring_limit.Visibility = Visibility.Collapsed;
        }

        private void btn_point_Click(object sender, RoutedEventArgs e)
        {
            CheckPoint();
        }

        private async void CheckPoint()
        {
            Task x = ViewBindingCustom(tbox_x.Text, tbox_y.Text);
            await x;
            if (x.IsCompleted) p_ring_xy.Visibility = Visibility.Collapsed;
        }
    }
}
