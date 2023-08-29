using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC12_UMTS : Plugin
    {
        public PluginCRC12_UMTS()
        {
            Name = "CRC-12/UMTS";
        }
        //算法：CRC-12/UMTS, 多项式：0x080F, 宽度：12,  初始值：0x0000, 数据反转(RefIn)：False, 数据反转(RefOut)：True, 结果异或值：0x0000
        static Parameters par = new Parameters(12, 0x080F, 0x0000, false, true, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}