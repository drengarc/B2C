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
    public partial class KullaniciMenuKopyalama : Islemler
    {
        public int kaynakId = 0;
        public int kaynakAlanlarAltId = 0;
        int yetkiIslemTipId=0;
        public int eskiKullaniciId;
        public string YetkiAlanAd = "";
        
        public KullaniciMenuKopyalama(int islemTip)
        {
            yetkiIslemTipId = islemTip;
            InitializeComponent();
            this.Text = "Kopyalama";
            if (islemTip == (int)KullaniciIslemleriTipEn.Menu_Yetkileri)
            {
                YardimciIslemlerKontrols.InvokeLueContainSet("M_MENU_ID", ESKI_KULLANICI_IDlke);
            }
            else
            {
               
                //ESKI_KULLANICI_IDlke.Properties.Columns[0].Visible = false;
            }

            YardimciIslemlerKontrols.InvokeChlSet("AKTIF_KULLANICI_ID", KULLANICI_IDchl);
            YardimciIslemlerKontrols.InvokeEnumSet(YardimciIslemlerKontrols.EnumToList<KullaniciRolEn>(), KULLANICI_ROL_IDlke);
        }
        private void KullaniciKopyalama_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, KULLANICI_IDchl, true);
            if (yetkiIslemTipId == (int)KullaniciIslemleriTipEn.Menu_Yetkileri)
            {
                ESKI_KULLANICI_IDlke.EditValue = kaynakId;
            }
            else
            {
                List<IdAdVm> vm = new List<IdAdVm>();
                vm.Add(new IdAdVm { ID = 0, AD = YetkiAlanAd });
                ESKI_KULLANICI_IDlke.Properties.DataSource = vm;
                ESKI_KULLANICI_IDlke.Properties.ValueMember = "ID";
                ESKI_KULLANICI_IDlke.Properties.DisplayMember = "AD";
                ESKI_KULLANICI_IDlke.EditValue  =0;
            }
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
                if (yetkiIslemTipId == (int)KullaniciIslemleriTipEn.Menu_Yetkileri)
                {
                    OrtakIslemlerService.KullaniciMenuKopyala(parameterIslemler, YardimciIslemler.SplitTrim(parameterIslemler["KULLANICI_ID"]));
                }
                else if (yetkiIslemTipId == (int)KullaniciIslemleriTipEn.Alan_Yetkileri)
                {
                    OrtakIslemlerService.KullaniciAlanBilgileriKopyala(parameterIslemler, YardimciIslemler.SplitTrim(parameterIslemler["KULLANICI_ID"]));
                }
                else if (yetkiIslemTipId == (int)KullaniciIslemleriTipEn.Bilgi_Bazli_Alan_Yetkileri)
                {
                    OrtakIslemlerService.KullaniciBilgiBazliAlanBilgileriKopyala(parameterIslemler, YardimciIslemler.SplitTrim(parameterIslemler["KULLANICI_ID"]));
                }
                else if (yetkiIslemTipId == (int)KullaniciIslemleriTipEn.Ozel_Listeler)
                {
                    OrtakIslemlerService.KullaniciOzelListelerKopyala(parameterIslemler, YardimciIslemler.SplitTrim(parameterIslemler["KULLANICI_ID"]));
                }
            }
            else
            {
                if (yetkiIslemTipId == (int)KullaniciIslemleriTipEn.Menu_Yetkileri)
                {
                    parameterIslemler.Add("ISLEM", "MENU");
                }
                else if (yetkiIslemTipId == (int)KullaniciIslemleriTipEn.Alan_Yetkileri)
                {
                    parameterIslemler.Add("ISLEM", "ALAN");
                }
                else if (yetkiIslemTipId == (int)KullaniciIslemleriTipEn.Bilgi_Bazli_Alan_Yetkileri)
                {
                    parameterIslemler.Add("ISLEM", "ALAN_BILGI");
                }
                else if (yetkiIslemTipId == (int)KullaniciIslemleriTipEn.Ozel_Listeler)
                {
                    parameterIslemler.Add("ISLEM", "OZEL_LISTE");
                }
                OrtakIslemlerService.KullaniciKopyalabyRol(parameterIslemler);
            }
        }
        public override bool IslemKontrol(Control cntrl)
        {
                parameterIslemler.Clear();
                parameterIslemler.Add("KULLANICI_ID", Convert.ToString(KULLANICI_IDchl.EditValue.ToString()));
                parameterIslemler.Add("KAYNAK_ID", Convert.ToString(kaynakId));
                parameterIslemler.Add("KAYNAK_ALANLAR_ALT_ID", Convert.ToString(kaynakAlanlarAltId));
                parameterIslemler.Add("ESKI_KULLANICI_ID", Convert.ToString(eskiKullaniciId));
                parameterIslemler.Add("RAPOR", Convert.ToString(YetkiAlanAd));
            
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
