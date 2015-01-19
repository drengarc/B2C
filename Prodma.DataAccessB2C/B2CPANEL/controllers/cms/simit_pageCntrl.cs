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
    public class simit_pageCntrl : BaseCtrl<simit_pageVm, int>
    {
        simit_pageService Service = new simit_pageService();
        public override List<simit_pageVm> doListe_Al(simit_pageVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(simit_pageVm entity)
        {
            simit_page ekle = new simit_page();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(simit_pageVm entity, int id)
        {
            simit_page islem = new simit_page();
            EntityKey guncelleId = new EntityKey("b2cEntities.simit_page", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(simit_page islem, simit_pageVm entity)
        {
            islem.name = entity.name;
            islem.content = entity.content;
            islem.slug = entity.slug;
            islem.tags = entity.tags;
            islem.description = entity.description;
            islem.title = entity.title;
            islem.last_modified = entity.last_modified;
            islem.is_active = entity.is_active;
        }
        public override void doSil(int id, simit_pageVm entity)
        {
            simit_page sil = new simit_page();
            EntityKey silId = new EntityKey("b2cEntities.simit_page", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
