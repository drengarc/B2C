using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.DataAccess;
using System.Windows.Forms;
using B2C.Models;
using B2C.Services;
namespace B2C.Controllers
{
    public class cms_menuattributeCntrl : BaseCtrl<cms_menuattributeVm, int>
    {
        cms_menuattributeService Service = new cms_menuattributeService();
        public override List<cms_menuattributeVm> doListe_Al(cms_menuattributeVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(cms_menuattributeVm entity)
        {
            cms_menuattribute ekle = new cms_menuattribute();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(cms_menuattributeVm entity, int id)
        {
            cms_menuattribute islem = new cms_menuattribute();
            EntityKey guncelleId = new EntityKey("b2cEntities.cms_menuattribute", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(cms_menuattribute islem, cms_menuattributeVm entity)
        {
            islem.entity_type_id = entity.entity_type_id;
            islem.entity_id = entity.entity_id;
            islem.value_text = entity.value_text;
            islem.value_float = entity.value_float;
            islem.value_date = entity.value_date;
            islem.value_bool = entity.value_bool;
            islem.schema_id = entity.schema_id;
            islem.choice_id = entity.choice_id;
        }
        public override void doSil(int id, cms_menuattributeVm entity)
        {
            cms_menuattribute sil = new cms_menuattribute();
            EntityKey silId = new EntityKey("b2cEntities.cms_menuattribute", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
