//文件名         ProductInfo.cs
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
    class ProductInfo
    {
        public ProductInfo()
        {
            product_code = "";
            product_nm_cn = "";
            product_price = "";
            product_size_l = "";
            product_size_w = "";
            product_size_h = "";
            product_amount = "";
            product_amount_scan = 0;
            scanned_no = "";
            company_product_code = "";
            check_flag = "";
        }

        public string product_code { get; set; }

        public string product_nm_cn { get; set; }

        public string product_price { get; set; }

        public string product_size_l { get; set; }

        public string product_size_w { get; set; }

        public string product_size_h { get; set; }

        public string product_amount { get; set; }

        public int product_amount_scan { get; set; }

        public string scanned_no { get; set; }

        public string company_product_code { get; set; }

        public string check_flag { get; set; }
    }
}
