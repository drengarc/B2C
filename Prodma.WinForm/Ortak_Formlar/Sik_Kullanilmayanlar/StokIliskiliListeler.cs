using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.DataAccessB2C;
//using Satis.Listeler.SiparisListeleri.Services;
//using Satis.Listeler.StokListeleri.Services;
namespace Prodma.WinForms
{
    //using Satis.Listeler.SiparisListeleri.Services = Siparis.ListeYap;
    public partial class StokIliskiliListeler : Islemler
    {
        usrGridIslem usr = new usrGridIslem(GridIslemEn.Bilgilendirme);
        BindingSource bn = new BindingSource();
        Dictionary<string, string> parameter = new Dictionary<string, string>();
        public int stokId = 0;
        public bool acilis = true;
        public StokIliskiliListeler()
        {
            InitializeComponent();
            YardimciIslemlerKontrols.TarihSet1900(TARIHdtbas);
            YardimciIslemlerKontrols.TarihSetBugun(TARIHdtbit);
            this.GOSTERcmd.Click += new System.EventHandler(this.GOSTERcmd_Click);
            YardimciIslemlerKontrols.InvokeLueContainSet("STOK_ID", STOKlke);
            this.Text = "Stok İşlem Bilgileri";
            panelControlGrid.Controls.Add(usr);
            usr.controlNavigatorButtonClick += controlNavigator1_ButtonClick;
            usr.gridView1.OptionsView.ShowGroupPanel = true;
            usr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GOZLEM_TIPcbo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            //this.GOZLEM_TIPcbo.Properties.Items.AddRange(new object[] {
            //"Stok Ambar Dağılım"});
            this.GOZLEM_TIPcbo.Properties.Items.AddRange(new object[] {
            "Stok Ambar Dağılım",
            "Güncel Satış Fiyatlar",
            "Güncel Alış Fiyatları",
            "Kampanya Fiyatları",
            "Satış Sipariş Bakiye",
            "Alış Sipariş Bakiye",
            "Stok Hareket Gözlem",
            });
            this.GOZLEM_TIPcbo.Properties.NullText = "Seçiniz";
        }
        private void GOSTERcmd_Click(object sender, EventArgs e)
        {
            Gridi_Doldur();
        }
        void Gridi_Olustur(usrGridIslem usr)
        {
            if (GOZLEM_TIPcbo.SelectedIndex == 0)
            {
                List<Alanlar> vmList = new List<Alanlar>();
                Alanlar vm = new Alanlar();
                vm = new Alanlar(); vm.ALAN_AD = "AMBAR_ADI"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 1; vmList.Add(vm);
                vm = new Alanlar(); vm.ALAN_AD = "BAKIYE"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "0"; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 2; vmList.Add(vm);
                vm = new Alanlar(); vm.ALAN_AD = "BIRIMI"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 3; vmList.Add(vm);
                usr.gridView1.OptionsView.ColumnAutoWidth = true;
                WinFormsHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", true);
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 1)
            {
               // FiyatSatisMiktarliCntrl famkulcntrl2 = new FiyatSatisMiktarliCntrl();
               // BindingSource bn = new BindingSource();
               //bn.DataSource = famkulcntrl2.doListe_Al_Guncel_Tarih(Convert.ToInt32(k2.STOK_ID));
                //string modelPath = "Satis.Listeler.StokListeleri.Models";
                //string modelName = "StokEnvanterTutarliVm";
                //string[] a = { "", "" };
                //WinFormsHelper.Grid_Olustur(modelPath, modelName, "Prodma.DataAccess", usr.gridView1, a, null);
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 2)
            {
                //string modelPath = "Satis.Listeler.StokListeleri.Models";
                //string modelName = "StokHareketMiktarliVm";
                //string[] a = { "", "" };
                //WinFormsHelper.Grid_Olustur(modelPath, modelName, "Prodma.DataAccess", usr.gridView1, a, null);
            }
            else if (GOZLEM_TIPcbo.SelectedIndex ==4)
            {
                string modelPath = "Satis.Listeler.SiparisListeleri.Models";
                string modelName = "StokSiparisBakiyeListVm";
                string[] a = { "", "" };
                WinFormsHelper.Grid_Olustur(modelPath, modelName, "Prodma.DataAccess", usr.gridView1, a, null);
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 5)
            {
                string modelPath = "Satis.Listeler.SiparisListeleri.Models";
                string modelName = "StokSiparisBakiyeListVm";
                string[] a = { "", "" };
                WinFormsHelper.Grid_Olustur(modelPath, modelName, "Prodma.DataAccess", usr.gridView1, a, null);
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 6)
            {
                string modelPath = "Satis.Listeler.StokListeleri.Models";
                string modelName = "StokHareketMiktarliVm";
                string[] a = { "", "" };
                WinFormsHelper.Grid_Olustur(modelPath, modelName, "Prodma.DataAccess", usr.gridView1, a, null);
            }
        }
        public void Gridi_Doldur()
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
           // if (GOZLEM_TIPcbo.SelectedIndex == 0)
           // {
           //     bn.DataSource = FisOrtakService.GetStokAmbarDurum((int)STOKlke.EditValue, Convert.ToDateTime(TARIHdtbas.EditValue), Convert.ToDateTime(TARIHdtbit.EditValue));
           // }
           // else if (GOZLEM_TIPcbo.SelectedIndex == 1)
           // {
           //     if (GenelParametreSng.Nesne().kullaniciYetkileri.SATIS_FIYAT_GOR_E_H == (int)EvetHayirEn.Evet)
           //     {
           //         FiyatSatisMiktarliCntrl famkulcntrl2 = new FiyatSatisMiktarliCntrl();
           //         bn.DataSource = famkulcntrl2.doListe_Al_Guncel_Tarih((int)STOKlke.EditValue, Convert.ToDateTime(TARIHdtbas.EditValue), Convert.ToDateTime(TARIHdtbit.EditValue));
           //     }
           // }
           // else if (GOZLEM_TIPcbo.SelectedIndex == 2)
           // {
           //     if (GenelParametreSng.Nesne().kullaniciYetkileri.ALIS_FIYAT_GOR_E_H == (int)EvetHayirEn.Evet)
           //     {
           //         FiyatAlisMiktarliCntrl famkulcntrl2 = new FiyatAlisMiktarliCntrl();
           //         bn.DataSource = famkulcntrl2.doListe_Al_Guncel_Tarih((int)STOKlke.EditValue, Convert.ToDateTime(TARIHdtbas.EditValue), Convert.ToDateTime(TARIHdtbit.EditValue));
           //     }
           // }
           // else if (GOZLEM_TIPcbo.SelectedIndex == 3)
           // {
           //     FiyatKampanyaMiktarliCntrl famkulcntrl2 = new FiyatKampanyaMiktarliCntrl();
           //     if (GenelParametreSng.Nesne().kullaniciYetkileri.SATIS_FIYAT_GOR_E_H == (int)EvetHayirEn.Evet)
           //     {
           //         bn.DataSource = famkulcntrl2.doListe_Al_Guncel_Tarih((int)STOKlke.EditValue, Convert.ToDateTime(TARIHdtbas.EditValue), Convert.ToDateTime(TARIHdtbit.EditValue));
           //     }
           // }
           // else if (GOZLEM_TIPcbo.SelectedIndex == 4)
           // {
           //     Gridi_Olustur(usr);
           //     siparis.ListeYap yp = new siparis.ListeYap();
           //     Dictionary<string,string> prm =  new Dictionary<string,string>();
           //     yp.alisSatisId = yp.alisSatisId1 = (int)AlisSatisEn.SATIS;
           //     yp.bitisKod = yp.baslangicKod = STOKlke.Text.Split('-')[0];
           //     prm.Add("PARITE_E_H", Convert.ToString((int)EvetHayirEn.Hayir));
           //     prm.Add("DOVIZ_AD", "TL");
           //     prm.Add("SATIR_SIPARIS_DOVIZ_ID", Convert.ToString((int)Doviz.TL));
           //     prm.Add("BRUT_NET_TIP",  Convert.ToString((int)BrutNetEn.BRUT));
           //     prm.Add("ULKE_ID",  Convert.ToString((int)UlkeEn.Turkiye));
           //     prm.Add("ALTERNATIF_KOD_E_H",  Convert.ToString((int)EvetHayirEn.Evet));
           //     bn.DataSource = yp.StokSiparisBakiyeList(prm);
           // }
           // else if (GOZLEM_TIPcbo.SelectedIndex == 5)
           // {
           //     Gridi_Olustur(usr);
           //     siparis.ListeYap yp = new siparis.ListeYap();

           //     Dictionary<string, string> prm = new Dictionary<string, string>();
           //     yp.alisSatisId = yp.alisSatisId1 = (int)AlisSatisEn.ALIS;
           //     yp.bitisKod = yp.baslangicKod = STOKlke.Text.Split('-')[0];
           //     prm.Add("PARITE_E_H", Convert.ToString((int)EvetHayirEn.Hayir));
           //     prm.Add("DOVIZ_AD", "TL");
           //     prm.Add("SATIR_SIPARIS_DOVIZ_ID", Convert.ToString((int)Doviz.TL));
           //     prm.Add("BRUT_NET_TIP", Convert.ToString((int)BrutNetEn.BRUT));
           //     prm.Add("ULKE_ID", Convert.ToString((int)UlkeEn.Turkiye));
           //     prm.Add("ALTERNATIF_KOD_E_H", Convert.ToString((int)EvetHayirEn.Evet));
           //     bn.DataSource = yp.StokSiparisBakiyeList(prm);
           // }
           // else if (GOZLEM_TIPcbo.SelectedIndex == 6)
           // {
           //     Gridi_Olustur(usr);
           //     stok.ListeYap yp1 = new stok.ListeYap();
           //     parameter.Clear();
           //     parameter.Add("TARIHbas", TARIHdtbas.Text);
           //     parameter.Add("TARIHbit", TARIHdtbit.Text);
           //     parameter.Add("STOK_IDbas", STOKlke.Text.Split('-')[0]);
           //     parameter.Add("STOK_IDbit", STOKlke.Text.Split('-')[0]);
           //     bn.DataSource = yp1.StokHareketMiktarliList(parameter);
           // }
           // else
           // {
           //     //parameter.Clear();
           //     //parameter.Add("TARIHbas",TARIHdtbas.Text);
           //     //parameter.Add("TARIHbit",TARIHdtbit.Text);
           //     //parameter.Add("STOK_IDbas",STOKlke.Text.Split('-')[0]);
           //     //parameter.Add("STOK_IDbit",STOKlke.Text.Split('-')[0]);
           //     //ListeYap yp = new ListeYap("",parameter);
           //     //if (GOZLEM_TIPcbo.SelectedIndex == 1)
           //     //{
           //     //    bn.DataSource = yp.StokEnvanterTutarliList(parameter);
           //     //}
           //     //else if (GOZLEM_TIPcbo.SelectedIndex == 2)
           //     //{
           //     //    bn.DataSource = yp.StokHareketMiktarliList(parameter);
           //     //}
           //}
           usr.gridControl1.DataSource = bn;
           YardimciIslemlerKontrols.ProgramBeklemeDurdur();
        }
        private void Stok_Gozlem_Load(object sender, EventArgs e)
        {
           
            Control_Ayarla_Kayit(this.Controls, null, STOKlke, false);
            YardimciIslemlerKontrols.TarihSet1900(TARIHdtbas);
            YardimciIslemlerKontrols.TarihSetBugun(TARIHdtbit);
            STOKlke.EditValue = stokId;
            GOZLEM_TIPcbo.SelectedIndex = 0;
           
        }
        public void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
        }
        private void Stok_Gozlem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void Stok_Gozlem_Shown(object sender, EventArgs e)
        {
            usr.gridControl1.Focus();
        }
        public void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
        }
        private void STOKlke_EditValueChanged(object sender, EventArgs e)
        {
            if (acilis == false)
            {
//                Gridi_Doldur();
            }
            acilis = false;
        }
        private void GOZLEM_TIPcbo_SelectedIndexChanged(object sender, EventArgs e)
        {
             
                usr.gridView1.Columns.Clear();
                Gridi_Olustur(usr);
                Gridi_Doldur();
             
        }
    }
}