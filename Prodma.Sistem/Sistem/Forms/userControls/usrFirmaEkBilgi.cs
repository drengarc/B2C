using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccessB2C;
using Prodma.SistemB2C.Models;
using Prodma.SistemB2C.Controllers;
using Prodma.WinForms;
namespace Prodma.Sistem.Forms
{
    public partial class usrFirmaEkBilgi : usrControlSablon
    {
        public string kayitEdilemez = "";
        public FirmaVm sifirliVm;
        private FirmaCntrl kulCntrl = new FirmaCntrl();
        public usrFirmaEkBilgi()
        {
            InitializeComponent();
            Ilk_Deger_Ver();
        }
        public void Ilk_Deger_Ver()
        {
            YardimciIslemlerKontrols.InvokeLueContainSet("FIRMA_TIP_ID", FIRMA_TIP_IDlke);
            YardimciIslemlerKontrols.InvokeLueContainSet("FIRMA_TEHLIKE_TIP_ID", FIRMA_TEHLIKE_TIP_IDlke);
            YardimciIslemlerKontrols.InvokeLueContainSet("FIRMA_ID", ASIL_FIRMA_IDlke);
        }
        public override void Doldur()
        {
            this.Control_Ayarla_Kayit(this.Controls, null, FIRMA_TIP_IDlke, null, true);
            FIRMA_TIP_IDlke.EditValue = (int?)sifirliVm.FIRMA_TIP_ID;
            FIRMA_TEHLIKE_TIP_IDlke.EditValue = (int?)sifirliVm.FIRMA_TEHLIKE_TIP_ID;
            ASIL_FIRMA_IDlke.EditValue = (int?)sifirliVm.ASIL_FIRMA_ID;
            DESTEK_ELEMAN_SAYISItxt.Text = sifirliVm.DESTEK_ELEMAN_SAYISI.ToString();
            ACIL_DURUM_YENILEME_PERIYODtxt.Text = sifirliVm.ACIL_DURUM_YENILEME_PERIYOD.ToString();
            YILLIK_EGITIM_YENILEME_PERIYODtxt.Text = sifirliVm.YILLIK_EGITIM_YENILEME_PERIYOD.ToString();
            PERIYODIK_EGITIM_DAKIKAtxt.Text = sifirliVm.PERIYODIK_EGITIM_DAKIKA.ToString();
            LOGO_PATHtxt.Text = Convert.ToString(sifirliVm.LOGO_PATH);
            RESIM_PATHtxt.Text = Convert.ToString(sifirliVm.RESIM_PATH);
            GUNCELLEME_PATHtxt.Text = Convert.ToString(sifirliVm.GUNCELLEME_PATH);
            RAPOR_PATHtxt.Text = Convert.ToString(sifirliVm.RAPOR_PATH);
            ARSIV_PATHtxt.Text = Convert.ToString(sifirliVm.ARSIV_PATH);
             
        }
        public override void Kaydet()
        {
            if (FIRMA_TIP_IDlke.EditValue != null) sifirliVm.FIRMA_TIP_ID = Convert.ToInt32(FIRMA_TIP_IDlke.EditValue);
            if (FIRMA_TEHLIKE_TIP_IDlke.EditValue != null) sifirliVm.FIRMA_TEHLIKE_TIP_ID = Convert.ToInt32(FIRMA_TEHLIKE_TIP_IDlke.EditValue);
            if (ASIL_FIRMA_IDlke.EditValue != null) sifirliVm.ASIL_FIRMA_ID = Convert.ToInt32(ASIL_FIRMA_IDlke.EditValue);
            if (DESTEK_ELEMAN_SAYISItxt.Text != "") sifirliVm.DESTEK_ELEMAN_SAYISI = Convert.ToInt32(DESTEK_ELEMAN_SAYISItxt.Text);
            if (ACIL_DURUM_YENILEME_PERIYODtxt.Text != "") sifirliVm.ACIL_DURUM_YENILEME_PERIYOD = Convert.ToInt32(ACIL_DURUM_YENILEME_PERIYODtxt.Text);
            if (YILLIK_EGITIM_YENILEME_PERIYODtxt.Text != "") sifirliVm.YILLIK_EGITIM_YENILEME_PERIYOD = Convert.ToInt32(YILLIK_EGITIM_YENILEME_PERIYODtxt.Text);
            if (PERIYODIK_EGITIM_DAKIKAtxt.Text != "") sifirliVm.PERIYODIK_EGITIM_DAKIKA = Convert.ToInt32(PERIYODIK_EGITIM_DAKIKAtxt.Text);
            sifirliVm.LOGO_PATH = LOGO_PATHtxt.Text.Trim();
            sifirliVm.RESIM_PATH = RESIM_PATHtxt.Text.Trim();
            sifirliVm.GUNCELLEME_PATH = GUNCELLEME_PATHtxt.Text.Trim();
            sifirliVm.RAPOR_PATH = RAPOR_PATHtxt.Text.Trim();
            sifirliVm.ARSIV_PATH = ARSIV_PATHtxt.Text.Trim();
             
            kulCntrl.Guncelle(sifirliVm, sifirliVm.ID);
            MessageBox.Show("İşlem Tamamlandı");
        }
    }
}