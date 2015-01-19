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
    public class vehicle_fuel_typeCntrl : BaseCtrl<vehicle_fuel_typeVm, int>
    {
        vehicle_fuel_typeService Service = new vehicle_fuel_typeService();
        public override List<vehicle_fuel_typeVm> doListe_Al(vehicle_fuel_typeVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(vehicle_fuel_typeVm entity)
        {
            vehicle_fuel_type ekle = new vehicle_fuel_type();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(vehicle_fuel_typeVm entity, int id)
        {
            vehicle_fuel_type islem = new vehicle_fuel_type();
            EntityKey guncelleId = new EntityKey("b2cEntities.vehicle_fuel_type", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(vehicle_fuel_type islem, vehicle_fuel_typeVm entity)
        {
            islem.name = entity.name;
            islem.slug = entity.slug;
        }
        public override void doSil(int id, vehicle_fuel_typeVm entity)
        {
            vehicle_fuel_type sil = new vehicle_fuel_type();
            EntityKey silId = new EntityKey("b2cEntities.vehicle_fuel_type", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
