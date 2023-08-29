using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Results
{
    public class ResultHighLowReverse : Result
    {
        public ResultHighLowReverse()
        {
            Name = "高低位倒序";
        }
        public override string Convert(string DataStr)
        {
            if (DataStr.Length > 2 && DataStr.Length % 2 == 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = DataStr.Length - 2; i >= 0; i -= 2)
                {
                    sb.Append(DataStr.Substring(i, 2));
                }
                return sb.ToString();
            }
            return "";
        }
    }
}
