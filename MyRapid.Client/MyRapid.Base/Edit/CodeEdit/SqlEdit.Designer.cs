/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.Base
{
    partial class SqlEdit
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolUndo = new System.Windows.Forms.ToolStripButton();
            this.toolRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCut = new System.Windows.Forms.ToolStripButton();
            this.toolCopy = new System.Windows.Forms.ToolStripButton();
            this.tolPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolFind = new System.Windows.Forms.ToolStripButton();
            this.toolReplace = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolRemove = new System.Windows.Forms.ToolStripButton();
            this.codeEdit = new ScintillaNET.Scintilla();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.cRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cFind = new System.Windows.Forms.ToolStripMenuItem();
            this.cReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.cAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.FindBox = new System.Windows.Forms.Panel();
            this.fMore = new System.Windows.Forms.Button();
            this.fClose = new System.Windows.Forms.Button();
            this.fReplaceAll = new System.Windows.Forms.Button();
            this.fReplace = new System.Windows.Forms.Button();
            this.ftxtReplace = new System.Windows.Forms.TextBox();
            this.fSearch = new System.Windows.Forms.Button();
            this.ftxtSearch = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.FindBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolUndo,
            this.toolRedo,
            this.toolStripSeparator2,
            this.toolCut,
            this.toolCopy,
            this.tolPaste,
            this.toolStripSeparator1,
            this.toolFind,
            this.toolReplace,
            this.toolStripSeparator3,
            this.toolAdd,
            this.toolRemove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(624, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolUndo
            // 
            this.toolUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolUndo.Image")));
            this.toolUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUndo.Name = "toolUndo";
            this.toolUndo.Size = new System.Drawing.Size(23, 22);
            this.toolUndo.Text = "撤销";
            this.toolUndo.ToolTipText = "撤销(Ctrl + Z)";
            this.toolUndo.Click += new System.EventHandler(this.toolUndo_Click);
            // 
            // toolRedo
            // 
            this.toolRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolRedo.Image")));
            this.toolRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRedo.Name = "toolRedo";
            this.toolRedo.Size = new System.Drawing.Size(23, 22);
            this.toolRedo.Text = "重做";
            this.toolRedo.ToolTipText = "重做(Ctrl + Y)";
            this.toolRedo.Click += new System.EventHandler(this.toolRedo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolCut
            // 
            this.toolCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCut.Image = ((System.Drawing.Image)(resources.GetObject("toolCut.Image")));
            this.toolCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCut.Name = "toolCut";
            this.toolCut.Size = new System.Drawing.Size(23, 22);
            this.toolCut.Text = "剪切";
            this.toolCut.ToolTipText = "剪切(Ctrl + X)";
            this.toolCut.Click += new System.EventHandler(this.toolCut_Click);
            // 
            // toolCopy
            // 
            this.toolCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolCopy.Image")));
            this.toolCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCopy.Name = "toolCopy";
            this.toolCopy.Size = new System.Drawing.Size(23, 22);
            this.toolCopy.Text = "复制";
            this.toolCopy.ToolTipText = "复制(Ctrl + C)";
            this.toolCopy.Click += new System.EventHandler(this.toolCopy_Click);
            // 
            // tolPaste
            // 
            this.tolPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tolPaste.Image = ((System.Drawing.Image)(resources.GetObject("tolPaste.Image")));
            this.tolPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolPaste.Name = "tolPaste";
            this.tolPaste.Size = new System.Drawing.Size(23, 22);
            this.tolPaste.Text = "粘贴";
            this.tolPaste.ToolTipText = "粘贴(Ctrl + P)";
            this.tolPaste.Click += new System.EventHandler(this.tolPaste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolFind
            // 
            this.toolFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFind.Image = ((System.Drawing.Image)(resources.GetObject("toolFind.Image")));
            this.toolFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFind.Name = "toolFind";
            this.toolFind.Size = new System.Drawing.Size(23, 22);
            this.toolFind.Text = "查找";
            this.toolFind.ToolTipText = "查找(Ctrl + F)";
            this.toolFind.Click += new System.EventHandler(this.toolFind_Click);
            // 
            // toolReplace
            // 
            this.toolReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolReplace.Image = ((System.Drawing.Image)(resources.GetObject("toolReplace.Image")));
            this.toolReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolReplace.Name = "toolReplace";
            this.toolReplace.Size = new System.Drawing.Size(23, 22);
            this.toolReplace.Text = "替换";
            this.toolReplace.ToolTipText = "替换(Ctrl + H)";
            this.toolReplace.Click += new System.EventHandler(this.toolReplace_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAdd
            // 
            this.toolAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(23, 22);
            this.toolAdd.Text = "注释";
            this.toolAdd.ToolTipText = "注释(Ctrl + L)";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolRemove
            // 
            this.toolRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolRemove.Image")));
            this.toolRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRemove.Name = "toolRemove";
            this.toolRemove.Size = new System.Drawing.Size(23, 22);
            this.toolRemove.Text = "取消注释";
            this.toolRemove.ToolTipText = "取消注释(Ctrl + K)";
            this.toolRemove.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // codeEdit
            // 
            this.codeEdit.AutoCMaxHeight = 9;
            this.codeEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeEdit.CaretLineBackColor = System.Drawing.Color.SkyBlue;
            this.codeEdit.CaretLineVisible = true;
            this.codeEdit.ContextMenuStrip = this.contextMenuStrip1;
            this.codeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEdit.Location = new System.Drawing.Point(0, 25);
            this.codeEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.codeEdit.Name = "codeEdit";
            this.codeEdit.Size = new System.Drawing.Size(624, 453);
            this.codeEdit.TabIndex = 2;
            this.codeEdit.WrapMode = ScintillaNET.WrapMode.Whitespace;
            this.codeEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codeEdit_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cUndo,
            this.cRedo,
            this.toolStripSeparator4,
            this.cCut,
            this.cCopy,
            this.cPaste,
            this.toolStripSeparator5,
            this.cSelectAll,
            this.toolStripSeparator6,
            this.cFind,
            this.cReplace,
            this.toolStripSeparator7,
            this.cAdd,
            this.cRemove});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 248);
            // 
            // cUndo
            // 
            this.cUndo.Name = "cUndo";
            this.cUndo.Size = new System.Drawing.Size(124, 22);
            this.cUndo.Text = "撤销";
            this.cUndo.Click += new System.EventHandler(this.cUndo_Click);
            // 
            // cRedo
            // 
            this.cRedo.Name = "cRedo";
            this.cRedo.Size = new System.Drawing.Size(124, 22);
            this.cRedo.Text = "重做";
            this.cRedo.Click += new System.EventHandler(this.cRedo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(121, 6);
            // 
            // cCut
            // 
            this.cCut.Name = "cCut";
            this.cCut.Size = new System.Drawing.Size(124, 22);
            this.cCut.Text = "剪切";
            this.cCut.Click += new System.EventHandler(this.cCut_Click);
            // 
            // cCopy
            // 
            this.cCopy.Name = "cCopy";
            this.cCopy.Size = new System.Drawing.Size(124, 22);
            this.cCopy.Text = "复制";
            this.cCopy.Click += new System.EventHandler(this.cCopy_Click);
            // 
            // cPaste
            // 
            this.cPaste.Name = "cPaste";
            this.cPaste.Size = new System.Drawing.Size(124, 22);
            this.cPaste.Text = "粘贴";
            this.cPaste.Click += new System.EventHandler(this.cPaste_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(121, 6);
            // 
            // cSelectAll
            // 
            this.cSelectAll.Name = "cSelectAll";
            this.cSelectAll.Size = new System.Drawing.Size(124, 22);
            this.cSelectAll.Text = "全选";
            this.cSelectAll.Click += new System.EventHandler(this.cSelectAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(121, 6);
            // 
            // cFind
            // 
            this.cFind.Name = "cFind";
            this.cFind.Size = new System.Drawing.Size(124, 22);
            this.cFind.Text = "查找";
            this.cFind.Click += new System.EventHandler(this.cFind_Click);
            // 
            // cReplace
            // 
            this.cReplace.Name = "cReplace";
            this.cReplace.Size = new System.Drawing.Size(124, 22);
            this.cReplace.Text = "替换";
            this.cReplace.Click += new System.EventHandler(this.cReplace_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(121, 6);
            // 
            // cAdd
            // 
            this.cAdd.Name = "cAdd";
            this.cAdd.Size = new System.Drawing.Size(124, 22);
            this.cAdd.Text = "注释";
            this.cAdd.Click += new System.EventHandler(this.cAdd_Click);
            // 
            // cRemove
            // 
            this.cRemove.Name = "cRemove";
            this.cRemove.Size = new System.Drawing.Size(124, 22);
            this.cRemove.Text = "取消注释";
            this.cRemove.Click += new System.EventHandler(this.cRemove_Click);
            // 
            // FindBox
            // 
            this.FindBox.Controls.Add(this.fMore);
            this.FindBox.Controls.Add(this.fClose);
            this.FindBox.Controls.Add(this.fReplaceAll);
            this.FindBox.Controls.Add(this.fReplace);
            this.FindBox.Controls.Add(this.ftxtReplace);
            this.FindBox.Controls.Add(this.fSearch);
            this.FindBox.Controls.Add(this.ftxtSearch);
            this.FindBox.Location = new System.Drawing.Point(334, 29);
            this.FindBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FindBox.Name = "FindBox";
            this.FindBox.Size = new System.Drawing.Size(287, 72);
            this.FindBox.TabIndex = 3;
            this.FindBox.Visible = false;
            // 
            // fMore
            // 
            this.fMore.Location = new System.Drawing.Point(9, 9);
            this.fMore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fMore.Name = "fMore";
            this.fMore.Size = new System.Drawing.Size(25, 23);
            this.fMore.TabIndex = 7;
            this.fMore.Text = "➢";
            this.fMore.UseVisualStyleBackColor = true;
            this.fMore.Click += new System.EventHandler(this.fMore_Click);
            // 
            // fClose
            // 
            this.fClose.Location = new System.Drawing.Point(253, 9);
            this.fClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fClose.Name = "fClose";
            this.fClose.Size = new System.Drawing.Size(23, 23);
            this.fClose.TabIndex = 6;
            this.fClose.Text = "X";
            this.fClose.UseVisualStyleBackColor = true;
            this.fClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fClose_MouseDown);
            // 
            // fReplaceAll
            // 
            this.fReplaceAll.Location = new System.Drawing.Point(253, 40);
            this.fReplaceAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fReplaceAll.Name = "fReplaceAll";
            this.fReplaceAll.Size = new System.Drawing.Size(23, 23);
            this.fReplaceAll.TabIndex = 5;
            this.fReplaceAll.Text = "✒";
            this.fReplaceAll.UseVisualStyleBackColor = true;
            this.fReplaceAll.Click += new System.EventHandler(this.fReplaceAll_Click);
            // 
            // fReplace
            // 
            this.fReplace.Location = new System.Drawing.Point(222, 40);
            this.fReplace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fReplace.Name = "fReplace";
            this.fReplace.Size = new System.Drawing.Size(25, 23);
            this.fReplace.TabIndex = 4;
            this.fReplace.Text = "✎";
            this.fReplace.UseVisualStyleBackColor = true;
            this.fReplace.Click += new System.EventHandler(this.fReplace_Click);
            // 
            // ftxtReplace
            // 
            this.ftxtReplace.Location = new System.Drawing.Point(40, 40);
            this.ftxtReplace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ftxtReplace.Name = "ftxtReplace";
            this.ftxtReplace.Size = new System.Drawing.Size(176, 23);
            this.ftxtReplace.TabIndex = 2;
            // 
            // fSearch
            // 
            this.fSearch.Location = new System.Drawing.Point(222, 9);
            this.fSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fSearch.Name = "fSearch";
            this.fSearch.Size = new System.Drawing.Size(25, 23);
            this.fSearch.TabIndex = 1;
            this.fSearch.Text = "🔍";
            this.fSearch.UseVisualStyleBackColor = true;
            this.fSearch.Click += new System.EventHandler(this.fSearch_Click);
            // 
            // ftxtSearch
            // 
            this.ftxtSearch.Location = new System.Drawing.Point(40, 9);
            this.ftxtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ftxtSearch.Name = "ftxtSearch";
            this.ftxtSearch.Size = new System.Drawing.Size(176, 23);
            this.ftxtSearch.TabIndex = 0;
            // 
            // SqlEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FindBox);
            this.Controls.Add(this.codeEdit);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SqlEdit";
            this.Size = new System.Drawing.Size(624, 478);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.FindBox.ResumeLayout(false);
            this.FindBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolUndo;
        private System.Windows.Forms.ToolStripButton toolRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolCut;
        private System.Windows.Forms.ToolStripButton toolCopy;
        private System.Windows.Forms.ToolStripButton tolPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolRemove;
        private ScintillaNET.Scintilla codeEdit;
        private System.Windows.Forms.Panel FindBox;
        private System.Windows.Forms.TextBox ftxtSearch;
        private System.Windows.Forms.TextBox ftxtReplace;
        private System.Windows.Forms.Button fSearch;
        private System.Windows.Forms.Button fClose;
        private System.Windows.Forms.Button fReplaceAll;
        private System.Windows.Forms.Button fReplace;
        private System.Windows.Forms.Button fMore;
        private System.Windows.Forms.ToolStripButton toolFind;
        private System.Windows.Forms.ToolStripButton toolReplace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cUndo;
        private System.Windows.Forms.ToolStripMenuItem cRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cCut;
        private System.Windows.Forms.ToolStripMenuItem cCopy;
        private System.Windows.Forms.ToolStripMenuItem cPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem cSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem cFind;
        private System.Windows.Forms.ToolStripMenuItem cReplace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem cAdd;
        private System.Windows.Forms.ToolStripMenuItem cRemove;
    }
}