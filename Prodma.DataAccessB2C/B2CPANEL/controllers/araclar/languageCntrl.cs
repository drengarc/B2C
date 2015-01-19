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
    public class languageCntrl : BaseCtrl<languageVm, int>
    {
        languageService Service = new languageService();
        public override List<languageVm> doListe_Al(languageVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(languageVm entity)
        {
            language ekle = new language();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(languageVm entity, int id)
        {
            language islem = new language();
            EntityKey guncelleId = new EntityKey("b2cEntities.language", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(language islem, languageVm entity)
        {
            islem.name = entity.name;
            islem.code = entity.code;
            islem.image = entity.image;
            islem.order = entity.order;
        }
        public override void doSil(int id, languageVm entity)
        {
            language sil = new language();
            EntityKey silId = new EntityKey("b2cEntities.language", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
