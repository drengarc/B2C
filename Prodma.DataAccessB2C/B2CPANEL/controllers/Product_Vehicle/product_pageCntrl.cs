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
    public class product_pageCntrl : BaseCtrl<product_pageVm, int>
    {
        product_pageService Service = new product_pageService();
        public override List<product_pageVm> doListe_Al(product_pageVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_pageVm entity)
        {
            product_page ekle = new product_page();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); //entity.id = ekle.id;
        }
        public override void doGuncelle(product_pageVm entity, int id)
        {
            //product_page islem = new product_page();
            //EntityKey guncelleId = new EntityKey("b2cEntities.product_page", "id", entity.id);
            //islem.EntityKey = guncelleId;
            ////islem.id = id;
            //EkleGuncelle(islem, entity);
            //Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_page islem, product_pageVm entity)
        {
            islem.product_id = entity.product_id;
            islem.page_title = entity.page_title;
            islem.page_description = entity.page_description;
            islem.keywords = entity.keywords;
        }
        public override void doSil(int id, product_pageVm entity)
        {
            //product_page sil = new product_page();
            //EntityKey silId = new EntityKey("b2cEntities.product_page", "id", entity.id);
            //sil.EntityKey = silId;
            //sil.id = entity.id; 
            //Service.Service_Sil(sil, id);
        }
    }    
 
}
