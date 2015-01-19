using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Prodma.DataAccess;
using System.Globalization;
using Prodma.Sistem.Models;
using Prodma.Sistem.Controllers;
namespace Prodma.Sistem.Forms
{
    public partial class usrMiktarsalIslemTipiEkBilgi : usrControlSablon
    {
        public string kayitEdilemez = "";
        public IslemTipiVm islemTipiVm = new IslemTipiVm();
        public BindingSource evetHayir = new BindingSource();
        private IslemTipiCntrl islemTipiCntrl = new IslemTipiCntrl();
        public usrMiktarsalIslemTipiEkBilgi()
        {
            InitializeComponent();
            Ilk_Deger_Ver();
            escapeKapatma = true;
        }
        void Ilk_Deger_Ver()
        {
            evetHayir.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            FAT_IRS_GUN_E_Hcbo.Properties.DataSource = evetHayir;
            MUH_TASIMA_E_Hcbo.Properties.DataSource = evetHayir;
            PLASIYER_E_Hcbo.Properties.DataSource = evetHayir;
            SIPARIS_E_Hcbo.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            ISEMRI_E_Hcbo.Properties.DataSource = evetHayir;
            GENEL_ENVANTER_E_Hcbo.Properties.DataSource = evetHayir;
            DEVIR_E_Hcbo.Properties.DataSource = evetHayir;
            YURTICI_KULLANIM_E_Hcbo.Properties.DataSource = evetHayir;
            YURTDISI_KULLANIM_E_Hcbo.Properties.DataSource = evetHayir;
            OTO_PARTI_NO_E_Hcbo.Properties.DataSource = evetHayir;
            SABIT_FIYAT_E_Hcbo.Properties.DataSource = evetHayir;
            KALITE_KONTROL_AMBAR_E_Hcbo.Properties.DataSource = evetHayir;
            FATURA_DOKUM_E_Hcbo.Properties.DataSource = evetHayir;

            IC_DIS_IDcbo.Properties.DataSource = ListService.GetIC_DIS_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            ISLEM_CINS_IDcbo.Properties.DataSource = ListService.GetISLEM_CINS_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            ITHALAT_TIP_IDcbo.Properties.DataSource = ListService.GetITHALAT_TIP_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            ISLEM_TIPI_ISLEVI_IDcbo.Properties.DataSource = ListService.GetISLEM_TIPI_ISLEVI_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            AMBAR_GIRIS_CIKIS_IDcbo.Properties.DataSource = ListService.GetAMBAR_GIRIS_CIKIS_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            LK_DURUM_IDcbo.Properties.DataSource = ListService.GetLK_DURUM_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
        }
        public override void Doldur()
        {
            this.Control_Ayarla_Kayit(this.Controls, ListDenemeService.GetALANLAR("ISLEM_TIPI", 2), IC_DIS_IDcbo, LK_DURUM_IDcbo, true);
            IC_DIS_IDcbo.EditValue = Convert.ToInt32(islemTipiVm.IC_DIS_ID);
            ISLEM_CINS_IDcbo.EditValue = Convert.ToInt32(islemTipiVm.ISLEM_CINS_ID);
            FAT_IRS_GUN_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.FAT_IRS_GUN_E_H);
            MUH_TASIMA_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.MUH_TASIMA_E_H);
            PLASIYER_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.PLASIYER_E_H);
            SIPARIS_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.SIPARIS_E_H);
            ISEMRI_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.ISEMRI_E_H);
            ITHALAT_TIP_IDcbo.EditValue = Convert.ToInt32(islemTipiVm.ITHALAT_TIP_ID);
            ISLEM_TIPI_ISLEVI_IDcbo.EditValue = Convert.ToInt32(islemTipiVm.ISLEM_TIPI_ISLEVI_ID);
            AMBAR_GIRIS_CIKIS_IDcbo.EditValue = Convert.ToInt32(islemTipiVm.AMBAR_GIRIS_CIKIS_ID);
            GENEL_ENVANTER_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.GENEL_ENVANTER_E_H);
            DEVIR_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.DEVIR_E_H);
            YURTICI_KULLANIM_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.YURTICI_KULLANIM_E_H);
            YURTDISI_KULLANIM_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.YURTDISI_KULLANIM_E_H);
            OTO_PARTI_NO_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.OTO_PARTI_NO_E_H);
            SABIT_FIYAT_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.SABIT_FIYAT_E_H);
            KALITE_KONTROL_AMBAR_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.KALITE_KONTROL_AMBAR_E_H);
            FATURA_DOKUM_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.FATURA_DOKUM_E_H);
            LK_DURUM_IDcbo.EditValue = Convert.ToInt32(islemTipiVm.LK_DURUM_ID);
        }
        public override void Kaydet()
        {
            if (kayitEdilemez != "") { MessageBox.Show(kayitEdilemez); Doldur(); return; }
            if(IC_DIS_IDcbo.EditValue != null) islemTipiVm.IC_DIS_ID = Convert.ToInt32(IC_DIS_IDcbo.EditValue);
            if(ISLEM_CINS_IDcbo.EditValue != null) islemTipiVm.ISLEM_CINS_ID = Convert.ToInt32(ISLEM_CINS_IDcbo.EditValue);
            if(FAT_IRS_GUN_E_Hcbo.EditValue != null) islemTipiVm.FAT_IRS_GUN_E_H = Convert.ToByte(FAT_IRS_GUN_E_Hcbo.EditValue);
            if(MUH_TASIMA_E_Hcbo.EditValue != null) islemTipiVm.MUH_TASIMA_E_H = Convert.ToByte(MUH_TASIMA_E_Hcbo.EditValue);
            if(PLASIYER_E_Hcbo.EditValue != null) islemTipiVm.PLASIYER_E_H = Convert.ToByte(PLASIYER_E_Hcbo.EditValue);
            if(SIPARIS_E_Hcbo.EditValue != null) islemTipiVm.SIPARIS_E_H = Convert.ToByte( SIPARIS_E_Hcbo.EditValue);
            if(ISEMRI_E_Hcbo.EditValue != null) islemTipiVm.ISEMRI_E_H = Convert.ToByte(ISEMRI_E_Hcbo.EditValue);
            if(ITHALAT_TIP_IDcbo.EditValue != null) islemTipiVm.ITHALAT_TIP_ID = Convert.ToInt32(ITHALAT_TIP_IDcbo.EditValue);
            if(ISLEM_TIPI_ISLEVI_IDcbo.EditValue != null) islemTipiVm.ISLEM_TIPI_ISLEVI_ID = Convert.ToInt32(ISLEM_TIPI_ISLEVI_IDcbo.EditValue);
            if(AMBAR_GIRIS_CIKIS_IDcbo.EditValue != null) islemTipiVm.AMBAR_GIRIS_CIKIS_ID = Convert.ToInt32(AMBAR_GIRIS_CIKIS_IDcbo.EditValue);
            if(GENEL_ENVANTER_E_Hcbo.EditValue != null) islemTipiVm.GENEL_ENVANTER_E_H = Convert.ToByte(GENEL_ENVANTER_E_Hcbo.EditValue);
            if(DEVIR_E_Hcbo.EditValue != null) islemTipiVm.DEVIR_E_H = Convert.ToByte(DEVIR_E_Hcbo.EditValue);
            if(YURTICI_KULLANIM_E_Hcbo.EditValue != null) islemTipiVm.YURTICI_KULLANIM_E_H = Convert.ToByte(YURTICI_KULLANIM_E_Hcbo.EditValue);
            if(YURTDISI_KULLANIM_E_Hcbo.EditValue != null) islemTipiVm.YURTDISI_KULLANIM_E_H = Convert.ToByte(YURTDISI_KULLANIM_E_Hcbo.EditValue);
            if(OTO_PARTI_NO_E_Hcbo.EditValue != null) islemTipiVm.OTO_PARTI_NO_E_H = Convert.ToByte(OTO_PARTI_NO_E_Hcbo.EditValue);
            if(SABIT_FIYAT_E_Hcbo.EditValue != null) islemTipiVm.SABIT_FIYAT_E_H = Convert.ToByte(SABIT_FIYAT_E_Hcbo.EditValue);
            if(KALITE_KONTROL_AMBAR_E_Hcbo.EditValue != null) islemTipiVm.KALITE_KONTROL_AMBAR_E_H = Convert.ToByte(KALITE_KONTROL_AMBAR_E_Hcbo.EditValue);
            if(FATURA_DOKUM_E_Hcbo.EditValue != null) islemTipiVm.FATURA_DOKUM_E_H = Convert.ToByte(FATURA_DOKUM_E_Hcbo.EditValue);
            if(LK_DURUM_IDcbo.EditValue != null) islemTipiVm.LK_DURUM_ID = Convert.ToInt32(LK_DURUM_IDcbo.EditValue);
            islemTipiCntrl.KayitMesajiGoster = true;
            islemTipiCntrl.Guncelle(islemTipiVm, islemTipiVm.ID);
            if (islemTipiCntrl.hataKod  !=  100)
            {
               IslemTipiVm Vm = islemTipiCntrl.Liste_Al(islemTipiVm)[0];
                islemTipiVm = Vm;
                Doldur();
            }
        }

   
    }
}