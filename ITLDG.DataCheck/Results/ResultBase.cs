using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Results
{
    public class ResultBase : Result
    {
        public ResultBase()
        {
            Name = "原始结果";
            Double = false;
        }
        public override string Convert(string DataStr)
        {
            return DataStr;
        }
    }
}
