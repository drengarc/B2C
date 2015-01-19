namespace Prodma.WinForms
{
    partial class YaziciSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YaziciSec));
            this.ISLEM_NEDENLERIlbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.YAZICI_ADItxt = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.KAGIT_SECIMItxt = new DevExpress.XtraEditors.TextEdit();
            this.DIKEY_YATAYlke = new DevExpress.XtraEditors.LookUpEdit();
            this.panelTamam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YAZICI_ADItxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KAGIT_SECIMItxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DIKEY_YATAYlke.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // IPTAL_1btn
            // 
            this.IPTAL_1btn.Location = new System.Drawing.Point(275, 4);
            this.IPTAL_1btn.TabIndex = 1;
            // 
            // TAMAM_1cmd
            // 
            this.TAMAM_1cmd.Location = new System.Drawing.Point(177, 4);
            this.TAMAM_1cmd.TabIndex = 0;
            // 
            // panelTamam
            // 
            this.panelTamam.Location = new System.Drawing.Point(0, 107);
            this.panelTamam.Size = new System.Drawing.Size(364, 30);
            this.panelTamam.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 137);
            this.progressBar1.Size = new System.Drawing.Size(364, 11);
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
            // ISLEM_NEDENLERIlbl
            // 
            this.ISLEM_NEDENLERIlbl.Location = new System.Drawing.Point(7, 39);
            this.ISLEM_NEDENLERIlbl.Name = "ISLEM_NEDENLERIlbl";
            this.ISLEM_NEDENLERIlbl.Size = new System.Drawing.Size(56, 13);
            this.ISLEM_NEDENLERIlbl.TabIndex = 666;
            this.ISLEM_NEDENLERIlbl.Text = "Kağıt Seçimi";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 65);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 666;
            this.labelControl1.Text = "Yatay/ Dikey";
            // 
            // YAZICI_ADItxt
            // 
            this.YAZICI_ADItxt.Location = new System.Drawing.Point(71, 10);
            this.YAZICI_ADItxt.Name = "YAZICI_ADItxt";
            this.YAZICI_ADItxt.Size = new System.Drawing.Size(166, 20);
            this.YAZICI_ADItxt.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 666;
            this.labelControl2.Text = "Yazıcı Seçimi";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(243, 7);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 668;
            this.simpleButton1.Text = "....";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // KAGIT_SECIMItxt
            // 
            this.KAGIT_SECIMItxt.Location = new System.Drawing.Point(71, 36);
            this.KAGIT_SECIMItxt.Name = "KAGIT_SECIMItxt";
            this.KAGIT_SECIMItxt.Size = new System.Drawing.Size(166, 20);
            this.KAGIT_SECIMItxt.TabIndex = 0;
            // 
            // DIKEY_YATAYlke
            // 
            this.DIKEY_YATAYlke.Location = new System.Drawing.Point(71, 62);
            this.DIKEY_YATAYlke.Name = "DIKEY_YATAYlke";
            this.DIKEY_YATAYlke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DIKEY_YATAYlke.Size = new System.Drawing.Size(166, 20);
            this.DIKEY_YATAYlke.TabIndex = 2;
            // 
            // YaziciSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 148);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.YAZICI_ADItxt);
            this.Controls.Add(this.DIKEY_YATAYlke);
            this.Controls.Add(this.KAGIT_SECIMItxt);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.ISLEM_NEDENLERIlbl);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "YaziciSec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Printer Seçimi";
            this.Load += new System.EventHandler(this.FisKurGiris_Load);
            this.Controls.SetChildIndex(this.ISLEM_NEDENLERIlbl, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.KAGIT_SECIMItxt, 0);
            this.Controls.SetChildIndex(this.DIKEY_YATAYlke, 0);
            this.Controls.SetChildIndex(this.YAZICI_ADItxt, 0);
            this.Controls.SetChildIndex(this.simpleButton1, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.panelTamam, 0);
            this.panelTamam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YAZICI_ADItxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KAGIT_SECIMItxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DIKEY_YATAYlke.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl ISLEM_NEDENLERIlbl;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit YAZICI_ADItxt;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.TextEdit KAGIT_SECIMItxt;
        public DevExpress.XtraEditors.LookUpEdit DIKEY_YATAYlke;
    }
}