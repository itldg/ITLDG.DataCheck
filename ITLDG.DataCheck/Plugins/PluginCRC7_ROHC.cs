using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC7_ROHC : Plugin
    {
        public PluginCRC7_ROHC()
        {
            Name = "CRC-7/ROHC";
        }
        //算法：CRC-7/ROHC, 多项式：0x4F, 宽度：7,  初始值：0x7F, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x00
        static Parameters par = new Parameters(7, 0x4F, 0x7F, true, true, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}