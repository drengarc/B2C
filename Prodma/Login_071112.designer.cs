namespace Prodma
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNot = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtKullanici = new DevExpress.XtraEditors.TextEdit();
            this.CALISMA_YILItxt = new DevExpress.XtraEditors.TextEdit();
            this.SIRKETgle = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CALISMA_YILIlbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SIRKETlbl = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.IPtxt1 = new DevExpress.XtraEditors.TextEdit();
            this.YILtxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Dbtxt = new System.Windows.Forms.TextBox();
            this.IPtxt = new System.Windows.Forms.TextBox();
            this.cmdGiris = new System.Windows.Forms.Button();
            this.cmdIptal = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullanici.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CALISMA_YILItxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SIRKETgle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IPtxt1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "KULLANICI ADI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ŞİFRE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = ":";
            // 
            // lblNot
            // 
            this.lblNot.AutoSize = true;
            this.lblNot.Location = new System.Drawing.Point(12, 82);
            this.lblNot.Name = "lblNot";
            this.lblNot.Size = new System.Drawing.Size(0, 13);
            this.lblNot.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(12, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(353, 150);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.txtSifre);
            this.tabPage1.Controls.Add(this.txtKullanici);
            this.tabPage1.Controls.Add(this.CALISMA_YILItxt);
            this.tabPage1.Controls.Add(this.SIRKETgle);
            this.tabPage1.Controls.Add(this.CALISMA_YILIlbl);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.SIRKETlbl);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(345, 124);
            this.tabPage1.TabIndex = 100;
            this.tabPage1.Text = "Kullanıcı İşlemleri";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(120, 84);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(147, 20);
            this.txtSifre.TabIndex = 3;
            this.txtSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSifre_KeyDown);
            // 
            // txtKullanici
            // 
            this.txtKullanici.Location = new System.Drawing.Point(120, 58);
            this.txtKullanici.Name = "txtKullanici";
            this.txtKullanici.Size = new System.Drawing.Size(147, 20);
            this.txtKullanici.TabIndex = 2;
            // 
            // CALISMA_YILItxt
            // 
            this.CALISMA_YILItxt.Location = new System.Drawing.Point(120, 32);
            this.CALISMA_YILItxt.Name = "CALISMA_YILItxt";
            this.CALISMA_YILItxt.Size = new System.Drawing.Size(147, 20);
            this.CALISMA_YILItxt.TabIndex = 1;
            // 
            // SIRKETgle
            // 
            this.SIRKETgle.Location = new System.Drawing.Point(120, 6);
            this.SIRKETgle.Name = "SIRKETgle";
            this.SIRKETgle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SIRKETgle.Properties.View = this.gridView3;
            this.SIRKETgle.Size = new System.Drawing.Size(151, 20);
            this.SIRKETgle.TabIndex = 0;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // CALISMA_YILIlbl
            // 
            this.CALISMA_YILIlbl.AutoSize = true;
            this.CALISMA_YILIlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CALISMA_YILIlbl.Location = new System.Drawing.Point(6, 35);
            this.CALISMA_YILIlbl.Name = "CALISMA_YILIlbl";
            this.CALISMA_YILIlbl.Size = new System.Drawing.Size(87, 13);
            this.CALISMA_YILIlbl.TabIndex = 31;
            this.CALISMA_YILIlbl.Text = "ÇALIŞMA YILI";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = ":";
            // 
            // SIRKETlbl
            // 
            this.SIRKETlbl.AutoSize = true;
            this.SIRKETlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SIRKETlbl.Location = new System.Drawing.Point(6, 9);
            this.SIRKETlbl.Name = "SIRKETlbl";
            this.SIRKETlbl.Size = new System.Drawing.Size(52, 13);
            this.SIRKETlbl.TabIndex = 29;
            this.SIRKETlbl.Text = "ŞİRKET";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.IPtxt1);
            this.tabPage2.Controls.Add(this.YILtxt);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.Dbtxt);
            this.tabPage2.Controls.Add(this.IPtxt);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(345, 124);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Firmaİşlemleri";
            // 
            // IPtxt1
            // 
            this.IPtxt1.Location = new System.Drawing.Point(192, 95);
            this.IPtxt1.Name = "IPtxt1";
            this.IPtxt1.Size = new System.Drawing.Size(147, 20);
            this.IPtxt1.TabIndex = 35;
            this.IPtxt1.Visible = false;
            // 
            // YILtxt
            // 
            this.YILtxt.Location = new System.Drawing.Point(109, 98);
            this.YILtxt.Name = "YILtxt";
            this.YILtxt.Size = new System.Drawing.Size(81, 20);
            this.YILtxt.TabIndex = 8;
            this.YILtxt.Text = "2012";
            this.YILtxt.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "DATABASE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "SERVER";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "ÇALIŞMA YILI";
            this.label8.Visible = false;
            // 
            // Dbtxt
            // 
            this.Dbtxt.Location = new System.Drawing.Point(109, 52);
            this.Dbtxt.Name = "Dbtxt";
            this.Dbtxt.PasswordChar = '*';
            this.Dbtxt.Size = new System.Drawing.Size(159, 20);
            this.Dbtxt.TabIndex = 7;
            this.Dbtxt.Text = "TIC";
            this.Dbtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dbtxt_KeyDown);
            // 
            // IPtxt
            // 
            this.IPtxt.Location = new System.Drawing.Point(109, 26);
            this.IPtxt.Name = "IPtxt";
            this.IPtxt.PasswordChar = '*';
            this.IPtxt.Size = new System.Drawing.Size(159, 20);
            this.IPtxt.TabIndex = 7;
            this.IPtxt.Text = "192.168.0.2";
            this.IPtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IPtxt_KeyDown);
            // 
            // cmdGiris
            // 
            this.cmdGiris.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGiris.Image = ((System.Drawing.Image)(resources.GetObject("cmdGiris.Image")));
            this.cmdGiris.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdGiris.Location = new System.Drawing.Point(224, 169);
            this.cmdGiris.Name = "cmdGiris";
            this.cmdGiris.Size = new System.Drawing.Size(63, 52);
            this.cmdGiris.TabIndex = 2;
            this.cmdGiris.Text = "TAMAM";
            this.cmdGiris.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdGiris.UseVisualStyleBackColor = true;
            this.cmdGiris.Click += new System.EventHandler(this.cmdGiris_Click);
            // 
            // cmdIptal
            // 
            this.cmdIptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdIptal.Image = ((System.Drawing.Image)(resources.GetObject("cmdIptal.Image")));
            this.cmdIptal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdIptal.Location = new System.Drawing.Point(293, 169);
            this.cmdIptal.Name = "cmdIptal";
            this.cmdIptal.Size = new System.Drawing.Size(63, 52);
            this.cmdIptal.TabIndex = 3;
            this.cmdIptal.Text = "İPTAL";
            this.cmdIptal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdIptal.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 226);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(368, 11);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 49;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 237);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cmdGiris);
            this.Controls.Add(this.cmdIptal);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblNot);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "login";
            this.Text = "PRODMA ERP  GİRİŞ";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Login_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullanici.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CALISMA_YILItxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SIRKETgle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IPtxt1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNot;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox YILtxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox IPtxt;
        internal System.Windows.Forms.Button cmdGiris;
        internal System.Windows.Forms.Button cmdIptal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Dbtxt;
        private System.Windows.Forms.Label CALISMA_YILIlbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label SIRKETlbl;
        public DevExpress.XtraEditors.GridLookUpEdit SIRKETgle;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.TextEdit txtKullanici;
        private DevExpress.XtraEditors.TextEdit CALISMA_YILItxt;
        private DevExpress.XtraEditors.TextEdit IPtxt1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

