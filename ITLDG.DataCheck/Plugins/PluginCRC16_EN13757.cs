using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_EN13757 : Plugin
    {
        public PluginCRC16_EN13757()
        {
            Name = "CRC-16/EN13757";
        }
        //算法：CRC-16/EN13757, 多项式：0x3D65, 宽度：16,  初始值：0x0000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0xFFFF
        static Parameters par = new Parameters(16, 0x3D65, 0x0000, false, false, 0xFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}