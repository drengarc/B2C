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
    public class product_tagCntrl : BaseCtrl<product_tagVm, int>
    {
        product_tagService Service = new product_tagService();
        public override List<product_tagVm> doListe_Al(product_tagVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_tagVm entity)
        {
            product_tag ekle = new product_tag();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_tagVm entity, int id)
        {
            product_tag islem = new product_tag();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_tag", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_tag islem, product_tagVm entity)
        {
            islem.name = entity.name;
            islem.slug = entity.slug;
        }
        public override void doSil(int id, product_tagVm entity)
        {
            product_tag sil = new product_tag();
            EntityKey silId = new EntityKey("b2cEntities.product_tag", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
