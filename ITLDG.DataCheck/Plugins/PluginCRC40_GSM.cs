using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC40_GSM : Plugin
    {
        public PluginCRC40_GSM()
        {
            Name = "CRC-40/GSM";
        }
        //算法：CRC-40/GSM, 多项式：0x0004820009, 宽度：40,  初始值：0x0000000000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0xFFFFFFFFFF
        static Parameters par = new Parameters(40, 0x0004820009, 0x0000000000, false, false, 0xFFFFFFFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}