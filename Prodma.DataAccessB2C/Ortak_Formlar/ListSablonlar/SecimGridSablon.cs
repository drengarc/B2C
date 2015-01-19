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
    public partial class SecimGridSablon : Sablon
    {
      
        #region Deðiþkenler
        private IContainer components;
        public PanelControl panelUstBilgi;
        public BindingSource bn = new BindingSource();
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        #endregion

        public int gridTip = 0;
        public usrGridIslem usr = new usrGridIslem(GridIslemEn.Bilgilendirme);
        public Dictionary<string, string> inputParametreler = new Dictionary<string, string>();
        public Dictionary<string, string> outputParametreler = new Dictionary<string, string>();
        private Panel panelIslemler;
        private SimpleButton IPTALcmd;
        private SimpleButton TAMAMcmd;
        public SimpleButton TEMIZLEcmd;
        private SimpleButton SECcmd;
        public PanelControl panelGrid;
        public System.Windows.Forms.BindingSource bindingSource1;
        public bool EkranEnterleKapat = true;
        #region formolaylar
        public SecimGridSablon()
        {
            InitializeComponent();
            this.KeyPreview = true;
            eventHandler();
            panelGrid.Controls.Add(usr);
            selection = new GridCheckMarksSelection(usr.gridView1, 0);
            usr.Dock = DockStyle.Fill;
        }
        public SecimGridSablon(int gridTip)
        {
            InitializeComponent();
            eventHandler();
            panelGrid.Controls.Add(usr);
            selection = new GridCheckMarksSelection(usr.gridView1, gridTip);
            usr.Dock = DockStyle.Fill;
        }
        public GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }
        public GridCheckMarksSelection Value
        {
            get
            {
                return selection;
            }

        }
        public virtual void TekSecimMesajAc()
        {

        }
        public virtual void TemizleIslemYap()
        {
            selection.ClearSelection();
        }
        public void SecimGridSablon_Load(object sender, EventArgs e)
        {
          
            usr.hucre_Islemleri_KeyEvents += hucre_Islemleri_KeyEvents;
        }
        public void SecimGridSablon_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (outputParametreler.Count == 0)
            {
                selection = null;
                this.Dispose();
                this.Close();
            }
            //EkranKapatKontrol();
        }
        public virtual void EkranKapatKontrol()
        {

        }
        public void hucre_Islemleri_KeyEvents(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter && EkranEnterleKapat==true) || e.KeyCode==Keys.F10)
            {
                outputParametreler.Clear();
                ParametreSet();
                if (KapatKontrol() == true)
                {
                    this.Dispose();
                    this.Close();
                }
                OnButtonClicked(e);
            }
        }
        private void SecimGridSablon_Shown(object sender, EventArgs e)
        {
            usr.gridControl1.Focus();
        }
        private void eventHandler()
        {
            this.Load += new System.EventHandler(this.SecimGridSablon_Load);
            this.Shown += new System.EventHandler(this.SecimGridSablon_Shown);
            this.TAMAMcmd.Click += new System.EventHandler(this.TAMAMcmd_Click);
            this.TEMIZLEcmd.Click += new System.EventHandler(this.TEMIZLEcmd_Click);
            this.SECcmd.Click += new System.EventHandler(this.SECcmd_Click);
            this.IPTALcmd.Click += new System.EventHandler(this.IPTALcmd_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SecimGridSablon_KeyDown);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SecimGridSablon_Closing);
        }
      
        public void Control_Ayarla_Islemler(Control.ControlCollection Control, Control cntrl)
        {
            
            foreach (Control fc in Control)
            {
                if (fc.GetType() == typeof(System.Windows.Forms.TabControl))
                {
                    Control_Ayarla_Islemler(fc.Controls, cntrl);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.TabPage))
                {
                    Control_Ayarla_Islemler(fc.Controls, cntrl);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
                {
                    Control_Ayarla_Islemler(fc.Controls, cntrl);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    Control_Ayarla_Islemler(fc.Controls, cntrl);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    Control_Ayarla_Islemler(fc.Controls, cntrl);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                {
                    Control_Ayarla_Islemler(fc.Controls, cntrl);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.UserControl))
                {
                    Control_Ayarla_Islemler(fc.Controls, cntrl);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.XtraUserControl))
                {
                    Control_Ayarla_Islemler(fc.Controls, cntrl);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
                {

                    DevExpress.XtraEditors.LabelControl label = fc as DevExpress.XtraEditors.LabelControl;
                    if (label.Tag != null && label.Tag.ToString() == "B") label.Text = "";
                    if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(labelName);
                    }
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Label))
                {
                    Label label = fc as Label;
                    if (label.Tag != null && label.Tag.ToString() == "B") label.Text = "";
                    if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(labelName);
                    }

                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    DevExpress.XtraEditors.LookUpEdit cbo = fc as DevExpress.XtraEditors.LookUpEdit;
                    cbo.Properties.ValueMember = "ID";
                    cbo.Properties.DisplayMember = "AD";
                    cbo.Properties.NullText = "Seçiniz";
                    cbo.Properties.PopulateColumns();
                    cbo.EnterMoveNextControl = true;
                    cbo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                    cbo.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                    if (cbo.Properties.Columns.Count > 0)
                    {
                        cbo.Properties.Columns["ID"].Visible = false;
                    }
                    cbo.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == cbo.Name)
                        {
                            cntrl.Focus();
                        }

                    }
                               }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                {
                    DevExpress.XtraEditors.GridLookUpEdit cbo = fc as DevExpress.XtraEditors.GridLookUpEdit;
                    if (cbo.Tag == null || cbo.Tag.ToString() != "X")
                    {
                        cbo.Properties.ValueMember = "ID";
                        cbo.Properties.DisplayMember = "AD";
                        cbo.Properties.NullText = "Seçiniz";
                        cbo.Properties.View.PopulateColumns();
                        cbo.EnterMoveNextControl = true;
                        cbo.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                        cbo.Properties.View.PopulateColumns(cbo.Properties.DataSource);
                        //if (cbo.Properties.View.RowCount > 0)
                        //{
                            cbo.Properties.View.Columns["AD"].Caption = "AD";
                            cbo.Properties.View.Columns["ID"].Visible = false;
                        //}
                    }
                    cbo.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == cbo.Name)
                        {
                            cntrl.Focus();
                        }

                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                {
                    DevExpress.XtraEditors.TextEdit txt = fc as DevExpress.XtraEditors.TextEdit;
                    txt.EnterMoveNextControl = true;
                    txt.Text = "";
                    if (cntrl != null)
                    {
                        if (cntrl.Name == txt.Name)
                        {
                            cntrl.Focus();
                        }

                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                {
                    DevExpress.XtraEditors.DateEdit dt = fc as DevExpress.XtraEditors.DateEdit;
                    dt.EnterMoveNextControl = true;
                    dt.EditValue = null;
                    if (dt != null)
                    {
                        if (dt.Name == dt.Name)
                        {
                            dt.Focus();
                        }
                    }
                
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                {
                    DevExpress.XtraEditors.CheckEdit chk = fc as DevExpress.XtraEditors.CheckEdit;
                    if (Convert.ToString(chk.Tag) == "F")
                        chk.Visible = false;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckedComboBoxEdit))
                {
                    DevExpress.XtraEditors.CheckedComboBoxEdit cbo = fc as DevExpress.XtraEditors.CheckedComboBoxEdit;
                    cbo.EnterMoveNextControl = true;
                }
            }
            //controlAyarlayaGirdi = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecimGridSablon));
            this.panelUstBilgi = new DevExpress.XtraEditors.PanelControl();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink();
            this.panelIslemler = new System.Windows.Forms.Panel();
            this.IPTALcmd = new DevExpress.XtraEditors.SimpleButton();
            this.TAMAMcmd = new DevExpress.XtraEditors.SimpleButton();
            this.TEMIZLEcmd = new DevExpress.XtraEditors.SimpleButton();
            this.SECcmd = new DevExpress.XtraEditors.SimpleButton();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelUstBilgi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.panelIslemler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
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
            // panelUstBilgi
            // 
            this.panelUstBilgi.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUstBilgi.Location = new System.Drawing.Point(0, 0);
            this.panelUstBilgi.Name = "panelUstBilgi";
            this.panelUstBilgi.Size = new System.Drawing.Size(917, 124);
            this.panelUstBilgi.TabIndex = 2;
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
            // panelIslemler
            // 
            this.panelIslemler.Controls.Add(this.IPTALcmd);
            this.panelIslemler.Controls.Add(this.TAMAMcmd);
            this.panelIslemler.Controls.Add(this.TEMIZLEcmd);
            this.panelIslemler.Controls.Add(this.SECcmd);
            this.panelIslemler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelIslemler.Location = new System.Drawing.Point(0, 449);
            this.panelIslemler.Name = "panelIslemler";
            this.panelIslemler.Size = new System.Drawing.Size(917, 34);
            this.panelIslemler.TabIndex = 7;
            // 
            // IPTALcmd
            // 
            this.IPTALcmd.Location = new System.Drawing.Point(389, 3);
            this.IPTALcmd.Name = "IPTALcmd";
            this.IPTALcmd.Size = new System.Drawing.Size(75, 23);
            this.IPTALcmd.TabIndex = 4;
            this.IPTALcmd.Text = "Ýptal";
            // 
            // TAMAMcmd
            // 
            this.TAMAMcmd.Location = new System.Drawing.Point(294, 3);
            this.TAMAMcmd.Name = "TAMAMcmd";
            this.TAMAMcmd.Size = new System.Drawing.Size(75, 23);
            this.TAMAMcmd.TabIndex = 4;
            this.TAMAMcmd.Text = "Tamam";
            // 
            // TEMIZLEcmd
            // 
            this.TEMIZLEcmd.Location = new System.Drawing.Point(199, 3);
            this.TEMIZLEcmd.Name = "TEMIZLEcmd";
            this.TEMIZLEcmd.Size = new System.Drawing.Size(75, 23);
            this.TEMIZLEcmd.TabIndex = 4;
            this.TEMIZLEcmd.Text = "Temizle";
            this.TEMIZLEcmd.Visible = false;
            // 
            // SECcmd
            // 
            this.SECcmd.Location = new System.Drawing.Point(106, 3);
            this.SECcmd.Name = "SECcmd";
            this.SECcmd.Size = new System.Drawing.Size(75, 23);
            this.SECcmd.TabIndex = 4;
            this.SECcmd.Text = "Tümünü Seç";
            this.SECcmd.Visible = false;
            // 
            // panelGrid
            // 
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 124);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(917, 325);
            this.panelGrid.TabIndex = 8;
            // 
            // SecimGridSablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(917, 483);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelIslemler);
            this.Controls.Add(this.panelUstBilgi);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "SecimGridSablon";
            this.Text = "ListSablon";
            ((System.ComponentModel.ISupportInitialize)(this.panelUstBilgi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.panelIslemler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        public virtual void ParametreSet() { }
        
        public virtual void GridKeyDown(object sender, KeyEventArgs e) {  }
        private void SECcmd_Click(object sender, EventArgs e)
        {
            selection.SelectAll();
        }
        private void TEMIZLEcmd_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Güncelleme iþlemi ilgili satýrlarý silmek demektir, Emin misiniz? ", "", MessageBoxButtons.YesNo);
            Application.DoEvents();
            if (res == DialogResult.Yes)
            {
                res = MessageBox.Show("Emin misiniz? ", "", MessageBoxButtons.YesNo);
                Application.DoEvents();
                if (res == DialogResult.Yes)
                {
                    TemizleIslemYap();
                }
            }            
        }
        private void TAMAMcmd_Click(object sender, EventArgs e)
        {
            outputParametreler.Clear();
            ParametreSet();
            if (KapatKontrol() == true)
            {
              this.Dispose();
              this.Close();
            }
            OnButtonClicked(e);
        }
        private void IPTALcmd_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        public event EventHandler ButtonClick;
        public void OnButtonClicked(EventArgs e)
        {
            if (ButtonClick != null)
            {
                ButtonClick(this, e);
            }
        }

        private void SecimGridSablon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Escape)
            {
               this.Dispose();
               this.Close();
            }
            else
            {
                GridKeyDown(sender, e);
            }
        }
    }
}
