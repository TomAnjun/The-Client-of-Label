using System;
using CCWin.SkinControl.Internals;
using Newtonsoft.Json;

namespace ShengXinSolution.Client.LablePrintSystemV2.Models
{
    class PackageInfo
    {
        public PackageInfo()
        {
            waybill_id = "";
            package_id = "";
            awb_no = "";
            package_size_l = "";
            package_size_w = "";
            package_size_h = "";
            package_weight = "";
            package_volume_weight = "";
        }

        public string waybill_id { get; set; }
        public string package_id { get; set; }
        //海关号
        public string awb_no { get; set; }

        public string package_size_l { get; set; }

        public string package_size_w { get; set; }

        public string package_size_h { get; set; }

        public string package_weight { get; set; }

        public string package_volume_weight { get; set; }
    }
}
