using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC7_UMTS : Plugin
    {
        public PluginCRC7_UMTS()
        {
            Name = "CRC-7/UMTS";
        }
        //算法：CRC-7/UMTS, 多项式：0x45, 宽度：7,  初始值：0x00, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x00
        static Parameters par = new Parameters(7, 0x45, 0x00, false, false, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}