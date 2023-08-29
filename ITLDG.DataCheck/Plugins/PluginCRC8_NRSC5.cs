using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC8_NRSC5 : Plugin
    {
        public PluginCRC8_NRSC5()
        {
            Name = "CRC-8/NRSC-5";
        }
        //算法：CRC-8/NRSC-5, 多项式：0x31, 宽度：8,  初始值：0xFF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x00
        static Parameters par = new Parameters(8, 0x31, 0xFF, false, false, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}