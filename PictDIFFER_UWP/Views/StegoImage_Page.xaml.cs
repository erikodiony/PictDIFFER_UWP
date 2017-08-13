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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static PictDIFFER.Controls.Data.Prop_Popup;
using static PictDIFFER.Controls.Data.Prop_Popup.Title;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PictDIFFER.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StegoImage_Page : Page
    {
        public StegoImage_Page()
        {
            InitializeComponent();
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            Init_Theme();
            Init_Transition();
            Init_Page();
            Init_Tips();
        }

        #region Initializing Result
        private void Init_StegoImage_NEW(string type)
        {
            switch (type)
            {
                case "CVR":
                    CVR_picker_status_stego.Text = Process.GetData.Picker[Data.Misc.Name].ToString();
                    CVR_picker_path_stego.Text = Process.GetData.Picker[Data.Misc.Path].ToString();
                    CVR_picker_size_stego.Text = String.Format("{0} bytes", Process.GetData.Picker[Data.Misc.Size].ToString());
                    CVR_picker_dimension_stego.Text = Process.GetData.Picker[Data.Misc.Dimensions].ToString();
                    CVR_picker_datecreated_stego.Text = Process.GetData.Picker[Data.Misc.DateCreated].ToString();
                    CVR_picker_ico_stego.Source = (BitmapImage)Process.GetData.Picker[Data.Misc.Icon];
                    CVR_picker_ico_stego.Visibility = Visibility.Visible;
                    break;
                case "STG":
                    STG_picker_status_stego.Text = Process.GetData.Picker[Data.Misc.Name].ToString();
                    STG_picker_path_stego.Text = Process.GetData.Picker[Data.Misc.Path].ToString();
                    STG_picker_size_stego.Text = String.Format("{0} bytes", Process.GetData.Picker[Data.Misc.Size].ToString());
                    STG_picker_dimension_stego.Text = Process.GetData.Picker[Data.Misc.Dimensions].ToString();
                    STG_picker_datecreated_stego.Text = Process.GetData.Picker[Data.Misc.DateCreated].ToString();
                    STG_picker_ico_stego.Source = (BitmapImage)Process.GetData.Picker[Data.Misc.Icon];
                    STG_picker_ico_stego.Visibility = Visibility.Visible;
                    break;
            }
        }
        #endregion
        #region Initializing Property
        private void Init_Page()
        {
            Init_CVR_StegoImage();
            Init_STG_StegoImage();

            HeaderInfo.Text = Data.Prop_Page.StegoPage;
            stego_btn_ClearAll_FooterMenu.Label = Data.Prop_Button.ClearAll;
            stego_btn_Execute_FooterMenu.Label = Data.Prop_Button.Execute;
        }
        private void Init_CVR_StegoImage()
        {
            CVR_picker_ico_stego.Visibility = Visibility.Collapsed;
            CVR_lbl_title_stego.Text = Data.Prop_Image_Cover.title;
            CVR_lbl_subtitle_stego.Text = Data.Prop_Image_Cover.subtitle;
            CVR_picker_status_stego.Text = Data.Prop_Image_Cover.picker_status;
            CVR_lbl_path_stego.Text = Data.Prop_Image_Cover.picker_path;
            CVR_picker_path_stego.Text = "-";
            CVR_lbl_size_stego.Text = Data.Prop_Image_Cover.picker_size;
            CVR_picker_size_stego.Text = "-";
            CVR_lbl_dimension_stego.Text = Data.Prop_Image_Cover.picker_dimension;
            CVR_picker_dimension_stego.Text = "-";
            CVR_lbl_datecreated_stego.Text = Data.Prop_Image_Cover.picker_datecreated;
            CVR_picker_datecreated_stego.Text = "-";
            CVR_btn_input_stego.Content = Data.Prop_Image_Cover.button;
        }
        private void Init_STG_StegoImage()
        {
            STG_picker_ico_stego.Visibility = Visibility.Collapsed;
            STG_lbl_title_stego.Text = Data.Prop_Image_Stego.title;
            STG_lbl_subtitle_stego.Text = Data.Prop_Image_Stego.subtitle;
            STG_picker_status_stego.Text = Data.Prop_Image_Stego.picker_status;
            STG_lbl_path_stego.Text = Data.Prop_Image_Stego.picker_path;
            STG_picker_path_stego.Text = "-";
            STG_lbl_size_stego.Text = Data.Prop_Image_Stego.picker_size;
            STG_picker_size_stego.Text = "-";
            STG_lbl_dimension_stego.Text = Data.Prop_Image_Stego.picker_dimension;
            STG_picker_dimension_stego.Text = "-";
            STG_lbl_datecreated_stego.Text = Data.Prop_Image_Stego.picker_datecreated;
            STG_picker_datecreated_stego.Text = "-";
            STG_btn_input_stego.Content = Data.Prop_Image_Stego.button;
        }
        #endregion
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
            if (value == "True")
            {
                Tips_Prop.Visibility = Visibility.Visible;
                Tips_Prop2.Visibility = Visibility.Visible;
                Tips_Prop3.Margin = new Thickness(0, 0, 0, 0);
            }
            else
            {
                Tips_Prop.Visibility = Visibility.Collapsed;
                Tips_Prop2.Visibility = Visibility.Collapsed;
                Tips_Prop3.Margin = new Thickness(0, -20, 0, 0);
            }
        }
        #endregion

        private async void stego_btn_ClearAll_FooterMenu_Click(object sender, RoutedEventArgs e)
        {
            Init_Page();
            Process.GetData.Reset_Data();
            await PopupDialog.Show(Status.Success, Detail.Stego_Image, Complete.Clear_All, Icon.Smile);
        }

        private void stego_btn_Execute_FooterMenu_Click(object sender, RoutedEventArgs e)
        {
            Exec();
            //await PopupDialog.StegoImage.Histogram_Show(Data.Misc.Stego1);
        }

        private async void CVR_btn_input_stego_Click(object sender, RoutedEventArgs e)
        {
            if (await Process.Picker.Execute(Data.File_Extensions.Png, Data.Misc.CVR) == true) Init_StegoImage_NEW(Data.Misc.CVR); else Init_CVR_StegoImage();
        }

        private async void STG_btn_input_stego_Click(object sender, RoutedEventArgs e)
        {
            if (await Process.Picker.Execute(Data.File_Extensions.Png, Data.Misc.STG) == true) Init_StegoImage_NEW(Data.Misc.STG); else Init_STG_StegoImage();
        }

        private async void Exec()
        {
            if (CVR_picker_status_stego.Text != Data.Prop_Image_Cover.picker_status && STG_picker_status_stego.Text != Data.Prop_Image_Stego.picker_status)
            {
                if (await PopupDialog.ShowConfirm(Detail.Stego_Image) == true) Process.Init(Process.GetData.SelectedTest);
            }
            else
            {
                await PopupDialog.Show(Status.Err, Detail.Stego_Image, Err.Input_isNull, Icon.Sad);
            }
        }

    }
}
