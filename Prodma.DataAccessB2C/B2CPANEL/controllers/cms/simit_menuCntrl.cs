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
    public class simit_menuCntrl : BaseCtrl<simit_menuVm, int>
    {
        simit_menuService Service = new simit_menuService();
        public override List<simit_menuVm> doListe_Al(simit_menuVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(simit_menuVm entity)
        {
            simit_menu ekle = new simit_menu();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(simit_menuVm entity, int id)
        {
            simit_menu islem = new simit_menu();
            EntityKey guncelleId = new EntityKey("b2cEntities.simit_menu", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(simit_menu islem, simit_menuVm entity)
        {
            islem.title = entity.title;
            islem.parent_id = entity.parent_id;
            islem.description = entity.description;
            islem.url = entity.url;
            islem.page_id = entity.page_id;
            islem.url_name = entity.url_name;
            islem.section_id = entity.section_id;
            islem.is_active = entity.is_active;
            islem.lft = entity.lft;
            islem.rght = entity.rght;
            islem.tree_id = entity.tree_id;
            islem.level = entity.level;
        }
        public override void doSil(int id, simit_menuVm entity)
        {
            simit_menu sil = new simit_menu();
            EntityKey silId = new EntityKey("b2cEntities.simit_menu", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
