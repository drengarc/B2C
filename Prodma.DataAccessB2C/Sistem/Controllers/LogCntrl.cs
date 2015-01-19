using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.SistemB2C.Models;
using Prodma.SistemB2C.Services;
using Prodma.DataAccessB2C;
using System.Windows.Forms;

namespace Prodma.SistemB2C.Controllers
{
    public class LogCntrl : BaseCtrl<Prodma.SistemB2C.Models.LogVm, int>
    {
        LogService Service = new LogService();
        public override List<Prodma.SistemB2C.Models.LogVm> doListe_Al(Prodma.SistemB2C.Models.LogVm entity)
        {
            return Service.Service_Liste_Al(entity);  
        }
        public override void doEkle(Prodma.SistemB2C.Models.LogVm entity)
        {
            Log ekle = new Log();
            ekle.Level = entity.Level;
            ekle.Date = entity.Date;
            ekle.Message = entity.Message;
            ekle.Logger = Globals.gnKullaniciAd;
            ekle.Thread = "";
            ekle.Exception = entity.Exception;
            Service.Service_Ekle(ekle); entity.ID = ekle.Id;
        }
        public override void doGuncelle(Prodma.SistemB2C.Models.LogVm entity, int id)
        {
            Log guncelle = new Log();
            EntityKey guncelleId = new EntityKey("b2cEntities.Log", "Id", entity.Id);
            guncelle.EntityKey = guncelleId;
            guncelle.Date = entity.Date;
            guncelle.Id = entity.Id;
            guncelle.Level = entity.Level;
            guncelle.Message = entity.Message;
            guncelle.Thread = "";
            guncelle.Exception = entity.Exception;
            guncelle.Logger = entity.Logger;
            Service.Service_Guncelle(guncelle, id);
        }
        public override void doSil(int id, Prodma.SistemB2C.Models.LogVm entity)
        {
            Log sil = new Log();
            EntityKey silId = new EntityKey("b2cEntities.Log", "Id", entity.Id);
            sil.EntityKey = silId;
            sil.Id = entity.Id;      
            Service.Service_Sil(sil, id);
                entity.tabloAdi = "Log";
                //entity.ayrimAlan = "AD:" + entity.AD;
        }
        

    }
}
