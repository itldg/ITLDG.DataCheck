using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC3_GSM : Plugin
    {
        public PluginCRC3_GSM()
        {
            Name = "CRC-3/GSM";
        }
        //算法：CRC-3/GSM, 多项式：0x03, 宽度：3,  初始值：0x00, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x07
        static Parameters par = new Parameters(3, 0x03, 0x00, false, false, 0x07);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}