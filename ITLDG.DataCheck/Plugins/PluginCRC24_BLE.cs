using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC24_BLE : Plugin
    {
        public PluginCRC24_BLE()
        {
            Name = "CRC-24/BLE";
        }
        //算法：CRC-24/BLE, 多项式：0x00065B, 宽度：24,  初始值：0x555555, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x000000
        static Parameters par = new Parameters(24, 0x00065B, 0x555555, true, true, 0x000000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}