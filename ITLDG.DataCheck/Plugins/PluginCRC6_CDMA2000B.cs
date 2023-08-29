using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC6_CDMA2000B : Plugin
    {
        public PluginCRC6_CDMA2000B()
        {
            Name = "CRC-6/CDMA2000-B";
        }
        //算法：CRC-6/CDMA2000-B, 多项式：0x07, 宽度：6,  初始值：0x3F, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x00
        static Parameters par = new Parameters(6, 0x07, 0x3F, false, false, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}