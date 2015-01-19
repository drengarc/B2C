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
using System.IO;
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;

namespace Prodma.Sistem.Forms
{
    public partial class Kullanici1 : TanitimSablon
    {
        #region degiskenler
        private KullaniciCntrl kulcntrl = new KullaniciCntrl();
        private DevExpress.XtraEditors.TextEdit[] textEdit1 = new DevExpress.XtraEditors.TextEdit[30];
        private Label[] lbl = new Label[30];
        private usrKullaniciEkBilgi usrKullaniciEkBilgi = new usrKullaniciEkBilgi();
        #endregion
        #region Constructors
        public Kullanici1()
        {
            InitializeComponent();
            tabloAdi = "KULLANICI";
            this.Text = Gridi_Olustur();  
            Tab_Gizle_Ekle();
            //Doldur();
            Kart_Bilgi_Duzenle(); 
          //  this.Activated += new System.EventHandler(this.Stok_Activated);
        }
        private void Tab_Gizle_Ekle()
        {
            this.pnlEkIslemler.Visible = true;
            this.pnlIslemler.Visible = true;
            this.panelControl1.Size = new System.Drawing.Size(948, 65);
            tabPage1.Text = "Kullanıcı Bilgi Giriş";
            tabPage2.Text = "Ek Bilgiler";
            this.pnlEkBilgiler.Controls.Add(usrKullaniciEkBilgi);
            this.tabPage2.Controls.Remove(controlNavigator2);
            this.tabControl1.TabPages.Remove(tabPage3);
            controlNavigator3.Visible = false;
            this.tabControl1.TabPages.Remove(tabPage4);
            this.tabControl1.TabPages.Remove(tabPage5);
            this.tabControl1.TabPages.Remove(tabPage6);
            this.tabControl1.TabPages.Remove(tabPage7);
            this.tabControl1.TabPages.Remove(tabPage8);
            this.tabControl1.TabPages.Remove(tabPage9);
            this.tabControl1.TabPages.Remove(tabPage10);
            this.tabControl1.TabPages.Remove(tabPage11);
            this.tabControl1.TabPages.Remove(tabPage12);
            this.tabControl1.TabPages.Remove(tabPage13);
        }
        public override void Doldur()
        {
            KullaniciVm k = new KullaniciVm();
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(null);
            base.gridControl1.DataSource = testInfoBindingSource;
            base.gridView1.Columns["ID"].Visible = false;
            base.gridView1.FocusedColumn = base.gridView1.VisibleColumns[0];
        }
        
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            KullaniciVm k = (KullaniciVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Yeni_Kayit()
        {
            KullaniciVm k = (KullaniciVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Sil()
        {
            KullaniciVm k = (KullaniciVm)ModelVm;
            kulcntrl.Sil(k.ID,k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Yazdir()
        {
            gridControl1.ShowPrintPreview();
        }
        public override void Bul()
        {
        }
        public override void Vazgec()
        {
        }
    

        #endregion

        #region ektabislemleri
        public override void TabPage_Index_Changed(int index)
        {
            if (index == 0)
            {
                Doldur();
            }
            else if (index == 1)
            {
                TabIndex2_Ac(gridView1.FocusedRowHandle);
            }
        }
        public override void TabPage_Selecting(DevExpress.XtraTab.XtraTabPage tb)
        {
            tabSelect = true;
        }
        #endregion
        #region Ek Tablara Bilgi Aktarımı

        public void TabIndex2_Ac(int index)
        {
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            KullaniciVm k = (KullaniciVm)ModelVm;
            usrKullaniciEkBilgi.kullaniciVm = k;
            usrKullaniciEkBilgi.Doldur();
        }

        public override void Dinamik_TextBox_Olustur(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int width = e.Bounds.Width;
            textEdit1[e.Column.VisibleIndex].Width = width;
            textEdit1[e.Column.VisibleIndex].Size = new System.Drawing.Size(e.Bounds.Width, e.Bounds.Height);
            textEdit1[e.Column.VisibleIndex].TabIndex = 0;
            textEdit1[e.Column.VisibleIndex].Location = new System.Drawing.Point(e.Bounds.Left, textEdit1[e.Column.VisibleIndex].Location.Y);
            lbl[e.Column.VisibleIndex].Width = width;
            lbl[e.Column.VisibleIndex].Size = new System.Drawing.Size(e.Bounds.Width, e.Bounds.Height);
            lbl[e.Column.VisibleIndex].TabIndex = 0;
            lbl[e.Column.VisibleIndex].Location = new System.Drawing.Point(e.Bounds.Left, lbl[e.Column.VisibleIndex].Location.Y);
        }
        private void Kart_Bilgi_Duzenle()
        {
            int intIndex = 0;
            //foreach (Control ChildControls in pnlTabpage2.Controls)
            //{
            //    ChildControls.Dispose();
            //}
            DevExpress.XtraGrid.Columns.GridColumn Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {

                Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                Column1 = gridView1.Columns[i];
                if (i == 0)
                {
                    Column1.Visible = false;
                }
                else
                {

                    lbl[intIndex] = new Label();
                    lbl[intIndex].Text = Column1.FieldName + "";
                    lbl[intIndex].TabIndex = 0;
                    lbl[intIndex].Location = new System.Drawing.Point(60, 0);
                    panel1.Controls.Add(lbl[intIndex]);
                    textEdit1[intIndex] = new DevExpress.XtraEditors.TextEdit();
                    textEdit1[intIndex].Name = Column1.FieldName + " :";
                    textEdit1[intIndex].TabIndex = 0;
                    textEdit1[intIndex].Location = new System.Drawing.Point(60, 15);
                    panel1.Controls.Add(textEdit1[intIndex]);
                    intIndex += 1;
                }
            }

        }
     private void Dinamik_Text_Box_Doldur()
        {
            int intIndex = 0;
            Object row = gridView1.GetFocusedRow();
            gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
            DevExpress.XtraGrid.Columns.GridColumn Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
            for (int i = 1; i < gridView1.Columns.Count; i++)
            {
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[i]) != null)
                {
                    textEdit1[i - 1].Text = Convert.ToString(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns[i]));
                }
                intIndex += 1;
            }

        }
        #endregion
        
     
    }
}