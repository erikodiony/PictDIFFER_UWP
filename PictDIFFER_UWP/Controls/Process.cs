﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

using static PictDIFFER.Controls.Data.Prop_Popup;
using static PictDIFFER.Controls.Data.Prop_Popup.Title;

using AForge.Imaging;
using System.Drawing;
using PictDIFFER.Controls;

namespace PictDIFFER
{
    class Process
    {
        #region Trigger Execute
        public static async void Init(string selected)
        {
            if (selected == Data.Misc.Stego1)
            {
                await StegoImage.Init(selected);
            }
            else if (selected == Data.Misc.Stego2)
            {
                await StegoImage.Init(selected);
            }
            else if (selected == Data.Misc.Stego3)
            {
                await StegoImage.Init(selected);
            }
            else if (selected == Data.Misc.Embedded1)
            {
                await EmbeddedFile.Init(selected, Data.Misc.MD5);                
            }
            else if (selected == Data.Misc.Embedded2)
            {
                await EmbeddedFile.Init(selected, Data.Misc.SHA1);
            }
        }
        #endregion
        #region Process Theme
        public class Theme
        {
            #region GetTheme from Storage
            public static bool GetTheme(string getTheme)
            {
                bool value = (getTheme == "Light") ? true : false;
                return value;
            }
            #endregion
            #region SetTheme to Storage
            public static void SetTheme(string value)
            {
                ApplicationData.Current.LocalSettings.Values["BG_set"] = value;
            }
            #endregion
        }
        #endregion
        #region Process Transition
        public class Transition
        {
            #region GetTransition from Storage
            public static TransitionCollection GetTransition(string getTransition)
            {
                NavigationThemeTransition theme = new NavigationThemeTransition();
                TransitionCollection collector = new TransitionCollection();

                if (getTransition == "Continuum")
                {
                    theme.DefaultNavigationTransitionInfo = new ContinuumNavigationTransitionInfo();
                }
                else if (getTransition == "Common")
                {
                    theme.DefaultNavigationTransitionInfo = new CommonNavigationTransitionInfo();
                }
                else if (getTransition == "Slide")
                {
                    theme.DefaultNavigationTransitionInfo = new SlideNavigationTransitionInfo();
                }
                else
                {
                    theme.DefaultNavigationTransitionInfo = new SuppressNavigationTransitionInfo();
                }
                collector.Add(theme);
                return collector;
            }
            #endregion

            #region SetTransition Status
            public static string SetTransitionStatus(string getTransition)
            {
                string result = String.Empty;
                if (getTransition == "Continuum")
                {
                    result = "Effect 1";
                }
                else if (getTransition == "Common")
                {
                    result = "Effect 2";
                }
                else if (getTransition == "Slide")
                {
                    result = "Effect 3";
                }
                else
                {
                    result = "None";
                }
                return result;
            }
            #endregion

            #region SetTransition to Storage
            public static void SetTransition(string value)
            {
                ApplicationData.Current.LocalSettings.Values["Effect_set"] = value;
            }
            #endregion
        }
        #endregion
        #region Process ShowTips
        public class Tips
        {
            #region GetTheme from Storage
            public static bool GetTips(string getTips)
            {
                bool value = (getTips == "False") ? false : true;
                return value;
            }
            #endregion
            #region SetTheme to Storage
            public static void SetTips(string value)
            {
                ApplicationData.Current.LocalSettings.Values["Tips_set"] = value;
            }
            #endregion
        }
        #endregion
        #region Process Picker
        public class Picker
        {
            public static async Task<bool> Execute(string[] extension, string type)
            {
                FileOpenPicker picker = new FileOpenPicker();
                foreach (string ext in extension)
                {
                    picker.FileTypeFilter.Add(ext);
                }

                StorageFile file = await picker.PickSingleFileAsync();
                if (file != null)
                {
                    if (await GetProperty(file, type) == true) return true; else return false;
                }
                else
                {
                    return false;
                }
            }

            public static async Task<bool> GetProperty(StorageFile file, string type)
            {
                IDictionary<string, object> prop = await file.Properties.RetrievePropertiesAsync(Data.Prop_File_Picker.All);
                StorageItemThumbnail thumbnail = await file.GetThumbnailAsync(ThumbnailMode.PicturesView);
                BitmapImage bitmap = new BitmapImage();

                if (type == Data.Misc.CVR)
                {
                    if (prop[Data.Prop_File_Picker.BitDepth].ToString() == "32")
                    {
                        bitmap.SetSource(thumbnail);

                        GetData.Picker.Clear();

                        GetData.Picker.Add(Data.Misc.Icon, bitmap);
                        GetData.Picker.Add(Data.Misc.Name, file.Name);
                        GetData.Picker.Add(Data.Misc.Path, file.Path.Replace("\\" + file.Name, String.Empty));
                        GetData.Picker.Add(Data.Misc.Size, prop[Data.Prop_File_Picker.Size]);
                        GetData.Picker.Add(Data.Misc.Dimensions, prop[Data.Prop_File_Picker.Dimensions]);
                        GetData.Picker.Add(Data.Misc.DateCreated, file.DateCreated);

                        GetData.Storage.Remove(Data.Misc.CVR);
                        GetData.Storage.Add(Data.Misc.CVR, file);

                        return true;
                    }
                    else
                    {
                        await PopupDialog.Show(Status.Err, Detail.CVR, Err.Invalid_32bitDepth, Icon.Sad);
                        return false;
                    }
                }
                else if(type == Data.Misc.STG)
                {
                    if (prop[Data.Prop_File_Picker.BitDepth].ToString() == "32")
                    {
                        bitmap.SetSource(thumbnail);

                        GetData.Picker.Clear();

                        GetData.Picker.Add(Data.Misc.Icon, bitmap);
                        GetData.Picker.Add(Data.Misc.Name, file.Name);
                        GetData.Picker.Add(Data.Misc.Path, file.Path.Replace("\\" + file.Name, String.Empty));
                        GetData.Picker.Add(Data.Misc.Size, prop[Data.Prop_File_Picker.Size]);
                        GetData.Picker.Add(Data.Misc.Dimensions, prop[Data.Prop_File_Picker.Dimensions]);
                        GetData.Picker.Add(Data.Misc.DateCreated, file.DateCreated);

                        GetData.Storage.Remove(Data.Misc.STG);
                        GetData.Storage.Add(Data.Misc.STG, file);

                        return true;
                    }
                    else
                    {
                        await PopupDialog.Show(Status.Err, Detail.STG, Err.Invalid_32bitDepth, Icon.Sad);
                        return false;
                    }
                }
                else if (type == Data.Misc.ORI)
                {
                    bitmap.SetSource(thumbnail);

                    GetData.Picker.Clear();

                    GetData.Picker.Add(Data.Misc.Icon, bitmap);
                    GetData.Picker.Add(Data.Misc.Name, file.Name);
                    GetData.Picker.Add(Data.Misc.Path, file.Path.Replace("\\" + file.Name, String.Empty));
                    GetData.Picker.Add(Data.Misc.Size, prop[Data.Prop_File_Picker.Size]);
                    GetData.Picker.Add(Data.Misc.Type, file.DisplayType);
                    GetData.Picker.Add(Data.Misc.DateCreated, file.DateCreated);

                    GetData.Storage.Remove(Data.Misc.ORI);
                    GetData.Storage.Add(Data.Misc.ORI, file);

                    return true;
                }
                else if(type == Data.Misc.EMB)
                {
                    bitmap.SetSource(thumbnail);

                    GetData.Picker.Clear();

                    GetData.Picker.Add(Data.Misc.Icon, bitmap);
                    GetData.Picker.Add(Data.Misc.Name, file.Name);
                    GetData.Picker.Add(Data.Misc.Path, file.Path.Replace("\\" + file.Name, String.Empty));
                    GetData.Picker.Add(Data.Misc.Size, prop[Data.Prop_File_Picker.Size]);
                    GetData.Picker.Add(Data.Misc.Type, file.DisplayType);
                    GetData.Picker.Add(Data.Misc.DateCreated, file.DateCreated);

                    GetData.Storage.Remove(Data.Misc.EMB);
                    GetData.Storage.Add(Data.Misc.EMB, file);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
        #region Data Storage
        public class GetData
        {
            public static Dictionary<string, object> Picker = new Dictionary<string, object>();
            public static Dictionary<string, object> Storage = new Dictionary<string, object>();
            public static Dictionary<string, object> DataResult = new Dictionary<string, object>();
            public static string SelectedTest;
            public static void Reset_Data()
            {
                Picker.Clear();
                Storage.Clear();
            }
        }
        #endregion
        #region Process EmbeddedFile
        public class EmbeddedFile
        {
            public static async Task Init(string nameTest, string typeAlgorithm)
            {
                PopupDialog.Loading pl = new PopupDialog.Loading();
                pl.Show(true, Data.Misc.WorkingOnIt, String.Empty);
                var x = Task.Run(() => Run(typeAlgorithm));
                await x;
                if (x.IsCompleted == true)
                {
                    pl.Show(false, String.Empty, String.Empty);
                    await PopupDialog.EmbeddedFile.Show(nameTest);
                }
            }
            public static async Task Run(string typeAlgorithm)
            {
                var origin = (StorageFile)GetData.Storage[Data.Misc.ORI];
                var embedded = (StorageFile)GetData.Storage[Data.Misc.EMB];

                HashAlgorithmProvider compute = HashAlgorithmProvider.OpenAlgorithm(typeAlgorithm);

                IBuffer hash_origin = compute.HashData(await FileIO.ReadBufferAsync(origin));
                IBuffer hash_embedded = compute.HashData(await FileIO.ReadBufferAsync(embedded));

                GetData.DataResult.Add(Data.Misc.ORI, CryptographicBuffer.EncodeToHexString(hash_origin));
                GetData.DataResult.Add(Data.Misc.EMB, CryptographicBuffer.EncodeToHexString(hash_embedded));

                await Task.Delay(6000);
            }
        }
        #endregion
        #region Process StegoImage
        public class StegoImage
        {
            public static async Task Init(string nameTest)
            {
                Task x;
                PopupDialog.Loading pl = new PopupDialog.Loading();
                pl.Show(true, Data.Misc.WorkingOnIt, String.Empty);
                if (nameTest == Data.Misc.Stego1)
                {
                    x = HistogramData.Run();
                    await x;
                }
                else if (nameTest == Data.Misc.Stego2)
                {
                    x = Task.Run(() => PixelIdentify.Run());
                    await x;
                }
                else
                {
                    x = Task.Run(() => MSEandPSNR.Run());
                    await x;
                }

                switch(x.IsCompleted)
                {
                    case true:
                        pl.Show(false, String.Empty, String.Empty);

                        if (nameTest == Data.Misc.Stego1)
                        {
                            await PopupDialog.StegoImage.Histogram_Show(nameTest);
                        }
                        else if (nameTest == Data.Misc.Stego2)
                        {
                            await PopupDialog.StegoImage.Pixel_Show(nameTest);
                        }
                        else
                        {
                            await PopupDialog.StegoImage.MSEandPSNR_Show(nameTest);
                        }
                        break;
                    case false:
                        break;
                }
            }
            #region HistogramData
            public class HistogramData
            {
                public static async Task Run()
                {
                    var cover = (StorageFile)GetData.Storage[Data.Misc.CVR];
                    var stego = (StorageFile)GetData.Storage[Data.Misc.STG];
                    var bmp_cvr = await CreateBitmap(cover);
                    var bmp_stg = await CreateBitmap(stego);
                    Calculate(bmp_cvr, Data.Misc.CVR);
                    Calculate(bmp_stg, Data.Misc.STG);
                    await Task.Delay(6000);
                }
                public static async Task<Bitmap> CreateBitmap(StorageFile img)
                {
                    ImageProperties prop = await img.Properties.GetImagePropertiesAsync();

                    WriteableBitmap wrt = new WriteableBitmap((int)prop.Width, (int)prop.Height);
                    using (var stream = await img.OpenAsync(FileAccessMode.Read))
                    {
                        wrt.SetSource(stream);
                    }
                    return (Bitmap)wrt;
                }
                public static PointCollection CreatePoint(int[] point)
                {
                    var values = SmoothHistogram(point);
                    //var values = point;
                    int max = values.Max();
                    PointCollection dots = new PointCollection();
                    dots.Add(new Windows.Foundation.Point(0, max));
                    for (int i = 0; i < values.Length; i++)
                    {
                        dots.Add(new Windows.Foundation.Point(i, max - values[i]));
                    }
                    dots.Add(new Windows.Foundation.Point(values.Length - 1, max));
                    return dots;
                }
                public static int[] SmoothHistogram(int[] value)
                {
                    int[] smoothedValues = new int[value.Length];

                    double[] mask = new double[] { 0.25, 0.5, 0.25 };

                    for (int bin = 1; bin < value.Length - 1; bin++)
                    {
                        double smoothedValue = 0;
                        for (int i = 0; i < mask.Length; i++)
                        {
                            smoothedValue += value[bin - 1 + i] * mask[i];
                        }
                        smoothedValues[bin] = (int)smoothedValue;
                    }
                    return smoothedValues;
                }
                public static void Calculate(Bitmap img, string type)
                {
                    using (img)
                    {
                        ImageStatistics rgb_Statistics_Cover = new ImageStatistics(img);
                        var Blue = CreatePoint(rgb_Statistics_Cover.Blue.Values);
                        var Green = CreatePoint(rgb_Statistics_Cover.Green.Values);
                        var Red = CreatePoint(rgb_Statistics_Cover.Red.Values);

                        switch (type)
                        {
                            case "CVR":
                                GetData.DataResult.Add(Data.Misc.CVR_B, Blue);
                                GetData.DataResult.Add(Data.Misc.CVR_G, Green);
                                GetData.DataResult.Add(Data.Misc.CVR_R, Red);
                                break;
                            case "STG":
                                GetData.DataResult.Add(Data.Misc.STG_B, Blue);
                                GetData.DataResult.Add(Data.Misc.STG_G, Green);
                                GetData.DataResult.Add(Data.Misc.STG_R, Red);
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
            #endregion
            #region PixelIdentify
            public class PixelIdentify
            {
                public static async Task Run()
                {
                    await GetPixel((StorageFile)GetData.Storage[Data.Misc.CVR], "CVR");
                    await GetPixel((StorageFile)GetData.Storage[Data.Misc.STG], "STG");
                    await Task.Delay(6000);
                }
                public static async Task GetPixel(StorageFile file, string type)
                {
                    IRandomAccessStream ram;
                    byte[] pixel;

                    List<byte> B = new List<byte>();
                    List<byte> G = new List<byte>();
                    List<byte> R = new List<byte>();
                    List<byte> A = new List<byte>();
                    List<string> XY = new List<string>();

                    int point;
                    using (ram = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        var dec = await BitmapDecoder.CreateAsync(ram);
                        pixel = (await dec.GetPixelDataAsync()).DetachPixelData();

                        int index = 0;
                        for (int y = 0; y <dec.PixelHeight; y++)
                        {
                            for (int x = 0; x < dec.PixelWidth; x++)
                            {
                                point = ((y * (int)dec.PixelWidth + x) * 4);
                                B.Add(pixel[point + 0]);
                                G.Add(pixel[point + 1]);
                                R.Add(pixel[point + 2]);
                                A.Add(pixel[point + 3]);
                                XY.Add(String.Format("{0},{1}", x+1, y+1));
                                index++;
                            }
                        }                       
                    }

                    switch(type)
                    {
                        case "CVR":
                            GetData.DataResult.Add(Data.Misc.CVR_B, B.ToArray());
                            GetData.DataResult.Add(Data.Misc.CVR_G, G.ToArray());
                            GetData.DataResult.Add(Data.Misc.CVR_R, R.ToArray());
                            GetData.DataResult.Add(Data.Misc.CVR_A, A.ToArray());
                            GetData.DataResult.Add(Data.Misc.CVR_XY, XY.ToArray());
                            break;
                        case "STG":
                            GetData.DataResult.Add(Data.Misc.STG_B, B.ToArray());
                            GetData.DataResult.Add(Data.Misc.STG_G, G.ToArray());
                            GetData.DataResult.Add(Data.Misc.STG_R, R.ToArray());
                            GetData.DataResult.Add(Data.Misc.STG_A, A.ToArray());
                            GetData.DataResult.Add(Data.Misc.STG_XY, XY.ToArray());
                            break;
                        default:
                            break;
                    }

                }

            }
            #endregion
            #region MSEandPSNR
            public class MSEandPSNR
            {
                public static async Task Run()
                {
                    var cover = (StorageFile)GetData.Storage[Data.Misc.CVR];
                    var stego = (StorageFile)GetData.Storage[Data.Misc.STG];

                    var cover_dict = await GetPixel(cover);
                    var stego_dict = await GetPixel(stego);

                    var cover_argb = (byte[])cover_dict["Data1"];
                    var cover_height = (int)cover_dict["Data2"];
                    var cover_width = (int)cover_dict["Data3"];

                    var stego_argb = (byte[])stego_dict["Data1"];
                    var stego_height = (int)stego_dict["Data2"];
                    var stego_width = (int)stego_dict["Data3"];

                    Calculate(cover_argb, stego_argb, cover_height, cover_width);

                    await Task.Delay(6000);
                }
                public static async Task<Dictionary<string, object>> GetPixel(StorageFile file)
                {
                    IRandomAccessStream ram;
                    byte[] pixel;
                    int height;
                    int width;
                    Dictionary<string, object> result = new Dictionary<string, object>();

                    using (ram = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        BitmapDecoder Decoder = await BitmapDecoder.CreateAsync(ram);
                        height = (int)Decoder.PixelHeight;
                        width = (int)Decoder.PixelWidth;
                        pixel = (await Decoder.GetPixelDataAsync()).DetachPixelData();
                    }

                    result.Add("Data1", pixel);
                    result.Add("Data2", height);
                    result.Add("Data3", width);
                    return result;
                }
                public static void Calculate(byte[] cvr, byte[] stg, int h_cvr, int w_cvr)
                {
                    var cvr_b = new List<byte>();
                    var cvr_g = new List<byte>();
                    var cvr_r = new List<byte>();
                    var cvr_a = new List<byte>();

                    var stg_b = new List<byte>();
                    var stg_g = new List<byte>();
                    var stg_r = new List<byte>();
                    var stg_a = new List<byte>();

                    #region get ARGB Value
                    for (int i = 0; i < cvr.Length / 4; i++)
                    {
                        cvr_b.Add(cvr[((i * 3) + i) + 0]);
                        cvr_g.Add(cvr[((i * 3) + i) + 1]);
                        cvr_r.Add(cvr[((i * 3) + i) + 2]);
                        cvr_a.Add(cvr[((i * 3) + i) + 3]);
                    }

                    for (int i = 0; i < stg.Length / 4; i++)
                    {
                        stg_b.Add(stg[((i * 3) + i) + 0]);
                        stg_g.Add(stg[((i * 3) + i) + 1]);
                        stg_r.Add(stg[((i * 3) + i) + 2]);
                        stg_a.Add(stg[((i * 3) + i) + 3]);
                    }
                    #endregion
                    #region get MSE&PSNR Value
                    var MSE_B = CountMSE(cvr_b.ToArray(), stg_b.ToArray(), h_cvr, w_cvr);
                    var MSE_G = CountMSE(cvr_g.ToArray(), stg_g.ToArray(), h_cvr, w_cvr);
                    var MSE_R = CountMSE(cvr_r.ToArray(), stg_r.ToArray(), h_cvr, w_cvr);
                    var MSE_A = CountMSE(cvr_a.ToArray(), stg_a.ToArray(), h_cvr, w_cvr);

                    var PSNR_B = CountPSNR(MSE_B, cvr_b.Max(), stg_b.Max());
                    var PSNR_G = CountPSNR(MSE_G, cvr_g.Max(), stg_g.Max());
                    var PSNR_R = CountPSNR(MSE_R, cvr_r.Max(), stg_r.Max());
                    var PSNR_A = CountPSNR(MSE_A, cvr_a.Max(), stg_a.Max());
                    #endregion

                    GetData.DataResult.Add(Data.Misc.MSE_B, MSE_B);
                    GetData.DataResult.Add(Data.Misc.MSE_G, MSE_G);
                    GetData.DataResult.Add(Data.Misc.MSE_R, MSE_R);
                    GetData.DataResult.Add(Data.Misc.MSE_A, MSE_A);
                    GetData.DataResult.Add(Data.Misc.MSE_ALL, (MSE_B + MSE_G + MSE_R + MSE_A) / 4);

                    GetData.DataResult.Add(Data.Misc.PSNR_B, PSNR_B);
                    GetData.DataResult.Add(Data.Misc.PSNR_G, PSNR_G);
                    GetData.DataResult.Add(Data.Misc.PSNR_R, PSNR_R);
                    GetData.DataResult.Add(Data.Misc.PSNR_A, PSNR_A);
                    GetData.DataResult.Add(Data.Misc.PSNR_ALL, (PSNR_B + PSNR_G + PSNR_R + PSNR_A) / 4);
                }
                public static double CountMSE(byte[] cvr_x, byte[] stg_x, int h, int w)
                {
                    var mse_result = new List<double>(); 
                    for (int i = 0; i < cvr_x.Length; i++)
                    {
                        mse_result.Add(Math.Pow(cvr_x[i] - stg_x[i], 2));
                    }
                    return mse_result.Sum() / (h * w);
                }
                public static double CountPSNR(double MSE, int cvr_max, int stg_max)
                {
                    double max = Math.Max(cvr_max, stg_max);
                    double sqrt = Math.Sqrt(MSE);
                    return (20 * Math.Log10(max / sqrt));
                }
            }
            #endregion
        }
        #endregion
    }
}