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
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using MyRapid.Code;

namespace MyRapid.Proxy
{
    public class AuthenticationInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            MessageHeader hdUserId = MessageHeader.CreateHeader("UserId", "Token", Code.Token.UserId);
            MessageHeader hdPassword = MessageHeader.CreateHeader("Password", "Token", Code.Token.Password);
            MessageHeader hHostName = MessageHeader.CreateHeader("HostName", "Token", Environment.MachineName);
            //HostName
            //MessageHeader hdToken = MessageHeader.CreateHeader("Token", "tempuri.org", AuthenticationToken.Token);
            //string license = new Guid().ToString();
            //MessageHeader hdToken = MessageHeader.CreateHeader("token", "http://tempuri.org", license);
            request.Headers.Add(hdUserId);
            request.Headers.Add(hdPassword);
            request.Headers.Add(hHostName);
            return null;
        }
    }
}