using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC14_DARC : Plugin
    {
        public PluginCRC14_DARC()
        {
            Name = "CRC-14/DARC";
        }
        //算法：CRC-14/DARC, 多项式：0x0805, 宽度：14,  初始值：0x0000, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x0000
        static Parameters par = new Parameters(14, 0x0805, 0x0000, true, true, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}