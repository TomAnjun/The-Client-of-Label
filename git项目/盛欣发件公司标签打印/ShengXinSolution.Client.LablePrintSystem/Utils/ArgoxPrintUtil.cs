using ShengXinSolution.Client.LablePrintSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ShengXinSolution.Client.LablePrintSystem.Utils
{
    class ArgoxPrintUtil
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
        private static void startPrinterSetting()
        {
            //Test code start
            // open port.
            int nLen, ret, sw;
            byte[] pbuf = new byte[128];
            string strmsg;
            IntPtr ver;
            System.Text.Encoding encAscII = System.Text.Encoding.ASCII;
            System.Text.Encoding encUnicode = System.Text.Encoding.Unicode;

            // dll version.
            ver = B_Get_DLL_Version(0);

            // search port.
            nLen = B_GetUSBBufferLen() + 1;
            strmsg = "DLL ";
            strmsg += Marshal.PtrToStringAnsi(ver);
            strmsg += "\r\n";
            if (nLen > 1)
            {
                byte[] buf1, buf2;
                int len1 = 128, len2 = 128;
                buf1 = new byte[len1];
                buf2 = new byte[len2];
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
                    strmsg += "打开USB端口失败!";
                }
                else
                {
                    strmsg += "打开USB:\r\n设备名称: ";
                    strmsg += encAscII.GetString(buf1, 0, len1);
                    strmsg += "\r\n设备路径: ";
                    strmsg += encAscII.GetString(buf2, 0, len2);
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
                strmsg += "打开 ";
                strmsg += szSaveFile;
                if (0 != ret)
                {
                    strmsg += " 文件失败!";
                }
                else
                {
                    strmsg += " 文件成功!";
                }
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

        #region 海关标签打印
        public static void CustomsPrint(SagawaLabel p)
        {
            startPrinterSetting();

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
            B_Prn_Text_TrueType(328, 68, 35, "Arial", 1, 400, 0, 0, 0, "TA", "SINOHF   AWB   :   " + p.customsNo);
            //第二部分
            B_Prn_Text_TrueType(56, 160, 35, "Arial", 1, 400, 0, 0, 0, "TC", "DELIVER TO");
            B_Prn_Barcode(480, 128, 0, "3", 4, 8, 72, 'N', p.destination);
            B_Prn_Text_TrueType(504, 208, 95, "Arial", 1, 400, 0, 0, 0, "TD", p.destination.Substring(0,1)+" "+p.destination.Substring(1,1)+" "+p.destination.Substring(2,1));
            B_Prn_Text_TrueType(56, 200, 30, "Arial", 1, 400, 0, 0, 0, "TE", p.receiverNameEn);
            if (p.receiverAddrEn.Length > 51)
            {
                B_Prn_Text_TrueType(56, 232, 30, "Arial", 1, 400, 0, 0, 0, "TF", p.receiverAddrEn.Substring(0,17));
                B_Prn_Text_TrueType(56, 264, 30, "Arial", 1, 400, 0, 0, 0, "TG", p.receiverAddrEn.Substring(17, 17));
                B_Prn_Text_TrueType(56, 296, 30, "Arial", 1, 400, 0, 0, 0, "TH", p.receiverAddrEn.Substring(34, 17));
                if(p.receiverAddrEn.Length > 68)
                    B_Prn_Text_TrueType(56, 328, 30, "Arial", 1, 400, 0, 0, 0, "TI", p.receiverAddrEn.Substring(51, 17));
                else
                    B_Prn_Text_TrueType(56, 328, 30, "Arial", 1, 400, 0, 0, 0, "TI", p.receiverAddrEn.Substring(51, p.receiverAddrEn.Length-51));
                B_Prn_Text_TrueType(56, 360, 30, "Arial", 1, 400, 0, 0, 0, "TJ", "Tel : "+p.AttnTel);
                B_Prn_Text_TrueType(56, 392, 30, "Arial", 1, 400, 0, 0, 0, "TK", "PostCode : "+ p.JpPostcode);
            }
            else if (p.receiverAddrEn.Length > 34)
            {
                B_Prn_Text_TrueType(56, 232, 30, "Arial", 1, 400, 0, 0, 0, "TF", p.receiverAddrEn.Substring(0, 17));
                B_Prn_Text_TrueType(56, 264, 30, "Arial", 1, 400, 0, 0, 0, "TG", p.receiverAddrEn.Substring(17, 17));
                B_Prn_Text_TrueType(56, 296, 30, "Arial", 1, 400, 0, 0, 0, "TH", p.receiverAddrEn.Substring(34, p.receiverAddrEn.Length - 34));
                B_Prn_Text_TrueType(56, 328, 30, "Arial", 1, 400, 0, 0, 0, "TJ", "Tel : " + p.AttnTel);
                B_Prn_Text_TrueType(56, 360, 30, "Arial", 1, 400, 0, 0, 0, "TK", "PostCode : " + p.JpPostcode);
            }
            else if (p.receiverAddrEn.Length > 17)
            {
                B_Prn_Text_TrueType(56, 232, 30, "Arial", 1, 400, 0, 0, 0, "TF", p.receiverAddrEn.Substring(0, 17));
                B_Prn_Text_TrueType(56, 264, 30, "Arial", 1, 400, 0, 0, 0, "TG", p.receiverAddrEn.Substring(17, p.receiverAddrEn.Length - 17));
                B_Prn_Text_TrueType(56, 296, 30, "Arial", 1, 400, 0, 0, 0, "TJ", "Tel : " + p.AttnTel);
                B_Prn_Text_TrueType(56, 328, 30, "Arial", 1, 400, 0, 0, 0, "TK", "PostCode : " + p.JpPostcode);
            }
            else
            {
                B_Prn_Text_TrueType(56, 232, 30, "Arial", 1, 400, 0, 0, 0, "TG", p.receiverAddrEn);
                B_Prn_Text_TrueType(56, 264, 30, "Arial", 1, 400, 0, 0, 0, "TJ", "Tel : " + p.AttnTel);
                B_Prn_Text_TrueType(56, 296, 30, "Arial", 1, 400, 0, 0, 0, "TK", "PostCode : " + p.JpPostcode);
            }
            //E-Commerce
            if(p.eCommerce == "Y")
                B_Prn_Text_TrueType(504, 344, 40, "Arial", 1, 400, 0, 0, 0, "TL", "E-Commerce");
            //第三部分
            //货物详情
            B_Prn_Text_TrueType(56, 440, 30, "Arial", 1, 400, 0, 0, 0, "TM", "DESCRIPTION  OF  CONTENTS :");
            if(p.PackName.Length > 30)
                B_Prn_Text_TrueType(56, 472, 30, "Arial", 1, 400, 0, 0, 0, "TN", p.PackName.Substring(0, 30));
            else
                B_Prn_Text_TrueType(56, 472, 30, "Arial", 1, 400, 0, 0, 0, "TN", p.PackName);
            B_Prn_Text_TrueType(56, 504, 30, "Arial", 1, 400, 0, 0, 0, "TO", "QUANTITY :      " + p.TotalPackNum +"  PCS");
            double jpValues = Convert.ToDouble(p.totalPrice);
            double usValues = jpValues*0.00415;
            B_Prn_Text_TrueType(56, 536, 30, "Arial", 1, 400, 0, 0, 0, "TP", "VALUE :    " + "  USD  " + usValues.ToString("f1"));
            B_Prn_Text_TrueType(616, 472, 30, "Arial", 1, 400, 0, 0, 0, "TQ", p.PackWeight);
            B_Prn_Text_TrueType(616, 536, 30, "Arial", 1, 400, 0, 0, 0, "TR", p.flightDate);
            //第四部分
            B_Prn_Barcode(88, 592, 0, "3", 4, 6, 152, 'N', p.customsNo);
            //B_Prn_Barcode(88, 592, 0, "1", 6, 10, 152, 'N', p.customsNo);
            B_Prn_Text_TrueType(104, 768, 35, "Arial", 1, 400, 0, 0, 0, "TS", "SINOHF   AWB   :   " + p.customsNo);
            //第五部分
            B_Prn_Text_TrueType(56, 832, 30, "Arial", 1, 400, 0, 0, 0, "TT", "SENDER");
            B_Prn_Text_TrueType(56, 864, 20, "Arial", 1, 400, 0, 0, 0, "TU", p.AgentSendCompany);
            if (p.AgentSendCompanyAdd.Length > 51)
            {
                B_Prn_Text_TrueType(56, 880, 20, "Arial", 1, 400, 0, 0, 0, "TV", p.AgentSendCompanyAdd.Substring(0, 17));
                B_Prn_Text_TrueType(56, 896, 20, "Arial", 1, 400, 0, 0, 0, "TW", p.AgentSendCompanyAdd.Substring(17, 17));
                B_Prn_Text_TrueType(56, 912, 20, "Arial", 1, 400, 0, 0, 0, "TX", p.AgentSendCompanyAdd.Substring(34, 17));
                if (p.AgentSendCompanyAdd.Length > 68)
                    B_Prn_Text_TrueType(56, 926, 20, "Arial", 1, 400, 0, 0, 0, "TY", p.AgentSendCompanyAdd.Substring(51, 17));
                else
                    B_Prn_Text_TrueType(56, 926, 20, "Arial", 1, 400, 0, 0, 0, "TY", p.AgentSendCompanyAdd.Substring(51, p.AgentSendCompanyAdd.Length - 51));
                B_Prn_Text_TrueType(56, 944, 20, "Arial", 1, 400, 0, 0, 0, "TZ", "Tel  " + p.senderTel);
            }
            else if (p.AgentSendCompanyAdd.Length > 34)
            {
                B_Prn_Text_TrueType(56, 880, 20, "Arial", 1, 400, 0, 0, 0, "TV", p.AgentSendCompanyAdd.Substring(0, 17));
                B_Prn_Text_TrueType(56, 896, 20, "Arial", 1, 400, 0, 0, 0, "TW", p.AgentSendCompanyAdd.Substring(17, 17));
                B_Prn_Text_TrueType(56, 912, 20, "Arial", 1, 400, 0, 0, 0, "TX", p.AgentSendCompanyAdd.Substring(34, p.AgentSendCompanyAdd.Length - 34));
                B_Prn_Text_TrueType(56, 926, 20, "Arial", 1, 400, 0, 0, 0, "TY", "Tel  " + p.senderTel);
            }
            else if (p.AgentSendCompanyAdd.Length > 17)
            {
                B_Prn_Text_TrueType(56, 880, 20, "Arial", 1, 400, 0, 0, 0, "TV", p.AgentSendCompanyAdd.Substring(0, 17));
                B_Prn_Text_TrueType(56, 896, 20, "Arial", 1, 400, 0, 0, 0, "TW", p.AgentSendCompanyAdd.Substring(17, p.AgentSendCompanyAdd.Length - 17));
                B_Prn_Text_TrueType(56, 912, 20, "Arial", 1, 400, 0, 0, 0, "TX", "Tel  " + p.senderTel);
            }
            else
            {
                B_Prn_Text_TrueType(56, 880, 20, "Arial", 1, 400, 0, 0, 0, "TV", p.AgentSendCompanyAdd);
                B_Prn_Text_TrueType(56, 896, 20, "Arial", 1, 400, 0, 0, 0, "TW", "Tel  " + p.senderTel);
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

        #region 佐川急便打印
        public static void SagawaLablePrint(SagawaLabel p)
        {
            startPrinterSetting();

            if (p.emptyStyle != "Y")
            {
                B_Draw_Box(20, 20, 10, 840, 1040);
                //横线

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
            }

            //判断大数字是否超过3个，如果超过三个缩小字体，位置前移
            if (p.BigNum.Length > 3)
            {
                B_Prn_Text_TrueType(40, 30, 170, "Arial", 1, 400, 0, 0, 0, "BA", p.BigNum);//大数字
                B_Prn_Text_TrueType(400, 96, 90, "Arial", 1, 400, 0, 0, 0, "BB", p.SmallNum);//小数字
            }
            else
            {
                //如果没有超过3个还是按照之前的样式打印
                B_Prn_Text_TrueType(60, 30, 170, "Arial", 1, 400, 0, 0, 0, "BA", p.BigNum);//大数字
                B_Prn_Text_TrueType(400, 96, 90, "Arial", 1, 400, 0, 0, 0, "BB", p.SmallNum);//小数字
            }

            B_Prn_Text_TrueType(610, 37, 22, "Arial", 1, 400, 0, 0, 0, "BG", "発送日:" + p.Date);//发送日期
            B_Prn_Text_TrueType(665, 80, 45, "Arial", 1, 400, 0, 0, 0, "BH", "個   数");//save in printer.
            B_Prn_Text_TrueType(720, 135, 35, "Arial", 1, 400, 0, 0, 0, "BI1", p.NowPackNum);//当前包裹号
            B_Prn_Text_TrueType(750, 145, 35, "Arial", 1, 400, 0, 0, 0, "BI2", "/");//
            B_Prn_Text_TrueType(760, 155, 35, "Arial", 1, 400, 0, 0, 0, "BI3", p.TotalPackNum);//总包裹数
            //B_Prn_Text_TrueType(615, 175, 18, "Arial", 1, 400, 0, 0, 0, "BJ", "着店バーコード");//save in printer.

            B_Prn_Text_TrueType(145, 425, 45, "Arial", 1, 400, 0, 0, 0, "BL", p.StorehouseName);//集货店名称
            B_Prn_Text_TrueType(80, 480, 30, "Arial", 1, 400, 0, 0, 0, "BM1", "お問和せTEL:" + p.StorehouseTel);//集货店电话
            B_Prn_Text_TrueType(80, 510, 30, "Arial", 1, 400, 0, 0, 0, "BM2", "お問和せFAX:" + p.StorehouseFax);//集货店传真
            B_Prn_Text_TrueType(80, 540, 30, "Arial", 1, 400, 0, 0, 0, "BM3", "出荷場コード:" + p.DeliveryPlace);//出荷场

            //打印需要输出文字
            //B_Prn_Text_TrueType(75, 200, 30, "Arial", 1, 400, 0, 0, 0, "BN1", "〒 " + p.JpPostcode);//日本邮编
            //B_Prn_Text_TrueType(75, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN12", p.JpAddress);//日本地址 这个需要换行，如果一行超过20个字符换到日本番号那行
            //B_Prn_Text_TrueType(75, 264, 30, "Arial", 1, 400, 0, 0, 0, "BN13", p.JpNum);//日本番号
            //B_Prn_Text_TrueType(75, 296, 30, "Arial", 1, 400, 0, 0, 0, "BN14", p.AcceptCompany);//收件公司
            //B_Prn_Text_TrueType(75, 328, 30, "Arial", 1, 400, 0, 0, 0, "BN15", p.Attn);//收件人
            //B_Prn_Text_TrueType(75, 360, 30, "Arial", 1, 400, 0, 0, 0, "BN16", "TEL:" + p.AttnTel);//收件人电话

            //打印需要输出文字
            B_Prn_Text_TrueType(95, 200, 30, "Arial", 1, 400, 0, 0, 0, "BN1", "〒 " + p.JpPostcode);//日本邮编
            //日本收货地址一行不够 需要换行
            if (p.JpAddress.Length > 18)
            {
                //对p.JpAddress进行截取
                string strUp = p.JpAddress.Substring(0, 18);
                string strDown = p.JpAddress.Substring(18, p.JpAddress.Length-18);
                B_Prn_Text_TrueType(95, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN121", strUp);//日本地址 这个需要换行，如果一行超过20个字符换到日本番号那行
                B_Prn_Text_TrueType(95, 264, 30, "Arial", 1, 400, 0, 0, 0, "BN122", strDown);//日本地址 这个需要换行，如果一行超过20个字符换到日本番号那行
                B_Prn_Text_TrueType(95, 296, 30, "Arial", 1, 400, 0, 0, 0, "BN131", p.JpNum);//日本番号
            }
            else
            {
                B_Prn_Text_TrueType(95, 232, 30, "Arial", 1, 400, 0, 0, 0, "BN12", p.JpAddress);//日本地址 这个需要换行，如果一行超过20个字符换到日本番号那行
                B_Prn_Text_TrueType(95, 264, 30, "Arial", 1, 400, 0, 0, 0, "BN13", p.JpNum);//日本番号
            }
            //收件公司一行也可能不够
            if (p.AcceptCompany.Length > 18)
            {
                string strUp = p.AcceptCompany.Substring(0, 18);
                string strDown = p.AcceptCompany.Substring(18, p.AcceptCompany.Length-18);
                B_Prn_Text_TrueType(95, 328, 30, "Arial", 1, 400, 0, 0, 0, "BN141", strUp);//收件公司
                B_Prn_Text_TrueType(95, 360, 30, "Arial", 1, 400, 0, 0, 0, "BN142", strDown + "  " + p.Attn);//收件公司+收件人
            }
            else
            {
                B_Prn_Text_TrueType(95, 328, 30, "Arial", 1, 400, 0, 0, 0, "BN14", p.AcceptCompany);//收件公司
                B_Prn_Text_TrueType(95, 360, 30, "Arial", 1, 400, 0, 0, 0, "BN15", p.Attn);//收件人
            }
            B_Prn_Text_TrueType(95, 392, 30, "Arial", 1, 400, 0, 0, 0, "BN16", "TEL:" + p.AttnTel);//收件人电话


            //输出者
            B_Prn_Text_TrueType(95, 585, 35, "Arial", 1, 400, 0, 0, 0, "BN2", p.AgentSendCompany);//代理发件公司：agentSendCompany
            //下面的地址字符串长度会超过打印标签的宽度，所以需要进行判断，如果字符串长度超过标签纸宽度，打印在标签上的文字要进行换行.
            if (p.AgentSendCompanyAdd.Length > 45)
            {
                //对p.AgentSendCompanyAdd进行截取
                string strUp = p.AgentSendCompanyAdd.Substring(0, 45);
                string strDown = p.AgentSendCompanyAdd.Substring(45, p.AgentSendCompanyAdd.Length-45);
                B_Prn_Text_TrueType(95, 642, 30, "Arial", 1, 400, 0, 0, 0, "BN211", strUp);//代理发件公司地址：agentSendCompanyAddress
                B_Prn_Text_TrueType(95, 667, 30, "Arial", 1, 400, 0, 0, 0, "BN212", strDown);//代理发件公司地址：agentSendCompanyAddress
            }
            else
            {
                B_Prn_Text_TrueType(95, 642, 30, "Arial", 1, 400, 0, 0, 0, "BN21", p.AgentSendCompanyAdd);//代理发件公司地址：agentSendCompanyAddress
            }
            //B_Prn_Text_TrueType(75, 625, 35, "Arial", 1, 400, 0, 0, 0, "BN21", p.AgentSendCompanyAdd);//代理发件公司地址：agentSendCompanyAddress

            //运送会社
            B_Prn_Text_TrueType(95, 715, 30, "Arial", 1, 400, 0, 0, 0, "BS1", p.AgentTransCompany + "    " + p.AgentTransPlace);//代理运输公司和营业所
           // B_Prn_Text_TrueType(105, 760, 35, "黑体", 1, 400, 0, 0, 0, "BS2", "TEL:" + p.PlaceTel + "   " + "FAX:" + p.PlaceFax);//营业所电话和传真

            //B_Prn_Text_TrueType(495, 822, 21, "Arial", 1, 400, 0, 0, 0, "BN3", p.PackName + "");//货物名称,这鬼东西也需要换行.....
            if (p.PackName.Length > 75)
            {
                //分四行
                string strUp = p.PackName.Substring(0, 25);
                string strMid = p.PackName.Substring(25, 25);
                string strDown = p.PackName.Substring(50, 25);
                string strBotton = p.PackName.Substring(75, p.PackName.Length-75);
                B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", strUp + "");//货物名称
                B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", strMid + "");//货物名称
                B_Prn_Text_TrueType(495, 862, 24, "Arial", 1, 400, 0, 0, 0, "BN33", strDown + "");//货物名称
                B_Prn_Text_TrueType(495, 882, 24, "Arial", 1, 400, 0, 0, 0, "BN34", strBotton + "");//货物名称

            }
            else
            {
                if (p.PackName.Length > 50)//长度大于60分三行
                {
                    string strUp = p.PackName.Substring(0, 25);
                    string strMid = p.PackName.Substring(25, 25);
                    string strDown = p.PackName.Substring(50, p.PackName.Length-50);
                    B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", strUp + "");//货物名称
                    B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", strMid + "");//货物名称
                    B_Prn_Text_TrueType(495, 862, 24, "Arial", 1, 400, 0, 0, 0, "BN33", strDown + "");//货物名称

                }
                else
                {
                    if (p.PackName.Length > 25)//长度大于30小于60分两行
                    {
                        //p.PackName.Length
                        string strUp = p.PackName.Substring(0, 25);
                        string strDown = p.PackName.Substring(25, p.PackName.Length-25);
                        B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN31", strUp + "");//货物名称
                        B_Prn_Text_TrueType(495, 842, 24, "Arial", 1, 400, 0, 0, 0, "BN32", strDown + "");//货物名称

                    }
                    else
                    { //长度小于18一行显示
                        B_Prn_Text_TrueType(495, 822, 24, "Arial", 1, 400, 0, 0, 0, "BN3", p.PackName + "");//货物名称
                    }

                }
            }


            B_Prn_Text_TrueType(495, 904, 20, "Arial", 1, 400, 0, 0, 0, "BN4", p.PackWeight);//货物重量
            B_Prn_Text_TrueType(495, 924, 20, "Arial", 1, 400, 0, 0, 0, "BN5", p.PackVolume + "サイズ ");//货物体积
            B_Prn_Text_TrueType(495, 947, 30, "Arial", 1, 400, 0, 0, 0, "BN6", p.CnPackNum + "");//中国运单号
            B_Prn_Text_TrueType(130, 1000, 36, "Arial", 1, 400, 0, 0, 0, "BN7", "SDM");
            B_Prn_Text_TrueType(220, 1005, 30, "Arial", 1, 400, 0, 0, 0, "BN8", "SHANDONG SHINESEN INT'L TRANSPORT CO.,LTD");

            //print barcode
            //codabar（nw-7）次打印机的接收参数必须是ABCD....ABCD格式的，也就是说开头和结尾必须是大写的
            //参数必须改成2：4 不然扫码枪扫不出内容
            B_Prn_Barcode(610, 250, 0, "K", 2, 4, 100, 'N', p.Barcode01);//从上倒下第一个条形码
            B_Prn_Barcode(500, 440, 0, "K", 2, 4, 100, 'B', p.JpPackNum);//第二个条形码
            B_Prn_Barcode(76, 890, 0, "K", 2, 4, 50, 'B', p.JpPackNum);//第三个条形码

            // output.
            B_Print_Out(1);//参数是打印份数

            // close port.
            B_ClosePrn();
            System.Threading.Thread.Sleep(500);
        }
        #endregion

        #region 佐川飞脚贴标打印
        public static void SagawaHikiyakuPrint(SagawaLabel p)
        {
            startPrinterSetting();

            B_Draw_Box(185, 30, 4, 715, 1040);

            var p0 = "お届け先";
            var p1 = "东京都品川区";
            var p2 = "滕岛1-1-1";
            var p3 = "S R C 2 F";
            var p4 = "佐川ュンヒュ-タ-システム";
            var p5 = "北沢                                                          様";
            var p6 = "TEL  03-3768-8713";

            var barCode1 = "7016";
            var barCode2 = "840024981176";

            //第一部分
            var sizeOfOne = p0.Length - 1;
            var temp = 0;
            var tempId = "";
            for (var i = 0; i < p0.Length; i++)
            {
                tempId = "BN" + "A" + i.ToString();
                B_Prn_Text_TrueType(644 - 50 * temp, 50, 30, "Arial", 2, 400, 0, 0, 0, tempId, p0[i].ToString());
                temp++;
            }
            tempId = "BN" + "B";
            B_Prn_Text_TrueType(604, 100, 30, "Arial", 2, 400, 0, 0, 0, tempId, p1.ToString());

            tempId = "BN" + "C";
            B_Prn_Text_TrueType(574, 100, 30, "Arial", 2, 400, 0, 0, 0, tempId, p2.ToString());

            for (var i = 0; i < p3.Length; i++)
            {
                tempId = "BN" + "D" + i.ToString();
                B_Prn_Text_TrueType(544, 100 + 16 * i, 30, "Arial", 2, 400, 0, 0, 0, tempId, p3[i].ToString());
            }

            tempId = "BN" + "E";
            B_Prn_Text_TrueType(514, 100, 30, "Arial", 2, 400, 0, 0, 0, tempId, p4.ToString());

            tempId = "BN" + "F";
            B_Prn_Text_TrueType(484, 100, 30, "Arial", 2, 400, 0, 0, 0, tempId, p5.ToString());

            tempId = "BN" + "G";
            B_Prn_Text_TrueType(454, 100, 30, "Arial", 2, 400, 0, 0, 0, tempId, p6.ToString());
            //第二部分
            B_Prn_Barcode(604, 720, 1, "3", 3, 8, 145, 'N', barCode1);
            var p8 = "7-016";
            var BNbarCode1 = "";
            BNbarCode1 = "BN" + "Q";
            B_Prn_Text_TrueType(644, 720, 55, "Arial", 2, 400, 0, 0, 0, BNbarCode1, p8.ToString());
            //第三部分
            B_Prn_Barcode(420, 48, 1, "3", 3, 6, 145, 'N', barCode2);
            var p7 = "メ-ル便No. " + barCode2;
            var BNbarCode2 = "";
            BNbarCode2 = "BN" + "t";
            B_Prn_Text_TrueType(220, 134, 32, "Arial", 2, 400, 0, 0, 0, BNbarCode2, p7.ToString());

            //第四部分
            var f1 = "お問合せ店";
            var f2 = "佐川急便(株)";
            var f3 = "渋谷店";
            var f4 = "TEL  03-5764-3101";
            //var f5 = "飞脚便签";
            var f6 = "1この荷物は佐川急便が配逵しました2この荷物は佐川急便が配逵しました3この荷物は佐川急便が配逵しました4この荷物は佐川急便が配逵しました5この荷物は佐川急便が配逵しました";

            tempId = "BN" + "f1";
            B_Prn_Text_TrueType(420, 688, 30, "Arial", 2, 400, 0, 0, 0, tempId, f1.ToString());

            tempId = "BN" + "f2";
            B_Prn_Text_TrueType(390, 688, 30, "Arial", 2, 400, 0, 0, 0, tempId, f2.ToString());

            tempId = "BN" + "f3";
            B_Prn_Text_TrueType(360, 688, 30, "Arial", 2, 400, 0, 0, 0, tempId, f3.ToString());

            tempId = "BN" + "f4";
            B_Prn_Text_TrueType(330, 688, 30, "Arial", 2, 400, 0, 0, 0, tempId, f4.ToString());

            tempId = "BN" + "f6";
            if (f6.Length <= 20)
            {
                B_Prn_Text_TrueType(225, 584, 24, "Arial", 2, 400, 0, 0, 0, tempId, f6.ToString());
            }
            else if (f6.Length > 20 && f6.Length <= 40)
            {
                B_Prn_Text_TrueType(225, 584, 24, "Arial", 2, 400, 0, 0, 0, tempId, f6.Substring(0, 20));
                B_Prn_Text_TrueType(205, 584, 24, "Arial", 2, 400, 0, 0, 0, tempId + "1", f6.Substring(20, 20));
            }
            else
            {
                B_Prn_Text_TrueType(225, 584, 24, "Arial", 2, 400, 0, 0, 0, tempId, f6.Substring(0, 20));
                B_Prn_Text_TrueType(205, 584, 24, "Arial", 2, 400, 0, 0, 0, tempId + "1", f6.Substring(20, 20));
                B_Prn_Text_TrueType(185, 584, 24, "Arial", 2, 400, 0, 0, 0, tempId + "2", f6.Substring(40, 20));
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

        #region 日本邮政贴标打印
        public static void JapanEmsPrint(SagawaLabel p)
        {
            // sample setting.
            
            //print text, true type text.
            //B_Prn_Text(30, 40, 0, 2, 1, 1, 'N', "PPLB Lib Example");
            //B_Prn_Text_TrueType(30, 100, 30, "Arial", 1, 400, 0, 0, 0, "AA", "TrueType Font");//save in printer.
            //B_Prn_Text_TrueType_W(30, 160, 20, 20, "Times New Roman", 1, 400, 0, 0, 0, "AB", "TT_W: 多字元測試");
            //B_Prn_Text_TrueType_Uni(30, 220, 30, "Times New Roman", 1, 400, 0, 0, 0, "AC", Encoding.Unicode.GetBytes("TT_Uni: 多字元測試"), 1);//UTF-16

            startPrinterSetting();
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
            B_Prn_Text_TrueType(20, 50, 70, "Arial", 1, 400, 0, 0, 0, "AB", p.BigNum+p.SmallNum);//数字
            B_Prn_Text_TrueType(730, 20, 30, "Arial", 1, 400, 0, 0, 0, "AC", "配達証");//配连证

            B_Prn_Text_TrueType(75, 125, 30, "Arial", 1, 400, 0, 0, 0, "BA", "〒"+p.JpPostcode);
            B_Prn_Text_TrueType(250, 125, 30, "Arial", 1, 400, 0, 0, 0, "BB", "TEL："+p.AttnTel);
            //B_Prn_Text_TrueType(75, 150, 30, "Arial", 1, 400, 0, 0, 0, "BC", p.JpAddress+p.JpNum);
            string receiverAdd = p.JpAddress + p.JpNum;
            if (receiverAdd.Length < 28)
            {
                B_Prn_Text_TrueType(75, 150, 30, "Arial", 1, 400, 0, 0, 0, "BC", receiverAdd);
            }
            else
            {
                B_Prn_Text_TrueType(75, 150, 30, "Arial", 1, 400, 0, 0, 0, "BC", receiverAdd.Substring(0, 28));
                B_Prn_Text_TrueType(75, 175, 30, "Arial", 1, 400, 0, 0, 0, "BC1", receiverAdd.Substring(28, receiverAdd.Length-28));
            }
            B_Prn_Text_TrueType(75, 200, 30, "Arial", 1, 400, 0, 0, 0, "BD", p.Attn);
            B_Prn_Text_TrueType(75, 230, 25, "Arial", 1, 400, 0, 0, 0, "BF", "EX TRADE");

            B_Prn_Text_TrueType(75, 260, 27, "Arial", 1, 400, 0, 0, 0, "CA", "〒"+p.senderZipcode);
            B_Prn_Text_TrueType(250, 260, 27, "Arial", 1, 400, 0, 0, 0, "CL", "TEL：" + p.senderTel);
            if (p.AgentSendCompanyAdd.Length >50)
            {
                B_Prn_Text_TrueType(75, 285, 27, "Arial", 1, 400, 0, 0, 0, "CB", p.AgentSendCompanyAdd.Substring(0,50));
            }
            else
                B_Prn_Text_TrueType(75, 285, 27, "Arial", 1, 400, 0, 0, 0, "CB",p.AgentSendCompanyAdd);
            B_Prn_Text_TrueType(75, 310, 27, "Arial", 1, 400, 0, 0, 0, "CC", p.AgentTransCompany);
            B_Prn_Text_TrueType(75, 335, 27, "Arial", 1, 400, 0, 0, 0, "CD", p.AgentTransPlace);
            B_Prn_Text_TrueType(75, 360, 27, "Arial", 1, 400, 0, 0, 0, "CE", "※返還は依頼主まで。返還前連絡は不要。");
            //B_Prn_Text_TrueType(650, 360, 25, "Arial", 1, 400, 0, 0, 0, "CF", "様");

            //B_Prn_Text_TrueType(130, 430, 30, "Arial", 1, 400, 0, 0, 0, "DA", p.PackName);
            if (p.PackName.Length < 40)
            {
                B_Prn_Text_TrueType(130, 430, 30, "Arial", 1, 400, 0, 0, 0, "DA", p.PackName);
            }
            else
            {
                B_Prn_Text_TrueType(130, 417, 30, "Arial", 1, 400, 0, 0, 0, "DA", p.PackName.Substring(0, 40));
                if(p.PackName.Length>80)
                    B_Prn_Text_TrueType(130, 442, 30, "Arial", 1, 400, 0, 0, 0, "DA1", p.PackName.Substring(40, 40));
                else
                    B_Prn_Text_TrueType(130, 442, 30, "Arial", 1, 400, 0, 0, 0, "DA1", p.PackName.Substring(40, p.PackName.Length-40));
            }
            B_Prn_Text_TrueType(320, 498, 30, "Arial", 1, 400, 0, 0, 0, "DC", p.jpNumNoLetter);
            B_Prn_Text_TrueType(22, 626, 30, "Arial", 1, 400, 0, 0, 0, "DD", "お問い合わせ番号："+p.jpNumNoLetter);
            B_Prn_Text_TrueType(690, 626, 30, "Arial", 1, 400, 0, 0, 0, "DE", "ちょう付用");


            B_Prn_Text_TrueType(75, 670, 30, "Arial", 1, 400, 0, 0, 0, "EA", "〒" + p.JpPostcode);
            B_Prn_Text_TrueType(250, 670, 30, "Arial", 1, 400, 0, 0, 0, "EB", "TEL：" + p.AttnTel);
            //B_Prn_Text_TrueType(75, 695, 25, "Arial", 1, 400, 0, 0, 0, "EC", p.JpAddress + p.JpNum);
            if (receiverAdd.Length < 28)
            {
                B_Prn_Text_TrueType(75, 695, 30, "Arial", 1, 400, 0, 0, 0, "EC", receiverAdd);
            }
            else
            {
                B_Prn_Text_TrueType(75, 695, 30, "Arial", 1, 400, 0, 0, 0, "EC", receiverAdd.Substring(0, 28));
                B_Prn_Text_TrueType(75, 720, 30, "Arial", 1, 400, 0, 0, 0, "EC1", receiverAdd.Substring(28, receiverAdd.Length-28));
            }
            B_Prn_Text_TrueType(75, 750, 30, "Arial", 1, 400, 0, 0, 0, "ED", p.Attn);
            B_Prn_Text_TrueType(75, 775, 25, "Arial", 1, 400, 0, 0, 0, "EF", "EX TRADE");

            B_Prn_Text_TrueType(75, 805, 27, "Arial", 1, 400, 0, 0, 0, "CA", "〒" + p.senderZipcode);
            B_Prn_Text_TrueType(250, 805, 27, "Arial", 1, 400, 0, 0, 0, "CL", "TEL：" + p.senderTel);
            if (p.AgentSendCompanyAdd.Length > 60)
            {
                B_Prn_Text_TrueType(75, 830, 27, "Arial", 1, 400, 0, 0, 0, "FB", p.AgentSendCompanyAdd.Substring(0,60));
            }
            else
                B_Prn_Text_TrueType(75, 830, 27, "Arial", 1, 400, 0, 0, 0, "FB", p.AgentSendCompanyAdd);
            B_Prn_Text_TrueType(75, 855, 27, "Arial", 1, 400, 0, 0, 0, "FC", p.AgentTransCompany);
            B_Prn_Text_TrueType(75, 880, 27, "Arial", 1, 400, 0, 0, 0, "FD", p.AgentTransPlace);
            B_Prn_Text_TrueType(75, 910, 27, "Arial", 1, 400, 0, 0, 0, "FE", "※返還は依頼主まで。返還前連絡は不要。");
            //B_Prn_Text_TrueType(780, 910, 27, "Arial", 1, 400, 0, 0, 0, "FF", "様");

            B_Prn_Text_TrueType(150, 970, 27, "Arial", 1, 400, 0, 0, 0, "GA", p.TotalPackNum+"pack  "+p.PackWeight);
            B_Prn_Text_TrueType(20, 1022, 25, "Arial", 1, 400, 0, 0, 0, "GB", "日本郵便株式会社");


            //draw codabar
            B_Prn_Barcode(400, 40, 0, "1", 2, 4, 70, 'N', p.Barcode01);//从上倒下第一个条形码
            B_Prn_Barcode(200, 545, 0, "3", 2, 6, 70, 'N', p.jpNumNoLetter);//从上倒下第一个条形码

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

        public static void JapanEmsSmallPrint(SagawaLabel p)
        {
             startPrinterSetting();
            //var i = 0;
            var p2 = "料金後納";

            B_Draw_Line('E', 30, 348, 160, 2);//横线
            B_Draw_Line('E', 30, 398, 160, 2);//横线
            //B_Draw_Line('E', 30, 440, 160, 2);//横线

            B_Draw_Line('O', 30, 348, 2, 112);//竖线
            B_Draw_Line('O', 190, 348, 2, 112);//竖线



            B_Prn_Text_TrueType(45, 403, 35, "Arial", 1, 300, 0, 0, 0, "BN1", p2);

            IntPtr himage = LoadImage(IntPtr.Zero, @"Resources\jpEmsSmallBmp.bmp", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
            B_Get_Graphic_ColorBMP_HBitmap(30, 440, 162, 80, 0, "BN2", himage);//100 angle.
            if (IntPtr.Zero != himage)
                DeleteObject(himage);

            B_Prn_Barcode(30, 610, 0, "K", 3, 6, 48, 'N', p.JpPackNum);//条形码
            B_Prn_Text_TrueType(130, 670, 30, "Arial", 1, 400, 0, 0, 0, "BN3", p.JpPackNum);//条形码数字
            B_Prn_Text_TrueType(40, 710, 20, "Arial", 1, 400, 0, 0, 0, "BN7", "SHANDONG SHINESEN INT'L TRANSPORT CO.,LTD");

            var num = "";
            num = p.JpPostcode.Substring(0, 3) + " - " + p.JpPostcode.Substring(3, 4);
            //for (i = 0; i < p.JpPostcode.Length; i++)
            //{
               // num += p.JpPostcode[i] + "  ";
            //}

            B_Prn_Text_TrueType(220, 340, 60, "Arial", 1, 400, 0, 0, 0, "BN4", num);//1450071
            string receiverAdd = p.JpAddress + p.JpNum;
            if (receiverAdd.Length > 16) //如果地址长度大于21分2行
            {
                if(receiverAdd.Length < 32)
                {
                    var tempStr1 = receiverAdd.Substring(0, 16);
                    var tempStr2 = receiverAdd.Substring(16, receiverAdd.Length - 16);
                    B_Prn_Text_TrueType(220, 410, 40, "Arial", 1, 400, 0, 0, 0, "BN50", tempStr1);//
                    B_Prn_Text_TrueType(220, 460, 40, "Arial", 1, 400, 0, 0, 0, "BN51", tempStr2);//
                }
                else
                {
                    var tempStr1 = receiverAdd.Substring(0, 16);
                    var tempStr2 = receiverAdd.Substring(16, 16);
                    B_Prn_Text_TrueType(220, 410, 40, "Arial", 1, 400, 0, 0, 0, "BN50", tempStr1);//
                    B_Prn_Text_TrueType(220, 460, 40, "Arial", 1, 400, 0, 0, 0, "BN51", tempStr2);//
                }
            }
            else//如果地址长度小于21不分行
            {
                B_Prn_Text_TrueType(220, 410, 40, "Arial", 1, 400, 0, 0, 0, "BN5", receiverAdd);//
            }

            B_Prn_Text_TrueType(220, 510, 40, "Arial", 1, 400, 0, 0, 0, "BN6", p.Attn);//　熊谷様
            //B_Prn_Text_TrueType(80, 570, 30, "Arial", 1, 400, 0, 0, 0, "BN7", p4);//　1001
            if (p.PackName.Length > 17)
                B_Prn_Text_TrueType(220, 560, 30, "Arial", 1, 400, 0, 0, 0, "BN8", p.PackName.Substring(0, 17));
                    //品名:LADYS SHOES (UP:PU　SOLE:TPR)
            else
                B_Prn_Text_TrueType(220, 560, 30, "Arial", 1, 400, 0, 0, 0, "BN8", p.PackName);
            B_Prn_Text_TrueType(515, 560, 30, "Arial", 1, 400, 0, 0, 0, "BN15", p.TotalPackNum + "pack  " + p.PackWeight);

            B_Prn_Text_TrueType(480, 635, 20, "Arial", 1, 400, 0, 0, 0, "BN9", "【差出人:返送先】〒 286-0113");//【差出人:返送先】〒286-0113
            //B_Prn_Text_TrueType(500, 635, 20, "Arial", 1, 400, 0, 0, 0, "BN10", p.AttnTel);//TEL:0476-35-7727

            //string receiverCompanyAddr = p.AcceptCompany +" " + p.JpAddress + p.JpNum;
            //if (receiverCompanyAddr.Length > 15) //如果地址长度大于15分2行
            //{
                //var tempStr1 = receiverCompanyAddr.Substring(0, 15);
                //var tempStr2 = receiverCompanyAddr.Substring(15, receiverCompanyAddr.Length - 15);
                B_Prn_Text_TrueType(488, 660, 20, "Arial", 1, 400, 0, 0, 0, "BN11", "TEL:0476-79-7727");//MOAL株式会社　千葉県成田市
            B_Prn_Text_TrueType(488, 685, 20, "Arial", 1, 400, 0, 0, 0, "BN12", "M.O.AIR LOGISTICS,INC.");
            //}
            //else//如果地址长度小于25不分行
            //{
                B_Prn_Text_TrueType(488, 710, 20, "Arial", 1, 400, 0, 0, 0, "BN16", "千葉県成田市南三里塚78-7");//MOAL株式会社　千葉県成田市
            //}

            B_Print_Out(1);//参数是打印份数
            B_ClosePrn();
            System.Threading.Thread.Sleep(500);
        }
        #endregion
    }
}
