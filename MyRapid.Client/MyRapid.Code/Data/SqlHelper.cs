/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
namespace MyRapid.Code
{
    public static class SqlHelper
    {
        public static string connectionString;
        public static DbParameter PreparParameter(string paraName, DbType dbType, object value, string sourceColumn)
        {
            if (!paraName.StartsWith("@"))
            { paraName = "@" + paraName; }
            SqlParameter sqlParameter = null;
            if (string.IsNullOrEmpty(sourceColumn))
            {
                sqlParameter = new SqlParameter(paraName, value ?? DBNull.Value);
                sqlParameter.DbType = dbType;
            }
            else
            {
                sqlParameter = new SqlParameter();
                sqlParameter.DbType = dbType;
                sqlParameter.ParameterName = paraName;
                sqlParameter.SourceColumn = sourceColumn;
            }
            sqlParameter.IsNullable = true;
            return sqlParameter;
        }
        #region ExecuteCommand
        /// <summary>
        /// 带参数的执行命令
        /// </summary>
        /// <param name="sql">SQL命令文本</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public static int ExecuteCommand(string sql, List<DbParameter> values)
        {
            if (values == null)
                values = new List<DbParameter>();
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                SqlTransaction SqlTrans = Connection.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddRange(values.ToArray());
                    cmd.Transaction = SqlTrans;
                    int result;
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                        SqlTrans.Commit();
                    }
                    catch
                    {
                        SqlTrans.Rollback();
                        throw;
                    }
                    return result;
                }
            }
        }
        #endregion
        #region GetDataTable
        /// <summary>
        /// 读取表
        /// </summary>
        /// <param name="sql">SQL命令文本</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, List<DbParameter> values)
        {
            if (values == null)
                values = new List<DbParameter>();
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                try
                {
                    DataTable dt = new DataTable("dt");
                    using (SqlDataAdapter sda = new SqlDataAdapter(sql, Connection))
                    {
                        sda.SelectCommand.Parameters.AddRange(values.ToArray());
                        sda.Fill(dt);
                        return dt;
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// 读取表
        /// </summary>
        /// <param name="sql">SQL命令文本</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                try
                {
                    DataTable dt = new DataTable("dt");
                    using (SqlDataAdapter sda = new SqlDataAdapter(sql, Connection))
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion
        #region UpdateDataSet
        /// <summary>
        /// 更新数据表到数据库
        /// </summary>
        /// <param name="dt">待更新的DataTable</param>
        /// <param name="upd">更新语句</param>
        /// <param name="del">删除语句</param>
        /// <param name="ins">插入语句</param>
        /// <param name="DbParameters">DbParameter变量列表</param>
        /// <returns></returns>
        public static int UpdateDataTable(DataTable dt, string ins, string upd, string del,
            List<DbParameter> insPar, List<DbParameter> updPar, List<DbParameter> delPar)
        {
            if (insPar == null)
                insPar = new List<DbParameter>();
            if (updPar == null)
                updPar = new List<DbParameter>();
            if (delPar == null)
                delPar = new List<DbParameter>();
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                SqlTransaction sqlTransaction = Connection.BeginTransaction();
                try
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        using (SqlCommand insCmd = new SqlCommand(ins, Connection))
                        {
                            using (SqlCommand updCmd = new SqlCommand(upd, Connection))
                            {
                                using (SqlCommand delCmd = new SqlCommand(del, Connection))
                                {
                                    if (insPar != null)
                                        insCmd.Parameters.AddRange(insPar.ToArray());
                                    insCmd.Transaction = sqlTransaction;
                                    if (updPar != null)
                                        updCmd.Parameters.AddRange(updPar.ToArray());
                                    updCmd.Transaction = sqlTransaction;
                                    if (delPar != null)
                                        delCmd.Parameters.AddRange(delPar.ToArray());
                                    delCmd.Transaction = sqlTransaction;
                                    sda.InsertCommand = insCmd;
                                    sda.UpdateCommand = updCmd;
                                    sda.DeleteCommand = delCmd;
                                    int rtn = sda.Update(dt);
                                    sqlTransaction.Commit();
                                    return rtn;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    sqlTransaction.Rollback();
                    throw;
                }
            }
        }
        #endregion
    }
}