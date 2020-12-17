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
using System.Linq;
using System.Text;
namespace MyRapid.Code
{
    public static class TableHelper
    {
        public static DataTable DistinctTable(this DataTable dt, params string[] columns)
        {
            DataView dataView = dt.DefaultView;
            return dataView.ToTable(true, columns);
        }
        #region Function CheckNull
        /// <summary>
        /// 判断datatable为Null或为空
        /// </summary>
        /// <param name="dt">待判断的DataTable</param>
        /// <returns></returns>
        public static bool IsNull(DataTable dt)
        {
            if (dt ==null) return true;
            if (dt.Rows.Count.Equals( 0)) return true;
            return false;
        }
        /// <summary>
        /// 判断dataset为Null或为空
        /// </summary>
        /// <param name="dSet">待判断的DataSet</param>
        /// <returns></returns>
        public static bool IsNull(DataSet dSet)
        {
            if (dSet ==null) return true;
            if (dSet.Tables.Count.Equals( 0)) return true;
            return false;
        }
        #endregion
    }
}