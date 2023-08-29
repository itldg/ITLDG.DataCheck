using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCheckSumDifference : Plugin
    {
        public PluginCheckSumDifference()
        {
            Name = "CheckSum 累加和校验( 0x100 - Sum 的差值)";
        }

        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = Common.AllAdd(DataByte);
            r[0] = (byte)(0x100 - r[0]);
            return r;
        }
    }
}
