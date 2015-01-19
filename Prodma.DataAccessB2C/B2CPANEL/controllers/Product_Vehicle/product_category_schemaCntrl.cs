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
    public class product_category_schemaCntrl : BaseCtrl<product_category_schemaVm, int>
    {
        product_category_schemaService Service = new product_category_schemaService();
        public override List<product_category_schemaVm> doListe_Al(product_category_schemaVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_category_schemaVm entity)
        {
            product_category_schema ekle = new product_category_schema();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_category_schemaVm entity, int id)
        {
            product_category_schema islem = new product_category_schema();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_category_schema", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_category_schema islem, product_category_schemaVm entity)
        {
            islem.title = entity.title;
            islem.name = entity.name;
            islem.help_text = entity.help_text;
            islem.datatype = entity.datatype;
            islem.required = entity.required;
            islem.searched = entity.searched;
            islem.filtered = entity.filtered;
            islem.sortable = entity.sortable;
            islem.category_id = entity.category_id;
        }
        public override void doSil(int id, product_category_schemaVm entity)
        {
            product_category_schema sil = new product_category_schema();
            EntityKey silId = new EntityKey("b2cEntities.product_category_schema", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
