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
    public class product_imagesCntrl : BaseCtrl<product_imagesVm, int>
    {
        product_imagesService Service = new product_imagesService();
        public override List<product_imagesVm> doListe_Al(product_imagesVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_imagesVm entity)
        {
            product_images ekle = new product_images();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_imagesVm entity, int id)
        {
            product_images islem = new product_images();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_images", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_images islem, product_imagesVm entity)
        {
            islem.product_id = entity.product_id;
            islem.image = entity.image;
            islem.order = entity.order;
        }
        public override void doSil(int id, product_imagesVm entity)
        {
            product_images sil = new product_images();
            EntityKey silId = new EntityKey("b2cEntities.product_images", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
