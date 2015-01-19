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
    public class category_attribute_valueCntrl : BaseCtrl<category_attribute_valueVm, int>
    {
        category_attribute_valueService Service = new category_attribute_valueService();
        public override List<category_attribute_valueVm> doListe_Al(category_attribute_valueVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(category_attribute_valueVm entity)
        {
            category_attribute_value ekle = new category_attribute_value();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(category_attribute_valueVm entity, int id)
        {
            category_attribute_value islem = new category_attribute_value();
            EntityKey guncelleId = new EntityKey("b2cEntities.category_attribute_value", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(category_attribute_value islem, category_attribute_valueVm entity)
        {
            islem.entity_type_id = entity.entity_type_id;
            islem.entity_id = entity.entity_id;
            islem.value_text = entity.value_text;
            islem.value_float = entity.value_float;
            islem.value_date = entity.value_date;
            islem.value_bool = entity.value_bool;
            islem.schema_id  = entity.schema_id;
            islem.choice_id = entity.choice_id;
        }
        public override void doSil(int id, category_attribute_valueVm entity)
        {
            category_attribute_value sil = new category_attribute_value();
            EntityKey silId = new EntityKey("b2cEntities.category_attribute_value", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
