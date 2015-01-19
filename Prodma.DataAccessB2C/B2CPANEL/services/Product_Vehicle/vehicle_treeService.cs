using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using System.Configuration;
using Prodma.DataAccessB2C;
using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using B2C.Models;
namespace B2C.Services
{
    public class vehicle_treeService : AService<vehicle_tree, int, vehicle_treeVm>  
    {

        public override void doService_Guncelle(vehicle_tree entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(vehicle_tree entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(vehicle_tree entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTovehicle_tree(entity);
                context.SaveChanges();
            }
           
        }
        public override List<vehicle_treeVm> doService_Liste_Al(vehicle_treeVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.vehicle_tree
                            select new vehicle_treeVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    image = kul.image,
                                    slug = kul.slug,
                                    parent_id = kul.parent_id,
                                    description = kul.description,
                                    //lft = kul.lft,
                                    //rght = kul.rght,
                                    //tree_id = kul.tree_id,
                                    level = kul.level,
                                    model_id  = kul.parent_id,
                                    marka_id = kul.vehicle_tree2.parent_id
                                });
                if (fVm != null)
                {
                    List<vehicle_treeVm> t;
                    t = fVm.id == 0 ? list.WhereByExample(fVm, "id").ToList() : list.Where(x => x.id == fVm.id).ToList();
                    return t;
                }
                else
                {
                    return list.ToList();
                }
            }
 
        }
        
    }
}
