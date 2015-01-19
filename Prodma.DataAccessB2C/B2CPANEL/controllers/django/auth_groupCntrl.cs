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
    public class auth_groupCntrl : BaseCtrl<auth_groupVm, int>
    {
        auth_groupService Service = new auth_groupService();
        public override List<auth_groupVm> doListe_Al(auth_groupVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(auth_groupVm entity)
        {
            auth_group ekle = new auth_group();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(auth_groupVm entity, int id)
        {
            auth_group islem = new auth_group();
            EntityKey guncelleId = new EntityKey("b2cEntities.auth_group", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(auth_group islem, auth_groupVm entity)
        {
            islem.name = entity.name;
        }
        public override void doSil(int id, auth_groupVm entity)
        {
            auth_group sil = new auth_group();
            EntityKey silId = new EntityKey("b2cEntities.auth_group", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
