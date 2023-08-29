using CRC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC64_GO_ISO : Plugin
    {
        public PluginCRC64_GO_ISO()
        {
            Name = "CRC-64/GO-ISO";
           
        }
        //算法：CRC-64/GO-ISO, 多项式：0x000000000000001B, 宽度：64, 初始值：0xFFFFFFFFFFFFFFFF, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0xFFFFFFFFFFFFFFFF
        static Parameters par = new Parameters(64, 0x000000000000001B, 0xFFFFFFFFFFFFFFFF, true, true, 0xFFFFFFFFFFFFFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}
