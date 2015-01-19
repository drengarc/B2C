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
    public class discount_product_tagCntrl : BaseCtrl<discount_product_tagVm, int>
    {
        discount_product_tagService Service = new discount_product_tagService();
        public override List<discount_product_tagVm> doListe_Al(discount_product_tagVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(discount_product_tagVm entity)
        {
            discount_product_tag ekle = new discount_product_tag();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(discount_product_tagVm entity, int id)
        {
            discount_product_tag islem = new discount_product_tag();
            EntityKey guncelleId = new EntityKey("b2cEntities.discount_product_tag", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(discount_product_tag islem, discount_product_tagVm entity)
        {
            islem.discount_id = entity.discount_id;
            islem.producttag_id = entity.producttag_id;
        }
        public override void doSil(int id, discount_product_tagVm entity)
        {
            discount_product_tag sil = new discount_product_tag();
            EntityKey silId = new EntityKey("b2cEntities.discount_product_tag", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
