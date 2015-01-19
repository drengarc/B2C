using System;
using System.Drawing;
using System.Collections;
using System.Text.RegularExpressions;
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
using System.Threading;
using Prodma.Sistem.Models;
using System.Collections.Generic;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using Microsoft.Reporting.WinForms;
using Prodma.Sistem.Controllers;
namespace Prodma.WinForms
{
    /// <summary>
    /// Summary description for MDIChild.
    /// </summary>
    /// 
    public partial class ListSablon : Sablon
    {
        #region Deðiþkenler
        public bool gridEkli = true;
        public bool raporEkli = false;
        public int sifirliId = 0;
        public int satirId =0;
        public bool direktYazdir = false;
        public string formName;
      
        int maximum = 100;
        public bool gridiolusturDinamik = false;
        public bool sorguBitti = false;

        public ListSablonOzellikleriVm ListeOzellikleri = new ListSablonOzellikleriVm();
        
        private IContainer components;
        public PanelControl panelControl1;
        public PanelControl panelUserControl;
        public BindingSource[] bn;
        public PanelControl panelControlGrid;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        public LabelControl lblBit;
        public LabelControl lblBas;
        public PanelControl panelControlGridControl;
        public Dictionary<string, string> parametersForm = new Dictionary<string, string>();
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Timer timer1;
        public SimpleButton OZELYAZDIRbtn;
        public SimpleButton TAMAMbtn;
        public SimpleButton IPTALbtn;
        public SimpleButton TAMAMYAZDIRbtn;
        public LookUpEdit DIL_IDlke;
        private LabelControl DIL__IDlbl;
        public usrGridIslem gridControl = new usrGridIslem(GridIslemEn.Bilgilendirme);
        
        #endregion
        #region formolaylar
        public ListSablon()
        {
            InitializeComponent();
            gridControl.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlGridControl.Controls.Add(gridControl);
            eventHandler();
            this.ClientSize = new Size(867, 600);
            this.StartPosition = FormStartPosition.Manual;
        }
        public void ListSablon_Load(object sender, EventArgs e)
        {
            YardimciIslemlerKontrols.InvokeLueContainSet("DIL_ID", DIL_IDlke);
            gridControl.gridView1.OptionsView.ShowGroupPanel = true;
            gridControl.gridView1.GroupPanelText = "Gruplamak Ýstediðiniz Alaný Bu Bölgeye Sürükleyiniz";
            if (yetki != null)
            {
                if (yetki.OKU_E_H == true && yetki.YAZ_E_H == false && yetki.GUNCELLE_E_H == false && yetki.SIL_E_H == false)
                {
                    gridControl.gridView1.OptionsBehavior.Editable = false;
                }
                if (yetki.OKU_E_H == false || yetki.YAZ_E_H == false || yetki.GUNCELLE_E_H == false || yetki.SIL_E_H == false)
                {
                    tamYetki = false;
                }
                else
                {
                    tamYetki = true;
                }
            }
           // if (ListeOzellikleri.modelName == "DinamikListeVm") dinamikListeMi = true;
            YardimciIslemlerKontrols.LueDsDuzenle(DIL_IDlke);
            DIL_IDlke.EditValue = 1;
            IlkDegerleriVer();
        }
        private void ListSablon_Shown(object sender, EventArgs e)
        {
            try
            {
                ActiveControl = (Control)gridControl.gridControl1;
            }
            catch (Exception)
            {
                
            //    throw;
            }
        }
        private void eventHandler()
        {
            this.Load += new System.EventHandler(this.ListSablon_Load);
            this.Shown += new System.EventHandler(this.ListSablon_Shown);
            this.TAMAMbtn.Click += new System.EventHandler(this.TAMAMbtn_Click);
            this.OZELYAZDIRbtn.Click += new System.EventHandler(this.OZELYAZDIRbtn_Click);
            this.IPTALbtn.Click += new System.EventHandler(this.IPTALbtn_Click);
            this.printableComponentLink1.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink1_CreateReportHeaderArea);
            this.printableComponentLink1.Component = gridControl.gridControl1;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListSablon));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.DIL_IDlke = new DevExpress.XtraEditors.LookUpEdit();
            this.DIL__IDlbl = new DevExpress.XtraEditors.LabelControl();
            this.TAMAMYAZDIRbtn = new DevExpress.XtraEditors.SimpleButton();
            this.OZELYAZDIRbtn = new DevExpress.XtraEditors.SimpleButton();
            this.TAMAMbtn = new DevExpress.XtraEditors.SimpleButton();
            this.IPTALbtn = new DevExpress.XtraEditors.SimpleButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblBit = new DevExpress.XtraEditors.LabelControl();
            this.lblBas = new DevExpress.XtraEditors.LabelControl();
            this.panelUserControl = new DevExpress.XtraEditors.PanelControl();
            this.panelControlGrid = new DevExpress.XtraEditors.PanelControl();
            this.panelControlGridControl = new DevExpress.XtraEditors.PanelControl();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DIL_IDlke.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelUserControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrid)).BeginInit();
            this.panelControlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "Printer.ico");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.DIL_IDlke);
            this.panelControl1.Controls.Add(this.DIL__IDlbl);
            this.panelControl1.Controls.Add(this.TAMAMYAZDIRbtn);
            this.panelControl1.Controls.Add(this.OZELYAZDIRbtn);
            this.panelControl1.Controls.Add(this.TAMAMbtn);
            this.panelControl1.Controls.Add(this.IPTALbtn);
            this.panelControl1.Controls.Add(this.progressBar1);
            this.panelControl1.Controls.Add(this.lblBit);
            this.panelControl1.Controls.Add(this.lblBas);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(748, 50);
            this.panelControl1.TabIndex = 1;
            // 
            // DIL_IDlke
            // 
            this.DIL_IDlke.Location = new System.Drawing.Point(307, 11);
            this.DIL_IDlke.Name = "DIL_IDlke";
            this.DIL_IDlke.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.DIL_IDlke.Properties.Appearance.Options.UseBackColor = true;
            this.DIL_IDlke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DIL_IDlke.Size = new System.Drawing.Size(100, 20);
            this.DIL_IDlke.TabIndex = 58;
            // 
            // DIL__IDlbl
            // 
            this.DIL__IDlbl.Location = new System.Drawing.Point(285, 14);
            this.DIL__IDlbl.Name = "DIL__IDlbl";
            this.DIL__IDlbl.Size = new System.Drawing.Size(16, 13);
            this.DIL__IDlbl.TabIndex = 57;
            this.DIL__IDlbl.Text = "DÝL";
            // 
            // TAMAMYAZDIRbtn
            // 
            this.TAMAMYAZDIRbtn.Location = new System.Drawing.Point(169, 8);
            this.TAMAMYAZDIRbtn.Name = "TAMAMYAZDIRbtn";
            this.TAMAMYAZDIRbtn.Size = new System.Drawing.Size(73, 23);
            this.TAMAMYAZDIRbtn.TabIndex = 56;
            this.TAMAMYAZDIRbtn.Text = "LIS./YAZDIR";
            this.TAMAMYAZDIRbtn.Click += new System.EventHandler(this.TAMAMYAZDIRbtn_Click);
            // 
            // OZELYAZDIRbtn
            // 
            this.OZELYAZDIRbtn.Location = new System.Drawing.Point(114, 8);
            this.OZELYAZDIRbtn.Name = "OZELYAZDIRbtn";
            this.OZELYAZDIRbtn.Size = new System.Drawing.Size(49, 23);
            this.OZELYAZDIRbtn.TabIndex = 56;
            this.OZELYAZDIRbtn.Text = "YAZDIR";
            // 
            // TAMAMbtn
            // 
            this.TAMAMbtn.Location = new System.Drawing.Point(10, 8);
            this.TAMAMbtn.Name = "TAMAMbtn";
            this.TAMAMbtn.Size = new System.Drawing.Size(47, 23);
            this.TAMAMbtn.TabIndex = 53;
            this.TAMAMbtn.Text = "TAMAM";
            // 
            // IPTALbtn
            // 
            this.IPTALbtn.Location = new System.Drawing.Point(63, 8);
            this.IPTALbtn.Name = "IPTALbtn";
            this.IPTALbtn.Size = new System.Drawing.Size(45, 23);
            this.IPTALbtn.TabIndex = 55;
            this.IPTALbtn.Text = "ÝPTAL";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(2, 37);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(744, 11);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 48;
            // 
            // lblBit
            // 
            this.lblBit.Location = new System.Drawing.Point(10, 18);
            this.lblBit.Name = "lblBit";
            this.lblBit.Size = new System.Drawing.Size(0, 13);
            this.lblBit.TabIndex = 32;
            this.lblBit.Visible = false;
            // 
            // lblBas
            // 
            this.lblBas.Location = new System.Drawing.Point(10, 2);
            this.lblBas.Name = "lblBas";
            this.lblBas.Size = new System.Drawing.Size(0, 13);
            this.lblBas.TabIndex = 31;
            this.lblBas.Visible = false;
            // 
            // panelUserControl
            // 
            this.panelUserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUserControl.Location = new System.Drawing.Point(0, 0);
            this.panelUserControl.Name = "panelUserControl";
            this.panelUserControl.Size = new System.Drawing.Size(752, 102);
            this.panelUserControl.TabIndex = 2;
            // 
            // panelControlGrid
            // 
            this.panelControlGrid.Controls.Add(this.panelControlGridControl);
            this.panelControlGrid.Controls.Add(this.panelControl1);
            this.panelControlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlGrid.Location = new System.Drawing.Point(0, 102);
            this.panelControlGrid.Name = "panelControlGrid";
            this.panelControlGrid.Size = new System.Drawing.Size(752, 345);
            this.panelControlGrid.TabIndex = 3;
            // 
            // panelControlGridControl
            // 
            this.panelControlGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlGridControl.Location = new System.Drawing.Point(2, 52);
            this.panelControlGridControl.Name = "panelControlGridControl";
            this.panelControlGridControl.Size = new System.Drawing.Size(748, 291);
            this.panelControlGridControl.TabIndex = 33;
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            // 
            // 
            // 
            this.printableComponentLink1.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageCollection.ImageStream")));
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ListSablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(752, 447);
            this.Controls.Add(this.panelControlGrid);
            this.Controls.Add(this.panelUserControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ListSablon";
            this.Text = "ListSablon";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DIL_IDlke.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelUserControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrid)).EndInit();
            this.panelControlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        #region virtuals
        public virtual void TabPage_Index_Changed(int index) { }
        public virtual void Tamam() { }
        public virtual void OzelYazdir() { }
        public virtual void TamamTum() { }
        public virtual void ParametreSet() { }
        public virtual void FilterParametreSet() { }
        public virtual void ReportParameterSet() { }
        public virtual void IlkDegerleriVer() { }
        public virtual void SeriKayit() { }
        public virtual void SetFilter(){ }
        #endregion
        #region override edilenler
        private void TAMAMbtn_Click(object sender, EventArgs e)
        {
            Listele();
        }
        private void TAMAMYAZDIRbtn_Click(object sender, EventArgs e)
        {
            direktYazdir = true;
            ParametreSet();
            ReportParameterSet();
            Goster();
        }
        public void Goster()
        {
                timer1.Enabled = true;
                progressBar1.Value = 0;
                progressBar1.Maximum = maximum;
                progressBar1.Step = 1;
                timer1.Enabled = true;
                lblBas.Text = DateTime.Now.ToString();
                Thread t = new Thread(Tamam);
                t.Start();
                Thread.Sleep(15);
        }
        public void griddoldur()
        {
            if (gridEkli == false)
            {
                this.panelControlGridControl.Controls.Remove(gridControl);
                gridEkli = true;
            }
            gridControl.gridControl1.DataSource = bn;
            lblBit.Text = DateTime.Now.ToString();       
            timer1.Enabled = false;
            gridControl.gridView1.BestFitColumns();
        }
        private void printableComponentLink1_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            string d = gridControl.gridView1.FilterPanelText;
            DevExpress.XtraPrinting.TextBrick brick;
            brick = e.Graph.DrawString(this.Text, Color.Navy, new RectangleF(0, 0, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Tahoma", 8);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
            DevExpress.XtraPrinting.TextBrick brick1;
            brick1 = e.Graph.DrawString(gridControl.gridView1.FilterPanelText, Color.Navy, new RectangleF(0, 30, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick1.Font = new Font("Tahoma", 8);
            brick1.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }
        private void OZELYAZDIRbtn_Click(object sender, EventArgs e)
        {
            OzelYazdir();
        }
        private void IPTALbtn_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
            this.Close(); 
        }
        #endregion
        void Listele()
        {
            butonlariIsle(false); 
            maximum = 300;
            gridControl.gridView1.Columns.Clear();
            ParametreSet();
            ReportParameterSet();
            ListHelper.Grid_Olustur(ListeOzellikleri.modelPath, ListeOzellikleri.modelName, "Prodma.DataAccess", gridControl.gridView1, ListeOzellikleri.toplamAlanlari, null);
            Goster();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if (sorguBitti == true)
            {
                if (direktYazdir == true)
                {
                    OzelYazdir();
                }
                else
                {
                    griddoldur();
                }
                progressBar1.Value = 0;
                butonlariIsle(true);
                return;
            }
            else if (progressBar1.Value == maximum)
            {
                progressBar1.Value = 0;
            }
        }
        void butonlariIsle(bool deger)
        {
            TAMAMbtn.Enabled =deger;
            IPTALbtn.Enabled = deger;
            OZELYAZDIRbtn.Enabled = deger;
        }
    }
}
