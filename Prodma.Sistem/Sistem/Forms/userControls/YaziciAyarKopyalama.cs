using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccess; using Prodma.WinForms;
using System.Threading;
namespace Prodma.Sistem.Forms
{
    public partial class YaziciAyarKopyalama : Islemler
    { 
        public int ayarId;
        public int ayarTipId;
        public YaziciAyarKopyalama()
        {
            InitializeComponent();
            this.Text = "Fatura İrsaliye Ayar Kopyalama";
            YardimciIslemlerKontrols.InvokeLueContainSet("FATURA_IRSALIYE_AYAR_TIP_ID", FATURA_AYARlke);
        }
        private void DovizKurKopyalama_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, HEDEF_AYARtxt, true);
            FATURA_AYARlke.EditValue = ayarId;
        }
        public override void Tamam()
        {
            if (sorguBitti == false)
            {
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                Kopyala();
            }
            sorguBitti = true;
        }
        void Kopyala()
        {
            OrtakIslemlerService.FaturaIrsaliyeAyarKopyala(Convert.ToInt32(FATURA_AYARlke.EditValue), HEDEF_AYARtxt.Text, ayarTipId);
            MessageBox.Show("Kopyalama Tamalandı");
        }
        public override bool IslemKontrol(Control cntrl)
        {
           
                //if (HEDEF_AYARtxt.EditValue == null)
                //{
                //    MessageBox.Show("Başlangıç Tarih Giriniz");
                //    return false;
                //}
                //if (KAYNAK_TARIHdte.EditValue == null)
                //{
                //    MessageBox.Show("Başlangıç Tarih Giriniz");
                //    return false;
                //}
                if (YardimciIslemlerKontrols.UyariVer("Yazıcı Ayarları Kopyalanacak Emin Misiniz?") == false)
                {
                    return false;
                } 
                return true;
        }
    }
}
