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
    public class cityCntrl : BaseCtrl<cityVm, int>
    {
        cityService Service = new cityService();
        public override List<cityVm> doListe_Al(cityVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(cityVm entity)
        {
            city ekle = new city();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(cityVm entity, int id)
        {
            city islem = new city();
            EntityKey guncelleId = new EntityKey("b2cEntities.city", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(city islem, cityVm entity)
        {
            islem.country_id = entity.country_id;
            islem.name = entity.name;
        }
        public override void doSil(int id, cityVm entity)
        {
            city sil = new city();
            EntityKey silId = new EntityKey("b2cEntities.city", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
