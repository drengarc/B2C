using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccessB2C; using Prodma.WinForms;
using System.Threading;
namespace Prodma.Sistem.Forms
{
    public partial class SifreDegistirme : Islemler
    {
        public SifreDegistirme()
        {
            InitializeComponent();
            this.Text = "Sifre Degistirme";
        }
        private void KullaniciKopyalama_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, ESKI_SIFREtxt, true);
        }
        public override void Tamam()
        {
            if (sorguBitti == false)
            {
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                Sifre_Degistir();
            }
            sorguBitti = true;
            
        }
        void Sifre_Degistir()
        {
            KontrolVm kn = OrtakIslemlerService.SifreDegistir(ESKI_SIFREtxt.Text,YENI_SIFREtxt.Text);
            if (kn.DONUS_TIP == (int)KontrolEn.ENGELLE)
            {
                sorguBitti = true;
                MessageBox.Show(kn.DONUS_MESAJ);
            }
            else
            {
                MessageBox.Show("İşlem Tamamlandı");
            }
        }
      
    }
}
