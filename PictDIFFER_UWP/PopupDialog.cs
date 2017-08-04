using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

using PictDIFFER.Views.Popup;
using static PictDIFFER.Data;

namespace PictDIFFER
{
    class PopupDialog
    {
        public static async Task Show(string status, string title, string msg, string ico)
        {
            Notification cbox = new Notification()
            {
                Title = String.Format("{0} | {1}", status, title),
                PrimaryButtonText = Prop_Button.OK,
                Detail = msg,
                Icon = ico
            };
            await cbox.ShowAsync();
        }
        public static async Task<bool> ShowConfirm(string type)
        {
            Confirmation cf = new Confirmation()
            {
                Title = String.Format("{0} | {1}", Prop_Popup.Title.Status.Confirm, type),
                PopupType = type,
                PrimaryButtonText = Prop_Button.OK,
                SecondaryButtonText = Prop_Button.Cancel,                
            };
            bool value = (await cf.ShowAsync() == ContentDialogResult.Primary) ? true : false;
            return value;
        }
        public class Loading
        {
            Progress pg = new Progress();
            public async void Show(bool type, string msg, string detail)
            {
                pg.Message = msg;
                pg.Detail = detail;
                if (type == true) await pg.ShowAsync(); else pg.Hide();
            }
        }
        public class EmbeddedFile
        {
            public static async Task Show(string type)
            {
                Result_EmbeddedFile re = new Result_EmbeddedFile()
                {
                    Title = String.Format("{0} | {1}", Prop_Popup.Title.Status.Result, type),
                    PrimaryButtonText = Prop_Button.Close,
                };
                await re.ShowAsync();               
            }
        }
        public class StegoImage
        {
            public static async Task MSEandPSNR_Show(string type)
            {
                Result_MSEandPSNR rm = new Result_MSEandPSNR()
                {
                    Title = String.Format("{0} | {1}", Prop_Popup.Title.Status.Result, type),
                    PrimaryButtonText = Prop_Button.Close,
                };
                await rm.ShowAsync();
            }
            public static async Task Histogram_Show(string type)
            {
                Result_Histogram rh = new Result_Histogram()
                {
                    Title = String.Format("{0} | {1}", Prop_Popup.Title.Status.Result, type),
                    PrimaryButtonText = Prop_Button.Close,
                };
                await rh.ShowAsync();
            }
            public static async Task Pixel_Show(string type)
            {
                Result_Pixel rh = new Result_Pixel()
                {
                    Title = String.Format("{0} | {1}", Prop_Popup.Title.Status.Result, type),
                    PrimaryButtonText = Prop_Button.Close,
                };
                await rh.ShowAsync();
            }
        }
    }
}
