using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Prodma.WinForms
{
    public partial class navBar : DevExpress.XtraEditors.XtraUserControl
    {
       
        public navBar()
        {
            InitializeComponent();
            
        }
        public void navBarCustomButTonSil()
        {
            this.controlNavigator1.CustomButtons.RemoveAt(2);
        }
        public void navBarEkle()
        {
            //this.controlNavigator1.CustomButtons.RemoveAt(2);
        }
    }
}
