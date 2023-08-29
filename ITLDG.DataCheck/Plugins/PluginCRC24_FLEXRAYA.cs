using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC24_FLEXRAYA : Plugin
    {
        public PluginCRC24_FLEXRAYA()
        {
            Name = "CRC-24/FLEXRAY-A";
        }
        //算法：CRC-24/FLEXRAY-A, 多项式：0x5D6DCB, 宽度：24,  初始值：0xFEDCBA, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x000000
        static Parameters par = new Parameters(24, 0x5D6DCB, 0xFEDCBA, false, false, 0x000000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}