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
    public class orderCntrl : BaseCtrl<orderVm, int>
    {
        orderService Service = new orderService();
        public override List<orderVm> doListe_Al(orderVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(orderVm entity)
        {
            //order ekle = new order();
            //EkleGuncelle(ekle, entity);
            //Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(orderVm entity, int id)
        {
            order islem = new order();
            EntityKey guncelleId = new EntityKey("b2cEntities.order", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, Convert.ToInt32(islem.id));
        }
        void EkleGuncelle(order islem, orderVm entity)
        {
            islem.date_processed = entity.date_processed;
            islem.receipt_id = entity.receipt_id;
            islem.customer_id = entity.customer_id;
            islem.discount = entity.discount;
            islem.delivery_name = entity.delivery_name;
            islem.delivery_address = entity.delivery_address;
            islem.delivery_city_id = entity.delivery_city_id;
            islem.delivery_phone = entity.delivery_phone;
            islem.billing_name = entity.billing_name;
            islem.billing_address = entity.billing_address;
            islem.billing_city_id = entity.billing_city_id;
            islem.billing_phone = entity.billing_phone;
            islem.cc_owner = entity.cc_owner;
            islem.cc_number_last = entity.cc_number_last;
            islem.final_price = entity.final_price;
            islem.final_kdv = entity.final_kdv;
            islem.comment = entity.comment;
            islem.cargo_no = entity.cargo_no;
            islem.payment_type = entity.payment_type;
            islem.shipment_price = entity.shipment_price;
            islem.shipment_alternative_id = entity.shipment_alternative_id;
        }
        public override void doSil(int id, orderVm entity)
        {
            order sil = new order();
            EntityKey silId = new EntityKey("b2cEntities.order", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id;
            Service.Service_Sil(sil, id);
        }
    }    
 
}
