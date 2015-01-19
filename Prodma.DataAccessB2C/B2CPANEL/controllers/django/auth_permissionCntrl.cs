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
    public class auth_permissionCntrl : BaseCtrl<auth_permissionVm, int>
    {
        auth_permissionService Service = new auth_permissionService();
        public override List<auth_permissionVm> doListe_Al(auth_permissionVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(auth_permissionVm entity)
        {
            auth_permission ekle = new auth_permission();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(auth_permissionVm entity, int id)
        {
            auth_permission islem = new auth_permission();
            EntityKey guncelleId = new EntityKey("b2cEntities.auth_permission", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(auth_permission islem, auth_permissionVm entity)
        {
            islem.name = entity.name;
            islem.content_type_id = entity.content_type_id;
            islem.codename = entity.codename;
        }
        public override void doSil(int id, auth_permissionVm entity)
        {
            auth_permission sil = new auth_permission();
            EntityKey silId = new EntityKey("b2cEntities.auth_permission", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
