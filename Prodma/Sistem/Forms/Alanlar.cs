using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccess;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.Sistem.Models;
using Prodma.Sistem.Controllers;
using System.Data.SqlClient;
namespace Prodma.Sistem.Forms
{
    public partial class Alanlar : Prodma.DataAccess.TanitimSablon
    {
        #region degiskenler
        private AlanlarCntrl kulcntrl = new AlanlarCntrl();
        #endregion
        #region Constructors
        public Alanlar()
        {
            
            InitializeComponent();
            tabloAdi = "M_ALANLAR";
            this.Text = this.Text = Gridi_Olustur();   
            Tab_Gizle_Ekle();
            //Doldur();
        }
        private void Tab_Gizle_Ekle()
        {
            tabPage1.Text = "Alanlar Bilgi Giriş";
            tabPage2.Text = "Ek Bilgiler";

            this.tabControl1.TabPages.Remove(tabPage2);
            controlNavigator2.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage3);
            //controlNavigator3.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage4);
            controlNavigator4.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage5);
            //controlNavigator5.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage6);
            //controlNavigator6.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage7);
            //controlNavigator7.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage8);
            //controlNavigator8.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage9);
            //controlNavigator9.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage10);
            //controlNavigator10.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage11);
            //controlNavigator11.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage12);
            //controlNavigator12.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage13);
            //controlNavigator13.NavigatableControl = base.gridControl1;



        }
        public override void Doldur()
        {
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(null);
          base.gridControl1.DataSource = testInfoBindingSource;
       //   gridView1.Columns["ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        //public void Gridi_Olustur()
        //{

        //    ProdmaEntities context = new ProdmaEntities();
        //    var q = from d in context.ALANLAR
        //            orderby d.ALAN_SIRA 
        //            where d.AD == "ALANLAR" && d.ALAN_GOSTERILEN == 1
        //            select d;
        //    foreach (var ALAN in q)
        //    {
        //        Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
        //        if (ALAN.ALAN_TIP == 1)
        //        {
        //            Column1.FieldName = ALAN.ALAN_AD;
        //            Column1.Name = ALAN.ALAN_AD;
        //            Column1.Visible = true;
        //            Column1.VisibleIndex = 1;
        //            repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
        //            gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
        //            repositoryItemTextEdit.AutoHeight = false;
        //            repositoryItemTextEdit.MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
        //            repositoryItemTextEdit.Name = "repositoryItemTextEdit1";
        //            Column1.ColumnEdit = repositoryItemTextEdit;
        //        }
        //        else if (ALAN.ALAN_TIP == 2)
        //        {
        //            Column1.Caption = ALAN.ALAN_AD;
        //            Column1.FieldName = ALAN.ALAN_AD;
        //            Column1.Name = ALAN.ALAN_AD;
        //            Column1.Visible = true;
        //            Column1.VisibleIndex = 1;
        //            ProdmaEntities context1 = new ProdmaEntities();
        //            bindingSource1 = new System.Windows.Forms.BindingSource();
        //            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
        //            gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1);
        //            Column1.ColumnEdit = this.repositoryItemLookUpEdit1;
        //            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
        //           new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD", "AD")});
        //            if (ALAN.ALAN_AD == "ALAN_TIP")
        //            { bindingSource1.DataSource = ListService.GetAlanTip(); }
        //            this.repositoryItemLookUpEdit1.NullText = "";
        //            this.repositoryItemLookUpEdit1.DataSource = bindingSource1;
        //            this.repositoryItemLookUpEdit1.DisplayMember = "AD";
        //            this.repositoryItemLookUpEdit1.Name = ALAN.ALAN_AD;
        //            this.repositoryItemLookUpEdit1.ValueMember = "ID";
        //            this.repositoryItemLookUpEdit1 = null;
        //        }
        //        else if (ALAN.ALAN_TIP == 3)
        //        {
        //            Column1.FieldName = ALAN.ALAN_AD;
        //            Column1.Name = ALAN.ALAN_AD;
        //            Column1.Visible = true;
        //            Column1.VisibleIndex = 1;
        //            repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
        //            String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
        //            String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
        //            this.repositoryItemTextEdit.Mask.EditMask = b + "." + a;
        //            this.repositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
        //            this.repositoryItemTextEdit.Name = "repositoryItemTextEdit";
        //            gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
        //            Column1.ColumnEdit = repositoryItemTextEdit;

        //        }
        //        else if (ALAN.ALAN_TIP == 4)
        //        {
        //            Column1.FieldName = ALAN.ALAN_AD;
        //            Column1.Name = ALAN.ALAN_AD;
        //            Column1.Visible = true;
        //            Column1.VisibleIndex = 1;
        //            repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
        //            this.repositoryItemDateEdit.AutoHeight = false;
        //            this.repositoryItemDateEdit.Name = "repositoryItemDateEdit";
        //            this.repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
        //            new DevExpress.XtraEditors.Controls.EditorButton()});
        //            gridControl1.RepositoryItems.Add(repositoryItemDateEdit);
        //            Column1.ColumnEdit = repositoryItemDateEdit;
        //        }
        //        this.gridView1.Columns.Add(Column1);
        //    }
        //}
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            AlanlarVm k = (AlanlarVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            AlanlarVm k = (AlanlarVm)ModelVm;
            DialogResult res = MessageBox.Show("Database'e eklensin mi?","",MessageBoxButtons.YesNo);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                DbyeEkle(k);
            }
            else
            {
                alanIdBul(k);
            }
            if (k.M_ALANLAR_ID == null)
            {
                k.M_ALANLAR_ID = 0;
                k.M_ALANLAR_ALAN_TABLOSU_ID = 0;
            }
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            AlanlarVm k = (AlanlarVm)ModelVm;
            kulcntrl.Sil(k.ID, k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public void alanIdBul(AlanlarVm vm)
        {
            string tabloAdi = "";
            AlanlarCntrl cntrl = new AlanlarCntrl();
            List<AlanlarVm> list = cntrl.Liste_Al(null);

            var sonuc = list.Find(f => f.ID == vm.M_ALANLAR_ALAN_TABLOSU_ID);
            tabloAdi = sonuc.ALAN_AD;
            var sonuc2 = list.FindAll(f => f.ID > 10000 && f.ID < 20000).OrderByDescending(o => o.ID).FirstOrDefault();
            int id = sonuc2.ID + 1;
            vm.ID = id;
        }
        public void DbyeEkle(AlanlarVm vm)
        {
            string tabloAdi="";
            AlanlarCntrl cntrl = new AlanlarCntrl();
            List<AlanlarVm> list = cntrl.Liste_Al(null);

            var sonuc = list.Find(f => f.ID == vm.M_ALANLAR_ALAN_TABLOSU_ID);
            tabloAdi = sonuc.ALAN_AD;
            var sonuc2 = list.FindAll(f => f.ID > 10000 && f.ID < 20000).OrderByDescending(o => o.ID).FirstOrDefault();
            int id = sonuc2.ID+1;
            vm.ID = id;
            string dataTip="";
            string nullDurumu="null";
            if (vm.M_ALAN_TIP_ID == (int)AlanTipEn.DECIMAL)
            {
               dataTip = "decimal(" + vm.ALAN_UZUNLUK + "," + vm.ALAN_PRECISION +")";
            }
            else if (vm.M_ALAN_TIP_ID == (int)AlanTipEn.COMBOBOX)
            {
               dataTip = "int";
            }
            else if (vm.M_ALAN_TIP_ID == (int)AlanTipEn.EVETHAYIR)
            {
                dataTip = "int";
            }
            string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = String.Format(strCon, ".", "sa", "bgssup", "TIC0112");
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "ALTER TABLE " + tabloAdi + " Add " + vm.ALAN_AD + " " + dataTip + " " + nullDurumu;
            cmd.ExecuteNonQuery();

            
            //string alanlarUpdate = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK," ;
            //alanlarUpdate += "ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,";
            //alanlarUpdate += "M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(";
            //alanlarUpdate += Convert.ToString(id) + "," + m_AlanlarId  + ",'" + AlanAdi.Text + "','',0,";
            //alanlarUpdate += "'','',0,1,2,";
            //alanlarUpdate += "1,0,1,1)"; 
            
            //cmd = new SqlCommand();
            //cmd.Connection = cn;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = alanlarUpdate;
            //cmd.ExecuteNonQuery();
        }
        public override void Yazdir()
        {
             gridControl1.ShowPrintPreview();
        }
        public override void Bul()
        {
            Kopyala();
        }
        public override void Vazgec()
        { 
        }
        public  void Kopyala()
        {
            kulcntrl.Kopyala("STOK_FIS_SATIR");
        }
        #endregion
    }
}