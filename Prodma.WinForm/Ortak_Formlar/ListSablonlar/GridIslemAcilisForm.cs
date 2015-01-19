using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Prodma.WinForms
{
    public partial class GridIslemAcilisForm : Form
    {
        public GridIslemAcilisForm()
        {
            InitializeComponent();
        }

        private void GridIslemAcilisForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }
    }
}