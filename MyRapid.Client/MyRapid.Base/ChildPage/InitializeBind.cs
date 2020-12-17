/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.Data;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Designer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSpreadsheet;
using MyRapid.Base;
using MyRapid.Code;
using MyRapid.GlobalLocalizer;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static MyRapid.SysEntity.Sys_Enum;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Base;
namespace MyRapid.Base
{
    public partial class ChildPage : DevExpress.XtraEditors.XtraForm
    {
        #region InitializeBind

        #region InitializeBind


        /// <summary>
        /// 绑定字段
        /// </summary>
        /// <param name="WorkSet_Id"></param>
        /// <param name="IsForQuery"></param>
        /// <returns></returns>
        protected List<MyParameter> InitializeBind(string WorkSet_Id, bool IsForQuery = true)
        {
            try
            {
                ParameterList.Clear();

                //插入全局参数
                //InitializeBindConst();

                List<MyParameter> mps = new List<MyParameter>();
                mps.Add("@WorkSet_Id", DbType.String, WorkSet_Id, null);
                var wks = BaseService.Open<Sys_WorkSet>("SystemWorkSet_Single", mps);
                if (wks == null || wks.Count == 0) return ParameterList;
                var wk = wks[0];
                //如果没有返回值则
                if (wk == null)
                    throw new Exception($"WorkSet：SystemWorkSet_Single\r\n参数:{WorkSet_Id}\r\n没有返回值！");

                mps.Add("@WorkSet_Id", DbType.String, wk.WorkSet_Id, null);
                var fieldList = BaseService.Open<Sys_Bind>("SystemBind_WorkSet", mps);

                //foreach (Sys_Bind sys_Bind in BindList.OrderBy(b => b.Bind_Sort))
                //{
                //    //取Bind绑定的控件上的值
                //    object val = InitializeParameter(sys_Bind);
                //    ParameterList.Add(sys_Bind.Bind_Name.TrimStart('@'), (DbType)sys_Bind.Bind_SqlDbType, val, null);
                //    //取Bind绑定的数据源字段
                //    if (!IsForQuery && !sys_Bind.Bind_Name.StartsWith("@"))
                //    {
                //        ParameterList.Add(sys_Bind.Bind_Name.TrimStart('@'), (DbType)sys_Bind.Bind_SqlDbType, null, sys_Bind.Bind_Field);
                //    }
                //}

                foreach (Sys_Bind sys_Bind in fieldList.OrderBy(b => b.Bind_Sort))
                {
                    //取Bind绑定的控件上的值
                    object val = InitializeParameter(sys_Bind);
                    ParameterList.Add(sys_Bind.Bind_Name.TrimStart('@'), (DbType)sys_Bind.Bind_SqlDbType, val, null);
                    //取Bind绑定的数据源字段
                    if (!IsForQuery && !sys_Bind.Bind_Name.StartsWith("@"))
                    {
                        ParameterList.Add(sys_Bind.Bind_Name.TrimStart('@'), (DbType)sys_Bind.Bind_SqlDbType, null, sys_Bind.Bind_Field);
                    }
                }



                return ParameterList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        /// <summary>
        /// 取得字段绑定的值
        /// </summary>
        /// <param name="sys_Bind"></param>
        /// <returns></returns>
        private object InitializeParameter(Sys_Bind sys_Bind)
        {
            object val = null;
            //if (sys_Bind.Bind_Field.StartsWith("val:"))
            //{
            //    val = sys_Bind.Bind_Field.Remove(0, 4);
            //}

            object control = sys_Bind.Bind_Control;
            //没有绑定过控件 绑定Sys_Bind到相应控件
            if (control == null)
            {
                if (sys_Bind.Bind_Field.IndexOf(".") > 0)
                {
                    string gd = sys_Bind.Bind_Field.Substring(0, sys_Bind.Bind_Field.IndexOf("."));
                    Control[] bindControls = this.Controls.Find(gd, true);
                    if (bindControls.Length > 0)
                    {
                        if (bindControls[0].GetType().Equals(typeof(GridControl)))
                        {
                            GridControl tgd = (GridControl)bindControls[0];
                            GridView tabv = (GridView)tgd.MainView;
                            string col = sys_Bind.Bind_Field.Substring(sys_Bind.Bind_Field.IndexOf(".") + 1);
                            sys_Bind.Bind_Control = tabv.Columns[col];
                        }
                    }
                }
                else
                {
                    //优先绑定Edit控件
                    Control[] bindControls = this.Controls.Find(sys_Bind.Bind_Field, true);
                    if (bindControls.Length > 0)
                    {
                        sys_Bind.Bind_Control = bindControls[0];
                    }
                    //如果没找到则绑定数据列
                    //判断传入的如果是Name 自动转为 Id
                    Sys_WorkSet twk = WorkSetList.Find(w => w.WorkSet_Id.Equals(sys_Bind.Bind_WorkSet));
                    if (twk != null && twk.WorkSet_Control != null && sys_Bind.Bind_Control == null)
                    {
                        GridView gv = (GridView)((GridControl)twk.WorkSet_Control).MainView;
                        sys_Bind.Bind_Control = gv.Columns[sys_Bind.Bind_Field];
                    }
                }
                control = sys_Bind.Bind_Control;
            }                    //绑定控件之后
            if (control != null)
            {
                object obj = null;
                //如果控件存在 且不是表格列 则用反射获取控件的值
                if (control.GetType() != typeof(GridColumn))
                {
                    //如果指定了属性则直接从属性里取
                    if (!string.IsNullOrEmpty(sys_Bind.Bind_Property))
                    {
                        obj = GetValue((Control)control, sys_Bind.Bind_Property);
                    }
                    //否则取默认的EditValue 若为空再取Text
                    else
                    {
                        obj = GetValue((Control)control, "EditValue");
                        if (obj == null)
                        {
                            obj = GetValue((Control)control, "Text");
                        }
                    }
                }
                //如果控件存在且是表格列 则取单元格中值
                else
                {
                    GridColumn bgc = (GridColumn)control;
                    if (bgc.View.FocusedRowHandle >= 0 || bgc.View.IsNewItemRow(bgc.View.FocusedRowHandle))
                        obj = bgc.View.GetFocusedRowCellValue(bgc);
                }
                //obj从DBNull转为null
                if (obj == DBNull.Value || string.IsNullOrEmpty(obj.ToStringEx()))
                {
                    obj = null;
                }
                val = obj;
            }
            return val;
        }
        #endregion

        #endregion       
    }
}