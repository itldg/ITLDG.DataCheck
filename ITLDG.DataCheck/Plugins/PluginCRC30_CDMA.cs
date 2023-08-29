using CRC;
using System.Collections.Generic;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC30_CDMA : Plugin
    {
        public PluginCRC30_CDMA()
        {
            Name = "CRC-30/CDMA";
        }
        //算法：CRC-30/CDMA, 多项式：0x2030B9C7, 宽度：30,  初始值：0x3FFFFFFF, 数据反转(RefIn)：False, 数据反转(RefOut)：False, 结果异或值：0x3FFFFFFF
        static Parameters par = new Parameters(30, 0x2030B9C7, 0x3FFFFFFF, false, false, 0x3FFFFFFF);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            return r;
        }
    }
}