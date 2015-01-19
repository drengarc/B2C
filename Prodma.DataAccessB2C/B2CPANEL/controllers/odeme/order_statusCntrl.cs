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
    public class order_statusCntrl : BaseCtrl<order_statusVm, int>
    {
        order_statusService Service = new order_statusService();
        public override List<order_statusVm> doListe_Al(order_statusVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(order_statusVm entity)
        {
            order_status ekle = new order_status();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); 
            entity.id = ekle.id;
            entity.insertId = Service.insertId;
        }
        public override void doGuncelle(order_statusVm entity, int id)
        {
            order_status islem = new order_status();
            EntityKey guncelleId = new EntityKey("b2cEntities.order_status", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(order_status islem, order_statusVm entity)
        {
            islem.time = entity.time;
            islem.order_id = entity.order_id;
            islem.order_status_type_id = entity.order_status_type_id;
            islem.comments = entity.comments;
            //islem.order_product_id = entity.order_product_id;
        }
        public override void doSil(int id, order_statusVm entity)
        {
            order_status sil = new order_status();
            EntityKey silId = new EntityKey("b2cEntities.order_status", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
