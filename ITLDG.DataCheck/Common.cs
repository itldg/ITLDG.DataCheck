using System;
using System.Collections.Generic;
using System.Text;

namespace ITLDG.DataCheck
{
    public class Common
    {
        public static void ByteResultToCheckResult(ref List<CheckResult> list, byte[] Result)
        {

            try
            {
                string hex = Result.GetString_HEX("");
                list.Add(new CheckResult("校验结果 HEX", hex, "hex"));
                list.Add(new CheckResult("校验结果 HEX2ASCII", hex.GetString_HEX2ASCII(""), "hex"));

                var num = Convert.ToUInt64(hex, 16);
                string str = num.ToString();
                list.Add(new CheckResult("校验结果 Dec", str, "dec"));
                list.Add(new CheckResult("校验结果 Dec2ASCII", str.GetString_HEX2ASCII(""), "hex"));

            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        ///    纵向冗余校验（Longitudinal Redundancy Check，简称：LRC）是通信中常用的一种校验形式，也称LRC校验或纵向校验。 它是一种从纵向通道上的特定比特串产生校验比特的错误检测方法。在行列格式中（如磁带），LRC经常是与VRC一起使用，这样就会为每个字符校验码。在工业领域Modbus协议Ascii模式采用该算法。 LRC计算校验码,具体算法如下：
        /// 1、对需要校验的数据（2n个字符）两两组成一个16进制的数值求和。
        /// 2、将求和结果与256求模。
        /// 3、用256减去所得模值得到校验结果（另一种方法：将模值按位取反然后加1）。
        /// </summary>
        public static byte[] Lrc(byte[] buffer, int start = 0, int len = 0)
        {
            if (buffer == null || buffer.Length == 0) return null;
            if (start < 0) return null;
            if (len == 0) len = buffer.Length - start;
            int length = start + len;
            if (length > buffer.Length) return null;
            byte lrc = 0;// Initial value
            for (int i = start; i < len; i++)
            {
                lrc += buffer[i];
            }
            lrc = (byte)((lrc ^ 0xFF) + 1);
            return new byte[] { lrc };
        }
        /// <summary>
        /// BCC(Block Check Character/信息组校验码)，因校验码是将所有数据异或得出，故俗称异或校验。具体算法是：将每一个字节的数据（一般是两个16进制的字符）进行异或后即得到校验码。
        /// </summary>
        public static byte[] Bcc(byte[] buffer, int start = 0, int len = 0)
        {
            if (buffer == null || buffer.Length == 0) return null;
            if (start < 0) return null;
            if (len == 0) len = buffer.Length - start;
            int length = start + len;
            if (length > buffer.Length) return null;
            byte bcc = 0;// Initial value
            for (int i = start; i < len; i++)
            {
                bcc ^= buffer[i];
            }
            return new byte[] { bcc };
        }

        /// <summary>
        /// 累加和校验
        /// </summary>
        public static byte[] AllAdd(byte[] buffer, int start = 0, int len = 0)
        {
            if (buffer == null || buffer.Length == 0) return null;
            if (start < 0) return null;
            if (len == 0) len = buffer.Length - start;
            int length = start + len;
            if (length > buffer.Length) return null;
            byte bcc = 0;// Initial value
            for (int i = start; i < len; i++)
            {
                bcc += buffer[i];
            }
            return new byte[] { bcc };
        }
    }

    public class CommonConvert
    {
        public static byte[] StrToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
        /// <summary>
        /// 转换十六进制字符串到字节数组："41 42 43"--{0x41,0x42,0x43}
        /// </summary>
        /// <param name="msg">待转换字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");//移除空格
            byte[] comBuffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
            {
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            }
            return comBuffer;
        }

        /// <summary>
        /// 转换字节数组到十六进制字符串:{0x41,0x42,0x43}--"414243"
        /// </summary>
        /// <param name="comByte">待转换字节数组</param>
        /// <returns>十六进制字符串</returns>
        public static string ByteToHex(byte[] comByte)
        {
            string returnStr = "";
            if (comByte != null)
            {
                for (int i = 0; i < comByte.Length; i++)
                {
                    returnStr += comByte[i].ToString("X2");
                }
                // returnStr = returnStr.Replace(" ", "");
            }
            return returnStr;
        }

        /// <summary>
        /// Hex转换成Ascii
        /// 将ASC码转换成字符串，如："414243"转换为"ABC"
        /// </summary>
        /// <param name="hex"></param>
        /// <returns>Ascii信息</returns>
        /// <exception cref="Exception"></exception>
        public static string HexToAscii(string hex)
        {
            string str = "";
            hex = hex.Replace(" ", "");
            int j = hex.Length;

            for (int i = 0; i < j - 1; i += 2)
            {
                int asciiCode1 = Convert.ToInt32(hex.Substring(i, 2), 16);

                if (asciiCode1 >= 0x00 && asciiCode1 <= 0xFF)
                {
                    ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                    byte[] byteArray = new byte[] { (byte)asciiCode1 };
                    str += asciiEncoding.GetString(byteArray);
                }
                else
                {
                    throw new Exception("ASCII Code is not valid.");
                }

            }
            return str;
        }
        /// <summary>
        /// Ascii转Hex
        /// 将字符串转换成ASC码，如："ABC"转换为"414243"
        /// </summary>
        /// <param name="asciiCode">Ascii代码</param>
        /// <returns>返回的hex信息</returns>
        //public static string AsciiToHex(string asciiCode)
        //{

        //    byte[] ba = Encoding.Default.GetBytes(asciiCode);
        //    StringBuilder sb = new StringBuilder();
        //    foreach (byte b in ba)
        //    {
        //        sb.Append(b.ToString("X2"));
        //    }
        //    return sb.ToString();

        //}
    }

    public enum BitOperation
    {
        AND,
        OR,
        //NOT,
        //NAND,
        //NOR,
        XOR

    }
    public class CommonBit
    {
        public static string ToHex(ulong Num)
        {
            string hex = Num.ToString("X2");
            if (hex.Length % 2 != 0)
            {
                hex = "0" + hex;
            }
            return hex;
        }
        /// <summary>
        /// & 位与 AND
        /// </summary>
        public static string HexAND(string hex1, string hex2)
        {
            ulong i1 = Convert.ToUInt64(hex1, 16);
            ulong i2 = Convert.ToUInt64(hex2, 16);
            ulong res = i1 & i2;
            return CommonBit.ToHex(res);
        }

        /// <summary>
        /// | 位或 OR
        /// </summary>
        public static string HexOR(string hex1, string hex2)
        {
            ulong i1 = Convert.ToUInt64(hex1, 16);
            ulong i2 = Convert.ToUInt64(hex2, 16);
            ulong res = i1 | i2;
            return CommonBit.ToHex(res);
        }

        /// <summary>
        /// ^ 异或 XOR
        /// </summary>
        public static string HexXOR(string hex1, string hex2)
        {
            ulong i1 = Convert.ToUInt64(hex1, 16);
            ulong i2 = Convert.ToUInt64(hex2, 16);
            ulong res = i1 ^ i2;
            return CommonBit.ToHex(res);
        }

        /// <summary>
        /// ~ 求反 NOR
        /// </summary>
        public static string HexNOR(string hex)
        {
            ulong i1 = Convert.ToUInt64(hex, 16);
            ulong res = ~i1;
            string newHex = res.ToString("X02");
            return newHex.Substring(newHex.Length-hex.Length, hex.Length);
        }

        /// <summary>
        /// 位移测试
        /// </summary>
        /// <param name="hex">结果HEX</param>
        /// <param name="hex2">要改变的HEX</param>
        /// <returns>位移位数,正数左移,负数右移 0为失败</returns>
        public static List<int> DisplacementCheck(string hex, string hex2)
        {
            List<int> list = new List<int>();
            long result = Convert.ToInt64(hex, 16);

            long result2 = Convert.ToInt64(hex2, 16);
            int max = hex2.Length * 4;
            for (int i = 1; i <= max; i++)
            {
                long temp = result2 << i;
                if (temp == result)
                {
                    list.Add(i);
                }
            }
            for (int i = 1; i <= max; i++)
            {
                long temp = result2 >> i;
                if (temp == result)
                {
                    list.Add(0 - i);
                }
            }
            return list;
        }

        /// <summary>
        /// 位移
        /// </summary>
        /// <param name="hex">要操作的HEX</param>
        /// <param name="num">位移位数,正数左移,负数右移 0不操作</param>
        /// <returns></returns>
        public static string Displacement(string hex, int num)
        {
            ulong result = Convert.ToUInt64(hex, 16);
            if (num > 0)
            {
                result <<= num;
            }
            else if (num < 0)
            {
                num = 0 - num;
                result >>= num;
            }
            return ToHex(result);
        }
    }
}
