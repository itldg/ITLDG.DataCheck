using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC32_D : Plugin
    {
        public PluginCRC32_D()
        {
            Name = "CRC-32/D";
        }
        //算法：CRC-32/D, 多项式：0xA833982B, 宽度：32,  初始值：0xFFFFFFFF, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0xFFFFFFFF
        static Parameters par = new Parameters(32, 0xA833982B, 0xFFFFFFFF, true, true, 0xFFFFFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}