using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccess;  
using Prodma.Raporlar;
using Microsoft.Reporting.WinForms;
using System.Threading;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.WinForms;
using Prodma.Personel.Listeler.Services;
namespace IsciPerformans.Forms
{
    public partial class PersonelListeleri : ListSablonStok
    {
      

        //usrTeklifGenelList teklifGenelList;
       
        //public TeklifFisSifirVm sifirVm = new TeklifFisSifirVm();
        //public TeklifFisSatirVm satirVm = new TeklifFisSatirVm();
        public PersonelListeleri()
        {
            InitializeComponent();
            //LISTE_SECIMIlke.Visible = false;
            gridControl.gridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(gridView1_CustomSummaryCalculate);
            this.Load += new System.EventHandler(this.TeklifListeleri_Load);
            this.Text = ListeOzellikleri.ListeAdi;
            bn = new BindingSource[1];
            //ListeOzellikleri.EkModelli = (int)ListeEkModelEn.Tum;
            ListeOzellikleri.listSablonTip = (int)ListSablonEn.TabPageSiz;
            ListeOzellikleri.reportDataSet = new string[1];
            ListeOzellikleri.mt = new string[1];
            ListeOzellikleri.modelPath = "Personel.Listeler.PersonelListeleri.Models";
            ListeOzellikleri.modelName = "PersonelPuanlamaListVm";
            ListeOzellikleri.ListeAdi = "PersonelPuanlama";
            ListeOzellikleri.reportDataSet[0] = "PersonelPuanlamads";
            ListeOzellikleri.reportName = "Prodma.Raporlar.Raporlar.FinansRaporlar.IkmalPerformans.rdlc";
            ListeOzellikleri.mt[0] = "PersonelPuanlamaList";
            ListeOzellikleri.raporBaslik = "Personel Puanlama";
            ListeOzellikleri.raporParametreleri = new Dictionary<string, string>();
            ListeOzellikleri.raporParametreleri.Add("strDonem", "");
            //ListeOzellikleri.raporParametreleri.Add("strFirmaAdi", Globals.gnFirmaAd);
            //ListeOzellikleri.raporParametreleri.Add("strRaporBaslik", Globals.rman.GetString(YanSanayiIkmalPerformansbtn.Tag.ToString()));
            //ListeOzellikleri.raporParametreleri.Add("strGirenCikanMevcut", "");
        }
        public void TeklifListeleri_Load(object sender, EventArgs e)
        {
            LISTE_SECIMIlke.EditValue = (int)ListSablonListeSecimiEn.Tum;
            if (ListeOzellikleri.AcilistaYukle == true)
            {
                ParametreSet();
                Goster();
            }
          
            //if (teklifGenelList != null)
            //{
            //    //if (varsayilanCariId != 0 || ListeOzellikleri.varsayilanCariId != 0)
            //    //{
            //    //    //teklifGenelList.CARI_IDglebit.EditValue = teklifGenelList.CARI_IDglebas.EditValue = varsayilanCariId != 0 ? varsayilanCariId : ListeOzellikleri.varsayilanCariId;
            //    //}
            //    //if (varsayilanStokId != 0 || ListeOzellikleri.varsayilanStokId != 0)
            //    //{
            //    //    //teklifGenelList.STOK_IDglebit.EditValue = teklifGenelList.STOK_IDglebas.EditValue = varsayilanStokId != 0 ? varsayilanStokId : ListeOzellikleri.varsayilanStokId;
            //    //}
            //    //if (teklifGenelList.LK_ALIS_SATIS_IDlke.Text == "")
            //    //{
            //    //    if (GenelParametreSng.Nesne().kullaniciYetkileri.SATIS_FIYAT_GOR_E_H == (int)EvetHayirEn.Evet)
            //    //    {
            //    //        teklifGenelList.LK_ALIS_SATIS_IDlke.EditValue = (int)AlisSatisEn.SATIS;
            //    //    }
            //    //    else if (GenelParametreSng.Nesne().kullaniciYetkileri.ALIS_FIYAT_GOR_E_H == (int)EvetHayirEn.Evet)
            //    //    {
            //    //        teklifGenelList.LK_ALIS_SATIS_IDlke.EditValue = (int)AlisSatisEn.ALIS;
            //    //    }

            //    //}
            //}
            this.Text = ListeOzellikleri.ListeAdi;
        }
        public override void TabPage_Index_Changed(int index)
        {
            //if (index == 1)
            //{
            //    if (stokIliskili == null)
            //    {
            //        stokIliskili = new usrStokBilgileri();
            //        cariIliskili = new usrCariBilgileri();
            //        cariIliskili.Dock = DockStyle.Top;
            //        tbBalantili.Controls.Add(cariIliskili);
            //        stokIliskili.Dock = DockStyle.Top;
            //        tbBalantili.Controls.Add(stokIliskili);
            //        stokIliskili.Doldur();
            //        cariIliskili.Doldur();
            //    }
            //}
            //else if (index == 2)
            //{
            //    if (stokKodlar == null)
            //    {
            //        stokKodlar = new usrStokKodlar();
            //        cariKodlar = new usrCariKodlar();
            //        stokKodlar.Dock = DockStyle.Top;
            //        tbKodlar.Controls.Add(stokKodlar);
            //        stokMarkaModelYil = new usrStokMarkaModelYil();
            //        stokMarkaModelYil.Dock = DockStyle.Top;
            //        tbKodlar.Controls.Add(stokMarkaModelYil);
            //        stokMarkaModelYil.Doldur();
            //        cariKodlar.Dock = DockStyle.Top;
            //        tbKodlar.Controls.Add(cariKodlar);
            //        stokKodlar.Doldur();
            //        cariKodlar.Doldur();
            //    }
            //}
            //else if (index == 3)
            //{
            //    if (stokMiktarlar == null)
            //    {
            //        stokMiktarlar = new usrStokMiktarlar();
            //        cariMiktarlar = new usrCariMiktarlar();
            //        cariMiktarlar.Dock = DockStyle.Top;
            //        tbDetay.Controls.Add(cariMiktarlar);
            //        stokMiktarlar.Dock = DockStyle.Top;
            //        tbDetay.Controls.Add(stokMiktarlar);
            //        stokMiktarlar.Doldur();
            //        cariMiktarlar.Doldur();
            //    }
            //}
        }
        public void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridColumnSummaryItem item = e.Item as GridColumnSummaryItem;
            GridView view = sender as GridView;
            if (item != null && item.FieldName.ToString() == "BAKIYE_MIKTAR")
            {
                if (ListeOzellikleri.ListeAdi == "TeklifGozlem")
                {
                    if (parametersForm.ContainsKey("TeklifGozlemTip") && Convert.ToString(parametersForm["TeklifGozlemTip"]) == Convert.ToInt32(SiparisGozlemTipEn.BAKIYE).ToString())
                    {
                        if (gridControl.gridView1.Columns["MIKTAR"].SummaryItem.SummaryValue != null && gridControl.gridView1.Columns["SIPARIS_MIKTAR"].SummaryItem.SummaryValue != null)
                            e.TotalValue = Convert.ToDecimal(gridControl.gridView1.Columns["MIKTAR"].SummaryItem.SummaryValue) - Convert.ToDecimal(gridControl.gridView1.Columns["SIPARIS_MIKTAR"].SummaryItem.SummaryValue);
                    }
                }
            }
        }
        public override void IlkDegerleriVer()
        {
            if (ListeOzellikleri.listSablonTip == (int)ListSablonEn.TabPageSiz || ListeOzellikleri.listSablonTip == (int)ListSablonEn.TabPagesizRaporsuz)
            {
                if (ListeOzellikleri.ListeAdi == "TeklifFisi")
                {
                    //teklifFisi = new usrTeklifFisi();
                    //teklifFisi.Dock = DockStyle.Top;
                    //this.panelControl2.Controls.Clear();
                    //this.panelControl2.Controls.Add(teklifFisi);
                    //this.panelControl2.Size = new Size(teklifFisi.Width, teklifFisi.Height);
                    //teklifFisi.Doldur();
                }
                else
                {
                 //   this.panelControl1.Size = new Size(0, 0);
                    this.panelControl2.Size = new Size(0, 0);
                }
                this.tbControl.TabPages.Remove(tbBalantili);
                this.tbControl.TabPages.Remove(tbKodlar);
                this.tbControl.TabPages.Remove(tbDetay);
                this.tbControl.TabPages.Remove(xtraTabPage3);
                this.tbControl.TabPages.Remove(xtraTabPage4);
                this.tbControl.TabPages.Remove(xtraTabPage5);
                this.tbControl.TabPages.Remove(xtraTabPage6);
                this.tbControl.TabPages.Remove(xtraTabPage7);
                this.tbControl.TabPages.Remove(xtraTabPage8);
                this.tbControl.TabPages.Remove(xtraTabPage9);
                this.tbControl.TabPages.Remove(xtraTabPage10);
            }
            else
            {
                if (ListeOzellikleri.ListeAdi == "StokTeklifList" || ListeOzellikleri.ListeAdi == "StokTeklifBakiyeList" || ListeOzellikleri.ListeAdi == "CariHesapTeklifList" || ListeOzellikleri.ListeAdi == "CariHesapTeklifBakiyeList")
                {
                    //panelControlGrupSecimi.Visible = true;
                    //ListHelper.GruplamaDoldurSecenekli(Gruplke, true, true, true, true);
                    //UST_GRUPlbl.Visible = true;
                    //Grup2lke.Visible = true;
                    //ListHelper.GruplamaDoldurSecenekli(Grup2lke, true, true, true, true);
                    //LK_DETAY_GOSTER_E_Hlke.EditValue = EvetHayirEn.Evet;
                }
                else if (panelControlGrupSecimi.Visible == true)
                {
                    //panelControlGrupSecimi.Visible = true;
                    //ListHelper.GruplamaDoldurSecenekli(Gruplke, true, false, false, true);
                    //LK_DETAY_GOSTER_E_Hlke.EditValue = EvetHayirEn.Evet;
                }
                this.tbControl.TabPages.Remove(xtraTabPage3);
                this.tbControl.TabPages.Remove(xtraTabPage4);
                this.tbControl.TabPages.Remove(xtraTabPage5);
                this.tbControl.TabPages.Remove(xtraTabPage6);
                this.tbControl.TabPages.Remove(xtraTabPage7);
                this.tbControl.TabPages.Remove(xtraTabPage8);
                this.tbControl.TabPages.Remove(xtraTabPage9);
                this.tbControl.TabPages.Remove(xtraTabPage10);
                ModelBilgileriniUygula(true);
            }
        }
        public void ModelBilgileriniUygula(bool ilkdeger)
        {
            string bolgeler = "";
            string problemTipleri = "";
            string ambarlar = "";
            string strDonem = "";
            string brutNetTipAd = "";
            string alisSatisTipAd = "";
            string dovizCins = "";
            if (ilkdeger == false)
            {
                if (parametersForm.ContainsKey("CARI_BOLGE_ID_1") && parametersForm["CARI_BOLGE_ID_1"].Length > 0)
                {
                    string[] tipler = parametersForm["CARI_BOLGE_ID_1"].ToString().Split(',');
                    for (int j = 0; j < tipler.Length; j++)
                    {
                        bolgeler += tipler[j].Split('-')[0] + "-";
                    }
                    bolgeler = ListHelper.SonKarakteriSil(bolgeler.Trim());
                }
                else
                {
                    bolgeler = "Tüm Bölgeler";
                }
                if (parametersForm.ContainsKey("TARIHbas"))
                {
                    strDonem = parametersForm["TARIHbas"] + "-" + parametersForm["TARIHbit"];
                }
                
            }
            else
            {
                if (ListeOzellikleri.ListeAdi != "DinamikListe")
                {
                    //teklifGenelList = new usrTeklifGenelList();
                    //teklifGenelList.escapeKapatma = true;
                    //teklifGenelList.varsayilanCariId = ListeOzellikleri.varsayilanCariId;
                    //teklifGenelList.varsayilanStokId = ListeOzellikleri.varsayilanStokId;
                    //teklifGenelList.Dock = DockStyle.Top;
                    //panelGenelList.Controls.Add(teklifGenelList);
                    //teklifGenelList.Doldur();
                }
            }
            if (ListeOzellikleri.ListeAdi == "TeklifGozlem")
            {
                if (ilkdeger == true)
                {
                    //siparisOzel = new usrSiparisOzel();
                    //siparisOzel.Dock = DockStyle.Top;
                    //panelListeOzel.Controls.Add(siparisOzel);
                    //siparisOzel.Doldur();
                }
                else
                {
                    // MessageBox.Show("Raporu Yapılmadı");
                }
            }

        }
        public override void Tamam()
        {
            if (sorguBitti == false)
            {
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                if (ListeOzellikleri.mt.Length > 0)
                {
                    bn[0] = new BindingSource();
                    ListeYap listeYap = new ListeYap(ListeOzellikleri.mt[0], parametersForm);
                    bn[0].DataSource = listeYap.InvokeMethod();
                }
                //if (ListeOzellikleri.mt.Length > 1)
                //{
                //    bn[1] = new BindingSource();
                //    if (ListeOzellikleri.ListeAdi == "ProformaFatura")
                //    {
                //        ListeYap listeYap = new ListeYap(ListeOzellikleri.mt[1], parametersForm);
                //        //bn[1].DataSource = listeYap.TeklifAltUstAciklama(parametersForm);
                //    }
                //}
                //YardimciIslemler.RaporParametersiSet(ListeOzellikleri.raporParametreleri, ListeOzellikleri.prmRapor, "strToplamMiktar", parametersForm["strToplamMiktar"]);
                //YardimciIslemler.RaporParametersiSet(ListeOzellikleri.raporParametreleri, ListeOzellikleri.prmRapor, "strToplamAgirlik", parametersForm["strToplamAgirlik"]);
                //YardimciIslemler.RaporParametersiSet(ListeOzellikleri.raporParametreleri, ListeOzellikleri.prmRapor, "strToplamHacim", parametersForm["strToplamHacim"]);
                //YardimciIslemler.RaporParametersiSet(ListeOzellikleri.raporParametreleri, ListeOzellikleri.prmRapor, "strTutarYaziyla", parametersForm["strTutarYaziyla"]);
                //YardimciIslemler.RaporParametersiSet(ListeOzellikleri.raporParametreleri, ListeOzellikleri.prmRapor, "strGenelToplam", parametersForm["strGenelToplam"]);
                //YardimciIslemler.RaporParametersiSet(ListeOzellikleri.raporParametreleri, ListeOzellikleri.prmRapor, "strDovizAd", parametersForm["DOVIZ_AD"]);
                //YardimciIslemler.RaporParametersiSet(ListeOzellikleri.raporParametreleri, ListeOzellikleri.prmRapor, "strIskontoToplam", parametersForm["strIskontoToplam"]);
                //YardimciIslemler.RaporParametersiSet(ListeOzellikleri.raporParametreleri, ListeOzellikleri.prmRapor, "strAraToplam", parametersForm["strAraToplam"]);
                

            }
            sorguBitti = true;
        }
        public override void ReportParameterSet()
        {
            #region parametreler
            Uri filepath = new Uri(Globals.gnLogoPath);


            string resimUrl = filepath.AbsoluteUri;
            string strFirmaAdi = "";
            string strFirmaAdres = "";
            string strFirmaAdres1 = "";
            string strFirmaAdres2 = "";
            string strFirmaAdres3 = "";
           
            //if (ListeOzellikleri.ListeAdi == "ProformaFatura")
            //{
            //    if (sifirVm.TEKLIF_TIP_ID == (int)AlisSatisEn.ALIS)
            //    {
            //        if (Convert.ToInt32(DIL_IDlke.EditValue) == (int)Dil.Turkce)
            //        {
            //            ListeOzellikleri.raporParametreleri["strRaporBaslik"] = Globals.rman.GetString("PROFORMA_FATURA_ALIS");
            //        }
            //        else
            //        {
            //            ListeOzellikleri.raporParametreleri["strRaporBaslik"] = Globals.rmanIng.GetString("PROFORMA_FATURA_ALIS");
            //        }
            //    }
            //    else if (sifirVm.TEKLIF_TIP_ID == (int)AlisSatisEn.SATIS)
            //    {
            //        if (Convert.ToInt32(DIL_IDlke.EditValue) == (int)Dil.Turkce)
            //        {
            //            ListeOzellikleri.raporParametreleri["strRaporBaslik"] = Globals.rman.GetString("PROFORMA_FATURA_SATIS");
            //        }
            //        else
            //        {
            //            ListeOzellikleri.raporParametreleri["strRaporBaslik"] = Globals.rmanIng.GetString("PROFORMA_FATURA_SATIS");
            //        }
            //    }

            //    strToplamMiktar = parametersForm["strToplamMiktar"];
            //    strToplamAgirlik = parametersForm["strToplamAgirlik"];
            //    strToplamHacim = parametersForm["strToplamHacim"];
            //    strTutarYaziyla = parametersForm["strTutarYaziyla"];
            //    strGenelToplam = parametersForm["strGenelToplam"];
            //    strDovizAd = parametersForm["DOVIZ_AD"];
            //    strIskontoToplam = parametersForm["strIskontoToplam"];
            //    strAraToplam = parametersForm["strAraToplam"];
            //}
            //else if (ListeOzellikleri.ListeAdi == "MaliyetliProformaFatura")
            //{
            //    strRaporBaslik = Globals.rman.GetString("MALIYETLI_PROFORMA_FATURA");
            //}
            #endregion



            String[] kodlar = { "11", "22" };
            if (parametersForm.ContainsKey("CARI_BOLGE_ID_1") && parametersForm["CARI_BOLGE_ID_1"].Length > 0)
            {
                string[] tipler = parametersForm["CARI_BOLGE_ID_1"].ToString().Split(',');
                for (int j = 0; j < tipler.Length; j++)
                {
                    kodlar[0] += tipler[j].Split('-')[0] + "-";
                }
                kodlar[0] = ListHelper.SonKarakteriSil(kodlar[0].Trim());
            }

        

            int i = 0;
            ListeOzellikleri.prmRapor = new ReportParameter[ListeOzellikleri.raporParametreleri.Count];
            try
            {
                if (ListeOzellikleri.raporParametreleri.ContainsKey("strDonem")) { ListeOzellikleri.prmRapor[i] = new ReportParameter("strDonem", ListeOzellikleri.raporParametreleri["strDonem"]); i++; }
                if (ListeOzellikleri.raporParametreleri.ContainsKey("strSarfDonem")) { ListeOzellikleri.prmRapor[i] = new ReportParameter("strSarfDonem", ListeOzellikleri.raporParametreleri["strSarfDonem"]); i++; }
                if (ListeOzellikleri.raporParametreleri.ContainsKey("strFiyatTip")) { ListeOzellikleri.prmRapor[i] = new ReportParameter("strFiyatTip", ListeOzellikleri.raporParametreleri["strFiyatTip"]); i++; }
                if (ListeOzellikleri.raporParametreleri.ContainsKey("strRaporBaslik")) { ListeOzellikleri.prmRapor[i] = new ReportParameter("strRaporBaslik", ListeOzellikleri.raporParametreleri["strRaporBaslik"]); i++; }
                if (ListeOzellikleri.raporParametreleri.ContainsKey("strListeTip")) { ListeOzellikleri.prmRapor[i] = new ReportParameter("strListeTip", ListeOzellikleri.raporParametreleri["strListeTip"]); i++; }
                if (ListeOzellikleri.raporParametreleri.ContainsKey("strFirmaAdi")) { ListeOzellikleri.prmRapor[i] = new ReportParameter("strFirmaAdi", Globals.gnFirmaAd); i++; }
                if (ListeOzellikleri.raporParametreleri.ContainsKey("strBolge")) { ListeOzellikleri.prmRapor[i] = new ReportParameter("strBolge", kodlar[0]); i++; }
                if (ListeOzellikleri.raporParametreleri.ContainsKey("strProblemTipi")) { ListeOzellikleri.prmRapor[i] = new ReportParameter("strProblemTipi", kodlar[1]); i++; }
            }
            catch (Exception)
            {

                // throw;
            }
          
        }
        public override void ParametreSet()
        {
            try
            {
                sorguBitti = true;
                parametersForm.Clear();
                if (ListeOzellikleri.listSablonTip == (int)ListSablonEn.TabPageSiz || ListeOzellikleri.listSablonTip == (int)ListSablonEn.TabPagesizRaporsuz)
                {
                    //if (teklifFis != null)
                    //{
                    //    //teklifFis.ParametreUsrSet();
                    //    //parametersForm = parametersForm.Concat(teklifFis.parametersUsr).ToDictionary(e => e.Key, e => e.Value);
                    //}
                    //if (usrMektup != null)
                    //{
                    //    //usrMektup.ParametreUsrSet();
                    //    //parametersForm = parametersForm.Concat(usrMektup.parametersUsr).ToDictionary(e => e.Key, e => e.Value);
                    //}
                    parametersForm.Add("SiparisEkranListTip", ListeOzellikleri.ListeAdi);
                }
                else
                {
                    parametersForm.Add("GRUP_SECIM", Convert.ToString(Gruplke.EditValue));
                    parametersForm.Add("GRUP_SECIM_DETAY_GOSTER", Convert.ToString(LK_DETAY_GOSTER_E_Hlke.Text));
                    parametersForm.Add("GRUP_SECIM2", Convert.ToString(Grup2lke.EditValue));
                    if (ListeOzellikleri.EkModelli == (int)ListeEkModelEn.PersonelModelli)
                    {
                        parametersForm.Add("HAREKET_SECIM", "PERSONELVM");
                    }
                    else if (ListeOzellikleri.EkModelli == (int)ListeEkModelEn.Tum)
                    {
                        parametersForm.Add("HAREKET_SECIM", "PERSONELVM");
                    }
                    //if (teklifGenelList != null)
                    //{
                    //    teklifGenelList.ParametreUsrSet();
                    //    parametersForm = parametersForm.Concat(teklifGenelList.parametersUsr).ToDictionary(e => e.Key, e => e.Value);

                    //}
                    
                }
                sorguBitti = false;
                ModelBilgileriniUygula(false);
            }
            catch (Exception)
            {
                sorguBitti = true;
                if (ListeOzellikleri.ListeAdi == "DinamikListe")
                {
                    MessageBox.Show("Gruplamak İstediğini Alanın Değerlerini Seçiniz");
                }
                else
                {
                    MessageBox.Show("Bilinmeyen bir Hata Oluştu");
                }
                //throw; 
            }

        }
        public override void FilterParametreSet()
        {
            filterParametersForm.Clear();
            filterParametersForm.Add("GRUP_SECIM", Convert.ToString(Gruplke.EditValue));
            filterParametersForm.Add("GRUP_SECIM2", Convert.ToString(Grup2lke.EditValue));
            filterParametersForm.Add("GRUP_SECIM_DETAY_GOSTER", LK_DETAY_GOSTER_E_Hlke.Text);
            filterParametersForm.Add("gridViewColumnschl", Convert.ToString(gridViewColumnschl.EditValue));
            filterParametersForm.Add("LISTE_SECIMI", Convert.ToString(Convert.ToInt32(LISTE_SECIMIlke.EditValue)));
            filterParametersForm.Add("DIL_SECIMI", Convert.ToString(Convert.ToInt32(DIL_IDlke.EditValue)));
 
            ////if (teklifGenelList != null)
            ////{
            ////    teklifGenelList.Control_Ayarla_Deger_Kopyala(teklifGenelList.Controls);
            ////    filterParametersForm = filterParametersForm.Concat(teklifGenelList.filterParameters).ToDictionary(e => e.Key, e => e.Value);
            ////}
          
        }
        public override void SetFilter()
        {
            //if (stokIliskili == null)
            //{
            //    //stokIliskili = new usrStokBilgileri();
            //    //cariIliskili = new usrCariBilgileri();
            //    //cariIliskili.Dock = DockStyle.Top;
            //    //tbBalantili.Controls.Add(cariIliskili);
            //    //stokIliskili.Dock = DockStyle.Top;
            //    //tbBalantili.Controls.Add(stokIliskili);
            //    //stokIliskili.Doldur();
            //    //cariIliskili.Doldur();
            //}

            //if (stokKodlar == null)
            //{
            //    //stokMarkaModelYil = new usrStokMarkaModelYil();
            //    //stokKodlar = new usrStokKodlar();
            //    //cariKodlar = new usrCariKodlar();
            //    //stokKodlar.Dock = DockStyle.Top;
            //    //tbKodlar.Controls.Add(stokKodlar);
            //    //stokMarkaModelYil.Dock = DockStyle.Top;
            //    //tbKodlar.Controls.Add(stokMarkaModelYil);
            //    //cariKodlar.Dock = DockStyle.Top;
            //    //tbKodlar.Controls.Add(cariKodlar);
            //    //stokKodlar.Doldur();
            //    //stokMarkaModelYil.Doldur();
            //    //cariKodlar.Doldur();
            //}

            //if (stokMiktarlar == null)
            //{
            //    //stokMiktarlar = new usrStokMiktarlar();
            //    //cariMiktarlar = new usrCariMiktarlar();
            //    //cariMiktarlar.Dock = DockStyle.Top;
            //    //tbDetay.Controls.Add(cariMiktarlar);
            //    //stokMiktarlar.Dock = DockStyle.Top;
            //    //tbDetay.Controls.Add(stokMiktarlar);
            //    //stokMiktarlar.Doldur();
            //    //cariMiktarlar.Doldur();
            //}


            if (setValues.ContainsKey("GRUP_SECIM"))
            {
                Gruplke.EditValue = setValues["GRUP_SECIM"];
            }
            if (setValues.ContainsKey("GRUP_SECIM2"))
            {
                Grup2lke.EditValue = setValues["GRUP_SECIM2"];
            }
            if (setValues.ContainsKey("GRUP_SECIM_DETAY_GOSTER"))
            {
                if (setValues["GRUP_SECIM_DETAY_GOSTER"] == "Evet")
                {
                    LK_DETAY_GOSTER_E_Hlke.EditValue = (int)EvetHayirEn.Evet;
                }
                else
                {
                    LK_DETAY_GOSTER_E_Hlke.EditValue = (int)EvetHayirEn.Hayir;
                }
            }
            if (setValues.ContainsKey("gridViewColumnschl"))
            {
                gridViewColumnschl.EditValue = setValues["gridViewColumnschl"];
            }
            if (setValues.ContainsKey("DIL_SECIMI"))
            {
                DIL_IDlke.EditValue = Convert.ToInt32(setValues["DIL_SECIMI"]);
            }
            //if (teklifGenelList != null) teklifGenelList.SetControl(teklifGenelList.Controls, setValues);
        }
        public override void VarSayilanRaporDegerleriniAyarla()
        {
            if (ListeOzellikleri.ListeAdi == "StokTeklifBakiyeList")
            {
                Gruplke.EditValue = "STOK_ID";
            }
            if (ListeOzellikleri.ListeAdi == "CariHesapTeklifBakiyeList")
            {
                Gruplke.EditValue = "CARI_ID";
                //Grup2lke.EditValue = "CARI_ID";
            }
            if (ListeOzellikleri.ListeAdi == "TeklifGozlem")
            {
                //teklifGenelList.BRUT_NET_TIPlke.Enabled = false;
            }
            else if (ListeOzellikleri.ListeAdi == "ProformaFatura")
            {
                //usrMektup.AMBAR_MIKTARlbl.Visible = false;
                //usrMektup.AMBAR_E_Hlke.Visible = false;                                
                //usrMektup.AMBAR_IDchl.Visible = false;
            }
            else if (ListeOzellikleri.ListeAdi == "MaliyetliProformaFatura")
            {
                //usrMektup.DOKUM_ACIKLAMALARIbtn.Visible = false;
            }       
        }
        public override void GridGoruntuAyarla()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in this.gridControl.gridView1.Columns)
            {
                if (item.FieldName == "GRUP_SECIM")
                {
                    if (Gruplke.Visible == false)
                    {
                        item.Visible = false;
                    }
                }
                if (item.FieldName == "GRUP_SECIM1")
                {
                    if (Grup2lke.Visible == false)
                    {
                        item.Visible = false;
                    }
                }

                // if (item.Visible == true) gridViewColumnschl.Properties.Items.Add(item.Caption.ToString(), item.Visible == true ? CheckState.Checked : CheckState.Unchecked, true);
            }

            if (ListeOzellikleri.ListeAdi == "MaliyetliProformaFatura")
            {
              
                        foreach (DevExpress.XtraGrid.Columns.GridColumn item in this.gridControl.gridView1.Columns)
                        {
                            if (item.FieldName == "GRUP_SECIM" || item.FieldName == "GRUP_SECIM1" || item.FieldName == "GRUP_SECIM2")
                            {
                                item.Visible = false;
                            }
                            // if (item.Visible == true) gridViewColumnschl.Properties.Items.Add(item.Caption.ToString(), item.Visible == true ? CheckState.Checked : CheckState.Unchecked, true);
                        }
                  
            }
            else if (ListeOzellikleri.ListeAdi == "TeklifGozlem")
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn item in this.gridControl.gridView1.Columns)
                {
                    if (Convert.ToString(parametersForm["SiparisGozlemTip"]) == Convert.ToInt32(SiparisGozlemTipEn.TUM).ToString())
                    {
                        if (item.FieldName == "BAKIYE_MIKTAR")
                        {
                            item.Visible = false;
                        }
                    }
                    if (item.FieldName == "GRUP_SECIM" || item.FieldName == "GRUP_SECIM1")
                    {
                        item.Visible = false;
                    }
                }
              

            }
            if (ListeOzellikleri.ListeAdi == "StokTeklifBakiyeList")
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn item in this.gridControl.gridView1.Columns)
                {
                    if (item.FieldName == "DOVIZ_FIYAT" || item.FieldName == "TEKLIF_FIYAT" || item.FieldName == "ISKONTO" || item.FieldName == "STOK_BIRIM_IC" || item.FieldName == "SIPARIS_FIYAT" || item.FieldName == "CARI_KOD" || item.FieldName == "CARI_AD")
                    {
                        //item.Visible = false;
                    }
                    if (item.FieldName == "ISKONTO" || item.FieldName == "SIPARIS_FIYAT" || item.FieldName == "STOK_BIRIM_IC" )
                    {
                        item.Visible = false;
                    }
                    if (item.FieldName == "GRUP_SECIM")
                    {
                        item.Visible = true;
                    }
                    // if (item.Visible == true) gridViewColumnschl.Properties.Items.Add(item.Caption.ToString(), item.Visible == true ? CheckState.Checked : CheckState.Unchecked, true);
                }

            }
        }
    }
}