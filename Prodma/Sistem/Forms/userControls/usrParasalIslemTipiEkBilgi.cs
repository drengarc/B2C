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
    public partial class usrParasalIslemTipiEkBilgi : usrControlSablon
    {
        public string kayitEdilemez = "";
        public IslemTipiVm islemTipiVm = new IslemTipiVm();
        public BindingSource evetHayir = new BindingSource();
        private IslemTipiCntrl islemTipiCntrl = new IslemTipiCntrl();
        public usrParasalIslemTipiEkBilgi()
        {
            InitializeComponent();
            Ilk_Deger_Ver();
            escapeKapatma = true;
        }
        void Ilk_Deger_Ver()
        {
            evetHayir.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            DEVIR_E_Hcbo.Properties.DataSource = evetHayir;
            MAHSUP_E_Hcbo.Properties.DataSource = evetHayir;
            KASA_E_Hcbo.Properties.DataSource = evetHayir;
            TEMINAT_E_Hcbo.Properties.DataSource = evetHayir;
            VIRMAN_E_Hcbo.Properties.DataSource = evetHayir;
            KREDI_E_Hcbo.Properties.DataSource = evetHayir;
            TAHSILATCI_E_Hcbo.Properties.DataSource = evetHayir;
            BORDRO_E_Hcbo.Properties.DataSource = evetHayir;
            NAKIT_CEK_IDcbo.Properties.DataSource = ListService.GetNAKIT_CEK_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            CEK_SENET_IDcbo.Properties.DataSource = ListService.GetCEK_SENET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            FIRMA_MUSTERI_IDcbo.Properties.DataSource = ListService.GetLK_FIRMA_MUSTERI_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);

        }
        public override void Doldur()
        {
            this.Control_Ayarla_Kayit(this.Controls, ListDenemeService.GetALANLAR("ISLEM_TIPI", 2), TAHSILATCI_E_Hcbo, KREDI_E_Hcbo, true);
            DEVIR_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.DEVIR_E_H);
            MAHSUP_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.MAHSUP_E_H);
            KASA_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.KASA_E_H);
            TEMINAT_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.TEMINAT_E_H);
            VIRMAN_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.VIRMAN_E_H);
            NAKIT_CEK_IDcbo.EditValue = Convert.ToInt32(islemTipiVm.NAKIT_CEK_ID);
            CEK_SENET_IDcbo.EditValue = Convert.ToInt32(islemTipiVm.CEK_SENET_ID);
            KREDI_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.KREDI_E_H);
            TAHSILATCI_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.TAHSILATCI_E_H);
            FIRMA_MUSTERI_IDcbo.EditValue = Convert.ToInt32(islemTipiVm.LK_FIRMA_MUSTERI_ID);
            BORDRO_E_Hcbo.EditValue = Convert.ToInt32(islemTipiVm.BORDRO_E_H);
        }
        public override void Kaydet()
        {
            if (kayitEdilemez != "") { MessageBox.Show(kayitEdilemez); Doldur(); return; }
            if(DEVIR_E_Hcbo.EditValue != null) islemTipiVm.DEVIR_E_H = Convert.ToByte(DEVIR_E_Hcbo.EditValue);
            if(MAHSUP_E_Hcbo.EditValue != null) islemTipiVm.MAHSUP_E_H = Convert.ToByte(MAHSUP_E_Hcbo.EditValue);
            if(KASA_E_Hcbo.EditValue != null) islemTipiVm.KASA_E_H = Convert.ToByte(KASA_E_Hcbo.EditValue);
            if(TEMINAT_E_Hcbo.EditValue != null) islemTipiVm.TEMINAT_E_H = Convert.ToByte(TEMINAT_E_Hcbo.EditValue);
            if(VIRMAN_E_Hcbo.EditValue != null) islemTipiVm.VIRMAN_E_H = Convert.ToByte(VIRMAN_E_Hcbo.EditValue);
            if(NAKIT_CEK_IDcbo.EditValue != null) islemTipiVm.NAKIT_CEK_ID = Convert.ToInt32(NAKIT_CEK_IDcbo.EditValue);
            if(CEK_SENET_IDcbo.EditValue != null) islemTipiVm.CEK_SENET_ID = Convert.ToInt32(CEK_SENET_IDcbo.EditValue);
            if(KREDI_E_Hcbo.EditValue != null) islemTipiVm.KREDI_E_H = Convert.ToByte(KREDI_E_Hcbo.EditValue);
            if(TAHSILATCI_E_Hcbo.EditValue != null) islemTipiVm.TAHSILATCI_E_H = Convert.ToByte(TAHSILATCI_E_Hcbo.EditValue);
            if (FIRMA_MUSTERI_IDcbo.EditValue != null && Convert.ToInt32(FIRMA_MUSTERI_IDcbo.EditValue)!=0) islemTipiVm.LK_FIRMA_MUSTERI_ID = Convert.ToInt32(FIRMA_MUSTERI_IDcbo.EditValue);
            if(BORDRO_E_Hcbo.EditValue != null) islemTipiVm.BORDRO_E_H = Convert.ToByte(BORDRO_E_Hcbo.EditValue);
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