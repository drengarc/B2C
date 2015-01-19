using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prodma.WinForm
{
    public partial class TextBoxBuyut : Form
    {
        public string yaziVerilen ="";
        public TextBoxBuyut(string text)
        {
            InitializeComponent();
            Yazitxt.Text = text;
        }

        private void TAMAMcmd_Click(object sender, EventArgs e)
        {
            yaziVerilen = Yazitxt.Text;
            this.Close();
        }

        private void TAMAMcmd_Click_1(object sender, EventArgs e)
        {
            yaziVerilen = Yazitxt.Text;
            this.Close();
        }

        private void IPTALcmd_Click(object sender, EventArgs e)
        {
            yaziVerilen = "";
            this.Close();
        }

    }
}
