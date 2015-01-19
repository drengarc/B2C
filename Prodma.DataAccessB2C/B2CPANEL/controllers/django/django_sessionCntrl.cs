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
    public class django_sessionCntrl : BaseCtrl<django_sessionVm, int>
    {
        django_sessionService Service = new django_sessionService();
        public override List<django_sessionVm> doListe_Al(django_sessionVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(django_sessionVm entity)
        {
            django_session ekle = new django_session();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); //entity.id = ekle.id;
        }
        public override void doGuncelle(django_sessionVm entity, int id)
        {
            //django_session islem = new django_session();
            //EntityKey guncelleId = new EntityKey("b2cEntities.django_session", "id", entity.id);
            //islem.EntityKey = guncelleId;
            //islem.id = id;
            //EkleGuncelle(islem, entity);
            //Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(django_session islem, django_sessionVm entity)
        {
            islem.session_data = entity.session_data;
            islem.expire_date = entity.expire_date;
        }
        public override void doSil(int id, django_sessionVm entity)
        {
            //django_session sil = new django_session();
            //EntityKey silId = new EntityKey("b2cEntities.django_session", "id", entity.id);
            //sil.EntityKey = silId;
            //sil.id = entity.id; 
            //Service.Service_Sil(sil, id);
        }
    }    
 
}
