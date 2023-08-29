using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC24_FLEXRAYB : Plugin
    {
        public PluginCRC24_FLEXRAYB()
        {
            Name = "CRC-24/FLEXRAY-B";
        }
        //算法：CRC-24/FLEXRAY-B, 多项式：0x5D6DCB, 宽度：24,  初始值：0xABCDEF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x000000
        static Parameters par = new Parameters(24, 0x5D6DCB, 0xABCDEF, false, false, 0x000000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}