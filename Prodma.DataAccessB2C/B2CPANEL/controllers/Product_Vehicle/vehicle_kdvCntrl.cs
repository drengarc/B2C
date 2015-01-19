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
    public class vehicle_kdvCntrl : BaseCtrl<vehicle_kdvVm, int>
    {
        vehicle_kdvService Service = new vehicle_kdvService();
        public override List<vehicle_kdvVm> doListe_Al(vehicle_kdvVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(vehicle_kdvVm entity)
        {
            vehicle_kdv ekle = new vehicle_kdv();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(vehicle_kdvVm entity, int id)
        {
            vehicle_kdv islem = new vehicle_kdv();
            EntityKey guncelleId = new EntityKey("b2cEntities.vehicle_kdv", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(vehicle_kdv islem, vehicle_kdvVm entity)
        {
            islem.name = entity.name;
            islem.value = entity.value;
        }
        public override void doSil(int id, vehicle_kdvVm entity)
        {
            vehicle_kdv sil = new vehicle_kdv();
            EntityKey silId = new EntityKey("b2cEntities.vehicle_kdv", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
