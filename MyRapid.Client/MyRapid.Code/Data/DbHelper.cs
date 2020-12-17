/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyRapid.Code
{
    /// <summary>  
    /// 通用数据库访问类，封装了对数据库的常见操作  
    ///</summary>  
    public sealed class DbHelper
    {
        public string ConnectionString { get; set; }
        private DbProviderFactory providerFactory;
        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="connectionString">数据库连接字符串</param>  
        /// <param name="providerType">数据库类型枚举，参见<paramref name="providerType"/></param>  
        public DbHelper(string connectionString, DbProviderType providerType)
        {
            ConnectionString = connectionString;
            providerFactory = ProviderFactory.GetDbProviderFactory(providerType);
            if (providerFactory == null)
            {
                throw new ArgumentException("Can't load DbProviderFactory for given value of providerType");
            }
        }

        /// <summary>
        /// 添加参数到 DbParameter列表
        /// </summary>
        /// <param name="sqlParameters">DbParameter列表</param>
        /// <param name="name">参数名称</param>
        /// <param name="value">参数值</param>
        public void AddParameter(List<DbParameter> sqlParameters, string name, object value)
        {
            try
            {
                DbParameter sqlParameter = sqlParameters.Find(p => p.ParameterName.ToUpper().Trim('@') == name.ToUpper().Trim('@'));

                if (sqlParameter == null)
                {
                    sqlParameter = providerFactory.CreateParameter();
                    sqlParameter.ParameterName = name;
                    sqlParameter.Value = value ?? DBNull.Value;
                    sqlParameter.IsNullable = true;
                    sqlParameter.Direction = ParameterDirection.Input;
                    sqlParameters.Add(sqlParameter);
                }
                else
                {
                    switch (sqlParameter.DbType)
                    {
                        case DbType.Binary:
                            //json会将byte[]用Base64编码
                            //这里Base64解码
                            byte[] bytes = Convert.FromBase64String((string)value);
                            sqlParameter.Value = bytes;
                            break;
                        default:
                            sqlParameter.Value = value;
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>     
        /// 对数据库执行增删改操作，返回受影响的行数。     
        /// </summary>     
        /// <param name="sql">要执行的增删改的SQL语句</param>     
        /// <param name="parameters">执行增删改语句所需要的参数</param>  
        /// <returns></returns>    
        public int ExecuteNonQuery(string sql, IList<DbParameter> parameters)
        {
            return ExecuteNonQuery(sql, parameters, CommandType.Text);
        }
        /// <summary>     
        /// 对数据库执行增删改操作，返回受影响的行数。     
        /// </summary>     
        /// <param name="sql">要执行的增删改的SQL语句</param>     
        /// <param name="parameters">执行增删改语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>  
        public int ExecuteNonQuery(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            try
            {
                using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
                {
                    command.Connection.Open();
                    int affectedRows = command.ExecuteNonQuery();
                    command.Connection.Close();
                    return affectedRows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>     
        /// 对数据库执行增删改操作，返回受影响的行数。     
        /// </summary>     
        /// <param name="sql">要执行的增删改的SQL语句</param>     
        /// <param name="parameters">执行增删改语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>  
        public int ExecuteNonQueryTrans(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            try
            {
                using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
                {
                    command.Connection.Open();
                    int affectedRows = command.ExecuteNonQuery();
                    command.Connection.Close();
                    return affectedRows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>     
        /// 执行一个查询语句，返回一个关联的DataReader实例     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <returns></returns>   
        public DbDataReader ExecuteReader(string sql, IList<DbParameter> parameters)
        {
            return ExecuteReader(sql, parameters, CommandType.Text);
        }
        /// <summary>     
        /// 执行一个查询语句，返回一个关联的DataReader实例     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>   
        public DbDataReader ExecuteReader(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            try
            {
                DbCommand command = CreateDbCommand(sql, parameters, commandType);
                command.Connection.Open();
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>     
        /// 执行一个查询语句，返回一个包含查询结果的DataTable     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <returns></returns>  
        public DataTable ExecuteDataTable(string sql, IList<DbParameter> parameters)
        {
            return ExecuteDataTable(sql, parameters, CommandType.Text);
        }
        /// <summary>     
        /// 执行一个查询语句，返回一个包含查询结果的DataTable     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>  
        public DataTable ExecuteDataTable(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            try
            {
                using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
                {
                    using (DbDataAdapter adapter = CreateDataAdapter())
                    {
                        adapter.SelectCommand = command;
                        DataTable data = new DataTable("dt");
                        adapter.Fill(data);
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>     
        /// 执行一个查询语句，返回一个包含查询结果的DataTable     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <returns></returns>  
        public int UpdateDataTable(DataTable data, string sqlInsert, string sqlUpdate, string sqlDelete
            , IList<DbParameter> paraInsert, IList<DbParameter> paraUpdate, IList<DbParameter> paraDelete)
        {
            try
            {
                return UpdateDataTable(data, sqlInsert, sqlUpdate, sqlDelete, paraInsert, paraUpdate, paraDelete, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>     
        /// 执行一个查询语句，返回一个包含查询结果的DataTable     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <returns></returns>  
        public int UpdateDataTableTrans(DataTable data, string sqlInsert, string sqlUpdate, string sqlDelete
            , IList<DbParameter> paraInsert, IList<DbParameter> paraUpdate, IList<DbParameter> paraDelete)
        {
            try
            {
                return UpdateDataTableTrans(data, sqlInsert, sqlUpdate, sqlDelete, paraInsert, paraUpdate, paraDelete, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>     
        /// 执行一个查询语句，返回一个包含查询结果的DataTable     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>  
        public int UpdateDataTable(DataTable data, string sqlInsert, string sqlUpdate, string sqlDelete
            , IList<DbParameter> paraInsert, IList<DbParameter> paraUpdate, IList<DbParameter> paraDelete, CommandType commandType)
        {
            try
            {
                using (DbDataAdapter adapter = CreateDataAdapter())
                {
                    using (DbCommand cmdInsert = CreateDbCommand(sqlInsert, paraInsert))
                    {
                        using (DbCommand cmdUpdate = CreateDbCommand(sqlUpdate, paraUpdate))
                        {
                            using (DbCommand cmdDelete = CreateDbCommand(sqlDelete, paraDelete))
                            {
                                
                                adapter.InsertCommand = cmdInsert;
                                adapter.UpdateCommand = cmdUpdate;
                                adapter.DeleteCommand = cmdDelete;
                                adapter.ContinueUpdateOnError = true;
                                return adapter.Update(data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>     
        /// 执行一个查询语句，返回一个包含查询结果的DataTable     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>  
        public int UpdateDataTableTrans(DataTable data, string sqlInsert, string sqlUpdate, string sqlDelete
            , IList<DbParameter> paraInsert, IList<DbParameter> paraUpdate, IList<DbParameter> paraDelete, CommandType commandType)
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                DbTransaction sqlTransaction = connection.BeginTransaction();
                try
                {
                    using (DbDataAdapter adapter = CreateDataAdapter())
                    {
                        using (DbCommand cmdInsert = CreateDbCommand(sqlInsert, paraInsert))
                        {
                            using (DbCommand cmdUpdate = CreateDbCommand(sqlUpdate, paraUpdate))
                            {
                                using (DbCommand cmdDelete = CreateDbCommand(sqlDelete, paraDelete))
                                {
                                    cmdInsert.Connection = connection;
                                    cmdUpdate.Connection = connection;
                                    cmdDelete.Connection = connection;
                                    cmdInsert.Transaction = sqlTransaction;
                                    cmdUpdate.Transaction = sqlTransaction;
                                    cmdDelete.Transaction = sqlTransaction;
                               
                                    adapter.InsertCommand = cmdInsert;
                                    adapter.UpdateCommand = cmdUpdate;
                                    adapter.DeleteCommand = cmdDelete;
                                    int rst = adapter.Update(data);
                                    sqlTransaction.Commit();
                                    return rst;
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    throw ex;
                }
            }
        }
        /// <summary>     
        /// 执行一个查询语句，返回查询结果的第一行第一列     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>     
        /// <returns></returns>     
        public object ExecuteScalar(string sql, IList<DbParameter> parameters)
        {
            return ExecuteScalar(sql, parameters, CommandType.Text);
        }
        /// <summary>     
        /// 执行一个查询语句，返回查询结果的第一行第一列     
        /// </summary>     
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>     
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>     
        public Object ExecuteScalar(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            try
            {
                using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
                {
                    command.Connection.Open();
                    object result = command.ExecuteScalar();
                    command.Connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DbParameter CreateDbParameter(string name, object value)
        {
            return CreateDbParameter(name, ParameterDirection.Input, value);
        }
        public DbParameter CreateDbParameter(string name, DbType dbType, object value)
        {
            try
            {
                DbParameter parameter = providerFactory.CreateParameter();
                parameter.ParameterName = name;
                parameter.Value = value ?? DBNull.Value;
                parameter.DbType = dbType;
                parameter.IsNullable = true;
                return parameter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DbParameter CreateDbParameter(string name, DbType dbType, string sourceColumn)
        {
            try
            {
                DbParameter parameter = providerFactory.CreateParameter();
                parameter.ParameterName = name;
                parameter.SourceColumn = sourceColumn;
                parameter.DbType = dbType;
                parameter.IsNullable = true;
                return parameter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DbParameter CreateDbParameter(string paraName, DbType dbType, object value, string sourceColumn)
        {
            if (string.IsNullOrEmpty(sourceColumn))
            {
                return CreateDbParameter(paraName, dbType, value);
            }
            else
            {
                return CreateDbParameter(paraName, dbType, sourceColumn);
            }
        }
        public DbParameter CreateDbParameter(string name, ParameterDirection parameterDirection, object value)
        {
            try
            {
                DbParameter parameter = providerFactory.CreateParameter();
                parameter.ParameterName = name;
                parameter.Value = value ?? DBNull.Value;
                parameter.Direction = parameterDirection;
                parameter.IsNullable = true;
                return parameter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DbParameter CreateDbParameter(string name, string column)
        {
            try
            {
                DbParameter parameter = providerFactory.CreateParameter();
                parameter.ParameterName = name;
                parameter.SourceColumn = column;
                parameter.IsNullable = true;
                return parameter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>  
        /// 创建一个DbCommand对象  
        /// </summary>  
        /// <param name="sql">要执行的查询语句</param>     
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>  
        /// <returns></returns>  
        private DbCommand CreateDbCommand(string sql, IList<DbParameter> parameters, CommandType commandType = CommandType.Text)
        {
            try
            {
                DbConnection connection = providerFactory.CreateConnection();
                DbCommand command = providerFactory.CreateCommand();
                connection.ConnectionString = ConnectionString;
                command.CommandText = sql;
                command.CommandType = commandType;
                command.Connection = connection;
                if (!(parameters == null || parameters.Count == 0))
                {
                    foreach (DbParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private DbDataAdapter CreateDataAdapter()
        {
            try
            {
                DbConnection conPrivate = providerFactory.CreateConnection();
                if (conPrivate is System.Data.SqlClient.SqlConnection)
                    return new System.Data.SqlClient.SqlDataAdapter();
                //if (conPrivate is MySqlConnection)
                //    return new MySqlDataAdapter();
                return providerFactory.CreateDataAdapter();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    /// <summary>  
    /// 数据库类型枚举  
    /// </summary>  
    public enum DbProviderType : byte
    {
        SqlServer,
        MySql,
        SQLite,
        Oracle,
        ODBC,
        OleDb,
        Firebird,
        PostgreSql,
        DB2,
        Informix,
        SqlServerCe
    }
    /// <summary>  
    /// DbProviderFactory工厂类
    /// </summary>  
    public class ProviderFactory
    {
        private static Dictionary<DbProviderType, string> providerInvariantNames = new Dictionary<DbProviderType, string>();
        private static Dictionary<DbProviderType, DbProviderFactory> providerFactoies = new Dictionary<DbProviderType, DbProviderFactory>(20);
        static ProviderFactory()
        {
            //加载已知的数据库访问类的程序集  
            providerInvariantNames.Add(DbProviderType.SqlServer, "System.Data.SqlClient");
            providerInvariantNames.Add(DbProviderType.OleDb, "System.Data.OleDb");
            providerInvariantNames.Add(DbProviderType.ODBC, "System.Data.ODBC");
            providerInvariantNames.Add(DbProviderType.Oracle, "Oracle.DataAccess.Client");
            providerInvariantNames.Add(DbProviderType.MySql, "MySql.Data.MySqlClient");
            providerInvariantNames.Add(DbProviderType.SQLite, "System.Data.SQLite");
            providerInvariantNames.Add(DbProviderType.Firebird, "FirebirdSql.Data.Firebird");
            providerInvariantNames.Add(DbProviderType.PostgreSql, "Npgsql");
            providerInvariantNames.Add(DbProviderType.DB2, "IBM.Data.DB2.iSeries");
            providerInvariantNames.Add(DbProviderType.Informix, "IBM.Data.Informix");
            providerInvariantNames.Add(DbProviderType.SqlServerCe, "System.Data.SqlServerCe");
        }
        /// <summary>  
        /// 获取指定数据库类型对应的程序集名称  
        /// </summary>  
        /// <param name="providerType">数据库类型枚举</param>  
        /// <returns></returns>  
        public static string GetProviderInvariantName(DbProviderType providerType)
        {
            return providerInvariantNames[providerType];
        }
        /// <summary>  
        /// 获取指定类型的数据库对应的DbProviderFactory  
        /// </summary>  
        /// <param name="providerType">数据库类型枚举</param>  
        /// <returns></returns>  
        public static DbProviderFactory GetDbProviderFactory(DbProviderType providerType)
        {
            //如果还没有加载，则加载该DbProviderFactory  
            if (!providerFactoies.ContainsKey(providerType))
            {
                providerFactoies.Add(providerType, ImportDbProviderFactory(providerType));
            }
            return providerFactoies[providerType];
        }
        /// <summary>  
        /// 加载指定数据库类型的DbProviderFactory  
        /// </summary>  
        /// <param name="providerType">数据库类型枚举</param>  
        /// <returns></returns>  
        private static DbProviderFactory ImportDbProviderFactory(DbProviderType providerType)
        {
            string providerName = providerInvariantNames[providerType];
            DbProviderFactory factory = null;
            try
            {
                //从全局程序集中查找  
                factory = DbProviderFactories.GetFactory(providerName);
            }
            catch (ArgumentException e)
            {
                factory = null;
                throw e;
            }
            return factory;
        }
    }

}