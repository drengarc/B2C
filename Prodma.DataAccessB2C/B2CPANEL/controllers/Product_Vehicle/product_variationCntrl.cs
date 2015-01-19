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
    public class product_variationCntrl : BaseCtrl<product_variationVm, int>
    {
        product_variationService Service = new product_variationService();
        public override List<product_variationVm> doListe_Al(product_variationVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_variationVm entity)
        {
            product_variation ekle = new product_variation();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_variationVm entity, int id)
        {
            product_variation islem = new product_variation();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_variation", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_variation islem, product_variationVm entity)
        {
            islem.product_id = entity.product_id;
        }
        public override void doSil(int id, product_variationVm entity)
        {
            product_variation sil = new product_variation();
            EntityKey silId = new EntityKey("b2cEntities.product_variation", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
