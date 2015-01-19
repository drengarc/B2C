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
    public class messaging_customermessageCntrl : BaseCtrl<messaging_customermessageVm, int>
    {
        messaging_customermessageService Service = new messaging_customermessageService();
        public override List<messaging_customermessageVm> doListe_Al(messaging_customermessageVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(messaging_customermessageVm entity)
        {
            messaging_customermessage ekle = new messaging_customermessage();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(messaging_customermessageVm entity, int id)
        {
            messaging_customermessage islem = new messaging_customermessage();
            EntityKey guncelleId = new EntityKey("b2cEntities.messaging_customermessage", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(messaging_customermessage islem, messaging_customermessageVm entity)
        {
            islem.customer_id = entity.customer_id;
            islem.topic = entity.topic;
            islem.message = entity.message;
            islem.top_message_id = entity.top_message_id;
            islem.unread = entity.unread;
            islem.time = entity.time;
            islem.staff_id = entity.staff_id;
            islem.order_id = entity.order_id;
            islem.department_id = entity.department_id;
        }
        public override void doSil(int id, messaging_customermessageVm entity)
        {
            messaging_customermessage sil = new messaging_customermessage();
            EntityKey silId = new EntityKey("b2cEntities.messaging_customermessage", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
