JOYO-J --> 做客户端（工具做服务器）
总共 27 个设备 --> 
功能码86H --> 
全遥信·[监控--> 五防机]  
虚遥信·[五防机--> 监控]
							 *     *  *     *           *
17:46:33.481 发送: 90 EB 90 EB 86 06 00 01 00 00 00 00 00 
                                               
17:46:38.589 发送: 90 EB 90 EB 86 06 00 01 00 01 00 00 00 
                                               
17:46:43.698 发送: 90 EB 90 EB 86 06 00 01 00 03 00 00 00 
                                               
17:46:48.803 发送: 90 EB 90 EB 86 06 00 01 00 07 00 00 00 
                                               
17:46:53.911 发送: 90 EB 90 EB 86 06 00 01 00 0F 00 00 00 
                                               
17:46:59.022 发送: 90 EB 90 EB 86 06 00 01 00 1F 00 00 00 
                                               
17:47:04.131 发送: 90 EB 90 EB 86 06 00 01 00 3F 00 00 00 
                                               
17:47:09.240 发送: 90 EB 90 EB 86 06 00 01 00 7F 00 00 00 
                                               
17:47:24.565 发送: 90 EB 90 EB 86 06 00 01 00 FF 03 00 00 
                                               
17:47:39.894 发送: 90 EB 90 EB 86 06 00 01 00 FF FF FF 03 
                                   
测试虚遥信		   90 EB 90 EB 86 06 00 01 00 1F 00 00 00


所有遥信开票闭锁和解锁报文：（五防方向）
        /// <summary>
        /// 打包主动发送全解锁和全闭锁命令数据帧 add by lirui 2014-6-8
        /// </summary>
        public NanRuiFrame PackageAllUnLockData(bool UnlockOrLock)
        {
            int RTUNo = XmlPara.StationNum;
            byte allowOperResult = 0;
            if (UnlockOrLock) //解锁
            {
                allowOperResult = 0xAA;//AAH或55H解锁，FFH闭锁
            }
            else//闭锁
            {
                allowOperResult = 0xFF;//AAH或55H解锁，FFH闭锁
            }

            int pos = 0;
            byte[] sendText = new byte[3];
            byte[] statBytes = TypeConvertHelper.UShortToBytes((ushort)RTUNo, NeedAdjustBytesSeq);//监控请求操作的站号
            statBytes.CopyTo(sendText, pos);
            pos += 2;
            sendText[pos] = allowOperResult;
            NanRuiFrame frame = this.CreateFrame((byte)EnumFunctionCode.AllYXJBSCode, sendText);
            return frame;
        } 								   
		
RecevingDebugText
完成规约遥信的收发


public partial class ProtocolNanRuiBase : ProtocolBase, IProtocol
    {

   /// <summary>
        /// 接收站Sn表 --> 接收设备列表 
        /// </summary>
        private StationSnTableList receiveStationSnTables = null;
	}
	