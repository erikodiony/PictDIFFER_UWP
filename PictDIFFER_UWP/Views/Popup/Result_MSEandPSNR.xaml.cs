using PictDIFFER.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class Result_MSEandPSNR : ContentDialog
    {
        public Result_MSEandPSNR()
        {
           InitializeComponent();
        }
        
        #region SetTheme
        private void Init_Theme()
        {
            string value = (string)ApplicationData.Current.LocalSettings.Values["BG_set"];
            var setTheme = Process.Theme.GetTheme(value) == true ? RequestedTheme = ElementTheme.Light : RequestedTheme = ElementTheme.Dark;
            Process.Theme.SetTheme(setTheme.ToString());
        }
        #endregion

        private void ContentDialog_Loading(FrameworkElement sender, object args)
        {
            Init_Theme();

            lbl_mse_b.Text = String.Format("MSE | Blue : {0}", Process.GetData.DataResult[Data.Misc.MSE_B]);
            lbl_mse_g.Text = String.Format("MSE | Green : {0}", Process.GetData.DataResult[Data.Misc.MSE_G]);
            lbl_mse_r.Text = String.Format("MSE | Red : {0}", Process.GetData.DataResult[Data.Misc.MSE_R]);
            lbl_mse_a.Text = String.Format("MSE | Alpha : {0}", Process.GetData.DataResult[Data.Misc.MSE_A]);
            lbl_mse_all.Text = String.Format("MSE | All : {0}", Process.GetData.DataResult[Data.Misc.MSE_ALL]);

            lbl_psnr_b.Text = String.Format("PSNR | Blue : {0}", Process.GetData.DataResult[Data.Misc.PSNR_B]);
            lbl_psnr_g.Text = String.Format("PSNR | Green : {0}", Process.GetData.DataResult[Data.Misc.PSNR_G]);
            lbl_psnr_r.Text = String.Format("PSNR | Red : {0}", Process.GetData.DataResult[Data.Misc.PSNR_R]);
            lbl_psnr_a.Text = String.Format("PSNR | Alpha : {0}", Process.GetData.DataResult[Data.Misc.PSNR_A]);
            lbl_psnr_all.Text = String.Format("PSNR | All : {0}", Process.GetData.DataResult[Data.Misc.PSNR_ALL]);

            Process.GetData.DataResult.Clear();
        }
    }
}
