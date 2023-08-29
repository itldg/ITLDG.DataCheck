using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC8_GSMA : Plugin
    {
        public PluginCRC8_GSMA()
        {
            Name = "CRC-8/GSM-A";
        }
        //算法：CRC-8/GSM-A, 多项式：0x1D, 宽度：8,  初始值：0x00, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x00
        static Parameters par = new Parameters(8, 0x1D, 0x00, false, false, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}