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
    public class discountCntrl : BaseCtrl<discountVm, int>
    {
        discountService Service = new discountService();
        public override List<discountVm> doListe_Al(discountVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(discountVm entity)
        {
            discount ekle = new discount();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(discountVm entity, int id)
        {
            discount islem = new discount();
            EntityKey guncelleId = new EntityKey("b2cEntities.discount", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(discount islem, discountVm entity)
        {
            islem.name = entity.name;
            islem.percentage = entity.percentage;
            islem.amount = entity.amount;
            islem.date_added = entity.date_added;
            islem.start_date = entity.start_date;
            islem.end_date = entity.end_date;
            islem.is_active = entity.is_active;
            islem.minimum_order_price = entity.minimum_order_price;
        }
        public override void doSil(int id, discountVm entity)
        {
            discount sil = new discount();
            EntityKey silId = new EntityKey("b2cEntities.discount", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
