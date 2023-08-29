using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC13_BBC : Plugin
    {
        public PluginCRC13_BBC()
        {
            Name = "CRC-13/BBC";
        }
        //算法：CRC-13/BBC, 多项式：0x1CF5, 宽度：13,  初始值：0x0000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x0000
        static Parameters par = new Parameters(13, 0x1CF5, 0x0000, false, false, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}