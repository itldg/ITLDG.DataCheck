using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_DDS110 : Plugin
    {
        public PluginCRC16_DDS110()
        {
            Name = "CRC-16/DDS-110";
        }
        //算法：CRC-16/DDS-110, 多项式：0x8005, 宽度：16,  初始值：0x800D, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x0000
        static Parameters par = new Parameters(16, 0x8005, 0x800D, false, false, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}