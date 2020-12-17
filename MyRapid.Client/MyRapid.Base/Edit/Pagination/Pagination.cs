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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MyRapid.Code;
namespace MyRapid.Base
{
    public partial class Pagination : XtraUserControl, INotifyPropertyChanged
    {
        public Pagination()
        {
            InitializeComponent();
        }
        private int _PageSize = 50;
        public int PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = value;
                btnPageSize.EditValue = value;
                OnPropertyChanged("PageSize");
            }
        }
        private int _PageIndex = 1;
        public int PageIndex
        {
            get
            {
                return _PageIndex;
            }
            set
            {
                try
                {
                    _PageIndex = value;
                    if (PageIndex.Equals(0))
                    {
                        PageIndex = 1;
                    }
                    if (PageIndex >= PageCount)
                    {
                        btnPageNext.Enabled = false;
                        btnPageLast.Enabled = false;
                    }
                    else
                    {
                        btnPageNext.Enabled = true;
                        btnPageLast.Enabled = true;
                    }
                    if (PageIndex.Equals(1))
                    {
                        btnPageFirst.Enabled = false;
                        btnPagePrevious.Enabled = false;
                    }
                    else
                    {
                        btnPageFirst.Enabled = true;
                        btnPagePrevious.Enabled = true;
                    }
                    string curPage = "/{0}";
                    curPage = string.Format(curPage, PageCount);
                    btnPageIndex.EditValue = PageIndex;
                    btnPageCount.Caption = curPage;
                    OnPropertyChanged("PageIndex");
                }
                catch
                {
                    //PageText = ex.Message;
                }
            }
        }
        private int _PageCount = 1;
        public int PageCount
        {
            get
            {
                return _PageCount;
            }
            set
            {
                _PageCount = value;
                try
                {
                    if (PageIndex >= _PageCount)
                    {
                        btnPageNext.Enabled = false;
                        btnPageLast.Enabled = false;
                    }
                    else
                    {
                        btnPageNext.Enabled = true;
                        btnPageLast.Enabled = true;
                    }
                    if (PageIndex.Equals(1))
                    {
                        btnPageFirst.Enabled = false;
                        btnPagePrevious.Enabled = false;
                    }
                    else
                    {
                        btnPageFirst.Enabled = true;
                        btnPagePrevious.Enabled = true;
                    }
                    string curPage = "/{0}";
                    curPage = string.Format(curPage, _PageCount);
                    btnPageIndex.EditValue = PageIndex;
                    btnPageCount.Caption = curPage;
                    txtPageIndex.MaxValue = _PageCount;
                    //OnPropertyChanged("PageCount");
                }
                catch
                {
                    //PageText = ex.Message;
                }
            }
        }
        private int _PageRecord = 1;
        public int PageRecord
        {
            get
            {
                return _PageRecord;
            }
            set
            {
                _PageRecord = value;
                OnPropertyChanged("PageRecord");
            }
        }
        //共{0}页，{1}条记录，每页{1}条，当前第{2}页
        private string _PageText = "";
        public string PageText
        {
            get
            {
                return _PageText;
            }
            set
            {
                _PageText = value;
                btnPageText.Caption = value;
                OnPropertyChanged("PageText");
            }
        }
        private int[] _PageOption = { 50, 100, 300, 500, 1000, 2000, 3000, 5000, 10000, 20000, 200000 };
        public int[] PageOption
        {
            get
            {
                return _PageOption;
            }
            set
            {
                _PageOption = value;
                cbxPageSize.Items.Clear();
                foreach (int i in _PageOption)
                {
                    cbxPageSize.Items.Add(i);
                }
            }
        }
        private Alignment _PageAlign;
        public Alignment PageAlign
        {
            get
            {
                return _PageAlign;
            }
            set
            {
                _PageAlign = value;
                switch (_PageAlign)
                {
                    case Alignment.Default:
                        btnPageText.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageSize.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageFirst.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPagePrevious.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageCount.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageNext.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageLast.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageIndex.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageRight.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageRight.RightIndent = 12;
                        break;
                    case Alignment.Near:
                        btnPageText.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
                        btnPageSize.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
                        btnPageFirst.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
                        btnPagePrevious.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
                        btnPageCount.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
                        btnPageNext.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
                        btnPageLast.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
                        btnPageIndex.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
                        btnPageRight.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
                        btnPageRight.RightIndent = 12;
                        break;
                    case Alignment.Center:
                        btnPageText.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageSize.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageFirst.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPagePrevious.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageCount.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageNext.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageLast.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageIndex.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageRight.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageRight.RightIndent = (this.Width - 300) / 2;
                        break;
                    case Alignment.Far:
                        btnPageText.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageSize.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageFirst.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPagePrevious.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageCount.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageNext.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageLast.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageIndex.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageRight.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                        btnPageRight.RightIndent = 12;
                        break;
                    default:
                        break;
                }

            }
        }

        private bool IsUpdate;
        public void BeginUpdate()
        {
            IsUpdate = true;
        }
        public void EndUpdate()
        {
            IsUpdate = false;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            if (!IsUpdate)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
            }
        }
        private void Pagination_Resize(object sender, EventArgs e)
        {
            this.Height = 27;
        }
        private void cbxPageSize_EditValueChanged(object sender, EventArgs e)
        {
            ComboBoxEdit cbx = (ComboBoxEdit)sender;
            try
            {
                PageSize = int.Parse(cbx.EditValue.ToString());
            }
            catch
            {
                PageSize = 50;
            }
        }
        private void btnPageFirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PageIndex = 1;
        }
        private void btnPagePrevious_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PageIndex -= 1;
        }
        private void btnPageNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PageIndex += 1;
        }
        private void btnPageLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PageIndex = PageCount;
        }
        private void txtPageIndex_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SpinEdit spinEdit = (SpinEdit)sender;
                spinEdit.Properties.IsFloatValue = false;
                int pageIndex = int.Parse(spinEdit.EditValue.ToString());
                if (pageIndex <= 0)
                {
                    spinEdit.EditValue = 1;
                    pageIndex = 1;
                }
                else
                {
                    PageIndex = pageIndex;
                }
            }
            catch
            {
                //PageText = ex.Message;
            }
        }

    }
}