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
using Prodma.SistemB2C.Models;
namespace Prodma.SistemB2C.Services
{
    public class MesajService : AService<MESAJ, int, MesajVm> 
    {
        
        public override void doService_Guncelle(MESAJ entity, int  id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }
            
        }
        public override void doService_Sil(MESAJ entity, int id)
        {

             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                 context.SaveChanges();
             }
    
        }
        public override void doService_Ekle(MESAJ entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToMESAJ(entity);
                 context.SaveChanges();
             }
           
        }
        public override List<MesajVm> doService_Liste_Al(MesajVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 var list = (from kul in context.MESAJ
                             select new MesajVm
                                 {
                                     ID = kul.ID,
                                     MESAJ_TIP_ID = kul.MESAJ_TIP_ID,
                                     KIMDEN_KULLANICI_ID = kul.KIMDEN_KULLANICI_ID,
                                     KIME_KULLANICI_ID = kul.KIME_KULLANICI_ID,
                                     MESAJ = kul.MESAJ1,
                                     MESAJ_2 = kul.MESAJ_2,
                                     MESAJ_3 = kul.MESAJ_3,
                                     OKUNDU_E_H = kul.OKUNDU_E_H,
                                     //LK_DURUM_ID = kul.L
                                 });
                 if (fVm != null)
                 {
                     List<MesajVm> t;
                     t = fVm.ID == 0 ? list.WhereByExample(fVm, "ID").ToList() : list.Where(x => x.ID == fVm.ID).ToList();
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
