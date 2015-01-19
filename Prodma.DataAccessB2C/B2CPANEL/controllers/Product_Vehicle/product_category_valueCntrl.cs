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
    public class product_category_valueCntrl : BaseCtrl<product_category_valueVm, int>
    {
        product_category_valueService Service = new product_category_valueService();
        public override List<product_category_valueVm> doListe_Al(product_category_valueVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_category_valueVm entity)
        {
            product_category_value ekle = new product_category_value();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_category_valueVm entity, int id)
        {
            product_category_value islem = new product_category_value();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_category_value", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_category_value islem, product_category_valueVm entity)
        {
            islem.entity_type_id = entity.entity_type_id;
            islem.entity_id = entity.entity_id;
            islem.value_text = entity.value_text;
            islem.value_float = entity.value_float;
            islem.value_date = entity.value_date;
            islem.value_bool = entity.value_bool;
            islem.schema_id = entity.schema_id;
            islem.choice_id = entity.choice_id;
            islem.category_id = entity.category_id;
        }
        public override void doSil(int id, product_category_valueVm entity)
        {
            product_category_value sil = new product_category_value();
            EntityKey silId = new EntityKey("b2cEntities.product_category_value", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
