﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using B2C.Controllers;
using B2C.Models; 
using Prodma.DataAccessB2C;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.WinForms;
namespace B2C.Forms
{
    public partial class simit_page : TanitimSablon
    {
        #region degiskenler
        private simit_pageCntrl kulcntrl = new simit_pageCntrl();
        #endregion
        #region Constructors
        public simit_page()
        {
            InitializeComponent();
            tabloAdi = "simit_page";
            this.Text =  Gridi_Olustur();   
            Tab_Gizle_Ekle();
            //Doldur();
        }
        private void Tab_Gizle_Ekle()
        {


            tabPage1.Text = this.Text;
            tabPage2.Text = "Ek Bilgiler";

            this.tabControl1.TabPages.Remove(tabPage2);
            //controlNavigator2.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage3);
            //controlNavigator3.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage4);
            //controlNavigator4.NavigatableControl = base.gridControl1;

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
            simit_pageVm k = new simit_pageVm();
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(null);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["id"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            simit_pageVm k = (simit_pageVm)ModelVm;
            kulcntrl.Guncelle(k, k.id);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Yeni_Kayit()
        {
            simit_pageVm k = (simit_pageVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Sil()
        {
            //Form1 frm = new Form1();
            //frm.ShowDialog();
            //return;
            simit_pageVm k = (simit_pageVm)ModelVm;
            kulcntrl.Sil(k.ID,k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yazdir()
        {
        }
        public override void Bul()
        {
        }
        public override void Vazgec()
        { 
        }
        #endregion
    }
}