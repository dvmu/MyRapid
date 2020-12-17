/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using MyRapid.Base;
using MyRapid.Proxy;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Base;
using MyRapid.SysEntity;
using MyRapid.Code;
using MyRapid.Proxy.MainService;
using DevExpress.XtraRichEdit.Services;
using System.Text.RegularExpressions;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;
namespace MyRapid.SystemManager
{
    public partial class SystemIcon : ChildPage
    {
        public SystemIcon()
        {
            InitializeComponent();
        }
        public void IconCompile()
        {
            try
            {
                CSharpCodeProvider ccp = new CSharpCodeProvider();
                CompilerParameters OnePara = new CompilerParameters();
                gridView1.CloseEditor();
                gridView1.UpdateCurrentRow();
                DataTable dt = (DataTable)gd.DataSource;
                SharedFunc.ShowProcess(this, 0, dt.Rows.Count);
                foreach (DataRow dr in dt.Select("IsEnabled = 1 "))
                {
                    SharedFunc.ShowProcess(1);
                    if (!Directory.Exists(@"tmp")) Directory.CreateDirectory(@"tmp");
                    File.WriteAllBytes(@"tmp\" + (string)dr["Icon_Name"], (byte[])dr["Icon_Byte"]);
                    OnePara.EmbeddedResources.Add(@"tmp\" + (string)dr["Icon_Name"]);
                }
                //OnePara.ReferencedAssemblies.Add("");
                OnePara.GenerateInMemory = false;
                OnePara.OutputAssembly = "MyRapid.Images.dll";
                CompilerResults cr;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("namespace MyRapid.Images");
                sb.AppendLine("{");
                sb.AppendLine("    public class IconList");
                sb.AppendLine("    {");
                sb.AppendLine("    }");
                sb.AppendLine("}");
                cr = ccp.CompileAssemblyFromSource(OnePara, sb.ToString());
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
                SharedFunc.ShowProcess(int.MaxValue);
            }

        }
        public override void Export()
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = (DataTable)gd.DataSource;
                    SharedFunc.ShowProcess(this, 0, dt.Rows.Count);
                    gridView1.CloseEditor();
                    gridView1.UpdateCurrentRow();
                    foreach (DataRow dr in dt.Select("IsEnabled = 1 "))
                    {
                        SharedFunc.ShowProcess(1);
                        if (!Directory.Exists(fbd.SelectedPath)) Directory.CreateDirectory(fbd.SelectedPath);
                        File.WriteAllBytes(fbd.SelectedPath + @"\" + (string)dr["Icon_Name"], (byte[])dr["Icon_Byte"]);
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
                SharedFunc.ShowProcess(int.MaxValue);
            }
        }
        public override void Import()
        {
            try
            {
                //string ss = File.ReadAllText("z.txt");
                //List<Sys_Icon> dtw = ss.ToObject<List<Sys_Icon>>();
                //gd.DataSource =EntityHelper .GetDataTable < Sys_Icon >( dtw);
                //object obj = gridView1.DataSource ;
                //return;
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = (DataTable)gd.DataSource;
                    SharedFunc.ShowProcess(this, 0, dt.Rows.Count);
                    foreach (string fs in Directory.GetFiles(fbd.SelectedPath, "*.png"))
                    {
                        SharedFunc.ShowProcess(1);
                        string f = Path.GetFileName(fs);
                        DataRow dr = dt.NewRow();
                        dr["Icon_Name"] = f;
                        dr["Icon_Nick"] = f.Replace("_16x16.png", "").Replace("_32x32.png", "");
                        dr["Icon_Byte"] = File.ReadAllBytes(fs);
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
                SharedFunc.ShowProcess(int.MaxValue);
            }
        }
    }
}