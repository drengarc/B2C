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
    public class product_reviewCntrl : BaseCtrl<product_reviewVm, int>
    {
        product_reviewService Service = new product_reviewService();
        public override List<product_reviewVm> doListe_Al(product_reviewVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_reviewVm entity)
        {
            product_review ekle = new product_review();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_reviewVm entity, int id)
        {
            product_review islem = new product_review();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_review", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_review islem, product_reviewVm entity)
        {
            islem.product_id = entity.product_id;
            islem.user_id = entity.user_id;
            islem.rating = entity.rating;
            islem.date_added = entity.date_added;
            islem.status = entity.status != null ? entity.status : 1;
            islem.language_id = entity.language_id;
            islem.text = entity.text;
        }
        public override void doSil(int id, product_reviewVm entity)
        {
            product_review sil = new product_review();
            EntityKey silId = new EntityKey("b2cEntities.product_review", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
