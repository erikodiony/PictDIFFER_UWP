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
    public sealed partial class Result_EmbeddedFile : ContentDialog
    {
        public Result_EmbeddedFile()
        {
            InitializeComponent();

        }

        private string CheckValid()
        {
            if ((string)Process.GetData.DataResult[Data.Misc.ORI] == (string)Process.GetData.DataResult[Data.Misc.EMB])
            {
                lbl_icon.Text = Data.Prop_Popup.Title.Icon.Smile;                
                return "File is Same / Identic";
            }
            else
            {
                lbl_icon.Text = Data.Prop_Popup.Title.Icon.Sad;
                return "File isn't Same / Identic";
            }
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
            lbl_title_origin.Text = Data.Misc.OriginFile;
            lbl_title_embedded.Text = Data.Misc.EmbeddedFile;
            lbl_hash_origin.Text = String.Format("Hash : {0}", (string)Process.GetData.DataResult[Data.Misc.ORI]);
            lbl_hash_embedded.Text = String.Format("Hash : {0}", (string)Process.GetData.DataResult[Data.Misc.EMB]);
            lbl_result.Text = CheckValid();
            Process.GetData.DataResult.Clear();
        }
    }
}
