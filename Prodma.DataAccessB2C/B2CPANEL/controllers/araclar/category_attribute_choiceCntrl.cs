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
    public class category_attribute_choiceCntrl : BaseCtrl<category_attribute_choiceVm, int>
    {
        category_attribute_choiceService Service = new category_attribute_choiceService();
        public override List<category_attribute_choiceVm> doListe_Al(category_attribute_choiceVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(category_attribute_choiceVm entity)
        {
            category_attribute_choice ekle = new category_attribute_choice();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(category_attribute_choiceVm entity, int id)
        {
            category_attribute_choice islem = new category_attribute_choice();
            EntityKey guncelleId = new EntityKey("b2cEntities.category_attribute_choice", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(category_attribute_choice islem, category_attribute_choiceVm entity)
        {
            islem.title = entity.title;
            islem.schema_id = entity.schema_id;
        }
        public override void doSil(int id, category_attribute_choiceVm entity)
        {
            category_attribute_choice sil = new category_attribute_choice();
            EntityKey silId = new EntityKey("b2cEntities.category_attribute_choice", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
