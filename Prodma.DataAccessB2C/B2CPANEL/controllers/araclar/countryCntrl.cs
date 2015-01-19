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
    public class countryCntrl : BaseCtrl<countryVm, int>
    {
        countryService Service = new countryService();
        public override List<countryVm> doListe_Al(countryVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(countryVm entity)
        {
            country ekle = new country();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(countryVm entity, int id)
        {
            country islem = new country();
            EntityKey guncelleId = new EntityKey("b2cEntities.country", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(country islem, countryVm entity)
        {
            islem.name = entity.name;
            islem.iso_code = entity.iso_code;
        }
        public override void doSil(int id, countryVm entity)
        {
            country sil = new country();
            EntityKey silId = new EntityKey("b2cEntities.country", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
