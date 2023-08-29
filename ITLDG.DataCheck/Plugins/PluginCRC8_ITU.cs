using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC8_ITU : Plugin
    {
        public PluginCRC8_ITU()
        {
            Name = "CRC-8/ITU";
        }
        //算法：CRC-8/ITU, 多项式：0x07, 宽度：8,  初始值：0x00, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x55
        static Parameters par = new Parameters(8, 0x07, 0x00, false, false, 0x55);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}