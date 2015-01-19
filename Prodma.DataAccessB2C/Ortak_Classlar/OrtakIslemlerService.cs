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
namespace Prodma.DataAccessB2C
{
    public class OrtakIslemlerService
    {
        public static void KullaniciKopyala(Dictionary<string, string> parameters, string[] kullanicilar)
        {

            string[] yapilcakIslem = YardimciIslemler.SplitTrim(parameters["KOPYALANACAK_BILGI"]);
            int eskikullaniciId = Convert.ToInt32(parameters["ESKI_KULLANICI_ID"]);
            string yeniKullaniciadi = parameters["YENI_KULLANICI_ADI"];
            using (b2cEntities context = new b2cEntities())
            {
                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Kullanici_Bilgileri)) && yeniKullaniciadi != "")
                {
                    KullaniciCntrl kullaniciCntrl = new KullaniciCntrl();
                    List<KullaniciVm> kullaniciList = new List<KullaniciVm>();
                    KullaniciVm kullaniciVm = new KullaniciVm();
                    kullaniciList = kullaniciCntrl.Liste_Al(null).Where(w => w.ID == eskikullaniciId).ToList();
                    kullaniciVm = kullaniciList[0];
                    kullaniciVm.AD = yeniKullaniciadi;
                    kullaniciVm.KULLANICI_AD = yeniKullaniciadi;
                    kullaniciCntrl.Ekle(kullaniciVm);
                    kullanicilar = new string[1];
                    kullanicilar[0] = Convert.ToString(kullaniciCntrl.insertId);
                }
                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Alan_Yetkileri)))
                {
                    YetkiAlanlarCntrl yAlanlarCntrl = new YetkiAlanlarCntrl();
                    List<YetkiAlanlarVm> yAlanlarList = new List<YetkiAlanlarVm>();
                    List<YetkiAlanlarVm> yAlanlarListEski = new List<YetkiAlanlarVm>();
                    YetkiAlanlarVm yAlanlarVm = new YetkiAlanlarVm();
                    yAlanlarList = YetkiAlanlarCek(eskikullaniciId, (int)KullaniciIslemleriTipEn.Alan_Yetkileri);
                    foreach (var item in kullanicilar)
                    {
                        yAlanlarListEski = YetkiAlanlarCek(Convert.ToInt32(item), (int)KullaniciIslemleriTipEn.Alan_Yetkileri);
                        if (yAlanlarListEski != null)
                        {
                            foreach (var item1 in yAlanlarListEski)
                            {
                                yAlanlarCntrl.Sil(item1.ID, item1);
                            }
                        }
                        if (yAlanlarList != null)
                        {
                            foreach (var item1 in yAlanlarList)
                            {
                                yAlanlarVm = new YetkiAlanlarVm();
                                yAlanlarVm = item1;
                                yAlanlarVm.KULLANICI_ID = Convert.ToInt32(item);
                                yAlanlarCntrl.Ekle(yAlanlarVm);
                            }
                        }
                    }
                }
                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Bilgi_Bazli_Alan_Yetkileri)))
                {
                    YetkiAlanlarCntrl yAlanlarCntrl = new YetkiAlanlarCntrl();
                    List<YetkiAlanlarVm> yAlanlarList = new List<YetkiAlanlarVm>();
                    List<YetkiAlanlarVm> yAlanlarListEski = new List<YetkiAlanlarVm>();
                    YetkiAlanlarVm yAlanlarVm = new YetkiAlanlarVm();
                    yAlanlarList = YetkiAlanlarCek(eskikullaniciId, (int)KullaniciIslemleriTipEn.Bilgi_Bazli_Alan_Yetkileri);
                    foreach (var item in kullanicilar)
                    {
                        yAlanlarListEski = YetkiAlanlarCek(Convert.ToInt32(item), (int)KullaniciIslemleriTipEn.Bilgi_Bazli_Alan_Yetkileri);
                        if (yAlanlarListEski != null)
                        {
                            foreach (var item1 in yAlanlarListEski)
                            {
                                yAlanlarCntrl.Sil(item1.ID, item1);
                            }
                        }
                        if (yAlanlarList != null)
                        {
                            foreach (var item1 in yAlanlarList)
                            {
                                yAlanlarVm = new YetkiAlanlarVm();
                                yAlanlarVm = item1;
                                yAlanlarVm.KULLANICI_ID = Convert.ToInt32(item);
                                yAlanlarCntrl.Ekle(yAlanlarVm);
                            }
                        }
                    }
                }

                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Islem_Yetkileri)))
                {
                    YetkiIslemlerCntrl yetkiIslemlerCntrl = new YetkiIslemlerCntrl();
                    List<YetkiIslemlerVm> yetkiIslemlerList = new List<YetkiIslemlerVm>();
                    List<YetkiIslemlerVm> yetkiIslemlerListEski = new List<YetkiIslemlerVm>();
                    YetkiIslemlerVm yetkiIslemlerVm = new YetkiIslemlerVm();
                    yetkiIslemlerList = YetkiIslemlerCek(eskikullaniciId, (int)IslemListeEn.ISLEM);
                    foreach (var item in kullanicilar)
                    {
                        yetkiIslemlerListEski = YetkiIslemlerCek(Convert.ToInt32(item), (int)IslemListeEn.ISLEM);
                        if (yetkiIslemlerListEski != null)
                        {
                            foreach (var item1 in yetkiIslemlerListEski)
                            {
                                yetkiIslemlerCntrl.Sil(item1.ID, item1);
                            }
                        }
                        if (yetkiIslemlerList != null)
                        {
                            foreach (var item1 in yetkiIslemlerList)
                            {
                                yetkiIslemlerVm = new YetkiIslemlerVm();
                                yetkiIslemlerVm = item1;
                                yetkiIslemlerVm.KULLANICI_ID = Convert.ToInt32(item);
                                yetkiIslemlerCntrl.Ekle(yetkiIslemlerVm);
                            }
                        }
                    }
                }
                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Liste_Yetkileri)))
                {
                    YetkiIslemlerCntrl yetkiIslemlerCntrl = new YetkiIslemlerCntrl();
                    List<YetkiIslemlerVm> yetkiIslemlerList = new List<YetkiIslemlerVm>();
                    List<YetkiIslemlerVm> yetkiIslemlerListEski = new List<YetkiIslemlerVm>();
                    YetkiIslemlerVm yetkiIslemlerVm = new YetkiIslemlerVm();
                    yetkiIslemlerList = YetkiIslemlerCek(eskikullaniciId, (int)IslemListeEn.LISTE);
                    foreach (var item in kullanicilar)
                    {
                        yetkiIslemlerListEski = YetkiIslemlerCek(Convert.ToInt32(item), (int)IslemListeEn.LISTE);
                        if (yetkiIslemlerListEski != null)
                        {
                            foreach (var item1 in yetkiIslemlerListEski)
                            {
                                yetkiIslemlerCntrl.Sil(item1.ID, item1);
                            }
                        }
                        if (yetkiIslemlerList != null)
                        {
                            foreach (var item1 in yetkiIslemlerList)
                            {
                                yetkiIslemlerVm = new YetkiIslemlerVm();
                                yetkiIslemlerVm = item1;
                                yetkiIslemlerVm.KULLANICI_ID = Convert.ToInt32(item);
                                yetkiIslemlerCntrl.Ekle(yetkiIslemlerVm);
                            }
                        }
                    }
                }
                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Kullanici_Dinamik_Yetkiler)))
                {
                    YetkiIslemlerCntrl yetkiIslemlerCntrl = new YetkiIslemlerCntrl();
                    List<YetkiIslemlerVm> yetkiIslemlerList = new List<YetkiIslemlerVm>();
                    List<YetkiIslemlerVm> yetkiIslemlerListEski = new List<YetkiIslemlerVm>();
                    YetkiIslemlerVm yetkiIslemlerVm = new YetkiIslemlerVm();
                    yetkiIslemlerList = YetkiIslemlerCek(eskikullaniciId, (int)IslemListeEn.DINAMIK);
                    foreach (var item in kullanicilar)
                    {
                        yetkiIslemlerListEski = YetkiIslemlerCek(Convert.ToInt32(item), (int)IslemListeEn.DINAMIK);
                        if (yetkiIslemlerListEski != null)
                        {
                            foreach (var item1 in yetkiIslemlerListEski)
                            {
                                yetkiIslemlerCntrl.Sil(item1.ID, item1);
                            }
                        }
                        if (yetkiIslemlerList != null)
                        {
                            foreach (var item1 in yetkiIslemlerList)
                            {
                                yetkiIslemlerVm = new YetkiIslemlerVm();
                                yetkiIslemlerVm = item1;
                                yetkiIslemlerVm.KULLANICI_ID = Convert.ToInt32(item);
                                yetkiIslemlerCntrl.Ekle(yetkiIslemlerVm);
                            }
                        }
                    }
                }
                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Menu_Yetkileri)))
                {
                    YetkiMenulerCntrl yetkiMenulerCntrl = new YetkiMenulerCntrl();
                    List<YetkiMenulerVm> yetkiMenulerList = new List<YetkiMenulerVm>();
                    List<YetkiMenulerVm> yetkiMenulerListEski = new List<YetkiMenulerVm>();
                    YetkiMenulerVm yetkiMenulerVm = new YetkiMenulerVm();
                    yetkiMenulerVm.KULLANICI_ID = eskikullaniciId;
                    yetkiMenulerList = yetkiMenulerCntrl.Liste_Al(yetkiMenulerVm);
                    foreach (var item in kullanicilar)
                    {
                        yetkiMenulerVm = new YetkiMenulerVm();
                        yetkiMenulerVm.KULLANICI_ID = Convert.ToInt32(item);
                        yetkiMenulerListEski = yetkiMenulerCntrl.Liste_Al(yetkiMenulerVm);
                        if (yetkiMenulerListEski != null)
                        {
                            foreach (var item1 in yetkiMenulerListEski)
                            {
                                yetkiMenulerCntrl.Sil(item1.ID, item1);
                            }
                        }
                        if (yetkiMenulerList != null)
                        {
                            foreach (var item1 in yetkiMenulerList)
                            {
                                yetkiMenulerVm = new YetkiMenulerVm();
                                yetkiMenulerVm = item1;
                                yetkiMenulerVm.KULLANICI_ID = Convert.ToInt32(item);
                                yetkiMenulerCntrl.Ekle(yetkiMenulerVm);
                            }
                        }
                    }
                }

                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Ozel_Listeler)))
                {
                    FiltrelerCntrl kullaniciFiltrelerCntrl = new FiltrelerCntrl();
                    List<FiltrelerVm> kullaniciFiltrelerList = new List<FiltrelerVm>();
                    List<FiltrelerVm> kullaniciFiltrelerListEski = new List<FiltrelerVm>();
                    FiltrelerVm kullaniciFiltrelerVm = new FiltrelerVm();
                    kullaniciFiltrelerVm.KULLANICI_ID = eskikullaniciId;
                    kullaniciFiltrelerList = kullaniciFiltrelerCntrl.Liste_Al(kullaniciFiltrelerVm);
                    foreach (var item in kullanicilar)
                    {
                        kullaniciFiltrelerVm = new FiltrelerVm();
                        kullaniciFiltrelerVm.KULLANICI_ID = Convert.ToInt32(item);
                        kullaniciFiltrelerListEski = kullaniciFiltrelerCntrl.Liste_Al(kullaniciFiltrelerVm);
                        if (kullaniciFiltrelerListEski != null)
                        {
                            foreach (var item1 in kullaniciFiltrelerListEski)
                            {
                                kullaniciFiltrelerCntrl.Sil(item1.ID, item1);
                            }
                        }
                        if (kullaniciFiltrelerList != null)
                        {
                            foreach (var item1 in kullaniciFiltrelerList)
                            {
                                kullaniciFiltrelerVm = new FiltrelerVm();
                                kullaniciFiltrelerVm = item1;
                                kullaniciFiltrelerVm.KULLANICI_ID = Convert.ToInt32(item);
                                kullaniciFiltrelerCntrl.Ekle(kullaniciFiltrelerVm);
                            }
                        }
                    }
                }
            }

        }
        public static void KullaniciKopyalabyRol(Dictionary<string, string> parameters)
        {
            int eskiKullaniciId = Convert.ToInt32(parameters["ESKI_KULLANICI_ID"]);
            string[] Roller = YardimciIslemler.SplitTrim(parameters["KULLANICI_ID"]);
            string[] kullaniciID = ListDenemeService.GetKullaniciByRol(Roller);
            kullaniciID = YardimciIslemler.DizidenCikart(eskiKullaniciId.ToString(), kullaniciID);
            if (parameters["ISLEM"] == "GENEL")
            {
                KullaniciKopyala(parameters, kullaniciID);
            }
            else if (parameters["ISLEM"] == "DETAY")
            {
                KullaniciDetayKopyala(parameters, kullaniciID);
            }
            else if (parameters["ISLEM"] == "MENU")
            {
                KullaniciMenuKopyala(parameters, kullaniciID);
            }
            else if (parameters["ISLEM"] == "ALAN")
            {
                KullaniciAlanBilgileriKopyala(parameters, kullaniciID);
            }
            else if (parameters["ISLEM"] == "ALAN_BILGI")
            {
                KullaniciBilgiBazliAlanBilgileriKopyala(parameters, kullaniciID);
            }
            else if (parameters["ISLEM"] == "OZEL_LISTE")
            {
                KullaniciOzelListelerKopyala(parameters, kullaniciID);
            }
        }
        public static void KullaniciDetayKopyala(Dictionary<string, string> parameters, string[] kullanicilar)
        {
            string[] yapilcakIslem = YardimciIslemler.SplitTrim(parameters["KOPYALANACAK_BILGI"]);
            int eskiKullaniciId = Convert.ToInt32(parameters["ESKI_KULLANICI_ID"]);
            int id = Convert.ToInt32(parameters["ID"]);
            int yapilcakIslemTip = Convert.ToInt32(parameters["KOPYALANACAK_BILGI_DETAY"]);
            using (b2cEntities context = new b2cEntities())
            {

                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Alan_Yetkileri)))
                {
                    YetkiAlanlarCntrl yAlanlarCntrl = new YetkiAlanlarCntrl();
                    List<YetkiAlanlarVm> yAlanlarList = new List<YetkiAlanlarVm>();
                    List<YetkiAlanlarVm> yAlanlarListEski = new List<YetkiAlanlarVm>();
                    YetkiAlanlarVm yAlanlarVm = new YetkiAlanlarVm();
                    yAlanlarList = YetkiAlanlarCek(eskiKullaniciId, (int)KullaniciIslemleriTipEn.Alan_Yetkileri);
                    foreach (var item in kullanicilar)
                    {
                        yAlanlarListEski = YetkiAlanlarCek(Convert.ToInt32(item), (int)KullaniciIslemleriTipEn.Alan_Yetkileri);
                        if (yAlanlarListEski != null)
                        {
                            foreach (var item1 in yAlanlarListEski)
                            {
                                yAlanlarCntrl.Sil(item1.ID, item1);
                            }
                        }
                        if (yAlanlarList != null)
                        {
                            foreach (var item1 in yAlanlarList)
                            {
                                yAlanlarVm = new YetkiAlanlarVm();
                                yAlanlarVm = item1;
                                yAlanlarVm.KULLANICI_ID = Convert.ToInt32(item);
                                yAlanlarCntrl.Ekle(yAlanlarVm);
                            }
                        }
                    }
                }
                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Bilgi_Bazli_Alan_Yetkileri)))
                {
                    YetkiAlanlarCntrl yAlanlarCntrl = new YetkiAlanlarCntrl();
                    List<YetkiAlanlarVm> yAlanlarList = new List<YetkiAlanlarVm>();
                    List<YetkiAlanlarVm> yAlanlarListEski = new List<YetkiAlanlarVm>();
                    YetkiAlanlarVm yAlanlarVm = new YetkiAlanlarVm();
                    yAlanlarList = YetkiAlanlarCek(eskiKullaniciId, (int)KullaniciIslemleriTipEn.Bilgi_Bazli_Alan_Yetkileri);
                    foreach (var item in kullanicilar)
                    {
                        yAlanlarListEski = YetkiAlanlarCek(Convert.ToInt32(item), (int)KullaniciIslemleriTipEn.Bilgi_Bazli_Alan_Yetkileri);
                        if (yAlanlarListEski != null)
                        {
                            foreach (var item1 in yAlanlarListEski)
                            {
                                yAlanlarCntrl.Sil(item1.ID, item1);
                            }
                        }
                        if (yAlanlarList != null)
                        {
                            foreach (var item1 in yAlanlarList)
                            {
                                yAlanlarVm = new YetkiAlanlarVm();
                                yAlanlarVm = item1;
                                yAlanlarVm.KULLANICI_ID = Convert.ToInt32(item);
                                yAlanlarCntrl.Ekle(yAlanlarVm);
                            }
                        }
                    }
                }
                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Islem_Yetkileri)))
                {
                    YetkiIslemlerCntrl yetkiIslemlerCntrl = new YetkiIslemlerCntrl();
                    List<YetkiIslemlerVm> yetkiIslemlerList = new List<YetkiIslemlerVm>();
                    List<YetkiIslemlerVm> yetkiIslemlerListEski = new List<YetkiIslemlerVm>();
                    YetkiIslemlerVm yetkiIslemlerVm = new YetkiIslemlerVm();
                    yetkiIslemlerVm.KULLANICI_ID = eskiKullaniciId;
                    yetkiIslemlerVm.ID = id;
                    yetkiIslemlerList = yetkiIslemlerCntrl.Liste_Al(yetkiIslemlerVm);
                    foreach (var item in kullanicilar)
                    {
                        if (yetkiIslemlerList != null)
                        {
                            foreach (var item1 in yetkiIslemlerList)
                            {
                                if (yapilcakIslemTip == (int)KullaniciListeSecimTipEn.Hepsi)
                                {
                                    KullaniciIslemListeYetkiKopyala(item1, true, (int)IslemListeEn.ISLEM);
                                }
                                yetkiIslemlerVm.KULLANICI_ID = Convert.ToInt32(item);
                                yetkiIslemlerVm.ID = 0;
                                yetkiIslemlerVm.YETKI_ISLEM_TANTIM_ID = item1.YETKI_ISLEM_TANTIM_ID;
                                yetkiIslemlerListEski = yetkiIslemlerCntrl.Liste_Al(yetkiIslemlerVm);
                                if (yetkiIslemlerListEski != null && yetkiIslemlerListEski.Count > 0)
                                {
                                    yetkiIslemlerListEski[0].YETKILI_E_H = item1.YETKILI_E_H;
                                    yetkiIslemlerCntrl.Guncelle(yetkiIslemlerListEski[0], yetkiIslemlerListEski[0].ID);
                                    if (yapilcakIslemTip == (int)KullaniciListeSecimTipEn.Hepsi)
                                    {
                                        KullaniciIslemListeYetkiKopyala(yetkiIslemlerListEski[0], true, (int)IslemListeEn.ISLEM);
                                    }
                                }
                                else
                                {
                                    yetkiIslemlerVm = new YetkiIslemlerVm();
                                    yetkiIslemlerVm = item1;
                                    yetkiIslemlerVm.KULLANICI_ID = Convert.ToInt32(item);
                                    yetkiIslemlerCntrl.Ekle(yetkiIslemlerVm);
                                    if (yapilcakIslemTip == (int)KullaniciListeSecimTipEn.Hepsi)
                                    {
                                        KullaniciIslemListeYetkiKopyala(yetkiIslemlerVm, true, (int)IslemListeEn.ISLEM);
                                    }
                                }
                            }
                        }
                    }
                }
                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Menu_Yetkileri)))
                {
                    YetkiMenulerCntrl yetkiMenulerCntrl = new YetkiMenulerCntrl();
                    List<YetkiMenulerVm> yetkiMenulerList = new List<YetkiMenulerVm>();
                    List<YetkiMenulerVm> yetkiMenulerListEski = new List<YetkiMenulerVm>();
                    YetkiMenulerVm yetkiMenulerVm = new YetkiMenulerVm();
                    yetkiMenulerVm.KULLANICI_ID = eskiKullaniciId;
                    yetkiMenulerList = yetkiMenulerCntrl.Liste_Al(yetkiMenulerVm);
                    foreach (var item in kullanicilar)
                    {
                        yetkiMenulerVm.KULLANICI_ID = Convert.ToInt32(item);
                        yetkiMenulerListEski = yetkiMenulerCntrl.Liste_Al(yetkiMenulerVm);
                        if (yetkiMenulerListEski != null)
                        {
                            foreach (var item1 in yetkiMenulerListEski)
                            {
                                yetkiMenulerCntrl.Sil(item1.ID, item1);
                            }
                        }
                        if (yetkiMenulerList != null)
                        {
                            foreach (var item1 in yetkiMenulerList)
                            {
                                yetkiMenulerVm = new YetkiMenulerVm();
                                yetkiMenulerVm = item1;
                                yetkiMenulerVm.KULLANICI_ID = Convert.ToInt32(item);
                                yetkiMenulerCntrl.Ekle(yetkiMenulerVm);
                            }
                        }
                    }
                }


                if (yapilcakIslem.Contains(Convert.ToString((int)KullaniciIslemleriTipEn.Kullanici_Dinamik_Yetkiler)))
                {
                    //KullaniciYetkileriCntrl kullaniciYetkileriCntrl = new KullaniciYetkileriCntrl();
                    //List<KullaniciYetkileriVm> kullaniciYetkileriList = new List<KullaniciYetkileriVm>();
                    //List<KullaniciYetkileriVm> kullaniciYetkileriListEski = new List<KullaniciYetkileriVm>();
                    //KullaniciYetkileriVm kullaniciYetkileriVm = new KullaniciYetkileriVm();
                    //kullaniciYetkileriVm.KULLANICI_ID = eskiKullaniciId;
                    //kullaniciYetkileriList = kullaniciYetkileriCntrl.Liste_Al(kullaniciYetkileriVm);
                    //foreach (var item in kullanicilar)
                    //{
                    //    kullaniciYetkileriVm.KULLANICI_ID = Convert.ToInt32(item);
                    //    kullaniciYetkileriListEski = kullaniciYetkileriCntrl.Liste_Al(kullaniciYetkileriVm);
                    //    if (kullaniciYetkileriListEski != null)
                    //    {
                    //        foreach (var item1 in kullaniciYetkileriListEski)
                    //        {
                    //            kullaniciYetkileriCntrl.Sil(item1.ID, item1);
                    //        }
                    //    }
                    //    if (kullaniciYetkileriList != null)
                    //    {
                    //        foreach (var item1 in kullaniciYetkileriList)
                    //        {
                    //            kullaniciYetkileriVm = new KullaniciYetkileriVm();
                    //            kullaniciYetkileriVm = item1;
                    //            kullaniciYetkileriVm.KULLANICI_ID = Convert.ToInt32(item);
                    //            kullaniciYetkileriCntrl.Ekle(kullaniciYetkileriVm);
                    //        }
                    //    }
                    //}
                }

            }

        }
        public static void KullaniciAlanBilgileriKopyala(Dictionary<string, string> parameterIslemler, string[] kullanicilar)
        {
            int yetkiAlanId = Convert.ToInt32(parameterIslemler["KAYNAK_ID"]);
            int eskiKullaniciId = Convert.ToInt32(parameterIslemler["ESKI_KULLANICI_ID"]);
            YetkiAlanlarCntrl yetkiAlanlarCntrl = new YetkiAlanlarCntrl();
            List<YetkiAlanlarVm> yetkiAlanlarList = new List<YetkiAlanlarVm>();
            List<YetkiAlanlarVm> yetkiAlanlarListEski = new List<YetkiAlanlarVm>();
            YetkiAlanlarVm yetkiAlanlarVm = new YetkiAlanlarVm();
            yetkiAlanlarVm.M_ALANLAR_ID = yetkiAlanId;
            yetkiAlanlarVm.KULLANICI_ID = eskiKullaniciId;
            yetkiAlanlarList = yetkiAlanlarCntrl.Liste_Al(yetkiAlanlarVm);
            foreach (var item in kullanicilar)
            {
                if (yetkiAlanlarList != null)
                {
                    foreach (var item1 in yetkiAlanlarList)
                    {
                        yetkiAlanlarVm = new YetkiAlanlarVm();
                        yetkiAlanlarVm.KULLANICI_ID = Convert.ToInt32(item);
                        yetkiAlanlarVm.M_ALANLAR_ID = item1.M_ALANLAR_ID;
                        yetkiAlanlarListEski = yetkiAlanlarCntrl.Liste_Al(yetkiAlanlarVm);
                        if (yetkiAlanlarListEski != null && yetkiAlanlarListEski.Count > 0)
                        {
                            yetkiAlanlarListEski[0].GORMESIN_E_H = item1.GORMESIN_E_H;
                            yetkiAlanlarListEski[0].YAZMASIN_E_H = item1.YAZMASIN_E_H;
                            yetkiAlanlarListEski[0].LK_DURUM_ID = item1.LK_DURUM_ID;
                            yetkiAlanlarCntrl.Guncelle(yetkiAlanlarListEski[0], yetkiAlanlarListEski[0].ID);
                        }
                        else
                        {
                            yetkiAlanlarVm = new YetkiAlanlarVm();
                            yetkiAlanlarVm = item1;
                            yetkiAlanlarVm.KULLANICI_ID = Convert.ToInt32(item);
                            yetkiAlanlarCntrl.Ekle(yetkiAlanlarVm);
                        }
                    }
                }
            }
        }
        public static void KullaniciBilgiBazliAlanBilgileriKopyala(Dictionary<string, string> parameterIslemler, string[] kullanicilar)
        {
            int yetkiAlanId = Convert.ToInt32(parameterIslemler["KAYNAK_ID"]);
            int yetkiAlanlarAltId = Convert.ToInt32(parameterIslemler["KAYNAK_ALANLAR_ALT_ID"]);
            int eskiKullaniciId = Convert.ToInt32(parameterIslemler["ESKI_KULLANICI_ID"]);
            YetkiAlanlarBilgiCntrl yetkiAlanlarCntrl = new YetkiAlanlarBilgiCntrl();
            List<YetkiAlanlarBilgiVm> yetkiAlanlarList = new List<YetkiAlanlarBilgiVm>();
            List<YetkiAlanlarBilgiVm> yetkiAlanlarListEski = new List<YetkiAlanlarBilgiVm>();
            YetkiAlanlarBilgiVm yetkiAlanlarVm = new YetkiAlanlarBilgiVm();
            yetkiAlanlarVm.M_ALANLAR_ID = yetkiAlanId;
            yetkiAlanlarVm.M_ALANLAR_ALT_ID = yetkiAlanlarAltId;
            yetkiAlanlarVm.KULLANICI_ID = eskiKullaniciId;
            yetkiAlanlarList = yetkiAlanlarCntrl.Liste_Al(yetkiAlanlarVm);
            foreach (var item in kullanicilar)
            {
                if (yetkiAlanlarList != null)
                {
                    foreach (var item1 in yetkiAlanlarList)
                    {
                        yetkiAlanlarVm = new YetkiAlanlarBilgiVm();
                        yetkiAlanlarVm.KULLANICI_ID = Convert.ToInt32(item);
                        yetkiAlanlarVm.M_ALANLAR_ID = item1.M_ALANLAR_ID;
                        yetkiAlanlarVm.M_ALANLAR_ALT_ID = yetkiAlanlarAltId;
                        yetkiAlanlarListEski = yetkiAlanlarCntrl.Liste_Al(yetkiAlanlarVm);
                        if (yetkiAlanlarListEski != null && yetkiAlanlarListEski.Count > 0)
                        {
                            yetkiAlanlarListEski[0].GORMESIN_E_H = item1.GORMESIN_E_H;
                            yetkiAlanlarListEski[0].YAZMASIN_E_H = item1.YAZMASIN_E_H;
                            yetkiAlanlarListEski[0].LK_DURUM_ID = item1.LK_DURUM_ID;
                            yetkiAlanlarCntrl.Guncelle(yetkiAlanlarListEski[0], yetkiAlanlarListEski[0].ID);
                        }
                        else
                        {
                            yetkiAlanlarVm = new YetkiAlanlarBilgiVm();
                            yetkiAlanlarVm = item1;
                            yetkiAlanlarVm.KULLANICI_ID = Convert.ToInt32(item);
                            yetkiAlanlarCntrl.Ekle(yetkiAlanlarVm);
                        }
                    }
                }
            }
        }
        public static void KullaniciMenuKopyala(Dictionary<string, string> parameterIslemler, string[] kullanicilar)
        {
            int menuId = Convert.ToInt32(parameterIslemler["KAYNAK_ID"]);
            int eskiKullaniciId = 0;
            if (parameterIslemler.ContainsKey("ESKI_KULLANICI_ID"))
            {
                eskiKullaniciId = Convert.ToInt32(parameterIslemler["ESKI_KULLANICI_ID"]);
            }
            YetkiMenulerCntrl yetkiMenulerCntrl = new YetkiMenulerCntrl();
            List<YetkiMenulerVm> yetkiMenulerList = new List<YetkiMenulerVm>();
            List<YetkiMenulerVm> yetkiMenulerListEski = new List<YetkiMenulerVm>();
            YetkiMenulerVm yetkiMenulerVm = new YetkiMenulerVm();
            yetkiMenulerVm.M_MENU_ID = menuId;
            yetkiMenulerVm.KULLANICI_ID = eskiKullaniciId;
            yetkiMenulerList = yetkiMenulerCntrl.Liste_Al(yetkiMenulerVm);
            foreach (var item in kullanicilar)
            {
                if (yetkiMenulerList != null)
                {
                    foreach (var item1 in yetkiMenulerList)
                    {
                        yetkiMenulerVm = new YetkiMenulerVm();
                        yetkiMenulerVm.KULLANICI_ID = Convert.ToInt32(item);
                        yetkiMenulerVm.M_MENU_ID = item1.M_MENU_ID;
                        yetkiMenulerListEski = yetkiMenulerCntrl.Liste_Al(yetkiMenulerVm);
                        if (yetkiMenulerListEski != null && yetkiMenulerListEski.Count > 0)
                        {
                            yetkiMenulerListEski[0].OKU_E_H = item1.OKU_E_H;
                            yetkiMenulerListEski[0].YAZ_E_H = item1.YAZ_E_H;
                            yetkiMenulerListEski[0].SIL_E_H = item1.SIL_E_H;
                            yetkiMenulerListEski[0].GUNCELLE_E_H = item1.GUNCELLE_E_H;
                            yetkiMenulerListEski[0].GORMESIN_E_H = item1.GORMESIN_E_H;
                            yetkiMenulerListEski[0].LK_DURUM_ID = item1.LK_DURUM_ID;
                            yetkiMenulerCntrl.Guncelle(yetkiMenulerListEski[0], yetkiMenulerListEski[0].ID);
                        }
                        else
                        {
                            yetkiMenulerVm = new YetkiMenulerVm();
                            yetkiMenulerVm = item1;
                            yetkiMenulerVm.KULLANICI_ID = Convert.ToInt32(item);
                            yetkiMenulerCntrl.Ekle(yetkiMenulerVm);
                        }
                    }
                }
                else
                {
                    yetkiMenulerVm = new YetkiMenulerVm();
                    yetkiMenulerVm.KULLANICI_ID = Convert.ToInt32(item);
                    yetkiMenulerListEski[0].GORMESIN_E_H = (int)EvetHayirEn.Evet;
                    yetkiMenulerListEski[0].LK_DURUM_ID = (int)DurumEn.Aktif;
                    yetkiMenulerVm.KULLANICI_ID = Convert.ToInt32(item);
                    yetkiMenulerCntrl.Ekle(yetkiMenulerVm);
                }
            }
        }
        public static void MenuYetkileriniKopyala(YetkiMenulerVm k)
        {
            YetkiMenulerCntrl yetkiMenulerCntrl = new YetkiMenulerCntrl();
            List<YetkiMenulerVm> yetkiMenulerList = new List<YetkiMenulerVm>();
            List<YetkiMenulerVm> yetkiMenulerListEski = new List<YetkiMenulerVm>();
            YetkiMenulerVm yetkiMenulerVm = new YetkiMenulerVm();
            using (b2cEntities context = new b2cEntities())
            {
                var list = (from d in context.YETKI
                            where d.M_MENU.M_MENU_ID == k.M_MENU_ID && d.KULLANICI_ID == k.KULLANICI_ID
                            select new YetkiMenulerVm
                            {
                                ID = d.ID
                            }).ToList();
                foreach (var item in list)
                {
                    yetkiMenulerCntrl.Sil(item.ID, item);
                }
            }
            MenulerCntrl menuCntrl = new MenulerCntrl();
            List<MenulerVm> menuList = new List<MenulerVm>();
            MenulerVm Vm = new MenulerVm();
            Vm.M_MENU_ID = k.M_MENU_ID;
            menuList = menuCntrl.Liste_Al(Vm);
            foreach (var item1 in menuList)
            {
                YetkiMenulerVm vmYetki = k;
                vmYetki.M_MENU_ID = item1.ID;
                yetkiMenulerCntrl.Ekle(vmYetki);
            }
        }
        public static void KullaniciIslemListeYetkiKopyala(YetkiIslemlerVm Vm, bool sahibineKopyala, int islemListeId)
        {
            List<YetkiIslemlerVm> list = new List<YetkiIslemlerVm>();
            YetkiIslemlerVm yetkiIslemlerVm = new YetkiIslemlerVm();
            YetkiIslemlerCntrl yetkiIslemlerCntrl = new YetkiIslemlerCntrl();
            using (b2cEntities context = new b2cEntities())
            {
                if (sahibineKopyala == true)
                {
                    list = (from d in context.YETKI_ISLEMLER
                            where d.YETKI_ISLEM_TANITIM.YETKI_ISLEM_SAHIBI_TANITIM.AD == Vm.YETKILI_ISLEM_SAHIBI_AD && d.KULLANICI_ID == Vm.KULLANICI_ID && d.YETKI_ISLEM_TANITIM.YETKI_ISLEM_SAHIBI_TANITIM.YETKI_ISLEM_SAHIBI_TIP_ID == islemListeId
                            && d.ID != Vm.ID
                            select new YetkiIslemlerVm
                            {
                                ID = d.ID,
                                YETKI_ISLEM_TANTIM_ID = d.YETKI_ISLEM_TANTIM_ID
                            }).ToList();
                }
                else
                {
                    list = (from d in context.YETKI_ISLEMLER
                            where d.KULLANICI_ID == Vm.KULLANICI_ID && d.YETKI_ISLEM_TANITIM.YETKI_ISLEM_SAHIBI_TANITIM.YETKI_ISLEM_SAHIBI_TIP_ID == islemListeId
                            select new YetkiIslemlerVm
                            {
                                ID = d.ID,
                                YETKI_ISLEM_TANTIM_ID = d.YETKI_ISLEM_TANTIM_ID
                            }).ToList();
                }
                foreach (var item in list)
                {
                    yetkiIslemlerVm = new YetkiIslemlerVm();
                    yetkiIslemlerVm = Vm;
                    yetkiIslemlerVm.ID = item.ID;
                    yetkiIslemlerVm.YETKI_ISLEM_TANTIM_ID = item.YETKI_ISLEM_TANTIM_ID;
                    yetkiIslemlerCntrl.Guncelle(yetkiIslemlerVm, yetkiIslemlerVm.ID);
                }
            }
        }
        public static void KullaniciOzelListelerKopyala(Dictionary<string, string> parameterIslemler, string[] kullanicilar)
        {
            string[] dizi = parameterIslemler["RAPOR"].Split('-');
            string formAdi = dizi[0];
            string raporAdi = dizi[1];
            int eskiKullaniciId = Convert.ToInt32(parameterIslemler["ESKI_KULLANICI_ID"]);
            FiltrelerCntrl FiltrelerCntrl = new FiltrelerCntrl();
            List<FiltrelerVm> FiltrelerList = new List<FiltrelerVm>();
            List<FiltrelerVm> FiltrelerListEski = new List<FiltrelerVm>();
            FiltrelerVm FiltrelerVm = new FiltrelerVm();
            FiltrelerVm.FORM_ADI = formAdi;
            FiltrelerVm.RAPOR_ADI = raporAdi;
            FiltrelerVm.KULLANICI_ID = eskiKullaniciId;
            FiltrelerList = FiltrelerCntrl.Liste_Al(FiltrelerVm);
            foreach (var item in kullanicilar)
            {
                if (FiltrelerList != null)
                {
                    foreach (var item1 in FiltrelerList)
                    {
                        FiltrelerVm = new FiltrelerVm();
                        FiltrelerVm.KULLANICI_ID = Convert.ToInt32(item);
                        FiltrelerVm.FORM_ADI = item1.FORM_ADI;
                        FiltrelerVm.RAPOR_ADI = item1.RAPOR_ADI;
                        FiltrelerVm.FILTRE_TIP_ID = item1.FILTRE_TIP_ID;  //31.01.2014 te eklendi detay liste kopyalama yaptığımızda veritabanında default 1 tanımlı olduğu için listeyi detay calısmaya degil ön ekrandaki filtreye ekliyordu
                        FiltrelerListEski = FiltrelerCntrl.Liste_Al(FiltrelerVm);
                        if (FiltrelerListEski != null && FiltrelerListEski.Count > 0)
                        {
                            FiltrelerListEski[0].DEGER_ALANI = item1.DEGER_ALANI;
                            FiltrelerListEski[0].LK_DURUM_ID = item1.LK_DURUM_ID;
                            FiltrelerListEski[0].FILTRE_OLUSTURAN_KULLANICI_ID = item1.ID;
                            FiltrelerCntrl.Guncelle(FiltrelerListEski[0], FiltrelerListEski[0].ID);
                        }
                        else
                        {
                            FiltrelerVm.FILTRE_OLUSTURAN_KULLANICI_ID = item1.ID;
                            FiltrelerVm.DEGER_ALANI = item1.DEGER_ALANI;
                            FiltrelerCntrl.Ekle(FiltrelerVm);
                        }
                    }
                }
            }
        }


        static List<YetkiAlanlarVm> YetkiAlanlarCek(int kullaniciId, int yetkiTipId)
        {
            using (b2cEntities context = new b2cEntities())
            {
                if (yetkiTipId == (int)KullaniciIslemleriTipEn.Alan_Yetkileri)
                {
                    var list = (from ya in context.YETKI_ALANLAR
                                where ya.KULLANICI_ID == kullaniciId && ya.M_ALANLAR_ALT_ID == null
                                select new YetkiAlanlarVm
                                {
                                    ID = ya.ID,
                                    KULLANICI_ID = ya.KULLANICI_ID,
                                    M_ALANLAR_ALT_ID = ya.M_ALANLAR_ALT_ID,
                                    M_ALANLAR_ID = ya.M_ALANLAR_ID,
                                    GORMESIN_E_H = ya.GORMESIN_E_H,
                                    YAZMASIN_E_H = ya.YAZMASIN_E_H,
                                    LK_DURUM_ID = ya.LK_DURUM_ID,
                                }).ToList();
                    return list;
                }
                else
                {
                    var list = (from ya in context.YETKI_ALANLAR
                                where ya.KULLANICI_ID == kullaniciId && ya.M_ALANLAR_ALT_ID != null
                                select new YetkiAlanlarVm
                                {
                                    ID = ya.ID,
                                    KULLANICI_ID = ya.KULLANICI_ID,
                                    M_ALANLAR_ALT_ID = ya.M_ALANLAR_ALT_ID,
                                    M_ALANLAR_ID = ya.M_ALANLAR_ID,
                                    GORMESIN_E_H = ya.GORMESIN_E_H,
                                    YAZMASIN_E_H = ya.YAZMASIN_E_H,
                                    LK_DURUM_ID = ya.LK_DURUM_ID,
                                }).ToList();
                    return list;

                }
            }

        }

        static List<YetkiIslemlerVm> YetkiIslemlerCek(int kullaniciId, int IslemListeId)
        {
            using (b2cEntities context = new b2cEntities())
            {

                var list = (from ya in context.YETKI_ISLEMLER
                            where ya.KULLANICI_ID == kullaniciId && ya.YETKI_ISLEM_TANITIM.YETKI_ISLEM_SAHIBI_TANITIM.YETKI_ISLEM_SAHIBI_TIP_ID == IslemListeId
                            select new YetkiIslemlerVm
                            {
                                ID = ya.ID,
                                KULLANICI_ID = ya.KULLANICI_ID,
                                YETKILI_E_H = ya.YETKILI_E_H,
                                YETKI_ISLEM_TANTIM_ID = ya.YETKI_ISLEM_TANTIM_ID,
                            }).ToList();
                return list;
            }

        }


        public static KontrolVm SifreDegistir(string eskiSifre, string yeniSifre)
        {
            KontrolVm kn = new KontrolVm();
            if (yeniSifre == "")
            {
                kn.DONUS_TIP = (int)KontrolEn.ENGELLE;
                kn.DONUS_MESAJ = "Yeni Şifreyi Giriniz";
                return kn;
            }
            else if (eskiSifre == "")
            {
                kn.DONUS_TIP = (int)KontrolEn.ENGELLE;
                kn.DONUS_MESAJ = "Eski Şifreyi Giriniz";
                return kn;
            }
            KullaniciCntrl cntrl = new KullaniciCntrl();
            List<KullaniciVm> listVm = new List<KullaniciVm>();
            listVm = cntrl.Liste_Al(new KullaniciVm { KULLANICI_AD = Globals.gnKullaniciAd, SIFRE = eskiSifre, ID = Globals.gnKullaniciId,LK_DURUM_ID=(int)DurumEn.Aktif });
            if (listVm.Count > 0)
            {
                listVm = listVm.Where(w => w.ID == Globals.gnKullaniciId).ToList();
                if (listVm.Count == 1)
                {
                    listVm[0].SIFRE = yeniSifre;
                    cntrl.Guncelle(listVm[0], listVm[0].ID);
                }
                kn.DONUS_TIP = (int)KontrolEn.DEVAM_ET;
                return kn;
            }
            else
            {
                kn.DONUS_TIP = (int)KontrolEn.ENGELLE;
                kn.DONUS_MESAJ = "Kullanıcı Bulunamadı";
                return kn;
            }
        }

        public static int GetMaxAlanId()
        {
            using (b2cEntities context = new b2cEntities())
            {
                var id = (from k in context.M_ALANLAR
                          where k.ID < 20000
                          select k.ID).Max();
                return id + 1;
            }
        }


        public static List<LogDetayVm> GetLogDetay(string kod)
        {
            int length = kod.Length;
            using (b2cEntities context = new b2cEntities())
            {
                var list = (from lg in context.Log
                            where lg.Level == "INFO"
                            && lg.Message.Substring(0, length) == kod
                            select new LogIlkVm
                            {
                                Date = lg.Date,
                                Message = lg.Message
                            }).ToList();
                return GetLogAyrinti(list);
            }
        }
        public static List<LogDetayVm> GetLogDetay(string kod,int id)
        {
            int length = kod.Length;
            using (b2cEntities context = new b2cEntities())
            {
                var list = (from lg in context.Log
                            where lg.Level == "INFO"
                            && lg.Message.Substring(0, length) == kod
                            select new LogIlkVm
                            {
                                Date = lg.Date,
                                Message = lg.Message
                            }).ToList();
                List<LogDetayVm> listDonus = GetLogAyrinti(list).Where(w=>w.ID==id).ToList();
                return listDonus;
            }
        }

        public static object GetLog(DateTime dateTime, DateTime dateTime_2, string p, string p_2)
        {
            using (b2cEntities context = new b2cEntities())
            {
                List<LogIlkVm> listSon = new List<LogIlkVm>();
                var list = (from lg in context.Log
                            where lg.Date >= dateTime && lg.Date <= dateTime_2
                            select new
                            {
                                Date = lg.Date,
                                Message = lg.Message,
                                Kullanici = lg.Logger,
                                Tablo = "",
                                Level = lg.Level,
                            }).ToList();
                return list;
            }
        }
        public static List<LogDetayVm> GetLogDetay(DateTime dateTime, DateTime dateTime_2,string kullanici,string tablo)
        {
            using (b2cEntities context = new b2cEntities())
            {
                string sql = "";
                sql = QueryOlustur.querylistString("", kullanici.Split(','), "Kullanici");
                if (sql != "")
                {
                    sql += QueryOlustur.querylistString(sql, tablo.Split(','), "Tablo");
                }
                else
                {
                    sql = QueryOlustur.querylistString("", tablo.Split(','), "Tablo");                        
                }
                sql = sql == "" ? "Kullanici!=\"\"" : sql;
                List<LogIlkVm> listSon = new List<LogIlkVm>();
                var list = (from lg in context.Log
                            where lg.Level == "INFO"
                            && lg.Date >= dateTime && lg.Date <= dateTime_2
                            select new LogIlkVm
                            {
                                Date = lg.Date,
                                Message = lg.Message,
                                Tablo=lg.Thread,
                                Kullanici=lg.Logger
                            }).Where(sql).ToList();
                foreach (var item in list)
                {
                    string[] selected = item.Message.ToString().Split('‡');
                    foreach (var item1 in selected)
                    {
                        if (item1 != "")
                        {
                            string[] a = item1.Split('»');
                            if (a[0] != "Alan" && a[0] != "Işlem" && a[0] != "Kullanici" && a[0] != "IslemNedeni" && a[0] != "ID")
                            {
                                string[] sonuc = a[0].Split('#');
                                if (sonuc.Length > 1)
                                    item.Tablo = sonuc[0];
                            }
                            else if (a[0] == "Kullanici")
                            {
                                if (a.Length > 0)
                                    item.Kullanici = a[1];
                            }
                        }
                    }
                    if (kullanici!="" && YardimciIslemler.IcindeVarMi(kullanici,item.Kullanici)==false)
                    {
                        continue;
                    }
                    if (tablo!="" && YardimciIslemler.IcindeVarMi(tablo, item.Tablo) == false)
                    {
                        continue;
                    }
                    listSon.Add(item);
                }
                
                //var list1 = (from lst in list
                //            select new LogIlkVm
                //            {
                //                Date = lst.Date,
                //                Message = lst.Message,
                //                Kullanıcı = lst.Kullanıcı,
                //                Tablo = lst.Tablo,
                //            }).Where(filtre).ToList();
                return GetLogAyrinti(listSon);
            }
        }
        public static List<LogDetayVm> GetLogDetayeski(DateTime dateTime, DateTime dateTime_2, string kullanici, string tablo)
        {
            using (b2cEntities context = new b2cEntities())
            {
                //kullanici = QueryOlustur.queryTekAlan("", kullanici.Split(','), "Kullanıcı");
                //tablo = QueryOlustur.queryTekAlan("", tablo.Split(','), "Tablo");

                //string filtre = "";
                //if (kullanici != "")
                //{
                //    filtre = kullanici;
                //    if (tablo != "")
                //    {
                //        filtre += " AND " + tablo;
                //    }
                //}
                //else
                //{
                //    if (tablo != "")
                //    {
                //        filtre = tablo;
                //    }
                //}
                List<LogIlkVm> listSon = new List<LogIlkVm>();
                var list = (from lg in context.Log
                            where lg.Level == "INFO"
                            && lg.Date >= dateTime && lg.Date <= dateTime_2
                            select new LogIlkVm
                            {
                                Date = lg.Date,
                                Message = lg.Message
                            }).ToList();
                foreach (var item in list)
                {
                    string[] selected = item.Message.ToString().Split('‡');
                    foreach (var item1 in selected)
                    {
                        if (item1 != "")
                        {
                            string[] a = item1.Split('»');
                            if (a[0] != "Alan" && a[0] != "Işlem" && a[0] != "Kullanici" && a[0] != "IslemNedeni" && a[0] != "ID")
                            {
                                string[] sonuc = a[0].Split('#');
                                if (sonuc.Length > 1)
                                    item.Tablo = sonuc[0];
                            }
                            else if (a[0] == "Kullanici")
                            {
                                if (a.Length > 0)
                                    item.Kullanici = a[1];
                            }
                        }
                    }
                    if (kullanici != "" && YardimciIslemler.IcindeVarMi(kullanici, item.Kullanici) == false)
                    {
                        continue;
                    }
                    if (tablo != "" && YardimciIslemler.IcindeVarMi(tablo, item.Tablo) == false)
                    {
                        continue;
                    }
                    listSon.Add(item);
                }

                //var list1 = (from lst in list
                //            select new LogIlkVm
                //            {
                //                Date = lst.Date,
                //                Message = lst.Message,
                //                Kullanıcı = lst.Kullanıcı,
                //                Tablo = lst.Tablo,
                //            }).Where(filtre).ToList();
                return GetLogAyrinti(listSon);
            }
        }
        public static List<LogDetayVm> GetLogDetay(DateTime dateTime, DateTime dateTime_2)
        {
            using (b2cEntities context = new b2cEntities())
            {
                List<LogIlkVm> listSon = new List<LogIlkVm>();
                var list = (from lg in context.Log
                            where lg.Level == "INFO"
                            && lg.Date >= dateTime && lg.Date <= dateTime_2
                            select new LogIlkVm
                            {
                                Date = lg.Date,
                                Message = lg.Message
                            }).ToList();
                return GetLogAyrinti(list);
             }
        }

        public static List<LogDetayVm> GetLogAyrinti(List<LogIlkVm> list)
        {
            string kod = "";
            string islemTip = "";
            List<LogDetayVm> listLogDetay = new List<LogDetayVm>();
            LogDetayVm Vm = new LogDetayVm();
            
                foreach (var item in list)
                {
                    string[] selected = item.Message.ToString().Split('‡');
                    Vm = new LogDetayVm();
                    foreach (var item1 in selected)
                    {
                        if (item1 != "")
                        {
                         
                            string[] a = item1.Split('»');
                            if (a[0] != "Alan" && a[0] != "Işlem" && a[0] != "Kullanici" && a[0] != "IslemNedeni" && a[0] != "ID")
                            {
                                string[] sonuc = a[0].Split('#');
                                Vm.TABLO = sonuc[0];
                                if (sonuc.Length == 2)
                                {
                                    if (YardimciIslemler.Strip(sonuc[1])>0)
                                    Vm.ID = Convert.ToInt32(sonuc[1]);
                                }
                            }
                            else if (a[0] == "ID")
                            {
                                if (YardimciIslemler.Strip(a[1]) > 0)                                
                                Vm.AYR = Convert.ToInt32(a[1]);
                            }
                            else if (a[0] == "Kullanici")
                            {
                                Vm.KULLANICI = a[1];
                            }
                            else if (a[0] == "IslemNedeni" && YardimciIslemler.Strip(a[1])>0)
                            {
                                //Vm.ISLEM_NEDEN = Convert.ToString(ListService.GetISLEM_NEDENLERI_ID((int)ListServiceTipEn.LISTEBYIDAD, (int)AktifPasifTumuEn.TUMU, Convert.ToInt32(a[1]), 0, 0, "", "", 0));
                            }
                            else if (a[0] == "Alan")
                            {
                                string strAlan = "";
                                Vm.ALAN = a[1];
                                string[] sonuc = a[1].Split('?');
                                for (int i = 0; i < sonuc.Length; i++)
                                {
                                    string[] sonuc1 = sonuc[i].Split('%');
                                     if (sonuc1.Length == 2)
                                     {
                                         if (sonuc1[0].Length > 3 && sonuc1[0].Substring(sonuc1[0].Length - 3, 3) == "_ID" && YardimciIslemler.Strip(sonuc1[1])>0)
                                         {
                                             int b = Convert.ToInt32(Convert.ToDecimal(sonuc1[1]));
                                             strAlan = Convert.ToString(ListService.InvokeMethod("Get" + sonuc1[0], (int)ListServiceTipEn.LISTEBYIDKODAD, (int)AktifPasifTumuEn.TUMU, b, 0, 0, "", "", 0));
                                             strAlan = strAlan != "" ? strAlan : Vm.ALAN;
                                         }
                                         else
                                         {
                                             strAlan = sonuc1[1];
                                         }
                                     }
                                     if (i==0){Vm.ALAN = strAlan;}
                                     else if (i == 1) { Vm.ALAN_2 = strAlan; }
                                     else if (i == 2) { Vm.ALAN_3 = strAlan; }
                                     else if (i == 3) { Vm.ALAN_4 = strAlan; }
                                     else if (i == 4) { Vm.ALAN_5 = strAlan; }
                                     //else if (i == 5) { Vm.ALAN_5 = strAlan; }
                                }
                              

                            }
                            else if (a[0] == "Işlem")
                            {
                                Vm.ISLEM_TIP = a[1];
                            }
                        }
                    }
              //      Vm = new LogDetayVm();
                    Vm.TARIH = item.Date;
                    listLogDetay.Add(Vm);
                }
            return listLogDetay;
        }
        public static List<LogDetayVm> GetLogDetay(DateTime dateTime, DateTime dateTime_2,string eski)
        {
            string kod = "";
            string islemTip = "";
            List<LogDetayVm> listLogDetay = new List<LogDetayVm>();
            LogDetayVm Vm = new LogDetayVm();
            using (b2cEntities context = new b2cEntities())
            {
                var list = (from lg in context.Log
                            where lg.Level == "INFO"
                            && lg.Date >= dateTime && lg.Date <= dateTime_2
                            select lg).ToList();

                foreach (var item in list)
                {
                    string[] selected = item.Message.ToString().Split('‡');

                    foreach (var item1 in selected)
                    {
                        if (item1 != "")
                        {
                            string[] a = item1.Split('»');
                            if (a[0] == "Tablo")
                            {
                                Vm.TABLO = a[1];
                            }
                            else if (a[0] == "Alan")
                            {
                                Vm.ALAN = a[1];
                                string[] sonuc = a[1].Split(':');
                                if (sonuc.Length == 2)
                                {
                                    if (sonuc[0].Length>3 && sonuc[0].Substring(sonuc[0].Length - 3, 3) == "_ID")
                                    {
                                        string strAlan = Convert.ToString(ListService.InvokeMethod("Get" + sonuc[0], (int)ListServiceTipEn.LISTEBYIDKOD, (int)AktifPasifTumuEn.TUMU, Convert.ToInt32(sonuc[1]), 0, 0, "", "", 0));
                                        Vm.ALAN = strAlan != "" ? strAlan : Vm.ALAN;
                                    }
                                }
                                
                            }
                            else if (a[0] == "Işlem")
                            {
                                Vm.ISLEM_TIP = a[1];
                            }
                        }
                    }
                    Vm = new LogDetayVm();
                    Vm.TARIH = item.Date;
                    listLogDetay.Add(Vm);
                }
            }
            return listLogDetay;
        }




        public static string Filtreolustur(int tabloAlanID, string AlanAdiEk,bool erisim)
        {
            string s = "";
            string sql = "";
            int gormesinEvetHayir = 2;
            b2cEntities context1 = new b2cEntities();
            using (context1)
            {
                var list = (from kul in context1.YETKI_ALANLAR
                            where kul.KULLANICI_ID == Globals.gnKullaniciId  && kul.M_ALANLAR.M_ALANLAR_ID == tabloAlanID
                            group kul by kul.M_ALANLAR_ID into g
                            select new
                            {
                                ID = g.Key,
                                sonuc = g,
                            }).ToList();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        s = "";
                        foreach (var itemIc in item.sonuc)
                        {
                            if (itemIc.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                            {
                                s += itemIc.M_ALANLAR_ALT_ID + ",";
                                gormesinEvetHayir = 1;
                            }
                            else if (itemIc.GORMESIN_E_H == (int)EvetHayirEn.Hayir)
                            {
                                if (erisim == false)
                                {
                                    s += itemIc.M_ALANLAR_ALT_ID + ",";
                                    gormesinEvetHayir = 0;
                                }
                                else if (erisim == true)
                                {
                                    if (itemIc.YAZMASIN_E_H == null || itemIc.YAZMASIN_E_H == (int)EvetHayirEn.Hayir)
                                    {
                                        s += itemIc.M_ALANLAR_ALT_ID + ",";
                                        gormesinEvetHayir = 0;
                                    }
                                }
                              
                            }
                            else if (itemIc.YAZMASIN_E_H == (int)EvetHayirEn.Evet && erisim==true)
                            {
                                s += itemIc.M_ALANLAR_ALT_ID + ",";
                                gormesinEvetHayir = 1;
                            }
                        }
                        string Alan = Convert.ToString(ListService.GetM_ALANLAR_ID((int)ListServiceTipEn.LISTEBYIDAD, (int)AktifPasifTumuEn.TUMU, item.ID, 0, 0, "", "", 0));
                        if (gormesinEvetHayir == 1)
                        {
                            if (s.ToString().Trim() != "" && Alan!="")
                            {
                                sql += sql == "" ? QueryOlustur.querylistTers("", s.ToString().Split(','), AlanAdiEk + Alan) : " AND " + QueryOlustur.querylistTers("", s.ToString().Split(','), AlanAdiEk + Alan);
                            }
                        }
                        else if (gormesinEvetHayir == 0)
                        {
                            if (s.ToString().Trim() != "" && Alan != "")
                            {
                                sql += sql == "" ? QueryOlustur.querylist("", s.ToString().Split(','), AlanAdiEk + Alan) : " AND " + QueryOlustur.querylist("", s.ToString().Split(','), AlanAdiEk + Alan);
                            }
                        }
                    }
                    ListHelper.SonKarakterSil(s);
                }

            }
            //    string sql = QueryOlustur.querylistTers("", s.ToString().Split(','), "CARI_TIP_ID");
            return sql;
        }


        public static string IslemiKullanicilaraKopyala(Dictionary<string, string> parameterIslemler)
        {
            int yetkiIslemTanitimId = Convert.ToInt32(parameterIslemler["YETKI_ISLEM_TANITIM_ID"]);
            int yetkiliEH = Convert.ToInt32(parameterIslemler["YETKILI_E_H"]);
            YetkiIslemTanitimCntrl cntrl = new YetkiIslemTanitimCntrl();
            List<YetkiIslemTanitimVm> vmlist = new List<YetkiIslemTanitimVm>();
            //vm.ID = yetkiIslemTanitimId;
            int kullaniciId=0;
            vmlist = cntrl.Liste_Al(new YetkiIslemTanitimVm { ID = yetkiIslemTanitimId }).ToList();
            if (vmlist.Count > 0)
            {
                YetkiIslemlerCntrl islemCntrl = new YetkiIslemlerCntrl();
                YetkiIslemlerVm islemVm = new YetkiIslemlerVm();
                islemVm.YETKI_ISLEM_TANTIM_ID = yetkiIslemTanitimId;
                //if (islemCntrl.Liste_Al(islemVm).Count > 0)
                    YetkiIslemlerCntrl yetkiIslemlerCntrl = new YetkiIslemlerCntrl();
                    List<YetkiIslemlerVm> yetkiIslemlerList = new List<YetkiIslemlerVm>();
                    List<YetkiIslemlerVm> yetkiIslemlerListEski = new List<YetkiIslemlerVm>();
                    YetkiIslemlerVm yetkiIslemlerVm = new YetkiIslemlerVm();
                    string[] kullanicilar = YardimciIslemler.SplitTrim(parameterIslemler["KULLANICI_ID"]);
                    YardimciIslemler.DizidenCikart("0", kullanicilar);
                    foreach (var item in kullanicilar)
                    {
                        if (Convert.ToInt32(item) == 0) continue;
                        islemVm = new YetkiIslemlerVm();
                        kullaniciId = Convert.ToInt32(item);
                        yetkiIslemlerListEski = yetkiIslemlerCntrl.Liste_Al(new YetkiIslemlerVm { KULLANICI_ID = kullaniciId, YETKI_ISLEM_TANTIM_ID = yetkiIslemTanitimId }).ToList();
                        if (yetkiIslemlerListEski.Count > 0)
                        {
                            islemVm = yetkiIslemlerListEski[0];
                            islemVm.YETKILI_E_H = (byte)yetkiliEH;
                            islemCntrl.Guncelle(islemVm, islemVm.ID);
                        }
                        else
                        {
                            islemVm.KULLANICI_ID = Convert.ToInt32(item);
                            islemVm.YETKILI_E_H = (byte)yetkiliEH;
                            islemVm.YETKI_ISLEM_TANTIM_ID = yetkiIslemTanitimId;
                            islemCntrl.Ekle(islemVm);
                        }
                    }
                //}
                //else
                //{

                //    YetkiIslemlerCntrl yetkiIslemlerCntrl = new YetkiIslemlerCntrl();
                //    List<YetkiIslemlerVm> yetkiIslemlerList = new List<YetkiIslemlerVm>();
                //    List<YetkiIslemlerVm> yetkiIslemlerListEski = new List<YetkiIslemlerVm>();
                //    YetkiIslemlerVm yetkiIslemlerVm = new YetkiIslemlerVm();
                //    string[] kullanicilar = YardimciIslemler.SplitTrim(parameterIslemler["KULLANICI_ID"]);
                //    foreach (var item in kullanicilar)
                //    {
                //        islemVm.KULLANICI_ID = Convert.ToInt32(item);
                //        islemVm.YETKILI_E_H = (byte)yetkiliEH;
                //        islemVm.YETKI_ISLEM_TANTIM_ID = yetkiIslemTanitimId;
                //        islemCntrl.Ekle(islemVm);
                       
                //    }
                //}
            }
            return "";
        }

        public static void KullaniciMesajYaz(string not, string not1, string not2, string[] kullanicilar, string islem)
        {
            if (islem == "ROL")
            {
                string[] Roller = kullanicilar;
                kullanicilar = ListDenemeService.GetKullaniciByRol(Roller);
                //kullanicilar = YardimciIslemler.DizidenCikart(eskiKullaniciId.ToString(), kullaniciID);
            }
            MesajCntrl yAlanlarCntrl = new MesajCntrl();
            List<MesajVm> yAlanlarList = new List<MesajVm>();
            MesajVm yAlanlarVm = new MesajVm();
            foreach (var item in kullanicilar)
            {
                        yAlanlarVm = new MesajVm();
                        yAlanlarVm.KIME_KULLANICI_ID = Convert.ToInt32(item);
                        yAlanlarVm.KIMDEN_KULLANICI_ID = Globals.gnKullaniciId;
                        yAlanlarVm.MESAJ = not;
                        yAlanlarVm.MESAJ_2 = not;
                        yAlanlarVm.MESAJ_3 = not;
                        yAlanlarVm.OKUNDU_E_H = (int)EvetHayirEn.Hayir;
                        yAlanlarCntrl.Ekle(yAlanlarVm);
            }
        }


        

    }
    public class LogDetayVm
    {
        public string TABLO { get; set; }
        public string KULLANICI { get; set; }
        public string ALAN { get; set; }
        public string ALAN_2 { get; set; }
        public string ALAN_3 { get; set; }
        public string ALAN_4 { get; set; }
        public string ALAN_5 { get; set; }
        public DateTimeOffset? TARIH { get; set; }
        public string ISLEM_TIP { get; set; }
        public string ISLEM_NEDEN { get; set; }
        public int AYR { get; set; }
        public int ID { get; set; }
    }

    public class LogVm
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }

    //public class LogIlkVm
    //{
    //    public string Message { get; set; }
    //    public string Level { get; set; }
    //    public string Kullanici { get; set; }
    //    public string Tablo { get; set; }
    //    public DateTime Date { get; set; }
    //    public int id { get; set; }
    //}
}
