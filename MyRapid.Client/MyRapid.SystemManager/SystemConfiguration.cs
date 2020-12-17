/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using MyRapid.Base;
using MyRapid.Code;
using MyRapid.Proxy;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyRapid.SystemManager
{
    public partial class SystemConfiguration : ChildPage
    {
        public SystemConfiguration()
        {
            InitializeComponent();
        }
        private RepositoryItem repositoryItemTextEdit = new RepositoryItemTextEdit();
        private RepositoryItem repositoryItemCheckEdit = new RepositoryItemCheckEdit();
        private RepositoryItem repositoryItemDateEdit = new RepositoryItemDateEdit();
        private RepositoryItem repositoryItemColorEdit = new RepositoryItemColorEdit();
        private RepositoryItem repositoryItemCalcEdit = new RepositoryItemCalcEdit();
        private RepositoryItem repositoryItemXmlEdit = new RepositoryItemMemoExEdit();
        private void AutoRepositoryItem(int Configuration_Type, GridView abv)
        {
            switch (Configuration_Type)
            {
                case 0://string
                    abv.Columns["Configuration_Value"].ColumnEdit = repositoryItemTextEdit;
                    break;
                case 1://decimal     
                    abv.Columns["Configuration_Value"].ColumnEdit = repositoryItemCalcEdit;
                    break;
                case 2://date
                    abv.Columns["Configuration_Value"].ColumnEdit = repositoryItemDateEdit;
                    break;
                case 3://bool
                    abv.Columns["Configuration_Value"].ColumnEdit = repositoryItemCheckEdit;
                    break;
                case 4://color
                    abv.Columns["Configuration_Value"].ColumnEdit = repositoryItemColorEdit;
                    break;
                case 5://xml
                    abv.Columns["Configuration_Value"].ColumnEdit = repositoryItemXmlEdit;
                    break;
                default:
                    break;
            }
        }
        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            AutoRepositoryItem(((GridView)sender).GetFocusedRowCellValue("Configuration_Type").ToIntEx(), (GridView)sender);
        }
        public override void Save()
        {
            base.Save();
            DataTable dt = BaseService.Open("SystemConfiguration_Global", null);
            List<Sys_Configuration> sys_Configurations = EntityHelper.GetEntities<Sys_Configuration>(dt);
            Provider.Set("SysConfiguration", sys_Configurations);
        }
        private void gv1_DataSourceChanged(object sender, EventArgs e)
        {
            AutoRepositoryItem(((GridView)sender).GetFocusedRowCellValue("Configuration_Type").ToIntEx(), (GridView)sender);
        }
        private void SystemConfiguration_Shown(object sender, EventArgs e)
        {
            base.Open();
        }
    }
}