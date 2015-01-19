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
    public class vehicle_treeCntrl : BaseCtrl<vehicle_treeVm, int>
    {
        vehicle_treeService Service = new vehicle_treeService();
        public override List<vehicle_treeVm> doListe_Al(vehicle_treeVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(vehicle_treeVm entity)
        {
            vehicle_tree ekle = new vehicle_tree();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(vehicle_treeVm entity, int id)
        {
            vehicle_tree islem = new vehicle_tree();
            EntityKey guncelleId = new EntityKey("b2cEntities.vehicle_tree", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(vehicle_tree islem, vehicle_treeVm entity)
        {
            islem.name = entity.name;
            islem.image = entity.image;
            islem.slug = entity.slug;
            islem.parent_id = entity.parent_id;
            islem.description = entity.description;
            //islem.lft = entity.lft;
            //islem.rght = entity.rght;
            //islem.tree_id = entity.tree_id;
            islem.level = entity.level;
        }
        public override void doSil(int id, vehicle_treeVm entity)
        {
            vehicle_tree sil = new vehicle_tree();
            EntityKey silId = new EntityKey("b2cEntities.vehicle_tree", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
