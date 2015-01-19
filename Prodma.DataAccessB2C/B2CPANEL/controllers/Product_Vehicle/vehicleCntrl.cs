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
    public class vehicleCntrl : BaseCtrl<vehicleVm, int>
    {
        vehicleService Service = new vehicleService();
        public override List<vehicleVm> doListe_Al(vehicleVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(vehicleVm entity)
        {
            vehicle ekle = new vehicle();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(vehicleVm entity, int id)
        {
            vehicle islem = new vehicle();
            EntityKey guncelleId = new EntityKey("b2cEntities.vehicle", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(vehicle islem, vehicleVm entity)
        {
            islem.model_type_id = entity.model_type_id;
            islem.motor_type_id = entity.motor_type_id;
            islem.fuel_type_id = entity.fuel_type_id;
            islem.begin_year = entity.begin_year;
            islem.end_year = entity.end_year;
            //islem.fulltext = entity.fulltext;
            islem.grup_id = entity.grup_id;
            islem.model_id = entity.model_id;
            islem.brand_id = entity.brand_id;
        }
        public override void doSil(int id, vehicleVm entity)
        {
            vehicle sil = new vehicle();
            EntityKey silId = new EntityKey("b2cEntities.vehicle", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
