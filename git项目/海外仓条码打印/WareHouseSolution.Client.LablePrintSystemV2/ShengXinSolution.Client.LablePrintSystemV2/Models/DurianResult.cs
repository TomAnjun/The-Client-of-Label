using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShengXinSolution.Client.LablePrintSystemV2.Models
{
    class DurianResult<T>
    {
        public string id { get; set; }
        public T result { get; set; }
        public string errMsg { get; set; }
        public int errCd { get; set; }
        public string trId { get; set; }

    }

    class Success<T>
    {
        public bool success { get; set; }
        public string msg { get; set; }
        public T result { get; set; }
    }

    class Grid<T>
    {
        public int total { get; set; }
        public List<T> rows { get; set; }
    }

}
