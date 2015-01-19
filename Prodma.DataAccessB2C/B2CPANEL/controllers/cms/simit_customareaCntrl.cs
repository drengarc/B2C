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
    public class simit_customareaCntrl : BaseCtrl<simit_customareaVm, int>
    {
        simit_customareaService Service = new simit_customareaService();
        public override List<simit_customareaVm> doListe_Al(simit_customareaVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(simit_customareaVm entity)
        {
            simit_customarea ekle = new simit_customarea();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(simit_customareaVm entity, int id)
        {
            simit_customarea islem = new simit_customarea();
            EntityKey guncelleId = new EntityKey("b2cEntities.simit_customarea", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(simit_customarea islem, simit_customareaVm entity)
        {
            islem.name = entity.name;
            islem.slug = entity.slug;
            islem.value = entity.value;
            islem.type = entity.type;
            islem.category_id = entity.category_id;
            islem.extra = entity.extra;
            islem.description = entity.description;
        }
        public override void doSil(int id, simit_customareaVm entity)
        {
            simit_customarea sil = new simit_customarea();
            EntityKey silId = new EntityKey("b2cEntities.simit_customarea", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
