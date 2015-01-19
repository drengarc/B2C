namespace Prodma.Sistem.Forms
{
    partial class TabloEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabloEkle));
            this.TABLOtxt = new DevExpress.XtraEditors.TextEdit();
            this.ALANtxt = new DevExpress.XtraEditors.TextEdit();
            this.TABLOlbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelTamam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TABLOtxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALANtxt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // IPTAL_1btn
            // 
            this.IPTAL_1btn.Location = new System.Drawing.Point(160, 4);
            this.IPTAL_1btn.TabIndex = 1;
            // 
            // TAMAM_1cmd
            // 
            this.TAMAM_1cmd.Location = new System.Drawing.Point(79, 4);
            this.TAMAM_1cmd.TabIndex = 0;
            // 
            // panelTamam
            // 
            this.panelTamam.Location = new System.Drawing.Point(0, 64);
            this.panelTamam.Size = new System.Drawing.Size(238, 30);
            this.panelTamam.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 94);
            this.progressBar1.Size = new System.Drawing.Size(238, 11);
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
            // TABLOtxt
            // 
            this.TABLOtxt.EnterMoveNextControl = true;
            this.TABLOtxt.Location = new System.Drawing.Point(79, 12);
            this.TABLOtxt.Name = "TABLOtxt";
            this.TABLOtxt.Size = new System.Drawing.Size(147, 20);
            this.TABLOtxt.TabIndex = 3;
            // 
            // ALANtxt
            // 
            this.ALANtxt.EnterMoveNextControl = true;
            this.ALANtxt.Location = new System.Drawing.Point(79, 38);
            this.ALANtxt.Name = "ALANtxt";
            this.ALANtxt.Size = new System.Drawing.Size(147, 20);
            this.ALANtxt.TabIndex = 4;
            // 
            // TABLOlbl
            // 
            this.TABLOlbl.Location = new System.Drawing.Point(12, 12);
            this.TABLOlbl.Name = "TABLOlbl";
            this.TABLOlbl.Size = new System.Drawing.Size(44, 13);
            this.TABLOlbl.TabIndex = 507;
            this.TABLOlbl.Text = "Tablo Adı";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 507;
            this.labelControl1.Text = "Alan Adı";
            // 
            // TabloEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 105);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.TABLOlbl);
            this.Controls.Add(this.TABLOtxt);
            this.Controls.Add(this.ALANtxt);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "TabloEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Toplu İrsaliye Silme";
            this.Load += new System.EventHandler(this.TopluIrsaliyeNoDuzenleme_Load);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.panelTamam, 0);
            this.Controls.SetChildIndex(this.ALANtxt, 0);
            this.Controls.SetChildIndex(this.TABLOtxt, 0);
            this.Controls.SetChildIndex(this.TABLOlbl, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.panelTamam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TABLOtxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALANtxt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit TABLOtxt;
        public DevExpress.XtraEditors.TextEdit ALANtxt;
        public DevExpress.XtraEditors.LabelControl TABLOlbl;
        public DevExpress.XtraEditors.LabelControl labelControl1;


    }
}