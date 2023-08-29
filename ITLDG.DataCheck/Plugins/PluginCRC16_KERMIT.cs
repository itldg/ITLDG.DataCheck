using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_KERMIT : Plugin
    {
        public PluginCRC16_KERMIT()
        {
            Name = "CRC-16/KERMIT";
        }
        //算法：CRC-16/KERMIT, 多项式：0x1021, 宽度：16,  初始值：0x0000, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x0000
        static Parameters par = new Parameters(16, 0x1021, 0x0000, true, true, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}