using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC10_GSM : Plugin
    {
        public PluginCRC10_GSM()
        {
            Name = "CRC-10/GSM";
        }
        //算法：CRC-10/GSM, 多项式：0x0175, 宽度：10,  初始值：0x0000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x03FF
        static Parameters par = new Parameters(10, 0x0175, 0x0000, false, false, 0x03FF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}