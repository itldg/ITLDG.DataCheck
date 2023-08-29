using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC17_CANFD : Plugin
    {
        public PluginCRC17_CANFD()
        {
            Name = "CRC-17/CAN-FD";
        }
        //算法：CRC-17/CAN-FD, 多项式：0x1685B, 宽度：17,  初始值：0x00000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x00000
        static Parameters par = new Parameters(17, 0x1685B, 0x00000, false, false, 0x00000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}