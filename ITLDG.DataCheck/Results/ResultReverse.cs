using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Results
{
    public class ResultReverse: Result
    {
        public ResultReverse()
        {
            Name = "字符倒序";
        }
        public override string Convert(string DataStr)
        {
            StringBuilder sb2 = new StringBuilder();
            for (int i = DataStr.Length - 1; i > -1; i--)
            {
                sb2.Append(DataStr[i].ToString());
            }
            return sb2.ToString();
        }
    }
}
