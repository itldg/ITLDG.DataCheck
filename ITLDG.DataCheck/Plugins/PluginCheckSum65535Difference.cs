using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCheckSum65535Difference : Plugin
    {
        public PluginCheckSum65535Difference()
        {
            Name = "CheckSum 累加和校验(0xFFFF)( 0x10000 - Sum 的差值)";
        }

        public override byte[] CheckData(byte[] DataByte)
        {
            byte[] r = allAdd(DataByte);
            return r;
        }

        /// <summary>
        /// 累加和校验
        /// </summary>
        public byte[] allAdd(byte[] buffer, int start = 0, int len = 0)
        {
            if (buffer == null || buffer.Length == 0) return null;
            if (start < 0) return null;
            if (len == 0) len = buffer.Length - start;
            int length = start + len;
            if (length > buffer.Length) return null;
            int sum = 0;
            for (int i = start; i < len; i++)
            {
                sum += buffer[i];
                sum = sum > 65535 ? sum - 65535 : sum;
            }
            sum = 0x10000 - sum;
            return CommonConvert.HexToByte(sum.ToString("X04")); ;
        }
    }
}
