/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
///*******************************************************************************
// * Copyright © 2010-2020  陈恩点版权所有
// * 初版作者: 陈恩点
// * Last Updated: 2017/8/21 11:49:53
// * 联系方式: 18115503914
// * 简单描述: MyRapid快速开发框架
//*********************************************************************************/
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Common;
//using System.Data.SQLite;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace MyRapid.Code
//{
//    public static class SQLiteHelper
//    {
//        public static string connectionString;
//        /// <summary>
//        /// 准备参数
//        /// </summary>
//        /// <param name="paraName"></param>
//        /// <param name="dbType"></param>
//        /// <param name="value"></param>
//        /// <param name="sourceColumn"></param>
//        /// <returns></returns>
//        public static DbParameter PreparParameter(string paraName, DbType dbType, object value, string sourceColumn)
//        {
//            if (!paraName.StartsWith("@"))
//            { paraName = "@" + paraName; }
//            SQLiteParameter sqlParameter = null;
//            if (string.IsNullOrEmpty(sourceColumn))
//            {
//                sqlParameter = new SQLiteParameter(paraName, value ?? DBNull.Value);
//                sqlParameter.DbType = dbType;
//            }
//            else
//            {
//                sqlParameter = new SQLiteParameter(paraName, dbType, -1, sourceColumn);
//            }
//            sqlParameter.IsNullable = true;
//            return sqlParameter;
//        }
//        /// <summary>
//        /// 带参数的执行命令
//        /// </summary>
//        /// <param name="sql">SQL命令文本</param>
//        /// <param name="values">参数</param>
//        /// <returns></returns>
//        public static int ExecuteCommand(string sql, List<DbParameter> values)
//        {
//            if (values == null) values = new List<DbParameter>();
//            using (SQLiteConnection Connection = new SQLiteConnection(connectionString))
//            {
//                Connection.Open();
//                SQLiteTransaction SqlTrans = Connection.BeginTransaction();
//                using (SQLiteCommand cmd = new SQLiteCommand(sql, Connection))
//                {
//                    cmd.Parameters.AddRange(values.ToArray());
//                    cmd.Transaction = SqlTrans;
//                    int result;
//                    try
//                    {
//                        result = cmd.ExecuteNonQuery();
//                        SqlTrans.Commit();
//                    }
//                    catch
//                    {
//                        SqlTrans.Rollback();
//                        throw;
//                    }
//                    return result;
//                }
//            }
//        }
//        /// <summary>
//        /// 读取表
//        /// </summary>
//        /// <param name="sql">SQL命令文本</param>
//        /// <param name="values">参数</param>
//        /// <returns></returns>
//        public static object GetScalar(string sql, List<DbParameter> values)
//        {
//            if (values == null) values = new List<DbParameter>();
//            using (SQLiteConnection Connection = new SQLiteConnection(connectionString))
//            {
//                Connection.Open();
//                try
//                {
//                    DataTable dt = new DataTable("dt");
//                    using (SQLiteCommand cmd = new SQLiteCommand(sql, Connection))
//                    {
//                        return cmd.ExecuteScalar();
//                    }
//                }
//                catch
//                {
//                    throw;
//                }
//            }
//        }
//        /// <summary>
//        /// 读取表
//        /// </summary>
//        /// <param name="sql">SQL命令文本</param>
//        /// <param name="values">参数</param>
//        /// <returns></returns>
//        public static DataTable GetDataTable(string sql, List<DbParameter> values)
//        {
//            if (values == null) values = new List<DbParameter>();
//            using (SQLiteConnection Connection = new SQLiteConnection(connectionString))
//            {
//                Connection.Open();
//                try
//                {
//                    DataTable dt = new DataTable("dt");
//                    using (SQLiteDataAdapter sda = new SQLiteDataAdapter(sql, Connection))
//                    {
//                        sda.SelectCommand.Parameters.AddRange(values.ToArray());
//                        sda.Fill(dt);
//                        return dt;
//                    }
//                }
//                catch
//                {
//                    throw;
//                }
//            }
//        }
//        /// <summary>
//        /// 更新数据表到数据库
//        /// </summary>
//        /// <param name="dt">待更新的DataTable</param>
//        /// <param name="upd">更新语句</param>
//        /// <param name="del">删除语句</param>
//        /// <param name="ins">插入语句</param>
//        /// <param name="SQLiteParameters">SQLiteParameter变量列表</param>
//        /// <returns></returns>
//        public static int UpdateDataTable(DataTable dt, string ins, string upd, string del,
//            List<DbParameter> insPar, List<DbParameter> updPar, List<DbParameter> delPar)
//        {
//            using (SQLiteConnection Connection = new SQLiteConnection(connectionString))
//            {
//                Connection.Open();
//                SQLiteTransaction sqlTransaction = Connection.BeginTransaction();
//                try
//                {
//                    using (SQLiteDataAdapter sda = new SQLiteDataAdapter())
//                    {
//                        using (SQLiteCommand insCmd = new SQLiteCommand(ins, Connection))
//                        {
//                            using (SQLiteCommand updCmd = new SQLiteCommand(upd, Connection))
//                            {
//                                using (SQLiteCommand delCmd = new SQLiteCommand(del, Connection))
//                                {
//                                    if (insPar != null)
//                                        insCmd.Parameters.AddRange(insPar.ToArray());
//                                    insCmd.Transaction = sqlTransaction;
//                                    if (updPar != null)
//                                        updCmd.Parameters.AddRange(updPar.ToArray());
//                                    updCmd.Transaction = sqlTransaction;
//                                    if (delPar != null)
//                                        delCmd.Parameters.AddRange(delPar.ToArray());
//                                    delCmd.Transaction = sqlTransaction;
//                                    sda.InsertCommand = insCmd;
//                                    sda.UpdateCommand = updCmd;
//                                    sda.DeleteCommand = delCmd;
//                                    int rtn = sda.Update(dt);
//                                    sqlTransaction.Commit();
//                                    return rtn;
//                                }
//                            }
//                        }
//                    }
//                }
//                catch
//                {
//                    sqlTransaction.Rollback();
//                    throw;
//                }
//            }
//        }
//    }
//}