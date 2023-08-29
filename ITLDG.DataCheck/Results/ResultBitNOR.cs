using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Results
{
    public class ResultBitNOR : Result
    {
        public ResultBitNOR()
        {
            Name = "位取反";
        }
        public override string Convert(string DataStr)
        {
            if ( DataStr.Length % 2 == 0)
            {
                return CommonBit.HexNOR(DataStr);
            }
            return "";
        }
    }
}
