//文件名         OrderInfo.cs
//
//作者           anjun
//
//日期           2016-07-12
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WareHouseSolution.Client.LablePrintSystem.Models
{
    class OrderInfo
    {
        public OrderInfo()
        {
            //物品订单编号
            product_order_no = "";
            //公司编号
            company_id = "";
            //订单日期
            product_order_date = "";
            //货物配送号码(日本)
            jp_express_no = "";
            //日本快递区间编号
            jp_express_section_id = "";
            //配送日期
            delivery_date = "";
            //配送状态
            delivery_state = "";
            //收件人中文名
            receiver_nm_cn = "";
            //收件人日文名
            receiver_nm_jp = "";
            //收件人英文名
            receiver_nm_en = "";
            //收件人电话
            receiver_tel = "";
            //收件人手机号
            receiver_phone_no = "";
            //收件人地址
            receiver_address = "";
            //收件人邮编
            receiver_zipcode = "";
            //货币种类
            currency_type = "";
            //收件人建议
            receiver_suggestion = "";
            //发件公司中文名
            send_com_nm_cn = "";
            //发件公司日文名
            send_company_jp = "";
            //发件公司英文名
            send_company_en = "";
            //发件地址中文名
            send_address_cn = "";
            //发件公司英文名
            send_address_en = "";
            //发件人中文名
            sender_nm_cn = "";
            //发件邮编
            send_zip = "";
            //发件传真
            send_fax = "";
            //发件人电话
            sender_tel = "";
            //发件邮箱
            sender_mail = "";
            StoreHouseShort = "";
            StoreHouseTel = "";
            StoreHouseFax = "";
            StoreHouseCd = "";
            StoreCompanyTel = "";
            StoreCompanyFax = "";
            ArrivalShopNo = "";
            StoreHouseLong = "";
            fandi_no_big = "";
            fandi_no_small = "";
            city_code = "";
            //顾客番号
            customer_designation = "";
            jp_express_company = "";
            //付款方式 01预付 02到付
            pay_mode = "";
            //货到付款金额
            cod_money = "";
            //消费税
            consumption_tax_money = "";
            //配送指定日期 *月*日
            delivery_designation_date = "";
            //时间指定  14点-16点
            time_specified = "";
            //结算类型
            settlement_type = "";
            //付款货币种类
            pay_money_type = "";
        }

        public List<ProductInfo> products { get; set; }

        public string product_order_no { get; set; }

        public string company_id { get; set; }

        public string product_order_date { get; set; }

        public string jp_express_no { get; set; }

        public string jp_express_section_id { get; set; }

        public string delivery_date { get; set; }

        public string delivery_state { get; set; }

        public string receiver_nm_cn { get; set; }

        public string receiver_nm_jp { get; set; }

        public string receiver_nm_en { get; set; }

        public string receiver_tel { get; set; }

        public string receiver_phone_no { get; set; }

        public string receiver_address { get; set; }

        public string receiver_zipcode { get; set; }

        public string currency_type { get; set; }

        public string receiver_suggestion { get; set; }

        public string send_com_nm_cn { get; set; }

        public string send_com_nm_en { get; set; }

        public string send_address_cn { get; set; }

        public string send_address_en { get; set; }

        public string sender_nm_cn { get; set; }

        public string send_zip { get; set; }

        public string send_fax { get; set; }

        public string sender_tel { get; set; }

        public string sender_mail { get; set; }

        public bool IsNull { get; set; }

        public string StoreHouseShort { get; set; }

        public string StoreHouseTel { get; set; }

        public string StoreHouseFax { get; set; }

        public string StoreHouseCd { get; set; }

        public string StoreCompanyTel { get; set; }

        public string StoreCompanyFax { get; set; }

        public string StoreHouseLong { get; set; }

        public string ArrivalShopNo { get; set; }

        public string fandi_no_big { get; set; }

        public string fandi_no_small { get; set; }

        public string city_code { get; set; }

        public string jp_express_company { get; set; }

        public string pay_mode { get; set; }

        public string cod_money { get; set; }

        public string consumption_tax_money { get; set; }

        public string delivery_designation_date { get; set; }

        public string time_specified { get; set; }

        public string settlement_type { get; set; }

        public string pay_money_type { get; set; }

        public string send_company_jp { get; set; }

        public string send_company_en { get; set; }

        public string customer_designation { get; set; }
    }
}
