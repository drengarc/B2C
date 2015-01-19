namespace Prodma.WinForm
{
    partial class TextBoxBuyut
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.IPTALcmd = new System.Windows.Forms.Button();
            this.TAMAMcmd = new System.Windows.Forms.Button();
            this.Yazitxt = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IPTALcmd);
            this.panel1.Controls.Add(this.TAMAMcmd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 53);
            this.panel1.TabIndex = 3;
            // 
            // IPTALcmd
            // 
            this.IPTALcmd.Location = new System.Drawing.Point(92, 18);
            this.IPTALcmd.Name = "IPTALcmd";
            this.IPTALcmd.Size = new System.Drawing.Size(75, 23);
            this.IPTALcmd.TabIndex = 1;
            this.IPTALcmd.Text = "İptal";
            this.IPTALcmd.UseVisualStyleBackColor = true;
            this.IPTALcmd.Click += new System.EventHandler(this.IPTALcmd_Click);
            // 
            // TAMAMcmd
            // 
            this.TAMAMcmd.Location = new System.Drawing.Point(11, 18);
            this.TAMAMcmd.Name = "TAMAMcmd";
            this.TAMAMcmd.Size = new System.Drawing.Size(75, 23);
            this.TAMAMcmd.TabIndex = 1;
            this.TAMAMcmd.Text = "Tamam";
            this.TAMAMcmd.UseVisualStyleBackColor = true;
            this.TAMAMcmd.Click += new System.EventHandler(this.TAMAMcmd_Click_1);
            // 
            // Yazitxt
            // 
            this.Yazitxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Yazitxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Yazitxt.Location = new System.Drawing.Point(0, 0);
            this.Yazitxt.Name = "Yazitxt";
            this.Yazitxt.Size = new System.Drawing.Size(601, 298);
            this.Yazitxt.TabIndex = 4;
            this.Yazitxt.Text = "";
            // 
            // TextBoxBuyut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 351);
            this.Controls.Add(this.Yazitxt);
            this.Controls.Add(this.panel1);
            this.Name = "TextBoxBuyut";
            this.Text = "Bilgi Girişi";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button IPTALcmd;
        private System.Windows.Forms.Button TAMAMcmd;
        private System.Windows.Forms.RichTextBox Yazitxt;

    }
}

