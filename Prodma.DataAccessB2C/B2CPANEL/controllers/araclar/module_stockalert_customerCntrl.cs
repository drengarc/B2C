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
    public class module_stockalert_customerCntrl : BaseCtrl<module_stockalert_customerVm, int>
    {
        module_stockalert_customerService Service = new module_stockalert_customerService();
        public override List<module_stockalert_customerVm> doListe_Al(module_stockalert_customerVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(module_stockalert_customerVm entity)
        {
            module_stockalert_customer ekle = new module_stockalert_customer();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(module_stockalert_customerVm entity, int id)
        {
            module_stockalert_customer islem = new module_stockalert_customer();
            EntityKey guncelleId = new EntityKey("b2cEntities.module_stockalert_customer", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(module_stockalert_customer islem, module_stockalert_customerVm entity)
        {
            islem.saved_time = entity.saved_time;
            islem.customer_id = entity.customer_id;
            islem.product_id = entity.product_id;
        }
        public override void doSil(int id, module_stockalert_customerVm entity)
        {
            module_stockalert_customer sil = new module_stockalert_customer();
            EntityKey silId = new EntityKey("b2cEntities.module_stockalert_customer", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
