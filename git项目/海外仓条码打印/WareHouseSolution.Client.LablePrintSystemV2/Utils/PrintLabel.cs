using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using CCWin.SkinControl;
using WareHouseSolution.Client.LablePrintSystem.Models;

namespace WareHouseSolution.Client.LablePrintSystem.Utils
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

        #region 条码

        public static void ProductRegNoBarcodePrint(string leftNum, string rightNum ,string leftComCode,string rightComCode)
        {
            PrinterInitialize();
            B_Prn_Text_TrueType(60, 5, 30, "Arial", 1, 600, 0, 0, 0, "BN19", leftComCode);
            B_Prn_Text_TrueType(476, 5, 30, "Arial", 1, 600, 0, 0, 0, "BN20", rightComCode);
            B_Prn_Barcode(60, 30, 0, "1", 2, 4, 80, 'B', leftNum);
            B_Prn_Barcode(476, 30, 0, "1", 2, 4, 80, 'B', rightNum);
            B_Print_Out(1);
            B_ClosePrn();
            System.Threading.Thread.Sleep(800);
        }
        #endregion
    }
}