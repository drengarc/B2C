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
    public class bannerCntrl : BaseCtrl<bannerVm, int>
    {
        bannerService Service = new bannerService();
        public override List<bannerVm> doListe_Al(bannerVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(bannerVm entity)
        {
            banner ekle = new banner();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(bannerVm entity, int id)
        {
            banner islem = new banner();
            EntityKey guncelleId = new EntityKey("b2cEntities.banner", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(banner islem, bannerVm entity)
        {
            islem.title = entity.title;
            islem.url = entity.url;
           // islem.language_id = entity.language_id;
            islem.image = entity.image;
            islem.html_text = entity.html_text;
            islem.end_date = entity.end_date;
            islem.start_date = entity.start_date;
            islem.date_added = entity.date_added;
            islem.is_active = entity.is_active;
            islem.area_id = entity.area_id;
        }
        public override void doSil(int id, bannerVm entity)
        {
            banner sil = new banner();
            EntityKey silId = new EntityKey("b2cEntities.banner", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
