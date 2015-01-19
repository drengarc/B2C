using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using DevExpress.XtraEditors;
using System.Reflection;
using DevExpress.XtraEditors.ViewInfo;
using Prodma.DataAccessB2C;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data;
 
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils.Text;
using System.Collections.Generic;
using DevExpress.XtraPrinting;


namespace Prodma.WinForms
{
    /// <summary>
    /// CRUD işlemlerinin yapıldıgı usercontrol.
    /// </summary>
    public partial class  usrGridIslem : XtraUserControl
    {
        #region Değişkenler
        public bool detayGosterme=false;
        public string gridIslemAdi = "";
        public int detayCalismaDegerId = 0;
        public DevExpress.XtraBars.PopupMenu popupMenu1;
        public DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public System.Windows.Forms.MenuItem[] contextMenuItems = new System.Windows.Forms.MenuItem[10];
        public System.Windows.Forms.ContextMenu ContextMenu1; 
        public bool escapeKapatma = false;
        public bool _bilgilendirme;
        public bool _guncelle;
        public bool _tekSecim;
        private System.Windows.Forms.BindingSource testInfoBindingSource1 = new System.Windows.Forms.BindingSource();
        public event EventHandler Bul;
        public event EventHandler Kaydet;
        public event EventHandler Sil;
        public event EventHandler Vazgec;
        public event EventHandler Yazdir;
        public event EventHandler Yeni_Kayit;
        public event EventHandler Doldur;
        public event EventHandler ShowingEditor;
        public event EventHandler ValidateRow;
        public event RowStyleEventHandler UsrRowStyle;
        public event EventHandler ValidatingEditor;
        public event EventHandler Eski_Kayit_Al_Yukle_Satir;
        public event EventHandler hucre_Islemleri;
        public event KeyEventHandler hucre_Islemleri_KeyEvents;
        public event EventHandler BagliGridDoldur;
        public event CustomSummaryEventHandler SummaryCalculate;
        public event NavigatorButtonClickEventHandler controlNavigatorButtonClick;
        public bool blnValidateRow = true;
        public bool acilisTamamlandi = false;
        public bool blnValidatingEditor = true;
        public string errorTextValidatingEditor = "";
        public bool blnGridView1ShowingEditor = false;
        public string rowHandleExcepTionMessage = "";
        public bool kayitTamam;
        bool sonsutunkaydet = false;
        bool yeniSatir = false;
        public string tabloAdi;
        #region Devexpress kontrolleri
        int intBind = 0;
        private DevExpress.XtraEditors.TextEdit[] textArama = new DevExpress.XtraEditors.TextEdit[64];
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn Column1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
        public DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[] repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[32];
        public BindingSource[] bindingSourceArr = new BindingSource[32];
        public BindingSource bindingSource1 = new BindingSource();
        #endregion
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;

        public Object ModelVm;
        public bool islemTamamDegil;
        GridIslemEn gridIslemTip;
        GridOzellikleriEn gridOzellikleri;
        #endregion
        public usrGridIslem(GridIslemEn tip)
        {
            InitializeComponent();
            gridIslemTip =  tip;
            GridolusturEkle();
            Grid_Ozellik_Duzenle();
            eventHandler();
            this.ContextMenu1 = new System.Windows.Forms.ContextMenu();
        }
        public void GridolusturEkle()
        {
            this.gridControl1 = new Prodma.DataAccessB2C.MyGridControl();
            this.gridView1 = new Prodma.DataAccessB2C.MyGridView();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.controlNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator1.Location = new System.Drawing.Point(0, 263);
            this.controlNavigator1.Name = "controlNavigator1";
            this.controlNavigator1.NavigatableControl = this.gridControl1;
            this.controlNavigator1.ShowToolTips = true;
            this.controlNavigator1.Size = new System.Drawing.Size(839, 38);
            this.controlNavigator1.TabIndex = 1;
            this.controlNavigator1.Text = "controlNavigator1";
            this.controlNavigator1.ToolTipController = this.toolTipGridview2;

            this.toolTipGridview2.Appearance.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.toolTipGridview2.Appearance.Options.UseFont = true;
            this.toolTipGridview2.AutoPopDelay = 50000;
            this.toolTipGridview2.InitialDelay = 1;
            this.toolTipGridview2.ReshowDelay = 3;

            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(839, 263);
            this.gridControl1.TabIndex = 18;
            this.gridControl1.ToolTipController = this.toolTipGridview2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";

            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.controlNavigator1);


        }
        public usrGridIslem(GridIslemEn tip, GridOzellikleriEn ozl)
        {
            InitializeComponent();
            gridIslemTip = tip;
            gridOzellikleri = ozl;
            GridolusturEkle();
            Grid_Ozellik_Duzenle();
            //if (gridOzellikleri== GridOzellikleriEn.Standart)
            //{
            //    gridView1.eskiYazim = false;                
            //}
            //else
            //{
            //    gridView1.eskiYazim = false;                
            //}
            eventHandler();
            this.ContextMenu1 = new System.Windows.Forms.ContextMenu();
        }
        private void Grid_Ozellik_Duzenle()
        {
            //this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink();
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            this.panelControl1.Visible = false;
            gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.GroupPanelText = "Gruplamak İstediğiniz Alanı Bu Bölgeye Sürükleyiniz";
            if (gridIslemTip == GridIslemEn.Bilgilendirme)
            {
                controlNavigator1.Buttons.Append.Visible = false;
                controlNavigator1.Buttons.CancelEdit.Visible = false;
                controlNavigator1.Buttons.Edit.Visible = false;
                controlNavigator1.Buttons.EndEdit.Visible = false;
                controlNavigator1.Buttons.Remove.Visible = false;
                gridView1.OptionsBehavior.Editable = true;
            }
            else if (gridIslemTip == GridIslemEn.Guncelle)
            {
                controlNavigator1.Buttons.Append.Visible = false;
                controlNavigator1.Buttons.CancelEdit.Visible = false;
                controlNavigator1.Buttons.EndEdit.Visible = false;
                gridView1.OptionsBehavior.Editable = true;
            }
            else if (gridIslemTip == GridIslemEn.Giris)
            {
                gridView1.OptionsBehavior.Editable = true;
            }
           gridView1.OptionsFind.AllowFindPanel = false;
        }
        public void PrintOzellikDuzenle()
        {
            //foreach (GridGroupSummaryItem item in gridView1.GroupSummary)
            //{
            //    //item.ShowInGroupColumnFooter = gridView1.Columns[item.FieldName.ToString()];
            //}
            //if (gridOzellikleri == GridOzellikleriEn.Yeni)
            //{
            //    gridView1.OptionsPrint.PrintDetails = false;
            //    gridView1.OptionsPrint.ExpandAllDetails = false;
            //    gridView1.OptionsPrint.ExpandAllGroups = false;
            //    gridView1.GroupFooterShowMode = GroupFooterShowMode.Hidden;
            //}
        }
        public string Gridi_Olustur()//GRİD ve ARAMALAR AYARLANIYOR
        {
            string alanadi = "";
            int intArama = 0;
            int ust_id = 0;
            var q = ListDenemeService.GetALANLAR(tabloAdi, 1);
            foreach (var ALAN in q)
            {
                Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                FieldInfo fi = typeof(GridColumn).GetField("minWidth", BindingFlags.NonPublic | BindingFlags.Instance);
                fi.SetValue(Column1, 0);
                Column1.Name = Column1.FieldName = alanadi = ALAN.ALAN_AD;
                Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                Column1.VisibleIndex = Convert.ToInt32(ALAN.ALAN_SIRA);
                if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                if ((ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
                {
                    Column1.Visible = false;
                }
                if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null)
                {
                    Column1.OptionsColumn.ReadOnly = true;
                }
                if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TEXTBOX)  // TEXT
                {
                    repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                    this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                    repositoryItemTextEdit.AutoHeight = false;
                    repositoryItemTextEdit.MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                    repositoryItemTextEdit.Name = ALAN.ALAN_AD;
                    Column1.ColumnEdit = repositoryItemTextEdit;
                    //this.repositoryItemTextEdit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                }
                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.COMBOBOX)
                {
                    bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                    this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                    repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                    string mt = "";
                    mt = "Get" + ALAN.ALAN_AD;
                    bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.AKTIF, 0, ALAN.ID, ust_id, "", "", 0);
                    this.repositoryItemLookUpEdit1[intBind].NullText = "";
                    this.repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                    this.repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                    this.repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                    this.repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                    this.repositoryItemLookUpEdit1[intBind].CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                    repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);

                    if (bindingSourceArr[intBind].DataSource != null)
                    {
                        if (this.repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns[2].Visible = false;
                        }
                    }
                    if ((int)ALAN.ALAN_LISTE_GENISLIK > 50 || ALAN.ALAN_AD == "CARI_ID" || ALAN.ALAN_AD == "STOK_ID") //M_ALANLAR tablosuna arama tipi konulacak
                    {
                        this.repositoryItemLookUpEdit1[intBind].ImmediatePopup = true;
                        this.repositoryItemLookUpEdit1[intBind].TextEditStyle = TextEditStyles.Standard;
                        this.repositoryItemLookUpEdit1[intBind].PopupFormSize = new Size(300, 500);
                        this.repositoryItemLookUpEdit1[intBind].View.Appearance.FocusedRow.ForeColor = Color.Red;
                        this.repositoryItemLookUpEdit1[intBind].PopupFilterMode = PopupFilterMode.Contains;
                        Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        //this.repositoryItemLookUpEdit1[intBind].KeyDown += new System.Windows.Forms.KeyEventHandler(this.repositoryItemLookUpEdit1_KeyDown);
                        //this.repositoryItemLookUpEdit1[intBind].ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.repositoryItemGridLookUpEdit1_ProcessNewValue);
                        //this.repositoryItemLookUpEdit1[intBind].EditValueChanged += new System.EventHandler(this.lke_EditValueChanged);
                    }
                    if (bindingSourceArr[intBind].DataSource != null)
                    {
                        this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                    }
                    this.repositoryItemLookUpEdit1[intBind].PopupBorderStyle = PopupBorderStyles.Style3D;
                    this.repositoryItemLookUpEdit1[intBind].AppearanceFocused.BackColor = Color.Red;
                    this.Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];

                }
                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.EVETHAYIR)// EVET HAYIR
                {
                    bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                    this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                    repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                    bindingSourceArr[intBind].DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                    this.repositoryItemLookUpEdit1[intBind].NullText = "";
                    this.repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                    repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                    if (bindingSourceArr[intBind].DataSource != null)
                    {
                        this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                        if (this.repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                        }
                    }
                    this.repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                    this.repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                    this.repositoryItemLookUpEdit1[intBind].ValueMember = "ID";

                    this.Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                }
                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TARIH)//TARIH
                {
                }
                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.DECIMAL)//DECIMAL
                {
                    if (ALAN.M_ALAN_ALT_BILGI == 1)
                    {
                        String format = "n" + Convert.ToInt32(ALAN.ALAN_DECIMAL);
                        Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                        Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        if (format != "")
                        {
                            if (format == "n0")
                            {
                                Column1.SummaryItem.DisplayFormat = "{0:0}";
                            }
                            else
                            {
                                Column1.SummaryItem.DisplayFormat = "{0:" + format + "}";
                            }

                        }
                    }
                    repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                    String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
                    String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
                    /////////////this.repositoryItemTextEdit.Mask.EditMask = b + "." + a;
                    if (a == "##")
                    {
                        this.repositoryItemTextEdit.Mask.EditMask = "###,###,###,##0.00";
                    }
                    else
                    {
                        this.repositoryItemTextEdit.Mask.EditMask = "###,###,##0.00000";
                    }
                    this.repositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    this.repositoryItemTextEdit.Mask.UseMaskAsDisplayFormat = true;
                    this.repositoryItemTextEdit.Name = ALAN.ALAN_AD;
                    this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                    //this.repositoryItemTextEdit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                    Column1.ColumnEdit = repositoryItemTextEdit;
                }

                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TAMSAYI)//TAMSAYI
                {
                    if (ALAN.M_ALAN_ALT_BILGI == 1)
                    {
                        Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                        Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    }
                    repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                    this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                    repositoryItemTextEdit.AutoHeight = false;
                    repositoryItemTextEdit.MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                    repositoryItemTextEdit.Name = ALAN.ALAN_AD;
                    //this.repositoryItemTextEdit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                    Column1.ColumnEdit = repositoryItemTextEdit;
                }
                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.CHECKBOX)//checkbox
                {
                    repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                    this.repositoryItemCheckEdit.AutoHeight = false;
                    this.repositoryItemCheckEdit.Name = ALAN.ALAN_AD;
                    this.gridControl1.RepositoryItems.Add(repositoryItemCheckEdit);
                    Column1.ColumnEdit = repositoryItemCheckEdit;
                }
                else if (ALAN.M_ALAN_TIP_ID == 7) // baglı Alan
                {
                    bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                    this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                    repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                    string mt = "";
                    mt = "Get" + ALAN.ALAN_AD;
                    bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.AKTIF, 0, ALAN.ID, ust_id, "", "", 0);
                    repositoryItemLookUpEdit.NullText = "";
                    repositoryItemLookUpEdit.DataSource = bindingSourceArr[intBind];
                    repositoryItemLookUpEdit.DisplayMember = "AD";
                    repositoryItemLookUpEdit.Name = ALAN.ALAN_AD;
                    repositoryItemLookUpEdit.ValueMember = "ID";
                    if (bindingSourceArr[intBind].DataSource != null)
                    {
                        this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                    }
                    repositoryItemLookUpEdit.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                    this.Column1.ColumnEdit = repositoryItemLookUpEdit;

                }
                intBind += 1;
                this.gridView1.Columns.Add(Column1);
                if (ALAN.ALAN_AD != "ID")
                {
                    textArama[intArama] = new DevExpress.XtraEditors.TextEdit();
                    textArama[intArama].Name = Column1.FieldName + " :";
                    textArama[intArama].TabIndex = 0;
                    pnlArama.Controls.Add(textArama[intArama]);
                    textArama[intArama].Location = new System.Drawing.Point(60, 25);
                    textArama[intArama].KeyDown += new KeyEventHandler(Arama);
                    intArama += 1;
                }
            }
            return Globals.rman.GetString(tabloAdi);
        }
        private void eventHandler()
        {
            //this.gridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView1_CustomSummaryCalculate);
            this.controlNavigator1.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.controlNavigator1_ButtonClick);
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
            //this.gridView1.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView1_CustomDrawGroupRow);
           // this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridView1_ShowGridMenu);
            this.gridView1.CustomDrawFooter += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView1_CustomDrawFooter);
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            if (gridIslemTip != GridIslemEn.Bilgilendirme) this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.BILGI1_cmd.Click += new System.EventHandler(this.BILGI_1cmd_Click);
            this.BILGI_2cmd.Click += new System.EventHandler(this.BILGI_2cmd_Click);
            this.BILGI_3cmd.Click += new System.EventHandler(this.BILGI_3cmd_Click);
            this.printableComponentLink1.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink1_CreateReportHeaderArea);
            this.printableComponentLink1.Component = gridControl1;
        }
        #region olaylar
        public void yazdir()
        {
            if (gridView1.FilterPanelText == "")
            {
                gridView1.OptionsPrint.PrintDetails = true;
                gridView1.OptionsPrint.ExpandAllDetails = false;
                gridControl1.ShowPrintPreview();
            }
            else
            {
                printableComponentLink1.CreateDocument();
                printableComponentLink1.ShowPreview();
            }
        }
        private void KayitaGonder(bool kaydet)
        {

            if (kaydet == false)
            {
                NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.CancelEdit);
                controlNavigator1_ButtonClick(controlNavigator1, args);
                if (!args.Handled)
                {
                    controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.CancelEdit);
                }
            }
            else
            {
                NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.EndEdit);
                controlNavigator1_ButtonClick(controlNavigator1, args);
                if (!args.Handled)
                {
                    controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.EndEdit);
                }
            }
        }//controlnavigatorı tetikliyor
        private bool Islem_Kaydet(Object row, int rowHandle)
        {
            if (sonsutunkaydet == true)
            {
                ModelVm = row;
                KayitaGonder(true);
                 yeniSatir = false;
                sonsutunkaydet = false;
            }
            else
            {
                DialogResult res = MessageBox.Show("Onayla?", "Kayıt Yapılsın Mı?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    ModelVm = row;
                    KayitaGonder(true);
                    yeniSatir = false;
                }
                else
                {
                    if (yeniSatir == true)
                    {
                        return false;
                    }
                    else
                    {
                        EventArgs eArgs = new EventArgs();
                        this.usrDoldur(eArgs);
                    }
                }
            }
            yeniSatir = false;
            return true;
        }//form kaydet-silleri tetikliyor
        #endregion
        #region virtuals
        public void usrTabPage_Index_Changed(int index) { }
        public void usrBul(EventArgs e)
        {
            if (Bul != null)
            {
                Bul(this, e);
            }
        }
        public void usrKaydet(EventArgs e)
        {
            if (Kaydet != null)
            {
                Kaydet(this, e);
            }
        }
        public void usrSil(EventArgs e)
        {
            if (Sil != null)
            {
                Sil(this, e);
            }
        }
        public void usrVazgec(EventArgs e)
        {
            if (Vazgec != null)
            {
                Vazgec(this, e);
            }
        }
        public void usrYazdir(EventArgs e)
        {
            if (Yazdir != null)
            {
                Yazdir(this, e);
            }
        }
        public void usrYeni_Kayit(EventArgs e)
        {
            if (Yeni_Kayit != null)
            {
                Yeni_Kayit(this, e);
            }
        }
        public void usrDoldur(EventArgs e)
        {
            if (Doldur != null)
            {
                Doldur(this, e);
            }
        }
        public void usrShowingEditor(EventArgs e)
        {
            if (ShowingEditor != null)
            {
                ShowingEditor(this, e);
            }
        }
        public void usrValidateRow(EventArgs e)
        {
            if (ValidateRow != null)
            {
                ValidateRow(this, e);
            }
        }
        public void usrRowStyle(RowStyleEventArgs e)
        {
            if (UsrRowStyle != null)
            {
                UsrRowStyle(this, e);
            }
        }
        public void usrValidatingEditor(object value, EventArgs e)
        {
            if (ValidatingEditor != null)
            {
                ValidatingEditor(this, e);
            }
        }
        public void usrcontrolNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (controlNavigatorButtonClick != null)
            {
                controlNavigatorButtonClick(this, e);
            }
        }
        public void usrEski_Kayit_Al_Yukle_Satir(int rowHandle, EventArgs e)
        {
            if (Eski_Kayit_Al_Yukle_Satir != null)
            {
                Eski_Kayit_Al_Yukle_Satir(this, e);
            }
        }
        public void usrhucre_Islemleri(GridView gridView1, int FocusedRowHandle, int PrevFocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn, DevExpress.XtraGrid.Columns.GridColumn PrevFocusedColumn, bool yeniSatir, EventArgs e)
        {
            if (hucre_Islemleri != null)
            {
                hucre_Islemleri(this, e);
            }
        }
        public virtual void usrhucre_Islemleri_KeyEvents(DevExpress.XtraGrid.Columns.GridColumn FocusedColumn, KeyEventArgs args)
        {
            if (hucre_Islemleri_KeyEvents != null)
            {
                hucre_Islemleri_KeyEvents(this, args);
            }
        }
        public virtual void usrBagliGridDoldur(bool hepsi, EventArgs e)
        {
            if (BagliGridDoldur != null)
            {
                BagliGridDoldur(this, e);
            }
        }
        public void usrSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (SummaryCalculate != null)
            {
                SummaryCalculate(this, e);
            }
        }
        #endregion
        #region kontroller
        private void controlNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)//Override yeni kayıt/guncelle/sil/ilerigerisatirolustur işlemi Yapılıyor.
        {
            ControlNavigator navigator = (ControlNavigator)sender;
            EventArgs eArgs = new EventArgs();
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag.ToString()=="Yazdir")
                {
                    if (this.popupMenu1!=null && this.popupMenu1.Manager != null)
                    {
                        FieldInfo fi = typeof(NavigatorButtonsBase).GetField("viewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
                        NavigatorButtonsViewInfo buttonsViewInfo = (NavigatorButtonsViewInfo)fi.GetValue(controlNavigator1.ViewInfo.Buttons);
                        Point mousePosition = controlNavigator1.PointToClient(Control.MousePosition);
                        NavigatorButtonViewInfo buttonViewInfo = buttonsViewInfo.ButtonViewInfoAt(mousePosition);
                        Point menuPosition = new Point(buttonViewInfo.Bounds.Left, buttonViewInfo.Bounds.Bottom);
                        menuPosition = controlNavigator1.PointToScreen(menuPosition);
                        popupMenu1.ShowPopup(menuPosition);
                    }
                    else
                    {
                        yazdir();
                    }
                }
                if (e.Button.Tag.ToString() == "Excel")
                {
                    //string fileName = @"C:\gridExport.xls";
                    //printingSystem1.Links[0].CreateDocument();
                    //printingSystem1.ExportToXls(fileName);
                   // printingSystem1.Links[0].
                    //string fileName = @"C:\gridExport.xls";
                    //printingSystem1.Links[0].CreateDocument();
                    //printingSystem1.ExportToXls(fileName);
                    //printableComponentLink1.pi
                    //if (detayGosterme == true)
                    //{
                    //    gridView1.OptionsPrint.PrintDetails = false;
                    //    gridView1.OptionsPrint.ExpandAllDetails = false;
                    //    gridView1.OptionsPrint.ExpandAllGroups = false;
                    //    gridView1.GroupFooterShowMode = GroupFooterShowMode.Hidden;
                    //    gridView1.yeniYazim = true;
                    //}
                    //else
                    //{
                    //    gridView1.OptionsPrint.PrintDetails = true;
                    //    gridView1.OptionsPrint.ExpandAllDetails = true;
                    //    gridView1.OptionsPrint.ExpandAllGroups = true;
                    //    gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
                    //    gridView1.yeniYazim = true;
                    //}
                    gridView1.OptionsPrint.AutoWidth = false;
                    //gridView1.yeniYazim = false;
                    string filepath = System.IO.Path.GetTempFileName();
                    filepath = filepath.Remove(filepath.LastIndexOf('.') + 1);
                    filepath = String.Concat(filepath, "xlsx");

                    //XlsxExportOptions options = new XlsxExportOptions();
                    //options.TextExportMode = TextExportMode.Text;
                    //gridControl1.ExportToXlsx(filepath, options);
                    gridControl1.ExportToXlsx(filepath);
                    //gridControl1.ExportToXlsx(filepath);
                    System.Diagnostics.ProcessStartInfo startInfo =
                         new System.Diagnostics.ProcessStartInfo("Excel.exe", String.Format("/r \"{0}\"", filepath));
                    System.Diagnostics.Process.Start(startInfo);

                     //Export.ExportToGridControl(this.gridControl1, "belge", ".xls", "XLS");
             
                }
                if (e.Button.Tag.ToString() == "Pdf")
                {
                    gridView1.OptionsPrint.AutoWidth = false;
                    string filepath = System.IO.Path.GetTempFileName();
                    filepath = filepath.Remove(filepath.LastIndexOf('.') + 1);
                    filepath = String.Concat(filepath, "pdf");
                    gridControl1.ExportToPdf(filepath);
                    Process process = new Process();
                    process.StartInfo.FileName = filepath;// String.Format("/r \"{0}\"", filepath);
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle =
                    ProcessWindowStyle.Normal;
                    process.Start();
                    //Export.ExportToGridControl(this.gridControl1,this.gridControl1.Text, ".pdf", "PDF");
                }
                else if (e.Button.Tag.ToString() == "Büyüt")
                {
                    ListForm frm = new ListForm();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.WindowState = FormWindowState.Maximized;
                    //frm.Controls.Add(gridControl);
                    frm.grd = this;
                    frm.Controls.Add(frm.grd);
                    //frm.Controls.Add(gridView1);
                    frm.ShowDialog();
                    this.gridControl1 = frm.grd.gridControl1;
                    this.gridView1 = frm.grd.gridView1;
                }
                else if (e.Button.Tag.ToString() == " Detay Çalışma ")
                {
                    
                    ListDetayCalisma frm = new ListDetayCalisma();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.FormAdi = this.gridIslemAdi; 
                    //frm.Controls.Add(gridControl);
                    frm.grd.gridControl1 = this.gridControl1;
                    frm.grd.gridView1 = this.gridView1;
                    frm.degerId = detayCalismaDegerId;
                  
                    List<object> a = new List<object>();
                    for (int i = 0; i < gridView1.DataRowCount; i++) {
                        object row = gridView1.GetRow(i);
                        
                        a.Add(row);
                    }
                    frm.a = a;
                    //frm.Controls.Add(frm.grd);
                    ////frm.Controls.Add(gridView1);
                    frm.PivotGridDoldur();
                    frm.ShowDialog();
                    //this.gridControl1 = frm.grd.gridControl1;
                    //this.gridView1 = frm.grd.gridView1;
                }
                this.usrcontrolNavigator_ButtonClick(sender,e);
            }
            else if (e.Button.ImageIndex == 0)
            {
                this.usrDoldur(eArgs);
            }
          
            else if (e.Button == navigator.Buttons.Append)// Yeni kayıda basildiginda direk kayida hazir olunmasi icin
            {
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];
                gridView1.ShowEditor();
            }
            else if (e.Button == navigator.Buttons.EndEdit)//Kaydete basildiginda grid tabinda ise
            {
                if (yeniSatir == false)
                {
                    this.usrKaydet(eArgs);
                }
                else
                {
                
                    this.usrYeni_Kayit(eArgs);
                }
                e.Handled = islemTamamDegil;
                //this.usrDoldur(eArgs);
            }
            else if (e.Button == navigator.Buttons.Remove)//Sil İşlemi
            {
                DialogResult res = MessageBox.Show("Onayla?", "Kayıt Silinsin Mi", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    this.controlNavigator1.Focus();
                    this.usrSil(eArgs);
                    e.Handled = islemTamamDegil;
                    if (islemTamamDegil == true)
                    {
                        this.usrDoldur(eArgs);
                    }
                }
                else
                {
                    e.Handled = true;
                }
                this.gridControl1.Focus();
            }
            else if (e.Button == navigator.Buttons.CancelEdit)//Sil İşlemi
            {
                e.Handled = false;
            }
        }

        private void printableComponentLink1_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            string d = gridView1.FilterPanelText;
            DevExpress.XtraPrinting.TextBrick brick;
            brick = e.Graph.DrawString(this.Text, Color.Navy, new RectangleF(0, 0, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Tahoma", 8);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
            DevExpress.XtraPrinting.TextBrick brick1;
            brick1 = e.Graph.DrawString(gridView1.FilterPanelText, Color.Navy, new RectangleF(0, 30, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick1.Font = new Font("Tahoma", 8);
            brick1.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }

        #endregion
        #region gridkontroller
        private void gridView1_RowStyle(object sender,
DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //usrRowStyle(e);
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Category"]);
            //    if (category == "Beverages")
            //    {
            //        e.Appearance.BackColor = Color.Salmon;
            //        e.Appearance.BackColor2 = Color.SeaShell;
            //    }
            //}
        }

        private void gridView1_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRow)
            {
                //view.FocusedRowHandle = hitInfo.RowHandle;
                ContextMenu1.Show(view.GridControl, e.Point);
            }
        }
        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {

                INavigatableControl gr = gridControl1;
                bool remove = gr.IsActionEnabled(NavigatorButtonType.Remove);
                GridControl grid = sender as GridControl;
                GridView view = grid.FocusedView as GridView;
                KeyEventArgs keyArgs = new KeyEventArgs(e.KeyCode);
                if (e.KeyCode == Keys.Delete && (_bilgilendirme == false && _guncelle == false))
                {
                    if (remove == true)
                    {
                        NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.Remove);
                        controlNavigator1_ButtonClick(controlNavigator1, args);
                        if (!args.Handled)
                        {
                            controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.Remove);
                        }
                    }
                }
                else if (e.KeyCode == Keys.Insert && (_bilgilendirme == false && _guncelle == false))
                {
                    NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.EndEdit);
                    controlNavigator1_ButtonClick(controlNavigator1, args);
                    if (!args.Handled)
                    {
                        controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.EndEdit);
                    }
                }
                else if (e.KeyCode == Keys.F2 && (_bilgilendirme == false && _guncelle == false))
                {
                    if (view.State == DevExpress.XtraGrid.Views.Grid.GridState.Normal)
                    {

                        NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.Append);
                        controlNavigator1_ButtonClick(controlNavigator1, args);
                        if (!args.Handled)
                        {
                            controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.Append);
                        }
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.CancelEdit);
                    controlNavigator1_ButtonClick(controlNavigator1, args);
                    if (!args.Handled)
                    {
                        controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.CancelEdit);
                    }
                    if (escapeKapatma == false && Globals.escapeTabDegistir==true) this.ParentForm.Close();
                }
                else if (e.KeyCode == Keys.F3)
                {
                    //this.gridView1.UpdateGroupSummary();
                    //if (this.gridView1.OptionsView.ShowAutoFilterRow == false)
                    //    this.gridView1.OptionsView.ShowAutoFilterRow = true;
                    //else
                    //    this.gridView1.OptionsView.ShowAutoFilterRow = false;
                    if (view.OptionsView.ShowAutoFilterRow == false)
                    {
                        if (Control.ModifierKeys != Keys.Shift)
                        {
                            view.OptionsView.ShowAutoFilterRow = true;
                            view.FocusedRowHandle = GridControl.AutoFilterRowHandle;
                        }
                    }
                    else
                    {
                        view.OptionsView.ShowAutoFilterRow = false;
                    }
                }
                else if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (view.FocusedColumn != null && view.FocusedColumn.VisibleIndex == view.VisibleColumns.Count - 1)
                    {
                         sonsutunkaydet = true;
                    }
                    KeyEventArgs args = new KeyEventArgs(e.KeyCode);
                    EventArgs eArgs = new EventArgs();
                    usrhucre_Islemleri_KeyEvents(gridView1.FocusedColumn, args);
                }
                else
                {
                    KeyEventArgs args = new KeyEventArgs(e.KeyCode);
                    EventArgs eArgs = new EventArgs();
                    usrhucre_Islemleri_KeyEvents(gridView1.FocusedColumn,args);
                }
            }
            catch (Exception)
            {
            }
        }
        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn == null || e.PrevFocusedColumn == null) return;
            EventArgs eArgs = new EventArgs();
            usrhucre_Islemleri(gridView1, gridView1.FocusedRowHandle, gridView1.FocusedRowHandle, e.FocusedColumn, e.PrevFocusedColumn, yeniSatir,eArgs);
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                ModelVm = gridView1.GetFocusedRow();
                EventArgs eArgs = new EventArgs();
                usrBagliGridDoldur(false,eArgs);
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            EventArgs eArgs = new EventArgs();
            usrBagliGridDoldur(true,eArgs);
        }
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            EventArgs eArgs = new EventArgs();
            rowHandleExcepTionMessage = "";
            usrValidateRow(eArgs);
            e.Valid = blnValidateRow;
            if (e.Valid == true)
            {
                e.Valid = Islem_Kaydet(e.Row, e.RowHandle);
                yeniSatir = false;
            }
            
        }
        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
            if (rowHandleExcepTionMessage != "")
                MessageBox.Show(rowHandleExcepTionMessage);
        }
        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            yeniSatir = true;
            blnGridView1ShowingEditor = false;
        }
        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedColumn.FieldName.ToString() != "CheckMarkSelection" && gridIslemTip==GridIslemEn.Bilgilendirme)
            {
                e.Cancel = true;
                return;
            }
            EventArgs eArgs = new EventArgs();
            usrShowingEditor(eArgs);
            e.Cancel = blnGridView1ShowingEditor;
        }// tanımlanmadı
        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            EventArgs eArgs = new EventArgs();
            usrValidatingEditor(e.Value,eArgs);
            e.ErrorText = errorTextValidatingEditor;
            e.Valid = blnValidatingEditor;
        }// tanımlanmadı
        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            acilisTamamlandi = true;
        }// tanımlanmadı
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //int width = e.Bounds.Width;
            //textArama[e.Column.VisibleIndex].Width = width;
            //textArama[e.Column.VisibleIndex].Size = new System.Drawing.Size(e.Bounds.Width, e.Bounds.Height);
            //textArama[e.Column.VisibleIndex].TabIndex = 0;
            //textArama[e.Column.VisibleIndex].Location = new System.Drawing.Point(e.Bounds.Left, textArama[e.Column.VisibleIndex].Location.Y);
        }
        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumnSummaryItem item = view.Columns["GIRIS_MIKTAR"].SummaryItem as GridColumnSummaryItem;
            //GridView view = sender as GridView;

            //GridGroupSummaryItem item = new GridGroupSummaryItem();
            //item = usrDetay.gridView1.Columns["BAKIYE_TUTAR"].GridGroupSummaryItem;
            //GridColumnSummaryItem item = usrDetay.gridView1.GetRowSummaryItem(0, usrDetay.gridView1.Columns["BAKIYE_TUTAR"].SummaryItem);
            //if (e.Item.FieldName.ToString() == "GIRIS_MIKTAR")
            //{
                // item.SetSummary = 1; 
                e.TotalValue = 10;
          //  }
           // usrSummaryCalculate(sender, e);
        }
        public void ContextMenuolustur()
        {
            int index = 0;
            foreach (var buttons in controlNavigator1.Buttons.CustomButtons)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)buttons;
                if (btn.Tag!=null && btn.Visible==true)
                {
                    contextMenuItems[index] = new MenuItem();
                    contextMenuItems[index].Text = btn.Hint;
                    contextMenuItems[index].Tag = btn.Tag;
                    ContextMenu1.MenuItems.Add(contextMenuItems[index]);
                    //this.controlNavigator1.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.controlNavigator1_ButtonClick);
                    //contextMenuItems[index].Click += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.controlNavigator1_ButtonClick);
                    contextMenuItems[index].Click += new System.EventHandler(this.MenuItem1_Click);
                    index++;
                }
                
            }
        }
        private void MenuItem1_Click(object sender, System.EventArgs e)
        {
            MenuItem mn = (MenuItem)sender;
            NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.CustomButtons[0]);
            args.Button.Tag = mn.Tag;
            args.Button.Hint = mn.Text;
            controlNavigator1_ButtonClick(controlNavigator1, args);
            //this.usrcontrolNavigator_ButtonClick(sender, e);
        }
        #endregion
        #region ekranaltislemlerAC
        private bool blnBilgi1Kapat = false;
        private bool blnBilgi2Kapat = false;
        private bool blnBilgi3Kapat = false;
        private void PanelAyarla(bool blnKapat)
        {
            if (blnKapat == true)
            {
                //pnl.Size = new System.Drawing.Size(536, 20);

                this.panelControl1.Size = new System.Drawing.Size(536, this.panelControl1.Size.Height - 80);

            }
            else
            {
                //pnl.Size = new System.Drawing.Size(536, 100);
                this.panelControl1.Size = new System.Drawing.Size(536, this.panelControl1.Size.Height + 100);
            }
        }
        private void BILGI_1cmd_Click(object sender, EventArgs e)
        {
            if (blnBilgi1Kapat == true)// kapatma
            {
                if (pnlEkIslemler.Visible == false && pnlIslemler.Visible == false)
                {
                    this.pnlArama.Size = new System.Drawing.Size(536, 20);
                    this.panelControl1.Size = new System.Drawing.Size(536, 25);
                    blnBilgi1Kapat = false;
                }
                else
                {
                    this.pnlArama.Size = new System.Drawing.Size(536, 20);
                    blnBilgi1Kapat = false;
                    if (blnBilgi3Kapat == true && blnBilgi2Kapat == true)// ikisi de acik
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 220);
                    }
                    else if (blnBilgi3Kapat == false && blnBilgi2Kapat == false)// ikisi de kapali
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 65);
                    }
                    else
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 140);
                    }
                }
            }
            else
            {
                if (pnlEkIslemler.Visible == false && pnlIslemler.Visible == false)
                {
                    this.pnlArama.Size = new System.Drawing.Size(536, 40);
                    this.panelControl1.Size = new System.Drawing.Size(536, 65);
                    blnBilgi1Kapat = true;
                }
                else
                {
                    this.pnlArama.Size = new System.Drawing.Size(536, 90);
                    blnBilgi1Kapat = true;
                    if (blnBilgi3Kapat == true && blnBilgi2Kapat == true)// ikisi de acik
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 240);
                    }
                    else if (blnBilgi3Kapat == false && blnBilgi2Kapat == false)// ikisi de kapali
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 90);
                    }
                    else
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 160);
                    }
                }
            }
        }
        private void BILGI_2cmd_Click(object sender, EventArgs e)
        {
            if (blnBilgi2Kapat == true)
            {
                this.pnlIslemler.Size = new System.Drawing.Size(536, 20);
                if (blnBilgi1Kapat == true && blnBilgi3Kapat == true)// ikisi de acik
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 220);
                }
                else if (blnBilgi1Kapat == false && blnBilgi3Kapat == false)// ikisi de kapali
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 65);
                }
                else
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 140);
                }

                blnBilgi2Kapat = false;
            }
            else
            {
                this.pnlIslemler.Size = new System.Drawing.Size(536, 100);
                if (blnBilgi1Kapat == true && blnBilgi3Kapat == true)// ikisi de acik
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 300);
                }
                else if (blnBilgi1Kapat == false && blnBilgi3Kapat == false)// ikisi de kapali
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 145);
                }
                else
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 220);
                }

                blnBilgi2Kapat = true;
            }

        }
        private void BILGI_3cmd_Click(object sender, EventArgs e)
        {
            if (blnBilgi3Kapat == true)
            {
                this.pnlEkIslemler.Size = new System.Drawing.Size(536, 20);
                blnBilgi3Kapat = false;
                if (blnBilgi1Kapat == true && blnBilgi2Kapat == true)// ikisi de acik
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 220);
                }
                else if (blnBilgi1Kapat == false && blnBilgi2Kapat == false)// ikisi de kapali
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 65);
                }
                else
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 140);
                }

            }
            else
            {
                this.pnlEkIslemler.Size = new System.Drawing.Size(536, 100);
                if (blnBilgi1Kapat == true && blnBilgi2Kapat == true)// ikisi de acik
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 300);
                }

                else if (blnBilgi1Kapat == false && blnBilgi2Kapat == false)// ikisi de kapali
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 145);
                }
                else
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 220);

                }
                blnBilgi3Kapat = true;
            }
        }
        private void Arama(object sender, EventArgs e)
        {
            Object aVm;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                aVm = gridView1.GetRow(i);
                //if (temp.IRSALIYE_NO != null)
                //{
                //    int result = 0;// temp.IRSALIYE_NO.CompareTo(textEdit1.Text);
                //    if (result > 0)
                //    {
                //        gridView1.FocusedRowHandle = i;
                //        break;
                //    }
                //}
            }
        }
        #endregion

        #region altToplamYaz
        public void gridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            ArrayList items = ExtractSummaryItems(view);
            if (items.Count == 0) return;
            DrawBackground(e, view);
            DrawSummaryValues(e, view, items);
            e.Handled = true;
        }

        private ArrayList ExtractSummaryItems(GridView view)
        {
            ArrayList items = new ArrayList();
            foreach (GridSummaryItem si in view.GroupSummary)
                if (si is GridGroupSummaryItem && si.SummaryType != SummaryItemType.None)
                    items.Add(si);
            return items;
        }

        private void DrawBackground(RowObjectCustomDrawEventArgs e, GridView view)
        {
            GridGroupRowPainter painter;
            GridGroupRowInfo info;
            painter = e.Painter as GridGroupRowPainter;
            info = e.Info as GridGroupRowInfo;
            int level = view.GetRowLevel(e.RowHandle);
            int row = view.GetDataRowHandleByGroupRowHandle(e.RowHandle);
            info.GroupText = string.Format("{0}: {1}", view.GroupedColumns[level].Caption,
                view.GetRowCellDisplayText(row, view.GroupedColumns[level]));
            e.Appearance.DrawBackground(e.Cache, info.Bounds);
            painter.ElementsPainter.GroupRow.DrawObject(info);
        }

        private void DrawSummaryValues(RowObjectCustomDrawEventArgs e, GridView view, ArrayList items)
        {
            Hashtable values = view.GetGroupSummaryValues(e.RowHandle);
            foreach (GridGroupSummaryItem item in items)
            {
                Rectangle rect = GetColumnBounds(view, item);
                if (rect.IsEmpty) continue;
                string text = item.GetDisplayText(values[item], false);
                rect = CalcSummaryRect(text, e, view.Columns[item.FieldName]);
                e.Appearance.DrawString(e.Cache, text, rect);
            }
        }

        private Rectangle GetColumnBounds(GridView view, GridGroupSummaryItem item)
        {
            GridColumn column = view.Columns[item.FieldName];
            return GetColumnBounds(column);
        }

        private Rectangle GetColumnBounds(GridColumn column)
        {
            if (column==null)
            {
                return Rectangle.Empty;
            }
            GridViewInfo gridInfo = (GridViewInfo)column.View.GetViewInfo();
            GridColumnInfoArgs colInfo = gridInfo.ColumnsInfo[column];

            if (colInfo != null)
                return colInfo.Bounds;
            else
                return Rectangle.Empty;
        }

        private Rectangle CalcSummaryRect(string text, RowObjectCustomDrawEventArgs e, GridColumn column)
        {
            SizeF sz = TextUtils.GetStringSize(e.Graphics, text, e.Appearance.Font);
            int width = Convert.ToInt32(sz.Width) + 1;
            Rectangle result = GetColumnBounds(column);
            result = FixLeftEdge(width, result);
            result.Width = result.Width;
            result.Y = e.Bounds.Y;
            result.Height = e.Bounds.Height - 2;
            return PreventSummaryTextOverlapping(e, result);
        }

        private Rectangle FixLeftEdge(int width, Rectangle result)
        {
            int delta = result.Width - width - 2;
            if (delta > 0)
            {
                result.X += delta;
                result.Width -= delta;
            }
            return result;
        }

        private Rectangle PreventSummaryTextOverlapping(RowObjectCustomDrawEventArgs e, Rectangle rect)
        {
            GridGroupRowInfo gInfo = (GridGroupRowInfo)e.Info;
            int groupTextLocation = gInfo.ButtonBounds.Right + 10;
            int groupTextWidth = TextUtils.GetStringSize(e.Graphics, gInfo.GroupText, e.Appearance.Font).Width;
            Rectangle r = new Rectangle(groupTextLocation, 0, groupTextWidth, e.Info.Bounds.Height);
            if (r.Right > rect.X)
            {
                if (r.Right > rect.Right)
                    rect.Width = 0;
                else
                {
                    rect.Width -= r.Right - rect.X;
                    rect.X = r.Right;
                }
            }
            return rect;
        }
        #endregion
        private void gridView1_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            e.Painter.DrawObject(e.Info);

            //GridView view = sender as GridView;
            //GridViewInfo gvi = view.GetViewInfo() as GridViewInfo;

            //DevExpress.Utils.Drawing.FooterCellInfoArgs info = new DevExpress.Utils.Drawing.FooterCellInfoArgs(e.Cache);
            //info.Appearance.Assign(view.PaintAppearance.FooterPanel);
            //Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, view.IndicatorWidth, e.Bounds.Height);
            //rect.Inflate(-3, -3);
            //info.Bounds = rect;
            //info.DisplayText = string.Format("{0}", view.DataRowCount);
            //gvi.Painter.ElementsPainter.FooterCell.DrawObject(info);

            //e.Handled = true;

            e.Painter.DrawObject(e.Info);

            GridView view = sender as GridView;
            //string s = "Kayıt Listelendi";
            //if (Globals.rman.GetString("Kayıt Listelendi") != null) { s = Globals.rman.GetString("Kayıt Listelendi"); }
            string sum = string.Format("{0}", view.DataRowCount + " " + YardimciIslemler.IstenilenDileCevir("Kayıt Listelendi"));
            Point point = new Point(e.Bounds.Left + 3, e.Bounds.Top + 3);
            e.Graphics.DrawString(sum, new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162))), Brushes.Black, point);

            e.Handled = true;

        }
        private void usrGridIslem_Load(object sender, EventArgs e)
        {
            ContextMenuolustur();
        }

    }
}
