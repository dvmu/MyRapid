/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.Server.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
namespace MyRapid.Server.Extension
{
    public class CustomErrorBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            return;
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            return; //无需处理
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            ChannelDispatcher cndisp = endpointDispatcher.ChannelDispatcher;
            // 加入自定义的错误处理程序
            CustomErrorHandler cehdlr = null;
            cehdlr = (CustomErrorHandler)cndisp.ErrorHandlers.FirstOrDefault();
            if (cehdlr == null)
            {
                cehdlr = new CustomErrorHandler();
            }
            cndisp.ErrorHandlers.Add(cehdlr);
        }
        public void Validate(ServiceEndpoint endpoint)
        {
            return;
        }
    }
}