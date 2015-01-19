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
    public class auth_user_groupsCntrl : BaseCtrl<auth_user_groupsVm, int>
    {
        auth_user_groupsService Service = new auth_user_groupsService();
        public override List<auth_user_groupsVm> doListe_Al(auth_user_groupsVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(auth_user_groupsVm entity)
        {
            auth_user_groups ekle = new auth_user_groups();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(auth_user_groupsVm entity, int id)
        {
            auth_user_groups islem = new auth_user_groups();
            EntityKey guncelleId = new EntityKey("b2cEntities.auth_user_groups", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(auth_user_groups islem, auth_user_groupsVm entity)
        {
            islem.user_id = entity.user_id;
            islem.group_id = entity.group_id;
        }
        public override void doSil(int id, auth_user_groupsVm entity)
        {
            auth_user_groups sil = new auth_user_groups();
            EntityKey silId = new EntityKey("b2cEntities.auth_user_groups", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
