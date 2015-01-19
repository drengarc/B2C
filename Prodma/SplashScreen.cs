using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prodma
{
    public partial class SplashScreen : Form
    {
       // private ProgressControl realProgress1;
        public SplashScreen()
        {
            InitializeComponent();
            //this.realProgress1 = new ProgressControl();
            //this.realProgress1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.realProgress1.IsOperationInProgress = false;
            //this.realProgress1.Location = new System.Drawing.Point(0, 0);
            //this.realProgress1.Name = "realProgress1";
            //this.realProgress1.Size = new System.Drawing.Size(556, 120);
            //this.realProgress1.TabIndex = 3;
            //this.realProgress1.Load += new System.EventHandler(this.realProgress1_Load);
            //this.Controls.Add(this.realProgress1);
            //realProgress1.Visible = false;
        }
        private void realProgress1_Load(object sender, EventArgs e)
        {

        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
           // realProgress1.calistir();
        }
    }
}
