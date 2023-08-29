using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_GSM : Plugin
    {
        public PluginCRC16_GSM()
        {
            Name = "CRC-16/GSM";
        }
        //算法：CRC-16/GSM, 多项式：0x1021, 宽度：16,  初始值：0x0000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0xFFFF
        static Parameters par = new Parameters(16, 0x1021, 0x0000, false, false, 0xFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}