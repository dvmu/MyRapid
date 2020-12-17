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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyRapid.Code
{
    interface IDbHelper
    {
        string connectionString { get; set; }
        DbParameter PreparParameter(string paraName, DbType dbType, object value, string sourceColumn);
        DataTable GetDataTable(string safeSql, List<DbParameter> values);
        int ExecuteCommand(string safeSql, List<DbParameter> values);
        int UpdateDataTable(DataTable dt, string ins, string upd, string del, List<DbParameter> insPar, List<DbParameter> updPar, List<DbParameter> delPar);

    }
}