using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC21_CANFD : Plugin
    {
        public PluginCRC21_CANFD()
        {
            Name = "CRC-21/CAN-FD";
        }
        //算法：CRC-21/CAN-FD, 多项式：0x102899, 宽度：21,  初始值：0x000000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x000000
        static Parameters par = new Parameters(21, 0x102899, 0x000000, false, false, 0x000000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}