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
namespace Prodma.WinForms
{
    /// <summary>
    /// Summary description for MDIChild.
    /// </summary>
    /// 
    public partial class DynamicUpdateSablon : Sablon
    {
      
        #region Deðiþkenler
        public int index;
        private IContainer components;
        public PanelControl panelControl1;
        public SimpleButton IPTALbtn;
        public SimpleButton TAMAMbtn;
        public PanelControl panelControl2;
        public BindingSource bn = new BindingSource();
        public DevExpress.XtraTab.XtraTabControl tbControl;
        public DevExpress.XtraTab.XtraTabPage tbGenel;
        public DevExpress.XtraTab.XtraTabPage tbKodlar;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage7;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage8;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage9;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage10;
        public PanelControl panelControlGrid;
        public GridControl gridControl1;
        public GridView gridView1;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        public LabelControl lblBilgi;
        public LabelControl lblBit;
        public LabelControl lblBas;
        public SimpleButton KaydetBtn;
        public CheckedComboBoxEdit gridViewColumnschl;
        public Dictionary<string, string> parametersForm = new Dictionary<string, string>();
        public Dictionary<string, string> gridViewColumns = new Dictionary<string, string>();

        #endregion
        #region formolaylar
        public DynamicUpdateSablon()
        {
            InitializeComponent();
            panelControlGrid.AutoScroll = true;
            this.tbControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tbControl_SelectedIndexChanged);
            
        }
        public void ListSablon_Load(object sender, EventArgs e)
        {
           // gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.GroupPanelText = "Gruplamak Ýstediðiniz Alaný Bu Bölgeye Sürükleyiniz";
            if (yetki != null)
            {
                if (yetki.OKU_E_H == true && yetki.YAZ_E_H == false && yetki.GUNCELLE_E_H == false && yetki.SIL_E_H == false)
                {
                    gridView1.OptionsBehavior.Editable = false;
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
        }
        private void ListSablon_Shown(object sender, EventArgs e)
        {
            try
            {
                ActiveControl = (Control)this.gridControl1;
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
            this.printableComponentLink1.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink1_CreateReportHeaderArea);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DynamicUpdateSablon));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridViewColumnschl = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.KaydetBtn = new DevExpress.XtraEditors.SimpleButton();
            this.lblBit = new DevExpress.XtraEditors.LabelControl();
            this.lblBas = new DevExpress.XtraEditors.LabelControl();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.IPTALbtn = new DevExpress.XtraEditors.SimpleButton();
            this.TAMAMbtn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tbControl = new DevExpress.XtraTab.XtraTabControl();
            this.tbGenel = new DevExpress.XtraTab.XtraTabPage();
            this.tbKodlar = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage7 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage8 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage9 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage10 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewColumnschl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbControl)).BeginInit();
            this.tbControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrid)).BeginInit();
            this.panelControlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "teklif.png");
            this.imageList1.Images.SetKeyName(1, "siparis.png");
            this.imageList1.Images.SetKeyName(2, "irsaliye.png");
            this.imageList1.Images.SetKeyName(3, "muhasebe.png");
            this.imageList1.Images.SetKeyName(4, "sistem.png");
            this.imageList1.Images.SetKeyName(5, "Altec Lansing ACS-48.ico");
            this.imageList1.Images.SetKeyName(6, "115.png");
            this.imageList1.Images.SetKeyName(7, "documents_gear.png");
            this.imageList1.Images.SetKeyName(8, "NeXT MS-DOS Batch File.ico");
            this.imageList1.Images.SetKeyName(9, "windows.png");
            this.imageList1.Images.SetKeyName(10, "Printer.ico");
            this.imageList1.Images.SetKeyName(11, "images.jpg");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridViewColumnschl);
            this.panelControl1.Controls.Add(this.KaydetBtn);
            this.panelControl1.Controls.Add(this.lblBit);
            this.panelControl1.Controls.Add(this.lblBas);
            this.panelControl1.Controls.Add(this.lblBilgi);
            this.panelControl1.Controls.Add(this.IPTALbtn);
            this.panelControl1.Controls.Add(this.TAMAMbtn);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(913, 36);
            this.panelControl1.TabIndex = 1;
            // 
            // gridViewColumnschl
            // 
            this.gridViewColumnschl.Location = new System.Drawing.Point(469, 7);
            this.gridViewColumnschl.Name = "gridViewColumnschl";
            this.gridViewColumnschl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridViewColumnschl.Properties.NullText = "[EditValue is null]";
            this.gridViewColumnschl.Size = new System.Drawing.Size(166, 20);
            this.gridViewColumnschl.TabIndex = 34;
            this.gridViewColumnschl.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.gridViewColumnschl_Closed);
            // 
            // KaydetBtn
            // 
            this.KaydetBtn.Location = new System.Drawing.Point(375, 7);
            this.KaydetBtn.Name = "KaydetBtn";
            this.KaydetBtn.Size = new System.Drawing.Size(75, 23);
            this.KaydetBtn.TabIndex = 33;
            this.KaydetBtn.Text = "KAYDET";
            this.KaydetBtn.Click += new System.EventHandler(this.KaydetBtn_Click);
            // 
            // lblBit
            // 
            this.lblBit.Location = new System.Drawing.Point(10, 18);
            this.lblBit.Name = "lblBit";
            this.lblBit.Size = new System.Drawing.Size(63, 13);
            this.lblBit.TabIndex = 32;
            this.lblBit.Text = "labelControl2";
            // 
            // lblBas
            // 
            this.lblBas.Location = new System.Drawing.Point(10, 2);
            this.lblBas.Name = "lblBas";
            this.lblBas.Size = new System.Drawing.Size(63, 13);
            this.lblBas.TabIndex = 31;
            this.lblBas.Text = "labelControl1";
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lblBilgi.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblBilgi.Appearance.Options.UseFont = true;
            this.lblBilgi.Appearance.Options.UseForeColor = true;
            this.lblBilgi.Location = new System.Drawing.Point(560, 7);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(0, 17);
            this.lblBilgi.TabIndex = 30;
            // 
            // IPTALbtn
            // 
            this.IPTALbtn.Location = new System.Drawing.Point(294, 7);
            this.IPTALbtn.Name = "IPTALbtn";
            this.IPTALbtn.Size = new System.Drawing.Size(75, 23);
            this.IPTALbtn.TabIndex = 27;
            this.IPTALbtn.Text = "ÝPTAL";
            this.IPTALbtn.Click += new System.EventHandler(this.IPTALbtn_Click_1);
            // 
            // TAMAMbtn
            // 
            this.TAMAMbtn.Location = new System.Drawing.Point(213, 7);
            this.TAMAMbtn.Name = "TAMAMbtn";
            this.TAMAMbtn.Size = new System.Drawing.Size(75, 23);
            this.TAMAMbtn.TabIndex = 26;
            this.TAMAMbtn.Text = "TAMAM";
            this.TAMAMbtn.Click += new System.EventHandler(this.TAMAMbtn_Click_1);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tbControl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(917, 200);
            this.panelControl2.TabIndex = 2;
            // 
            // tbControl
            // 
            this.tbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControl.Location = new System.Drawing.Point(2, 2);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedTabPage = this.tbGenel;
            this.tbControl.Size = new System.Drawing.Size(913, 196);
            this.tbControl.TabIndex = 1;
            this.tbControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tbGenel,
            this.tbKodlar,
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage5,
            this.xtraTabPage6,
            this.xtraTabPage7,
            this.xtraTabPage8,
            this.xtraTabPage9,
            this.xtraTabPage10});
            // 
            // tbGenel
            // 
            this.tbGenel.Name = "tbGenel";
            this.tbGenel.Size = new System.Drawing.Size(905, 167);
            this.tbGenel.Text = "Genel";
            // 
            // tbKodlar
            // 
            this.tbKodlar.Name = "tbKodlar";
            this.tbKodlar.Size = new System.Drawing.Size(905, 167);
            this.tbKodlar.Text = "Gruplar";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(905, 167);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(905, 167);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(905, 167);
            this.xtraTabPage3.Text = "xtraTabPage3";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(905, 167);
            this.xtraTabPage4.Text = "xtraTabPage4";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(905, 167);
            this.xtraTabPage5.Text = "xtraTabPage5";
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(905, 167);
            this.xtraTabPage6.Text = "xtraTabPage6";
            // 
            // xtraTabPage7
            // 
            this.xtraTabPage7.Name = "xtraTabPage7";
            this.xtraTabPage7.Size = new System.Drawing.Size(905, 167);
            this.xtraTabPage7.Text = "xtraTabPage7";
            // 
            // xtraTabPage8
            // 
            this.xtraTabPage8.Name = "xtraTabPage8";
            this.xtraTabPage8.Size = new System.Drawing.Size(905, 167);
            this.xtraTabPage8.Text = "xtraTabPage8";
            // 
            // xtraTabPage9
            // 
            this.xtraTabPage9.Name = "xtraTabPage9";
            this.xtraTabPage9.Size = new System.Drawing.Size(905, 167);
            this.xtraTabPage9.Text = "xtraTabPage9";
            // 
            // xtraTabPage10
            // 
            this.xtraTabPage10.Name = "xtraTabPage10";
            this.xtraTabPage10.Size = new System.Drawing.Size(905, 167);
            this.xtraTabPage10.Text = "xtraTabPage10";
            // 
            // panelControlGrid
            // 
            this.panelControlGrid.Controls.Add(this.gridControl1);
            this.panelControlGrid.Controls.Add(this.panelControl1);
            this.panelControlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlGrid.Location = new System.Drawing.Point(0, 200);
            this.panelControlGrid.Name = "panelControlGrid";
            this.panelControlGrid.Size = new System.Drawing.Size(917, 283);
            this.panelControlGrid.TabIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(2, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(913, 283);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.gridControl1;
            // 
            // 
            // 
            this.printableComponentLink1.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageCollection.ImageStream")));
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // DynamicUpdateSablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(917, 483);
            this.Controls.Add(this.panelControlGrid);
            this.Controls.Add(this.panelControl2);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "DynamicUpdateSablon";
            this.Text = "ListSablon";
            this.Load += new System.EventHandler(this.DynamicUpdateSablon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewColumnschl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbControl)).EndInit();
            this.tbControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrid)).EndInit();
            this.panelControlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        #region virtuals
        public virtual void Tamam() { }
        public virtual void Doldur() { }
        #endregion

        #region override edilenler
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


        public void GridViewCheckedComboBoxLoad()
        {
            gridViewColumnschl.Properties.Items.Clear();
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in this.gridView1.Columns)
            {

                gridViewColumnschl.Properties.Items.Add(item.FieldName.ToString(),item.Visible == true ? CheckState.Checked : CheckState.Unchecked, true);
            }

        }
        public virtual void TAMAMbtn_Click_1(object sender, EventArgs e)
        {
            Doldur();            
        }

        public virtual void IPTALbtn_Click_1(object sender, EventArgs e)
        {

        }

        public virtual void DynamicUpdateSablon_Load(object sender, EventArgs e)
        {
        }
        public void tbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = tbControl.SelectedTabPageIndex;
        }
        public virtual void SeriKayit()
        {
 
        }

        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            DynamicUpdateWarning warning = new DynamicUpdateWarning();
            warning.ShowDialog();
            if(warning.saveFlag == true)
                SeriKayit();
        }

        private void gridViewColumnschl_Closed(object sender, ClosedEventArgs e)
        {
            foreach (CheckedListBoxItem item in gridViewColumnschl.Properties.Items)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView1.Columns)
                {
                    if (column.FieldName.ToString() == item.Value.ToString())
                    {
                        if (item.CheckState == CheckState.Checked)
                        {
                            column.Visible = true;
                        }
                        else
                        {
                            column.Visible = false;
                        }

                        break;
                    }
                    
                }                

            }
        }


  

        
    }
}
