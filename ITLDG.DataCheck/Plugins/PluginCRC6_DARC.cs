using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC6_DARC : Plugin
    {
        public PluginCRC6_DARC()
        {
            Name = "CRC-6/DARC";
        }
        //算法：CRC-6/DARC, 多项式：0x19, 宽度：6,  初始值：0x00, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x00
        static Parameters par = new Parameters(6, 0x19, 0x00, true, true, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}