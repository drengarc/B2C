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
    public class customer_basketCntrl : BaseCtrl<customer_basketVm, int>
    {
        customer_basketService Service = new customer_basketService();
        public override List<customer_basketVm> doListe_Al(customer_basketVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(customer_basketVm entity)
        {
            customer_basket ekle = new customer_basket();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(customer_basketVm entity, int id)
        {
            customer_basket islem = new customer_basket();
            EntityKey guncelleId = new EntityKey("b2cEntities.customer_basket", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(customer_basket islem, customer_basketVm entity)
        {
            islem.customer_id = entity.customer_id;
            islem.product_id = entity.product_id;
            islem.quantity = entity.quantity;
            islem.date_added = entity.date_added;
        }
        public override void doSil(int id, customer_basketVm entity)
        {
            customer_basket sil = new customer_basket();
            EntityKey silId = new EntityKey("b2cEntities.customer_basket", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
