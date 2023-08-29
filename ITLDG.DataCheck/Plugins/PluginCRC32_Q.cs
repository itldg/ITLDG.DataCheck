using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC32_Q : Plugin
    {
        public PluginCRC32_Q()
        {
            Name = "CRC-32/Q";
        }
        //算法：CRC-32/Q, 多项式：0x814141AB, 宽度：32,  初始值：0x00000000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x00000000
        static Parameters par = new Parameters(32, 0x814141AB, 0x00000000, false, false, 0x00000000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}