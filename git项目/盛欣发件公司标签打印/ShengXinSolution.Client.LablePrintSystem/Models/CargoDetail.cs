using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShengXinSolution.Client.LablePrintSystem.Models
{
    class CargoDetail
    {
        public string weight { get; set; }
        public string height { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public string quantity { get; set; }

        public bool isNull()
        {
            if (string.IsNullOrEmpty(this.weight)
                || string.IsNullOrEmpty(this.height)
                || string.IsNullOrEmpty(this.length)
                || string.IsNullOrEmpty(this.width))
                return true;
            else return false;
        }
        
    }
}
