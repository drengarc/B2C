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
    public class categoryCntrl : BaseCtrl<categoryVm, int>
    {
        categoryService Service = new categoryService();
        public override List<categoryVm> doListe_Al(categoryVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(categoryVm entity)
        {
            category ekle = new category();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(categoryVm entity, int id)
        {
            category islem = new category();
            EntityKey guncelleId = new EntityKey("b2cEntities.category", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(category islem, categoryVm entity)
        {
            islem.name = entity.name;
            islem.image = entity.image;
            islem.parent_id = entity.parent_id;
            islem.description = entity.description;
            islem.slug = entity.slug;
            islem.lft = entity.lft;
            islem.rght = entity.rght;
            islem.tree_id = entity.tree_id;
            islem.level = entity.level;
            islem.vehicle_category = entity.vehicle_category;
        }
        public override void doSil(int id, categoryVm entity)
        {
            category sil = new category();
            EntityKey silId = new EntityKey("b2cEntities.category", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
