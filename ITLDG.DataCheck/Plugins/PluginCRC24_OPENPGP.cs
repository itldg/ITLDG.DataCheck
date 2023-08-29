using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC24_OPENPGP : Plugin
    {
        public PluginCRC24_OPENPGP()
        {
            Name = "CRC-24/OPENPGP";
        }
        //算法：CRC-24/OPENPGP, 多项式：0x864CFB, 宽度：24,  初始值：0xB704CE, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x000000
        static Parameters par = new Parameters(24, 0x864CFB, 0xB704CE, false, false, 0x000000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}