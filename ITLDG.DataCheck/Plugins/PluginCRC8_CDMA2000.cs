using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC8_CDMA2000 : Plugin
    {
        public PluginCRC8_CDMA2000()
        {
            Name = "CRC-8/CDMA2000";
        }
        //算法：CRC-8/CDMA2000, 多项式：0x9B, 宽度：8,  初始值：0xFF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x00
        static Parameters par = new Parameters(8, 0x9B, 0xFF, false, false, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}