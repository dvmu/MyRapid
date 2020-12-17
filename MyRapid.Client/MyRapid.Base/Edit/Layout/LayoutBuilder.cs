/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace MyRapid.Base
{
    public class LayoutBuilder : ComponentDesigner
    {
        private IContainer components;
        [DebuggerNonUserCode]
        public LayoutBuilder(IContainer container) : this()
        {
            bool flag = container != null;
            if (flag)
            {
                container.Add((IComponent)this);
            }
        }
        [DebuggerNonUserCode]
        public LayoutBuilder()
        {
            this.InitializeComponent();
            DesignerVerb value = new DesignerVerb("布局模版", delegate (object a0, EventArgs a1)
            {
                this.BuildClick();
            });
            base.Verbs.Add(value);
        }
        public void BuildClick()
        {
            this.DoDefaultAction();
        }
        public override void DoDefaultAction()
        {
            IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
            DesignerTransaction designerTransaction = designerHost.CreateTransaction();
            IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
            Form component = (Form)designerHost.RootComponent;
            LayoutBuilderUI myBuildFrm = new LayoutBuilderUI(designerHost);
            myBuildFrm.ShowDialog();
            componentChangeService.OnComponentChanging(component, null);
            componentChangeService.OnComponentChanged(component, null, null, null);
            designerTransaction.Commit();
        }
        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                bool flag = disposing && this.components != null;
                if (flag)
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
        }

    }
}