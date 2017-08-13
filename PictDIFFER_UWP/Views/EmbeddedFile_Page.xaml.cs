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
using PictDIFFER.Controls;
using static PictDIFFER.Controls.Data.Prop_Popup;
using static PictDIFFER.Controls.Data.Prop_Popup.Title;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PictDIFFER.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmbeddedFile_Page : Page
    {
        public EmbeddedFile_Page()
        {
            InitializeComponent();
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            Init_Theme();
            Init_Transition();
            Init_Tips();
            Init_Page();
        }

        #region Initializing Result
        private void Init_EmbeddedFile_NEW(string type)
        {
            switch (type)
            {
                case "ORI":
                    ORI_picker_status_file.Text = Process.GetData.Picker[Data.Misc.Name].ToString();
                    ORI_picker_path_file.Text = Process.GetData.Picker[Data.Misc.Path].ToString();
                    ORI_picker_size_file.Text = String.Format("{0} bytes", Process.GetData.Picker[Data.Misc.Size].ToString());
                    ORI_picker_type_file.Text = Process.GetData.Picker[Data.Misc.Type].ToString();
                    ORI_picker_datecreated_file.Text = Process.GetData.Picker[Data.Misc.DateCreated].ToString();
                    ORI_picker_ico_file.Source = (BitmapImage)Process.GetData.Picker[Data.Misc.Icon];
                    ORI_picker_ico_file.Visibility = Visibility.Visible;
                    break;
                case "EMB":
                    EMB_picker_status_file.Text = Process.GetData.Picker[Data.Misc.Name].ToString();
                    EMB_picker_path_file.Text = Process.GetData.Picker[Data.Misc.Path].ToString();
                    EMB_picker_size_file.Text = String.Format("{0} bytes", Process.GetData.Picker[Data.Misc.Size].ToString());
                    EMB_picker_type_file.Text = Process.GetData.Picker[Data.Misc.Type].ToString();
                    EMB_picker_datecreated_file.Text = Process.GetData.Picker[Data.Misc.DateCreated].ToString();
                    EMB_picker_ico_file.Source = (BitmapImage)Process.GetData.Picker[Data.Misc.Icon];
                    EMB_picker_ico_file.Visibility = Visibility.Visible;
                    break;
            }
        }
        #endregion
        #region Initializing Property
        private void Init_Page()
        {
            Init_ORI_file();
            Init_EMB_file();
            HeaderInfo.Text = Data.Prop_Page.EmbeddedPage;
            embedded_btn_Execute_FooterMenu.Label = Data.Prop_Button.Execute;
            embedded_btn_ClearAll_FooterMenu.Label = Data.Prop_Button.ClearAll;
        }
        private void Init_ORI_file()
        {
            ORI_picker_ico_file.Visibility = Visibility.Collapsed;
            ORI_lbl_title_file.Text = Data.Prop_Origin_File.title;
            ORI_lbl_subtitle_file.Text = Data.Prop_Origin_File.subtitle;
            ORI_picker_status_file.Text = Data.Prop_Origin_File.picker_status;
            ORI_lbl_path_file.Text = Data.Prop_Origin_File.picker_path;
            ORI_picker_path_file.Text = "-";
            ORI_lbl_size_file.Text = Data.Prop_Origin_File.picker_size;
            ORI_picker_size_file.Text = "-";
            ORI_lbl_type_file.Text = Data.Prop_Origin_File.picker_type;
            ORI_picker_type_file.Text = "-";
            ORI_lbl_datecreated_file.Text = Data.Prop_Origin_File.picker_datecreated;
            ORI_picker_datecreated_file.Text = "-";
            ORI_btn_input_file.Content = Data.Prop_Origin_File.button;
        }
        private void Init_EMB_file()
        {
            EMB_picker_ico_file.Visibility = Visibility.Collapsed;
            EMB_lbl_title_file.Text = Data.Prop_Embedded_File.title;
            EMB_lbl_subtitle_file.Text = Data.Prop_Embedded_File.subtitle;
            EMB_picker_status_file.Text = Data.Prop_Embedded_File.picker_status;
            EMB_lbl_path_file.Text = Data.Prop_Embedded_File.picker_path;
            EMB_picker_path_file.Text = "-";
            EMB_lbl_size_file.Text = Data.Prop_Embedded_File.picker_size;
            EMB_picker_size_file.Text = "-";
            EMB_lbl_type_file.Text = Data.Prop_Embedded_File.picker_type;
            EMB_picker_type_file.Text = "-";
            EMB_lbl_datecreated_file.Text = Data.Prop_Embedded_File.picker_datecreated;
            EMB_picker_datecreated_file.Text = "-";
            EMB_btn_input_file.Content = Data.Prop_Embedded_File.button;
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

        private async void embedded_btn_ClearAll_FooterMenu_Click(object sender, RoutedEventArgs e)
        {
            Init_Page();
            Process.GetData.Reset_Data();
            await PopupDialog.Show(Status.Success, Detail.Embedded_File, Complete.Clear_All, Icon.Smile);
        }

        private void embedded_btn_Execute_FooterMenu_Click(object sender, RoutedEventArgs e)
        {
            Exec();
        }

        private async void ORI_btn_input_file_Click(object sender, RoutedEventArgs e)
        {
            if (await Process.Picker.Execute(Data.File_Extensions.All, Data.Misc.ORI) == true) Init_EmbeddedFile_NEW(Data.Misc.ORI); else Init_ORI_file();
        }

        private async void EMB_btn_input_file_Click(object sender, RoutedEventArgs e)
        {
            if (await Process.Picker.Execute(Data.File_Extensions.All, Data.Misc.EMB) == true) Init_EmbeddedFile_NEW(Data.Misc.EMB); else Init_EMB_file();
        }

        private async void Exec()
        {
            if (ORI_picker_status_file.Text != Data.Prop_Origin_File.picker_status && EMB_picker_status_file.Text != Data.Prop_Embedded_File.picker_status)
            {
                if (await PopupDialog.ShowConfirm(Detail.Embedded_File) == true) Process.Init(Process.GetData.SelectedTest);
            }
            else
            {
                await PopupDialog.Show(Status.Err, Detail.Embedded_File, Err.Input_isNull, Icon.Sad);
            }
        }
    }
}
