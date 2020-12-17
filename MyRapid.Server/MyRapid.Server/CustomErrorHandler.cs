/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
namespace MyRapid.Server.Extension
{
    public class CustomErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            //return false; // typeof(FaultException) != error.GetType();
            return true;
        }
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            // 1、封装异常
            FaultException fex;
            Type t = error.GetType();
            if (typeof(FaultException) != error.GetType())
            {
                fex = new FaultException(error.Message);
            }
            else
            {
                fex = (FaultException)error;
            }

            // 2、产生 MessageFault
            MessageFault msg_fault = fex.CreateMessageFault();
            // 3、产生新的消息
            fault = Message.CreateMessage(version, msg_fault, fex.Action);
        }
    }
}