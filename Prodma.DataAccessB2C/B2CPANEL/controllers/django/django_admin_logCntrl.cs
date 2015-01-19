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
    public class django_admin_logCntrl : BaseCtrl<django_admin_logVm, int>
    {
        django_admin_logService Service = new django_admin_logService();
        public override List<django_admin_logVm> doListe_Al(django_admin_logVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(django_admin_logVm entity)
        {
            django_admin_log ekle = new django_admin_log();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(django_admin_logVm entity, int id)
        {
            django_admin_log islem = new django_admin_log();
            EntityKey guncelleId = new EntityKey("b2cEntities.django_admin_log", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(django_admin_log islem, django_admin_logVm entity)
        {
            islem.action_time = entity.action_time;
            islem.user_id = entity.user_id;
            islem.content_type_id = entity.content_type_id;
            islem.object_id = entity.object_id;
            islem.object_repr = entity.object_repr;
            islem.action_flag = entity.action_flag;
            islem.change_message = entity.change_message;
        }
        public override void doSil(int id, django_admin_logVm entity)
        {
            django_admin_log sil = new django_admin_log();
            EntityKey silId = new EntityKey("b2cEntities.django_admin_log", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
