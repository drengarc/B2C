namespace Prodma.Sistem.Forms
{
    partial class YaziciAyarKopyalama
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YaziciAyarKopyalama));
            this.HEDEF_TARIHlbl = new DevExpress.XtraEditors.LabelControl();
            this.KAYNAK_TARIHlbl = new DevExpress.XtraEditors.LabelControl();
            this.FATURA_AYARlke = new DevExpress.XtraEditors.LookUpEdit();
            this.HEDEF_AYARtxt = new DevExpress.XtraEditors.TextEdit();
            this.panelTamam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FATURA_AYARlke.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HEDEF_AYARtxt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // IPTAL_1btn
            // 
            this.IPTAL_1btn.Location = new System.Drawing.Point(421, 4);
            // 
            // TAMAM_1cmd
            // 
            this.TAMAM_1cmd.Location = new System.Drawing.Point(340, 4);
            // 
            // panelTamam
            // 
            this.panelTamam.Location = new System.Drawing.Point(0, 55);
            this.panelTamam.Size = new System.Drawing.Size(499, 30);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 85);
            this.progressBar1.Size = new System.Drawing.Size(499, 11);
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
            // HEDEF_TARIHlbl
            // 
            this.HEDEF_TARIHlbl.Location = new System.Drawing.Point(6, 34);
            this.HEDEF_TARIHlbl.Name = "HEDEF_TARIHlbl";
            this.HEDEF_TARIHlbl.Size = new System.Drawing.Size(76, 13);
            this.HEDEF_TARIHlbl.TabIndex = 13;
            this.HEDEF_TARIHlbl.Text = "Hedef  Ayar Adı";
            // 
            // KAYNAK_TARIHlbl
            // 
            this.KAYNAK_TARIHlbl.Enabled = false;
            this.KAYNAK_TARIHlbl.Location = new System.Drawing.Point(6, 8);
            this.KAYNAK_TARIHlbl.Name = "KAYNAK_TARIHlbl";
            this.KAYNAK_TARIHlbl.Size = new System.Drawing.Size(61, 13);
            this.KAYNAK_TARIHlbl.TabIndex = 13;
            this.KAYNAK_TARIHlbl.Text = "Kaynak Ayar";
            // 
            // FATURA_AYARlke
            // 
            this.FATURA_AYARlke.Location = new System.Drawing.Point(147, 5);
            this.FATURA_AYARlke.Name = "FATURA_AYARlke";
            this.FATURA_AYARlke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FATURA_AYARlke.Size = new System.Drawing.Size(212, 20);
            this.FATURA_AYARlke.TabIndex = 505;
            // 
            // HEDEF_AYARtxt
            // 
            this.HEDEF_AYARtxt.Location = new System.Drawing.Point(147, 31);
            this.HEDEF_AYARtxt.Name = "HEDEF_AYARtxt";
            this.HEDEF_AYARtxt.Size = new System.Drawing.Size(212, 20);
            this.HEDEF_AYARtxt.TabIndex = 506;
            // 
            // YaziciAyarKopyalama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 96);
            this.Controls.Add(this.HEDEF_AYARtxt);
            this.Controls.Add(this.FATURA_AYARlke);
            this.Controls.Add(this.KAYNAK_TARIHlbl);
            this.Controls.Add(this.HEDEF_TARIHlbl);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "YaziciAyarKopyalama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fiş Tarihi Değiştirme";
            this.Load += new System.EventHandler(this.DovizKurKopyalama_Load);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.panelTamam, 0);
            this.Controls.SetChildIndex(this.HEDEF_TARIHlbl, 0);
            this.Controls.SetChildIndex(this.KAYNAK_TARIHlbl, 0);
            this.Controls.SetChildIndex(this.FATURA_AYARlke, 0);
            this.Controls.SetChildIndex(this.HEDEF_AYARtxt, 0);
            this.panelTamam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FATURA_AYARlke.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HEDEF_AYARtxt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl HEDEF_TARIHlbl;
        private DevExpress.XtraEditors.LabelControl KAYNAK_TARIHlbl;
        private DevExpress.XtraEditors.LookUpEdit FATURA_AYARlke;
        private DevExpress.XtraEditors.TextEdit HEDEF_AYARtxt;


    }
}