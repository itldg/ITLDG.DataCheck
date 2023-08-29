using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC8_DVBS2 : Plugin
    {
        public PluginCRC8_DVBS2()
        {
            Name = "CRC-8/DVB-S2";
        }
        //算法：CRC-8/DVB-S2, 多项式：0xD5, 宽度：8,  初始值：0x00, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x00
        static Parameters par = new Parameters(8, 0xD5, 0x00, false, false, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}