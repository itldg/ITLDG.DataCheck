using CRC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC64_WE : Plugin
    {
        public PluginCRC64_WE()
        {
            Name = "CRC-64/WE";
           
        }
        //算法：CRC-64/WE, 多项式：0x42F0E1EBA9EA3693, 宽度：64, 初始值：0xFFFFFFFFFFFFFFFF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0xFFFFFFFFFFFFFFFF
        static Parameters par = new Parameters(64, 0x42F0E1EBA9EA3693, 0xFFFFFFFFFFFFFFFF, false, false, 0xFFFFFFFFFFFFFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}
