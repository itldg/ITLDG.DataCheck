using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginLrc : Plugin
    {
        public PluginLrc()
        {
            Name = "LRC 纵向冗余校验（Longitudinal Redundancy Check）";
        }

        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r= Common.Lrc(DataByte);
            return r;
        }
    }
}
