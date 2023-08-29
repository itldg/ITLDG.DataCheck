﻿using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC10_CDMA2000 : Plugin
    {
        public PluginCRC10_CDMA2000()
        {
            Name = "CRC-10/CDMA2000";
        }
        //算法：CRC-10/CDMA2000, 多项式：0x03D9, 宽度：10,  初始值：0x03FF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x0000
        static Parameters par = new Parameters(10, 0x03D9, 0x03FF, false, false, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}