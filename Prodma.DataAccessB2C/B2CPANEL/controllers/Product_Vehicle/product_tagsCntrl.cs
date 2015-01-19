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
    public class product_tagsCntrl : BaseCtrl<product_tagsVm, int>
    {
        product_tagsService Service = new product_tagsService();
        public override List<product_tagsVm> doListe_Al(product_tagsVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_tagsVm entity)
        {
            product_tags ekle = new product_tags();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_tagsVm entity, int id)
        {
            product_tags islem = new product_tags();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_tags", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_tags islem, product_tagsVm entity)
        {
            islem.product_id = entity.product_id;
            islem.producttag_id = entity.producttag_id;
        }
        public override void doSil(int id, product_tagsVm entity)
        {
            product_tags sil = new product_tags();
            EntityKey silId = new EntityKey("b2cEntities.product_tags", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
