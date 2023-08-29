﻿using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC8_SAEJ1850 : Plugin
    {
        public PluginCRC8_SAEJ1850()
        {
            Name = "CRC-8/SAE-J1850";
        }
        //算法：CRC-8/SAE-J1850, 多项式：0x1D, 宽度：8,  初始值：0xFF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0xFF
        static Parameters par = new Parameters(8, 0x1D, 0xFF, false, false, 0xFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}