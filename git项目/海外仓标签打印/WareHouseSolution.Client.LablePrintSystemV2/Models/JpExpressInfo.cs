using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WareHouseSolution.Client.LablePrintSystem.Models
{
    class JpExpressInfo
    {
        //日本单号区间编号
        public string jp_express_section_id { get; set; }
        //快递公司编码
        public string jp_express_company { get; set; }
        //快递公司
        public string jp_express_company_nm { get; set; }
        //城市代码
        public string city_code { get; set; }
        //配送城市代码
        public string customer_name { get; set; }
        //开始号码
        public string start_no { get; set; }
        //结束号码
        //public string end_no { get; set; }
    }
}
