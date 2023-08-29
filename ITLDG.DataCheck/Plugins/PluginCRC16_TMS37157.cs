using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_TMS37157 : Plugin
    {
        public PluginCRC16_TMS37157()
        {
            Name = "CRC-16/TMS37157";
        }
        //算法：CRC-16/TMS37157, 多项式：0x1021, 宽度：16,  初始值：0x89EC, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x0000
        static Parameters par = new Parameters(16, 0x1021, 0x89EC, true, true, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}