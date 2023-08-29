using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC31_PHILLIPS : Plugin
    {
        public PluginCRC31_PHILLIPS()
        {
            Name = "CRC-31/PHILLIPS";
        }
        //算法：CRC-31/PHILLIPS, 多项式：0x04C11DB7, 宽度：31,  初始值：0x7FFFFFFF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x7FFFFFFF
        static Parameters par = new Parameters(31, 0x04C11DB7, 0x7FFFFFFF, false, false, 0x7FFFFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}