using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShengXinSolution.Client.LablePrintSystemV2.Models
{
    class MasterInfo
    {
        public MasterInfo()
        {
            outlet_port = "";
            arrival_port = "";
            airline_company_nm = "";
            flight_no = "";
        }

        public string master_id { get; set; }
        public string outlet_port { get; set; }
        public string arrival_port { get; set; }
        public string airline_company_nm { get; set; }
        public string flight_no { get; set; }
        public int master_item_cnt { get; set; }
        public int item_index { get; set; }
     
    }
}
