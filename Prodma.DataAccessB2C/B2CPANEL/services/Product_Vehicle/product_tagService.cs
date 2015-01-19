﻿using System;
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
    public class product_tagService : AService<product_tag, int, product_tagVm>  
    {

        public override void doService_Guncelle(product_tag entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(product_tag entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(product_tag entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToproduct_tag(entity);
                context.SaveChanges();
            }
           
        }
        public override List<product_tagVm> doService_Liste_Al(product_tagVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.product_tag
                            select new product_tagVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    slug = kul.slug,
                                });
                if (fVm != null)
                {
                    List<product_tagVm> t;
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
