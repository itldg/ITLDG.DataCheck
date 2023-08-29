using ITLDG.DataCheck;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PluginExample
{
    public class PluginTest : Plugin
    {
        public PluginTest()
        {
            Name = "测试插件(固定00 FF)";
        }

        public override byte[] CheckData(byte[] DataByte)
        {
            return new byte[2] { 0x00, 0xFF };
        }
    }
}
