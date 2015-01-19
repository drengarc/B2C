using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.DataAccessB2C;
using System.Windows.Forms;
using B2C.Models;
using B2C.Services;
namespace B2C.Controllers
{
    public class south_migrationhistoryCntrl : BaseCtrl<south_migrationhistoryVm, int>
    {
        south_migrationhistoryService Service = new south_migrationhistoryService();
        public override List<south_migrationhistoryVm> doListe_Al(south_migrationhistoryVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(south_migrationhistoryVm entity)
        {
            south_migrationhistory ekle = new south_migrationhistory();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(south_migrationhistoryVm entity, int id)
        {
            south_migrationhistory islem = new south_migrationhistory();
            EntityKey guncelleId = new EntityKey("b2cEntities.south_migrationhistory", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(south_migrationhistory islem, south_migrationhistoryVm entity)
        {
            islem.app_name = entity.app_name;
            islem.migration = entity.migration;
            islem.applied = entity.applied;
        }
        public override void doSil(int id, south_migrationhistoryVm entity)
        {
            south_migrationhistory sil = new south_migrationhistory();
            EntityKey silId = new EntityKey("b2cEntities.south_migrationhistory", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
