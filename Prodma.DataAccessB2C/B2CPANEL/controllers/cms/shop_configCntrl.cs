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
    public class shop_configCntrl : BaseCtrl<shop_configVm, int>
    {
        shop_configService Service = new shop_configService();
        public override List<shop_configVm> doListe_Al(shop_configVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(shop_configVm entity)
        {
            shop_config ekle = new shop_config();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(shop_configVm entity, int id)
        {
            shop_config islem = new shop_config();
            EntityKey guncelleId = new EntityKey("b2cEntities.shop_config", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(shop_config islem, shop_configVm entity)
        {
            islem.key = entity.key;
            islem.value = entity.value;
        }
        public override void doSil(int id, shop_configVm entity)
        {
            shop_config sil = new shop_config();
            EntityKey silId = new EntityKey("b2cEntities.shop_config", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
