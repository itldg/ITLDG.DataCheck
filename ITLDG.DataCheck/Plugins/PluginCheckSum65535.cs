using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck.Plugins
{
    public class PluginCheckSum65535 : Plugin
    {
        public PluginCheckSum65535()
        {
            Name = "CheckSum 累加和校验(最大65535)";
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
                sum = sum>65535? sum-65535:sum;
            }
            return CommonConvert.HexToByte(sum.ToString("X04")); ;
        }
    }
}
