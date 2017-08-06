using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictDIFFER
{
    class Data
    {
        #region FileExtensions
        public static class File_Extensions
        {
            public static readonly string[] Png = new string[] { ".png" };
            public static readonly string[] All = new string[] { ".txt", ".doc", ".xls", ".ppt", ".docx", ".xlsx", ".pptx", ".pdf", ".jpg", ".gif", ".png", ".mp3", ".mp4", ".zip", ".rar" };
        }
        #endregion

        #region Property Page
        public static class Prop_Page
        {
            public static readonly string StegoPage = "Menu yang berfungsi untuk menguji hasil keluaran dari proses Embedding Steganography (Stego Image), Jenis uji yang digunakan yakni Histogram, Pixel Identify dan MSE & PSNR";
            public static readonly string EmbeddedPage = "Menu yang berfungsi untuk menguji hasil keluaran dari proses Extracting Steganography (Embedded File), Jenis uji yang digunakan yakni MD5 Checksum";
            public static readonly string SettingsPage = "Menu yang berfungsi untuk mengganti Warna Latar Belakang (Change Background) beserta mengganti Efek Transisi Halaman (Change Transition Effect)";
            public static readonly string AboutPage = "Menu yang berisi tentang Detail Aplikasi (App Detail) beserta Info tentang Creator (About Me)";
        }
        #endregion

        #region Property FilePicker
        public static class Prop_File_Picker
        {
            public static readonly string Size = "System.Size";
            public static readonly string Dimensions = "System.Image.Dimensions";
            public static readonly string BitDepth = "System.Image.BitDepth";
            public static readonly List<string> All = new List<string>() { Size, Dimensions, BitDepth };
        }
        #endregion

        #region Property Popup
        public static class Prop_Popup
        {
            #region Popup Title
            public static class Title
            {
                public static class Status
                {
                    public static readonly string Success = "SUCCESS";
                    public static readonly string Err = "ERROR";
                    public static readonly string Confirm = "CONFIRMATION";
                    public static readonly string Result = "RESULT";
                }
                public static class Detail
                {
                    public static readonly string Stego_Image = "Stego Image Test";
                    public static readonly string Embedded_File = "Embedded File Test";
                    public static readonly string CVR = "Choose Cover Image";
                    public static readonly string STG = "Choose Stego Image";
                    public static readonly string ORI = "Choose Origin File";
                    public static readonly string EMB = "Choose Embedded File";
                }
                public static class Icon
                {
                    public static readonly string Smile = "J";
                    public static readonly string Sad = "L";
                    public static readonly string Flat = "K";
                }
            }
            #endregion
            #region Popup Complete
            public static class Complete
            {
                public static readonly string Clear_All = "All field was Cleared !\nProcess Successfully...";
                public static readonly string Clear_Input_Passwd = "Field ''Input Password'' was Cleared !\nProcess Successfully...";
                public static readonly string Clear_Input_Message = "Field ''Input Text/Message'' was Cleared !\nProcess Successfully...";
                public static readonly string Saved_StegoImage = "Stego Image was Saved !\nProcess Successfully...";
                public static readonly string Saved_SecretFile = "Secret File was Saved !\nProcess Successfully...";
            }
            #endregion
            #region Popup Error
            public static class Err
            {
                public static readonly string Input_isNull = "Some field is empty !\nPlease check again...";
                public static readonly string Invalid_Stego = "Invalid Image Stego !\nCan't Extract File / Message...";
                public static readonly string Invalid_Passwd = "Password Incorrect !\nCan't Extract File / Message...";
                public static readonly string Invalid_32bitDepth = "Only Image Cover 32BitDepth was supported !\nPlease check again...";
                public static readonly string Overload_Size = "Overload size quota of File !\nPlease check again...";
                public static readonly string Null_Size = "Field ''Choose Image Cover'' must be filled !\nPlease check again...";
                public static readonly string Replace_Message = "Field ''Input Text/Message'' is Saved !\nClick 'Clear' to Replace with new Text/Message...";
                public static readonly string NotSaved_StegoImage = "Stego Image not saved !\nProcess cancelling...";
                public static readonly string NotSaved_SecretFile = "Secret File not saved !\nProcess cancelling...";
                public static readonly string More150Kb = "Size more than 150Kb !\nCan't Saving File...";
            }
            #endregion
            #region Popup Confirm
            public static class Confirm
            {
                public static readonly string isExecute = "Confirm to Execute ?\nClick 'OK' to continue...";
                public static readonly string isLargeFile = "Large size will take a several minute !\nClick 'OK' to continue...";
            }
            #endregion
        }
        #endregion

        #region Property Button
        public static class Prop_Button
        {
            public static readonly string OK = "OK";
            public static readonly string Cancel = "Cancel";
            public static readonly string Close = "Close";
            public static readonly string Save = "Save";
            public static readonly string Clear = "Clear";
            public static readonly string ClearAll = "Clear All";
            public static readonly string Execute = "Execute";
        }
        #endregion

        #region Property Stego Image Test
        public static class Prop_Image_Stego
        {
            public static readonly string title = "Choose Stego Image";
            public static readonly string subtitle = "(Pilih Stego Image yang telah ter-Embed didalamnya)";
            public static readonly string button = "Choose Image";
            public static readonly string picker_status = "No Image";
            public static readonly string picker_path = "Path : ";
            public static readonly string picker_size = "Size : ";
            public static readonly string picker_dimension = "Dimension : ";
            public static readonly string picker_datecreated = "Date created : ";
        }
        public static class Prop_Image_Cover
        {
            public static readonly string title = "Choose Cover Image";
            public static readonly string subtitle = "(Pilih Cover Image yang telah ter-Embed didalamnya)";
            public static readonly string button = "Choose Image";
            public static readonly string picker_status = "No Image";
            public static readonly string picker_path = "Path : ";
            public static readonly string picker_size = "Size : ";
            public static readonly string picker_dimension = "Dimension : ";
            public static readonly string picker_datecreated = "Date created : ";
        }
        #endregion

        #region Property Embedded File Test
        public static class Prop_Origin_File
        {
            public static readonly string title = "Choose Origin File";
            public static readonly string subtitle = "(Mendukung format File Dokumen, Gambar, dll)";
            public static readonly string picker_status = "No File";
            public static readonly string picker_path = "Path : ";
            public static readonly string picker_size = "Size : ";
            public static readonly string picker_type = "Type : ";
            public static readonly string picker_datecreated = "Date created : ";
            public static readonly string button = "Choose File";
        }
        public static class Prop_Embedded_File
        {
            public static readonly string title = "Choose Embedded File";
            public static readonly string subtitle = "(Mendukung format File Dokumen, Gambar, dll)";
            public static readonly string picker_status = "No File";
            public static readonly string picker_path = "Path : ";
            public static readonly string picker_size = "Size : ";
            public static readonly string picker_type = "Type : ";
            public static readonly string picker_datecreated = "Date created : ";
            public static readonly string button = "Choose File";
        }
        #endregion

        #region Property About
        public static class Prop_AppDetail
        {
            public static readonly string title = "PictDIFFER";
            public static readonly string version = "Version 1.0 (Build 201707)";
            public static readonly string source_code = "Source Code (Github)";
            public static readonly string source_code_link = "http://github.com/Erikodiony/PictDIFFER";
            public static readonly string bug_support = "Bug / Support (Facebook)";
            public static readonly string bug_support_link = "http://facebook.com/erikodiony";
        }
        public static class Prop_AboutMe
        {
            public static readonly string title = "''Make your dreams come true with working hardly and tawakkal''";
            public static readonly string head1 = "Biodata";
            public static readonly string name = "Erikodiony Ariessa Wahyudi";
            public static readonly string birth = "Balikpapan, 24 September 1994";
            public static readonly string domicile = "Kertosono, Nganjuk";
            public static readonly string head2 = "Riwayat Pendidikan";
            public static readonly string school_tk = "TK Pertiwi Kudu";
            public static readonly string school_sd = "SD Negeri 1 Kudu";
            public static readonly string school_smp = "SMP Negeri 1 Kertosono";
            public static readonly string school_smk = "SMK Negeri 1 Kertosono (Teknik Otomasi Industri)";
            public static readonly string university = "Universitas Nusantara PGRI Kediri (Teknik Informatika)";
        }
        #endregion

        #region Property Misc
        public static class Misc
        {
            public static readonly string Name = "Name";
            public static readonly string Path = "Path";
            public static readonly string Size = "Size";
            public static readonly string Dimensions = "Dimensions";
            public static readonly string Type = "Type";
            public static readonly string Icon = "Icon";
            public static readonly string DateCreated = "DateCreated";

            public static readonly string CVR = "CVR";
            public static readonly string STG = "STG";
            public static readonly string ORI = "ORI";
            public static readonly string EMB = "EMB";

            public static readonly string Stego1 = "Histogram Data";
            public static readonly string Stego2 = "Pixel Identify";
            public static readonly string Stego3 = "Count MSE & PSNR";
            public static readonly string Embedded1 = "MD5 Hash Identify";
            public static readonly string Embedded2 = "SHA1 Hash Identify";

            public static readonly string MD5 = "MD5";
            public static readonly string SHA1 = "SHA1";

            public static readonly string WorkingOnIt = "Working on it...";

            public static readonly string OriginFile = "Origin File";
            public static readonly string EmbeddedFile = "Embedded File";
            public static readonly string CoverFile = "Cover Image";
            public static readonly string StegoFile = "Stego Image";

            public static readonly string MSE_B = "MSE_B";
            public static readonly string MSE_G = "MSE_G";
            public static readonly string MSE_R = "MSE_R";
            public static readonly string MSE_A = "MSE_A";
            public static readonly string MSE_ALL = "MSE_ALL";
            public static readonly string PSNR_B = "PSNR_B";
            public static readonly string PSNR_G = "PSNR_G";
            public static readonly string PSNR_R = "PSNR_R";
            public static readonly string PSNR_A = "PSNR_A";
            public static readonly string PSNR_ALL = "PSNR_ALL";

            public static readonly string CVR_B = "CVR_B";
            public static readonly string CVR_G = "CVR_G";
            public static readonly string CVR_R = "CVR_R";
            public static readonly string CVR_A = "CVR_A";
            public static readonly string CVR_XY = "CVR_XY";

            public static readonly string STG_B = "STG_B";
            public static readonly string STG_G = "STG_G";
            public static readonly string STG_R = "STG_R";
            public static readonly string STG_A = "STG_A";
            public static readonly string STG_XY = "STG_XY";

            public static readonly string CORD_X = "CORD_X";
            public static readonly string CORD_Y = "CORD_Y";
        }
        #endregion
    }
}
