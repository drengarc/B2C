namespace Prodma.WinForms
{
    partial class DynamicUpdateWarning
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
            this.nextBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.warningLbl = new DevExpress.XtraEditors.LabelControl();
            this.warningLbl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(318, 111);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 0;
            this.nextBtn.Text = "İleri";
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(399, 111);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "İptal";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // warningLbl
            // 
            this.warningLbl.Location = new System.Drawing.Point(87, 36);
            this.warningLbl.Name = "warningLbl";
            this.warningLbl.Size = new System.Drawing.Size(372, 13);
            this.warningLbl.TabIndex = 2;
            this.warningLbl.Text = "Seri kayıt işlemi ekranda listelenen tüm kayıtları değiştirmek için tasarlanmıştı" +
                "r. ";
            // 
            // warningLbl2
            // 
            this.warningLbl2.Location = new System.Drawing.Point(87, 55);
            this.warningLbl2.Name = "warningLbl2";
            this.warningLbl2.Size = new System.Drawing.Size(349, 13);
            this.warningLbl2.TabIndex = 3;
            this.warningLbl2.Text = "Devam Etmek için \"İleri\" butonuna vazgeçmek için \"İptal\" butonuna basın.";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Prodma.DataAccessB2C.Resource1.warning;
            this.pictureEdit1.Location = new System.Drawing.Point(16, 32);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(45, 41);
            this.pictureEdit1.TabIndex = 4;
            // 
            // DynamicUpdateWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 155);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.warningLbl2);
            this.Controls.Add(this.warningLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.nextBtn);
            this.Name = "DynamicUpdateWarning";
            this.Text = "DynamicUpdateWarning";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton nextBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.LabelControl warningLbl;
        private DevExpress.XtraEditors.LabelControl warningLbl2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}