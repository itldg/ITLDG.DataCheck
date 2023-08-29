using CRC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC64_ECMA_182 : Plugin
    {
        public PluginCRC64_ECMA_182()
        {
            Name = "CRC-64/ECMA-182";
           
        }
        //算法：CRC-64/ECMA-182, 多项式：0x42F0E1EBA9EA3693, 宽度：64, 初始值：0x0000000000000000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x0000000000000000
        static Parameters par = new Parameters(64, 0x42F0E1EBA9EA3693, 0x0000000000000000, false, false, 0x0000000000000000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}
