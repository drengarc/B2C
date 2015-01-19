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
    public class manufacturerCntrl : BaseCtrl<manufacturerVm, int>
    {
        manufacturerService Service = new manufacturerService();
        public override List<manufacturerVm> doListe_Al(manufacturerVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(manufacturerVm entity)
        {
            manufacturer ekle = new manufacturer();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(manufacturerVm entity, int id)
        {
            manufacturer islem = new manufacturer();
            EntityKey guncelleId = new EntityKey("b2cEntities.manufacturer", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(manufacturer islem, manufacturerVm entity)
        {
            islem.name = entity.name;
            islem.image = entity.image;
        }
        public override void doSil(int id, manufacturerVm entity)
        {
            manufacturer sil = new manufacturer();
            EntityKey silId = new EntityKey("b2cEntities.manufacturer", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
