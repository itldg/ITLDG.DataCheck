using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC24_LTEB : Plugin
    {
        public PluginCRC24_LTEB()
        {
            Name = "CRC-24/LTE-B";
        }
        //算法：CRC-24/LTE-B, 多项式：0x800063, 宽度：24,  初始值：0x000000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x000000
        static Parameters par = new Parameters(24, 0x800063, 0x000000, false, false, 0x000000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}