using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.DynamicB2C;
using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection;
using Prodma.SistemB2C.Models;
using Prodma.SistemB2C.Controllers;
using System.Globalization;
using Prodma.SistemB2C.Services;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Resources;
using B2C.Models;
using B2C.Controllers;
namespace Prodma.DataAccessB2C
{
    public class B2cSistemService
    {


        public static void Kur()
        {
                //Globals.server = getConnecTionString();
                //KullaniciCntrl kul = new KullaniciCntrl();
                //KullaniciVm k = new KullaniciVm();
                //FirmaParametreVm f = new FirmaParametreVm();
                //f.FIRMA_ID = 1;
                //FirmaParametreService srvF = new FirmaParametreService();
                //f = srvF.Service_Liste_Al(f)[0];
                //k.KULLANICI_AD = "murat";
                //k.SIFRE = "bgssup";
                //k.LK_DURUM_ID = (int)DurumEn.Aktif;
                //List<KullaniciVm> kullanici = kul.Liste_Al(k);
                //if (kullanici.Count > 0)
                //{
                //    //if (kullanici[0].DIL_ID == (int)Dil.Turkce)
                //    //{
                //    //    Globals.rman = new System.Resources.ResourceManager("Prodma.DataAccess.Resources.Resource1.trTR", assem);
                //    //    Globals.rmanIng = new System.Resources.ResourceManager("Prodma.DataAccess.Resources.Resource1.enUS", assem);
                //    //}
                //    //else
                //    //{
                //    //    Globals.rman = new System.Resources.ResourceManager("Prodma.DataAccess.Resources.Resource1.enUS", assem);
                //    //    Globals.rmanIng = new System.Resources.ResourceManager("Prodma.DataAccess.Resources.Resource1.enUS", assem);
                //    //}
                //    //GenelParametreSng nesne = GenelParametreSng.Nesne();
                //    Globals.gnKullaniciId = kullanici[0].ID;
                //    Globals.gnKullaniciAd = kullanici[0].AD;
                //    Globals.gnKullaniciRolId = kullanici[0].ROL_ID;
                //    Globals.gnKullaniciDil = (int)Dil.Turkce;
                //    Globals.gnKullaniciFirmaTipId = kullanici[0].KULLANICI_FIRMA_TIP_ID;
                //    if (kullanici[0].DIL_ID != null) { Globals.gnKullaniciDil = Convert.ToInt32(kullanici[0].DIL_ID); }
                //    Globals.mFormAc = true;
                //    Globals.gnFirmaId = 1;
                //    Globals.hataMesaji = "";
                //    Globals.currentYear = 2012;
                //    FirmaParametreCntrl firma = new FirmaParametreCntrl();
                //    GenelParametreSng nesne = GenelParametreSng.Nesne();
                //    YetkiMenulerCntrl kulYetki = new YetkiMenulerCntrl();
                //    YetkiMenulerVm kYetki = new YetkiMenulerVm();
                //    kYetki.KULLANICI_ID = Globals.gnKullaniciId;
                //    kYetki.LK_DURUM_ID = (int)DurumEn.Aktif;
                //    nesne.kullaniciMenuYetkiBilgileri = kulYetki.Liste_Al(kYetki);
                //    nesne.firmaBilgileri = firma.Liste_Al(null)[0];
                //    nesne.kullaniciBilgileri = kullanici[0];                    
                //    Globals.gnFirmaId = nesne.firmaBilgileri.FIRMA_ID;
                //    Globals.gnLogoPath = nesne.firmaBilgileri.LOGO_PATH;
                //    Globals.gnFirmaAd = nesne.firmaBilgileri.FIRMA_ADI;
                //    Globals.stokKirilim = nesne.firmaBilgileri.STOK_KIRILMA;
                //    Globals.cariKirilim = nesne.firmaBilgileri.CARI_HESAP_KIRILMA;
                //    Globals.muhasebeKirilim = nesne.firmaBilgileri.MUHASEBE_KIRILMA;
                //    Globals.masrafYeriKirilim = nesne.firmaBilgileri.MASRAF_YERI_KIRILMA;
                //    Globals.dovizKurTip = Convert.ToInt32(nesne.firmaBilgileri.SATIS_DOVIZ_KUR_TIP);
                //    Globals.siparisTeslimTarihiGirisKontrolGun = Convert.ToInt32(nesne.firmaBilgileri.SIPARIS_TESLIM_TARIHI_GIRIS_KONTROL_GUN);
                //    KullaniciYetkileriCntrl kullaniciYetkileriCntl = new KullaniciYetkileriCntrl();
                //    KullaniciYetkileriVm kYetkiVm = new KullaniciYetkileriVm();
                //    kYetkiVm.KULLANICI_ID = Globals.gnKullaniciId;
                //    if (kullaniciYetkileriCntl.Liste_Al(kYetkiVm).Count > 0)
                //    {
                //        nesne.kullaniciYetkileri = kullaniciYetkileriCntl.Liste_Al(kYetkiVm)[0];
                //        ListDenemeService.SetYETKI_ISLEM(nesne.kullaniciYetkileri);
                //    }
                //    else
                //    {
                //        nesne.kullaniciYetkileri = kYetkiVm;
                //        ListDenemeService.SetYETKI_ISLEM(nesne.kullaniciYetkileri);
                //        //return;
                //    }
                //    string[] a = new string[2];
                //    a = ListDenemeService.GetVARSAYILAN_AMBAR_ID(Globals.gnKullaniciId, (int)KullaniciAmbarTipEn.VARSAYILAN);
                //    if (a.Length > 0)
                //    {
                //        if (a[0] != "") nesne.kullaniciYetkileri.KULLANICI_VARSAYILAN_AMBAR_ID = Convert.ToInt32(a[0]);
                //        nesne.kullaniciYetkileri.KULLANICI_VARSAYILAN_AMBAR_KOD = a[1];
                //    }
                //    OrtakIslemlerService.CariErisimBul();
                //    //FileVersionInfo myFI1 = FileVersionInfo.GetVersionInfo(Application.StartupPath.ToString() + "/Prodma.Satis.exe");
                //    //string strHostName = "";
                //    //strHostName = System.Net.Dns.GetHostName();

                //    //IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
                //    //IPAddress[] addr = ipEntry.AddressList;
                //    //string bilgisayarIp = "";
                //    //if (addr.Length > 0)
                //    //{
                //    //    for (int i = 0; i < addr.Length; i++)
                //    //    {
                //    //        bilgisayarIp = addr[i].ToString() + "  /   ";
                //    //    }

                //    //}
                //    //LogHelper.LogInfoMessage(Globals.gnKullaniciAd + " giriş yapti : Version == " + myFI1.FileVersion + " İp == " + bilgisayarIp);
                //} 
        }

        public static void StokUpdate(Dictionary<string, string> parameterIslemler)
        {
            //int id1 = 0;
            //StokVm vmStok = new StokVm();
            //StokVm vmStokKontrol = new StokVm();
            //List<StokVm> vmStokList = new List<StokVm>();
            //StokCntrl cntrlStok = new StokCntrl();
            //List<productVm> productList = new List<productVm>();
            //productCntrl cntrl = new productCntrl();
            //string productId = "";
            //if (parameterIslemler.ContainsKey("productId"))
            //{
            //    productId = Convert.ToString(parameterIslemler["productId"]);
            //}
            //string sql = "";
            //if (productId != "") sql = QueryOlustur.queryTekAlan(sql, productId.Split(','), "id");

            //productVm vm = new productVm();
            //vm.ListeFiltresi = sql;
            //productList = cntrl.Liste_Al(vm);
            //foreach (var item in productList)
            //{
            //    //vmStokKontrol = new StokVm();
            //    //vmStokKontrol.KOD = item.partner_code;
            //    //vmStokList = new List<StokVm>();
            //    //vmStokList = cntrlStok.Liste_Al(vmStokKontrol);
            //    vmStokList = null;
            //    if (vmStokList == null)
            //    {
            //        vmStok = new StokVm();
            //        // vmStok.ID = id1;
            //        vmStok.KOD = item.partner_code;
            //        vmStok.AD = item.name;
            //        vmStok.KISA_AD = item.name;
            //        vmStok.LK_STOK_TIP_ID = (int)StokTipEn.Mamul;
            //        vmStok.LK_YERLI_ITHAL_ID = 1;
            //        vmStok.STOK_AYRI_MALIYET_ID = 1;
            //        vmStok.LK_ONAY_E_H = 1;
            //        vmStok.LK_TICARI_MAL_E_H = 1;
            //        vmStok.BIRIM_IC_ID = 1;
            //        vmStok.LK_DURUM_ID = (int)DurumEn.Aktif;
            //        vmStok.product_id = item.id;
            //        cntrlStok.Ekle(vmStok);
            //    }
            //    else
            //    {
            //        vmStokList[0].AD = item.name;
            //        cntrlStok.Guncelle(vmStok,vmStok.ID);
            //    }
            //    id1++;
            //}
        }
        public static void SatisFiyatGir()
        {
            //FiyatSatisCntrl cntrl = new FiyatSatisCntrl();
            //cntrl.
        }

        public static void CariUpdate(Dictionary<string, string> parameterIslemler)
        {
        //    int i = 0;
        //    int j = 0;
        //    CariVm vmCari = new CariVm();
        //    CariAdresVm vmCariAdres = new CariAdresVm();
        //    CariTelefonIletisimVm vmCariTelefonIletisim = new CariTelefonIletisimVm();
        //    CariCntrl cntrlCari = new CariCntrl();
        //    CariAdresCntrl cntrlCariAdres = new CariAdresCntrl();
        //    CariTelefonIletisimCntrl cntrlCariTelefonIletisim = new CariTelefonIletisimCntrl();
        //    List<auth_userVm> cariList = new List<auth_userVm>();
        //    List<customer_addressVm> customer_addressList = new List<customer_addressVm>();
        //    customer_addressVm customer_addressVm = new customer_addressVm();
        //    auth_userCntrl cntrlauth_user = new auth_userCntrl();
        //    customer_addressCntrl cntrlcustomer_address = new customer_addressCntrl();
           
        //    string auth_userId = "";
        //    if (parameterIslemler.ContainsKey("auth_user_id"))
        //    {
        //        auth_userId = Convert.ToString(parameterIslemler["auth_user_id"]);
        //    }
        //    string sql="";
        //    if (auth_userId!="") sql = QueryOlustur.queryTekAlan(sql, auth_userId.Split(','), "id");

        //    auth_userVm vm = new auth_userVm();
        //    vm.ListeFiltresi = sql;
        //    cariList = cntrlauth_user.Liste_Al(vm);
        //    foreach (var item in cariList)
        //    {
        //        vmCari = new CariVm();
        //        String a = new String('0',9-item.id.ToString().Length);
        //        vmCari.KOD = "M" + a  +item.id.ToString();
        //        vmCari.AD = item.email;
        //        vmCari.KISA_AD = item.first_name;
        //        vmCari.CARI_TIP_ID = (int)CariTipEn.MUSTERI;
        //        vmCari.CARI_MENSEI_ID = (int)CariMenseiEn.Yurt_Ici;
        //        vmCari.LK_DURUM_ID = (int)DurumEn.Aktif;
        //        vmCari.KAMPANYA_E_H = 0;
        //        vmCari.MAIL = item.email;
        //        vmCari.customer_id = item.id;
        //        cntrlCari.Ekle(vmCari);
        //        customer_addressVm = new customer_addressVm();
        //        customer_addressVm.customer_id = item.id;
        //        customer_addressList = cntrlcustomer_address.Liste_Al(customer_addressVm);
        //        j = 1;
        //        if (customer_addressList.Count==0)
        //        {
        //            vmCariAdres = new CariAdresVm();
        //            vmCariAdres.CARI_ID = vmCari.ID;
        //            vmCariAdres.KOD = String.Format("{0:00}", j);
        //            vmCariAdres.AD ="Adres Girilmemiş";// item1.address_name;
        //            vmCariAdres.TC_KIMLIK_NO = "Adres Girilmemiş";// item1.address_name;
        //            vmCariAdres.FATURA_ADRES_1 = "Adres Girilmemiş";
        //            vmCariAdres.FATURA_ADRES_2 = "";
        //            vmCariAdres.FATURA_ADRES_3 = "";
        //            vmCariAdres.IRSALIYE_ADRES_1 = "Adres Girilmemiş";
        //            vmCariAdres.IRSALIYE_ADRES_2 = "";
        //            vmCariAdres.IRSALIYE_ADRES_3 = "";
        //            vmCariAdres.VERGI_NO = "Adres Girilmemiş";// item1.identity_number;
        //            vmCariAdres.VERGI_DAIRE = "Adres Girilmemiş"; //item1.tax_authority;
        //            cntrlCariAdres.Ekle(vmCariAdres);
        //        }
        //        else
        //        {
        //            foreach (var item1 in customer_addressList)
        //            {
        //                vmCariAdres = new CariAdresVm();
        //                vmCariAdres.CARI_ID = vmCari.ID;
        //                vmCariAdres.KOD = String.Format("{0:00}", j);
        //                vmCariAdres.AD = item1.address_name;// item1.address_name;
        //                vmCariAdres.TC_KIMLIK_NO = item1.identity_number;// item1.address_name;
        //                vmCariAdres.FATURA_ADRES_1 = item1.address;
        //                vmCariAdres.FATURA_ADRES_2 = "";
        //                vmCariAdres.FATURA_ADRES_3 = "";
        //                vmCariAdres.IRSALIYE_ADRES_1 = item1.address;
        //                vmCariAdres.IRSALIYE_ADRES_2 = "";
        //                vmCariAdres.IRSALIYE_ADRES_3 = "";
        //                vmCariAdres.VERGI_NO = item1.tax_no;// item1.identity_number;
        //                vmCariAdres.VERGI_DAIRE = item1.tax_authority; //item1.tax_authority;
        //                cntrlCariAdres.Ekle(vmCariAdres);
        //                j++;
        //            }
        //        }
               
        //        vmCariTelefonIletisim = new CariTelefonIletisimVm();
        //        vmCariTelefonIletisim.CARI_ID = vmCari.ID;
        //        vmCariTelefonIletisim.TELEFON = item.phone;
        //        cntrlCariTelefonIletisim.Ekle(vmCariTelefonIletisim);
        //        i++;
        //    }
        //}
        //public static void StokCariEslestir()
        //{
        //    int id1 = 0;
        //    StokVm vmStok = new StokVm();
        //    StokCntrl cntrlStok = new StokCntrl();
        //    List<productVm> productList = new List<productVm>();
        //    productCntrl cntrl = new productCntrl();
        //    productList = cntrl.Liste_Al(null);
        //    foreach (var item in productList)
        //    {
        //        vmStok = new StokVm();
        //       // vmStok.ID = id1;
        //        vmStok.KOD = item.partner_code;
        //        vmStok.AD = item.name;
        //        vmStok.KISA_AD = item.name;
        //        vmStok.LK_STOK_TIP_ID = (int)StokTipEn.Mamul;
        //        vmStok.LK_YERLI_ITHAL_ID = 1 ;
        //        vmStok.STOK_AYRI_MALIYET_ID = 1;
        //        vmStok.LK_ONAY_E_H = 1;
        //        vmStok.LK_TICARI_MAL_E_H =1;
        //        vmStok.BIRIM_IC_ID = 1;
        //        vmStok.LK_DURUM_ID = (int)DurumEn.Aktif;
        //        vmStok.product_id = item.id;
        //        cntrlStok.Ekle(vmStok);
        //        id1++;
        //    }
        //    int i=0;
        //    CariVm vmCari = new CariVm();
        //    CariAdresVm vmCariAdres = new CariAdresVm();
        //    CariCntrl cntrlCari = new CariCntrl();
        //    CariAdresCntrl cntrlCariAdres = new CariAdresCntrl();
            
        //    List<auth_userVm> cariList = new List<auth_userVm>();
        //    List<customer_addressVm> customer_addressList = new List<customer_addressVm>();
        //    customer_addressVm customer_addressVm = new customer_addressVm();
        //    auth_userCntrl cntrlauth_user = new auth_userCntrl();
        //    customer_addressCntrl cntrlcustomer_address = new customer_addressCntrl();

        //    cariList = cntrlauth_user.Liste_Al(null);
        //    foreach (var item in cariList)
        //    {
        //        vmCari = new CariVm();
        //        vmCari.KOD = "M000000000" + i;
        //        vmCari.AD = item.email;
        //        vmCari.KISA_AD = item.first_name;
        //        vmCari.CARI_TIP_ID = (int)CariTipEn.MUSTERI;
        //        vmCari.CARI_MENSEI_ID = (int)CariMenseiEn.Yurt_Ici;
        //        vmCari.LK_DURUM_ID = (int)DurumEn.Aktif;
        //        vmCari.KAMPANYA_E_H = 0;
        //        vmCari.customer_id = item.id;
        //        cntrlCari.Ekle(vmCari);
        //        customer_addressVm.id = item.id;
        //        customer_addressList = cntrlcustomer_address.Liste_Al(customer_addressVm);
        //        foreach (var item1 in customer_addressList)
        //        {
        //            vmCariAdres = new CariAdresVm();
        //            vmCariAdres.CARI_ID = vmCari.ID;
        //            vmCariAdres.KOD = "01";
        //            vmCariAdres.AD = item.email;// item1.address_name;
        //            vmCariAdres.FATURA_ADRES_1 =  "";
        //            vmCariAdres.FATURA_ADRES_2 =  "";
        //            vmCariAdres.FATURA_ADRES_3 =  "";
        //            vmCariAdres.IRSALIYE_ADRES_1 =  "";
        //            vmCariAdres.IRSALIYE_ADRES_2 =  "";
        //            vmCariAdres.IRSALIYE_ADRES_3 =  "";
        //            vmCariAdres.VERGI_NO = "111111111111";// item1.identity_number;
        //            vmCariAdres.VERGI_DAIRE = "Esenler"; //item1.tax_authority;
        //            cntrlCariAdres.Ekle(vmCariAdres);
        //        }
        //        i++;
        //    }

        //    //using (Prodma.DataAccessB2C.b2cEntities context = new DataAccessB2C.b2cEntities())
        //    //{
        //    //    var product1 = (from k in context.product
        //    //                    select new productVm
        //    //                    {
        //    //                        ID = k.id,
        //    //                        name = k.name
        //    //                    }).ToList();


        //    //}

        }
        public static string getConnecTionString()
        {
            //CALISMA_YILItxt.Text =  CALISMA_YILItxt.Text == "" ? Convert.ToString(DateTime.Today.Year) : CALISMA_YILItxt.Text;
            //if (IPtxt.Text.Trim() == "")
            //{
            //    IPtxt.Text = ".";
            //}
            //if (Dbtxt.Text == "" || Dbtxt.Text.Length != 3)
            //{
            //    Dbtxt.Text = "TIC";
            //}
            Globals.rman = new ResourceManager("Prodma.DataAccess.Resources.Resource1.trTR", Assembly.GetExecutingAssembly());
            //Globals.rman = new System.Resources.ResourceManager("Prodma.DataAccessB.Resources.Resource1.trTR", assem);
            string providerName = "System.Data.SqlClient";
            string serverName = "";// IPtxt.Text.Trim();
            string databaseName = "";//Dbtxt.Text.Trim() + Convert.ToString(SIRKETgle.EditValue) + CALISMA_YILItxt.Text.Substring(2, 2);
            databaseName = "B2C_ERP";
            serverName = ".";
            //IPtxt.Text = ".";
            Globals.db = databaseName;
            Globals.serverIp = serverName;
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.PersistSecurityInfo = false;
            sqlBuilder.UserID = "sa";
            sqlBuilder.Password = "bgssup";
            string providerString = sqlBuilder.ToString();
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            entityBuilder.Provider = providerName;

            entityBuilder.ProviderConnectionString = providerString;

            entityBuilder.Metadata = @"res://*/ProdmaModel.csdl|
                            res://*/ProdmaModel.ssdl|
                            res://*/ProdmaModel.msl";
            return entityBuilder.ToString();

        }

        public static List<productVm> ProductList(Dictionary<string, string> parametersForm)
        {
            string sql = QueryOlustur.SqlQueryProduct(parametersForm);
            using (b2cEntities context = new b2cEntities())
            {
                var list = (from kul in context.product
                           select new productVm
                           {
                               id = kul.id,
                               quantity = kul.quantity,
                               name = kul.name,
                               category_id = kul.category_id,
                               price = kul.price,
                               date_added = kul.date_added,
                               discount_price = kul.discount_price,
                               cargo_price = kul.cargo_price,
                               last_modified = kul.last_modified,
                               active = kul.active,
                               manufacturer_id = kul.manufacturer_id,
                               description = kul.description,
                               sync_ege = kul.sync_ege,
                               kdv = kul.kdv,
                               volume = kul.volume,
                               weight = kul.weight,
                               partner_code = kul.partner_code,
                               toptanci_id = kul.toptanci_id,
                               minimum_order_amount = kul.minimum_order_amount,
                               grup_id = kul.grup_id,
                           }).Where(sql).ToList();
                return list;
            }

            return null;
        }
    }
     
}
