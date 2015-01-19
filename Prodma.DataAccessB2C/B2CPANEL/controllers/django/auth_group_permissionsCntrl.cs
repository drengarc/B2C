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
    public class auth_group_permissionsCntrl : BaseCtrl<auth_group_permissionsVm, int>
    {
        auth_group_permissionsService Service = new auth_group_permissionsService();
        public override List<auth_group_permissionsVm> doListe_Al(auth_group_permissionsVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(auth_group_permissionsVm entity)
        {
            auth_group_permissions ekle = new auth_group_permissions();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(auth_group_permissionsVm entity, int id)
        {
            auth_group_permissions islem = new auth_group_permissions();
            EntityKey guncelleId = new EntityKey("b2cEntities.auth_group_permissions", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(auth_group_permissions islem, auth_group_permissionsVm entity)
        {
            islem.group_id = entity.group_id;
            islem.permission_id = entity.permission_id;
        }
        public override void doSil(int id, auth_group_permissionsVm entity)
        {
            auth_group_permissions sil = new auth_group_permissions();
            EntityKey silId = new EntityKey("b2cEntities.auth_group_permissions", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
