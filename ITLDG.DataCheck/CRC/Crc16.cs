using System;
using System.Linq;

namespace ITLDG.DataCheck
{
    public class Crc16
    {
        public static ushort CRC(Crc16Parameters parameters, byte[] buffer)
        {
            return CRC(buffer, parameters.Poly, parameters.Init, parameters.RefIn, parameters.RefOut, parameters.LittleEndian, parameters.XorOut);

        }
        public static ushort CRC(byte[] buffer, uint poly = 0x8005, uint init = 0xFFFF, bool refIn = false, bool refOut = false, bool littleEndian = false, uint xorOut = 0x0000)
        {
            int length = buffer.Length;
            uint crc = init;
            byte data;
            int i;
            for (int j = 0; j < length; j++)
            {
                data = buffer[j];

                //输入反转
                if (refIn)
                {
                    data = (byte)Reverse8(data);
                }

                crc = (uint)(crc ^ (data << 8));
                for (i = 0; i < 8; i++)
                {
                    if ((crc & 0x8000) == 0x8000)//16位 0x8000  8位 0x80
                    {
                        crc = (crc << 1) ^ poly;
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
            }
            //输出反转
            if (refOut)
            {
                crc = Reverse16(crc);
            }
            if (littleEndian)
            {
                byte[] b = BitConverter.GetBytes((ushort)crc);
                Array.Reverse(b);
                crc = BitConverter.ToUInt16(b, 0);
            }
            crc = crc ^ xorOut;//结果异或
            return (ushort)crc;
        }

        static uint Reverse16(uint data)
        {
            byte i;
            uint temp = 0;
            for (i = 0; i < 16; i++)
            {
                temp |= ((data >> i) & 0x01) << (15 - i);
            }
            return temp;
        }
        static byte Reverse8(byte data)
        {
            byte i;
            byte temp = 0;
            for (i = 0; i < 8; i++)
            {
                temp = (byte)(temp | (((data >> i) & 0x01) << (7 - i)));
            }
            return temp;
        }
    }


    public class Crc16Parameters
    {
        /// <summary>
        /// Crc16校验参数
        /// </summary>
        /// <param name="poly">多项式 POLY（Hex）</param>
        /// <param name="init">初始值 INIT（Hex）</param>
        /// <param name="refIn">输入数据反转（REFIN）</param>
        /// <param name="refOut">输出数据反转（REFOUT）</param>
        /// <param name="littleEndian">小端字节序</param>
        /// <param name="xorOut">结果异或值 XOROUT（Hex）</param>
        public Crc16Parameters(uint poly, uint init, bool refIn, bool refOut, bool littleEndian, uint xorOut)
        {
            Init = init;
            Poly = poly;
            RefIn = refIn;
            RefOut = refOut;
            XorOut = xorOut;
            LittleEndian = littleEndian;
        }
        /// <summary>
        /// 初始值
        /// </summary>
        public uint Init { get; private set; }
        /// <summary>
        /// 校验配置
        /// </summary>
        public string Name
        {
            get
            {
                return $"{Poly.ToString("X04")},{Init.ToString("X04")},{RefIn},{RefOut},{LittleEndian}";
            }
        }
        /// <summary>
        /// 多项式
        /// </summary>
        public uint Poly { get; private set; }
        /// <summary>
        /// 输入反转
        /// </summary>
        public bool RefIn { get; private set; }

        /// <summary>
        /// 输出反转
        /// </summary>
        public bool RefOut { get; private set; }
        /// <summary>
        /// 结果异或
        /// </summary>
        public uint XorOut { get; private set; }
        /// <summary>
        /// 小端字节序
        /// </summary>
        public bool LittleEndian { get; private set; }
    }
}
