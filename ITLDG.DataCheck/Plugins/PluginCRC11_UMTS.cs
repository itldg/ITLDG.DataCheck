using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC11_UMTS : Plugin
    {
        public PluginCRC11_UMTS()
        {
            Name = "CRC-11/UMTS";
        }
        //算法：CRC-11/UMTS, 多项式：0x0307, 宽度：11,  初始值：0x0000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x0000
        static Parameters par = new Parameters(11, 0x0307, 0x0000, false, false, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}