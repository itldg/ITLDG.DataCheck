using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_X25 : Plugin
    {
        public PluginCRC16_X25()
        {
            Name = "CRC-16/X-25";
        }
        //算法：CRC-16/X-25, 多项式：0x1021, 宽度：16,  初始值：0xFFFF, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0xFFFF
        static Parameters par = new Parameters(16, 0x1021, 0xFFFF, true, true, 0xFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}