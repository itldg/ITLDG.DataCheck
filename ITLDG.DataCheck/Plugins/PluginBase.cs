using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginBase : Plugin
    {
        public PluginBase()
        {
            Name = "原封不动";
        }

        public override byte[] CheckData(byte[] DataByte)
        {
            return DataByte;
        }
    }
}
