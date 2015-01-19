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
    public class product_variation_optionCntrl : BaseCtrl<product_variation_optionVm, int>
    {
        product_variation_optionService Service = new product_variation_optionService();
        public override List<product_variation_optionVm> doListe_Al(product_variation_optionVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_variation_optionVm entity)
        {
            product_variation_option ekle = new product_variation_option();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_variation_optionVm entity, int id)
        {
            product_variation_option islem = new product_variation_option();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_variation_option", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_variation_option islem, product_variation_optionVm entity)
        {
            islem.product_variation_id = entity.product_variation_id;
            islem.variation_id = entity.variation_id;
            islem.value = entity.value;
        }
        public override void doSil(int id, product_variation_optionVm entity)
        {
            product_variation_option sil = new product_variation_option();
            EntityKey silId = new EntityKey("b2cEntities.product_variation_option", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
