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
    public class banner_areaCntrl : BaseCtrl<banner_areaVm, int>
    {
        banner_areaService Service = new banner_areaService();
        public override List<banner_areaVm> doListe_Al(banner_areaVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(banner_areaVm entity)
        {
            banner_area ekle = new banner_area();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(banner_areaVm entity, int id)
        {
            banner_area islem = new banner_area();
            EntityKey guncelleId = new EntityKey("b2cEntities.banner_area", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(banner_area islem, banner_areaVm entity)
        {
            islem.name = entity.name;
        }
        public override void doSil(int id, banner_areaVm entity)
        {
            banner_area sil = new banner_area();
            EntityKey silId = new EntityKey("b2cEntities.banner_area", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
