using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShengXinSolution.Client.LablePrintSystemV2.Models
{
    class ItemInfo
    {
        public ItemInfo()
        {
            item_nm_en = "";
        }

        public string waybill_id { get; set; }
        public string item_id { get; set; }
        public string item_nm_en { get; set; }
    }
}
