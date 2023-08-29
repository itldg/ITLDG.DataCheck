using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC8_ROHC : Plugin
    {
        public PluginCRC8_ROHC()
        {
            Name = "CRC-8/ROHC";
        }
        //算法：CRC-8/ROHC, 多项式：0x07, 宽度：8,  初始值：0xFF, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x00
        static Parameters par = new Parameters(8, 0x07, 0xFF, true, true, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}