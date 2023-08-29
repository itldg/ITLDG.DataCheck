using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_CMS : Plugin
    {
        public PluginCRC16_CMS()
        {
            Name = "CRC-16/CMS";
        }
        //算法：CRC-16/CMS, 多项式：0x8005, 宽度：16,  初始值：0xFFFF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x0000
        static Parameters par = new Parameters(16, 0x8005, 0xFFFF, false, false, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}