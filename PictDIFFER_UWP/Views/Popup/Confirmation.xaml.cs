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
using static PictDIFFER.Controls.Data.Prop_Popup.Title;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PictDIFFER.Views.Popup
{
    public sealed partial class Confirmation : ContentDialog
    {
        public string PopupType;
        public List<string> StegoImage = new List<string>()
        {
            Data.Misc.Stego1,
            Data.Misc.Stego2,
            Data.Misc.Stego3
        };
        public List<string> EmbeddedFile = new List<string>()
        {
            Data.Misc.Embedded1,
            Data.Misc.Embedded2
        };

        public Confirmation()
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
        #region SetComboBox
        private void SetCombo(string type)
        {
            if (type == Detail.Stego_Image)
            {
                cmb_List.ItemsSource = StegoImage;
            }
            else
            {
                cmb_List.ItemsSource = EmbeddedFile;
            }
            cmb_List.SelectedIndex = 0;
            Process.GetData.SelectedTest = cmb_List.SelectedValue.ToString();
        }
        #endregion

        private void ContentDialog_Loading(FrameworkElement sender, object args)
        {
            Init_Theme();
            SetCombo(PopupType);
            lbl_icon.Text = Icon.Flat;
            lbl_detail.Text = String.Format("Choose testing type in {0} !", PopupType);
        }

        private void cmb_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Process.GetData.SelectedTest = cmb_List.SelectedValue.ToString();
        }
    }
}
