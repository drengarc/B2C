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
    public class messaging_messagedepartmentCntrl : BaseCtrl<messaging_messagedepartmentVm, int>
    {
        messaging_messagedepartmentService Service = new messaging_messagedepartmentService();
        public override List<messaging_messagedepartmentVm> doListe_Al(messaging_messagedepartmentVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(messaging_messagedepartmentVm entity)
        {
            messaging_messagedepartment ekle = new messaging_messagedepartment();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(messaging_messagedepartmentVm entity, int id)
        {
            messaging_messagedepartment islem = new messaging_messagedepartment();
            EntityKey guncelleId = new EntityKey("b2cEntities.messaging_messagedepartment", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(messaging_messagedepartment islem, messaging_messagedepartmentVm entity)
        {
            islem.name = entity.name;
        }
        public override void doSil(int id, messaging_messagedepartmentVm entity)
        {
            messaging_messagedepartment sil = new messaging_messagedepartment();
            EntityKey silId = new EntityKey("b2cEntities.messaging_messagedepartment", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
