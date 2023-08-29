using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginBcc : Plugin
    {
        public PluginBcc()
        {
            Name = "BCC(Block Check Character/信息组校验码)";
        }

        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r= Common.Bcc(DataByte);
            return r;
        }
    }
}
