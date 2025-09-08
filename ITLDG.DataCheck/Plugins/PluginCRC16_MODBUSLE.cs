using CRC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCRC16_MODBUS_LE : Plugin
    {
        public PluginCRC16_MODBUS_LE()
        {
            Name = "CRC-16/MODBUS-LE";

        }
        //算法：CRC-16/MODBUS, 多项式：0x8005, 宽度：16 初始值：0xFFFF, 数据反转(RefIn)：True, 数据反转(RefOut)：True, 结果异或值：0x0000
        static Parameters par = new Parameters(16, 0x8005, 0xFFFF, true, true, 0x0000);
        static Crc crc = new Crc(par);
        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = crc.CheckByte(DataByte);
            if (r != null && r.Length >= 2) {
                byte tmp = r[r.Length - 1];
                r[r.Length - 1] = r[r.Length - 2];
                r[r.Length - 2] = tmp;
            }
            return r;
        }
    }
}
