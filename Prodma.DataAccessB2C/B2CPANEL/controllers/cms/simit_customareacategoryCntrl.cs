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
    public class simit_customareacategoryCntrl : BaseCtrl<simit_customareacategoryVm, int>
    {
        simit_customareacategoryService Service = new simit_customareacategoryService();
        public override List<simit_customareacategoryVm> doListe_Al(simit_customareacategoryVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(simit_customareacategoryVm entity)
        {
            simit_customareacategory ekle = new simit_customareacategory();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(simit_customareacategoryVm entity, int id)
        {
            simit_customareacategory islem = new simit_customareacategory();
            EntityKey guncelleId = new EntityKey("b2cEntities.simit_customareacategory", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(simit_customareacategory islem, simit_customareacategoryVm entity)
        {
            islem.name = entity.name;
        }
        public override void doSil(int id, simit_customareacategoryVm entity)
        {
            simit_customareacategory sil = new simit_customareacategory();
            EntityKey silId = new EntityKey("b2cEntities.simit_customareacategory", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
