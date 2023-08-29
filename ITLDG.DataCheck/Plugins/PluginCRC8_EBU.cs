using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC8_EBU : Plugin
    {
        public PluginCRC8_EBU()
        {
            Name = "CRC-8/EBU";
        }
        //算法：CRC-8/EBU, 多项式：0x1D, 宽度：8,  初始值：0xFF, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x00
        static Parameters par = new Parameters(8, 0x1D, 0xFF, true, true, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}