using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_GENIBUS : Plugin
    {
        public PluginCRC16_GENIBUS()
        {
            Name = "CRC-16/GENIBUS";
        }
        //算法：CRC-16/GENIBUS, 多项式：0x1021, 宽度：16,  初始值：0xFFFF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0xFFFF
        static Parameters par = new Parameters(16, 0x1021, 0xFFFF, false, false, 0xFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}