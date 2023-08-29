using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC32_POSIX : Plugin
    {
        public PluginCRC32_POSIX()
        {
            Name = "CRC-32/POSIX";
        }
        //算法：CRC-32/POSIX, 多项式：0x04C11DB7, 宽度：32,  初始值：0x00000000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0xFFFFFFFF
        static Parameters par = new Parameters(32, 0x04C11DB7, 0x00000000, false, false, 0xFFFFFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}