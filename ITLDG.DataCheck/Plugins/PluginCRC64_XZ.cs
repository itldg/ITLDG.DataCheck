using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC64_XZ : Plugin
    {
        public PluginCRC64_XZ()
        {
            Name = "CRC-64/XZ";
           
        }
        //算法：CRC-64/XZ, 多项式：0x42F0E1EBA9EA3693, 宽度：64, 初始值：0xFFFFFFFFFFFFFFFF, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0xFFFFFFFFFFFFFFFF
        static Parameters par = new Parameters(64, 0x42F0E1EBA9EA3693, 0xFFFFFFFFFFFFFFFF, true, true, 0xFFFFFFFFFFFFFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}
