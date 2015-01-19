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
    public class est_bankCntrl : BaseCtrl<est_bankVm, int>
    {
        est_bankService Service = new est_bankService();
        public override List<est_bankVm> doListe_Al(est_bankVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(est_bankVm entity)
        {
            est_bank ekle = new est_bank();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(est_bankVm entity, int id)
        {
            est_bank islem = new est_bank();
            EntityKey guncelleId = new EntityKey("b2cEntities.est_bank", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(est_bank islem, est_bankVm entity)
        {
            islem.name = entity.name;
            islem.image = entity.image;
        }
        public override void doSil(int id, est_bankVm entity)
        {
            est_bank sil = new est_bank();
            EntityKey silId = new EntityKey("b2cEntities.est_bank", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
