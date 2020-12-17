/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Design;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static MyRapid.SysEntity.Sys_Enum;
namespace MyRapid.Base
{
    public partial class ChildPage : DevExpress.XtraEditors.XtraForm
    {
        #region InitializeRepositoryItem
        private Dictionary<string, Sys_Popup> PopupList = new Dictionary<string, Sys_Popup>();
        protected RepositoryItem InitializeRepositoryItem(Sys_Bind sys_Bind)
        {


            try
            {
                List<MyParameter> myParameters = new List<MyParameter>();
                if (string.IsNullOrEmpty(sys_Bind.Bind_Popup)) return null;
                myParameters.Add("@Popup_Id", DbType.String, sys_Bind.Bind_Popup, null);
                DataTable dt = BaseService.Open("SystemPopup_PopupBind", myParameters);
                Sys_Popup sys_Popup = EntityHelper.GetEntity<Sys_Popup>(dt);
                sys_Popup.Popup_Target = sys_Bind.Bind_Id;
                PopupList[sys_Bind.Bind_Id] = sys_Popup;
                switch ((Sys_Enum.Sys_WorkSet_Editor)sys_Popup.Popup_Type)
                {
                    case Sys_WorkSet_Editor.ColorEdit:
                        RepositoryItemColorEdit repositoryItemColorEdit = new RepositoryItemColorEdit();
                        repositoryItemColorEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemColorEdit.StoreColorAsInteger = true;
                        repositoryItemColorEdit.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
                        repositoryItemColorEdit.KeyDown += BindColorEditClear;
                        return repositoryItemColorEdit;
                    case Sys_WorkSet_Editor.DateTimeEdit:
                        RepositoryItemDateEdit repositoryItemDateTimeEdit = new RepositoryItemDateEdit();
                        repositoryItemDateTimeEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemDateTimeEdit.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
                        repositoryItemDateTimeEdit.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
                        repositoryItemDateTimeEdit.EditMask = "yyyy-MM-dd HH:mm:ss";
                        repositoryItemDateTimeEdit.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        repositoryItemDateTimeEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemDateTimeEdit.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        repositoryItemDateTimeEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemDateTimeEdit.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
                        repositoryItemDateTimeEdit.DoubleClick += BindDateTimeEdit;
                        return repositoryItemDateTimeEdit;
                    case Sys_WorkSet_Editor.DateEdit:
                        RepositoryItemDateEdit repositoryItemDateEdit = new RepositoryItemDateEdit();
                        repositoryItemDateEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemDateEdit.EditMask = "yyyy-MM-dd";
                        repositoryItemDateEdit.DisplayFormat.FormatString = "yyyy-MM-dd";
                        repositoryItemDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemDateEdit.EditFormat.FormatString = "yyyy-MM-dd";
                        repositoryItemDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemDateEdit.Mask.EditMask = "yyyy-MM-dd";
                        repositoryItemDateEdit.DoubleClick += BindDateTimeEdit;
                        return repositoryItemDateEdit;
                    case Sys_WorkSet_Editor.MonthEdit:
                        RepositoryItemDateEdit repositoryItemMonthEdit = new RepositoryItemDateEdit();
                        repositoryItemMonthEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemMonthEdit.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
                        repositoryItemMonthEdit.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
                        repositoryItemMonthEdit.EditMask = "yyyy-MM";
                        repositoryItemMonthEdit.DisplayFormat.FormatString = "yyyy-MM";
                        repositoryItemMonthEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemMonthEdit.EditFormat.FormatString = "yyyy-MM";
                        repositoryItemMonthEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemMonthEdit.Mask.EditMask = "yyyy-MM";
                        repositoryItemMonthEdit.DoubleClick += BindDateTimeEdit;
                        repositoryItemMonthEdit.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
                        repositoryItemMonthEdit.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
                        return repositoryItemMonthEdit;
                    case Sys_WorkSet_Editor.YearEdit:
                        RepositoryItemDateEdit repositoryItemYearEdit = new RepositoryItemDateEdit();
                        repositoryItemYearEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemYearEdit.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
                        repositoryItemYearEdit.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
                        repositoryItemYearEdit.EditMask = "yyyy";
                        repositoryItemYearEdit.DisplayFormat.FormatString = "yyyy";
                        repositoryItemYearEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemYearEdit.EditFormat.FormatString = "yyyy";
                        repositoryItemYearEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemYearEdit.Mask.EditMask = "yyyy";
                        repositoryItemYearEdit.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
                        repositoryItemYearEdit.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
                        repositoryItemYearEdit.DoubleClick += BindDateTimeEdit;
                        return repositoryItemYearEdit;
                    case Sys_WorkSet_Editor.SpinEdit:
                        RepositoryItemSpinEdit repositoryItemSpinEdit = new RepositoryItemSpinEdit();
                        repositoryItemSpinEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemSpinEdit.IsFloatValue = false;
                        return repositoryItemSpinEdit;
                    case Sys_WorkSet_Editor.TimeEdit:
                        RepositoryItemTimeEdit repositoryItemTimeEdit = new RepositoryItemTimeEdit();
                        repositoryItemTimeEdit.AccessibleName = sys_Bind.Bind_Id;
                        return repositoryItemTimeEdit;
                    case Sys_WorkSet_Editor.TextEdit:
                        RepositoryItemTextEdit repositoryItemTextEdit = new RepositoryItemTextEdit();
                        repositoryItemTextEdit.AccessibleName = sys_Bind.Bind_Id;
                        return repositoryItemTextEdit;
                    case Sys_WorkSet_Editor.ButtonEdit:
                        RepositoryItemButtonEdit repositoryItemButtonEdit = new RepositoryItemButtonEdit();
                        repositoryItemButtonEdit.AccessibleName = sys_Bind.Bind_Id;
                        return repositoryItemButtonEdit;
                    case Sys_WorkSet_Editor.CalcEdit:
                        RepositoryItemCalcEdit repositoryItemCalcEdit = new RepositoryItemCalcEdit();
                        repositoryItemCalcEdit.AccessibleName = sys_Bind.Bind_Id;
                        return repositoryItemCalcEdit;
                    case Sys_WorkSet_Editor.CheckEdit:
                        RepositoryItemCheckEdit repositoryItemCheckEdit = new RepositoryItemCheckEdit();
                        repositoryItemCheckEdit.Caption = "";
                        repositoryItemCheckEdit.ValueChecked = 1;
                        repositoryItemCheckEdit.ValueUnchecked = 0;
                        repositoryItemCheckEdit.ValueGrayed = null;
                        return repositoryItemCheckEdit;
                    case Sys_WorkSet_Editor.ProgressBar:
                        RepositoryItemProgressBar repositoryItemProgressBar = new RepositoryItemProgressBar();
                        repositoryItemProgressBar.AccessibleName = sys_Bind.Bind_Id;
                        return repositoryItemProgressBar;
                    case Sys_WorkSet_Editor.PhrasePage:
                        RepositoryItemButtonEdit repositoryItemPhrasePage = new RepositoryItemButtonEdit();
                        repositoryItemPhrasePage.ButtonClick += new ButtonPressedEventHandler((sender, e) =>
                        {
                            ButtonEdit buttonEdit = (ButtonEdit)sender;
                            PhrasePage phrasePage = new PhrasePage(buttonEdit.Text);
                            List<MyParameter> PhrasePageParameters = InitializePopupPara(sys_Popup);
                            DataTable repositoryItemPhrasePageDataSource = BaseService.Open(sys_Popup.Popup_WorkSet, PhrasePageParameters);
                            phrasePage.DisplayMember = sys_Popup.Popup_DisplayMember;
                            phrasePage.ValueMember = sys_Popup.Popup_ValueMember;
                            phrasePage.DataSource = repositoryItemPhrasePageDataSource;
                            if (phrasePage.ShowDialog() == DialogResult.OK)
                                buttonEdit.Text = phrasePage.ReturnText;
                        });
                        return repositoryItemPhrasePage;
                    case Sys_WorkSet_Editor.LookUpEdit:
                        #region LookUpEdit
                        RepositoryItemLookUpEdit repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                        repositoryItemLookUpEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemLookUpEdit.TextEditStyle = TextEditStyles.Standard;
                        repositoryItemLookUpEdit.NullText = String.Empty;
                        repositoryItemLookUpEdit.PopupFormSize = new Size((int)sys_Bind.Bind_Width, 80);
                        repositoryItemLookUpEdit.PopupFormMinSize = new Size((int)sys_Bind.Bind_Width, 20);
                        List<MyParameter> QueryParameters = InitializePopupPara(sys_Popup);
                        DataTable repositoryItemLookUpEditDataSource = BaseService.Open(sys_Popup.Popup_WorkSet, QueryParameters);
                        repositoryItemLookUpEdit.PopupFilterMode = PopupFilterMode.Contains;
                        repositoryItemLookUpEdit.ValueMember = sys_Popup.Popup_ValueMember;
                        repositoryItemLookUpEdit.DisplayMember = sys_Popup.Popup_DisplayMember;
                        repositoryItemLookUpEdit.DataSource = repositoryItemLookUpEditDataSource;
                        repositoryItemLookUpEdit.PopulateColumns();
                        //会导致选中状态时 变更内容弹出下拉条
                        //repositoryItemLookUpEdit.AutoSearchColumnIndex = repositoryItemLookUpEdit.Columns.IndexOf(repositoryItemLookUpEdit.Columns[sys_Popup.Popup_DisplayMember]);
                        repositoryItemLookUpEdit.SearchMode = SearchMode.AutoFilter;
                        foreach (LookUpColumnInfo gc in repositoryItemLookUpEdit.Columns)
                        {
                            if (gc.FieldName != sys_Popup.Popup_DisplayMember)
                            {
                                gc.Visible = false;
                            }
                        }
                        repositoryItemLookUpEdit.ShowHeader = false;
                        repositoryItemLookUpEdit.BestFitMode = BestFitMode.BestFitResizePopup;
                        repositoryItemLookUpEdit.BestFit();
                        repositoryItemLookUpEdit.Closed += RepositoryItemLookUpEdit_ParseEditValue;
                        return repositoryItemLookUpEdit;
                    #endregion
                    case Sys_WorkSet_Editor.TreeListLookUpEdit:
                        #region TreeListLookUpEdit
                        RepositoryItemTreeListLookUpEdit repositoryItemTreeListLookUpEdit = new RepositoryItemTreeListLookUpEdit();
                        repositoryItemTreeListLookUpEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemTreeListLookUpEdit.TextEditStyle = TextEditStyles.Standard;
                        repositoryItemTreeListLookUpEdit.NullText = String.Empty;
                        repositoryItemTreeListLookUpEdit.PopupFormSize = new Size((int)sys_Bind.Bind_Width, 200);
                        repositoryItemTreeListLookUpEdit.PopupFormMinSize = new Size((int)sys_Bind.Bind_Width, 80);
                        //BindTreeListLookUpEdit(repositoryItemTreeListLookUpEdit, sys_Bind.Bind_WorkSet);
                        List<MyParameter> treeParameters = InitializePopupPara(sys_Popup);
                        DataTable treedt = BaseService.Open(sys_Popup.Popup_WorkSet, treeParameters);
                        repositoryItemTreeListLookUpEdit.DataSource = treedt;
                        repositoryItemTreeListLookUpEdit.ValueMember = sys_Popup.Popup_ValueMember;
                        repositoryItemTreeListLookUpEdit.DisplayMember = sys_Popup.Popup_DisplayMember;
                        repositoryItemTreeListLookUpEdit.TreeList.DataSource = treedt;
                        repositoryItemTreeListLookUpEdit.TreeList.ParentFieldName = sys_Popup.Popup_ParentField;
                        repositoryItemTreeListLookUpEdit.TreeList.KeyFieldName = sys_Popup.Popup_KeyField;
                        repositoryItemTreeListLookUpEdit.TreeList.PopulateColumns();
                        repositoryItemTreeListLookUpEdit.PopupFilterMode = PopupFilterMode.Contains;
                        foreach (DevExpress.XtraTreeList.Columns.TreeListColumn gc in repositoryItemTreeListLookUpEdit.TreeList.Columns)
                        {
                            //Department_Nick Department_Nick
                            if (gc.FieldName != sys_Popup.Popup_DisplayMember)
                            {
                                gc.Visible = false;
                            }
                        }
                        repositoryItemTreeListLookUpEdit.TreeList.OptionsView.ShowColumns = false;
                        repositoryItemTreeListLookUpEdit.TreeList.OptionsView.ShowIndicator = false;
                        repositoryItemTreeListLookUpEdit.TreeList.OptionsView.ShowHorzLines = false;
                        repositoryItemTreeListLookUpEdit.TreeList.OptionsView.ShowVertLines = false;
                        repositoryItemTreeListLookUpEdit.Closed += RepositoryItemTreeListLookUpEdit_ParseEditValue;
                        //repositoryItemTreeListLookUpEdit.BestFitMode = BestFitMode.BestFitResizePopup();
                        return repositoryItemTreeListLookUpEdit;
                    #endregion
                    case Sys_WorkSet_Editor.ComboBoxEdit:
                        RepositoryItemComboBox repositoryItemComboBox = new RepositoryItemComboBox();
                        repositoryItemComboBox.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemComboBox.MouseDown += BindComboBox;
                        return repositoryItemComboBox;
                    case Sys_WorkSet_Editor.CheckedLookUpEdit:
                        RepositoryItemCheckedComboBoxEdit repositoryItemCheckedLookUpEdit = new RepositoryItemCheckedComboBoxEdit();
                        repositoryItemCheckedLookUpEdit.AccessibleName = sys_Bind.Bind_Id;
                        List<MyParameter> checkQueryParameters = InitializePopupPara(sys_Popup);
                        DataTable CheckedLookUpEditdt = BaseService.Open(sys_Popup.Popup_WorkSet, checkQueryParameters);
                        repositoryItemCheckedLookUpEdit.ValueMember = sys_Popup.Popup_ValueMember;
                        repositoryItemCheckedLookUpEdit.DisplayMember = sys_Popup.Popup_DisplayMember;
                        repositoryItemCheckedLookUpEdit.DataSource = CheckedLookUpEditdt;
                        return repositoryItemCheckedLookUpEdit;
                    case Sys_WorkSet_Editor.CheckedComboBoxEdit:
                        RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit = new RepositoryItemCheckedComboBoxEdit();
                        repositoryItemCheckedComboBoxEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemCheckedComboBoxEdit.MouseDown += BindCheckedComboBoxEdit;
                        return repositoryItemCheckedComboBoxEdit;
                    case Sys_WorkSet_Editor.FileInput:
                        RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit = new RepositoryItemHyperLinkEdit();
                        repositoryItemHyperLinkEdit.ReadOnly = false;
                        repositoryItemHyperLinkEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemHyperLinkEdit.Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis));
                        repositoryItemHyperLinkEdit.Buttons.Add(new EditorButton(ButtonPredefines.Clear));
                        repositoryItemHyperLinkEdit.ButtonClick += BindFileSelect;
                        repositoryItemHyperLinkEdit.OpenLink += BindFileDownload;
                        return repositoryItemHyperLinkEdit;
                    case Sys_WorkSet_Editor.ImageEdit:
                        RepositoryItemImageEdit repositoryItemImageEdit = new RepositoryItemImageEdit();
                        repositoryItemImageEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemImageEdit.PictureStoreMode = PictureStoreMode.ByteArray;
                        return repositoryItemImageEdit;
                    case Sys_WorkSet_Editor.SkinPicker:
                        RepositoryItemButtonEdit repositoryItemSkinPicker = new RepositoryItemButtonEdit();
                        repositoryItemSkinPicker.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemSkinPicker.ButtonClick += BindSkinPicker;
                        return repositoryItemSkinPicker;
                    //break;
                    case Sys_WorkSet_Editor.ImagePicker:
                        RepositoryItemButtonEdit repositoryItemImagePicker = new RepositoryItemButtonEdit();
                        repositoryItemImagePicker.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemImagePicker.ButtonClick += BindImagePicker;
                        return repositoryItemImagePicker;
                    case Sys_WorkSet_Editor.TreeSelect:
                        RepositoryItemButtonEdit repositoryItemTreeSelect = new RepositoryItemButtonEdit();
                        repositoryItemTreeSelect.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemTreeSelect.AccessibleDescription = sys_Bind.Bind_WorkSet.ToStringEx();
                        repositoryItemTreeSelect.ButtonClick += new ButtonPressedEventHandler(BindTreeSelect);
                        return repositoryItemTreeSelect;
                    case Sys_WorkSet_Editor.GridSelect:
                        RepositoryItemButtonEdit repositoryItemGridSelect = new RepositoryItemButtonEdit();
                        repositoryItemGridSelect.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemGridSelect.AccessibleDescription = sys_Bind.Bind_WorkSet.ToStringEx();
                        repositoryItemGridSelect.ButtonClick += new ButtonPressedEventHandler(BindGridSelect);
                        return repositoryItemGridSelect;
                    case Sys_WorkSet_Editor.GridPopup:
                        RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit = new RepositoryItemPopupContainerEdit();
                        repositoryItemPopupContainerEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemPopupContainerEdit.AccessibleDescription = sys_Bind.Bind_WorkSet.ToStringEx();
                        repositoryItemPopupContainerEdit.Buttons[0].Visible = false; //.Clear();
                        repositoryItemPopupContainerEdit.Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis));
                        PopupContainerControl gridPopupContainer = new PopupContainerControl();
                        gridPopupContainer.AutoSize = true;
                        gridPopupContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
                        gridPopupContainer.Width = 80;
                        GridControl gridPopup = new GridControl();
                        repositoryItemPopupContainerEdit.PopupControl = gridPopupContainer;
                        repositoryItemPopupContainerEdit.TextEditStyle = TextEditStyles.Standard;
                        gridPopup.Dock = DockStyle.Fill;
                        gridPopup.MainView = gridPopup.CreateView("GridView");
                        GridView gv = (GridView)gridPopup.MainView;
                        gv.OptionsBehavior.AutoPopulateColumns = false;
                        gv.OptionsView.ColumnAutoWidth = false;
                        gridPopup.MainView.BorderStyle = BorderStyles.NoBorder;
                        gridPopupContainer.Controls.Add(gridPopup);
                        repositoryItemPopupContainerEdit.KeyDown += SearchPopupGridBegin;
                        repositoryItemPopupContainerEdit.KeyUp += SearchPopupGridEnd;
                        repositoryItemPopupContainerEdit.EditValueChanged += SearchPopupGridQuery;
                        repositoryItemPopupContainerEdit.BeforePopup += new EventHandler(BindPopupGrid);
                        //弹窗  和  GridSelect 共用
                        repositoryItemPopupContainerEdit.ButtonClick += new ButtonPressedEventHandler(BindGridSelect);
                        return repositoryItemPopupContainerEdit;
                    case Sys_WorkSet_Editor.ExpressionEditor:
                        RepositoryItemButtonEdit repositoryItemExpressionEditorControl = new RepositoryItemButtonEdit();
                        repositoryItemExpressionEditorControl.ButtonClick += BindExpressionEditor;
                        return repositoryItemExpressionEditorControl;
                    case Sys_WorkSet_Editor.PopupPage:
                        RepositoryItemButtonEdit repositoryItemPopupPage = new RepositoryItemButtonEdit();
                        repositoryItemPopupPage.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemPopupPage.AccessibleDescription = sys_Bind.Bind_WorkSet.ToStringEx();
                        repositoryItemPopupPage.ButtonClick += new ButtonPressedEventHandler(BindPopupPage);
                        return repositoryItemPopupPage;
                    case Sys_WorkSet_Editor.FolderPicker:
                        RepositoryItemButtonEdit repositoryItemFolderPicker = new RepositoryItemButtonEdit();
                        repositoryItemFolderPicker.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemFolderPicker.ButtonClick += BindFolderPicker; ;
                        return repositoryItemFolderPicker;
                    case Sys_WorkSet_Editor.PasswordEdit:
                        RepositoryItemTextEdit repositoryItemPasswordEdit = new RepositoryItemTextEdit();
                        repositoryItemPasswordEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemPasswordEdit.UseSystemPasswordChar = true;
                        repositoryItemPasswordEdit.Enter += RepositoryItemPasswordEdit_Enter;
                        return repositoryItemPasswordEdit;
                    case Sys_WorkSet_Editor.ScriptEdit:
                        RepositoryItemButtonEdit repositoryItemScriptEdit = new RepositoryItemButtonEdit();
                        repositoryItemScriptEdit.ButtonClick += BindScriptEdit; ;
                        return repositoryItemScriptEdit;
                    case Sys_WorkSet_Editor.MemoEdit:
                        RepositoryItemMemoEdit repositoryItemMemoEdit = new RepositoryItemMemoEdit();
                        repositoryItemMemoEdit.DoubleClick += new EventHandler((sender, e) =>
                        {
                            if (string.IsNullOrEmpty(sys_Popup.Popup_WorkSet)) return;
                            MemoEdit memoEdit = (MemoEdit)sender;
                            PhrasePage phrasePage = new PhrasePage(memoEdit.Text);
                            List<MyParameter> PhrasePageParameters = InitializePopupPara(sys_Popup);
                            DataTable repositoryItemPhrasePageDataSource = BaseService.Open(sys_Popup.Popup_WorkSet, PhrasePageParameters);
                            phrasePage.DisplayMember = sys_Popup.Popup_DisplayMember;
                            phrasePage.ValueMember = sys_Popup.Popup_ValueMember;
                            phrasePage.DataSource = repositoryItemPhrasePageDataSource;
                            if (phrasePage.ShowDialog() == DialogResult.OK)
                                memoEdit.Text = phrasePage.ReturnText;
                        });
                        return repositoryItemMemoEdit;
                    //case Sys_WorkSet_Editor.SnapEdit:
                    //    RepositoryItemButtonEdit repositoryItemSnapEdit = new RepositoryItemButtonEdit();
                    //    repositoryItemSnapEdit.ButtonClick += BindSnapEdit;
                    //    repositoryItemSnapEdit.AccessibleName = PopupBind_Id_Str;
                    //    return repositoryItemSnapEdit;
                    //case Sys_WorkSet_Editor.RichEdit:
                    //    RepositoryItemButtonEdit repositoryItemRichEdit = new RepositoryItemButtonEdit();
                    //    repositoryItemRichEdit.ButtonClick += BindRichEdit;
                    //    repositoryItemRichEdit.AccessibleName = PopupBind_Id_Str;
                    //    return repositoryItemRichEdit;
                    //case Sys_WorkSet_Editor.DiagramEdit:
                    //    RepositoryItemButtonEdit repositoryItemDiagramEdit = new RepositoryItemButtonEdit();
                    //    repositoryItemDiagramEdit.ButtonClick += BindDiagramEdit;
                    //    repositoryItemDiagramEdit.AccessibleName = PopupBind_Id_Str;
                    //    return repositoryItemDiagramEdit;
                    //case Sys_WorkSet_Editor.ChartEdit:
                    //    RepositoryItemButtonEdit repositoryItemChartEdit = new RepositoryItemButtonEdit();
                    //    repositoryItemChartEdit.ButtonClick += BindChartEdit; ;
                    //    repositoryItemChartEdit.AccessibleName = PopupBind_Id_Str;
                    //    return repositoryItemChartEdit;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

            finally
            {
            }
            return null;
        }


        private void SearchPopupGridQuery(object sender, EventArgs e)
        {
            try
            {
                if (HasInput)
                {
                    PopupContainerEdit buttonEdit = (PopupContainerEdit)sender;
                    if (!buttonEdit.IsPopupOpen)
                    {
                        buttonEdit.ShowPopup();
                        buttonEdit.Focus();
                    }
                }
                HasInput = false;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
            }
        }
        private bool HasInput = false;
        private object obj;
        //PopupGrid 的实现
        //1.键盘按下 标志开始并记住当前文本
        //2.文本变更显示下拉条，并将标志结束
        //3.键盘放开如果文本未变更将标志结束
        //之所以这样实现是为了兼容汉字输入并且保证用代码变更文本不会触发下拉条
        //
        private void SearchPopupGridBegin(object sender, KeyEventArgs e)
        {


            try
            {
                HasInput = true;
                PopupContainerEdit buttonEdit = (PopupContainerEdit)sender;
                obj = buttonEdit.EditValue;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void SearchPopupGridEnd(object sender, KeyEventArgs e)
        {


            try
            {
                PopupContainerEdit buttonEdit = (PopupContainerEdit)sender;
                if (buttonEdit.EditValue == obj)
                {
                    HasInput = false;
                }
                //英文状态下自动重新获取焦点
                Control c = buttonEdit.Properties.PopupControl.Controls[0];
                if (c.GetType() == typeof(GridControl))
                {
                    GridControl gridPopup = (GridControl)c;
                    GridView gv = (GridView)gridPopup.MainView;
                    gv.FindFilterText = buttonEdit.Text;
                    if (e.KeyCode == Keys.Down)
                    {
                        gv.FocusedRowHandle += 1;
                        buttonEdit.Focus();
                    }
                    if (e.KeyCode == Keys.Up)
                    {
                        gv.FocusedRowHandle -= 1;
                        buttonEdit.Focus();
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
                        List<MyParameter> para_Sys_Bind = InitializePopupPara(sys_Popup);
                        DataTable GridData = BaseService.Open(sys_Popup.Popup_WorkSet, para_Sys_Bind);
                        para_Sys_Bind.Clear();
                        para_Sys_Bind.Add("@Bind_Id", DbType.String, sys_Popup.Popup_Target, null);
                        DataTable PopupBind = BaseService.Open("SystemPopupBind_Popup", para_Sys_Bind);
                        if (PopupBind == null || PopupBind.Rows.Count == 0) return;
                        List<Sys_PopupBind> sys_PopupBinds = EntityHelper.GetEntities<Sys_PopupBind>(PopupBind);
                        DataTable sdt = (DataTable)gridPopup.DataSource;
                        if (sdt == null) return;
                        DataTable rdt = sdt.Clone();
                        if (gv.FocusedRowHandle >= 0)
                        {
                            foreach (int i in gv.GetSelectedRows())
                            {
                                rdt.Rows.Add(gv.GetDataRow(i).ItemArray);
                            }
                        }
                        //else
                        //{
                        //    rdt.Rows.Add(rdt.NewRow());
                        //}
                        if (rdt.Rows.Count > 0)
                        {
                            if (buttonEdit.Parent.GetType() == typeof(GridControl))
                            {
                                GridControl grid = (GridControl)buttonEdit.Parent;
                                GridView abv = (GridView)grid.MainView;
                                if (abv.IsNewItemRow(abv.FocusedRowHandle))
                                {
                                    //abv.AddNewRow();
                                    abv.UpdateCurrentRow();
                                }
                            }
                            ParseValue(sys_Popup.Popup_Target, rdt, sys_PopupBinds);
                        }
                        buttonEdit.ClosePopup();
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void BindPopupGrid(object sender, EventArgs e)
        {


            try
            {
                PopupContainerEdit buttonEdit = (PopupContainerEdit)sender;
                Control c = buttonEdit.Properties.PopupControl.Controls[0];
                if (c.GetType() != typeof(GridControl)) return;
                GridControl gridPopup = (GridControl)c;
                //if (gridPopup.DataSource != null) return;
                Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
                List<MyParameter> para_Sys_Bind = InitializePopupPara(sys_Popup);
                DataTable GridData = BaseService.Open(sys_Popup.Popup_WorkSet, para_Sys_Bind);
                para_Sys_Bind.Clear();
                para_Sys_Bind.Add("@Bind_Id", DbType.String, sys_Popup.Popup_Target, null);
                DataTable PopupBind = BaseService.Open("SystemPopupBind_Popup", para_Sys_Bind);
                if (PopupBind == null || PopupBind.Rows.Count == 0) return;
                List<Sys_PopupBind> sys_PopupBinds = EntityHelper.GetEntities<Sys_PopupBind>(PopupBind);
                gridPopup.DataSource = GridData;
                GridView gv = (GridView)gridPopup.MainView;
                gv.BeginUpdate();
                gridPopup.FocusedView = gv;
                foreach (Sys_PopupBind sys_PopupBind in sys_PopupBinds.OrderBy(p => p.PopupBind_Sort))
                {
                    GridColumn gc = gv.Columns[sys_PopupBind.PopupBind_Field];
                    if (gc == null)
                    {
                        gc = new GridColumn();
                        gv.Columns.Add(gc);

                    }
                    gc.FieldName = sys_PopupBind.PopupBind_Field;
                    gc.Width = gc.GetBestWidth();
                    gc.VisibleIndex = sys_PopupBind.PopupBind_Sort;
                    gc.Visible = sys_PopupBind.PopupBind_Visible;
                    gc.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                    gc.Caption = sys_PopupBind.PopupBind_Nick;
                }
                gv.OptionsBehavior.Editable = false;
                gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                gv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                gv.BestFitMaxRowCount = 100;
                gv.OptionsView.ShowGroupPanel = false;
                //gv.BestFitColumns();
                gv.EndUpdate();
                gv.BestFitColumns();
                int popupWidth = 80;
                foreach (GridColumn item in gv.Columns)
                {
                    popupWidth += item.Width;
                }
                buttonEdit.Properties.PopupControl.Height = 240;
                buttonEdit.Properties.PopupControl.Width = popupWidth;
                bool flag = false;
                gv.DoubleClick += delegate
                {
                    if (flag)
                    {
                        DataTable sdt = (DataTable)gridPopup.DataSource;
                        DataTable rdt = sdt.Clone();
                        if (gv.FocusedRowHandle >= 0)
                        {
                            foreach (int i in gv.GetSelectedRows())
                            {
                                rdt.Rows.Add(gv.GetDataRow(i).ItemArray);
                            }
                        }
                        if (rdt.Rows.Count > 0)
                        {
                            if (buttonEdit.Parent.GetType() == typeof(GridControl))
                            {
                                GridControl grid = (GridControl)buttonEdit.Parent;
                                GridView abv = (GridView)grid.MainView;
                                if (abv.IsNewItemRow(abv.FocusedRowHandle))
                                {
                                    //abv.AddNewRow();
                                    abv.UpdateCurrentRow();
                                }
                            }
                            ParseValue(sys_Popup.Popup_Target, rdt, sys_PopupBinds);
                        }
                        //ParseValue(sys_Popup.Popup_Target, rdt, sys_PopupBinds);
                        buttonEdit.ClosePopup();
                    }
                };
                gv.MouseDown += delegate (object sender2, MouseEventArgs e2)
                {
                    DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gv.CalcHitInfo(new Point(e2.X, e2.Y));
                    flag = hInfo.InDataRow;
                };
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }


        }
        private void BindExpressionEditor(object sender, ButtonPressedEventArgs e)
        {


            try
            {
                ButtonEdit buttonEdit = (ButtonEdit)sender;
                GridColumn gc = new GridColumn();
                gc.UnboundExpression = buttonEdit.Text;
                ExpressionEditorFormEx expressionEditorControl = new ExpressionEditorFormEx(gc, null);
                if (expressionEditorControl.ShowDialog() == DialogResult.OK)
                    buttonEdit.Text = expressionEditorControl.Expression;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void BindPhrasePage(object sender, ButtonPressedEventArgs e)
        {


            try
            {
                ButtonEdit buttonEdit = (ButtonEdit)sender;
                PhrasePage phrasePage = new PhrasePage(buttonEdit.Text);
                phrasePage.ShowDialog();
                buttonEdit.Text = phrasePage.ReturnText;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void BindScriptEdit(object sender, ButtonPressedEventArgs e)
        {


            try
            {
                ButtonEdit buttonEdit = (ButtonEdit)sender;
                ScriptPage scriptPage = new ScriptPage(buttonEdit.Text);
                scriptPage.ShowDialog();
                buttonEdit.Text = scriptPage.Script;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private List<MyParameter> InitializePopupPara(Sys_Popup sys_Popup)
        {


            try
            {
                List<MyParameter> ParameterList = new List<MyParameter>();
                List<MyParameter> para_Sys_Bind = new List<MyParameter>();
                para_Sys_Bind.Add("@Bind_Id", DbType.String, sys_Popup.Popup_Target, null);
                DataTable PopupBind = BaseService.Open("SystemPopupBind_Popup", para_Sys_Bind);
                if (PopupBind == null || PopupBind.Rows.Count == 0) return new List<MyParameter>();
                List<Sys_PopupBind> sys_PopupBinds = EntityHelper.GetEntities<Sys_PopupBind>(PopupBind);
                foreach (Sys_PopupBind spb in sys_PopupBinds.Where(p => p.PopupBind_Name.StartsWith("@")))
                {
                    foreach (Sys_Bind sys_Bind in BindList.Where(b => b.Bind_Name == spb.PopupBind_Bind))
                    {
                        object control = sys_Bind.Bind_Control;
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
                                Control[] bindControls = this.Controls.Find(sys_Bind.Bind_Field, true);
                                if (bindControls.Length > 0)
                                {
                                    sys_Bind.Bind_Control = bindControls[0];
                                }
                            }
                            control = sys_Bind.Bind_Control;
                        }
                        if (control != null)
                        {
                            object obj = null;
                            if (control.GetType() != typeof(GridColumn))
                            {
                                if (!string.IsNullOrEmpty(sys_Bind.Bind_Property))
                                {
                                    obj = ReflectionHelper.GetProperty(control, sys_Bind.Bind_Property);
                                }
                                else
                                {
                                    obj = ReflectionHelper.GetProperty(control, "EditValue");
                                    if (obj == null)
                                        obj = ReflectionHelper.GetProperty(control, "Text");
                                }
                            }
                            else
                            {
                                GridColumn bgc = (GridColumn)control;
                                obj = bgc.View.GetFocusedRowCellValue(bgc);
                            }
                            if (obj != null && obj.Equals(DBNull.Value))
                            {
                                obj = null;
                            }
                            if (ParameterList.Find(p => p.Name == "@" + spb.PopupBind_Name.TrimStart('@')) == null)
                                ParameterList.Add(spb.PopupBind_Name.TrimStart('@'), (DbType)sys_Bind.Bind_SqlDbType, obj, null);
                        }
                        else
                        {
                            if (control == null)
                            {
                                Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Id == sys_Bind.Bind_WorkSet);
                                if (sys_WorkSet.WorkSet_Control != null && sys_WorkSet.WorkSet_Control.GetType().Equals(typeof(GridControl)))
                                {
                                    GridControl tgd = (GridControl)sys_WorkSet.WorkSet_Control;
                                    if (tgd != null)
                                    {
                                        GridView tabv = (GridView)tgd.MainView;
                                        string col = sys_Bind.Bind_Field;
                                        if (tabv.FocusedRowHandle >= 0 || (tabv.FocusedRowHandle < 0 && tabv.IsNewItemRow(tabv.FocusedRowHandle)))
                                        {
                                            object obj = tabv.GetFocusedRowCellValue(col);
                                            if (obj != null && obj.Equals(DBNull.Value))
                                            {
                                                obj = null;
                                            }
                                            if (ParameterList.Find(p => p.Name == "@" + spb.PopupBind_Name.TrimStart('@')) == null)
                                                ParameterList.Add(spb.PopupBind_Name.TrimStart('@'), (DbType)sys_Bind.Bind_SqlDbType, obj, null);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                return ParameterList;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
                return null;
            }
            finally
            {
            }

        }
        private void BindDateTimeEdit(object sender, EventArgs e)
        {


            try
            {
                DateEdit dateEdit = (DateEdit)sender;
                if (dateEdit.EditValue == null || dateEdit.EditValue == DBNull.Value)
                    dateEdit.EditValue = DateTime.Now;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
            }
        }
        protected BaseEdit InitializeBaseEdit(Sys_Bind sys_Bind, BaseEdit baseEdit)
        {


            try
            {
                if (baseEdit != null)
                {
                    //baseEdit.Name = sys_Bind.Bind_Field;
                    baseEdit.Text = sys_Bind.Bind_Default;
                    baseEdit.EditValue = sys_Bind.Bind_Default;
                    if (baseEdit.GetType().Equals(typeof(CheckEdit)))
                    {
                        CheckEdit chkEdit = (CheckEdit)baseEdit;
                        chkEdit.Text = string.Empty;
                        chkEdit.Checked = sys_Bind.Bind_Default.ToBoolEx();
                    }
                    baseEdit.Properties.Appearance.Options.UseTextOptions = true;
                    baseEdit.Properties.Appearance.TextOptions.HAlignment = (DevExpress.Utils.HorzAlignment)sys_Bind.Bind_TextAlignment;
                    if (sys_Bind.Bind_ForeColor < 0)
                        baseEdit.ForeColor = Color.FromArgb(sys_Bind.Bind_ForeColor);
                    if (sys_Bind.Bind_BackColor < 0)
                        baseEdit.BackColor = Color.FromArgb(sys_Bind.Bind_BackColor);
                    if (sys_Bind.Bind_BorderColor < 0)
                    {
                        baseEdit.Properties.Appearance.Options.UseBorderColor = true;
                        baseEdit.Properties.Appearance.BorderColor = Color.FromArgb(sys_Bind.Bind_BorderColor);
                        baseEdit.BorderStyle = BorderStyles.Simple;
                    }
                    baseEdit.ToolTip = sys_Bind.Bind_ToolTip;
                    //baseEdit.ReadOnly = sys_Bind.Bind_ReadOnly;
                    //baseEdit.Visible = sys_Bind.Bind_Visible;
                    LayoutControl lyc = (LayoutControl)baseEdit.StyleController;
                    if (lyc != null)
                    {
                        foreach (object lci in lyc.Items)
                        {
                            if (lci.GetType() == typeof(LayoutControlItem))
                            {
                                LayoutControlItem lyci = (LayoutControlItem)lci;
                                if (lyci.Control == baseEdit)
                                {
                                    lyci.AppearanceItemCaption.TextOptions.HAlignment = (DevExpress.Utils.HorzAlignment)sys_Bind.Bind_TitleAlignment;
                                    lyci.Name = "oli_" + sys_Bind.Bind_Name;
                                    lyci.Text = sys_Bind.Bind_Nick;
                                    //lyci.Visibility = sys_Bind.Bind_Visible ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                                }
                            }
                        }
                    }
                    baseEdit.GotFocus += Control_GotFocus;
                }
                List<MyParameter> myParameters = new List<MyParameter>();
                if (string.IsNullOrEmpty(sys_Bind.Bind_Popup)) return new TextEdit();
                myParameters.Add("@Popup_Id", DbType.String, sys_Bind.Bind_Popup, null);
                DataTable dt = BaseService.Open("SystemPopup_PopupBind", myParameters);
                Sys_Popup sys_Popup = EntityHelper.GetEntity<Sys_Popup>(dt);
                sys_Popup.Popup_Target = sys_Bind.Bind_Id;
                PopupList[sys_Bind.Bind_Id] = sys_Popup;

                switch ((Sys_WorkSet_Editor)sys_Popup.Popup_Type)
                {
                    case Sys_WorkSet_Editor.ColorEdit:
                        if (baseEdit == null) baseEdit = new ColorEdit();
                        ColorEdit repositoryItemColorEdit = (ColorEdit)baseEdit;// new ColorEdit();
                        repositoryItemColorEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemColorEdit.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
                        repositoryItemColorEdit.Properties.StoreColorAsInteger = true;
                        repositoryItemColorEdit.KeyDown += BindColorEditClear;
                        return repositoryItemColorEdit;
                    case Sys_WorkSet_Editor.DateTimeEdit:
                        DateEdit repositoryItemDateTimeEdit = new DateEdit();
                        repositoryItemDateTimeEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemDateTimeEdit.Properties.ShowToday = true;
                        //repositoryItemDateTimeEdit.Properties.TodayDate = repositoryItemDateTimeEdit.EditValue == null ? DateTime.Now : repositoryItemDateTimeEdit.DateTime;
                        repositoryItemDateTimeEdit.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
                        repositoryItemDateTimeEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
                        repositoryItemDateTimeEdit.Properties.EditMask = "yyyy-MM-dd HH:mm:ss";
                        repositoryItemDateTimeEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        repositoryItemDateTimeEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemDateTimeEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        repositoryItemDateTimeEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemDateTimeEdit.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
                        repositoryItemDateTimeEdit.DoubleClick += BindDateTimeEdit;
                        return repositoryItemDateTimeEdit;
                    case Sys_WorkSet_Editor.DateEdit:
                        DateEdit repositoryItemDateEdit = new DateEdit();
                        repositoryItemDateEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemDateEdit.Properties.ShowToday = true;
                        //repositoryItemDateEdit.Properties.TodayDate = repositoryItemDateEdit.EditValue == null ? DateTime.Now : repositoryItemDateEdit.DateTime;
                        repositoryItemDateEdit.Properties.EditMask = "yyyy-MM-dd";
                        repositoryItemDateEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
                        repositoryItemDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemDateEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd";
                        repositoryItemDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemDateEdit.Properties.Mask.EditMask = "yyyy-MM-dd";
                        repositoryItemDateEdit.DoubleClick += BindDateTimeEdit;
                        return repositoryItemDateEdit;
                    case Sys_WorkSet_Editor.MonthEdit:
                        DateEdit repositoryItemMonthEdit = new DateEdit();
                        repositoryItemMonthEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemMonthEdit.Properties.ShowToday = true;
                        //repositoryItemMonthEdit.Properties.TodayDate = repositoryItemMonthEdit.EditValue == null ? DateTime.Now : repositoryItemMonthEdit.DateTime;
                        //repositoryItemMonthEdit.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
                        //repositoryItemMonthEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
                        repositoryItemMonthEdit.Properties.EditMask = "yyyy-MM";
                        repositoryItemMonthEdit.Properties.DisplayFormat.FormatString = "yyyy-MM";
                        repositoryItemMonthEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemMonthEdit.Properties.EditFormat.FormatString = "yyyy-MM";
                        repositoryItemMonthEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemMonthEdit.Properties.Mask.EditMask = "yyyy-MM";
                        repositoryItemMonthEdit.DoubleClick += BindDateTimeEdit;
                        repositoryItemMonthEdit.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
                        repositoryItemMonthEdit.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
                        return repositoryItemMonthEdit;
                    case Sys_WorkSet_Editor.YearEdit:
                        DateEdit repositoryItemYearEdit = new DateEdit();
                        repositoryItemYearEdit.AccessibleName = sys_Bind.Bind_Id;
                        //repositoryItemYearEdit.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
                        //repositoryItemYearEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
                        repositoryItemYearEdit.Properties.ShowToday = true;
                        //repositoryItemYearEdit.Properties.TodayDate = repositoryItemYearEdit.EditValue == null ? DateTime.Now : repositoryItemYearEdit.DateTime;
                        repositoryItemYearEdit.Properties.EditMask = "yyyy";
                        repositoryItemYearEdit.Properties.DisplayFormat.FormatString = "yyyy";
                        repositoryItemYearEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemYearEdit.Properties.EditFormat.FormatString = "yyyy";
                        repositoryItemYearEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        repositoryItemYearEdit.Properties.Mask.EditMask = "yyyy";
                        repositoryItemYearEdit.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
                        repositoryItemYearEdit.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
                        repositoryItemYearEdit.DoubleClick += BindDateTimeEdit;
                        return repositoryItemYearEdit;
                    case Sys_WorkSet_Editor.SpinEdit:
                        if (baseEdit == null) baseEdit = new SpinEdit();
                        SpinEdit repositoryItemSpinEdit = (SpinEdit)baseEdit;// new SpinEdit();
                        repositoryItemSpinEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemSpinEdit.Properties.IsFloatValue = false;
                        return repositoryItemSpinEdit;
                    case Sys_WorkSet_Editor.TimeEdit:
                        if (baseEdit == null) baseEdit = new TimeEdit();
                        TimeEdit repositoryItemTimeEdit = (TimeEdit)baseEdit;// new TimeEdit();
                        repositoryItemTimeEdit.AccessibleName = sys_Bind.Bind_Id;
                        return repositoryItemTimeEdit;
                    case Sys_WorkSet_Editor.TextEdit:
                        if (baseEdit == null) baseEdit = new TextEdit();
                        TextEdit repositoryItemTextEdit = (TextEdit)baseEdit;// new TextEdit();
                        repositoryItemTextEdit.AccessibleName = sys_Bind.Bind_Id;
                        return repositoryItemTextEdit;
                    case Sys_WorkSet_Editor.ButtonEdit:
                        if (baseEdit == null) baseEdit = new ButtonEdit();
                        ButtonEdit repositoryItemButtonEdit = (ButtonEdit)baseEdit;// new ButtonEdit();
                        repositoryItemButtonEdit.AccessibleName = sys_Bind.Bind_Id;
                        return repositoryItemButtonEdit;
                    case Sys_WorkSet_Editor.CalcEdit:
                        if (baseEdit == null) baseEdit = new CalcEdit();
                        CalcEdit repositoryItemCalcEdit = (CalcEdit)baseEdit;// new CalcEdit();
                        repositoryItemCalcEdit.AccessibleName = sys_Bind.Bind_Id;
                        return repositoryItemCalcEdit;
                    case Sys_WorkSet_Editor.CheckEdit:
                        if (baseEdit == null) baseEdit = new CheckEdit();
                        CheckEdit repositoryItemCheckEdit = (CheckEdit)baseEdit;// new CheckEdit();
                        repositoryItemCheckEdit.Properties.Caption = "";
                        repositoryItemCheckEdit.Properties.ValueChecked = 1;
                        repositoryItemCheckEdit.Properties.ValueUnchecked = 0;
                        repositoryItemCheckEdit.Properties.ValueGrayed = null;
                        return repositoryItemCheckEdit;
                    case Sys_WorkSet_Editor.ProgressBar:
                        if (baseEdit == null) baseEdit = new ProgressBarControl();
                        ProgressBarControl repositoryItemProgressBar = (ProgressBarControl)baseEdit;// new ProgressBarControl();
                        repositoryItemProgressBar.AccessibleName = sys_Bind.Bind_Id;
                        return repositoryItemProgressBar;
                    case Sys_WorkSet_Editor.PhrasePage:
                        ButtonEdit repositoryItemPhrasePage = new ButtonEdit();
                        repositoryItemPhrasePage.ButtonClick += new ButtonPressedEventHandler((sender, e) =>
                        {
                            ButtonEdit buttonEdit = (ButtonEdit)sender;
                            PhrasePage phrasePage = new PhrasePage(buttonEdit.Text);
                            List<MyParameter> PhrasePageParameters = InitializePopupPara(sys_Popup);
                            DataTable repositoryItemPhrasePageDataSource = BaseService.Open(sys_Popup.Popup_WorkSet, PhrasePageParameters);
                            phrasePage.DisplayMember = sys_Popup.Popup_DisplayMember;
                            phrasePage.ValueMember = sys_Popup.Popup_ValueMember;
                            phrasePage.DataSource = repositoryItemPhrasePageDataSource;
                            if (phrasePage.ShowDialog() == DialogResult.OK)
                                buttonEdit.Text = phrasePage.ReturnText;
                        });
                        return repositoryItemPhrasePage;
                    case Sys_WorkSet_Editor.LookUpEdit:
                        #region LookUpEdit
                        if (baseEdit == null) baseEdit = new LookUpEdit();
                        LookUpEdit repositoryItemLookUpEdit = (LookUpEdit)baseEdit;// new LookUpEdit();
                        repositoryItemLookUpEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemLookUpEdit.Properties.TextEditStyle = TextEditStyles.Standard;
                        repositoryItemLookUpEdit.Properties.NullText = String.Empty;
                        repositoryItemLookUpEdit.Properties.PopupFormSize = new Size((int)sys_Bind.Bind_Width, 80);
                        repositoryItemLookUpEdit.Properties.PopupFormMinSize = new Size((int)sys_Bind.Bind_Width, 20);
                        List<MyParameter> QueryParameters = InitializePopupPara(sys_Popup);
                        DataTable sdt = BaseService.Open(sys_Popup.Popup_WorkSet, QueryParameters);
                        repositoryItemLookUpEdit.Properties.ValueMember = sys_Popup.Popup_ValueMember;
                        repositoryItemLookUpEdit.Properties.DisplayMember = sys_Popup.Popup_DisplayMember;
                        repositoryItemLookUpEdit.Properties.DataSource = sdt;
                        //repositoryItemLookUpEdit.Properties.PopulateColumns();
                        repositoryItemLookUpEdit.Properties.PopupFilterMode = PopupFilterMode.Contains;
                        foreach (DataColumn dc in sdt.Columns)
                        {
                            LookUpColumnInfo lc = new LookUpColumnInfo();
                            lc.FieldName = dc.ColumnName;
                            repositoryItemLookUpEdit.Properties.Columns.Add(lc);
                            if (sys_Popup.Popup_DisplayMember != dc.ColumnName)
                                lc.Visible = false;
                        }
                        //会导致选中状态时 变更内容弹出下拉条
                        //repositoryItemLookUpEdit.Properties.AutoSearchColumnIndex = repositoryItemLookUpEdit.Properties.Columns.IndexOf(repositoryItemLookUpEdit.Properties.Columns[sys_Popup.Popup_DisplayMember]);
                        repositoryItemLookUpEdit.Properties.SearchMode = SearchMode.AutoFilter;
                        repositoryItemLookUpEdit.Properties.ShowHeader = false;
                        repositoryItemLookUpEdit.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                        repositoryItemLookUpEdit.Properties.BestFit();
                        repositoryItemLookUpEdit.Closed += RepositoryItemLookUpEdit_ParseEditValue;
                        return repositoryItemLookUpEdit;
                    #endregion
                    case Sys_WorkSet_Editor.TreeListLookUpEdit:
                        #region TreeListLookUpEdit
                        if (baseEdit == null) baseEdit = new TreeListLookUpEdit();
                        TreeListLookUpEdit repositoryItemTreeListLookUpEdit = (TreeListLookUpEdit)baseEdit;// new TreeListLookUpEdit();
                        repositoryItemTreeListLookUpEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemTreeListLookUpEdit.Properties.TextEditStyle = TextEditStyles.Standard;
                        repositoryItemTreeListLookUpEdit.Properties.NullText = String.Empty;
                        //repositoryItemTreeListLookUpEdit.Properties.PopupFormSize = new Size((int)sys_Bind.Bind_Width, 80);
                        //repositoryItemTreeListLookUpEdit.Properties.PopupFormMinSize = new Size((int)sys_Bind.Bind_Width, 20);
                        //BindTreeListLookUpEdit(repositoryItemTreeListLookUpEdit, sys_Bind.Bind_WorkSet);
                        List<MyParameter> treeParameters = InitializePopupPara(sys_Popup);
                        DataTable tdt = BaseService.Open(sys_Popup.Popup_WorkSet, treeParameters);
                        repositoryItemTreeListLookUpEdit.Properties.ValueMember = sys_Popup.Popup_ValueMember;
                        repositoryItemTreeListLookUpEdit.Properties.DisplayMember = sys_Popup.Popup_DisplayMember;
                        repositoryItemTreeListLookUpEdit.Properties.DataSource = tdt;
                        repositoryItemTreeListLookUpEdit.Properties.TreeList.ParentFieldName = sys_Popup.Popup_ParentField;
                        repositoryItemTreeListLookUpEdit.Properties.TreeList.KeyFieldName = sys_Popup.Popup_KeyField;
                        //repositoryItemTreeListLookUpEdit.Properties.TreeList.PopulateColumns();
                        repositoryItemTreeListLookUpEdit.Properties.PopupFilterMode = PopupFilterMode.Contains;
                        repositoryItemTreeListLookUpEdit.Properties.TreeList.PopulateColumns();
                        foreach (DevExpress.XtraTreeList.Columns.TreeListColumn gc in repositoryItemTreeListLookUpEdit.Properties.TreeList.Columns)
                        {
                            //Department_Nick Department_Nick
                            if (gc.FieldName != sys_Popup.Popup_DisplayMember)
                            {
                                gc.Visible = false;
                            }
                        }
                        //foreach (DataColumn dc in tdt.Columns)
                        //{
                        //    DevExpress.XtraTreeList.Columns.TreeListColumn lc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        //    lc.FieldName = dc.ColumnName;
                        //    repositoryItemTreeListLookUpEdit.Properties.TreeList.Columns.Add(lc);
                        //    if (sys_Popup.Popup_DisplayMember != lc.FieldName)
                        //        lc.Visible = false;
                        //}
                        repositoryItemTreeListLookUpEdit.Properties.TreeList.OptionsView.ShowColumns = false;
                        repositoryItemTreeListLookUpEdit.Properties.TreeList.OptionsView.ShowIndicator = false;
                        repositoryItemTreeListLookUpEdit.Properties.TreeList.OptionsView.ShowHorzLines = false;
                        repositoryItemTreeListLookUpEdit.Properties.TreeList.OptionsView.ShowVertLines = false;
                        repositoryItemTreeListLookUpEdit.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                        repositoryItemTreeListLookUpEdit.Closed += RepositoryItemTreeListLookUpEdit_ParseEditValue;
                        return repositoryItemTreeListLookUpEdit;
                    #endregion
                    case Sys_WorkSet_Editor.ComboBoxEdit:
                        if (baseEdit == null) baseEdit = new ComboBoxEdit();
                        ComboBoxEdit repositoryItemComboBox = (ComboBoxEdit)baseEdit;// new ComboBoxEdit();
                        repositoryItemComboBox.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemComboBox.MouseDown += BindComboBox;
                        return repositoryItemComboBox;
                    case Sys_WorkSet_Editor.CheckedLookUpEdit:
                        if (baseEdit == null) baseEdit = new CheckedComboBoxEdit();
                        CheckedComboBoxEdit repositoryItemCheckedLookUpEdit = (CheckedComboBoxEdit)baseEdit;// new CheckedComboBoxEdit();
                        repositoryItemCheckedLookUpEdit.AccessibleName = sys_Bind.Bind_Id;
                        List<MyParameter> checkQueryParameters = InitializePopupPara(sys_Popup);
                        DataTable CheckedLookUpEditdt = BaseService.Open(sys_Popup.Popup_WorkSet, checkQueryParameters);
                        repositoryItemCheckedLookUpEdit.Properties.ValueMember = sys_Popup.Popup_ValueMember;
                        repositoryItemCheckedLookUpEdit.Properties.DisplayMember = sys_Popup.Popup_DisplayMember;
                        repositoryItemCheckedLookUpEdit.Properties.DataSource = CheckedLookUpEditdt;
                        return repositoryItemCheckedLookUpEdit;
                    case Sys_WorkSet_Editor.CheckedComboBoxEdit:
                        if (baseEdit == null) baseEdit = new CheckedComboBoxEdit();
                        CheckedComboBoxEdit repositoryItemCheckedComboBoxEdit = (CheckedComboBoxEdit)baseEdit;// new CheckedComboBoxEdit();
                        repositoryItemCheckedComboBoxEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemCheckedComboBoxEdit.MouseDown += BindCheckedComboBoxEdit;
                        return repositoryItemCheckedComboBoxEdit;
                    case Sys_WorkSet_Editor.FileInput:
                        if (baseEdit == null) baseEdit = new HyperLinkEdit();
                        HyperLinkEdit repositoryItemHyperLinkEdit = (HyperLinkEdit)baseEdit;// new HyperLinkEdit();
                        repositoryItemHyperLinkEdit.ReadOnly = false;
                        repositoryItemHyperLinkEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemHyperLinkEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis));
                        repositoryItemHyperLinkEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Clear));
                        repositoryItemHyperLinkEdit.ButtonClick += BindFileSelect;
                        repositoryItemHyperLinkEdit.OpenLink += BindFileDownload;
                        return repositoryItemHyperLinkEdit;
                    //case Sys_WorkSet_Editor.FileUpload:
                    //    if (baseEdit == null) baseEdit = new HyperLinkEdit();
                    //    HyperLinkEdit repositoryItemFileUpload = (HyperLinkEdit)baseEdit;// new HyperLinkEdit();
                    //    repositoryItemFileUpload.ReadOnly = false;
                    //    repositoryItemFileUpload.AccessibleName = sys_Bind.Bind_Id;
                    //    repositoryItemFileUpload.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis));
                    //    repositoryItemFileUpload.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Clear));
                    //    repositoryItemFileUpload.ButtonClick += BindFileSelect;
                    //    repositoryItemFileUpload.OpenLink += BindFileDownload;
                    //    return repositoryItemFileUpload;
                    case Sys_WorkSet_Editor.ImageEdit:
                        if (baseEdit == null) baseEdit = new ImageEdit();
                        ImageEdit repositoryItemImageEdit = (ImageEdit)baseEdit;// new ImageEdit();
                        repositoryItemImageEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemImageEdit.Properties.PictureStoreMode = PictureStoreMode.ByteArray;
                        return repositoryItemImageEdit;
                    case Sys_WorkSet_Editor.SkinPicker:
                        if (baseEdit == null) baseEdit = new ButtonEdit();
                        ButtonEdit repositoryItemSkinPicker = (ButtonEdit)baseEdit;// new ButtonEdit();
                        repositoryItemSkinPicker.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemSkinPicker.ButtonClick += BindSkinPicker;
                        return repositoryItemSkinPicker;
                    //break;
                    case Sys_WorkSet_Editor.ImagePicker:
                        if (baseEdit == null) baseEdit = new ButtonEdit();
                        ButtonEdit repositoryItemImagePicker = (ButtonEdit)baseEdit;// new ButtonEdit();
                        repositoryItemImagePicker.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemImagePicker.ButtonClick += BindImagePicker;
                        return repositoryItemImagePicker;
                    case Sys_WorkSet_Editor.TreeSelect:
                        if (baseEdit == null) baseEdit = new ButtonEdit();
                        ButtonEdit repositoryItemTreeSelect = (ButtonEdit)baseEdit;// new ButtonEdit();
                        repositoryItemTreeSelect.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemTreeSelect.AccessibleDescription = sys_Bind.Bind_WorkSet.ToStringEx();
                        repositoryItemTreeSelect.ButtonClick += new ButtonPressedEventHandler(BindTreeSelect);
                        return repositoryItemTreeSelect;
                    case Sys_WorkSet_Editor.GridSelect:
                        if (baseEdit == null) baseEdit = new ButtonEdit();
                        ButtonEdit repositoryItemGridSelect = (ButtonEdit)baseEdit;// new ButtonEdit();
                        repositoryItemGridSelect.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemGridSelect.AccessibleDescription = sys_Bind.Bind_WorkSet.ToStringEx();
                        repositoryItemGridSelect.ButtonClick += new ButtonPressedEventHandler(BindGridSelect);
                        return repositoryItemGridSelect;
                    case Sys_WorkSet_Editor.GridPopup:
                        if (baseEdit == null) baseEdit = new PopupContainerEdit();
                        PopupContainerEdit popupContainerEdit = (PopupContainerEdit)baseEdit;// new ButtonEdit();                         
                        //PopupContainerEdit popupContainerEdit = new PopupContainerEdit();
                        popupContainerEdit.Properties.AccessibleName = sys_Bind.Bind_Id;
                        popupContainerEdit.Properties.AccessibleDescription = sys_Bind.Bind_WorkSet.ToStringEx();
                        popupContainerEdit.Properties.Buttons[0].Visible = false; //.Clear();
                        popupContainerEdit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis));
                        PopupContainerControl gridPopupContainer = new PopupContainerControl();
                        gridPopupContainer.AutoSize = true;
                        gridPopupContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
                        gridPopupContainer.Width = 80;
                        GridControl gridPopup = new GridControl();
                        popupContainerEdit.Properties.PopupControl = gridPopupContainer;
                        popupContainerEdit.Properties.TextEditStyle = TextEditStyles.Standard;
                        gridPopup.Dock = DockStyle.Fill;
                        gridPopup.MainView = gridPopup.CreateView("GridView");
                        GridView gv = (GridView)gridPopup.MainView;
                        gv.OptionsBehavior.AutoPopulateColumns = false;
                        gv.OptionsView.ColumnAutoWidth = false;
                        gridPopup.MainView.BorderStyle = BorderStyles.NoBorder;
                        gridPopupContainer.Controls.Add(gridPopup);
                        popupContainerEdit.KeyDown += SearchPopupGridBegin;
                        popupContainerEdit.KeyUp += SearchPopupGridEnd;
                        popupContainerEdit.EditValueChanged += SearchPopupGridQuery;
                        popupContainerEdit.BeforePopup += new EventHandler(BindPopupGrid);
                        //弹窗  和  GridSelect 共用
                        popupContainerEdit.ButtonClick += new ButtonPressedEventHandler(BindGridSelect);
                        return popupContainerEdit;
                    case Sys_WorkSet_Editor.ExpressionEditor:
                        ButtonEdit repositoryItemExpressionEditorControl = new ButtonEdit();
                        repositoryItemExpressionEditorControl.ButtonClick += BindExpressionEditor;
                        return repositoryItemExpressionEditorControl;
                    case Sys_WorkSet_Editor.PopupPage:
                        ButtonEdit repositoryItemPopupPage = new ButtonEdit();
                        repositoryItemPopupPage.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemPopupPage.AccessibleDescription = sys_Bind.Bind_WorkSet.ToStringEx();
                        repositoryItemPopupPage.ButtonClick += new ButtonPressedEventHandler(BindPopupPage);
                        return repositoryItemPopupPage;
                    case Sys_WorkSet_Editor.FolderPicker:
                        if (baseEdit == null) baseEdit = new ButtonEdit();
                        ButtonEdit repositoryItemFolderPicker = (ButtonEdit)baseEdit;// new ButtonEdit();
                        repositoryItemFolderPicker.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemFolderPicker.ButtonClick += BindFolderPicker; ;
                        return repositoryItemFolderPicker;
                    case Sys_WorkSet_Editor.PasswordEdit:
                        if (baseEdit == null) baseEdit = new TextEdit();
                        TextEdit repositoryItemPasswordEdit = (TextEdit)baseEdit;// new TextEdit();
                        repositoryItemPasswordEdit.AccessibleName = sys_Bind.Bind_Id;
                        repositoryItemPasswordEdit.Properties.UseSystemPasswordChar = true;
                        repositoryItemPasswordEdit.Enter += RepositoryItemPasswordEdit_Enter;
                        return repositoryItemPasswordEdit;
                    case Sys_WorkSet_Editor.ScriptEdit:
                        ButtonEdit repositoryItemScriptEdit = new ButtonEdit();
                        repositoryItemScriptEdit.ButtonClick += BindScriptEdit; ;
                        return repositoryItemScriptEdit;
                    case Sys_WorkSet_Editor.MemoEdit:
                        MemoEdit repositoryItemMemoEdit = new MemoEdit();
                        repositoryItemMemoEdit.DoubleClick += new EventHandler((sender, e) =>
                        {
                            if (string.IsNullOrEmpty(sys_Popup.Popup_WorkSet)) return;
                            MemoEdit memoEdit = (MemoEdit)sender;
                            PhrasePage phrasePage = new PhrasePage(memoEdit.Text);
                            List<MyParameter> PhrasePageParameters = InitializePopupPara(sys_Popup);
                            DataTable repositoryItemPhrasePageDataSource = BaseService.Open(sys_Popup.Popup_WorkSet, PhrasePageParameters);
                            phrasePage.DisplayMember = sys_Popup.Popup_DisplayMember;
                            phrasePage.ValueMember = sys_Popup.Popup_ValueMember;
                            phrasePage.DataSource = repositoryItemPhrasePageDataSource;
                            if (phrasePage.ShowDialog() == DialogResult.OK)
                                memoEdit.Text = phrasePage.ReturnText;
                        });
                        return repositoryItemMemoEdit;
                    //case Sys_WorkSet_Editor.ReportEdit:
                    //    if (baseEdit == null) baseEdit = new ButtonEdit();
                    //    ButtonEdit repositoryItemReportEdit = (ButtonEdit)baseEdit;// new ButtonEdit();
                    //    repositoryItemReportEdit.ButtonClick += BindReportEdit;
                    //    repositoryItemReportEdit.AccessibleName = PopupBind_Id_Str;
                    //    return repositoryItemReportEdit;
                    //case Sys_WorkSet_Editor.SnapEdit:
                    //    if (baseEdit == null) baseEdit = new ButtonEdit();
                    //    ButtonEdit repositoryItemSnapEdit = (ButtonEdit)baseEdit;// new ButtonEdit();
                    //    repositoryItemSnapEdit.ButtonClick += BindSnapEdit;
                    //    repositoryItemSnapEdit.AccessibleName = PopupBind_Id_Str;
                    //    return repositoryItemSnapEdit;
                    //case Sys_WorkSet_Editor.RichEdit:
                    //    if (baseEdit == null) baseEdit = new ButtonEdit();
                    //    ButtonEdit repositoryItemRichEdit = (ButtonEdit)baseEdit;// new ButtonEdit();
                    //    repositoryItemRichEdit.ButtonClick += BindRichEdit;
                    //    repositoryItemRichEdit.AccessibleName = PopupBind_Id_Str;
                    //    return repositoryItemRichEdit;
                    //case Sys_WorkSet_Editor.DiagramEdit:
                    //    if (baseEdit == null) baseEdit = new ButtonEdit();
                    //    ButtonEdit repositoryItemDiagramEdit = (ButtonEdit)baseEdit;// new ButtonEdit();
                    //    repositoryItemDiagramEdit.ButtonClick += BindDiagramEdit;
                    //    repositoryItemDiagramEdit.AccessibleName = PopupBind_Id_Str;
                    //    return repositoryItemDiagramEdit;
                    //case Sys_WorkSet_Editor.ChartEdit:
                    //    if (baseEdit == null) baseEdit = new ButtonEdit();
                    //    ButtonEdit repositoryItemChartEdit = (ButtonEdit)baseEdit;// new ButtonEdit();
                    //    repositoryItemChartEdit.ButtonClick += BindChartEdit; ;
                    //    repositoryItemChartEdit.AccessibleName = PopupBind_Id_Str;
                    //    return repositoryItemChartEdit;
                    default:
                        if (baseEdit == null) baseEdit = new TextEdit();
                        TextEdit repositoryItemDefaultEdit = (TextEdit)baseEdit;// new TextEdit();
                        repositoryItemDefaultEdit.AccessibleName = sys_Bind.Bind_Id;
                        return repositoryItemDefaultEdit;
                }

            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
            }
            return null;

        }
        private void RepositoryItemTreeListLookUpEdit_ParseEditValue(object sender, EventArgs e)
        {


            try
            {
                TreeListLookUpEdit lue = (TreeListLookUpEdit)sender;
                DataRowView dr = (DataRowView)lue.GetSelectedDataRow();
                if (dr == null) return;
                DataTable dt = dr.Row.Table.Clone();
                dt.Rows.Add(dr.Row.ItemArray);
                Sys_Popup sys_Popup = PopupList[lue.AccessibleName];
                List<MyParameter> para_Sys_Bind = InitializePopupPara(sys_Popup);
                DataTable GridData = BaseService.Open(sys_Popup.Popup_WorkSet, para_Sys_Bind);
                para_Sys_Bind.Clear();
                para_Sys_Bind.Add("@Bind_Id", DbType.String, sys_Popup.Popup_Target, null);
                DataTable PopupBind = BaseService.Open("SystemPopupBind_Popup", para_Sys_Bind);
                if (PopupBind == null || PopupBind.Rows.Count == 0) return;
                List<Sys_PopupBind> sys_PopupBinds = EntityHelper.GetEntities<Sys_PopupBind>(PopupBind);
                ParseValue(sys_Popup.Popup_Target, dt, sys_PopupBinds);
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
            }
        }
        private void RepositoryItemLookUpEdit_ParseEditValue(object sender, EventArgs e)
        {


            try
            {
                LookUpEdit lue = (LookUpEdit)sender;
                DataRowView dr = (DataRowView)lue.GetSelectedDataRow();
                if (dr == null) return;
                DataTable dt = dr.Row.Table.Clone();
                dt.Rows.Add(dr.Row.ItemArray);
                Sys_Popup sys_Popup = PopupList[lue.AccessibleName];
                List<MyParameter> para_Sys_Bind = InitializePopupPara(sys_Popup);
                DataTable GridData = BaseService.Open(sys_Popup.Popup_WorkSet, para_Sys_Bind);
                para_Sys_Bind.Clear();
                para_Sys_Bind.Add("@Bind_Id", DbType.String, sys_Popup.Popup_Target, null);
                DataTable PopupBind = BaseService.Open("SystemPopupBind_Popup", para_Sys_Bind);
                if (PopupBind == null || PopupBind.Rows.Count == 0) return;
                List<Sys_PopupBind> sys_PopupBinds = EntityHelper.GetEntities<Sys_PopupBind>(PopupBind);
                ParseValue(sys_Popup.Popup_Target, dt, sys_PopupBinds);
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
            }
        }
        private void BindColorEditClear(object sender, KeyEventArgs e)
        {


            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    ColorEdit colorEdit = (ColorEdit)sender;
                    colorEdit.EditValue = DBNull.Value;
                    colorEdit.Update();
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
            }
        }

        //private void BindChartEdit(object sender, ButtonPressedEventArgs e)
        //{
        //    try
        //    {
        //        ButtonEdit buttonEdit = (ButtonEdit)sender;
        //        Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
        //        object obj = buttonEdit.Parent;
        //        if (obj != null && obj.GetType().Equals(typeof(GridControl)))
        //        {
        //            GridControl grid = (GridControl)obj;
        //            GridView abv = (GridView)grid.MainView;
        //            object val = abv.GetFocusedRowCellValue(sys_Popup.Popup_Field);
        //            if (val == null) val = string.Empty;
        //            if (val.GetType() == typeof(string))
        //            {
        //                ChartControlDesigner chartDesigner = new ChartControlDesigner((string)val);
        //                abv.SetFocusedRowCellValue(sys_Popup.Popup_Field, chartDesigner.Content);
        //            }
        //            if (val.GetType() == typeof(byte[]))
        //            {
        //                ChartControlDesigner chartDesigner = new ChartControlDesigner((byte[])val);
        //                abv.SetFocusedRowCellValue(sys_Popup.Popup_Field, chartDesigner.Content);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SharedFunc.RaiseError(ex);
        //    }
        //}
        //private void BindDiagramEdit(object sender, ButtonPressedEventArgs e)
        //{
        //    try
        //    {
        //        ButtonEdit buttonEdit = (ButtonEdit)sender;
        //        Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
        //        object obj = buttonEdit.Parent;
        //        if (obj != null && obj.GetType().Equals(typeof(GridControl)))
        //        {
        //            GridControl grid = (GridControl)obj;
        //            GridView abv = (GridView)grid.MainView;
        //            object val = abv.GetFocusedRowCellValue(sys_Popup.Popup_Field);
        //            if (val == null) val = string.Empty;
        //            DiagramDesigner diagramDesigner = null;
        //            if (val.GetType() == typeof(string))
        //            {
        //                diagramDesigner = new DiagramDesigner((string)val);
        //                diagramDesigner.ShowDialog();
        //                abv.SetFocusedRowCellValue(sys_Popup.Popup_Field, diagramDesigner.Content);
        //            }
        //            if (val.GetType() == typeof(byte[]))
        //            {
        //                diagramDesigner = new DiagramDesigner((byte[])val);
        //                diagramDesigner.ShowDialog();
        //                abv.SetFocusedRowCellValue(sys_Popup.Popup_Field, diagramDesigner.ByteContent);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SharedFunc.RaiseError(ex);
        //    }
        //}
        //private void BindRichEdit(object sender, ButtonPressedEventArgs e)
        //{
        //    try
        //    {
        //        ButtonEdit buttonEdit = (ButtonEdit)sender;
        //        Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
        //        object obj = buttonEdit.Parent;
        //        if (obj != null && obj.GetType().Equals(typeof(GridControl)))
        //        {
        //            GridControl grid = (GridControl)obj;
        //            GridView abv = (GridView)grid.MainView;
        //            object val = abv.GetFocusedRowCellValue(sys_Popup.Popup_Field);
        //            if (val == DBNull.Value) val = null;
        //            RichDesigner RichDesigner = null;
        //            if (abv.Columns[sys_Popup.Popup_Field].ColumnType == typeof(string))
        //            {
        //                RichDesigner = new RichDesigner((string)val);
        //                RichDesigner.ShowDialog();
        //                abv.SetFocusedRowCellValue(sys_Popup.Popup_Field, RichDesigner.Content);
        //            }
        //            if (abv.Columns[sys_Popup.Popup_Field].ColumnType == typeof(byte[]))
        //            {
        //                RichDesigner = new RichDesigner((byte[])val);
        //                RichDesigner.ShowDialog();
        //                abv.SetFocusedRowCellValue(sys_Popup.Popup_Field, RichDesigner.ByteContent);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SharedFunc.RaiseError(ex);
        //    }
        //}
        //private void BindSnapEdit(object sender, ButtonPressedEventArgs e)
        //{
        //    try
        //    {
        //        ButtonEdit buttonEdit = (ButtonEdit)sender;
        //        Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
        //        object obj = buttonEdit.Parent;
        //        if (obj != null && obj.GetType().Equals(typeof(GridControl)))
        //        {
        //            GridControl grid = (GridControl)obj;
        //            GridView abv = (GridView)grid.MainView;
        //            object val = abv.GetFocusedRowCellValue(sys_Popup.Popup_Field);
        //            if (val == DBNull.Value) val = null;
        //            SnapDesigner SnapDesigner = null;
        //            if (abv.Columns[sys_Popup.Popup_Field].ColumnType == typeof(string))
        //            {
        //                SnapDesigner = new SnapDesigner((string)val);
        //                SnapDesigner.ShowDialog();
        //                abv.SetFocusedRowCellValue(sys_Popup.Popup_Field, SnapDesigner.Content);
        //            }
        //            if (abv.Columns[sys_Popup.Popup_Field].ColumnType == typeof(byte[]))
        //            {
        //                SnapDesigner = new SnapDesigner((byte[])val);
        //                SnapDesigner.ShowDialog();
        //                abv.SetFocusedRowCellValue(sys_Popup.Popup_Field, SnapDesigner.ByteContent);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SharedFunc.RaiseError(ex);
        //    }
        //}
        //private void BindReportEdit(object sender, ButtonPressedEventArgs e)
        //{
        //    try
        //    {
        //        ButtonEdit buttonEdit = (ButtonEdit)sender;
        //        Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
        //        object obj = buttonEdit.Parent;
        //        if (obj != null && obj.GetType().Equals(typeof(GridControl)))
        //        {
        //            GridControl grid = (GridControl)obj;
        //            GridView abv = (GridView)grid.MainView;
        //            object val = abv.GetFocusedRowCellValue(sys_Popup.Popup_Field);
        //            ReportDesigner ReportDesigner = null;
        //            if (val == DBNull.Value) val = null;
        //            //if (val == null) val = string.Empty;
        //            if (abv.Columns[sys_Popup.Popup_Field].ColumnType == typeof(string))
        //            {
        //                ReportDesigner = new ReportDesigner((string)val);
        //                ReportDesigner.ShowDialog();
        //                abv.SetFocusedRowCellValue(sys_Popup.Popup_Field, ReportDesigner.Content);
        //            }
        //            if (abv.Columns[sys_Popup.Popup_Field].ColumnType == typeof(byte[]))
        //            {
        //                ReportDesigner = new ReportDesigner((byte[])val);
        //                ReportDesigner.ShowDialog();
        //                abv.SetFocusedRowCellValue(sys_Popup.Popup_Field, ReportDesigner.ByteContent);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SharedFunc.RaiseError(ex);
        //    }
        //}
        private void RepositoryItemPasswordEdit_Enter(object sender, EventArgs e)
        {


            try
            {
                TextEdit txtEdit = (TextEdit)sender;
                txtEdit.TextChanged += PasswordEdit_TextChanged;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void PasswordEdit_TextChanged(object sender, EventArgs e)
        {


            try
            {
                TextEdit txtEdit = (TextEdit)sender;
                txtEdit.EditValue = EncryptHelper.MD5Encrypt(txtEdit.Text);
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void BindFolderPicker(object sender, ButtonPressedEventArgs e)
        {


            try
            {
                ButtonEdit buttonEdit = (ButtonEdit)sender;
                Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
                {
                    buttonEdit.EditValue = folderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void BindFileDownload(object sender, OpenLinkEventArgs e)
        {


            try
            {
                ButtonEdit buttonEdit = (ButtonEdit)sender;
                Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                object obj = buttonEdit.Parent;
                if (obj != null && obj.GetType().Equals(typeof(GridControl)))
                {
                    GridControl grid = (GridControl)obj;
                    GridView abv = (GridView)grid.MainView;
                    List<MyParameter> para_Sys_Bind = new List<MyParameter>();
                    para_Sys_Bind.Add("@Bind_Id", DbType.String, buttonEdit.AccessibleName, null);
                    DataTable PopupBind = BaseService.Open("SystemPopupBind_Popup", para_Sys_Bind);
                    if (PopupBind == null || PopupBind.Rows.Count == 0) return;
                    List<Sys_PopupBind> sys_PopupBinds = EntityHelper.GetEntities<Sys_PopupBind>(PopupBind);
                    byte[] bytes = null;
                    Sys_PopupBind byteBind = sys_PopupBinds.Find(s => s.PopupBind_Field.Equals("FileInput_Bytes"));
                    if (byteBind != null)
                    {
                        object abj = abv.GetFocusedRowCellValue(byteBind.PopupBind_Bind);
                        if (abj != DBNull.Value)
                        {
                            bytes = (byte[])abj;
                        }
                    }
                    Sys_PopupBind fidBind = sys_PopupBinds.Find(s => s.PopupBind_Field.Equals("FileInput_Id"));
                    if (fidBind != null && bytes == null)
                    {
                        string fid = abv.GetFocusedRowCellValue(sys_PopupBinds.Find(s => s.PopupBind_Field.Equals("FileInput_Id")).PopupBind_Bind).ToStringEx();
                        if (!string.IsNullOrEmpty(fid))
                        {
                            bytes = BaseService.GetFile(fid);
                        }
                    }
                    if (bytes != null)
                    {
                        string fName = string.Empty;
                        Sys_PopupBind nameBind = sys_PopupBinds.Find(s => s.PopupBind_Field.Equals("FileInput_Name"));
                        if (nameBind != null)
                            fName = nameBind.PopupBind_Bind;
                        saveFileDialog.FileName = abv.GetFocusedRowCellValue(fName).ToStringEx();
                        saveFileDialog.DefaultExt = Path.GetExtension(saveFileDialog.FileName);
                        saveFileDialog.AddExtension = true;
                        if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, bytes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private Dictionary<string, string> FileDictionary = new Dictionary<string, string>();
        private void BindFileSelect(object sender, ButtonPressedEventArgs e)
        {


            try
            {
                ButtonEdit buttonEdit = (ButtonEdit)sender;
                Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
                if (e.Button.Kind == ButtonPredefines.Ellipsis)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        object obj = buttonEdit.Parent;
                        if (obj != null && obj.GetType().Equals(typeof(GridControl)))
                        {
                            GridControl grid = (GridControl)obj;
                            GridView abv = (GridView)grid.MainView;
                            //PopupBind
                            List<MyParameter> para_Sys_Bind = new List<MyParameter>();
                            para_Sys_Bind.Add("@Bind_Id", DbType.String, buttonEdit.AccessibleName, null);
                            DataTable PopupBind = BaseService.Open("SystemPopupBind_Popup", para_Sys_Bind);
                            if (PopupBind == null || PopupBind.Rows.Count == 0) return;
                            List<Sys_PopupBind> sys_PopupBinds = EntityHelper.GetEntities<Sys_PopupBind>(PopupBind);
                            List<Sys_FileInput> sfs = new List<Sys_FileInput>();
                            foreach (string file in openFileDialog.FileNames)
                            {
                                Sys_FileInput sys_FileInput = new Sys_FileInput();
                                string fid = Guid.NewGuid().ToString();
                                sys_FileInput.FileInput_Id = fid;
                                Sys_PopupBind sys_PopupBind = sys_PopupBinds.Find(p => p.PopupBind_Name == "FileInput_Bytes" && !string.IsNullOrEmpty(p.PopupBind_Bind));
                                if (sys_PopupBind == null)
                                {
                                    FileDictionary.Add(fid, file);
                                }
                                sys_FileInput.FileInput_Name = Path.GetFileName(file);
                                sys_FileInput.FileInput_Bytes = File.ReadAllBytes(file);
                                sys_FileInput.FileInput_Path = file;
                                sys_FileInput.FileInput_Relative = sys_FileInput.FileInput_Path.Replace(Application.StartupPath + "\\", "");
                                sys_FileInput.FileInput_Extension = Path.GetExtension(file);
                                if (FileHelper.IsTxt(file))
                                    sys_FileInput.FileInput_Content = File.ReadAllText(file);
                                sfs.Add(sys_FileInput);
                            }
                            DataTable dt = EntityHelper.GetDataTable(sfs);
                            ParseValue(sys_Popup.Popup_Target, dt, sys_PopupBinds);
                        }
                    }
                }
                if (e.Button.Kind == ButtonPredefines.Clear)
                {
                    List<MyParameter> para_Sys_Bind = new List<MyParameter>();
                    para_Sys_Bind.Add("@Bind_Id", DbType.String, buttonEdit.AccessibleName, null);
                    DataTable PopupBind = BaseService.Open("SystemPopupBind_Popup", para_Sys_Bind);
                    if (PopupBind == null || PopupBind.Rows.Count == 0) return;
                    List<Sys_PopupBind> sys_PopupBinds = EntityHelper.GetEntities<Sys_PopupBind>(PopupBind);
                    DataTable dt = new DataTable();
                    Sys_FileInput sys_FileInput = new Sys_FileInput();
                    dt = EntityHelper.GetDataTable(sys_FileInput);
                    dt.Rows.Clear();
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    ParseValue(sys_Popup.Popup_Target, new Sys_FileInput(), sys_PopupBinds);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        SkinPicker skinPicker;
        private void BindSkinPicker(object sender, ButtonPressedEventArgs e)
        {


            try
            {
                ButtonEdit buttonEdit = (ButtonEdit)sender;
                if (skinPicker == null)
                {
                    skinPicker = new SkinPicker();
                }
                skinPicker.ShowDialog();
                if (skinPicker.ReturnItem != null)
                {
                    //UserLookAndFeel.Default.SetSkinStyle(skinPicker.ReturnItem.Tag.ToStringEx());
                    buttonEdit.EditValue = skinPicker.ReturnItem.Tag.ToStringEx();
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private ImagePicker imagePicker;
        private void BindImagePicker(object sender, ButtonPressedEventArgs e)
        {


            try
            {
                if (imagePicker == null)
                {
                    imagePicker = new ImagePicker();
                }
                imagePicker.ShowDialog();
                ButtonEdit buttonEdit = (ButtonEdit)sender;
                if (imagePicker.ReturnItem != null)
                {
                    buttonEdit.EditValue = imagePicker.ReturnItem.Caption;
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void BindCheckedComboBoxEdit(object sender, MouseEventArgs e)
        {


            CheckedComboBoxEdit checkedComboBoxEdit = (CheckedComboBoxEdit)sender;
            Sys_Popup sys_Popup = PopupList[checkedComboBoxEdit.AccessibleName];
            try
            {
                object obj = checkedComboBoxEdit.Parent;
                if (obj != null && obj.GetType().Equals(typeof(GridControl)))
                {
                    GridControl grid = (GridControl)obj;
                    GridView abv = (GridView)grid.MainView;
                    if (!string.IsNullOrEmpty(sys_Popup.Popup_Field) && abv.Columns[sys_Popup.Popup_Field] != null)
                    {
                        DataTable adt = (DataTable)grid.DataSource;
                        if (adt != null)
                        {
                            checkedComboBoxEdit.Properties.Items.Clear();
                            foreach (DataRow dr in adt.Rows)
                            {
                                if (!string.IsNullOrEmpty(dr[sys_Popup.Popup_Field].ToStringEx()))
                                {
                                    checkedComboBoxEdit.Properties.Items.Add(dr[sys_Popup.Popup_Field]);
                                }
                            }
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            try
            {
                List<MyParameter> QueryParameters = InitializePopupPara(sys_Popup);
                DataTable dt = BaseService.Open(sys_Popup.Popup_WorkSet.ToStringEx(), QueryParameters);
                if (dt != null)
                {
                    checkedComboBoxEdit.Properties.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(dr[0].ToStringEx()))
                        {
                            checkedComboBoxEdit.Properties.Items.Add(dr[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void BindComboBox(object sender, MouseEventArgs e)
        {


            ComboBoxEdit comboBoxEdit = (ComboBoxEdit)sender;
            Sys_Popup sys_Popup = PopupList[comboBoxEdit.AccessibleName];
            try
            {
                object obj = comboBoxEdit.Parent;
                if (string.IsNullOrEmpty(sys_Popup.Popup_WorkSet) && obj.GetType().Equals(typeof(GridControl)))
                {
                    string field = sys_Popup.Popup_Field;
                    GridControl grid = (GridControl)obj;
                    GridView abv = (GridView)grid.MainView;
                    if (string.IsNullOrEmpty(field))
                    {
                        field = abv.FocusedColumn.FieldName;
                    }
                    if (field.Contains("."))
                    {
                        Control[] cs = this.Controls.Find(field.Substring(0, field.IndexOf(".")), true);
                        if (cs.Length > 0 && cs[0].GetType() == typeof(GridControl))
                        {
                            grid = (GridControl)cs[0];
                            abv = (GridView)grid.MainView;
                            field = field.Substring(field.IndexOf(".") + 1);
                        }
                    }
                    if (!string.IsNullOrEmpty(field) && abv.Columns[field] != null)
                    {
                        DataTable adt = (DataTable)grid.DataSource;
                        if (adt != null)
                        {
                            comboBoxEdit.Properties.Items.Clear();
                            foreach (DataRow dr in adt.DistinctTable(field).Rows)
                            {
                                string value = dr[field].ToStringEx();
                                if (!string.IsNullOrEmpty(value))
                                {
                                    if (!comboBoxEdit.Properties.Items.Contains(value))
                                        comboBoxEdit.Properties.Items.Add(value);
                                }
                            }
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            try
            {
                List<MyParameter> QueryParameters = InitializePopupPara(sys_Popup);
                DataTable dt = BaseService.Open(sys_Popup.Popup_WorkSet.ToStringEx(), QueryParameters);
                if (dt != null)
                {
                    comboBoxEdit.Properties.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        //string s = dr[sys_Popup.Popup_Field].ToStringEx();
                        if (dt.Columns.Contains(sys_Popup.Popup_Field) && !string.IsNullOrEmpty(dr[sys_Popup.Popup_Field].ToStringEx()))
                        {
                            if (!comboBoxEdit.Properties.Items.Contains(dr[sys_Popup.Popup_Field]))
                                comboBoxEdit.Properties.Items.Add(dr[sys_Popup.Popup_Field]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void BindTreeListLookUpEdit(TreeListLookUpEdit treeListLookUpEdit, Sys_Popup sys_Popup)
        {


            try
            {
                List<MyParameter> QueryParameters = InitializePopupPara(sys_Popup);
                DataTable dt = BaseService.Open(treeListLookUpEdit.AccessibleName, QueryParameters);
                treeListLookUpEdit.Properties.ValueMember = dt.Columns[0].ColumnName;
                treeListLookUpEdit.Properties.DisplayMember = dt.Columns[1].ColumnName;
                treeListLookUpEdit.Properties.DataSource = dt;
                treeListLookUpEdit.Properties.TreeList.ParentFieldName = "";
                treeListLookUpEdit.Properties.TreeList.KeyFieldName = "";
                //treeListLookUpEdit.Properties.SearchMode = SearchMode.AutoComplete;
                treeListLookUpEdit.Properties.TreeList.PopulateColumns();
                treeListLookUpEdit.Properties.TreeList.Columns[0].Visible = false;
                treeListLookUpEdit.Properties.TreeList.OptionsView.ShowColumns = false;
                treeListLookUpEdit.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                treeListLookUpEdit.Properties.TreeList.OptionsView.ShowIndicator = false;
                treeListLookUpEdit.Properties.TreeList.OptionsView.ShowHorzLines = false;
                treeListLookUpEdit.Properties.TreeList.OptionsView.ShowVertLines = false;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void BindLookUpEdit(LookUpEdit lookUpEdit, Sys_Popup sys_Popup)
        {


            try
            {
                List<MyParameter> QueryParameters = InitializePopupPara(sys_Popup);
                DataTable dt = BaseService.Open(lookUpEdit.AccessibleName, QueryParameters);
                lookUpEdit.Properties.ValueMember = dt.Columns[0].ColumnName;
                lookUpEdit.Properties.DisplayMember = dt.Columns[1].ColumnName;
                lookUpEdit.Properties.DataSource = dt;
                lookUpEdit.Properties.PopulateColumns();
                lookUpEdit.Properties.SearchMode = SearchMode.AutoComplete;
                lookUpEdit.Properties.Columns[0].Visible = false;
                lookUpEdit.Properties.ShowHeader = false;
                lookUpEdit.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                lookUpEdit.Properties.BestFit();
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void BindTreeSelect(object sender, ButtonPressedEventArgs e)
        {


            ButtonEdit buttonEdit = (ButtonEdit)sender;
            Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
            List<MyParameter> para_Sys_Bind = InitializePopupPara(sys_Popup);
            DataTable GridData = BaseService.Open(sys_Popup.Popup_WorkSet, para_Sys_Bind);
            para_Sys_Bind.Clear();
            para_Sys_Bind.Add("@Bind_Id", DbType.String, sys_Popup.Popup_Target, null);
            DataTable PopupBind = BaseService.Open("SystemPopupBind_Popup", para_Sys_Bind);
            if (PopupBind == null || PopupBind.Rows.Count == 0) return;
            List<Sys_PopupBind> sys_PopupBinds = EntityHelper.GetEntities<Sys_PopupBind>(PopupBind);
            TreePicker treePicker = new TreePicker();
            treePicker.PopupBindList = sys_PopupBinds;
            treePicker.ParentFieldName = sys_Popup.Popup_ParentField;
            treePicker.KeyFieldName = sys_Popup.Popup_KeyField;
            treePicker.MultiSelect = false;
            treePicker.DataSource = GridData;
            treePicker.Text = sys_Popup.Popup_Nick;
            if (treePicker.ShowDialog() == DialogResult.OK)
            {
                DataTable drs = treePicker.ReturnItem;
                ParseValue(sys_Popup.Popup_Target, drs, sys_PopupBinds);
            }

        }
        private void BindPopupPage(object sender, ButtonPressedEventArgs e)
        {


            try
            {
                ButtonEdit buttonEdit = (ButtonEdit)sender;
                Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
                List<MyParameter> myParameters = new List<MyParameter>();
                myParameters.Add("@WorkSet_Id", DbType.String, sys_Popup.Popup_WorkSet, null);
                DataTable dt = BaseService.Open("SystemPopup_PopupPage", myParameters);
                Sys_Page sys_Page = EntityHelper.GetEntity<Sys_Page>(dt);
                ChildPage myPage = (ChildPage)ReflectionHelper.LoadForm(sys_Page.Menu_Path, sys_Page.Menu_Class);
                //myPage.WindowState = FormWindowState.Maximized;
                myPage.StartPosition = FormStartPosition.CenterParent;
                myPage.Name = sys_Page.Menu_Name;
                myPage.Text = sys_Page.Menu_Nick;
                myPage.SysPage = sys_Page;
                myPage.ShowDialog();
                object fc = myPage.ActiveControl;
                if (fc.GetType() == typeof(GridControl))
                {
                    GridControl gd = (GridControl)fc;
                    GridView gv = (GridView)gd.MainView;
                    DataTable SourceTable = (DataTable)gd.DataSource;
                    DataTable ResultTable = SourceTable.Clone();
                    if (gv.FocusedRowHandle >= 0)
                    {
                        foreach (int i in gv.GetSelectedRows())
                        {
                            ResultTable.Rows.Add(gv.GetDataRow(i).ItemArray);
                        }
                    }
                    else
                    {
                        ResultTable.Rows.Add(ResultTable.NewRow());
                    }
                    List<MyParameter> para_Sys_Bind = new List<MyParameter>();
                    para_Sys_Bind.Add("@Bind_Id", DbType.String, sys_Popup.Popup_Target, null);
                    DataTable PopupBind = BaseService.Open("SystemPopupBind_Popup", para_Sys_Bind);
                    if (PopupBind == null || PopupBind.Rows.Count == 0) return;
                    List<Sys_PopupBind> sys_PopupBinds = EntityHelper.GetEntities<Sys_PopupBind>(PopupBind);
                    ParseValue(sys_Popup.Popup_Target, ResultTable, sys_PopupBinds);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }


        }

        private void BindGridSelect(object sender, ButtonPressedEventArgs e)
        {


            try
            {
                if (e.Button.Kind == ButtonPredefines.Ellipsis)
                {
                    ButtonEdit buttonEdit = (ButtonEdit)sender;
                    Sys_Popup sys_Popup = PopupList[buttonEdit.AccessibleName];
                    List<MyParameter> para_Sys_Bind = InitializePopupPara(sys_Popup);
                    DataTable GridData = BaseService.Open(sys_Popup.Popup_WorkSet, para_Sys_Bind);
                    para_Sys_Bind.Clear();
                    para_Sys_Bind.Add("@Bind_Id", DbType.String, sys_Popup.Popup_Target, null);
                    DataTable PopupBind = BaseService.Open("SystemPopupBind_Popup", para_Sys_Bind);
                    if (PopupBind == null || PopupBind.Rows.Count == 0) return;
                    List<Sys_PopupBind> sys_PopupBinds = EntityHelper.GetEntities<Sys_PopupBind>(PopupBind);
                    GridPicker grid = new GridPicker();
                    grid.Text = sys_Popup.Popup_Nick;
                    grid.PopupBindList = sys_PopupBinds;
                    grid.BestFitMaxRowCount = 50;
                    object obj = buttonEdit.Parent;
                    if (obj != null && obj.GetType().Equals(typeof(GridControl)))
                    {
                        grid.MultiSelect = true;
                    }
                    else
                    {
                        grid.MultiSelect = false;
                    }
                    grid.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                    grid.DataSource = GridData;
                    if (grid.ShowDialog() == DialogResult.OK)
                    {
                        DataTable drs = grid.ReturnTable;
                        ParseValue(sys_Popup.Popup_Target, drs, sys_PopupBinds);
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }


        }
        private void BindCheckEdit(object sender, EventArgs e)
        {


            try
            {
                GridView abv = (GridView)sender;
                foreach (GridColumn GridColumn in abv.Columns)
                {
                    RepositoryItemCheckEdit repositoryItem;
                    if (GridColumn.ColumnEdit != null && GridColumn.ColumnEdit.GetType().Equals(typeof(RepositoryItemCheckEdit)))
                    {
                        repositoryItem = (RepositoryItemCheckEdit)GridColumn.ColumnEdit;
                        if (GridColumn.ColumnType.Equals(typeof(bool)))
                        {
                            repositoryItem.ValueChecked = Convert.ToBoolean(1);
                            repositoryItem.ValueUnchecked = Convert.ToBoolean(0);
                            repositoryItem.ValueGrayed = null;
                        }
                        if (GridColumn.ColumnType.Equals(typeof(Int16)))
                        {
                            repositoryItem.ValueChecked = Convert.ToInt16(1);
                            repositoryItem.ValueUnchecked = Convert.ToInt16(0);
                            repositoryItem.ValueGrayed = null;
                        }
                        if (GridColumn.ColumnType.Equals(typeof(int)))
                        {
                            repositoryItem.ValueChecked = Convert.ToInt32(1);
                            repositoryItem.ValueUnchecked = Convert.ToInt32(0);
                            repositoryItem.ValueGrayed = null;
                        }
                        if (GridColumn.ColumnType.Equals(typeof(Int64)))
                        {
                            repositoryItem.ValueChecked = Convert.ToInt64(1);
                            repositoryItem.ValueUnchecked = Convert.ToInt64(0);
                            repositoryItem.ValueGrayed = null;
                        }
                        if (GridColumn.ColumnType.Equals(typeof(byte)))
                        {
                            repositoryItem.ValueChecked = Convert.ToByte(1);
                            repositoryItem.ValueUnchecked = Convert.ToByte(0);
                            repositoryItem.ValueGrayed = null;
                        }
                        if (GridColumn.ColumnType.Equals(typeof(string)))
                        {
                            repositoryItem.ValueChecked = Convert.ToString(true);
                            repositoryItem.ValueUnchecked = Convert.ToString(false);
                            repositoryItem.ValueGrayed = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void ParseValue(string Bind_Id, DataTable drs, List<Sys_PopupBind> sys_PopupBinds)
        {


            try
            {
                //this.Cursor = Cursors.WaitCursor;
                Sys_Bind bind = BindList.Find(b => b.Bind_Id == Bind_Id);
                if (bind == null) bind = new Sys_Bind();
                Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Id.Equals(bind.Bind_WorkSet));
                object obj = sys_WorkSet.WorkSet_Control;
                if (drs != null && drs.Rows.Count > 0)
                {
                    if (obj != null && obj.GetType().Equals(typeof(GridControl)))
                    {
                        GridControl gridControl = (GridControl)obj;
                        GridView abv = (GridView)gridControl.MainView;
                        abv.BeginUpdate();
                        NewItemRowPosition nirp = abv.OptionsView.NewItemRowPosition;
                        abv.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                        foreach (DataRow dr in drs.Rows)
                        {
                            foreach (Sys_PopupBind sys_PopupBind in sys_PopupBinds)
                            {
                                if (drs.Columns[sys_PopupBind.PopupBind_Field] == null) continue;
                                if (abv.Columns[sys_PopupBind.PopupBind_Bind] != null)
                                {
                                    if (abv.IsNewItemRow(abv.FocusedRowHandle))
                                    {
                                        abv.UpdateCurrentRow();
                                        abv.AddNewRow();
                                        abv.CloseEditor();
                                        abv.UpdateCurrentRow();
                                    }
                                    abv.SetFocusedRowCellValue(sys_PopupBind.PopupBind_Bind, dr[sys_PopupBind.PopupBind_Field]);
                                    abv.CloseEditor();
                                    abv.UpdateCurrentRow();
                                    //推送绑定的字段
                                    Sys_Bind sys_Bind = BindList.Find(b => b.Bind_Name == sys_PopupBind.PopupBind_Bind && b.Bind_WorkSet == sys_WorkSet.WorkSet_Id);
                                    if (!string.IsNullOrEmpty(sys_Bind.Bind_Push))
                                        SetValue(sys_Bind.Bind_Push, dr[sys_PopupBind.PopupBind_Field], string.IsNullOrEmpty(sys_Bind.Bind_Property) ? "EditValue" : sys_Bind.Bind_Property);
                                }
                                else if (!string.IsNullOrEmpty(sys_PopupBind.PopupBind_Bind))
                                {
                                    Sys_Bind sys_Bind = BindList.Find(b => b.Bind_Name == sys_PopupBind.PopupBind_Bind && b.Bind_WorkSet == sys_WorkSet.WorkSet_Id);
                                    if (sys_Bind == null) continue;
                                    if (!string.IsNullOrEmpty(sys_Bind.Bind_Property))
                                        SetValue(sys_Bind.Bind_Field, dr[sys_PopupBind.PopupBind_Field], sys_Bind.Bind_Property);
                                    else
                                    {
                                        if (!SetValue(sys_Bind.Bind_Field, dr[sys_PopupBind.PopupBind_Field], "EditValue"))
                                        {
                                            SetValue(sys_Bind.Bind_Field, dr[sys_PopupBind.PopupBind_Field], "Text");
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(sys_Bind.Bind_Property))
                                        SetValue(sys_Bind.Bind_Push, dr[sys_PopupBind.PopupBind_Field], sys_Bind.Bind_Property);
                                    else
                                    {
                                        if (!SetValue(sys_Bind.Bind_Push, dr[sys_PopupBind.PopupBind_Field], "EditValue"))
                                        {
                                            SetValue(sys_Bind.Bind_Push, dr[sys_PopupBind.PopupBind_Field], "Text");
                                        }
                                    }
                                }
                            }
                            if (drs.Rows.Count > 1)
                                abv.MoveNext();// = 2;// abv.FocusedRowHandle + 1;
                        }
                        //if (drs.Rows.Count > 1)
                        //    abv.MoveFirst();// = 2;// abv.FocusedRowHandle + 1;
                        abv.EndUpdate();
                        abv.OptionsView.NewItemRowPosition = nirp;
                        abv.CloseEditor();
                        abv.UpdateCurrentRow();
                    }
                    else
                    {
                        foreach (Sys_PopupBind sys_PopupBind in sys_PopupBinds)
                        {
                            if (drs.Columns[sys_PopupBind.PopupBind_Field] == null) continue;
                            if (!string.IsNullOrEmpty(sys_PopupBind.PopupBind_Bind))
                            {
                                Sys_Bind sys_Bind = BindList.Find(b => b.Bind_Name == sys_PopupBind.PopupBind_Bind && b.Bind_WorkSet == sys_WorkSet.WorkSet_Id);
                                if (sys_Bind == null) continue;
                                DataRow dr = drs.Rows[0];
                                if (!string.IsNullOrEmpty(sys_Bind.Bind_Property))
                                    SetValue(sys_Bind.Bind_Field, dr[sys_PopupBind.PopupBind_Field], sys_Bind.Bind_Property);
                                else
                                {
                                    if (!SetValue(sys_Bind.Bind_Field, dr[sys_PopupBind.PopupBind_Field], "EditValue"))
                                    {
                                        SetValue(sys_Bind.Bind_Field, dr[sys_PopupBind.PopupBind_Field], "Text");
                                    }
                                }
                                if (!string.IsNullOrEmpty(sys_Bind.Bind_Property))
                                    SetValue(sys_Bind.Bind_Push, dr[sys_PopupBind.PopupBind_Field], sys_Bind.Bind_Property);
                                else
                                {
                                    if (!SetValue(sys_Bind.Bind_Push, dr[sys_PopupBind.PopupBind_Field], "EditValue"))
                                    {
                                        SetValue(sys_Bind.Bind_Push, dr[sys_PopupBind.PopupBind_Field], "Text");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
                //this.Cursor = Cursors.Default;
            }

        }

        private void ParseValue(string Bind_Id, object drs, List<Sys_PopupBind> sys_PopupBinds)
        {


            try
            {
                Sys_Bind bind = BindList.Find(b => b.Bind_Id == Bind_Id);
                if (bind == null) bind = new Sys_Bind();
                Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Id.Equals(bind.Bind_WorkSet));
                object obj = sys_WorkSet.WorkSet_Control;
                if (drs != null && obj != null && obj.GetType().Equals(typeof(GridControl)))
                {
                    GridControl gridControl = (GridControl)obj;
                    GridView abv = (GridView)gridControl.MainView;
                    foreach (Sys_PopupBind sys_PopupBind in sys_PopupBinds)
                    {
                        if (abv.Columns[sys_PopupBind.PopupBind_Bind] != null)
                        {
                            if (abv.IsNewItemRow(abv.FocusedRowHandle))
                            {
                                abv.AddNewRow();
                                abv.CloseEditor();
                                abv.UpdateCurrentRow();
                            }
                            object val = ReflectionHelper.GetProperty(drs, sys_PopupBind.PopupBind_Field);
                            abv.SetFocusedRowCellValue(sys_PopupBind.PopupBind_Bind, val);
                        }
                        else if (!string.IsNullOrEmpty(sys_PopupBind.PopupBind_Bind))
                        {
                            Sys_Bind sys_Bind = BindList.Find(b => b.Bind_Name == sys_PopupBind.PopupBind_Bind);
                            if (sys_Bind == null) return;
                            Control[] bindControls = this.Controls.Find(sys_Bind.Bind_Field, true);
                            if (bindControls.Length > 0)
                            {
                                Control bindControl = bindControls[0];
                                if (!ReflectionHelper.SetProperty(bindControl, string.IsNullOrEmpty(bind.Bind_Property) ? "EditValue" : bind.Bind_Property, ReflectionHelper.GetProperty(drs, sys_PopupBind.PopupBind_Field)))
                                {
                                    ReflectionHelper.SetProperty(bindControl, "Text", ReflectionHelper.GetProperty(drs, sys_PopupBind.PopupBind_Field));
                                }
                            }
                        }
                    }
                    abv.CloseEditor();
                    abv.UpdateCurrentRow();
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        #endregion
    }
}