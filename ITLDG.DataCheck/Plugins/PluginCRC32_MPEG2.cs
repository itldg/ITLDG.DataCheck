using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC32_MPEG2 : Plugin
    {
        public PluginCRC32_MPEG2()
        {
            Name = "CRC-32/MPEG-2";
        }
        //算法：CRC-32/MPEG-2, 多项式：0x04C11DB7, 宽度：32,  初始值：0xFFFFFFFF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x00000000
        static Parameters par = new Parameters(32, 0x04C11DB7, 0xFFFFFFFF, false, false, 0x00000000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}