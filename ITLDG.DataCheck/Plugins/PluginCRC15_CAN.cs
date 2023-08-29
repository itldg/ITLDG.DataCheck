﻿using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC15_CAN : Plugin
    {
        public PluginCRC15_CAN()
        {
            Name = "CRC-15/CAN";
        }
        //算法：CRC-15/CAN, 多项式：0x4599, 宽度：15,  初始值：0x0000, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x0000
        static Parameters par = new Parameters(15, 0x4599, 0x0000, false, false, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}