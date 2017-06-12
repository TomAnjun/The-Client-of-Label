using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WareHouseSolution.Client.LablePrintSystem.Models
{
    class ProductRegInfo
    {
        public ProductRegInfo() {
            product_reg_code = "";
            company_product_code = "";
        }

        public string product_reg_code { get; set; }

        public string company_product_code { get; set; }
    }
}
