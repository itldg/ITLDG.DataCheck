using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_DNP : Plugin
    {
        public PluginCRC16_DNP()
        {
            Name = "CRC-16/DNP";
        }
        //算法：CRC-16/DNP, 多项式：0x3D65, 宽度：16,  初始值：0x0000, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0xFFFF
        static Parameters par = new Parameters(16, 0x3D65, 0x0000, true, true, 0xFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}