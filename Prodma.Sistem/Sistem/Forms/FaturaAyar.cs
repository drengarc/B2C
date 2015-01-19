using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Prodma.DataAccess; using Prodma.WinForms;

namespace Prodma.Sistem.Forms
{
    public partial class FaturaAyar : Sablon
    {
        usrFaturaAyar usrFaturaAyar = new usrFaturaAyar();
        public FaturaAyar()
        {
            InitializeComponent();
            this.Controls.Add(this.usrFaturaAyar);
            this.usrFaturaAyar.Dock = DockStyle.Fill;
        }
    }
}