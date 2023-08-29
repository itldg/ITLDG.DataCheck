using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC32_C : Plugin
    {
        public PluginCRC32_C()
        {
            Name = "CRC-32/C";
        }
        //算法：CRC-32/C, 多项式：0x1EDC6F41, 宽度：32,  初始值：0xFFFFFFFF, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0xFFFFFFFF
        static Parameters par = new Parameters(32, 0x1EDC6F41, 0xFFFFFFFF, true, true, 0xFFFFFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}