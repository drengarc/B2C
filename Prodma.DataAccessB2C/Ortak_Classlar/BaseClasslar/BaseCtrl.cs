using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prodma.DataAccessB2C
{
    public abstract class BaseCtrl<TViewModel, TModelKey> where TViewModel : IViewModel
    {
        string tabloAdi = "";
        public DateTime FisBaslangicTarih = YardimciIslemler.TarihSet1900();
        public DateTime FisBitisTarih = YardimciIslemler.TarihSet2049();
        public bool islemTamamDegilCntrl = true;
        public int hataKod=100;
        public string Mesaj;
        public int insertId;
        public bool kayitVar = false;
        public bool mesajGosterme = false;
        public bool KayitMesajiGoster = false;
        public bool LogDosyasinaYazma = false;
        public int yil = 0;
        public List<TViewModel> Liste_Al(TViewModel t)
        {
            try
            {
                //List<TViewModel> sonuc = doListe_Al(t);
                //if (sonuc.Count > 0) kayitVar = true; else kayitVar = false;
                return doListe_Al(t);
            }
            catch (ServiceIstisna ex)
            {
                
                hataKod = 101;
                Mesaj = "Servise İstisna Hatası (Liste Alma) - detayli Aciklama: " + ex.InnerException;
                return null;
            }
            catch (Exception ex)
            {
                hataKod = 102;
                Mesaj = "Controller Hatası (Liste Alma) - detayli Aciklama: " + ex.Message;
                return null;
            }
            finally
            {
                if (hataKod == 100)
                {
                    islemTamamDegilCntrl = false;
                }
                else
                {
                    islemTamamDegilCntrl = true;
                    //if (Globals.serverIp == "") Globals.serverIp = "192.168.1.13";
                    ////LogHelperB2C.Logger.setString("data source=" + Globals.serverIp + ";initial catalog=" + Globals.db + ";integrated security=false;persist security info=True;User ID=sa;Password=bgssup"); 
                    if (LogDosyasinaYazma == false) LogHelperB2C.LogError(Mesaj,tabloAdi);
                }

            }
             
        }
        public void Ekle(TViewModel t)
        {
            try
            {
                doEkle(t);
                //t.ID = t.insertId;
                t.modelDegiskligeUgradi = true;
                hataKod = 100;
                insertId = t.insertId;
                if (Globals.islemYapilanTabloAdiServiceten == null) Globals.islemYapilanTabloAdiServiceten = "Tablo,Boş";
                string[] a = Globals.islemYapilanTabloAdiServiceten.Split(',');
                if (a.Length == 2)
                {
                    if (t.IslemNedeni == null || t.IslemNedeni == 0)
                    {
                        t.IslemNedeni = (int)IslemNedeniEn.DigerSebeplerden;
                    }
                    Mesaj = a[0] + "#" + t.Islem + "‡Alan»" + t.ayrimAlan + "‡Işlem»Yeni Kayıt" + "‡Kullanici»" + Globals.gnKullaniciAd + "‡IslemNedeni»" + t.IslemNedeni + "‡ID»" + t.ID;
                    tabloAdi = a[0];
                }
            }
            catch (ServiceIstisna ex)
            {
                hataKod = 101;
                if (Globals.islemYapilanTabloAdiServiceten == null) Globals.islemYapilanTabloAdiServiceten = "Tablo,Boş";

                                string[] a = Globals.islemYapilanTabloAdiServiceten.Split(',');
                                if (a.Length == 2)
                                {
                                    if (t.IslemNedeni == null || t.IslemNedeni == 0)
                                    {
                                        t.IslemNedeni = (int)IslemNedeniEn.DigerSebeplerden;
                                    }
                                    Mesaj = a[0] + "#" + t.Islem + "#Servise İstisna Hatası (Yeni Kayıt) - detayli Aciklama: " + ex.Mesaj;
                                    tabloAdi = a[0];
                                }
            }
            catch (Exception ex)
            {
                hataKod = 102;
                if (Globals.islemYapilanTabloAdiServiceten == null) Globals.islemYapilanTabloAdiServiceten = "Tablo,Boş";

                                string[] a = Globals.islemYapilanTabloAdiServiceten.Split(',');
                                if (a.Length == 2)
                                {
                                    if (t.IslemNedeni == null || t.IslemNedeni == 0)
                                    {
                                        t.IslemNedeni = (int)IslemNedeniEn.DigerSebeplerden;
                                    }
                                    Mesaj = a[0] + "#" + t.Islem + "#Controller Hatası (Yeni Kayıt) - detayli Aciklama: " + ex.Message + " inner: " + ex.InnerException;
                                    tabloAdi = a[0];

                                }
            }
            finally
            {
                if (hataKod == 100)
                {
                    islemTamamDegilCntrl = false;
                    if (Globals.serverIp == "") Globals.serverIp = "192.100.10.250";
                    ////LogHelperB2C.Logger.setString("data source=" + Globals.serverIp + ";initial catalog=" + Globals.db + ";integrated security=false;persist security info=True;User ID=sa;Password=bgssup"); 
                    if (LogDosyasinaYazma==false) LogHelperB2C.LogInfoMessage(Mesaj,tabloAdi);
                }
                else  
                {
                    islemTamamDegilCntrl = true;
                    if (Globals.serverIp == "") Globals.serverIp = "192.100.10.250";
                    ////LogHelperB2C.Logger.setString("data source=" + Globals.serverIp + ";initial catalog=" + Globals.db + ";integrated security=false;persist security info=True;User ID=sa;Password=bgssup"); 
                    if (LogDosyasinaYazma == false) LogHelperB2C.LogError(Mesaj,tabloAdi);
                }

            }
           
        }
        public void Guncelle(TViewModel t,TModelKey id) {
            try
            {
                if (Convert.ToInt32(id) > 0) { doGuncelle(t,id); }
                if (KayitMesajiGoster == true) YardimciIslemler.UserControlKayitSonucu(100);
                t.modelDegiskligeUgradi = true;
                hataKod = 100;
                if (Globals.islemYapilanTabloAdiServiceten == null) Globals.islemYapilanTabloAdiServiceten = "Tablo,Boş";

                string[] a = Globals.islemYapilanTabloAdiServiceten.Split(',');
                if (a.Length==2)
                {
                    if (t.IslemNedeni == null || t.IslemNedeni == 0)
                    {
                        t.IslemNedeni = (int)IslemNedeniEn.DigerSebeplerden;
                    }
                    Mesaj = a[0] + "#" + a[1] + "‡Alan»" + t.ayrimAlan + "‡Işlem»Güncelleme" + "‡Kullanici»" + Globals.gnKullaniciAd + "‡IslemNedeni»" + t.IslemNedeni + "‡ID»" + t.ID;
                    tabloAdi = a[0];
                }
            }
            catch (ServiceIstisna ex)
            {
                hataKod = 101;
                if (Globals.islemYapilanTabloAdiServiceten == null) Globals.islemYapilanTabloAdiServiceten = "Tablo,Boş";

                   string[] a = Globals.islemYapilanTabloAdiServiceten.Split(',');
                   if (a.Length == 2)
                   {
                       if (t.IslemNedeni == null || t.IslemNedeni == 0)
                       {
                           t.IslemNedeni = (int)IslemNedeniEn.DigerSebeplerden;
                       }
                       Mesaj = a[0] + "#" + t.Islem + "#Servise İstisna Hatası (Güncelleme) - detayli Aciklama: " + ex.Mesaj;
                       tabloAdi = a[0];                     
                   }

                if (KayitMesajiGoster == true) YardimciIslemler.UserControlKayitSonucu(101);
                //TViewModel t1 = doListe_Al(t)[0];
                //t = t1;
            }
            catch (Exception ex)
            {
                if (KayitMesajiGoster == true) YardimciIslemler.UserControlKayitSonucu(102);
                hataKod = 102;
                if (Globals.islemYapilanTabloAdiServiceten == null) Globals.islemYapilanTabloAdiServiceten = "Tablo,Boş";

                string[] a = Globals.islemYapilanTabloAdiServiceten.Split(',');
                if (a.Length==2)
                {
                    if (t.IslemNedeni == null || t.IslemNedeni == 0)
                    {
                        t.IslemNedeni = (int)IslemNedeniEn.DigerSebeplerden;
                    }
                    Mesaj = a[0] + "#" + t.Islem + "#Controller Hatası (Güncelleme) - detayli Aciklama: " + ex.Message + " inner: " + ex.InnerException;
                    tabloAdi = a[0];

                }
                    //TViewModel t1 = doListe_Al(t)[0];
                //t = t1;
            }
            finally
            {
                if (hataKod == 100)
                {
                    islemTamamDegilCntrl = false;
                    if (Globals.serverIp == "") Globals.serverIp = "192.100.10.250";
                    ////LogHelperB2C.Logger.setString("data source=" + Globals.serverIp + ";initial catalog=" + Globals.db + ";integrated security=false;persist security info=True;User ID=sa;Password=bgssup");
                    if (LogDosyasinaYazma == false) LogHelperB2C.LogInfoMessage(Mesaj,tabloAdi);

                }
                else
                {
                    islemTamamDegilCntrl = true;
                    if (Globals.serverIp == "") Globals.serverIp = "192.100.10.250";
                    ////LogHelperB2C.Logger.setString("data source=" + Globals.serverIp + ";initial catalog=" + Globals.db + ";integrated security=false;persist security info=True;User ID=sa;Password=bgssup");
                    if (LogDosyasinaYazma == false) LogHelperB2C.LogError(Mesaj,tabloAdi);

                }

            }
        }
        public void Sil(TModelKey id, TViewModel t) {
            try
            {
                doSil(id, t);
                hataKod = 100;
                if (Globals.islemYapilanTabloAdiServiceten == null) Globals.islemYapilanTabloAdiServiceten = "Tablo,Boş";

                string[] a = Globals.islemYapilanTabloAdiServiceten.Split(',');
                if (a.Length == 2)
                {
                    if (t.IslemNedeni == null || t.IslemNedeni == 0)
                    {
                        t.IslemNedeni = (int)IslemNedeniEn.DigerSebeplerden;
                    }
                    Mesaj = a[0] + "#" + a[1] + "‡Alan»" + t.ayrimAlan + "‡Işlem»Silme" + "‡Kullanici»" + Globals.gnKullaniciAd + "‡IslemNedeni»" + t.IslemNedeni + "‡ID»" + t.ID;
                    tabloAdi = a[0];
                }
            }
            catch (ServiceIstisna ex)
            {
                hataKod = 101;
                if (Globals.islemYapilanTabloAdiServiceten == null) Globals.islemYapilanTabloAdiServiceten = "Tablo,Boş";

                               string[] a = Globals.islemYapilanTabloAdiServiceten.Split(',');
                               if (a.Length == 2)
                               {
                                   if (t.IslemNedeni == null || t.IslemNedeni == 0)
                                   {
                                       t.IslemNedeni = (int)IslemNedeniEn.DigerSebeplerden;
                                   }
                                   Mesaj = Mesaj + "#Servise İstisna Hatası (Silme) - detayli Aciklama: " + ex.Mesaj;
                                   tabloAdi = a[0];
                               }
            }
            catch (Exception ex)
            {
                hataKod = 102;
                if (Globals.islemYapilanTabloAdiServiceten == null) Globals.islemYapilanTabloAdiServiceten = "Tablo,Boş";

                                string[] a = Globals.islemYapilanTabloAdiServiceten.Split(',');
                                if (a.Length == 2)
                                {
                                    if (t.IslemNedeni == null || t.IslemNedeni == 0)
                                    {
                                        t.IslemNedeni = (int)IslemNedeniEn.DigerSebeplerden;
                                    }
                                    Mesaj = Mesaj + "#Controller Hatası (Silme) - detayli Aciklama: " + ex.Message + " inner: " + ex.InnerException;
                                    tabloAdi = a[0];
                                }
            }
            finally
            {
                if (hataKod == 100)
                {
                    islemTamamDegilCntrl = false;
                    if (Globals.serverIp == "") Globals.serverIp = "192.100.10.250";
                    ////LogHelperB2C.Logger.setString("data source=" + Globals.serverIp + ";initial catalog=" + Globals.db + ";integrated security=false;persist security info=True;User ID=sa;Password=bgssup");
                    if (LogDosyasinaYazma == false) LogHelperB2C.LogInfoMessage(Mesaj,tabloAdi);

                }
                else
                {
                    islemTamamDegilCntrl = true;
                    if (Globals.serverIp == "") Globals.serverIp = "192.100.10.250";
                    ////LogHelperB2C.Logger.setString("data source=" + Globals.serverIp + ";initial catalog=" + Globals.db + ";integrated security=false;persist security info=True;User ID=sa;Password=bgssup"); 
                    if (LogDosyasinaYazma == false) LogHelperB2C.LogError(Mesaj,tabloAdi);

                }

            }
        }
        public string MesajYaz()
        {

            return Mesaj;
        }
        public abstract void doEkle(TViewModel t);
        public abstract void doSil(TModelKey id,TViewModel t);
        public abstract void doGuncelle(TViewModel t,TModelKey id);
        public abstract List<TViewModel> doListe_Al(TViewModel t);

    }
}
