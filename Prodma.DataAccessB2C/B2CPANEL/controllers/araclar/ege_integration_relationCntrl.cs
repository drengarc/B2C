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
    public class ege_integration_relationCntrl : BaseCtrl<ege_integration_relationVm, int>
    {
        ege_integration_relationService Service = new ege_integration_relationService();
        public override List<ege_integration_relationVm> doListe_Al(ege_integration_relationVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(ege_integration_relationVm entity)
        {
            ege_integration_relation ekle = new ege_integration_relation();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(ege_integration_relationVm entity, int id)
        {
            ege_integration_relation islem = new ege_integration_relation();
            EntityKey guncelleId = new EntityKey("b2cEntities.ege_integration_relation", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(ege_integration_relation islem, ege_integration_relationVm entity)
        {
            islem.content_type_id = entity.content_type_id;
            islem.object_id = entity.object_id;
            islem.ege_code = entity.ege_code;
        }
        public override void doSil(int id, ege_integration_relationVm entity)
        {
            ege_integration_relation sil = new ege_integration_relation();
            EntityKey silId = new EntityKey("b2cEntities.ege_integration_relation", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
