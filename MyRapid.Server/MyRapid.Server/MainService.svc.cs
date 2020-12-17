/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
namespace MyRapid.Server
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MainService : IMainService
    {
        DbHelper db = null;
        public Sys_User sys_User;
        private string baseConn;
        public MainService()
        {
            //DbHelper.connectionString = ConfigurationManager.AppSettings["TestString"];
            baseConn = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            db = new DbHelper(baseConn, DbProviderType.SqlServer);
        }
        [WebInvoke(Method = "*", UriTemplate = "/GetToken", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public string GetToken(string userName, string password)
        {
            try
            {
                List<MyParameter> sqlParameters = new List<MyParameter>();
                MyParameter userPara = new MyParameter("@User_Name", userName, (int)DbType.String, null);
                sqlParameters.Add(userPara);
                MyParameter userPass = new MyParameter("@User_Password", password, (int)DbType.String, null);
                sqlParameters.Add(userPass);
                string ReadSql = @"SELECT * FROM Sys_User Where User_Name = @User_Name AND User_Password = @User_Password";
                DataTable rdt = db.ExecuteDataTable(ReadSql, PreparParameters(sqlParameters));
                sys_User = EntityHelper.GetEntity<Sys_User>(rdt);
                if (sys_User != null)
                {
                    string token = Guid.NewGuid().ToString();
                    sys_User.User_Password = token;
                    //System.Web.HttpContext.Current.Session["SysUser"] = sys_User;
                    return sys_User.ToJson();
                }
                throw new Exception("账号或密码不正确！");
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 读取信息
        /// </summary>
        /// <param name="WorkSet_Id">WorkSet 名称</param>
        /// <param name="sqlParameters">MyParameter 的List</param>
        /// <returns></returns>
        [WebInvoke(Method = "*", UriTemplate = "/Open", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public DataTable Open(string WorkSet_Id, List<MyParameter> sqlParameters = null)
        {
            try
            {
                if (string.IsNullOrEmpty(WorkSet_Id)) return null;
                if (sqlParameters == null) { sqlParameters = new List<MyParameter>(); }
                Sys_WorkSet wkCmd = PreparWorkSet(WorkSet_Id);
                if (wkCmd != null)
                {
                    string ReadSql = wkCmd.WorkSet_Select;
                    if (!string.IsNullOrEmpty(ReadSql))
                    {
                        if (!string.IsNullOrEmpty(wkCmd.WorkSet_Connection))
                        {
                            db.ConnectionString = wkCmd.WorkSet_Connection;
                        }
                        DataTable rdt = db.ExecuteDataTable(ReadSql, PreparParameters(sqlParameters));
                        return rdt;
                    }
                    else
                    {
                        throw new ArgumentNullException(WorkSet_Id + ".WorkSet_Select");
                    }
                }
                else
                {
                    throw new ArgumentNullException(WorkSet_Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.ConnectionString = baseConn;
            }
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="WorkSet_Id">WorkSet 名称</param>
        /// <param name="Data">待保存的表</param>
        /// <param name="sqlParameters">MyParameter 的List</param>
        /// <returns></returns>
        [WebInvoke(Method = "*", UriTemplate = "/Save", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public DataTable Save(string WorkSet_Id, DataTable Data, List<MyParameter> sqlParameters)
        {
            try
            {
                if (sqlParameters == null) { sqlParameters = new List<MyParameter>(); }
                Sys_WorkSet wkCmd = PreparWorkSet(WorkSet_Id);
                if (wkCmd != null)
                {
                    if (!string.IsNullOrEmpty(wkCmd.WorkSet_Connection))
                    {
                        db.ConnectionString = wkCmd.WorkSet_Connection;
                    }
                    db.UpdateDataTable(Data, wkCmd.WorkSet_Insert, wkCmd.WorkSet_Update, wkCmd.WorkSet_Delete, PreparParameters(sqlParameters), PreparParameters(sqlParameters), PreparParameters(sqlParameters));
                    return null;
                }
                throw new ArgumentNullException(WorkSet_Id);
            }
            catch
            {
                return Data;
                //throw new Exception(string.Concat(WorkSet_Id, "\r\n", ex.Message, "\r\n", sqlParameters.ToJson()));
            }
            finally
            {
                db.ConnectionString = baseConn;
            }
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="WorkSet_Id">WorkSet 名称</param>
        /// <param name="CRUD">增删改查</param>
        /// <param name="sqlParameters">MyParameter 的List</param>
        /// <returns></returns>
        [WebInvoke(Method = "*", UriTemplate = "/Execute", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public int Execute(string WorkSet_Id, List<MyParameter> sqlParameters = null, string CRUD = "R")
        {
            try
            {
                if (sqlParameters == null) { sqlParameters = new List<MyParameter>(); }
                if (string.IsNullOrEmpty(WorkSet_Id)) return 0;
                Sys_WorkSet wkCmd = PreparWorkSet(WorkSet_Id);
                if (wkCmd != null)
                {
                    string sqlCRUD = "";
                    switch (CRUD.ToUpper())
                    {
                        case "I":
                            sqlCRUD = wkCmd.WorkSet_Insert;
                            break;
                        case "C":
                            sqlCRUD = wkCmd.WorkSet_Insert;
                            break;
                        case "R":
                            sqlCRUD = wkCmd.WorkSet_Select;
                            break;
                        case "U":
                            sqlCRUD = wkCmd.WorkSet_Update;
                            break;
                        case "D":
                            sqlCRUD = wkCmd.WorkSet_Delete;
                            break;
                        default:
                            break;
                    }
                    if (!string.IsNullOrEmpty(sqlCRUD))
                    {
                        if (!string.IsNullOrEmpty(wkCmd.WorkSet_Connection))
                        {
                            db.ConnectionString = wkCmd.WorkSet_Connection;
                        }
                        int rtn = db.ExecuteNonQuery(sqlCRUD, PreparParameters(sqlParameters));
                        return rtn;
                    }

                }
                throw new ArgumentNullException(WorkSet_Id);
            }
            catch (FaultException ex)
            {
                throw new Exception(string.Concat(WorkSet_Id, "\r\n", ex.Message, "\r\n", sqlParameters.ToJson()));
            }
            finally
            {
                db.ConnectionString = baseConn;
            }
        }
        private string uploadPath = ConfigurationManager.AppSettings.Get("uploadPath");
        [WebInvoke(Method = "*", UriTemplate = "/SaveFile", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public string SaveFile(byte[] file, string fileName = "")
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                    fileName = Guid.NewGuid().ToString();
                fileName = string.Concat(uploadPath, @"\", fileName);
                if (File.Exists(fileName))
                {
                    throw new Exception("File Exists:" + fileName);
                }
                File.WriteAllBytes(fileName, file);
                return fileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebInvoke(Method = "*", UriTemplate = "/GetFile", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public byte[] GetFile(string fileName)
        {
            try
            {
                fileName = string.Concat(uploadPath, @"\", fileName);
                if (File.Exists(fileName))
                {
                    byte[] bs = File.ReadAllBytes(fileName);
                    return bs;
                }
                else
                {
                    throw new FileNotFoundException("FileNotFoundException", fileName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region PreparCommand 
        private Sys_WorkSet PreparWorkSet(string worksetName)
        {
            if (sys_User == null)
                throw new Exception("Authentication");
            if (sys_User != null)
            {
                List<MyParameter> lsp = new List<MyParameter>();
                string sql = @"MyRapid_SqlCommand @WorkSet_Name ,@User_Id";
                MyParameter pName = new MyParameter("@WorkSet_Name", worksetName, (int)DbType.String, null);
                lsp.Add(pName);
                MyParameter pUser = new MyParameter("@User_Id", sys_User.User_Id.ToString(), (int)DbType.String, null);
                lsp.Add(pUser);
                DataTable sdt = db.ExecuteDataTable(sql, PreparParameters(lsp));
                List<Sys_WorkSet> wkCmd = EntityHelper.GetEntities<Sys_WorkSet>(sdt);
                if (wkCmd.Count > 0)
                    return wkCmd[0];
                throw new Exception($"未能找到请求的WorkSet:{worksetName}");
            }
            return null;
        }
        private List<DbParameter> PreparParameters(List<MyParameter> MyParameters)
        {
            List<MyParameter> mps = InitializeParameter(MyParameters);
            List<DbParameter> sqlParameters = new List<DbParameter>();
            foreach (MyParameter value in mps)
            {
                DbParameter sqlParameter = db.CreateDbParameter(value.Name, (DbType)value.Type, value.Value, value.Source);
                sqlParameters.Add(sqlParameter);
            }
            return sqlParameters;
        }
        /// <summary>
        /// 参数最终处理
        /// </summary>
        /// <param name="myParameters">参数</param>
        /// <returns></returns>
        private List<MyParameter> InitializeParameter(List<MyParameter> myParameters)
        {
            try
            {
                if (myParameters == null) myParameters = new List<MyParameter>();
                if (sys_User != null)
                {
                    myParameters.Remove(myParameters.Find(p => p.Name.TrimStart('@').Equals("Create_User")));
                    myParameters.Remove(myParameters.Find(p => p.Name.TrimStart('@').Equals("Modify_User")));
                    myParameters.Remove(myParameters.Find(p => p.Name.TrimStart('@').Equals("Delete_User")));
                    myParameters.Remove(myParameters.Find(p => p.Name.TrimStart('@').Equals("sUserName")));
                    myParameters.Remove(myParameters.Find(p => p.Name.TrimStart('@').Equals("sUserId")));
                    myParameters.Remove(myParameters.Find(p => p.Name.TrimStart('@').Equals("sUserNick")));
                    myParameters.Remove(myParameters.Find(p => p.Name.TrimStart('@').Equals("sUserCultural")));
                    myParameters.Remove(myParameters.Find(p => p.Name.TrimStart('@').Equals("sUserDept")));
                    myParameters.Remove(myParameters.Find(p => p.Name.TrimStart('@').Equals("sUserDepartment")));
                    myParameters.Remove(myParameters.Find(p => p.Name.TrimStart('@').Equals("sUserRole")));
                    myParameters.Add(new MyParameter("@Create_User", sys_User.User_Id, 16, null));
                    myParameters.Add(new MyParameter("@Modify_User", sys_User.User_Id, 16, null));
                    myParameters.Add(new MyParameter("@Delete_User", sys_User.User_Id, 16, null));
                    myParameters.Add(new MyParameter("@sUserName", sys_User.User_Name, 16, null));
                    myParameters.Add(new MyParameter("@sUserId", sys_User.User_Id, 16, null));
                    myParameters.Add(new MyParameter("@sUserNick", sys_User.User_Nick, 16, null));
                    myParameters.Add(new MyParameter("@sUserCultural", sys_User.User_Cultural, 16, null));
                    myParameters.Add(new MyParameter("@sUserDept", sys_User.User_Department, 16, null));
                    myParameters.Add(new MyParameter("@sUserDepartment", sys_User.User_Department, 16, null));
                    myParameters.Add(new MyParameter("@sUserRole", sys_User.User_Authorization, 16, null));
                    //check
                    foreach (MyParameter myParameter in myParameters.Where(p => string.IsNullOrEmpty(p.Source)))
                    {
                        if (myParameter.Type.Equals((int)DbType.DateTime) || myParameter.Type.Equals((int)DbType.DateTime2) || myParameter.Type.Equals((int)DbType.Date))
                        {
                            if (myParameter.Value.ToDateTimeEx() < new DateTime(1753, 1, 1, 0, 0, 0) || myParameter.Value.ToDateTimeEx() > new DateTime(9999, 12, 31, 23, 59, 59))
                            {
                                myParameter.Value = null;
                                myParameter.Source = null;
                            }
                        }
                    }

                }


                return myParameters;
            }
            catch
            {
                throw;
            }
        }
        public void LoginOut()
        {
            sys_User = null;
        }
        #endregion
    }
}