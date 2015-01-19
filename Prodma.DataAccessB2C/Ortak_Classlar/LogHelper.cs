using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.SistemB2C.Services;
using Prodma.DataAccessB2C;
using Prodma.SistemB2C.Controllers;
using Prodma.SistemB2C.Models;
namespace Prodma
{
    public class LogHelperB2C
    {
      
        public LogHelperB2C()
        {
            

            //testLogger.Debug("THis is sadi's world!");
            //testLogger.Info("How beautyful the console looks like");
            //testLogger.Warn("You are great you did this");
            //logger.LogError("Who make you know is the best");
            //testLogger.Fatal("sadi the great");
        }
        public static void LogError(string Mesaj)
        {
            KullaniciService srv = new KullaniciService();
            Log ent = new Log();
            ent.Date = DateTime.Now;
            ent.Message =Mesaj;
            ent.Thread = "";
            ent.Level = "ERROR";
            ent.Logger = Globals.gnKullaniciAd;
            ent.Exception = "";
            srv.Log_Kayit(ent);
        }

        public static void LogInfoMessage(string Mesaj)
        {
            KullaniciService srv = new KullaniciService();
            Log ent = new Log();
            ent.Date = DateTime.Now;
            ent.Message = Mesaj;
            ent.Thread = "";
            ent.Level = "INFO";
            ent.Logger = Globals.gnKullaniciAd!=null ? Globals.gnKullaniciAd : "";
            ent.Exception = "";
            srv.Log_Kayit(ent);
        }

        public static void LogError(string Mesaj,string tabloAdi)
        {
            KullaniciService srv = new KullaniciService();
            Log ent = new Log();
            ent.Date = DateTime.Now;
            ent.Message = Mesaj;
            ent.Thread = tabloAdi;
            ent.Level = "ERROR";
            ent.Logger = Globals.gnKullaniciAd;
            ent.Exception = "";
            srv.Log_Kayit(ent);
        }

        public static void LogInfoMessage(string Mesaj,string tabloAdi)
        {
            KullaniciService srv = new KullaniciService();
            Log ent = new Log();
            ent.Date = DateTime.Now;
            ent.Message = Mesaj;
            ent.Thread = tabloAdi;
            ent.Level = "INFO";
            ent.Logger = Globals.gnKullaniciAd != null ? Globals.gnKullaniciAd : "";
            ent.Exception = "";
            srv.Log_Kayit(ent);
        }

        public static void KullaniciMesajYaz(int kullaniciId, string[] Mesaj)
        {
            //MesajCntrl cn = new MesajCntrl();
            //MesajVm vm = new MesajVm();
            //vm.KIME_KULLANICI_ID = kullaniciId;
            //vm.MESAJ = Mesaj[0];
            //vm.MESAJ_2 = Mesaj[1];
            //vm.MESAJ_3 = Mesaj[2];
            //vm.OKUNDU_E_H = (int)EvetHayirEn.Hayir;
            //cn.Ekle(vm); 
        }
    }
}
