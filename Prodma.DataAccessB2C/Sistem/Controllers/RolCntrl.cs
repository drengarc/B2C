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
    public class RolCntrl : BaseCtrl<RolVm, int>
    {
        RolService Service = new RolService();
        public override List<RolVm> doListe_Al(RolVm entity)
        {

            return Service.Service_Liste_Al(entity);  
             
        }
        public override void doEkle(RolVm entity)
        {
            ROL ekle = new ROL();
            ekle.AD = entity.AD;
            ekle.LK_DURUM_ID = entity.LK_DURUM_ID;   
                Service.Service_Ekle(ekle); entity.ID = ekle.ID;
                entity.tabloAdi = "Islem Cins";
                entity.ayrimAlan = "AD:" + entity.AD;
        }
        public override void doGuncelle(RolVm entity, int id)
        {
            ROL guncelle = new ROL();
            EntityKey guncelleId = new EntityKey("b2cEntities.ROL", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
                guncelle.AD = entity.AD;
                guncelle.LK_DURUM_ID = entity.LK_DURUM_ID;
                
                Service.Service_Guncelle(guncelle, id);
                entity.tabloAdi = "Rol";
                entity.ayrimAlan = "AD:" + entity.AD;
        }
        public override void doSil(int id, RolVm entity)
        {
            ROL sil = new ROL();
            EntityKey silId = new EntityKey("b2cEntities.ROL", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;      
            Service.Service_Sil(sil, id);
                entity.tabloAdi = "Rol";
                entity.ayrimAlan = "AD:" + entity.AD;
        }
        

    }
}
