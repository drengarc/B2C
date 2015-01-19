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
    public class productCntrl : BaseCtrl<productVm, int>
    {
        productService Service = new productService();
        public override List<productVm> doListe_Al(productVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(productVm entity)
        {
            product ekle = new product();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(productVm entity, int id)
        {
            product islem = new product();
            EntityKey guncelleId = new EntityKey("b2cEntities.product", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product islem, productVm entity)
        {
            islem.quantity = entity.quantity;
            islem.name = entity.name;
            islem.category_id = entity.category_id;
            islem.price = entity.price;
            islem.date_added = entity.date_added;
            islem.discount_price = entity.discount_price;
            islem.cargo_price = entity.cargo_price;
            islem.last_modified = entity.last_modified;
            islem.active = entity.active;
            //islem.shipment_package_id = entity.shipment_package_id;
            islem.manufacturer_id = entity.manufacturer_id;
            islem.description = entity.description;
            //islem.fulltext = entity.fulltext;
            //islem.attr = entity.attr;
            islem.sync_ege = entity.sync_ege;
            islem.kdv = entity.kdv;
            //islem.currency_id = entity.currency_id;
            //islem.currency_value = entity.currency_value;
            islem.volume = entity.volume;
            islem.weight = entity.weight;
            islem.partner_code = entity.partner_code;
            islem.toptanci_id = entity.toptanci_id;
            islem.minimum_order_amount = entity.minimum_order_amount;
            islem.grup_id = entity.grup_id;
        }
        public override void doSil(int id, productVm entity)
        {
            product sil = new product();
            EntityKey silId = new EntityKey("b2cEntities.product", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
