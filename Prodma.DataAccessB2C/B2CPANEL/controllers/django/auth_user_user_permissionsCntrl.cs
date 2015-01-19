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
    public class auth_user_user_permissionsCntrl : BaseCtrl<auth_user_user_permissionsVm, int>
    {
        auth_user_user_permissionsService Service = new auth_user_user_permissionsService();
        public override List<auth_user_user_permissionsVm> doListe_Al(auth_user_user_permissionsVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(auth_user_user_permissionsVm entity)
        {
            auth_user_user_permissions ekle = new auth_user_user_permissions();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(auth_user_user_permissionsVm entity, int id)
        {
            auth_user_user_permissions islem = new auth_user_user_permissions();
            EntityKey guncelleId = new EntityKey("b2cEntities.auth_user_user_permissions", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(auth_user_user_permissions islem, auth_user_user_permissionsVm entity)
        {
            islem.user_id = entity.user_id;
            islem.permission_id = entity.permission_id;
        }
        public override void doSil(int id, auth_user_user_permissionsVm entity)
        {
            auth_user_user_permissions sil = new auth_user_user_permissions();
            EntityKey silId = new EntityKey("b2cEntities.auth_user_user_permissions", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
