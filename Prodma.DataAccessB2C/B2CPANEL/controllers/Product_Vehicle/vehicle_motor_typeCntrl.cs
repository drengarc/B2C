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
    public class vehicle_motor_typeCntrl : BaseCtrl<vehicle_motor_typeVm, int>
    {
        vehicle_motor_typeService Service = new vehicle_motor_typeService();
        public override List<vehicle_motor_typeVm> doListe_Al(vehicle_motor_typeVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(vehicle_motor_typeVm entity)
        {
            vehicle_motor_type ekle = new vehicle_motor_type();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(vehicle_motor_typeVm entity, int id)
        {
            vehicle_motor_type islem = new vehicle_motor_type();
            EntityKey guncelleId = new EntityKey("b2cEntities.vehicle_motor_type", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(vehicle_motor_type islem, vehicle_motor_typeVm entity)
        {
            islem.name = entity.name;
            islem.slug = entity.slug;
        }
        public override void doSil(int id, vehicle_motor_typeVm entity)
        {
            vehicle_motor_type sil = new vehicle_motor_type();
            EntityKey silId = new EntityKey("b2cEntities.vehicle_motor_type", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
