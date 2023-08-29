using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC24_INTERLAKEN : Plugin
    {
        public PluginCRC24_INTERLAKEN()
        {
            Name = "CRC-24/INTERLAKEN";
        }
        //算法：CRC-24/INTERLAKEN, 多项式：0x328B63, 宽度：24,  初始值：0xFFFFFF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0xFFFFFF
        static Parameters par = new Parameters(24, 0x328B63, 0xFFFFFF, false, false, 0xFFFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}