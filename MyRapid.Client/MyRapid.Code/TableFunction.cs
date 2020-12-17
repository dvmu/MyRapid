/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * Author: 陈恩点
 * First Create: 2012/8/21 11:49:53
 * Contact: 18115503914
 * Description: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MyERP.Code
{
    public static class TableFunction
    {
        public static DataTable DistinctTable(this DataTable dt, params string[] columns)
        {
            DataView dataView = dt.DefaultView;
            return dataView.ToTable(true, columns);
        }
    }
}