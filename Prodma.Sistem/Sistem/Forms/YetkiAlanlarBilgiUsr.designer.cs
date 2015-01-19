namespace Prodma.Sistem.Forms
{
    partial class YetkiAlanlarBilgiUsr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YetkiAlanlarBilgiUsr));
            this.ustAlanlaLe = new DevExpress.XtraEditors.GridLookUpEdit();
            this.kullaniciLe = new DevExpress.XtraEditors.GridLookUpEdit();
            this.alanlarLe = new DevExpress.XtraEditors.GridLookUpEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTamam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ustAlanlaLe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullaniciLe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alanlarLe.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPTAL_1btn
            // 
            this.IPTAL_1btn.Location = new System.Drawing.Point(608, 4);
            // 
            // TAMAM_1cmd
            // 
            this.TAMAM_1cmd.Location = new System.Drawing.Point(527, 4);
            // 
            // panelTamam
            // 
            this.panelTamam.Location = new System.Drawing.Point(0, 250);
            this.panelTamam.Size = new System.Drawing.Size(686, 30);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 280);
            this.progressBar1.Size = new System.Drawing.Size(686, 11);
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
            // ustAlanlaLe
            // 
            this.ustAlanlaLe.Location = new System.Drawing.Point(227, 3);
            this.ustAlanlaLe.Name = "ustAlanlaLe";
            this.ustAlanlaLe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ustAlanlaLe.Size = new System.Drawing.Size(217, 20);
            this.ustAlanlaLe.TabIndex = 1;
            this.ustAlanlaLe.EditValueChanged += new System.EventHandler(this.ustAlanlarLe_EditValueChanged);
            // 
            // kullaniciLe
            // 
            this.kullaniciLe.Location = new System.Drawing.Point(4, 3);
            this.kullaniciLe.Name = "kullaniciLe";
            this.kullaniciLe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.kullaniciLe.Size = new System.Drawing.Size(217, 20);
            this.kullaniciLe.TabIndex = 3;
            // 
            // alanlarLe
            // 
            this.alanlarLe.Location = new System.Drawing.Point(450, 3);
            this.alanlarLe.Name = "alanlarLe";
            this.alanlarLe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.alanlarLe.Size = new System.Drawing.Size(217, 20);
            this.alanlarLe.TabIndex = 2;
            this.alanlarLe.EditValueChanged += new System.EventHandler(this.alanlarLe_EditValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.ustAlanlaLe);
            this.panel2.Controls.Add(this.alanlarLe);
            this.panel2.Controls.Add(this.kullaniciLe);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 28);
            this.panel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 222);
            this.panel1.TabIndex = 7;
            // 
            // YetkiAlanlarBilgiUsr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 291);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "YetkiAlanlarBilgiUsr";
            this.Text = "YetkiAlanlarBilgiUsr";
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.panelTamam, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panelTamam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ustAlanlaLe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullaniciLe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alanlarLe.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit ustAlanlaLe;
        public DevExpress.XtraEditors.GridLookUpEdit kullaniciLe;
        private DevExpress.XtraEditors.GridLookUpEdit alanlarLe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}