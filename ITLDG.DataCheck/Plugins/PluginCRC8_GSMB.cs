using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC8_GSMB : Plugin
    {
        public PluginCRC8_GSMB()
        {
            Name = "CRC-8/GSM-B";
        }
        //算法：CRC-8/GSM-B, 多项式：0x49, 宽度：8,  初始值：0x00, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0xFF
        static Parameters par = new Parameters(8, 0x49, 0x00, false, false, 0xFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}