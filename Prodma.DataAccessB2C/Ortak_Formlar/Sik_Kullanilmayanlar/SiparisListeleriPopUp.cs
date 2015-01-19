using System;
using Prodma.DataAccess;
using System.Windows.Forms;

namespace Prodma.WinForms
{
    public partial class SiparisListeleriPopUp : Sablon
    {
        public string filterName;
        public int? islem;
        public SiparisListeleriPopUp()
        {
            InitializeComponent();
        }

        private void Tamambtn_Click(object sender, EventArgs e)
        {
            if (FilterNametxt.Text == "")
                MessageBox.Show("Bir filtre adı belirlemelisiniz!");
            else
            {
                islem = 0;
                this.Close();
            }
        }

        private void Silbtn_Click(object sender, EventArgs e)
        {
            islem = 1;
            this.Close();
        }

        private void YeniKayitBtn_Click(object sender, EventArgs e)
        {
            if (FilterNametxt.Text == "")
                MessageBox.Show("Bir filtre adı belirlemelisiniz!");
            else
            {
                islem = 2;
                this.Close();
            }
        }

        private void SiparisListeleriPopUp_Load(object sender, EventArgs e)
        {
            islem = null;
            FilterNametxt.Text = filterName;
            if (filterName == "")
            {
                Silbtn.Enabled = false;
                Tamambtn.Enabled = false;
            }
        }

        
    }
}