using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC14_GSM : Plugin
    {
        public PluginCRC14_GSM()
        {
            Name = "CRC-14/GSM";
        }
        //算法：CRC-14/GSM, 多项式：0x202D, 宽度：14,  初始值：0x0000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x3FFF
        static Parameters par = new Parameters(14, 0x202D, 0x0000, false, false, 0x3FFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}