using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Prodma.DataAccess;

namespace Prodma.Sistem.Forms
{
    public partial class IrsaliyeAyar : Sablon
    {
        usrIrsaliyeYaziciAyar usrIrsaliyeYaziciAyar = new usrIrsaliyeYaziciAyar();
        public IrsaliyeAyar()
        {
            InitializeComponent();
            this.Controls.Add(this.usrIrsaliyeYaziciAyar);
            this.usrIrsaliyeYaziciAyar.Dock = DockStyle.Fill;
        }
    }
}