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
    public class discount_customer_groupCntrl : BaseCtrl<discount_customer_groupVm, int>
    {
        discount_customer_groupService Service = new discount_customer_groupService();
        public override List<discount_customer_groupVm> doListe_Al(discount_customer_groupVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(discount_customer_groupVm entity)
        {
            discount_customer_group ekle = new discount_customer_group();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(discount_customer_groupVm entity, int id)
        {
            discount_customer_group islem = new discount_customer_group();
            EntityKey guncelleId = new EntityKey("b2cEntities.discount_customer_group", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(discount_customer_group islem, discount_customer_groupVm entity)
        {
            islem.discount_id = entity.discount_id;
            islem.customergroup_id = entity.customergroup_id;
        }
        public override void doSil(int id, discount_customer_groupVm entity)
        {
            discount_customer_group sil = new discount_customer_group();
            EntityKey silId = new EntityKey("b2cEntities.discount_customer_group", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
