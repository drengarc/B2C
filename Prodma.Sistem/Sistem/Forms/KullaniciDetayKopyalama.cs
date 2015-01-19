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
    public partial class KullaniciDetayKopyalama : Islemler
    {
        public int kullaniciId = 0;
        public int kullaniciIslemleriTipId = 0;
        public int islemId = 0;
        public int kopyalanacakBilgiDetayId = 0;
        public KullaniciDetayKopyalama()
        {
            InitializeComponent();
            this.Text = "Kullanici Kopyalama";
            YardimciIslemlerKontrols.InvokeLueContainSet("KULLANICI_ID", ESKI_KULLANICI_IDlke);
            YardimciIslemlerKontrols.InvokeChlSet("AKTIF_KULLANICI_ID", KULLANICI_IDchl);
            YardimciIslemlerKontrols.InvokeEnumSet(YardimciIslemlerKontrols.EnumToList<KullaniciListeSecimTipEn>(), HEDEF_TIPlke);
            YardimciIslemlerKontrols.InvokeEnumSet(YardimciIslemlerKontrols.EnumToList<KullaniciRolEn>(), KULLANICI_ROL_IDlke);
        }
        private void KullaniciKopyalama_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, KULLANICI_IDchl, true);
            ESKI_KULLANICI_IDlke.EditValue = kullaniciId;
            HEDEF_TIPlke.EditValue = (int)KullaniciListeSecimTipEn.Satir;
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
            MessageBox.Show("İşlem Tamamlandı");
        }
        void Kullanici_Kopyala()
        {
            if (Convert.ToInt32(KULLANICI_ROL_IDlke.EditValue) == (int)KullaniciRolEn.Kullanici)
            {
                OrtakIslemlerService.KullaniciDetayKopyala(parameterIslemler, YardimciIslemler.SplitTrim(parameterIslemler["KULLANICI_ID"]));
            }
            else
            {
                parameterIslemler.Add("ISLEM", "DETAY");
                OrtakIslemlerService.KullaniciKopyalabyRol(parameterIslemler);
            }
        }
        public override bool IslemKontrol(Control cntrl)
        {
                parameterIslemler.Clear();
                parameterIslemler.Add("KULLANICI_ID", Convert.ToString(KULLANICI_IDchl.EditValue.ToString()));
                parameterIslemler.Add("ESKI_KULLANICI_ID", Convert.ToString(ESKI_KULLANICI_IDlke.EditValue.ToString()));
                parameterIslemler.Add("KOPYALANACAK_BILGI", Convert.ToString(kullaniciIslemleriTipId));
                parameterIslemler.Add("ID", Convert.ToString(islemId));
                parameterIslemler.Add("KOPYALANACAK_BILGI_DETAY", HEDEF_TIPlke.EditValue.ToString());
            return true;
        }

        private void KULLANICI_ROL_IDlke_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(KULLANICI_ROL_IDlke.EditValue) == (int)KullaniciRolEn.Kullanici)
            {
                YardimciIslemlerKontrols.InvokeChlSet("KULLANICI_ID", KULLANICI_IDchl);
            }
            else
            {
                YardimciIslemlerKontrols.InvokeChlSet("ROL_ID", KULLANICI_IDchl);
            }
        }
    }
}
