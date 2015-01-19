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
    public class discount_categoryCntrl : BaseCtrl<discount_categoryVm, int>
    {
        discount_categoryService Service = new discount_categoryService();
        public override List<discount_categoryVm> doListe_Al(discount_categoryVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(discount_categoryVm entity)
        {
            discount_category ekle = new discount_category();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(discount_categoryVm entity, int id)
        {
            discount_category islem = new discount_category();
            EntityKey guncelleId = new EntityKey("b2cEntities.discount_category", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(discount_category islem, discount_categoryVm entity)
        {
            islem.discount_id = entity.discount_id;
            islem.category_id = entity.category_id;
        }
        public override void doSil(int id, discount_categoryVm entity)
        {
            discount_category sil = new discount_category();
            EntityKey silId = new EntityKey("b2cEntities.discount_category", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
