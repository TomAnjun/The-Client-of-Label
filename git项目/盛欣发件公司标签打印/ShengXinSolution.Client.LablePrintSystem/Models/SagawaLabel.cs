using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ShengXinSolution.Client.LablePrintSystem.Models
{
    class SagawaLabel
    {
        private string labelType;//打印标签的类型

        public string LabelType
        {
            get { return labelType; }
            set { labelType = value; }
        }
        private string bigNum;//

        public string BigNum
        {
            get { return bigNum; }
            set { bigNum = value; }
        }

       
        private string smallNum;//

        public string SmallNum
        {
            get { return smallNum; }
            set { smallNum = value; }
        }
        private string date;//send date

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string nowPackNum;//

        public string NowPackNum
        {
            get { return nowPackNum; }
            set { nowPackNum = value; }
        }
        private string totalPackNum;

        public string TotalPackNum
        {
            get { return totalPackNum; }
            set { totalPackNum = value; }
        }
        private string jpPostcode;

        public string JpPostcode
        {
            get { return jpPostcode; }
            set { jpPostcode = value; }
        }
        private string jpAddress;

        public string JpAddress
        {
            get { return jpAddress; }
            set { jpAddress = value; }
        }
        private string jpNum;//日本番号

        public string JpNum
        {
            get { return jpNum; }
            set { jpNum = value; }
        }
        private string acceptCompany;

        public string AcceptCompany
        {
            get { return acceptCompany; }
            set { acceptCompany = value; }
        }
        private string attn;//收件人

        public string Attn
        {
            get { return attn; }
            set { attn = value; }
        }
        private string attnTel;

        public string AttnTel
        {
            get { return attnTel; }
            set { attnTel = value; }
        }
        private string barcode01;

        public string Barcode01
        {
            get { return barcode01; }
            set { barcode01 = value; }
        }
        private string storehouseName;//集货店名称

        public string StorehouseName
        {
            get { return storehouseName; }
            set { storehouseName = value; }
        }
        private string storehouseTel;

        public string StorehouseTel
        {
            get { return storehouseTel; }
            set { storehouseTel = value; }
        }
        private string storehouseFax;

        public string StorehouseFax
        {
            get { return storehouseFax; }
            set { storehouseFax = value; }
        }
        private string deliveryPlace;

        public string DeliveryPlace
        {
            get { return deliveryPlace; }
            set { deliveryPlace = value; }
        }
        private string jpPackNum;

        public string JpPackNum
        {
            get { return jpPackNum; }
            set { jpPackNum = value; }
        }

        private string agentSendCompany;

        public string AgentSendCompany
        {
            get { return agentSendCompany; }
            set { agentSendCompany = value; }
        }
        private string agentSendCompanyAdd;

        public string AgentSendCompanyAdd
        {
            get { return agentSendCompanyAdd; }
            set { agentSendCompanyAdd = value; }
        }
        private string agentTransCompany;

        public string AgentTransCompany
        {
            get { return agentTransCompany; }
            set { agentTransCompany = value; }
        }
        private string agentTransPlace;

        public string AgentTransPlace
        {
            get { return agentTransPlace; }
            set { agentTransPlace = value; }
        }
        private string placeTel;

        public string PlaceTel
        {
            get { return placeTel; }
            set { placeTel = value; }
        }
        private string placeFax;

        public string PlaceFax
        {
            get { return placeFax; }
            set { placeFax = value; }
        }
        //public string jpPackNum;
        private string packName;

        public string PackName
        {
            get { return packName; }
            set { packName = value; }
        }
        private string packWeight;

        public string PackWeight
        {
            get { return packWeight; }
            set { packWeight = value; }
        }
        private string packVolume;

        public string PackVolume
        {
            get { return packVolume; }
            set { packVolume = value; }
        }
        public string cnPackNum;

        public string CnPackNum
        {
            get { return cnPackNum; }
            set { cnPackNum = value; }
        }

        public string SendDate
        {
            get { return date; }
            set { date = value; }
        }

        public string senderZipcode;
        public string SenderZipcode
        {
            get { return senderZipcode; }
            set { senderZipcode = value; }
        }

        public string senderTel;
        public string SenderTel
        {
            get { return senderTel; }
            set { senderTel = value; }
        }

        public string jpNumNoLetter;
        public string JpNumNoLetter
        {
            get { return jpNumNoLetter; }
            set { jpNumNoLetter = value; }
        }

        public string customsNo;
        public string CustomsNo
        {
            get { return customsNo; }
            set { customsNo = value; }
        }

        public string eCommerce;
        public string ECommerce
        {
            get { return eCommerce; }
            set { eCommerce = value; }
        }

        public string destination;
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public string flightDate;
        public string FlightDate
        {
            get { return flightDate; }
            set { flightDate = value; }
        }

        public string receiverNameEn;
        public string ReceiverNameEn
        {
            get { return receiverNameEn; }
            set { receiverNameEn = value; }
        }

        public string receiverAddrEn;
        public string ReceiverAddrEn
        {
            get { return receiverAddrEn; }
            set { receiverAddrEn = value; }
        }

        public string totalPrice;
        public string TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public string emptyStyle;
        public string EmptyStyle
        {
            get { return emptyStyle; }
            set { emptyStyle = value; }
        }

        public void parsing(string tmp) {
            try
            {
                //将读取到的txt行数据进行解析和赋值
                if (tmp == null || tmp.Equals(""))
                    return;
                //将字符串以“|”分割赋值到tmpData中
                String[] tmpDatas = tmp.Split('|');
                //if (tmpDatas.Length > 0) this.SendDate = tmpDatas[0];
                if (tmpDatas.Length > 0) this.LabelType = tmpDatas[0];
                if (tmpDatas.Length > 1) this.BigNum = tmpDatas[1];
                if (tmpDatas.Length > 2) this.SmallNum = tmpDatas[2];
                if (tmpDatas.Length > 3) this.Date = tmpDatas[3];
                if (tmpDatas.Length > 4) this.NowPackNum = tmpDatas[4];
                if (tmpDatas.Length > 5) this.TotalPackNum = tmpDatas[5];
                if (tmpDatas.Length > 6) this.JpPostcode = tmpDatas[6];
                if (tmpDatas.Length > 7) this.JpAddress = tmpDatas[7];
                if (tmpDatas.Length > 8) this.JpNum = tmpDatas[8];
                if (tmpDatas.Length > 9) this.AcceptCompany = tmpDatas[9];
                if (tmpDatas.Length > 10) this.Attn = tmpDatas[10];
                if (tmpDatas.Length > 11) this.AttnTel = tmpDatas[11];
                if (tmpDatas.Length > 12) this.Barcode01 = tmpDatas[12];
                if (tmpDatas.Length > 13) this.StorehouseName = tmpDatas[13];
                if (tmpDatas.Length > 14) this.StorehouseTel = tmpDatas[14];
                if (tmpDatas.Length > 15) this.StorehouseFax = tmpDatas[15];
                if (tmpDatas.Length > 16) this.DeliveryPlace = tmpDatas[16];
                if (tmpDatas.Length > 17) this.JpPackNum = tmpDatas[17];
                if (tmpDatas.Length > 18) this.AgentSendCompany = tmpDatas[18];
                if (tmpDatas.Length > 19) this.AgentSendCompanyAdd = tmpDatas[19];
                if (tmpDatas.Length > 20) this.AgentTransCompany = tmpDatas[20];
                if (tmpDatas.Length > 21) this.AgentTransPlace = tmpDatas[21];
                if (tmpDatas.Length > 22) this.PlaceTel = tmpDatas[22];
                if (tmpDatas.Length > 23) this.PlaceFax = tmpDatas[23];
                if (tmpDatas.Length > 24) this.jpNumNoLetter = tmpDatas[24];
                if (tmpDatas.Length > 25) this.PackName = tmpDatas[25];
                if (tmpDatas.Length > 26) this.PackWeight = tmpDatas[26];
                if (tmpDatas.Length > 27) this.PackVolume = tmpDatas[27];
                if (tmpDatas.Length > 28) this.CnPackNum = tmpDatas[28];
                if (tmpDatas.Length > 29) this. senderZipcode= tmpDatas[29];
                if (tmpDatas.Length > 30) this.senderTel = tmpDatas[30];
                if (tmpDatas.Length > 31) this.customsNo = tmpDatas[31];
                if (tmpDatas.Length > 32) this.receiverNameEn = tmpDatas[32];
                if (tmpDatas.Length > 33) this.receiverAddrEn = tmpDatas[33];
                if (tmpDatas.Length > 34) this.totalPrice = tmpDatas[34];
            }
            catch (Exception)
            {

                MessageBox.Show("格式错误!");
            }

           
        }
    }
}
