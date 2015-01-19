using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Prodma.WinForms
{
    public partial class SplashScreenForm : Sablon
    {
        private ProgressControl realProgress1;
        public DateTime gosterilmeZamani;
        public int gosterilmeCount = 0;
        public bool gosterildi = false;
        public SplashScreenForm()
        {
            InitializeComponent();
            
            this.labelControl1.Text = "Kullanıcı Ve Firma Bilgileri Oluşturuluyor"; //Globals.rman.GetString("AcilisUyarisi1");
            this.labelControl2.Text = "     Lütfen Bekleyiniz!!!.";// Globals.rman.GetString("AcilisUyarisi2");
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

         
        public void mesajSet(string mesaj1, string mesaj2)
        {
            this.labelControl1.Text = mesaj1;
            this.labelControl2.Text = mesaj2;
        }
        private void realProgress1_Load(object sender, EventArgs e)
        {

        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {

            //timer1.Start();
            timer1.Enabled = false;
            //timer1.Interval = 3;
            //Thread t = new Thread(realProgress1.calistir);
            //t.Start();
            //Thread.Sleep(10);
           // realProgress1.calistir();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.labelControl1.Text.Trim() == "")
            {
                this.labelControl1.Text = "Kullanıcı Ve Firma Bilgileri Oluşturuluyor, Yetkiler Tanımlanıyor."; //Globals.rman.GetString("AcilisUyarisi1");
                this.labelControl2.Text = "Lütfen Bekleyiniz!!!.";// Globals.rman.GetString("AcilisUyarisi2");
            }
            else
            {
                this.labelControl1.Text = ""; //Globals.rman.GetString("AcilisUyarisi1");
                this.labelControl2.Text = ""; //Globals.rman.GetString("AcilisUyarisi1");
            }
        }

        public void mesajSet(string[] mesaj)
        {
            throw new NotImplementedException();
        }
    }
}
