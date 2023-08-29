using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC11_FLEXRAY : Plugin
    {
        public PluginCRC11_FLEXRAY()
        {
            Name = "CRC-11/FLEXRAY";
        }
        //算法：CRC-11/FLEXRAY, 多项式：0x0385, 宽度：11,  初始值：0x001A, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x0000
        static Parameters par = new Parameters(11, 0x0385, 0x001A, false, false, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}