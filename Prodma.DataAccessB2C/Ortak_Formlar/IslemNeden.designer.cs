namespace Prodma.WinForms
{
    partial class IslemNeden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IslemNeden));
            this.ISLEM_NEDENLERIlbl = new DevExpress.XtraEditors.LabelControl();
            this.ISLEM_NEDENLERIlke = new DevExpress.XtraEditors.LookUpEdit();
            this.panelTamam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ISLEM_NEDENLERIlke.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // IPTAL_1btn
            // 
            this.IPTAL_1btn.Location = new System.Drawing.Point(163, 4);
            this.IPTAL_1btn.TabIndex = 1;
            // 
            // TAMAM_1cmd
            // 
            this.TAMAM_1cmd.Location = new System.Drawing.Point(65, 4);
            this.TAMAM_1cmd.TabIndex = 0;
            // 
            // panelTamam
            // 
            this.panelTamam.Location = new System.Drawing.Point(0, 47);
            this.panelTamam.Size = new System.Drawing.Size(252, 30);
            this.panelTamam.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 77);
            this.progressBar1.Size = new System.Drawing.Size(252, 11);
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
            this.ISLEM_NEDENLERIlbl.Location = new System.Drawing.Point(8, 10);
            this.ISLEM_NEDENLERIlbl.Name = "ISLEM_NEDENLERIlbl";
            this.ISLEM_NEDENLERIlbl.Size = new System.Drawing.Size(58, 13);
            this.ISLEM_NEDENLERIlbl.TabIndex = 666;
            this.ISLEM_NEDENLERIlbl.Text = "İptal Nedeni";
            // 
            // ISLEM_NEDENLERIlke
            // 
            this.ISLEM_NEDENLERIlke.Location = new System.Drawing.Point(72, 7);
            this.ISLEM_NEDENLERIlke.Name = "ISLEM_NEDENLERIlke";
            this.ISLEM_NEDENLERIlke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ISLEM_NEDENLERIlke.Size = new System.Drawing.Size(166, 20);
            this.ISLEM_NEDENLERIlke.TabIndex = 5;
            //this.ISLEM_NEDENLERIlke.EditValueChanged += new System.EventHandler(this.SATIS_DOVIZ_KUR_TIPlke_EditValueChanged);
            // 
            // FisSilmeNeden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 88);
            this.Controls.Add(this.ISLEM_NEDENLERIlke);
            this.Controls.Add(this.ISLEM_NEDENLERIlbl);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "FisSilmeNeden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fiş Kur Giriş";
            this.Load += new System.EventHandler(this.FisKurGiris_Load);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.panelTamam, 0);
            this.Controls.SetChildIndex(this.ISLEM_NEDENLERIlbl, 0);
            this.Controls.SetChildIndex(this.ISLEM_NEDENLERIlke, 0);
            this.panelTamam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ISLEM_NEDENLERIlke.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl ISLEM_NEDENLERIlbl;
        private DevExpress.XtraEditors.LookUpEdit ISLEM_NEDENLERIlke;
    }
}