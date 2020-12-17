/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.Proxy.MainService;
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.ServiceModel;
using static MyRapid.SysEntity.Sys_Enum;
using System.Linq;

namespace MyRapid.Proxy
{
    public static class BaseService
    {
        private static MainServiceClient _mService;
        private static MainServiceClient mService
        {
            get
            {
                //MainServiceClient _mService = new MainServiceClient() ; 
                if (_mService == null)
                {
                    _mService = new MainServiceClient();
                    _mService.Endpoint.Behaviors.Add(new AuthenticationBehavior());
                    _mService.Open();
                }
                if (_mService.State.Equals(CommunicationState.Faulted))
                {
                    Provider.SysUser = null;// ("SysUser");
                    _mService.Abort();
                    _mService = new MainServiceClient();
                    _mService.Open();
                }
                if (_mService.State != CommunicationState.Opened)
                {
                    //
                }
                return _mService;
            }
        }

        public static bool IsFaulted
        {
            get
            {
                return _mService.State.Equals(CommunicationState.Faulted);
            }
        }
        #region 辅助函数

        /// <summary>
        /// 加入参数列表
        /// </summary>
        /// <param name="myParameters">参数数组</param>
        /// <param name="type">类型</param>
        /// <param name="name">变量名</param>
        /// <param name="value">变量值</param>
        public static List<MyParameter> Add(this List<MyParameter> myParameters, string name, DbType type, object value, string source)
        {
            if (!name.StartsWith("@"))
                name = "@" + name;
            MyParameter myParameter = myParameters.Find(p => p.Name.Equals(name));
            if (myParameter == null)
            {
                myParameter = new MyParameter();
                myParameters.Add(myParameter);
            }

            myParameter.Name = name;
            myParameter.Type = (int)type;
            //myParameter.Value = value ?? DBNull.Value ;
            if (!string.IsNullOrEmpty(source))
            {
                myParameter.Source = source;
            }
            if (value != null)
            {
                myParameter.Value = value;
            }
            return myParameters;
        }
        /// <summary>
        /// 加入参数列表
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="myParameters">参数</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public static List<MyParameter> Add<T>(this List<MyParameter> myParameters, T entity)
        {
            if (entity == null)
            {
                return null;
            }
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                MyParameter myParameter = myParameters.Find(p => p.Name.Trim('@').Equals(propertyInfo.Name));
                if (myParameter != null)
                {
                    myParameter.Value = propertyInfo.GetValue(entity, null);
                }
                else
                {
                    myParameters.Add("@" + propertyInfo.Name, ConvertHelper.GetDbType(propertyInfo.PropertyType), propertyInfo.GetValue(entity, null), null);
                }
            }
            return myParameters;
        }
        /// <summary>
        /// 检查配置
        /// </summary>
        /// <param name="ConfigurationName">配置名称</param>
        /// <returns></returns>
        public static string CheckConfiguration(string ConfigurationName)
        {
            try
            {
                if (string.IsNullOrEmpty(ConfigurationName)) return string.Empty;
                List<Sys_Configuration> SysConfigurations = new List<Sys_Configuration>();
                SysConfigurations = (List<Sys_Configuration>)Provider.Get("SysConfiguration");
                Sys_Configuration SysConfiguration = SysConfigurations.FirstOrDefault(c => c.Configuration_Name.ToUpper() == ConfigurationName.ToUpper());
                if (SysConfiguration != null)
                {
                    return SysConfiguration.Configuration_Value;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
        private static void Authentication(Exception ex)
        {
            if (ex.Message == "Authentication")
                Provider.SysUser = null;// ("SysUser");
        }
        #region Object Open_Sys_WorkSet
        /// <summary>
        /// 查询WorkSet
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="WorkSet_Id">表格编号</param>
        /// <param name="entity">实体参数</param>
        /// <returns></returns>
        public static object Get<T>(string WorkSet_Id, T entity)
        {
            List<MyParameter> myParameters = new List<MyParameter>();
            try
            {
                myParameters.Add(entity);
                return Get(WorkSet_Id, myParameters);
            }
            catch (FaultException ex)
            {
                //BaseService.SaveLog(ex.Message, ex.ToJson(), (byte)Sys_Log_Type.FaultException, string.Empty, WorkSet_Id.ToString());
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询WorkSet
        /// </summary>
        /// <param name="WorkSet_Name">表格名称</param>
        /// <param name="myParameters">参数列表</param>
        /// <returns></returns>
        public static object Get(string WorkSet_Name, List<MyParameter> myParameters)
        {
            try
            {
                DataTable dt = mService.Open(WorkSet_Name, myParameters);
                //BaseService.SaveLog("Open", WorkSet_Name, (byte)Sys_Log_Type.Operation, string.Empty, WorkSet_Name);
                if (dt != null && dt.Rows.Count > 0)
                    return dt.Rows[0][0];
                return null;
            }
            catch (FaultException ex)
            {
                Authentication(ex);
                //BaseService.SaveLog(ex.Message, ex.ToJson(), (byte)Sys_Log_Type.FaultException, string.Empty, WorkSet_Name);
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion

        #region DataTable Open_Sys_WorkSet
        /// <summary>
        /// 查询WorkSet
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="WorkSet_Name">表格名称</param>
        /// <param name="entity">实体参数</param>
        /// <returns></returns>
        public static DataTable Open<T>(string WorkSet_Name, T entity)
        {
            List<MyParameter> myParameters = new List<MyParameter>();
            try
            {
                myParameters.Add(entity);
                return Open(WorkSet_Name, myParameters);
            }
            catch (FaultException ex)
            {
                //BaseService.SaveLog(ex.Message, ex.ToJson(), (byte)Sys_Log_Type.FaultException, string.Empty, WorkSet_Name);
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 查询WorkSet
        /// </summary>
        /// <param name="WorkSet_Name">表格名称</param>
        /// <param name="myParameters">参数列表</param>
        /// <returns></returns>
        public static DataTable Open(string WorkSet_Name, List<MyParameter> myParameters)
        {
            try
            {
                DataTable dt = mService.Open(WorkSet_Name, myParameters);
                //BaseService.SaveLog("Open", WorkSet_Name, (byte)Sys_Log_Type.Operation, string.Empty, WorkSet_Name);
                return dt;
            }
            catch (FaultException ex)
            {
                Authentication(ex);
                //BaseService.SaveLog(ex.Message, ex.ToJson(), (byte)Sys_Log_Type.FaultException, string.Empty, WorkSet_Name);
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
        #region List<T> Open_Sys_WorkSet
        /// <summary>
        /// 查询WorkSet
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="WorkSet_Id">表格编号</param>
        /// <param name="myParameters">参数列表</param>
        /// <returns></returns>
        public static List<T> Open<T>(string WorkSet_Id, List<MyParameter> myParameters) where T : new()
        {
            DataTable dt = Open(WorkSet_Id, myParameters);
            return EntityHelper.GetEntities<T>(dt);
        }
        /// <summary>
        /// 查询WorkSet
        /// </summary>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <typeparam name="TPara">参数类型</typeparam>
        /// <param name="WorkSet_Name">表格名称</param>
        /// <param name="myParameters">参数列表</param>
        /// <returns></returns>
        public static List<TReturn> Open<TReturn, TPara>(string WorkSet_Name, TPara entity) where TReturn : new()
        {
            List<MyParameter> myParameters = new List<MyParameter>();
            myParameters.Add(entity);
            DataTable dt = Open(WorkSet_Name, myParameters);
            return EntityHelper.GetEntities<TReturn>(dt);
        }
        #endregion
        #region Execute_Sys_WorkSet
        /// <summary>
        /// 执行WorkSet
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="WorkSet_Id">表格编号</param>
        /// <param name="entity">实体参数</param>
        /// <returns></returns>
        public static int Execute(string WorkSet_Id, List<MyParameter> myParameters, string CRUD = "R")
        {
            try
            {
                int rtn = mService.Execute(WorkSet_Id, myParameters, CRUD);
                //BaseService.SaveLog("Execute", WorkSet_Id, (byte)Sys_Log_Type.Operation, string.Empty, WorkSet_Id);
                return rtn;
            }
            catch (FaultException ex)
            {
                Authentication(ex);
                //BaseService.SaveLog(ex.Message, ex.ToJson(), (byte)Sys_Log_Type.FaultException, string.Empty, WorkSet_Id.ToString());
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 执行WorkSet
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="WorkSet_Id">表格编号</param>
        /// <param name="entity">实体参数</param>
        /// <returns></returns>
        public static int Execute<T>(string WorkSet_Id, T entity, string CRUD = "R")
        {
            try
            {
                List<MyParameter> myParameters = new List<MainService.MyParameter>();
                myParameters.Add(entity);
                int rtn = mService.Execute(WorkSet_Id, myParameters, CRUD);
                //BaseService.SaveLog("Execute", WorkSet_Id, (byte)Sys_Log_Type.Operation, string.Empty, WorkSet_Id);
                return rtn;
            }
            catch (FaultException ex)
            {
                Authentication(ex);
                //BaseService.SaveLog(ex.Message, ex.ToJson(), (byte)Sys_Log_Type.FaultException, string.Empty, WorkSet_Id.ToString());
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
        #region ExecuteAsync_Sys_WorkSet

        /// <summary>
        /// 执行WorkSet
        /// </summary>
        /// <param name="WorkSet_Name">表格名称</param>
        /// <param name="myParameters">参数列表</param>
        /// <returns></returns>
        public static void ExecuteAsync(string WorkSet_Name, List<MyParameter> myParameters, string CRUD = "R")
        {
            try
            {
                mService.ExecuteAsync(WorkSet_Name, myParameters, CRUD);
                //BaseService.SaveLog("ExecuteAsync", WorkSet_Name, (byte)Sys_Log_Type.Operation, string.Empty, WorkSet_Name);
            }
            catch (FaultException ex)
            {
                //BaseService.SaveLog(ex.Message, ex.ToJson(), (byte)Sys_Log_Type.FaultException, string.Empty, WorkSet_Name);
                throw ex;
            }
        }
        /// <summary>
        /// 执行WorkSet
        /// </summary>
        /// <param name="WorkSet_Name">表格名称</param>
        /// <param name="myParameters">参数列表</param>
        /// <returns></returns>
        public static void ExecuteAsync<T>(string WorkSet_Name, T entity, string CRUD = "R")
        {
            try
            {
                List<MyParameter> myParameters = new List<MainService.MyParameter>();
                myParameters.Add(entity);
                mService.ExecuteAsync(WorkSet_Name, myParameters, CRUD);
                //BaseService.SaveLog("ExecuteAsync", WorkSet_Name, (byte)Sys_Log_Type.Operation, string.Empty, WorkSet_Name);
            }
            catch (FaultException ex)
            {
                //BaseService.SaveLog(ex.Message, ex.ToJson(), (byte)Sys_Log_Type.FaultException, string.Empty, WorkSet_Name);
                throw ex;
            }
        }
        #endregion
        #region Save_Sys_WorkSet

        /// <summary>
        /// 保存工作表
        /// </summary>
        /// <param name="WorkSet_Id">表格编号</param>
        /// <param name="SaveTable">待保存数据</param>
        /// <param name="myParameters">参数</param>
        /// <returns></returns>
        public static DataTable Save(string WorkSet_Id, DataTable SaveTable, List<MyParameter> myParameters)
        {
            try
            {
                mService.Save(WorkSet_Id.ToStringEx(), SaveTable, myParameters);
                //BaseService.SaveLog("Save", WorkSet_Id.ToStringEx(), (byte)Sys_Log_Type.Operation, string.Empty, WorkSet_Id.ToString());
                return SaveTable;
            }
            catch (FaultException ex)
            {
                Authentication(ex);
                //BaseService.SaveLog(ex.Message, ex.ToJson(), (byte)Sys_Log_Type.FaultException, string.Empty, WorkSet_Id.ToString());
                throw ex;
            }
        }
        #endregion
        #region File
        public static string SaveFile(byte[] file, string fileName = "")
        {
            return mService.SaveFile(file, fileName);
        }
        public static byte[] GetFile(string fileName)
        {
            return mService.GetFile(fileName);
        }
        #endregion

        public static string Login(string userName, string password)
        {
            try
            {
                string token = mService.GetToken(userName, password);
                if (!string.IsNullOrEmpty(token))
                {
                    Sys_User sys_User = token.ToObject<Sys_User>();
                    Provider.SysUser = sys_User;
                }
                //BaseService.SaveLog("Login", "UserLogin", (byte)Sys_Log_Type.Operation, string.Empty, "UserLogin");
                return token;
            }
            catch (FaultException ex)
            {
                //BaseService.SaveLog(ex.Message, ex.ToJson(), (byte)Sys_Log_Type.FaultException, string.Empty, "UserLogin");
                throw new Exception("UserLogin" + ":" + ex.Message, ex);
            }
        }
    }
}