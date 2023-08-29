using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC8_ICODE : Plugin
    {
        public PluginCRC8_ICODE()
        {
            Name = "CRC-8/I-CODE";
        }
        //算法：CRC-8/I-CODE, 多项式：0x1D, 宽度：8,  初始值：0xFD, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x00
        static Parameters par = new Parameters(8, 0x1D, 0xFD, false, false, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}