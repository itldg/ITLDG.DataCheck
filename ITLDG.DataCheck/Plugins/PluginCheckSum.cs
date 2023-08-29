using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCheckSum : Plugin
    {
        public PluginCheckSum()
        {
            Name = "CheckSum 累加和校验";
        }

        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r= Common.AllAdd(DataByte);
            return r;
        }
    }
}
