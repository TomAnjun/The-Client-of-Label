using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using CCWin.SkinControl;
using ShengXinSolution.Client.LablePrintSystemV2.Models;

namespace ShengXinSolution.Client.LablePrintSystemV2.Utils
{
    class PrintLabel
    {
        #region 打印机环境初始化
        const uint IMAGE_BITMAP = 0;
        const uint LR_LOADFROMFILE = 16;
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType,
           int cxDesired, int cyDesired, uint fuLoad);
        [DllImport("Gdi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int DeleteObject(IntPtr ho);
        const string szSavePath = "C:\\Argox";
        const string szSaveFile = "C:\\Argox\\PPLB_Example.Prn";
        const string sznop1 = "nop_front\r\n";
        const string sznop2 = "nop_middle\r\n";
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Bar2d_Maxi(int x, int y, int cl, int cc, int pc, string data);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Bar2d_PDF417(int x, int y, int w, int v, int s, int c, int px,
            int py, int r, int l, int t, int o, string data);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Bar2d_PDF417_N(int x, int y, int w, int h, string pParameter, string data);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Bar2d_DataMatrix(int x, int y, int r, int l, int h, int v, string data);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern void B_ClosePrn();
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_CreatePrn(int selection, string filename);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Del_Form(string formname);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Del_Pcx(string pcxname);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Draw_Box(int x, int y, int thickness, int hor_dots,
            int ver_dots);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Draw_Line(char mode, int x, int y, int hor_dots, int ver_dots);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Error_Reporting(char option);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern IntPtr B_Get_DLL_Version(int nShowMessage);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Get_DLL_VersionA(int nShowMessage);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Get_Graphic_ColorBMP(int x, int y, string filename);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Get_Graphic_ColorBMPEx(int x, int y, int nWidth, int nHeight,
            int rotate, string id_name, string filename);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Get_Graphic_ColorBMP_HBitmap(int x, int y, int nWidth, int nHeight,
           int rotate, string id_name, IntPtr hbm);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Get_Pcx(int x, int y, string filename);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Initial_Setting(int Type, string Source);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_WriteData(int IsImmediate, byte[] pbuf, int length);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_ReadData(byte[] pbuf, int length, int dwTimeoutms);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Load_Pcx(int x, int y, string pcxname);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Open_ChineseFont(string path);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Print_Form(int labset, int copies, string form_out, string var);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Print_MCopy(int labset, int copies);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Print_Out(int labset);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Prn_Barcode(int x, int y, int ori, string type, int narrow,
            int width, int height, char human, string data);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern void B_Prn_Configuration();
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Prn_Text(int x, int y, int ori, int font, int hor_factor,
            int ver_factor, char mode, string data);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Prn_Text_Chinese(int x, int y, int fonttype, string id_name,
            string data);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Prn_Text_TrueType(int x, int y, int FSize, string FType,
            int Fspin, int FWeight, int FItalic, int FUnline, int FStrikeOut, string id_name,
            string data);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Prn_Text_TrueType_W(int x, int y, int FHeight, int FWidth,
            string FType, int Fspin, int FWeight, int FItalic, int FUnline, int FStrikeOut,
            string id_name, string data);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Select_Option(int option);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Select_Option2(int option, int p);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Select_Symbol(int num_bit, int symbol, int country);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Select_Symbol2(int num_bit, string csymbol, int country);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_Backfeed(char option);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_Backfeed_Offset(int offset);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_CutPeel_Offset(int offset);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_BMPSave(int nSave, string strBMPFName);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_Darkness(int darkness);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_DebugDialog(int nEnable);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_Direction(char direction);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_Form(string formfile);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_Labgap(int lablength, int gaplength);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_Labwidth(int labwidth);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_Originpoint(int hor, int ver);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_Prncomport(int baud, char parity, int data, int stop);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_Prncomport_PC(int nBaudRate, int nByteSize, int nParity,
            int nStopBits, int nDsr, int nCts, int nXonXoff);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_Speed(int speed);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_ProcessDlg(int nShow);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_ErrorDlg(int nShow);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_GetUSBBufferLen();
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_EnumUSB(byte[] buf);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_CreateUSBPort(int nPort);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_ResetPrinter();
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_GetPrinterResponse(byte[] buf, int nMax);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_TFeedMode(int nMode);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_TFeedTest();
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_CreatePort(int nPortType, int nPort, string filename);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Execute_Form(string form_out, string var);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Bar2d_QR(int x, int y, int model, int scl, char error,
            char dinput, int c, int d, int p, string data);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_GetNetPrinterBufferLen();
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_EnumNetPrinter(byte[] buf);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_CreateNetPort(int nPort);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Prn_Text_TrueType_Uni(int x, int y, int FSize, string FType,
            int Fspin, int FWeight, int FItalic, int FUnline, int FStrikeOut, string id_name,
            byte[] data, int format);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Prn_Text_TrueType_UniB(int x, int y, int FSize, string FType,
            int Fspin, int FWeight, int FItalic, int FUnline, int FStrikeOut, string id_name,
            byte[] data, int format);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_GetUSBDeviceInfo(int nPort, byte[] pDeviceName,
            out int pDeviceNameLen, byte[] pDevicePath, out int pDevicePathLen);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Set_EncryptionKey(string encryptionKey);
        [DllImport(@"Libs\\Argox\\Winpplb.dll")]
        private static extern int B_Check_EncryptionKey(string decodeKey, string encryptionKey,
            int dwTimeoutms);
        #endregion

        #region 打印机设置初始化
        private static void PrinterInitialize()
        {
            //Test code start
            // open port.
            int nLen, ret, sw;
            byte[] pbuf = new byte[128];
            var encAscII = Encoding.ASCII;
            // search port.
            nLen = B_GetUSBBufferLen() + 1;
            if (nLen > 1)
            {
                int len1 = 128, len2 = 128;
                var buf1 = new byte[len1];
                var buf2 = new byte[len2];
                B_EnumUSB(pbuf);
                B_GetUSBDeviceInfo(1, buf1, out len1, buf2, out len2);
                sw = 1;
                if (1 == sw)
                {
                    ret = B_CreatePrn(12, encAscII.GetString(buf2, 0, len2));// open usb.
                }
                else
                {
                    ret = B_CreateUSBPort(1);// must call B_GetUSBBufferLen() function fisrt.
                }
                if (0 != ret)
                {
                }
                else
                {
                    //sw = 2;
                    if (2 == sw)
                    {
                        //Immediate Error Report.
                        B_WriteData(1, encAscII.GetBytes("^ee\r\n"), 5);//^ee
                        ret = B_ReadData(pbuf, 4, 1000);
                    }
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(szSavePath);
                ret = B_CreatePrn(0, szSaveFile);// open file.
            }

            if (0 != ret)
                return;

            // printer setting.
            B_Set_Direction('B');
            B_Set_DebugDialog(1);//设定除错环境
            B_Set_Originpoint(0, 0);//设定开始列印点
            B_Select_Option(2);//設定轉印模式、啟動 Cutter 或 Peel
            B_Set_Darkness(8);
            B_Del_Pcx("*");// delete all picture.
            B_WriteData(0, encAscII.GetBytes(sznop2), sznop2.Length);
            B_WriteData(1, encAscII.GetBytes(sznop1), sznop1.Length);
        }
        #endregion

        #region 海关标签
        public static void CustomLabelPrint(WaybillInfo waybillInfo, int packIndex)
        {
            PrinterInitialize();

            //横竖线
            B_Draw_Box(20, 20, 10, 840, 1040);
            B_Draw_Line('O', 28, 416, 796, 2);//一横
            B_Draw_Line('O', 520, 512, 304, 2);//二横
            B_Draw_Line('O', 28, 576, 796, 2);//三横
            B_Draw_Line('O', 28, 824, 796, 2);//四横
            B_Draw_Line('O', 312, 936, 512, 2);//五横
            B_Draw_Line('O', 520, 416, 2, 160);//一竖
            B_Draw_Line('O', 312, 824, 2, 208);//二竖

            IntPtr himage = LoadImage(IntPtr.Zero, @"Resources\customs.bmp", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
            B_Get_Graphic_ColorBMP_HBitmap(56, 48, 152, 56, 0, "BN", himage);
            if (IntPtr.Zero != himage)
                DeleteObject(himage);
            //第一部分
            B_Prn_Text_TrueType(328, 68, 35, "Arial", 1, 400, 0, 0, 0, "TA", "SINOHF   AWB   :   " + waybillInfo.packages[packIndex].awb_no);
            //第二部分
            B_Prn_Text_TrueType(56, 160, 35, "Arial", 1, 400, 0, 0, 0, "TC", "DELIVER TO");
            B_Prn_Barcode(504, 128, 0, "1", 3, 6, 72, 'N', waybillInfo.Destination);
            B_Prn_Text_TrueType(504, 208, 95, "Arial", 1, 400, 0, 0, 0, "TD", waybillInfo.Destination.Substring(0, 1) + " " + waybillInfo.Destination.Substring(1, 1) + " " + waybillInfo.Destination.Substring(2, 1));
            B_Prn_Text_TrueType(56, 200, 30, "Arial", 1, 400, 0, 0, 0, "TE", waybillInfo.receiver_nm_en);
            if (waybillInfo.receiver_addr_en.Length > 51)
            {
                B_Prn_Text_TrueType(56, 232, 30, "Arial", 1, 400, 0, 0, 0, "TF", waybillInfo.receiver_addr_en.Substring(0, 17));
                B_Prn_Text_TrueType(56, 264, 30, "Arial", 1, 400, 0, 0, 0, "TG", waybillInfo.receiver_addr_en.Substring(17, 17));
                B_Prn_Text_TrueType(56, 296, 30, "Arial", 1, 400, 0, 0, 0, "TH", waybillInfo.receiver_addr_en.Substring(34, 17));
                if (waybillInfo.receiver_addr_en.Length > 68)
                    B_Prn_Text_TrueType(56, 328, 30, "Arial", 1, 400, 0, 0, 0, "TI", waybillInfo.receiver_addr_en.Substring(51, 17));
                else
                    B_Prn_Text_TrueType(56, 328, 30, "Arial", 1, 400, 0, 0, 0, "TI", waybillInfo.receiver_addr_en.Substring(51, waybillInfo.receiver_addr_en.Length - 51));
                B_Prn_Text_TrueType(56, 360, 30, "Arial", 1, 400, 0, 0, 0, "TJ", "Tel : " + waybillInfo.receiver_tel);
                B_Prn_Text_TrueType(56, 392, 30, "Arial", 1, 400, 0, 0, 0, "TK", "PostCode : " + waybillInfo.receiver_zip_cd);
            }
            else if (waybillInfo.receiver_addr_en.Length > 34)
            {
                B_Prn_Text_TrueType(56, 232, 30, "Arial", 1, 400, 0, 0, 0, "TF", waybillInfo.receiver_addr_en.Substring(0, 17));
                B_Prn_Text_TrueType(56, 264, 30, "Arial", 1, 400, 0, 0, 0, "TG", waybillInfo.receiver_addr_en.Substring(17, 17));
                B_Prn_Text_TrueType(56, 296, 30, "Arial", 1, 400, 0, 0, 0, "TH", waybillInfo.receiver_addr_en.Substring(34, waybillInfo.receiver_addr_en.Length - 34));
                B_Prn_Text_TrueType(56, 328, 30, "Arial", 1, 400, 0, 0, 0, "TJ", "Tel : " + waybillInfo.receiver_tel);
                B_Prn_Text_TrueType(56, 360, 30, "Arial", 1, 400, 0, 0, 0, "TK", "PostCode : " + waybillInfo.receiver_zip_cd);
            }
            else if (waybillInfo.receiver_addr_en.Length > 17)
            {
                B_Prn_Text_TrueType(56, 232, 30, "Arial", 1, 400, 0, 0, 0, "TF", waybillInfo.receiver_addr_en.Substring(0, 17));
                B_Prn_Text_TrueType(56, 264, 30, "Arial", 1, 400, 0, 0, 0, "TG", waybillInfo.receiver_addr_en.Substring(17, waybillInfo.receiver_addr_en.Length - 17));
                B_Prn_Text_TrueType(56, 296, 30, "Arial", 1, 400, 0, 0, 0, "TJ", "Tel : " + waybillInfo.receiver_tel);
                B_Prn_Text_TrueType(56, 328, 30, "Arial", 1, 400, 0, 0, 0, "TK", "PostCode : " + waybillInfo.receiver_zip_cd);
            }
            else
            {
                B_Prn_Text_TrueType(56, 232, 30, "Arial", 1, 400, 0, 0, 0, "TG", waybillInfo.receiver_addr_en);
                B_Prn_Text_TrueType(56, 264, 30, "Arial", 1, 400, 0, 0, 0, "TJ", "Tel : " + waybillInfo.receiver_tel);
                B_Prn_Text_TrueType(56, 296, 30, "Arial", 1, 400, 0, 0, 0, "TK", "PostCode : " + waybillInfo.receiver_zip_cd);
            }
            //E-Commerce
            if (waybillInfo.ECommerce)
                B_Prn_Text_TrueType(504, 344, 40, "Arial", 1, 400, 0, 0, 0, "TL", "E-Commerce");
            //第三部分
            //货物详情
            B_Prn_Text_TrueType(56, 440, 30, "Arial", 1, 400, 0, 0, 0, "TM", "DESCRIPTION  OF  CONTENTS :");
            if (!waybillInfo.items[0].item_nm_en.IsNullOrEmpty())
            {
                if (waybillInfo.items[0].item_nm_en.Length > 30)
                    B_Prn_Text_TrueType(56, 472, 30, "Arial", 1, 400, 0, 0, 0, "TN", waybillInfo.items[0].item_nm_en.Substring(0, 30));
                else
                    B_Prn_Text_TrueType(56, 472, 30, "Arial", 1, 400, 0, 0, 0, "TN", waybillInfo.items[0].item_nm_en);
            }
            B_Prn_Text_TrueType(56, 504, 30, "Arial", 1, 400, 0, 0, 0, "TO", "QUANTITY :      " + waybillInfo.total_package_cnt + "  PCS");
            double jpValues = Convert.ToDouble(waybillInfo.total_price);
            double usValues = jpValues * 0.00415;
            B_Prn_Text_TrueType(56, 536, 30, "Arial", 1, 400, 0, 0, 0, "TP", "VALUE :    " + "  USD  " + usValues.ToString("f1"));
            B_Prn_Text_TrueType(616, 472, 30, "Arial", 1, 400, 0, 0, 0, "TQ", waybillInfo.packages[packIndex].package_weight);
            B_Prn_Text_TrueType(616, 536, 30, "Arial", 1, 400, 0, 0, 0, "TR", waybillInfo.FlightDate);
            //第四部分
            B_Prn_Barcode(88, 592, 0, "1", 6, 16, 152, 'N', waybillInfo.packages[packIndex].awb_no);
            //B_Prn_Barcode(88, 592, 0, "1", 6, 10, 152, 'N', p.customsNo);
            B_Prn_Text_TrueType(104, 768, 35, "Arial", 1, 400, 0, 0, 0, "TS", "SINOHF   AWB   :   " + waybillInfo.packages[packIndex].awb_no);
            //第五部分
            B_Prn_Text_TrueType(56, 832, 30, "Arial", 1, 400, 0, 0, 0, "TT", "SENDER");
            B_Prn_Text_TrueType(56, 864, 20, "Arial", 1, 400, 0, 0, 0, "TU", waybillInfo.sender_nm_en + " 店铺");
            if (waybillInfo.sender_addr_en.Length > 75)
            {
                B_Prn_Text_TrueType(56, 880, 20, "Arial", 1, 400, 0, 0, 0, "TV", waybillInfo.sender_addr_en.Substring(0, 25));
                B_Prn_Text_TrueType(56, 896, 20, "Arial", 1, 400, 0, 0, 0, "TW", waybillInfo.sender_addr_en.Substring(25, 25));
                B_Prn_Text_TrueType(56, 912, 20, "Arial", 1, 400, 0, 0, 0, "TX", waybillInfo.sender_addr_en.Substring(50, 25));
                if (waybillInfo.sender_addr_en.Length > 100)
                    B_Prn_Text_TrueType(56, 926, 20, "Arial", 1, 400, 0, 0, 0, "TY", waybillInfo.sender_addr_en.Substring(75, 25));
                else
                    B_Prn_Text_TrueType(56, 926, 20, "Arial", 1, 400, 0, 0, 0, "TY", waybillInfo.sender_addr_en.Substring(75, waybillInfo.sender_addr_en.Length - 75));
                B_Prn_Text_TrueType(56, 944, 20, "Arial", 1, 400, 0, 0, 0, "TZ", "Tel  " + waybillInfo.sender_tel);
            }
            else if (waybillInfo.sender_addr_en.Length > 50)
            {
                B_Prn_Text_TrueType(56, 880, 20, "Arial", 1, 400, 0, 0, 0, "TV", waybillInfo.sender_addr_en.Substring(0, 25));
                B_Prn_Text_TrueType(56, 896, 20, "Arial", 1, 400, 0, 0, 0, "TW", waybillInfo.sender_addr_en.Substring(25, 25));
                B_Prn_Text_TrueType(56, 912, 20, "Arial", 1, 400, 0, 0, 0, "TX", waybillInfo.sender_addr_en.Substring(50, waybillInfo.sender_addr_en.Length - 50));
                B_Prn_Text_TrueType(56, 926, 20, "Arial", 1, 400, 0, 0, 0, "TY", "Tel  " + waybillInfo.sender_tel);
            }
            else if (waybillInfo.sender_addr_en.Length > 25)
            {
                B_Prn_Text_TrueType(56, 880, 20, "Arial", 1, 400, 0, 0, 0, "TV", waybillInfo.sender_addr_en.Substring(0, 25));
                B_Prn_Text_TrueType(56, 896, 20, "Arial", 1, 400, 0, 0, 0, "TW", waybillInfo.sender_addr_en.Substring(25, waybillInfo.sender_addr_en.Length - 25));
                B_Prn_Text_TrueType(56, 912, 20, "Arial", 1, 400, 0, 0, 0, "TX", "Tel  " + waybillInfo.sender_tel);
            }
            else
            {
                B_Prn_Text_TrueType(56, 880, 20, "Arial", 1, 400, 0, 0, 0, "TV", waybillInfo.sender_addr_en);
                B_Prn_Text_TrueType(56, 896, 20, "Arial", 1, 400, 0, 0, 0, "TW", "Tel  " + waybillInfo.sender_tel);
            }
            B_Prn_Text_TrueType(80, 972, 40, "Arial", 1, 400, 0, 0, 0, "TZ0", "CN");
            //安全声明
            B_Prn_Text_TrueType(320, 832, 20, "Arial", 1, 400, 0, 0, 0, "TZ1", "Avlation Security and Dangerous Goods Declaration");
            B_Prn_Text_TrueType(320, 848, 20, "Arial", 1, 400, 0, 0, 0, "TZ2", "The sender acknowledges that this article may be carried by air");
            B_Prn_Text_TrueType(320, 864, 20, "Arial", 1, 400, 0, 0, 0, "TZ3", "And wil be subject to avlation security and clearing procedures");
            B_Prn_Text_TrueType(320, 880, 20, "Arial", 1, 400, 0, 0, 0, "TZ4", "And the sender declares that the article does not contain any");
            B_Prn_Text_TrueType(320, 896, 20, "Arial", 1, 400, 0, 0, 0, "TZ5", "dangerous or prohibited goods,exploslive or incendlary devices,A");
            B_Prn_Text_TrueType(320, 912, 20, "Arial", 1, 400, 0, 0, 0, "TZ6", "talse declaration is a criminal offence.");

            B_Print_Out(1);//参数是打印份数
            B_ClosePrn();
            System.Threading.Thread.Sleep(500);
        }
        #endregion

        #region 佐川急便
        public static void SagawaLablePrint(WaybillInfo waybillInfo, int packIndex)
        {
            PrinterInitialize();

            B_Draw_Box(20, 20, 10, 840, 1040);//横线
            B_Draw_Line('E', 576, 66, 248, 4); //第一条横线 D
            B_Draw_Line('E', 576, 122, 248, 4); //第二条横线 D
            B_Draw_Line('E', 28, 186, 796, 4); //第三条横线 D
            B_Draw_Line('E', 576, 226, 248, 4); //第四条横线 D
            B_Draw_Line('E', 576, 372, 248, 4); //第五条横线 D
            B_Draw_Line('E', 28, 418, 798, 4); //第六条横线 D
            B_Draw_Line('E', 28, 466, 420, 4); //第七条横线 D
            B_Draw_Line('E', 28, 576, 798, 4); //第八条横线 D
            B_Draw_Line('E', 28, 696, 798, 4); //第九条横线 D
            B_Draw_Line('E', 28, 815, 798, 4); //第十条横线 D
            B_Draw_Line('E', 28, 872, 420, 4); //第十一条横线 D
            B_Draw_Line('E', 28, 976, 798, 4); //第十二条横线 D

            //draw ver line
            B_Draw_Line('O', 50, 186, 4, 232); //1A 竖线
            B_Draw_Line('O', 50, 576, 4, 240); //1B 竖线
            B_Draw_Line('O', 443, 418, 4, 160); //2A 竖线
            B_Draw_Line('O', 443, 815, 4, 164); //2B 竖线
            B_Draw_Line('O', 467, 418, 4, 160); //3A 竖线
            B_Draw_Line('O', 467, 815, 4, 164); //3B 竖线
            B_Draw_Line('O', 576, 20, 4, 356); //4 竖线

            //判断大数字是否超过3个，如果超过三个缩小字体，位置前移
            if (waybillInfo.fandi_no_big.Length > 3)
            {
                B_Prn_Text_TrueType(40, 30, 170, "Arial", 1, 400, 0, 0, 0, "BA", waybillInfo.fandi_no_big);//大数字
                B_Prn_Text_TrueType(400, 96, 90, "Arial", 1, 400, 0, 0, 0, "BB", waybillInfo.fandi_no_small);//小数字
            }
            else
            {
                //如果没有超过3个还是按照之前的样式打印
                B_Prn_Text_TrueType(60, 30, 170, "Arial", 1, 400, 0, 0, 0, "BA", waybillInfo.fandi_no_big);//大数字
                B_Prn_Text_TrueType(400, 96, 90, "Arial", 1, 400, 0, 0, 0, "BB", waybillInfo.fandi_no_small);//小数字
            }

            string dateStr = waybillInfo.print_date;
            dateStr = DateTime.ParseExact(dateStr, "yyyyMMdd", null).ToString("yy年MM月dd日");

            B_Prn_Text_TrueType(610, 37, 22, "Arial", 1, 400, 0, 0, 0, "BG", "発送日:" + dateStr);//发送日期
            B_Prn_Text_TrueType(650, 80, 45, "Arial", 1, 400, 0, 0, 0, "BH", "個   数");//save in printer.
            B_Prn_Text_TrueType(670, 137, 45, "Arial", 1, 400, 0, 0, 0, "BI1", waybillInfo.packages[packIndex].package_id);//当前包裹号
            B_Prn_Text_TrueType(705, 140, 45, "Arial", 1, 400, 0, 0, 0, "BI2", "/");//
            B_Prn_Text_TrueType(725, 143, 45, "Arial", 1, 400, 0, 0, 0, "BI3", waybillInfo.total_package_cnt);//总包裹数
            B_Prn_Text_TrueType(630, 200, 20, "Arial", 1, 400, 0, 0, 0, "BJ", "着営業所バーコード");
            //お届け先
            B_Prn_Text_TrueType(32, 265, 20, "Arial", 1, 400, 0, 0, 0, "BK", "お");
            B_Prn_Text_TrueType(32, 285, 20, "Arial", 1, 400, 0, 0, 0, "BK1", "届");
            B_Prn_Text_TrueType(32, 305, 20, "Arial", 1, 400, 0, 0, 0, "BK2", "け");
            B_Prn_Text_TrueType(32, 325, 20, "Arial", 1, 400, 0, 0, 0, "BK3", "先");
            //輸出者
            B_Prn_Text_TrueType(32, 615, 20, "Arial", 1, 400, 0, 0, 0, "BK4", "輸");
            B_Prn_Text_TrueType(32, 635, 20, "Arial", 1, 400, 0, 0, 0, "BK5", "出");
            B_Prn_Text_TrueType(32, 655, 20, "Arial", 1, 400, 0, 0, 0, "BK6", "者");
            //ご依頼主
            B_Prn_Text_TrueType(32, 720, 20, "Arial", 1, 400, 0, 0, 0, "BK7", "ご");
            B_Prn_Text_TrueType(32, 740, 20, "Arial", 1, 400, 0, 0, 0, "BK8", "依");
            B_Prn_Text_TrueType(32, 760, 20, "Arial", 1, 400, 0, 0, 0, "BK9", "頼");
            B_Prn_Text_TrueType(32, 780, 20, "Arial", 1, 400, 0, 0, 0, "BK10", "主");
            //間合番号
            B_Prn_Text_TrueType(448, 465, 20, "Arial", 1, 400, 0, 0, 0, "BK11", "間");
            B_Prn_Text_TrueType(448, 485, 20, "Arial", 1, 400, 0, 0, 0, "BK12", "合");
            B_Prn_Text_TrueType(448, 505, 20, "Arial", 1, 400, 0, 0, 0, "BK13", "番");
            B_Prn_Text_TrueType(448, 525, 20, "Arial", 1, 400, 0, 0, 0, "BK14", "号");
            //品名荷姿
            B_Prn_Text_TrueType(448, 865, 20, "Arial", 1, 400, 0, 0, 0, "BK15", "品");
            B_Prn_Text_TrueType(448, 885, 20, "Arial", 1, 400, 0, 0, 0, "BK16", "名");
            B_Prn_Text_TrueType(448, 905, 20, "Arial", 1, 400, 0, 0, 0, "BK17", "荷");
            B_Prn_Text_TrueType(448, 925, 20, "Arial", 1, 400, 0, 0, 0, "BK18", "姿");

            if (waybillInfo.StoreHouseShort.Equals("成田店"))
                B_Prn_Text_TrueType(140, 425, 45, "Arial", 1, 400, 0, 0, 0, "BL", waybillInfo.StoreHouseShort);//集货店名称
            else
                B_Prn_Text_TrueType(60, 423, 45, "Arial", 1, 400, 0, 0, 0, "BL", waybillInfo.StoreHouseShort);//集货店名称
            B_Prn_Text_TrueType(80, 480, 30, "Arial", 1, 400, 0, 0, 0, "BM1", "お問合せTEL:" + waybillInfo.StoreHouseTel);//集货店电话
            B_Prn_Text_TrueType(80, 510, 30, "Arial", 1, 400, 0, 0, 0, "BM2", "お問合せFAX:" + waybillInfo.StoreHouseFax);//集货店传真
            B_Prn_Text_TrueType(80, 540, 30, "Arial", 1, 400, 0, 0, 0, "BM3", "出荷場コード:" + waybillInfo.StoreHouseCd);//出荷场
            B_Prn_Text_TrueType(75, 823, 25, "Arial", 1, 400, 0, 0, 0, "BS4", "佐川急便(株)の損害賠償限度額は");
            B_Prn_Text_TrueType(75, 847, 25, "Arial", 1, 400, 0, 0, 0, "BS5", "荷物１個につき３０万円です");

            //打印需要输出文字
            B_Prn_Text_TrueType(95, 200, 30, "Arial", 1, 400, 0, 0, 0, "BN1", "〒 " + waybillInfo.receiver_zip_cd);//日本邮编
            //日本收货地址一行不够 需要换行
            if (waybillInfo.receiver_addr_cn.Length > 36)
            {
                B_Prn_Text_TrueType(95, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN121", waybillInfo.receiver_addr_cn.Substring(0, 18));
                B_Prn_Text_TrueType(95, 264, 30, "Arial", 1, 400, 0, 0, 0, "BN122", waybillInfo.receiver_addr_cn.Substring(18, 18));
                B_Prn_Text_TrueType(95, 296, 30, "Arial", 1, 400, 0, 0, 0, "BN131", waybillInfo.receiver_addr_cn.Substring(36, waybillInfo.receiver_addr_cn.Length - 36));
            }
            else if (waybillInfo.receiver_addr_cn.Length > 18)
            {
                B_Prn_Text_TrueType(95, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN12", waybillInfo.receiver_addr_cn.Substring(0, 18));
                B_Prn_Text_TrueType(95, 264, 30, "Arial", 1, 400, 0, 0, 0, "BN13", waybillInfo.receiver_addr_cn.Substring(18, waybillInfo.receiver_addr_cn.Length - 18));
            }
            else
            {
                B_Prn_Text_TrueType(95, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN12", waybillInfo.receiver_addr_cn);
            }
            //收件公司一行也可能不够
            if (waybillInfo.receiver_nm_cn.Length > 18)
            {
                B_Prn_Text_TrueType(95, 328, 30, "Arial", 1, 400, 0, 0, 0, "BN141", waybillInfo.receiver_nm_cn.Substring(0, 18));//收件公司
                B_Prn_Text_TrueType(95, 360, 30, "Arial", 1, 400, 0, 0, 0, "BN142", waybillInfo.receiver_nm_cn.Substring(18, waybillInfo.receiver_nm_cn.Length - 18) + "   " + waybillInfo.receiver_contact_nm_cn);//收件公司+收件人
            }
            else
            {
                B_Prn_Text_TrueType(95, 328, 30, "Arial", 1, 400, 0, 0, 0, "BN14", waybillInfo.receiver_nm_cn);//收件公司
                B_Prn_Text_TrueType(95, 360, 30, "Arial", 1, 400, 0, 0, 0, "BN15", waybillInfo.receiver_contact_nm_cn);//收件人
            }
            B_Prn_Text_TrueType(95, 392, 30, "Arial", 1, 400, 0, 0, 0, "BN16", "TEL:" + waybillInfo.receiver_tel);//收件人电话


            //输出者
            B_Prn_Text_TrueType(95, 595, 35, "Arial", 1, 400, 0, 0, 0, "BN2", waybillInfo.sender_nm_en);//代理发件公司：agentSendCompany
            //下面的地址字符串长度会超过打印标签的宽度，所以需要进行判断，如果字符串长度超过标签纸宽度，打印在标签上的文字要进行换行.
            if (waybillInfo.sender_addr_en.Length > 45)
            {
                B_Prn_Text_TrueType(95, 638, 30, "Arial", 1, 400, 0, 0, 0, "BN211", waybillInfo.sender_addr_en.Substring(0, 45));//代理发件公司地址：agentSendCompanyAddress
                B_Prn_Text_TrueType(95, 663, 30, "Arial", 1, 400, 0, 0, 0, "BN212", waybillInfo.sender_addr_en.Substring(45, waybillInfo.sender_addr_en.Length - 45));//代理发件公司地址：agentSendCompanyAddress
            }
            else
            {
                B_Prn_Text_TrueType(95, 638, 30, "Arial", 1, 400, 0, 0, 0, "BN21", waybillInfo.sender_addr_en);//代理发件公司地址：agentSendCompanyAddress
            }

            //运送会社
            B_Prn_Text_TrueType(95, 740, 30, "Arial", 1, 400, 0, 0, 0, "BS1", waybillInfo.StoreHouseLong);//代理运输公司和营业所
            B_Prn_Text_TrueType(95, 775, 30, "Arial", 1, 400, 0, 0, 0, "BS2", "TEL:" + waybillInfo.StoreCompanyTel + "       " + "FAX:" + waybillInfo.StoreCompanyFax);//营业所电话和传真

            if (!waybillInfo.items[0].item_nm_en.IsNullOrEmpty())
            {
                if (waybillInfo.items[0].item_nm_en.Length > 75)
                {
                    B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", waybillInfo.items[0].item_nm_en.Substring(0, 25));//货物名称
                    B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", waybillInfo.items[0].item_nm_en.Substring(25, 25));//货物名称
                    B_Prn_Text_TrueType(495, 862, 24, "Arial", 1, 400, 0, 0, 0, "BN33", waybillInfo.items[0].item_nm_en.Substring(50, 25));//货物名称
                    B_Prn_Text_TrueType(495, 882, 24, "Arial", 1, 400, 0, 0, 0, "BN34", waybillInfo.items[0].item_nm_en.Substring(75, waybillInfo.items[0].item_nm_en.Length - 75));//货物名称
                }
                else
                {
                    if (waybillInfo.items[0].item_nm_en.Length > 50)//长度大于60分三行
                    {
                        B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", waybillInfo.items[0].item_nm_en.Substring(0, 25));//货物名称
                        B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", waybillInfo.items[0].item_nm_en.Substring(25, 25));//货物名称
                        B_Prn_Text_TrueType(495, 862, 24, "Arial", 1, 400, 0, 0, 0, "BN33", waybillInfo.items[0].item_nm_en.Substring(50, waybillInfo.items[0].item_nm_en.Length - 50));//货物名称
                    }
                    else
                    {
                        if (waybillInfo.items[0].item_nm_en.Length > 25)//长度大于30小于60分两行
                        {
                            B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", waybillInfo.items[0].item_nm_en.Substring(0, 25));//货物名称
                            B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", waybillInfo.items[0].item_nm_en.Substring(25, waybillInfo.items[0].item_nm_en.Length - 25));//货物名称
                        }
                        else
                        { //长度小于18一行显示
                            B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN3", waybillInfo.items[0].item_nm_en);//货物名称
                        }
                    }
                }
            }
            B_Prn_Text_TrueType(495, 904, 20, "Arial", 1, 400, 0, 0, 0, "BN4", waybillInfo.packages[packIndex].package_weight);//货物重量
            B_Prn_Text_TrueType(495, 924, 20, "Arial", 1, 400, 0, 0, 0, "BN5", waybillInfo.packages[packIndex].package_volume_weight + "サイズ ");//货物体积
            B_Prn_Text_TrueType(495, 947, 30, "Arial", 1, 400, 0, 0, 0, "BN6", waybillInfo.sx_no + "");//中国运单号
            B_Prn_Text_TrueType(80, 990, 36, "Arial", 1, 400, 0, 0, 0, "BN7", "SDM");
            B_Prn_Text_TrueType(170, 995, 30, "Arial", 1, 400, 0, 0, 0, "BN8", "SHANDONG SHINESEN INT'L TRANSPORT CO.,LTD");

            //print barcode
            //codabar（nw-7）次打印机的接收参数必须是ABCD....ABCD格式的，也就是说开头和结尾必须是大写的
            //参数必须改成2：4 不然扫码枪扫不出内容
            B_Prn_Barcode(610, 250, 0, "K", 2, 4, 100, 'N', waybillInfo.ArrivalShopNo);//从上倒下第一个条形码
            //if(waybillInfo.total_package_cnt.Equals("1"))
            if (waybillInfo.StoreHouseShort.Equals("成田店"))
            {
                if (packIndex == 0)
                {
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "A" + waybillInfo.jp_express_no + "A"); //第二个条形码
                    B_Prn_Barcode(76, 890, 0, "K", 2, 4, 50, 'B', "A" + waybillInfo.jp_express_no + "A"); //第三个条形码
                }
                else
                {
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "D" + waybillInfo.jp_express_no + "D"); //第二个条形码
                    B_Prn_Barcode(76, 890, 0, "K", 2, 4, 50, 'B', "D" + waybillInfo.jp_express_no + "D");//第三个条形码
                }
            }
            else
            {
                if(waybillInfo.total_package_cnt.Equals("1"))
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "A" + waybillInfo.jp_express_no + "A"); //第二个条形码
                else
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "D" + waybillInfo.jp_express_no + "D"); //第二个条形码
                B_Prn_Text_TrueType(95, 710, 25, "Arial", 1, 400, 0, 0, 0, "BS0", "〒5490021　大阪府泉南市泉州空港南１第二国際貨物代理店ビル");
                B_Prn_Text_TrueType(40, 895, 25, "Arial", 1, 400, 0, 0, 0, "BS6", "□飛脚宅配便　□飛脚ラージサイズ宅配便");
                B_Prn_Text_TrueType(40, 930, 25, "Arial", 1, 400, 0, 0, 0, "BS7", "□飛脚航空便　□飛脚ラージサイズ航空便");
            }
            // output.
            B_Print_Out(1);//参数是打印份数
            // close port.
            B_ClosePrn();
            System.Threading.Thread.Sleep(500);
        }
        #endregion

        #region 日本邮政大贴标
        public static void JapanEmsPrint(WaybillInfo waybillInfo, int packIndex)
        {
            // sample setting.

            //print text, true type text.
            //B_Prn_Text(30, 40, 0, 2, 1, 1, 'N', "PPLB Lib Example");
            //B_Prn_Text_TrueType(30, 100, 30, "Arial", 1, 400, 0, 0, 0, "AA", "TrueType Font");//save in printer.
            //B_Prn_Text_TrueType_W(30, 160, 20, 20, "Times New Roman", 1, 400, 0, 0, 0, "AB", "TT_W: 多字元測試");
            //B_Prn_Text_TrueType_Uni(30, 220, 30, "Times New Roman", 1, 400, 0, 0, 0, "AC", Encoding.Unicode.GetBytes("TT_Uni: 多字元測試"), 1);//UTF-16

            PrinterInitialize();
            //draw box.
            B_Draw_Box(20, 120, 4, 844, 1020);
            //draw hor line
            B_Draw_Line('E', 20, 256, 810, 4);//第一条横线
            B_Draw_Line('E', 20, 392, 810, 4);//第一条横线
            B_Draw_Line('E', 20, 528, 810, 4);//第一条横线
            B_Draw_Line('E', 20, 664, 810, 4);//第一条横线
            B_Draw_Line('E', 20, 800, 810, 4);//第一条横线
            B_Draw_Line('E', 20, 940, 810, 4);//第一条横线

            B_Draw_Line('E', 700, 304, 130, 4);//第一条横线 A
            B_Draw_Line('E', 20, 488, 810, 4);//第一条横线 C
            B_Draw_Line('E', 700, 440, 130, 4);//第一条横线 D

            //draw ver line
            B_Draw_Line('O', 64, 120, 4, 272);//1 竖线
            B_Draw_Line('O', 700, 256, 4, 232);//2 竖线
            B_Draw_Line('O', 64, 664, 4, 276);//3 竖线
            B_Draw_Line('O', 120, 392, 4, 96);//4 竖线
            B_Draw_Line('O', 240, 488, 4, 40);//5 竖线
            B_Draw_Line('O', 120, 940, 4, 80);//5 竖线


            //draw text
            //固定名词
            B_Prn_Text_TrueType(30, 123, 30, "Arial", 1, 400, 0, 0, 0, "ZA", "お");//竖着的第一个
            B_Prn_Text_TrueType(30, 156, 30, "Arial", 1, 400, 0, 0, 0, "ZB", "届");//
            B_Prn_Text_TrueType(30, 189, 30, "Arial", 1, 400, 0, 0, 0, "ZC", "け");//
            B_Prn_Text_TrueType(30, 222, 30, "Arial", 1, 400, 0, 0, 0, "ZD", "先");//

            B_Prn_Text_TrueType(30, 123 + 136, 30, "Arial", 1, 400, 0, 0, 0, "ZE", "ご");//竖着的第二个
            B_Prn_Text_TrueType(30, 156 + 136, 30, "Arial", 1, 400, 0, 0, 0, "ZF", "依");//
            B_Prn_Text_TrueType(30, 189 + 136, 30, "Arial", 1, 400, 0, 0, 0, "ZG", "頼");//
            B_Prn_Text_TrueType(30, 222 + 136, 30, "Arial", 1, 400, 0, 0, 0, "ZH", "主");//

            B_Prn_Text_TrueType(730, 265, 30, "Arial", 1, 400, 0, 0, 0, "ZJ", "受領印");//
            B_Prn_Text_TrueType(730, 400, 30, "Arial", 1, 400, 0, 0, 0, "ZK", "サイズ");//

            B_Prn_Text_TrueType(45, 410, 30, "Arial", 1, 400, 0, 0, 0, "ZL", "品名");//
            B_Prn_Text_TrueType(45, 450, 30, "Arial", 1, 400, 0, 0, 0, "ZM", "記事");//

            B_Prn_Text_TrueType(25, 492, 30, "Arial", 1, 400, 0, 0, 0, "ZN", "お問い合わせ番号");//

            B_Prn_Text_TrueType(30, 670, 25, "Arial", 1, 400, 0, 0, 0, "ZAA", "お");//竖着的第三个
            B_Prn_Text_TrueType(30, 703, 25, "Arial", 1, 400, 0, 0, 0, "ZBB", "届");//
            B_Prn_Text_TrueType(30, 736, 25, "Arial", 1, 400, 0, 0, 0, "ZCC", "け");//
            B_Prn_Text_TrueType(30, 769, 25, "Arial", 1, 400, 0, 0, 0, "ZDD", "先");//

            B_Prn_Text_TrueType(30, 670 + 136, 25, "Arial", 1, 400, 0, 0, 0, "ZAAA", "ご");//竖着的第四个
            B_Prn_Text_TrueType(30, 703 + 136, 25, "Arial", 1, 400, 0, 0, 0, "ZBBB", "依");//
            B_Prn_Text_TrueType(30, 736 + 136, 25, "Arial", 1, 400, 0, 0, 0, "ZCCC", "頼");//
            B_Prn_Text_TrueType(30, 769 + 136, 25, "Arial", 1, 400, 0, 0, 0, "ZDDD", "主");//

            B_Prn_Text_TrueType(45, 963, 25, "Arial", 1, 400, 0, 0, 0, "ZLA", "品名");//品名
            B_Prn_Text_TrueType(45, 988, 25, "Arial", 1, 400, 0, 0, 0, "ZMB", "記事");//记事


            //B_Prn_Text_TrueType(20, 20, 30, "Arial", 1, 400, 0, 0, 0, "AA", "ゆうパック");//数字上面的日文
            B_Prn_Text_TrueType(20, 50, 70, "Arial", 1, 400, 0, 0, 0, "AB", waybillInfo.fandi_no_big + waybillInfo.fandi_no_small);//数字
            B_Prn_Text_TrueType(730, 20, 30, "Arial", 1, 400, 0, 0, 0, "AC", "配達証");//配连证

            B_Prn_Text_TrueType(75, 125, 30, "Arial", 1, 400, 0, 0, 0, "BA", "〒" + waybillInfo.receiver_zip_cd);
            B_Prn_Text_TrueType(250, 125, 30, "Arial", 1, 400, 0, 0, 0, "BB", "TEL：" + waybillInfo.receiver_tel);
            //B_Prn_Text_TrueType(75, 150, 30, "Arial", 1, 400, 0, 0, 0, "BC", p.JpAddress+p.JpNum);

            if (waybillInfo.receiver_addr_cn.Length < 28)
            {
                B_Prn_Text_TrueType(75, 150, 30, "Arial", 1, 400, 0, 0, 0, "BC", waybillInfo.receiver_addr_cn);
            }
            else
            {
                B_Prn_Text_TrueType(75, 150, 30, "Arial", 1, 400, 0, 0, 0, "BC", waybillInfo.receiver_addr_cn.Substring(0, 28));
                B_Prn_Text_TrueType(75, 175, 30, "Arial", 1, 400, 0, 0, 0, "BC1", waybillInfo.receiver_addr_cn.Substring(28, waybillInfo.receiver_addr_cn.Length - 28));
            }
            B_Prn_Text_TrueType(75, 200, 30, "Arial", 1, 400, 0, 0, 0, "BD", waybillInfo.receiver_nm_cn);
            B_Prn_Text_TrueType(75, 230, 25, "Arial", 1, 400, 0, 0, 0, "BF", "EX TRADE");

            B_Prn_Text_TrueType(75, 260, 27, "Arial", 1, 400, 0, 0, 0, "CA", "〒" + waybillInfo.sender_zip_cd);
            B_Prn_Text_TrueType(250, 260, 27, "Arial", 1, 400, 0, 0, 0, "CL", "TEL：" + waybillInfo.sender_tel);
            if (waybillInfo.sender_addr_en.Length > 50)
            {
                B_Prn_Text_TrueType(75, 285, 27, "Arial", 1, 400, 0, 0, 0, "CB", waybillInfo.sender_addr_en.Substring(0, 50));
            }
            else
                B_Prn_Text_TrueType(75, 285, 27, "Arial", 1, 400, 0, 0, 0, "CB", waybillInfo.sender_addr_en);
            B_Prn_Text_TrueType(75, 310, 27, "Arial", 1, 400, 0, 0, 0, "CC", waybillInfo.StoreHouseLong);
            B_Prn_Text_TrueType(75, 335, 27, "Arial", 1, 400, 0, 0, 0, "CD", waybillInfo.StoreHouseShort);
            B_Prn_Text_TrueType(75, 360, 27, "Arial", 1, 400, 0, 0, 0, "CE", "※返還は依頼主まで。返還前連絡は不要。");
            //B_Prn_Text_TrueType(650, 360, 25, "Arial", 1, 400, 0, 0, 0, "CF", "様");

            //B_Prn_Text_TrueType(130, 430, 30, "Arial", 1, 400, 0, 0, 0, "DA", p.PackName);
            if (!waybillInfo.items[0].item_nm_en.IsNullOrEmpty())
            {
                if (waybillInfo.items[0].item_nm_en.Length < 40)
                {
                    B_Prn_Text_TrueType(130, 430, 30, "Arial", 1, 400, 0, 0, 0, "DA", waybillInfo.items[0].item_nm_en);
                }
                else
                {
                    B_Prn_Text_TrueType(130, 417, 30, "Arial", 1, 400, 0, 0, 0, "DA", waybillInfo.items[0].item_nm_en.Substring(0, 40));
                    if (waybillInfo.items[0].item_nm_en.Length > 80)
                        B_Prn_Text_TrueType(130, 442, 30, "Arial", 1, 400, 0, 0, 0, "DA1", waybillInfo.items[0].item_nm_en.Substring(40, 40));
                    else
                        B_Prn_Text_TrueType(130, 442, 30, "Arial", 1, 400, 0, 0, 0, "DA1", waybillInfo.items[0].item_nm_en.Substring(40, waybillInfo.items[0].item_nm_en.Length - 40));
                }
            }
            B_Prn_Text_TrueType(320, 498, 30, "Arial", 1, 400, 0, 0, 0, "DC", waybillInfo.jp_express_no);
            B_Prn_Text_TrueType(22, 626, 30, "Arial", 1, 400, 0, 0, 0, "DD", "お問い合わせ番号：" + waybillInfo.jp_express_no);
            B_Prn_Text_TrueType(690, 626, 30, "Arial", 1, 400, 0, 0, 0, "DE", "ちょう付用");


            B_Prn_Text_TrueType(75, 670, 30, "Arial", 1, 400, 0, 0, 0, "EA", "〒" + waybillInfo.receiver_zip_cd);
            B_Prn_Text_TrueType(250, 670, 30, "Arial", 1, 400, 0, 0, 0, "EB", "TEL：" + waybillInfo.receiver_tel);
            //B_Prn_Text_TrueType(75, 695, 25, "Arial", 1, 400, 0, 0, 0, "EC", p.JpAddress + p.JpNum);
            if (waybillInfo.receiver_addr_cn.Length < 28)
            {
                B_Prn_Text_TrueType(75, 695, 30, "Arial", 1, 400, 0, 0, 0, "EC", waybillInfo.receiver_addr_cn);
            }
            else
            {
                B_Prn_Text_TrueType(75, 695, 30, "Arial", 1, 400, 0, 0, 0, "EC", waybillInfo.receiver_addr_cn.Substring(0, 28));
                B_Prn_Text_TrueType(75, 720, 30, "Arial", 1, 400, 0, 0, 0, "EC1", waybillInfo.receiver_addr_cn.Substring(28, waybillInfo.receiver_addr_cn.Length - 28));
            }
            B_Prn_Text_TrueType(75, 750, 30, "Arial", 1, 400, 0, 0, 0, "ED", waybillInfo.receiver_nm_cn);
            B_Prn_Text_TrueType(75, 775, 25, "Arial", 1, 400, 0, 0, 0, "EF", "EX TRADE");

            B_Prn_Text_TrueType(75, 805, 27, "Arial", 1, 400, 0, 0, 0, "CA", "〒" + waybillInfo.sender_zip_cd);
            B_Prn_Text_TrueType(250, 805, 27, "Arial", 1, 400, 0, 0, 0, "CL", "TEL：" + waybillInfo.sender_tel);
            if (waybillInfo.sender_addr_en.Length > 60)
            {
                B_Prn_Text_TrueType(75, 830, 27, "Arial", 1, 400, 0, 0, 0, "FB", waybillInfo.sender_addr_en.Substring(0, 60));
            }
            else
                B_Prn_Text_TrueType(75, 830, 27, "Arial", 1, 400, 0, 0, 0, "FB", waybillInfo.sender_addr_en);
            B_Prn_Text_TrueType(75, 855, 27, "Arial", 1, 400, 0, 0, 0, "FC", waybillInfo.StoreHouseLong);
            B_Prn_Text_TrueType(75, 880, 27, "Arial", 1, 400, 0, 0, 0, "FD", waybillInfo.StoreHouseShort);
            B_Prn_Text_TrueType(75, 910, 27, "Arial", 1, 400, 0, 0, 0, "FE", "※返還は依頼主まで。返還前連絡は不要。");
            //B_Prn_Text_TrueType(780, 910, 27, "Arial", 1, 400, 0, 0, 0, "FF", "様");

            B_Prn_Text_TrueType(150, 970, 27, "Arial", 1, 400, 0, 0, 0, "GA", waybillInfo.total_package_cnt + "pack  " + waybillInfo.packages[packIndex].package_weight);
            B_Prn_Text_TrueType(20, 1022, 25, "Arial", 1, 400, 0, 0, 0, "GB", "日本郵便株式会社");


            //draw codabar
            B_Prn_Barcode(400, 40, 0, "K", 2, 4, 70, 'N', waybillInfo.ArrivalShopNo);//从上倒下第一个条形码
            B_Prn_Barcode(200, 545, 0, "K", 3, 6, 70, 'N', "A" + waybillInfo.jp_express_no + "A");//从上倒下第一个条形码

            //barcode.
            //B_Prn_Barcode(420, 100, 0, "3", 2, 3, 40, 'B', "1234<+1>");//have a counter
            //B_Bar2d_QR(420, 200, 1, 3, 'M', 'A', 0, 0, 0, "QR CODE");

            //picture.
            //B_Get_Graphic_ColorBMP(420, 280, "bb.bmp");// Color bmp file.
            //B_Get_Graphic_ColorBMPEx(420, 320, 200, 150, 2, "bb1", "bb.bmp");//180 angle.
            //IntPtr himage = LoadImage(IntPtr.Zero, "bb.bmp", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
            //B_Get_Graphic_ColorBMP_HBitmap(630, 280, 250, 80, 1, "bb2", himage);//90 angle.
            //if (IntPtr.Zero != himage)
            //    DeleteObject(himage);

            B_Print_Out(1);//参数是打印份数
            B_ClosePrn();
            System.Threading.Thread.Sleep(500);
        }
        #endregion

        #region 日本邮政小贴标

        public static void JapanEmsSmallPrint(WaybillInfo waybillInfo, int packIndex)
        {
            PrinterInitialize();

            B_Draw_Line('E', 30, 348, 160, 2);//横线
            B_Draw_Line('E', 30, 398, 160, 2);//横线
            //B_Draw_Line('E', 30, 440, 160, 2);//横线

            B_Draw_Line('O', 30, 348, 2, 112);//竖线
            B_Draw_Line('O', 190, 348, 2, 112);//竖线

            B_Prn_Text_TrueType(45, 403, 35, "Arial", 1, 300, 0, 0, 0, "BN1", "料金後納");

            IntPtr himage = LoadImage(IntPtr.Zero, @"Resources\jpEmsSmallBmp.bmp", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
            B_Get_Graphic_ColorBMP_HBitmap(30, 440, 162, 80, 0, "BN2", himage);//100 angle.
            if (IntPtr.Zero != himage)
                DeleteObject(himage);

            B_Prn_Barcode(30, 620, 0, "K", 2, 6, 48, 'N', "A" + waybillInfo.jp_express_no + "A");//条形码
            B_Prn_Text_TrueType(130, 680, 30, "Arial", 1, 400, 0, 0, 0, "BN3", waybillInfo.jp_express_no);//条形码数字
            //B_Prn_Text_TrueType(30, 710, 20, "Arial", 1, 400, 0, 0, 0, "BN7", "SHANDONG SHINESEN INT'L TRANSPORT CO.,LTD");

            B_Prn_Text_TrueType(220, 340, 60, "Arial", 1, 400, 0, 0, 0, "BN4", waybillInfo.receiver_zip_cd.Substring(0, 3) + " - " + waybillInfo.receiver_zip_cd.Substring(3, 4));//1450071

            if (waybillInfo.receiver_addr_cn.Length > 18) //如果地址长度大于21分2行
            {
                B_Prn_Text_TrueType(220, 410, 30, "Arial", 1, 400, 0, 0, 0, "BN50",
                    waybillInfo.receiver_addr_cn.Substring(0, 18));
                B_Prn_Text_TrueType(220, 440, 30, "Arial", 1, 400, 0, 0, 0, "BN51",
                    waybillInfo.receiver_addr_cn.Substring(18, waybillInfo.receiver_addr_cn.Length - 18));
            }
            else//如果地址长度小于21不分行
            {
                B_Prn_Text_TrueType(220, 410, 30, "Arial", 1, 400, 0, 0, 0, "BN5", waybillInfo.receiver_addr_cn);//
            }

            B_Prn_Text_TrueType(220, 480, 35, "Arial", 1, 400, 0, 0, 0, "BN6", waybillInfo.receiver_nm_cn);//　熊谷様
            //B_Prn_Text_TrueType(80, 570, 30, "Arial", 1, 400, 0, 0, 0, "BN7", p4);//　1001
            if (!waybillInfo.items[0].item_nm_en.IsNullOrEmpty())
            {
                if (waybillInfo.items[0].item_nm_en.Length > 17)
                    B_Prn_Text_TrueType(220, 510, 30, "Arial", 1, 400, 0, 0, 0, "BN8", waybillInfo.items[0].item_nm_en.Substring(0, 17));
                //品名:LADYS SHOES (UP:PU　SOLE:TPR)
                else
                    B_Prn_Text_TrueType(220, 510, 30, "Arial", 1, 400, 0, 0, 0, "BN8", waybillInfo.items[0].item_nm_en);
            }
            B_Prn_Text_TrueType(515, 510, 30, "Arial", 1, 400, 0, 0, 0, "BN15", waybillInfo.total_package_cnt + "pack  " + waybillInfo.packages[packIndex].package_weight);

            //收件公司
            //如果收件公司地址长度超过30，分两行打印出来
            if (waybillInfo.sender_nm_en.Length > 30)
            {
                B_Prn_Text_TrueType(220, 540, 30, "Arial", 1, 400, 0, 0, 0, "BN17", waybillInfo.sender_nm_en.Substring(0, 29));
                B_Prn_Text_TrueType(220, 570, 30, "Arial", 1, 400, 0, 0, 0, "BN18", waybillInfo.sender_nm_en.Substring(29, waybillInfo.sender_nm_en.Length - 29));
            }
            else {
                B_Prn_Text_TrueType(220, 550, 30, "Arial", 1, 400, 0, 0, 0, "BN17", waybillInfo.sender_nm_en);
            }
            

            //盛欣单号
            B_Prn_Text_TrueType(488, 610, 25, "Arial", 1, 400, 0, 0, 0, "BN13", waybillInfo.sx_no);
            B_Prn_Text_TrueType(480, 640, 20, "Arial", 1, 400, 0, 0, 0, "BN9", "【差出人:返送先】〒 286-0113");//【差出人:返送先】〒286-0113
            B_Prn_Text_TrueType(488, 664, 20, "Arial", 1, 400, 0, 0, 0, "BN11", "TEL:0476-35-6180");//MOAL株式会社　千葉県成田市
            B_Prn_Text_TrueType(488, 687, 20, "Arial", 1, 400, 0, 0, 0, "BN12", "MO通販倉庫");
            B_Prn_Text_TrueType(486, 710, 20, "Arial", 1, 400, 0, 0, 0, "BN16", "千葉県成田市南三里塚78-7");//MOAL株式会社　千葉県成田市

            B_Print_Out(1);//参数是打印份数
            B_ClosePrn();
            System.Threading.Thread.Sleep(500);
        }
        #endregion

        #region 佐川飞脚
        public static void SagawaHikiyakuPrint(WaybillInfo waybillInfo, int packIndex)
        {
            PrinterInitialize();

            B_Draw_Box(185, 30, 4, 715, 1040);

            var colName = "お届け先";
            var src = "S R C 2 F";
            var storeCompany = "佐川ュンヒュ-タ-システム";
            var storeHouse = "北沢";

            //第一部分
            for (var i = 0; i < colName.Length; i++)
            {
                B_Prn_Text_TrueType(644 - 50 * i, 50, 30, "Arial", 2, 400, 0, 0, 0, "BNA", i.ToString());
            }
            if (waybillInfo.receiver_addr_cn.Length > 6)
            {
                B_Prn_Text_TrueType(604, 100, 30, "Arial", 2, 400, 0, 0, 0, "BNB", waybillInfo.receiver_addr_cn.Substring(0, 6));
                B_Prn_Text_TrueType(574, 100, 30, "Arial", 2, 400, 0, 0, 0, "BNC", waybillInfo.receiver_addr_cn.Substring(6, waybillInfo.receiver_addr_cn.Length - 6));
            }
            else
                B_Prn_Text_TrueType(604, 100, 30, "Arial", 2, 400, 0, 0, 0, "BNB", waybillInfo.receiver_addr_cn);

            for (var i = 0; i < src.Length; i++)
            {
                var tempId = "BN" + "D" + i.ToString();
                B_Prn_Text_TrueType(544, 100 + 16 * i, 30, "Arial", 2, 400, 0, 0, 0, tempId, src[i].ToString());
            }

            B_Prn_Text_TrueType(514, 100, 30, "Arial", 2, 400, 0, 0, 0, "BNE", storeCompany.ToString());
            B_Prn_Text_TrueType(484, 100, 30, "Arial", 2, 400, 0, 0, 0, "BNF", storeHouse.ToString());
            B_Prn_Text_TrueType(454, 100, 30, "Arial", 2, 400, 0, 0, 0, "BNG", "TEL  03-3768-8713");
            //第二部分
            B_Prn_Barcode(604, 720, 1, "K", 3, 8, 145, 'N', "7016");
            B_Prn_Text_TrueType(644, 720, 55, "Arial", 2, 400, 0, 0, 0, "BNH", "7-016");
            //第三部分
            B_Prn_Barcode(420, 48, 1, "K", 3, 6, 145, 'N', waybillInfo.jp_express_no);
            B_Prn_Text_TrueType(220, 134, 32, "Arial", 2, 400, 0, 0, 0, "BNI", "メ-ル便No. " + waybillInfo.jp_express_no);
            //第四部分
            //var f5 = "飞脚便签";

            B_Prn_Text_TrueType(420, 688, 30, "Arial", 2, 400, 0, 0, 0, "BNJ", "お問合せ店");
            B_Prn_Text_TrueType(390, 688, 30, "Arial", 2, 400, 0, 0, 0, "BNK", "佐川急便(株)");
            B_Prn_Text_TrueType(360, 688, 30, "Arial", 2, 400, 0, 0, 0, "BNL", "渋谷店");
            B_Prn_Text_TrueType(330, 688, 30, "Arial", 2, 400, 0, 0, 0, "BNM", "TEL  03-5764-3101");
            var exp = "1この荷物は佐川急便が配逵しました2この荷物は佐川急便が配逵しました3この荷物は佐川急便が配逵しました4この荷物は佐川急便が配逵しました5この荷物は佐川急便が配逵しました";
            if (exp.Length <= 20)
            {
                B_Prn_Text_TrueType(225, 584, 24, "Arial", 2, 400, 0, 0, 0, "BNN", exp.ToString());
            }
            else if (exp.Length > 20 && exp.Length <= 40)
            {
                B_Prn_Text_TrueType(225, 584, 24, "Arial", 2, 400, 0, 0, 0, "BNO", exp.Substring(0, 20));
                B_Prn_Text_TrueType(205, 584, 24, "Arial", 2, 400, 0, 0, 0, "BNP" + "1", exp.Substring(20, 20));
            }
            else
            {
                B_Prn_Text_TrueType(225, 584, 24, "Arial", 2, 400, 0, 0, 0, "BNQ", exp.Substring(0, 20));
                B_Prn_Text_TrueType(205, 584, 24, "Arial", 2, 400, 0, 0, 0, "BNR" + "1", exp.Substring(20, 20));
                B_Prn_Text_TrueType(185, 584, 24, "Arial", 2, 400, 0, 0, 0, "BNS" + "2", exp.Substring(40, 20));
            }


            /*B_Get_Graphic_ColorBMPEx(110, 688, 0, 0, 0, "testPic", "temp.bmp");

            B_Get_Graphic_ColorBMPEx(220, 688, 0, 0, 0, "testPic1", "C:\\Users\\zx\\Source\\Repos\\ShengXinPrint\\ShengXinSolution.Client.LablePrintSystem\\Resources\temp.bmpp");

            B_Load_Pcx(330, 688, "testPic");
            */
            //picture.
            /* B_Get_Graphic_ColorBMP(110, 688, "feijiao.bmp");// Color bmp file.
             B_Get_Graphic_ColorBMPEx(110, 688, 0, 0, 1, "bb1", "feijiao.bmp");//180 angle.*/
            /*IntPtr himage = LoadImage(IntPtr.Zero, "feijiao.bmp", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
            B_Get_Graphic_ColorBMP_HBitmap(275, 688, 320, 45, 1, "bb2", himage);//90 angle.
            if (IntPtr.Zero != himage)
                DeleteObject(himage);
                */
            B_Print_Out(1);//参数是打印份数
            B_ClosePrn();
            System.Threading.Thread.Sleep(500);
        }
        #endregion
        #region 黑猫
        public static void YamatoLablePrint(WaybillInfo waybillInfo, int packIndex)
        {
            PrinterInitialize();

            B_Prn_Text_TrueType(110, 230, 40, "Arial", 1, 400, 0, 0, 0, "BN1", "〒 " + waybillInfo.receiver_zip_cd.Substring(0,3)+"-"+waybillInfo.receiver_zip_cd.Substring(3,4));//日本邮编
            
            //日本收货地址一行不够 需要换行
            if (waybillInfo.receiver_addr_cn.Length > 20)
            {
                B_Prn_Text_TrueType(110, 280, 40, "Arial", 1, 400, 0, 0, 0, "BN11", waybillInfo.receiver_addr_cn.Substring(0, 20));
                B_Prn_Text_TrueType(110, 320, 40, "Arial", 1, 400, 0, 0, 0, "BN12", waybillInfo.receiver_addr_cn.Substring(20, waybillInfo.receiver_addr_cn.Length - 20));
            }
            else
            {
                B_Prn_Text_TrueType(110, 280, 40, "Arial", 1, 400, 0, 0, 0, "BN13", waybillInfo.receiver_addr_cn);
            }

            B_Prn_Text_TrueType(110, 400, 30, "Arial", 1, 400, 0, 0, 0, "BN19", waybillInfo.waybill_id);//中国号
            B_Prn_Text_TrueType(110, 430, 30, "Arial", 1, 400, 0, 0, 0, "BN20", waybillInfo.sender_nm_en);//发件公司
            //品名处理
            if (waybillInfo.items[0].item_nm_en.Length > 60)
            {
                B_Prn_Text_TrueType(110, 460, 25, "Arial", 1, 400, 0, 0, 0, "BN21", waybillInfo.items[0].item_nm_en.Substring(0, 59));
            }
            else
            {
                B_Prn_Text_TrueType(110, 460, 25, "Arial", 1, 400, 0, 0, 0, "BN21", waybillInfo.items[0].item_nm_en);
            }

            //收件人电话
            B_Prn_Text_TrueType(110, 490, 30, "Arial", 1, 400, 0, 0, 0, "BN14", waybillInfo.receiver_tel);
            //收件人
            B_Prn_Text_TrueType(110, 520, 40, "Arial", 1, 400, 0, 0, 0, "BN15", waybillInfo.receiver_contact_nm_cn);

            B_Prn_Barcode(154, 570, 0, "K", 2, 8, 72, 'N', "A" + waybillInfo.jp_express_no + "A"); //条形码
            B_Prn_Text_TrueType(264, 640, 30, "Arial", 1, 400, 0, 0, 0, "BN22", "a"+waybillInfo.jp_express_no+"a");

            //Yamato image
            IntPtr himage = LoadImage(IntPtr.Zero, @"Resources\yamato.bmp", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
            B_Get_Graphic_ColorBMP_HBitmap(110, 690, 360, 32, 0, "YAMATO", himage);//100 angle.
            if (IntPtr.Zero != himage)
                DeleteObject(himage);

            //yamato信息
            B_Prn_Text_TrueType(520, 690, 30, "Arial", 1, 400, 0, 0, 0, "BN16", "三里塚センター");
            B_Prn_Text_TrueType(110, 720, 30, "Arial", 1, 400, 0, 0, 0, "BN17", "この荷物は郵便物ではありません 025-201");
            B_Prn_Text_TrueType(110, 750, 30, "Arial", 1, 400, 0, 0, 0, "BN18", "お問い合せ先　フリ－ダイヤル 0120-11-8010");
            
            // output.
            B_Print_Out(1);//参数是打印份数
            // close port.
            B_ClosePrn();
            System.Threading.Thread.Sleep(500);
        }
        #endregion

        #region 佐川急便(BBC专用)
        public static void SagawaBBCLablePrint(WaybillInfo waybillInfo, int packIndex)
        {
            PrinterInitialize();

            B_Draw_Box(20, 20, 10, 840, 1040);//横线
            B_Draw_Line('E', 576, 66, 248, 4); //第一条横线 D
            B_Draw_Line('E', 576, 122, 248, 4); //第二条横线 D
            B_Draw_Line('E', 28, 186, 796, 4); //第三条横线 D
            B_Draw_Line('E', 576, 226, 248, 4); //第四条横线 D
            B_Draw_Line('E', 576, 372, 248, 4); //第五条横线 D
            B_Draw_Line('E', 28, 418, 798, 4); //第六条横线 D
            B_Draw_Line('E', 28, 466, 420, 4); //第七条横线 D
            B_Draw_Line('E', 28, 576, 798, 4); //第八条横线 D
            B_Draw_Line('E', 28, 696, 798, 4); //第九条横线 D
            B_Draw_Line('E', 28, 815, 798, 4); //第十条横线 D
            B_Draw_Line('E', 28, 872, 420, 4); //第十一条横线 D
            B_Draw_Line('E', 28, 976, 798, 4); //第十二条横线 D

            //draw ver line
            B_Draw_Line('O', 50, 186, 4, 232); //1A 竖线
            B_Draw_Line('O', 50, 576, 4, 240); //1B 竖线
            B_Draw_Line('O', 443, 418, 4, 160); //2A 竖线
            B_Draw_Line('O', 443, 815, 4, 164); //2B 竖线
            B_Draw_Line('O', 467, 418, 4, 160); //3A 竖线
            B_Draw_Line('O', 467, 815, 4, 164); //3B 竖线
            B_Draw_Line('O', 576, 20, 4, 356); //4 竖线

            //判断大数字是否超过3个，如果超过三个缩小字体，位置前移
            if (waybillInfo.fandi_no_big.Length > 3)
            {
                B_Prn_Text_TrueType(40, 30, 170, "Arial", 1, 400, 0, 0, 0, "BA", waybillInfo.fandi_no_big);//大数字
                B_Prn_Text_TrueType(400, 96, 90, "Arial", 1, 400, 0, 0, 0, "BB", waybillInfo.fandi_no_small);//小数字
            }
            else
            {
                //如果没有超过3个还是按照之前的样式打印
                B_Prn_Text_TrueType(60, 30, 170, "Arial", 1, 400, 0, 0, 0, "BA", waybillInfo.fandi_no_big);//大数字
                B_Prn_Text_TrueType(400, 96, 90, "Arial", 1, 400, 0, 0, 0, "BB", waybillInfo.fandi_no_small);//小数字
            }

            string dateStr = waybillInfo.print_date;
            dateStr = DateTime.ParseExact(dateStr, "yyyyMMdd", null).ToString("yy年MM月dd日");

            B_Prn_Text_TrueType(610, 37, 22, "Arial", 1, 400, 0, 0, 0, "BG", "発送日:" + dateStr);//发送日期
            B_Prn_Text_TrueType(650, 80, 45, "Arial", 1, 400, 0, 0, 0, "BH", "個   数");//save in printer.
            B_Prn_Text_TrueType(670, 137, 45, "Arial", 1, 400, 0, 0, 0, "BI1", waybillInfo.packages[packIndex].package_id);//当前包裹号
            B_Prn_Text_TrueType(705, 140, 45, "Arial", 1, 400, 0, 0, 0, "BI2", "/");//
            B_Prn_Text_TrueType(725, 143, 45, "Arial", 1, 400, 0, 0, 0, "BI3", waybillInfo.total_package_cnt);//总包裹数
            B_Prn_Text_TrueType(630, 200, 20, "Arial", 1, 400, 0, 0, 0, "BJ", "着営業所バーコード");
            //お届け先
            B_Prn_Text_TrueType(32, 265, 20, "Arial", 1, 400, 0, 0, 0, "BK", "お");
            B_Prn_Text_TrueType(32, 285, 20, "Arial", 1, 400, 0, 0, 0, "BK1", "届");
            B_Prn_Text_TrueType(32, 305, 20, "Arial", 1, 400, 0, 0, 0, "BK2", "け");
            B_Prn_Text_TrueType(32, 325, 20, "Arial", 1, 400, 0, 0, 0, "BK3", "先");
            //輸出者
            B_Prn_Text_TrueType(32, 615, 20, "Arial", 1, 400, 0, 0, 0, "BK4", "輸");
            B_Prn_Text_TrueType(32, 635, 20, "Arial", 1, 400, 0, 0, 0, "BK5", "出");
            B_Prn_Text_TrueType(32, 655, 20, "Arial", 1, 400, 0, 0, 0, "BK6", "者");
            //ご依頼主
            B_Prn_Text_TrueType(32, 720, 20, "Arial", 1, 400, 0, 0, 0, "BK7", "ご");
            B_Prn_Text_TrueType(32, 740, 20, "Arial", 1, 400, 0, 0, 0, "BK8", "依");
            B_Prn_Text_TrueType(32, 760, 20, "Arial", 1, 400, 0, 0, 0, "BK9", "頼");
            B_Prn_Text_TrueType(32, 780, 20, "Arial", 1, 400, 0, 0, 0, "BK10", "主");
            //間合番号
            B_Prn_Text_TrueType(448, 465, 20, "Arial", 1, 400, 0, 0, 0, "BK11", "間");
            B_Prn_Text_TrueType(448, 485, 20, "Arial", 1, 400, 0, 0, 0, "BK12", "合");
            B_Prn_Text_TrueType(448, 505, 20, "Arial", 1, 400, 0, 0, 0, "BK13", "番");
            B_Prn_Text_TrueType(448, 525, 20, "Arial", 1, 400, 0, 0, 0, "BK14", "号");
            //品名荷姿
            B_Prn_Text_TrueType(448, 865, 20, "Arial", 1, 400, 0, 0, 0, "BK15", "品");
            B_Prn_Text_TrueType(448, 885, 20, "Arial", 1, 400, 0, 0, 0, "BK16", "名");
            B_Prn_Text_TrueType(448, 905, 20, "Arial", 1, 400, 0, 0, 0, "BK17", "荷");
            B_Prn_Text_TrueType(448, 925, 20, "Arial", 1, 400, 0, 0, 0, "BK18", "姿");

            if (waybillInfo.StoreHouseShort.Equals("成田店"))
                B_Prn_Text_TrueType(140, 425, 45, "Arial", 1, 400, 0, 0, 0, "BL", waybillInfo.StoreHouseShort);//集货店名称
            else
                B_Prn_Text_TrueType(60, 423, 45, "Arial", 1, 400, 0, 0, 0, "BL", waybillInfo.StoreHouseShort);//集货店名称
            B_Prn_Text_TrueType(80, 480, 30, "Arial", 1, 400, 0, 0, 0, "BM1", "お問合せTEL:" + waybillInfo.StoreHouseTel);//集货店电话
            B_Prn_Text_TrueType(80, 510, 30, "Arial", 1, 400, 0, 0, 0, "BM2", "お問合せFAX:" + waybillInfo.StoreHouseFax);//集货店传真
            B_Prn_Text_TrueType(80, 540, 30, "Arial", 1, 400, 0, 0, 0, "BM3", "出荷場コード:" + waybillInfo.StoreHouseCd);//出荷场
            B_Prn_Text_TrueType(75, 823, 25, "Arial", 1, 400, 0, 0, 0, "BS4", "佐川急便(株)の損害賠償限度額は");
            B_Prn_Text_TrueType(75, 847, 25, "Arial", 1, 400, 0, 0, 0, "BS5", "荷物１個につき３０万円です");

            //打印需要输出文字
            B_Prn_Text_TrueType(95, 200, 30, "Arial", 1, 400, 0, 0, 0, "BN1", "〒 " + waybillInfo.receiver_zip_cd);//日本邮编
            //日本收货地址一行不够 需要换行
            if (waybillInfo.receiver_addr_cn.Length > 36)
            {
                B_Prn_Text_TrueType(95, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN121", waybillInfo.receiver_addr_cn.Substring(0, 18));
                B_Prn_Text_TrueType(95, 264, 30, "Arial", 1, 400, 0, 0, 0, "BN122", waybillInfo.receiver_addr_cn.Substring(18, 18));
                B_Prn_Text_TrueType(95, 296, 30, "Arial", 1, 400, 0, 0, 0, "BN131", waybillInfo.receiver_addr_cn.Substring(36, waybillInfo.receiver_addr_cn.Length - 36));
            }
            else if (waybillInfo.receiver_addr_cn.Length > 18)
            {
                B_Prn_Text_TrueType(95, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN12", waybillInfo.receiver_addr_cn.Substring(0, 18));
                B_Prn_Text_TrueType(95, 264, 30, "Arial", 1, 400, 0, 0, 0, "BN13", waybillInfo.receiver_addr_cn.Substring(18, waybillInfo.receiver_addr_cn.Length - 18));
            }
            else
            {
                B_Prn_Text_TrueType(95, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN12", waybillInfo.receiver_addr_cn);
            }
            //收件公司一行也可能不够
            if (waybillInfo.receiver_nm_cn.Length > 18)
            {
                B_Prn_Text_TrueType(95, 328, 30, "Arial", 1, 400, 0, 0, 0, "BN141", waybillInfo.receiver_nm_cn.Substring(0, 18));//收件公司
                B_Prn_Text_TrueType(95, 360, 30, "Arial", 1, 400, 0, 0, 0, "BN142", waybillInfo.receiver_nm_cn.Substring(18, waybillInfo.receiver_nm_cn.Length - 18) + "   " + waybillInfo.receiver_contact_nm_cn);//收件公司+收件人
            }
            else
            {
                B_Prn_Text_TrueType(95, 328, 30, "Arial", 1, 400, 0, 0, 0, "BN14", waybillInfo.receiver_nm_cn);//收件公司
                B_Prn_Text_TrueType(95, 360, 30, "Arial", 1, 400, 0, 0, 0, "BN15", waybillInfo.receiver_contact_nm_cn);//收件人
            }
            B_Prn_Text_TrueType(95, 392, 30, "Arial", 1, 400, 0, 0, 0, "BN16", "TEL:" + waybillInfo.receiver_tel);//收件人电话


            //输出者
            B_Prn_Text_TrueType(95, 595, 35, "Arial", 1, 400, 0, 0, 0, "BN2", waybillInfo.sender_nm_en);//代理发件公司：agentSendCompany
            //下面的地址字符串长度会超过打印标签的宽度，所以需要进行判断，如果字符串长度超过标签纸宽度，打印在标签上的文字要进行换行.
            if (waybillInfo.sender_addr_en.Length > 45)
            {
                B_Prn_Text_TrueType(95, 638, 30, "Arial", 1, 400, 0, 0, 0, "BN211", waybillInfo.sender_addr_en.Substring(0, 45));//代理发件公司地址：agentSendCompanyAddress
                B_Prn_Text_TrueType(95, 663, 30, "Arial", 1, 400, 0, 0, 0, "BN212", waybillInfo.sender_addr_en.Substring(45, waybillInfo.sender_addr_en.Length - 45));//代理发件公司地址：agentSendCompanyAddress
            }
            else
            {
                B_Prn_Text_TrueType(95, 638, 30, "Arial", 1, 400, 0, 0, 0, "BN21", waybillInfo.sender_addr_en);//代理发件公司地址：agentSendCompanyAddress
            }

            //运送会社
            B_Prn_Text_TrueType(95, 740, 30, "Arial", 1, 400, 0, 0, 0, "BS1", "エムオーエアロジスティックス(株)/MO  通販倉庫");//代理运输公司和营业所
            //B_Prn_Text_TrueType(95, 775, 30, "Arial", 1, 400, 0, 0, 0, "BS2", "TEL:0476-35-6180" + "       " + "FAX:" + waybillInfo.StoreCompanyFax);//营业所电话和传真
            B_Prn_Text_TrueType(95, 775, 30, "Arial", 1, 400, 0, 0, 0, "BS2", "TEL:0476-35-6180");//营业所电话和传真
            if (!waybillInfo.items[0].item_nm_en.IsNullOrEmpty())
            {
                if (waybillInfo.items[0].item_nm_en.Length > 75)
                {
                    B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", waybillInfo.items[0].item_nm_en.Substring(0, 25));//货物名称
                    B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", waybillInfo.items[0].item_nm_en.Substring(25, 25));//货物名称
                    B_Prn_Text_TrueType(495, 862, 24, "Arial", 1, 400, 0, 0, 0, "BN33", waybillInfo.items[0].item_nm_en.Substring(50, 25));//货物名称
                    B_Prn_Text_TrueType(495, 882, 24, "Arial", 1, 400, 0, 0, 0, "BN34", waybillInfo.items[0].item_nm_en.Substring(75, waybillInfo.items[0].item_nm_en.Length - 75));//货物名称
                }
                else
                {
                    if (waybillInfo.items[0].item_nm_en.Length > 50)//长度大于60分三行
                    {
                        B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", waybillInfo.items[0].item_nm_en.Substring(0, 25));//货物名称
                        B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", waybillInfo.items[0].item_nm_en.Substring(25, 25));//货物名称
                        B_Prn_Text_TrueType(495, 862, 24, "Arial", 1, 400, 0, 0, 0, "BN33", waybillInfo.items[0].item_nm_en.Substring(50, waybillInfo.items[0].item_nm_en.Length - 50));//货物名称
                    }
                    else
                    {
                        if (waybillInfo.items[0].item_nm_en.Length > 25)//长度大于30小于60分两行
                        {
                            B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", waybillInfo.items[0].item_nm_en.Substring(0, 25));//货物名称
                            B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", waybillInfo.items[0].item_nm_en.Substring(25, waybillInfo.items[0].item_nm_en.Length - 25));//货物名称
                        }
                        else
                        { //长度小于18一行显示
                            B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN3", waybillInfo.items[0].item_nm_en);//货物名称
                        }
                    }
                }
            }
            B_Prn_Text_TrueType(495, 904, 20, "Arial", 1, 400, 0, 0, 0, "BN4", waybillInfo.packages[packIndex].package_weight);//货物重量
            B_Prn_Text_TrueType(495, 924, 20, "Arial", 1, 400, 0, 0, 0, "BN5", waybillInfo.packages[packIndex].package_volume_weight + "サイズ ");//货物体积
            B_Prn_Text_TrueType(495, 947, 30, "Arial", 1, 400, 0, 0, 0, "BN6", waybillInfo.sx_no + "");//中国运单号
            //B_Prn_Text_TrueType(80, 990, 36, "Arial", 1, 400, 0, 0, 0, "BN7", "SDM");
            //B_Prn_Text_TrueType(170, 995, 30, "Arial", 1, 400, 0, 0, 0, "BN8", "SHANDONG SHINESEN INT'L TRANSPORT CO.,LTD");

            //print barcode
            //codabar（nw-7）次打印机的接收参数必须是ABCD....ABCD格式的，也就是说开头和结尾必须是大写的
            //参数必须改成2：4 不然扫码枪扫不出内容
            B_Prn_Barcode(610, 250, 0, "K", 2, 4, 100, 'N', waybillInfo.ArrivalShopNo);//从上倒下第一个条形码
            //if(waybillInfo.total_package_cnt.Equals("1"))
            if (waybillInfo.StoreHouseShort.Equals("成田店"))
            {
                if (packIndex == 0)
                {
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "A" + waybillInfo.jp_express_no + "A"); //第二个条形码
                    B_Prn_Barcode(76, 890, 0, "K", 2, 4, 50, 'B', "A" + waybillInfo.jp_express_no + "A"); //第三个条形码
                }
                else
                {
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "D" + waybillInfo.jp_express_no + "D"); //第二个条形码
                    B_Prn_Barcode(76, 890, 0, "K", 2, 4, 50, 'B', "D" + waybillInfo.jp_express_no + "D");//第三个条形码
                }
            }
            else
            {
                if (waybillInfo.total_package_cnt.Equals("1"))
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "A" + waybillInfo.jp_express_no + "A"); //第二个条形码
                else
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "D" + waybillInfo.jp_express_no + "D"); //第二个条形码
                B_Prn_Text_TrueType(95, 710, 25, "Arial", 1, 400, 0, 0, 0, "BS0", "〒5490021　大阪府泉南市泉州空港南１第二国際貨物代理店ビル");
                B_Prn_Text_TrueType(40, 895, 25, "Arial", 1, 400, 0, 0, 0, "BS6", "□飛脚宅配便　□飛脚ラージサイズ宅配便");
                B_Prn_Text_TrueType(40, 930, 25, "Arial", 1, 400, 0, 0, 0, "BS7", "□飛脚航空便　□飛脚ラージサイズ航空便");
            }
            // output.
            B_Print_Out(1);//参数是打印份数
            // close port.
            B_ClosePrn();
            System.Threading.Thread.Sleep(500);
        }
        #endregion
        #region 主单
        public static void MasterPrint(MasterInfo masterInfo)
        {
            PrinterInitialize();
            var p0 = masterInfo.airline_company_nm;
            var p1 = "Master Air Waybill";
            var p2 = masterInfo.master_id;
            var p3 = "FLIGHT NO.";
            var p4 = masterInfo.flight_no;
            var p5 = "DEPARTURE        DESTINATION";
            var p61 = masterInfo.outlet_port;
            var p62 = " → ";
            var p63 = masterInfo.arrival_port;
            var p7 = "Total NO.OF PCS";
            var p8 = masterInfo.master_item_cnt.ToString();
            var p9 = "M.O.AIR LOGISTICS INC.NARITA";
            var p10 = "0476-49-7727";
            var p11 = masterInfo.item_index.ToString();

            B_Draw_Line('E', 20, 160, 800, 2);//横线
            B_Draw_Line('E', 20, 410, 800, 2);//横线
            B_Draw_Line('E', 20, 520, 460, 2);//横线
            B_Draw_Line('E', 20, 650, 800, 2);//横线
            B_Draw_Line('E', 20, 760, 800, 2);//横线
            B_Draw_Line('E', 480, 412, 2, 238);//竖线

            if (p0.Length > 21)//标题过长，单行放不下，缩小字体
            {
                B_Prn_Text_TrueType(150, 30, 60, "Arial Black", 1, 500, 0, 0, 0, "BN1", p0);//标签头
            }
            else
            {
                B_Prn_Text_TrueType(150, 30, 80, "Arial Black", 1, 500, 0, 0, 0, "BN1", p0);//标签头
            }

            B_Prn_Text_TrueType(30, 170, 30, "Arial", 1, 600, 0, 0, 0, "BN2", p1);//Master Air Waybill
            B_Prn_Text_TrueType(290, 190, 50, "Arial Black", 1, 600, 0, 0, 0, "BN3", p2);//条形码
            B_Prn_Barcode(120, 240, 0, "1", 6, 16, 160, 'N', p2);//条形码

            B_Prn_Text_TrueType(30, 420, 30, "Arial", 1, 600, 0, 0, 0, "BN4", p3);//Flight No. 题头
            B_Prn_Text_TrueType(130, 450, 70, "Arial Black", 1, 400, 0, 0, 0, "BN5", p4);//Flight No. 值

            B_Prn_Text_TrueType(50, 530, 30, "Arial", 1, 600, 0, 0, 0, "BN6", p5);//Departure and Destination
            B_Prn_Text_TrueType(70, 560, 80, "Arial Black", 1, 500, 0, 0, 0, "BN71", p61);//Departure 值
            B_Prn_Text_TrueType(200, 560, 80, "Arial Black", 1, 500, 0, 0, 0, "BN72", p62);//箭头
            B_Prn_Text_TrueType(290, 560, 80, "Arial Black", 1, 500, 0, 0, 0, "BN73", p63);//Destination 值

            B_Prn_Text_TrueType(550, 440, 30, "Arial", 1, 600, 0, 0, 0, "BN8", p7);//总号
            if (p8.Length >= 2)//长度大于2,左移一位
            {
                B_Prn_Text_TrueType(570, 460, 180, "Arial Black", 1, 500, 0, 0, 0, "BN9", p8);//总号为2位
            }
            else
            {
                B_Prn_Text_TrueType(620, 460, 180, "Arial Black", 1, 500, 0, 0, 0, "BN9", p8);//总号为1位
            }

            B_Prn_Text_TrueType(30, 670, 30, "Arial", 1, 600, 0, 0, 0, "BN10", p9);//地址
            B_Prn_Text_TrueType(30, 720, 30, "Arial", 1, 600, 0, 0, 0, "BN11", p10);//电话

            if (p11.Length >= 2)//长度大于2,左移一位，当前号
            {
                B_Prn_Text_TrueType(310, 760, 270, "Arial Black", 1, 500, 0, 0, 0, "BN12", p11);//当前号为2位
            }
            else
            {
                B_Prn_Text_TrueType(360, 760, 270, "Arial Black", 1, 500, 0, 0, 0, "BN12", p11);//当前号为1位
            }
            B_Print_Out(1);//参数是打印份数
            B_ClosePrn();
            System.Threading.Thread.Sleep(500);
        }
        #endregion
        
        #region 佐川急便(SUK专用)
        public static void SagawaSUKLablePrint(WaybillInfo waybillInfo, int packIndex) {
            PrinterInitialize();

            B_Draw_Box(20, 20, 10, 840, 1040);//横线
            B_Draw_Line('E', 576, 66, 248, 4); //第一条横线 D
            B_Draw_Line('E', 576, 122, 248, 4); //第二条横线 D
            B_Draw_Line('E', 28, 186, 796, 4); //第三条横线 D
            B_Draw_Line('E', 576, 226, 248, 4); //第四条横线 D
            B_Draw_Line('E', 576, 372, 248, 4); //第五条横线 D
            B_Draw_Line('E', 28, 418, 798, 4); //第六条横线 D
            B_Draw_Line('E', 28, 466, 420, 4); //第七条横线 D
            B_Draw_Line('E', 28, 576, 798, 4); //第八条横线 D
            B_Draw_Line('E', 28, 696, 798, 4); //第九条横线 D
            B_Draw_Line('E', 28, 815, 798, 4); //第十条横线 D
            B_Draw_Line('E', 28, 872, 420, 4); //第十一条横线 D
            B_Draw_Line('E', 28, 976, 798, 4); //第十二条横线 D

            //draw ver line
            B_Draw_Line('O', 50, 186, 4, 232); //1A 竖线
            B_Draw_Line('O', 50, 576, 4, 240); //1B 竖线
            B_Draw_Line('O', 443, 418, 4, 160); //2A 竖线
            B_Draw_Line('O', 443, 815, 4, 164); //2B 竖线
            B_Draw_Line('O', 467, 418, 4, 160); //3A 竖线
            B_Draw_Line('O', 467, 815, 4, 164); //3B 竖线
            B_Draw_Line('O', 576, 20, 4, 356); //4 竖线

            //判断大数字是否超过3个，如果超过三个缩小字体，位置前移
            if (waybillInfo.fandi_no_big.Length > 3)
            {
                B_Prn_Text_TrueType(40, 30, 170, "Arial", 1, 400, 0, 0, 0, "BA", waybillInfo.fandi_no_big);//大数字
                B_Prn_Text_TrueType(400, 96, 90, "Arial", 1, 400, 0, 0, 0, "BB", waybillInfo.fandi_no_small);//小数字
            }
            else
            {
                //如果没有超过3个还是按照之前的样式打印
                B_Prn_Text_TrueType(60, 30, 170, "Arial", 1, 400, 0, 0, 0, "BA", waybillInfo.fandi_no_big);//大数字
                B_Prn_Text_TrueType(400, 96, 90, "Arial", 1, 400, 0, 0, 0, "BB", waybillInfo.fandi_no_small);//小数字
            }

            string dateStr = waybillInfo.print_date;
            dateStr = DateTime.ParseExact(dateStr, "yyyyMMdd", null).ToString("yy年MM月dd日");

            B_Prn_Text_TrueType(610, 37, 22, "Arial", 1, 400, 0, 0, 0, "BG", "発送日:" + dateStr);//发送日期
            B_Prn_Text_TrueType(650, 80, 45, "Arial", 1, 400, 0, 0, 0, "BH", "個   数");//save in printer.
            B_Prn_Text_TrueType(670, 137, 45, "Arial", 1, 400, 0, 0, 0, "BI1", waybillInfo.packages[packIndex].package_id);//当前包裹号
            B_Prn_Text_TrueType(705, 140, 45, "Arial", 1, 400, 0, 0, 0, "BI2", "/");//
            B_Prn_Text_TrueType(725, 143, 45, "Arial", 1, 400, 0, 0, 0, "BI3", waybillInfo.total_package_cnt);//总包裹数
            B_Prn_Text_TrueType(630, 200, 20, "Arial", 1, 400, 0, 0, 0, "BJ", "着営業所バーコード");
            //お届け先
            B_Prn_Text_TrueType(32, 265, 20, "Arial", 1, 400, 0, 0, 0, "BK", "お");
            B_Prn_Text_TrueType(32, 285, 20, "Arial", 1, 400, 0, 0, 0, "BK1", "届");
            B_Prn_Text_TrueType(32, 305, 20, "Arial", 1, 400, 0, 0, 0, "BK2", "け");
            B_Prn_Text_TrueType(32, 325, 20, "Arial", 1, 400, 0, 0, 0, "BK3", "先");
            //輸出者
            B_Prn_Text_TrueType(32, 615, 20, "Arial", 1, 400, 0, 0, 0, "BK4", "輸");
            B_Prn_Text_TrueType(32, 635, 20, "Arial", 1, 400, 0, 0, 0, "BK5", "出");
            B_Prn_Text_TrueType(32, 655, 20, "Arial", 1, 400, 0, 0, 0, "BK6", "者");
            //ご依頼主
            B_Prn_Text_TrueType(32, 720, 20, "Arial", 1, 400, 0, 0, 0, "BK7", "ご");
            B_Prn_Text_TrueType(32, 740, 20, "Arial", 1, 400, 0, 0, 0, "BK8", "依");
            B_Prn_Text_TrueType(32, 760, 20, "Arial", 1, 400, 0, 0, 0, "BK9", "頼");
            B_Prn_Text_TrueType(32, 780, 20, "Arial", 1, 400, 0, 0, 0, "BK10", "主");
            //間合番号
            B_Prn_Text_TrueType(448, 465, 20, "Arial", 1, 400, 0, 0, 0, "BK11", "間");
            B_Prn_Text_TrueType(448, 485, 20, "Arial", 1, 400, 0, 0, 0, "BK12", "合");
            B_Prn_Text_TrueType(448, 505, 20, "Arial", 1, 400, 0, 0, 0, "BK13", "番");
            B_Prn_Text_TrueType(448, 525, 20, "Arial", 1, 400, 0, 0, 0, "BK14", "号");
            //品名荷姿
            B_Prn_Text_TrueType(448, 865, 20, "Arial", 1, 400, 0, 0, 0, "BK15", "品");
            B_Prn_Text_TrueType(448, 885, 20, "Arial", 1, 400, 0, 0, 0, "BK16", "名");
            B_Prn_Text_TrueType(448, 905, 20, "Arial", 1, 400, 0, 0, 0, "BK17", "荷");
            B_Prn_Text_TrueType(448, 925, 20, "Arial", 1, 400, 0, 0, 0, "BK18", "姿");

            if (waybillInfo.StoreHouseShort.Equals("成田店"))
                B_Prn_Text_TrueType(140, 425, 45, "Arial", 1, 400, 0, 0, 0, "BL", waybillInfo.StoreHouseShort);//集货店名称
            else
                B_Prn_Text_TrueType(60, 423, 45, "Arial", 1, 400, 0, 0, 0, "BL", waybillInfo.StoreHouseShort);//集货店名称
            B_Prn_Text_TrueType(80, 480, 30, "Arial", 1, 400, 0, 0, 0, "BM1", "お問合せTEL:" + waybillInfo.StoreHouseTel);//集货店电话
            B_Prn_Text_TrueType(80, 510, 30, "Arial", 1, 400, 0, 0, 0, "BM2", "お問合せFAX:" + waybillInfo.StoreHouseFax);//集货店传真
            B_Prn_Text_TrueType(80, 540, 30, "Arial", 1, 400, 0, 0, 0, "BM3", "出荷場コード:" + waybillInfo.StoreHouseCd);//出荷场
            B_Prn_Text_TrueType(75, 823, 25, "Arial", 1, 400, 0, 0, 0, "BS4", "佐川急便(株)の損害賠償限度額は");
            B_Prn_Text_TrueType(75, 847, 25, "Arial", 1, 400, 0, 0, 0, "BS5", "荷物１個につき３０万円です");

            //打印需要输出文字
            B_Prn_Text_TrueType(95, 200, 30, "Arial", 1, 400, 0, 0, 0, "BN1", "〒 " + waybillInfo.receiver_zip_cd);//日本邮编
            //日本收货地址一行不够 需要换行
            if (waybillInfo.receiver_addr_cn.Length > 36)
            {
                B_Prn_Text_TrueType(95, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN121", waybillInfo.receiver_addr_cn.Substring(0, 18));
                B_Prn_Text_TrueType(95, 264, 30, "Arial", 1, 400, 0, 0, 0, "BN122", waybillInfo.receiver_addr_cn.Substring(18, 18));
                B_Prn_Text_TrueType(95, 296, 30, "Arial", 1, 400, 0, 0, 0, "BN131", waybillInfo.receiver_addr_cn.Substring(36, waybillInfo.receiver_addr_cn.Length - 36));
            }
            else if (waybillInfo.receiver_addr_cn.Length > 18)
            {
                B_Prn_Text_TrueType(95, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN12", waybillInfo.receiver_addr_cn.Substring(0, 18));
                B_Prn_Text_TrueType(95, 264, 30, "Arial", 1, 400, 0, 0, 0, "BN13", waybillInfo.receiver_addr_cn.Substring(18, waybillInfo.receiver_addr_cn.Length - 18));
            }
            else
            {
                B_Prn_Text_TrueType(95, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN12", waybillInfo.receiver_addr_cn);
            }
            //收件公司一行也可能不够
            if (waybillInfo.receiver_nm_cn.Length > 18)
            {
                B_Prn_Text_TrueType(95, 328, 30, "Arial", 1, 400, 0, 0, 0, "BN141", waybillInfo.receiver_nm_cn.Substring(0, 18));//收件公司
                B_Prn_Text_TrueType(95, 360, 30, "Arial", 1, 400, 0, 0, 0, "BN142", waybillInfo.receiver_nm_cn.Substring(18, waybillInfo.receiver_nm_cn.Length - 18) + "   " + waybillInfo.receiver_contact_nm_cn);//收件公司+收件人
            }
            else
            {
                B_Prn_Text_TrueType(95, 328, 30, "Arial", 1, 400, 0, 0, 0, "BN14", waybillInfo.receiver_nm_cn);//收件公司
                B_Prn_Text_TrueType(95, 360, 30, "Arial", 1, 400, 0, 0, 0, "BN15", waybillInfo.receiver_contact_nm_cn);//收件人
            }
            B_Prn_Text_TrueType(95, 392, 30, "Arial", 1, 400, 0, 0, 0, "BN16", "TEL:" + waybillInfo.receiver_tel);//收件人电话


            //输出者
            B_Prn_Text_TrueType(95, 595, 35, "Arial", 1, 400, 0, 0, 0, "BN2", waybillInfo.sender_nm_en);//代理发件公司：agentSendCompany
            //下面的地址字符串长度会超过打印标签的宽度，所以需要进行判断，如果字符串长度超过标签纸宽度，打印在标签上的文字要进行换行.
            if (waybillInfo.sender_addr_en.Length > 45)
            {
                B_Prn_Text_TrueType(95, 638, 30, "Arial", 1, 400, 0, 0, 0, "BN211", waybillInfo.sender_addr_en.Substring(0, 45));//代理发件公司地址：agentSendCompanyAddress
                B_Prn_Text_TrueType(95, 663, 30, "Arial", 1, 400, 0, 0, 0, "BN212", waybillInfo.sender_addr_en.Substring(45, waybillInfo.sender_addr_en.Length - 45));//代理发件公司地址：agentSendCompanyAddress
            }
            else
            {
                B_Prn_Text_TrueType(95, 638, 30, "Arial", 1, 400, 0, 0, 0, "BN21", waybillInfo.sender_addr_en);//代理发件公司地址：agentSendCompanyAddress
            }

            //运送会社
            B_Prn_Text_TrueType(95, 740, 30, "Arial", 1, 400, 0, 0, 0, "BS1", "エムオーエアロジスティックス（株式会社）");//代理运输公司和营业所
            B_Prn_Text_TrueType(95, 775, 30, "Arial", 1, 400, 0, 0, 0, "BS2", "TEL:" + "81-476356118" + "       " + "FAX:" + "81-476356194");//营业所电话和传真

            if (!waybillInfo.items[0].item_nm_en.IsNullOrEmpty())
            {
                if (waybillInfo.items[0].item_nm_en.Length > 75)
                {
                    B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", waybillInfo.items[0].item_nm_en.Substring(0, 25));//货物名称
                    B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", waybillInfo.items[0].item_nm_en.Substring(25, 25));//货物名称
                    B_Prn_Text_TrueType(495, 862, 24, "Arial", 1, 400, 0, 0, 0, "BN33", waybillInfo.items[0].item_nm_en.Substring(50, 25));//货物名称
                    B_Prn_Text_TrueType(495, 882, 24, "Arial", 1, 400, 0, 0, 0, "BN34", waybillInfo.items[0].item_nm_en.Substring(75, waybillInfo.items[0].item_nm_en.Length - 75));//货物名称
                }
                else
                {
                    if (waybillInfo.items[0].item_nm_en.Length > 50)//长度大于60分三行
                    {
                        B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", waybillInfo.items[0].item_nm_en.Substring(0, 25));//货物名称
                        B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", waybillInfo.items[0].item_nm_en.Substring(25, 25));//货物名称
                        B_Prn_Text_TrueType(495, 862, 24, "Arial", 1, 400, 0, 0, 0, "BN33", waybillInfo.items[0].item_nm_en.Substring(50, waybillInfo.items[0].item_nm_en.Length - 50));//货物名称
                    }
                    else
                    {
                        if (waybillInfo.items[0].item_nm_en.Length > 25)//长度大于30小于60分两行
                        {
                            B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", waybillInfo.items[0].item_nm_en.Substring(0, 25));//货物名称
                            B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", waybillInfo.items[0].item_nm_en.Substring(25, waybillInfo.items[0].item_nm_en.Length - 25));//货物名称
                        }
                        else
                        { //长度小于18一行显示
                            B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN3", waybillInfo.items[0].item_nm_en);//货物名称
                        }
                    }
                }
            }
            B_Prn_Text_TrueType(495, 904, 20, "Arial", 1, 400, 0, 0, 0, "BN4", waybillInfo.packages[packIndex].package_weight);//货物重量
            B_Prn_Text_TrueType(495, 924, 20, "Arial", 1, 400, 0, 0, 0, "BN5", waybillInfo.packages[packIndex].package_volume_weight + "サイズ ");//货物体积
            B_Prn_Text_TrueType(495, 947, 30, "Arial", 1, 400, 0, 0, 0, "BN6", waybillInfo.sx_no + "");//中国运单号
            B_Prn_Text_TrueType(170, 995, 30, "Arial", 1, 400, 0, 0, 0, "BN8", "SHENZHEN SUK INTERNATIONAL FREIGHT CO LTD");
            B_Prn_Text_TrueType(95, 710, 25, "Arial", 1, 400, 0, 0, 0, "BS0", "〒5490021　千葉県成田市古込154－4");

            //print barcode
            //codabar（nw-7）次打印机的接收参数必须是ABCD....ABCD格式的，也就是说开头和结尾必须是大写的
            //参数必须改成2：4 不然扫码枪扫不出内容
            B_Prn_Barcode(610, 250, 0, "K", 2, 4, 100, 'N', waybillInfo.ArrivalShopNo);//从上倒下第一个条形码
            //if(waybillInfo.total_package_cnt.Equals("1"))
            if (waybillInfo.StoreHouseShort.Equals("成田店"))
            {
                if (packIndex == 0)
                {
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "A" + waybillInfo.jp_express_no + "A"); //第二个条形码
                    B_Prn_Barcode(76, 890, 0, "K", 2, 4, 50, 'B', "A" + waybillInfo.jp_express_no + "A"); //第三个条形码
                }
                else
                {
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "D" + waybillInfo.jp_express_no + "D"); //第二个条形码
                    B_Prn_Barcode(76, 890, 0, "K", 2, 4, 50, 'B', "D" + waybillInfo.jp_express_no + "D");//第三个条形码
                }
            }
            else
            {
                if (waybillInfo.total_package_cnt.Equals("1"))
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "A" + waybillInfo.jp_express_no + "A"); //第二个条形码
                else
                    B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', "D" + waybillInfo.jp_express_no + "D"); //第二个条形码
                B_Prn_Text_TrueType(95, 710, 25, "Arial", 1, 400, 0, 0, 0, "BS0", "〒5490021　大阪府泉南市泉州空港南１第二国際貨物代理店ビル");
                B_Prn_Text_TrueType(40, 895, 25, "Arial", 1, 400, 0, 0, 0, "BS6", "□飛脚宅配便　□飛脚ラージサイズ宅配便");
                B_Prn_Text_TrueType(40, 930, 25, "Arial", 1, 400, 0, 0, 0, "BS7", "□飛脚航空便　□飛脚ラージサイズ航空便");
            }
            // output.
            B_Print_Out(1);//参数是打印份数
            // close port.
            B_ClosePrn();
            System.Threading.Thread.Sleep(500);
        }
        #endregion
        #region 条码

        public static void BarcodePrint(string leftNum, string rightNum)
        {
            PrinterInitialize();
            B_Prn_Barcode(80, 20, 0, "1", 2, 4, 90, 'B', leftNum);
            B_Prn_Barcode(496, 20, 0, "1", 2, 4, 90, 'B', rightNum);
            B_Print_Out(1);
            B_ClosePrn();
        }
        #endregion
    }
}