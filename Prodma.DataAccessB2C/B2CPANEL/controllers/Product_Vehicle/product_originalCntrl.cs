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
    public class product_originalCntrl : BaseCtrl<product_originalVm, int>
    {
        product_originalService Service = new product_originalService();
        public override List<product_originalVm> doListe_Al(product_originalVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_originalVm entity)
        {
            product_original ekle = new product_original();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_originalVm entity, int id)
        {
            product_original islem = new product_original();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_original", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_original islem, product_originalVm entity)
        {
            islem.product_id = entity.product_id;
            islem.oem_no = entity.oem_no;
            islem.oem_no_original = entity.oem_no_original;
            islem.brand_id = entity.brand_id;
        }
        public override void doSil(int id, product_originalVm entity)
        {
            product_original sil = new product_original();
            EntityKey silId = new EntityKey("b2cEntities.product_original", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
