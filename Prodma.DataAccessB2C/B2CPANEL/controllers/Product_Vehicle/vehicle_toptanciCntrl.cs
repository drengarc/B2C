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
    public class vehicle_toptanciCntrl : BaseCtrl<vehicle_toptanciVm, int>
    {
        vehicle_toptanciService Service = new vehicle_toptanciService();
        public override List<vehicle_toptanciVm> doListe_Al(vehicle_toptanciVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(vehicle_toptanciVm entity)
        {
            vehicle_toptanci ekle = new vehicle_toptanci();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(vehicle_toptanciVm entity, int id)
        {
            vehicle_toptanci islem = new vehicle_toptanci();
            EntityKey guncelleId = new EntityKey("b2cEntities.vehicle_toptanci", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(vehicle_toptanci islem, vehicle_toptanciVm entity)
        {
            islem.name = entity.name;
        }
        public override void doSil(int id, vehicle_toptanciVm entity)
        {
            vehicle_toptanci sil = new vehicle_toptanci();
            EntityKey silId = new EntityKey("b2cEntities.vehicle_toptanci", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
