# 数据校验

`ITLDG.DataCheck` 为数据校验核心,提供常见的串口校验:`BCC`,`CheckSum`,`LRC`,`CRC`等等

`Example` 为调用该核心实现的校验推算

`PluginExample` 插件示例,可以自己编写插件来为推算提供更多可能

## 界面预览

![界面预览](/docs/main.png)

## 库使用示例

使用 `Nuget` 安装 `ITLDG.DataCheck`

```csharp
ITLDG.DataCheck.Plugins.PluginCRC16_MODBUS crc16 = new ITLDG.DataCheck.Plugins.PluginCRC16_MODBUS();
byte[] result = crc16.CheckData(tempData);
```

## 已实现校验列举

-   BCC(Block Check Character/信息组校验码)
-   CheckSum 累加和校验
-   CheckSum 累加和校验( 0x100 - Sum 的差值)
-   CheckSum 累加和校验(0xFFFF)( 0x10000 - Sum 的差值)
-   CheckSum 累加和校验(最大 65535)
-   CRC-10/ATM
-   CRC-10/CDMA2000
-   CRC-10/GSM
-   CRC-11/FLEXRAY
-   CRC-11/UMTS
-   CRC-12/CDMA2000
-   CRC-12/DECT
-   CRC-12/GSM
-   CRC-12/UMTS
-   CRC-13/BBC
-   CRC-14/DARC
-   CRC-14/GSM
-   CRC-15/CAN
-   CRC-15/MPT1327
-   CRC-16/AUG-CCITT
-   CRC-16/BUYPASS
-   CRC-16/CCITT-FALSE
-   CRC-16/CDMA2000
-   CRC-16/CMS
-   CRC-16/CRC-A
-   CRC-16/DDS-110
-   CRC-16/DECT-R
-   CRC-16/DECT-X
-   CRC-16/DNP
-   CRC-16/EN13757
-   CRC-16/GENIBUS
-   CRC-16/GSM
-   CRC-16/IBM
-   CRC-16/KERMIT
-   CRC-16/LJ1200
-   CRC-16/MAXIM
-   CRC-16/MCRF4XX
-   CRC-16/MODBUS
-   CRC-16/MODBUS 默纳克 7000
-   CRC-16/OPENSAFETY-A
-   CRC-16/OPENSAFETY-B
-   CRC-16/PROFIBUS
-   CRC-16/RIELLO
-   CRC-16/T10-DIF
-   CRC-16/TELEDISK
-   CRC-16/TMS37157
-   CRC-16/USB
-   CRC-16/X-25
-   CRC-16/XMODEM
-   CRC-17/CAN-FD
-   CRC-21/CAN-FD
-   CRC-24/BLE
-   CRC-24/FLEXRAY-A
-   CRC-24/FLEXRAY-B
-   CRC-24/INTERLAKEN
-   CRC-24/LTE-A
-   CRC-24/LTE-B
-   CRC-24/OPENPGP
-   CRC-24/OS-9
-   CRC-3/GSM
-   CRC-3/ROHC
-   CRC-30/CDMA
-   CRC-31/PHILLIPS
-   CRC-32
-   CRC-32/AUTOSAR
-   CRC-32/BZIP2
-   CRC-32/C
-   CRC-32/D
-   CRC-32/JAMCRC
-   CRC-32/MPEG-2
-   CRC-32/POSIX
-   CRC-32/Q
-   CRC-32/XFER
-   CRC-4/INTERLAKEN
-   CRC-4/ITU
-   CRC-40/GSM
-   CRC-5/EPC
-   CRC-5/ITU
-   CRC-5/USB
-   CRC-6/CDMA2000-A
-   CRC-6/CDMA2000-B
-   CRC-6/DARC
-   CRC-6/GSM
-   CRC-6/ITU
-   CRC-64/ECMA-182
-   CRC-64/GO-ISO
-   CRC-64/WE
-   CRC-64/XZ
-   CRC-7
-   CRC-7/ROHC
-   CRC-7/UMTS
-   CRC-8/AUTOSAR
-   CRC-8/BLUETOOTH
-   CRC-8/CDMA2000
-   CRC-8/DARC
-   CRC-8/DVB-S2
-   CRC-8/EBU
-   CRC-8/GSM-A
-   CRC-8/GSM-B
-   CRC-8/I-CODE
-   CRC-8/ITU
-   CRC-8/LTE
-   CRC-8/MAXIM
-   CRC-8/NRSC-5
-   CRC-8/OPENSAFETY
-   CRC-8/ROHC
-   CRC-8/SAE-J1850
-   CRC-8/SMBUS
-   CRC-8/WCDMA
-   LRC 纵向冗余校验（Longitudinal Redundancy Check）
