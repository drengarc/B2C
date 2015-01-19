using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Prodma.DataAccess;
using Siparis.Fis.Models;
using Siparis.Fis.Controllers;
using Satis.StokAmbar.Models;
using Satis.StokAmbar.Controllers;
using Satis.Cari.Models;
using System.Globalization;
using Satis.Cari.Controllers;
using Prodma.Sistem.Models;
using Prodma.Sistem.Controllers;
namespace Prodma.Sistem.Forms
{
    public partial class usrKullaniciEkBilgi : usrControlSablon
    {
        public string kayitEdilemez = "";
        public KullaniciVm kullaniciVm;
        public KullaniciCntrl kulcntrl = new KullaniciCntrl();
        public usrKullaniciEkBilgi()
        {
            InitializeComponent();
            Ilk_Deger_Ver();
        }
        void Ilk_Deger_Ver()
        {
            DIL_IDcbo.Properties.DataSource = ListService.GetDIL_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            YardimciIslemler.InvokeLueContainSet("KULLANICI_ID", UST_KULLANICI_IDlke);
            FIRMA_DISI_E_Hcbo.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            SARF_AMBAR_IDcbo.Properties.DataSource = ListService.GetAMBAR_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            ILERI_FIS_GIRIS_E_Hcbo.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            GERI_FIS_GIRIS_E_Hcbo.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            BAYI_SIPARIS_ONAY_E_Hcbo.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            TEKLIF_TIP_IDlke.Properties.DataSource = ListService.GetTEKLIF_TIP_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            SIPARIS_TIP_IDlke.Properties.DataSource = ListService.GetLK_ALIS_SATIS_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            AGENT_IDcbo.Properties.DataSource = ListService.GetCARI_AGENT_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            BARKOD_KULLANICI_E_Hcbo.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            KULLANICI_ALANLAR_OZEL_E_Hlke.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
        }
        public override void Doldur()
        {
            Control_Ayarla_Kayit(this.Controls, ListDenemeService.GetALANLAR("KULLANICI", 2), DIL_IDcbo, null, true);
            DIL_IDcbo.EditValue = kullaniciVm.DIL_ID;
            UST_KULLANICI_IDlke.EditValue = kullaniciVm.UST_KULLANICI_ID;
            if (kullaniciVm.FIRMA_DISI_E_H != null) FIRMA_DISI_E_Hcbo.EditValue = Convert.ToInt32(kullaniciVm.FIRMA_DISI_E_H);
            SARF_AMBAR_IDcbo.EditValue = kullaniciVm.SARF_AMBAR_ID;
            if (kullaniciVm.ILERI_FIS_GIRIS_E_H != null) ILERI_FIS_GIRIS_E_Hcbo.EditValue = Convert.ToInt32(kullaniciVm.ILERI_FIS_GIRIS_E_H);
            if (kullaniciVm.GERI_FIS_GIRIS_E_H != null) GERI_FIS_GIRIS_E_Hcbo.EditValue = Convert.ToInt32(kullaniciVm.GERI_FIS_GIRIS_E_H);
            if (kullaniciVm.BAYI_SIPARIS_ONAY_E_H != null) BAYI_SIPARIS_ONAY_E_Hcbo.EditValue = Convert.ToInt32(kullaniciVm.BAYI_SIPARIS_ONAY_E_H);
            TEKLIF_TIP_IDlke.EditValue = kullaniciVm.TEKLIF_TIP_ID;
            SIPARIS_TIP_IDlke.EditValue = kullaniciVm.SIPARIS_TIP_ID;
            AGENT_IDcbo.EditValue = kullaniciVm.CARI_AGENT_ID;
            if (kullaniciVm.BARKOD_KULLANICI_E_H != null) BARKOD_KULLANICI_E_Hcbo.EditValue = Convert.ToInt32(kullaniciVm.BARKOD_KULLANICI_E_H);
            if (kullaniciVm.KULLANICI_ALANLAR_OZEL_E_H != null) KULLANICI_ALANLAR_OZEL_E_Hlke.EditValue = Convert.ToInt32(kullaniciVm.KULLANICI_ALANLAR_OZEL_E_H);
            SIFREtxt.Text = Convert.ToString(kullaniciVm.SIFRE) ?? "";
            AGENT_SIFREtxt.Text = Convert.ToString(kullaniciVm.AGENT_SIFRE) ?? "";
            FIRMA_DISI_MAX_ISK_YUZtxt.Text = Convert.ToString(kullaniciVm.FIRMA_DISI_MAX_ISK_YUZ) ?? "";
            EK_ISK_YUZtxt.Text = Convert.ToString(kullaniciVm.EK_ISK_YUZ) ?? "";
        }
        public override void Kaydet()
        {
            //
            //TextEditler
            //
            kullaniciVm.SIFRE = SIFREtxt.Text;
            if (FIRMA_DISI_MAX_ISK_YUZtxt.Text != "") kullaniciVm.FIRMA_DISI_MAX_ISK_YUZ = Convert.ToDecimal(FIRMA_DISI_MAX_ISK_YUZtxt.Text);
            if (EK_ISK_YUZtxt.Text != "") kullaniciVm.EK_ISK_YUZ = Convert.ToDecimal(EK_ISK_YUZtxt.Text);
            kullaniciVm.AGENT_SIFRE = AGENT_SIFREtxt.Text;
            //
            //LookUpEditler
            //
            if (DIL_IDcbo.EditValue != null) { kullaniciVm.DIL_ID = Convert.ToInt16(DIL_IDcbo.EditValue); } else { kullaniciVm.DIL_ID = null; }
            if (UST_KULLANICI_IDlke.EditValue != null) kullaniciVm.UST_KULLANICI_ID = Convert.ToInt16(UST_KULLANICI_IDlke.EditValue);
            if (FIRMA_DISI_E_Hcbo.EditValue != null) { kullaniciVm.FIRMA_DISI_E_H = Convert.ToByte(FIRMA_DISI_E_Hcbo.EditValue); } else { kullaniciVm.FIRMA_DISI_E_H = null; }
            if (SARF_AMBAR_IDcbo.EditValue != null) { kullaniciVm.SARF_AMBAR_ID = Convert.ToInt16(SARF_AMBAR_IDcbo.EditValue); } else { kullaniciVm.SARF_AMBAR_ID = null; }
            if (ILERI_FIS_GIRIS_E_Hcbo.EditValue != null) { kullaniciVm.ILERI_FIS_GIRIS_E_H = Convert.ToByte(ILERI_FIS_GIRIS_E_Hcbo.EditValue); } else { kullaniciVm.ILERI_FIS_GIRIS_E_H = null; }
            if (BAYI_SIPARIS_ONAY_E_Hcbo.EditValue != null) { kullaniciVm.BAYI_SIPARIS_ONAY_E_H = Convert.ToByte(BAYI_SIPARIS_ONAY_E_Hcbo.EditValue); } else { kullaniciVm.BAYI_SIPARIS_ONAY_E_H = null; }
            if (TEKLIF_TIP_IDlke.EditValue != null) { kullaniciVm.CARI_PLASIYER_ID = Convert.ToInt32(TEKLIF_TIP_IDlke.EditValue); } else { kullaniciVm.CARI_PLASIYER_ID = null; }
            if (SIPARIS_TIP_IDlke.EditValue != null) { kullaniciVm.CARI_SATIS_ELEMANI_ID = Convert.ToInt32(SIPARIS_TIP_IDlke.EditValue); } else { kullaniciVm.CARI_SATIS_ELEMANI_ID = null; }
            if (AGENT_IDcbo.EditValue != null) { kullaniciVm.CARI_AGENT_ID = Convert.ToInt32(AGENT_IDcbo.EditValue); } else { kullaniciVm.CARI_AGENT_ID = null; }
            if (BARKOD_KULLANICI_E_Hcbo.EditValue != null) { kullaniciVm.BARKOD_KULLANICI_E_H = Convert.ToByte(BARKOD_KULLANICI_E_Hcbo.EditValue); } else { kullaniciVm.BARKOD_KULLANICI_E_H = null; }
            kulcntrl.KayitMesajiGoster = true;
            kulcntrl.Guncelle(kullaniciVm, kullaniciVm.ID);
            if (kulcntrl.hataKod  !=  100)
            {
                KullaniciVm Vm = kulcntrl.Liste_Al(kullaniciVm)[0];
                kullaniciVm = Vm;
                Doldur();
            }
        }

   
    }
}