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
    public class product_variation_typeCntrl : BaseCtrl<product_variation_typeVm, int>
    {
        product_variation_typeService Service = new product_variation_typeService();
        public override List<product_variation_typeVm> doListe_Al(product_variation_typeVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_variation_typeVm entity)
        {
            product_variation_type ekle = new product_variation_type();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_variation_typeVm entity, int id)
        {
            product_variation_type islem = new product_variation_type();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_variation_type", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_variation_type islem, product_variation_typeVm entity)
        {
            islem.name = entity.name;
        }
        public override void doSil(int id, product_variation_typeVm entity)
        {
            product_variation_type sil = new product_variation_type();
            EntityKey silId = new EntityKey("b2cEntities.product_variation_type", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
