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
    public class newsletterCntrl : BaseCtrl<newsletterVm, int>
    {
        newsletterService Service = new newsletterService();
        public override List<newsletterVm> doListe_Al(newsletterVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(newsletterVm entity)
        {
            newsletter ekle = new newsletter();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(newsletterVm entity, int id)
        {
            newsletter islem = new newsletter();
            EntityKey guncelleId = new EntityKey("b2cEntities.newsletter", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(newsletter islem, newsletterVm entity)
        {
            islem.title = entity.title;
            islem.content = entity.content;
            islem.date_added = entity.date_added;
            islem.date_sent = entity.date_sent;
            islem.is_active = entity.is_active;
            islem.language_id = entity.language_id;
        }
        public override void doSil(int id, newsletterVm entity)
        {
            newsletter sil = new newsletter();
            EntityKey silId = new EntityKey("b2cEntities.newsletter", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
