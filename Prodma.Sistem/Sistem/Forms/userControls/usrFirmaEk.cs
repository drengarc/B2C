using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccess;
using Prodma.WinForms;
using System.Threading;
namespace Prodma.Sistem.Forms
{
    public partial class usrFirmaEk : usrControlSablon
    {
        public string kayitEdilemez = "";
        public StokVm sifirliVm;
        bool _kayitIcin = false;
        Dictionary<string, bool> checkControl = new Dictionary<string, bool>();
        BindingSource[] bnSablonDizi = new BindingSource[10];
        public usrStokEkBilgi_3()
        {
            InitializeComponent();
            listeBicimTip = (int)UserControlTipEn.Kayit;
            escapeKapatma = true;
        }
        public usrStokEkBilgi_3(bool kayitIcin)
        {
            InitializeComponent();
            listeBicimTip = (int)UserControlTipEn.Kayit;
            _kayitIcin = kayitIcin;
            Ilk_Deger_Ver();
            escapeKapatma = true;
        }
        public void Ilk_Deger_Ver()
        {
            YardimciIslemlerKontrols.InvokeLueContainSet("FIRMA_TIP_ID", FIRMA_TIP_IDlke);
            YardimciIslemlerKontrols.InvokeLueContainSet("FIRMA_TEHLIKE_TIP_ID", FIRMA_TEHLIKE_TIP_IDlke);
            YardimciIslemlerKontrols.InvokeLueContainSet("FIRMA_ID", ASIL_FIRMA_IDlke);
         }
        public override void ControlleriDuzenle()
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, LK_STOK_TIP_IDlke, LK_STOK_TIP_IDlke, _kayitIcin);
        }
        public override void Doldur(bool ilkKayit)
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, LK_STOK_TIP_IDlke, LK_STOK_TIP_IDlke, _kayitIcin);         
            //LK_STOK_TIP_IDlke.EditValue = sifirliVm.BIRIM_IC_ID;
            //LK_YERLI_ITHAL_IDlke.EditValue = (int?)sifirliVm.BIRIM_DIS_ID;
            //LK_ONAY_E_Hlke.EditValue = ilkKayit==false ? sifirliVm.LK_KALITE_TANITIM_E_H: (int)EvetHayirEn.Hayir ;
            //LK_TICARI_MAL_E_Hlke.EditValue = ilkKayit==false ? sifirliVm.LK_KALITE_KONTROL_E_H: (int)EvetHayirEn.Hayir ;
            //LK_DURUM_IDlke.EditValue = ilkKayit==false ? sifirliVm.LK_TESVIK_E_H: (int)EvetHayirEn.Hayir ;
         }
        public override void Kaydet()
        {

             
            //sifirliVm.TICARI_MAL_MALIYET_MUHASEBE_HESAP_PLANI_ID = (int?)TICARI_MAL_MALIYET_MUHASEBE_HESAP_PLANI_IDlke.EditValue;                       

            StokCntrl ekBilgiCntrl1 = new StokCntrl();
            ekBilgiCntrl1.KayitMesajiGoster = true;
            ekBilgiCntrl1.Guncelle(sifirliVm, sifirliVm.ID);
            if (ekBilgiCntrl1.hataKod  !=  100)
            {
                
                StokVm Vm = ekBilgiCntrl1.Liste_Al(sifirliVm)[0];
                sifirliVm = Vm;
                Doldur();
            }
        }
        
    }
}