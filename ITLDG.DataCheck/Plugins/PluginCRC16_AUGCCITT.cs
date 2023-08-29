using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_AUGCCITT : Plugin
    {
        public PluginCRC16_AUGCCITT()
        {
            Name = "CRC-16/AUG-CCITT";
        }
        //算法：CRC-16/AUG-CCITT, 多项式：0x1021, 宽度：16,  初始值：0x1D0F, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x0000
        static Parameters par = new Parameters(16, 0x1021, 0x1D0F, false, false, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}