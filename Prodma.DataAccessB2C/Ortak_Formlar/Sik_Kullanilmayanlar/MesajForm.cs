using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;
using Prodma.DataAccessB2C;

namespace Prodma.WinForms
{
    public partial class MesajForm : Sablon
    {
        public DateTime gosterilmeZamani;
        public int gosterilmeCount = 0;
        public bool gosterildi = false;
        public int mesajId = 0;
        public MesajForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }
        public void mesajSet(string[] mesaj1)
        {
            mesajId = Convert.ToInt32(mesaj1[0]);
            if(mesaj1.Length>1) this.labelControl1.Text = mesaj1[1];
            if (mesaj1.Length > 2) this.labelControl2.Text = mesaj1[2];
            if (mesaj1.Length > 3) this.labelControl2.Text = mesaj1[3];
        }
        void okumduIsaretle()
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void MesajForm_Click(object sender, EventArgs e)
        {
         
        }

        private void OKUNDUcmd_Click(object sender, EventArgs e)
        {
            MesajCntrl cn = new MesajCntrl();
            List<MesajVm> list = cn.Liste_Al(new MesajVm
            {
                ID = mesajId,
            }).ToList();
            if (list != null && list.Count != 0)
            {
                list[0].OKUNDU_E_H = (int)EvetHayirEn.Evet;
                cn.Guncelle(list[0], list[0].ID);
            }
            this.Hide();
        }
    }
}
