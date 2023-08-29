using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC5_EPC : Plugin
    {
        public PluginCRC5_EPC()
        {
            Name = "CRC-5/EPC";
        }
        //算法：CRC-5/EPC, 多项式：0x09, 宽度：5,  初始值：0x09, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x00
        static Parameters par = new Parameters(5, 0x09, 0x09, false, false, 0x00);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}