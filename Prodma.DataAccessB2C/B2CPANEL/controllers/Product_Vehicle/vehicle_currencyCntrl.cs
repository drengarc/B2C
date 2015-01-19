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
    public class vehicle_currencyCntrl : BaseCtrl<vehicle_currencyVm, int>
    {
        vehicle_currencyService Service = new vehicle_currencyService();
        public override List<vehicle_currencyVm> doListe_Al(vehicle_currencyVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(vehicle_currencyVm entity)
        {
            vehicle_currency ekle = new vehicle_currency();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(vehicle_currencyVm entity, int id)
        {
            vehicle_currency islem = new vehicle_currency();
            EntityKey guncelleId = new EntityKey("b2cEntities.vehicle_currency", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(vehicle_currency islem, vehicle_currencyVm entity)
        {
            islem.name = entity.name;
            islem.code = entity.code;
            islem.symbol = entity.symbol;
            islem.parity = entity.parity;
        }
        public override void doSil(int id, vehicle_currencyVm entity)
        {
            vehicle_currency sil = new vehicle_currency();
            EntityKey silId = new EntityKey("b2cEntities.vehicle_currency", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
