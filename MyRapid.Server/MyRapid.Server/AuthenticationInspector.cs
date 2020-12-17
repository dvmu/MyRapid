/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using MyRapid.Code;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Text;
using System.Xml;
using MyRapid.Server;

namespace MyRapid.Server.Extension
{

    public class AuthenticationInspector : IDispatchMessageInspector
    {

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            return null;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            MessageBuffer requstBuffer = reply.CreateBufferedCopy(int.MaxValue);
            Message msg = requstBuffer.CreateMessage();
            reply = requstBuffer.CreateMessage();
        }


    }




}