using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC3_ROHC : Plugin
    {
        public PluginCRC3_ROHC()
        {
            Name = "CRC-3/ROHC";
        }
        //算法：CRC-3/ROHC, 多项式：0x03, 宽度：3,  初始值：0x07, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x00
        static Parameters par = new Parameters(3, 0x03, 0x07, true, true, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}