using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_USB : Plugin
    {
        public PluginCRC16_USB()
        {
            Name = "CRC-16/USB";
        }
        //算法：CRC-16/USB, 多项式：0x8005, 宽度：16,  初始值：0xFFFF, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0xFFFF
        static Parameters par = new Parameters(16, 0x8005, 0xFFFF, true, true, 0xFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}