using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC4_INTERLAKEN : Plugin
    {
        public PluginCRC4_INTERLAKEN()
        {
            Name = "CRC-4/INTERLAKEN";
        }
        //算法：CRC-4/INTERLAKEN, 多项式：0x03, 宽度：4,  初始值：0x0F, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x0F
        static Parameters par = new Parameters(4, 0x03, 0x0F, false, false, 0x0F);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}