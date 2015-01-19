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
    public class module_pricedropalert_customerCntrl : BaseCtrl<module_pricedropalert_customerVm, int>
    {
        module_pricedropalert_customerService Service = new module_pricedropalert_customerService();
        public override List<module_pricedropalert_customerVm> doListe_Al(module_pricedropalert_customerVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(module_pricedropalert_customerVm entity)
        {
            module_pricedropalert_customer ekle = new module_pricedropalert_customer();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(module_pricedropalert_customerVm entity, int id)
        {
            module_pricedropalert_customer islem = new module_pricedropalert_customer();
            EntityKey guncelleId = new EntityKey("b2cEntities.module_pricedropalert_customer", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(module_pricedropalert_customer islem, module_pricedropalert_customerVm entity)
        {
            islem.saved_time = entity.saved_time;
            islem.customer_id = entity.customer_id;
            islem.product_id = entity.product_id;
            islem.checkpoint_price = entity.checkpoint_price;
        }
        public override void doSil(int id, module_pricedropalert_customerVm entity)
        {
            module_pricedropalert_customer sil = new module_pricedropalert_customer();
            EntityKey silId = new EntityKey("b2cEntities.module_pricedropalert_customer", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
