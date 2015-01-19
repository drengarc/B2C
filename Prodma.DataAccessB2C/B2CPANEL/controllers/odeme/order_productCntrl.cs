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
    public class order_productCntrl : BaseCtrl<order_productVm, int>
    {
        order_productService Service = new order_productService();
        public override List<order_productVm> doListe_Al(order_productVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(order_productVm entity)
        {
            order_product ekle = new order_product();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(order_productVm entity, int id)
        {
            order_product islem = new order_product();
            EntityKey guncelleId = new EntityKey("b2cEntities.order_product", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(order_product islem, order_productVm entity)
        {
            islem.order_id = entity.order_id;
            islem.product_id = entity.product_id;
            islem.quantity = entity.quantity;
            islem.price = entity.price;
            islem.discount = entity.discount;
            islem.vehicle_toptanci_id = entity.vehicle_toptanci_id;
            islem.sase_code = entity.sase_code;
        }
        public override void doSil(int id, order_productVm entity)
        {
            order_product sil = new order_product();
            EntityKey silId = new EntityKey("b2cEntities.order_product", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
