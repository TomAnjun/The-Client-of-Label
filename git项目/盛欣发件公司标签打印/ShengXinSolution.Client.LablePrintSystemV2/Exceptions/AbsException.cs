using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShengXinSolution.Client.LablePrintSystemV2.Exceptions
{
    class AbsException : Exception
    {
        public int errCd { get; set; }
        public String errMsg { get; set; }


    }
}
