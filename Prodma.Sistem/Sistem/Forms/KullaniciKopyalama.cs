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
namespace Prodma.DataAccessB2C
{
    public partial class KullaniciKopyalama : Islemler
    {
        public int kullaniciId = 0;
        public KullaniciKopyalama(bool kullanici)
        {
            InitializeComponent();
            this.Text = "Kullanici Kopyalama";
            YardimciIslemlerKontrols.InvokeLueContainSet("KULLANICI_ID", ESKI_KULLANICI_IDlke);
            YardimciIslemlerKontrols.InvokeChlSet(YardimciIslemlerKontrols.EnumToList<KullaniciIslemleriTipEn>(), KOPYALANACAK_BILGIchl);
            YardimciIslemlerKontrols.InvokeEnumSet(YardimciIslemlerKontrols.EnumToList<KullaniciRolEn>(), KULLANICI_ROL_IDlke);
        }
        private void KullaniciKopyalama_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, KULLANICI_IDchl, true);
            ESKI_KULLANICI_IDlke.EditValue = kullaniciId;
            KULLANICI_ROL_IDlke.EditValue = (int)KullaniciRolEn.Kullanici;
        }
        public override void Tamam()
        {
            if (sorguBitti == false)
            {
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                Kullanici_Kopyala();
            }
            sorguBitti = true;
        }
        void Kullanici_Kopyala()
        {
         
                 
                if (Convert.ToInt32(KULLANICI_ROL_IDlke.EditValue) == (int)KullaniciRolEn.Kullanici)
                {
                    if (NOTtxt.Text.Trim() != "")
                    {
                        OrtakIslemlerService.KullaniciMesajYaz(NOTtxt.Text,NOT1txt.Text,NOT2txt.Text, YardimciIslemler.SplitTrim(parameterIslemler["KULLANICI_ID"]),"");
                        return;
                    }
                    OrtakIslemlerService.KullaniciKopyala(parameterIslemler, YardimciIslemler.SplitTrim(parameterIslemler["KULLANICI_ID"]));
                }
                else
                {
                    if (NOTtxt.Text.Trim() != "")
                    {
                        OrtakIslemlerService.KullaniciMesajYaz(NOTtxt.Text, NOT1txt.Text, NOT2txt.Text, YardimciIslemler.SplitTrim(parameterIslemler["KULLANICI_ID"]), "Rol");
                        return;
                    }
                    parameterIslemler.Add("ISLEM", "GENEL");
                    OrtakIslemlerService.KullaniciKopyalabyRol(parameterIslemler);
                }
                MessageBox.Show("İşlem Tamamlandı");
        }
        public override bool IslemKontrol(Control cntrl)
        {
                parameterIslemler.Clear();
                parameterIslemler.Add("KULLANICI_ID", Convert.ToString(KULLANICI_IDchl.EditValue.ToString()));
                parameterIslemler.Add("ESKI_KULLANICI_ID", Convert.ToString(ESKI_KULLANICI_IDlke.EditValue.ToString()));
                parameterIslemler.Add("KOPYALANACAK_BILGI", KOPYALANACAK_BILGIchl.EditValue.ToString());
                parameterIslemler.Add("YENI_KULLANICI_ADI", YENI__KULLANICI_ADItxt.Text.ToString());
            return true;
        }

        private void KULLANICI_ROL_IDlke_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(KULLANICI_ROL_IDlke.EditValue) == (int)KullaniciRolEn.Kullanici)
            {
                YardimciIslemlerKontrols.InvokeChlSet("AKTIF_KULLANICI_ID", KULLANICI_IDchl);
            }
            else
            {
                YardimciIslemlerKontrols.InvokeChlSet("ROL_ID", KULLANICI_IDchl);
            }
        }
    }
}
