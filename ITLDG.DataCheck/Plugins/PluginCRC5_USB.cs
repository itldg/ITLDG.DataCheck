using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC5_USB : Plugin
    {
        public PluginCRC5_USB()
        {
            Name = "CRC-5/USB";
        }
        //算法：CRC-5/USB, 多项式：0x05, 宽度：5,  初始值：0x1F, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x1F
        static Parameters par = new Parameters(5, 0x05, 0x1F, true, true, 0x1F);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}