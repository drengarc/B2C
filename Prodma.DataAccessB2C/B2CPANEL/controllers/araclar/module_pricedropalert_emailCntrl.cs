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
    public class module_pricedropalert_emailCntrl : BaseCtrl<module_pricedropalert_emailVm, int>
    {
        module_pricedropalert_emailService Service = new module_pricedropalert_emailService();
        public override List<module_pricedropalert_emailVm> doListe_Al(module_pricedropalert_emailVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(module_pricedropalert_emailVm entity)
        {
            module_pricedropalert_email ekle = new module_pricedropalert_email();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(module_pricedropalert_emailVm entity, int id)
        {
            module_pricedropalert_email islem = new module_pricedropalert_email();
            EntityKey guncelleId = new EntityKey("b2cEntities.module_pricedropalert_email", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(module_pricedropalert_email islem, module_pricedropalert_emailVm entity)
        {
            islem.saved_time = entity.saved_time;
            islem.email = entity.email;
            islem.product_id = entity.product_id;
            islem.checkpoint_price = entity.checkpoint_price;
        }
        public override void doSil(int id, module_pricedropalert_emailVm entity)
        {
            module_pricedropalert_email sil = new module_pricedropalert_email();
            EntityKey silId = new EntityKey("b2cEntities.module_pricedropalert_email", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
