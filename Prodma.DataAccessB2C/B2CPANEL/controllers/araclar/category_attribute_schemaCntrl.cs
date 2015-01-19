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
    public class category_attribute_schemaCntrl : BaseCtrl<category_attribute_schemaVm, int>
    {
        category_attribute_schemaService Service = new category_attribute_schemaService();
        public override List<category_attribute_schemaVm> doListe_Al(category_attribute_schemaVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(category_attribute_schemaVm entity)
        {
            category_attribute_schema ekle = new category_attribute_schema();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(category_attribute_schemaVm entity, int id)
        {
            category_attribute_schema islem = new category_attribute_schema();
            EntityKey guncelleId = new EntityKey("b2cEntities.category_attribute_schema", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(category_attribute_schema islem, category_attribute_schemaVm entity)
        {
            islem.title = entity.title;
            islem.name = entity.name;
            islem.help_text = entity.help_text;
            islem.datatype = entity.datatype;
            islem.required = entity.required;
            islem.searched = entity.searched;
            islem.filtered = entity.filtered;
            islem.sortable = entity.sortable;
        }
        public override void doSil(int id, category_attribute_schemaVm entity)
        {
            category_attribute_schema sil = new category_attribute_schema();
            EntityKey silId = new EntityKey("b2cEntities.category_attribute_schema", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
