using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC5_ITU : Plugin
    {
        public PluginCRC5_ITU()
        {
            Name = "CRC-5/ITU";
        }
        //算法：CRC-5/ITU, 多项式：0x15, 宽度：5,  初始值：0x00, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x00
        static Parameters par = new Parameters(5, 0x15, 0x00, true, true, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}