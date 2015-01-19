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
    public class ege_integration_activitylogCntrl : BaseCtrl<ege_integration_activitylogVm, int>
    {
        ege_integration_activitylogService Service = new ege_integration_activitylogService();
        public override List<ege_integration_activitylogVm> doListe_Al(ege_integration_activitylogVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(ege_integration_activitylogVm entity)
        {
            ege_integration_activitylog ekle = new ege_integration_activitylog();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(ege_integration_activitylogVm entity, int id)
        {
            ege_integration_activitylog islem = new ege_integration_activitylog();
            EntityKey guncelleId = new EntityKey("b2cEntities.ege_integration_activitylog", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(ege_integration_activitylog islem, ege_integration_activitylogVm entity)
        {
            islem.@event = entity.event1;
            islem.level = entity.level;
            islem.message = entity.message;
            islem.timestamp = entity.timestamp;
        }
        public override void doSil(int id, ege_integration_activitylogVm entity)
        {
            ege_integration_activitylog sil = new ege_integration_activitylog();
            EntityKey silId = new EntityKey("b2cEntities.ege_integration_activitylog", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
