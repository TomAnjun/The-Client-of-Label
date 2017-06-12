using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace ShengXinSolution.Client.LablePrintSystemV2.Models
{
    class WaybillInfo
    {
        public WaybillInfo()
        {
            print_date = DateTime.Now.ToString("yyyyMMdd");
            sx_no = "";
            jp_express_no = "";
            cargo_type = "";
            total_price = "";
            total_package_cnt = "";
            sender_nm_en = "";
            sender_addr_en = "";
            sender_zip_cd = "";
            sender_tel = "";
            receiver_zip_cd = "";
            receiver_addr_cn = "";
            receiver_nm_cn = "";
            receiver_contact_nm_cn = "";
            receiver_tel = "";
            receiver_nm_en = "";
            receiver_addr_en = "";
            fandi_no_big = "";
            fandi_no_small = "";
            ArrivalShopNo = "";
            StoreHouseShort = "";
            StoreHouseTel = "";
            StoreHouseFax = "";
            StoreHouseCd = "";
            StoreHouseLong = "";
            StoreCompanyTel = "";
            StoreCompanyFax = "";
            Destination = "";
            FlightDate = DateTime.Now.ToString("yyyy-M-d");
        }

        public List<PackageInfo> packages { get; set; }

        public List<ItemInfo> items { get; set; }

        public string waybill_id { get; set; }
        //发送日期
        public string print_date { get; set; }
        //盛欣单号
        public string sx_no { get; set; }
        //日本快递单号
        public string jp_express_no { get; set; }
        //货物类型
        public string cargo_type { get; set; }
        //总价
        public string total_price { get; set; }
        //包裹总数量
        public string total_package_cnt { get; set; }

        //发件人-英文
        public string sender_nm_en { get; set; }
        //发件人地址-英文
        public string sender_addr_en { get; set; }
        //发件人邮编
        public string sender_zip_cd { get; set; }
        //发件人电话
        public string sender_tel { get; set; }

        //收件人邮编
        public string receiver_zip_cd { get; set; }
        //收件人中文地址
        public string receiver_addr_cn { get; set; }
        //收件地址-番地
        //public string receiver_fandi { get; set; } = "";
        //收件人-中文
        public string receiver_nm_cn { get; set; }
        //收件联系人-中文
        public string receiver_contact_nm_cn { get; set; }
        //收件人电话
        public string receiver_tel { get; set; }
        //收件人-英文
        public string receiver_nm_en { get; set; }
        //收件地址-英文
        public string receiver_addr_en { get; set; }

        //着店号-前缀
        public string fandi_no_big { get; set; }
        //着店号-后缀
        public string fandi_no_small { get; set; }

        //着店号-条码
        [JsonIgnore]
        public string ArrivalShopNo { get; set; }
        //到着店 eg.成田店
        [JsonIgnore]
        public string StoreHouseShort { get; set; }
        //到着店电话
        [JsonIgnore]
        public string StoreHouseTel { get; set; }
        //到着店传真
        [JsonIgnore]
        public string StoreHouseFax { get; set; }
        //出荷場code
        [JsonIgnore]
        public string StoreHouseCd { get; set; }
        //营业所
        [JsonIgnore]
        public string StoreHouseLong { get; set; }
        //会社电话
        [JsonIgnore]
        public string StoreCompanyTel { get; set; }
        //会社传真
        [JsonIgnore]
        public string StoreCompanyFax { get; set; }
        //目的港
        [JsonIgnore]
        public string Destination { get; set; }
        //E-Commerce
        [JsonIgnore]
        public bool ECommerce { get; set; }
        //航班日期
        [JsonIgnore]
        public string FlightDate { get; set; }
    }
}