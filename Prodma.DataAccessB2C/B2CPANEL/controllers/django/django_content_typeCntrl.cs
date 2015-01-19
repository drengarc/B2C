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
    public class django_content_typeCntrl : BaseCtrl<django_content_typeVm, int>
    {
        django_content_typeService Service = new django_content_typeService();
        public override List<django_content_typeVm> doListe_Al(django_content_typeVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(django_content_typeVm entity)
        {
            django_content_type ekle = new django_content_type();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(django_content_typeVm entity, int id)
        {
            django_content_type islem = new django_content_type();
            EntityKey guncelleId = new EntityKey("b2cEntities.django_content_type", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(django_content_type islem, django_content_typeVm entity)
        {
            islem.name = entity.name;
            islem.app_label = entity.app_label;
            islem.model = entity.model;
        }
        public override void doSil(int id, django_content_typeVm entity)
        {
            django_content_type sil = new django_content_type();
            EntityKey silId = new EntityKey("b2cEntities.django_content_type", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
