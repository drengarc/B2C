namespace Prodma.WinForms
{
    partial class TopluGridPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.formNamePanel = new System.Windows.Forms.Panel();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // formNamePanel
            // 
            this.formNamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.formNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formNamePanel.Location = new System.Drawing.Point(0, 0);
            this.formNamePanel.Name = "formNamePanel";
            this.formNamePanel.Size = new System.Drawing.Size(738, 24);
            this.formNamePanel.TabIndex = 0;
            // 
            // gridPanel
            // 
            this.gridPanel.AutoScroll = true;
            this.gridPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(0, 24);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(738, 191);
            this.gridPanel.TabIndex = 1;
            // 
            // TopluGridPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.formNamePanel);
            this.Name = "TopluGridPanel";
            this.Size = new System.Drawing.Size(738, 215);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel formNamePanel;
        private System.Windows.Forms.Panel gridPanel;


    }
}
