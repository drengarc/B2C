namespace WF_tinyMCE
{
    partial class Form1
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
            this.ctlEdit = new System.Windows.Forms.Button();
            this.ctlRtf = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ctlEdit
            // 
            this.ctlEdit.Location = new System.Drawing.Point(97, 161);
            this.ctlEdit.Name = "ctlEdit";
            this.ctlEdit.Size = new System.Drawing.Size(88, 28);
            this.ctlEdit.TabIndex = 0;
            this.ctlEdit.Text = "Edit";
            this.ctlEdit.UseVisualStyleBackColor = true;
            this.ctlEdit.Click += new System.EventHandler(this.ctlEdit_Click);
            // 
            // ctlRtf
            // 
            this.ctlRtf.Location = new System.Drawing.Point(12, 10);
            this.ctlRtf.Name = "ctlRtf";
            this.ctlRtf.Size = new System.Drawing.Size(266, 145);
            this.ctlRtf.TabIndex = 1;
            this.ctlRtf.Text = "tinyMCe intergrated into .NET.\nA bit uncomfortable way through IE.\nBut if you man" +
                "age it good, you can use it for free.\n\nDon\'t forget to press save in MCE toolbar" +
                ".\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 201);
            this.Controls.Add(this.ctlRtf);
            this.Controls.Add(this.ctlEdit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ctlEdit;
        private System.Windows.Forms.RichTextBox ctlRtf;
    }
}

