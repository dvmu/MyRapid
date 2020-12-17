/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
namespace MyRapid.Server
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IMainService
    {
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        DataTable Open(string WorkSet_Id, List<MyParameter> sqlParameters);
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        DataTable Save(string WorkSet_Id, DataTable dt, List<MyParameter> sqlParameters);
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        int Execute(string WorkSet_Id, List<MyParameter> sqlParameters, string CRUD = "R");
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        string GetToken(string userName, string password);
        [OperationContract(IsInitiating = false, IsTerminating = true, IsOneWay = true)]
        void LoginOut();
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        string SaveFile(byte[] file, string fileName = "");
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        byte[] GetFile(string fileName);
    }
}
