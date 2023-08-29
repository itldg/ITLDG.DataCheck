using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC8_BLUETOOTH : Plugin
    {
        public PluginCRC8_BLUETOOTH()
        {
            Name = "CRC-8/BLUETOOTH";
        }
        //算法：CRC-8/BLUETOOTH, 多项式：0xA7, 宽度：8,  初始值：0x00, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x00
        static Parameters par = new Parameters(8, 0xA7, 0x00, true, true, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}