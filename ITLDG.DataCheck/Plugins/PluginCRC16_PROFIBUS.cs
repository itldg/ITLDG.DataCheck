using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_PROFIBUS : Plugin
    {
        public PluginCRC16_PROFIBUS()
        {
            Name = "CRC-16/PROFIBUS";
        }
        //算法：CRC-16/PROFIBUS, 多项式：0x1DCF, 宽度：16,  初始值：0xFFFF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0xFFFF
        static Parameters par = new Parameters(16, 0x1DCF, 0xFFFF, false, false, 0xFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}