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
    public class product_category_choiceCntrl : BaseCtrl<product_category_choiceVm, int>
    {
        product_category_choiceService Service = new product_category_choiceService();
        public override List<product_category_choiceVm> doListe_Al(product_category_choiceVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_category_choiceVm entity)
        {
            product_category_choice ekle = new product_category_choice();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_category_choiceVm entity, int id)
        {
            product_category_choice islem = new product_category_choice();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_category_choice", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_category_choice islem, product_category_choiceVm entity)
        {
            islem.title = entity.title;
            islem.schema_id = entity.schema_id;
        }
        public override void doSil(int id, product_category_choiceVm entity)
        {
            product_category_choice sil = new product_category_choice();
            EntityKey silId = new EntityKey("b2cEntities.product_category_choice", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
