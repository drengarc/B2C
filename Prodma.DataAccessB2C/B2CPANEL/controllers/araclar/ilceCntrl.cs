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
    public class ilceCntrl : BaseCtrl<ilceVm, int>
    {
        ilceService Service = new ilceService();
        public override List<ilceVm> doListe_Al(ilceVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(ilceVm entity)
        {
            ilce ekle = new ilce();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(ilceVm entity, int id)
        {
            ilce islem = new ilce();
            EntityKey guncelleId = new EntityKey("b2cEntities.ilce", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(ilce islem, ilceVm entity)
        {
            islem.city_id = entity.city_id;
            islem.name = entity.name;
        }
        public override void doSil(int id, ilceVm entity)
        {
            ilce sil = new ilce();
            EntityKey silId = new EntityKey("b2cEntities.ilce", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
