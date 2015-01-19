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
     public class YetkiIslemlerService : AService<YETKI_ISLEMLER, int, YetkiIslemlerVm>
    {
        
        public override void doService_Guncelle(YETKI_ISLEMLER entity, int id)
        {

             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }

        }
        public override void doService_Sil(YETKI_ISLEMLER entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                 context.SaveChanges();
             }


        }
        public override void doService_Ekle(YETKI_ISLEMLER entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToYETKI_ISLEMLER(entity);
                 context.SaveChanges();
             }

        }
        public override List<YetkiIslemlerVm> doService_Liste_Al(YetkiIslemlerVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 if (fVm.ListeFiltresi != "" && fVm.ListeFiltresi != null)
                 {
                     int tipID = Convert.ToInt32(fVm.ListeFiltresi);
                     var list = (from kul in context.YETKI_ISLEMLER
                                 where kul.YETKI_ISLEM_TANITIM.YETKI_ISLEM_SAHIBI_TANITIM.YETKI_ISLEM_SAHIBI_TIP_ID == tipID && kul.KULLANICI_ID == fVm.KULLANICI_ID
                                 select new YetkiIslemlerVm
                                 {
                                     ID = kul.ID,
                                     KULLANICI_ID = kul.KULLANICI_ID,
                                     YETKI_ISLEM_TANTIM_ID = kul.YETKI_ISLEM_TANTIM_ID,
                                     YETKILI_E_H = kul.YETKILI_E_H,
                                     SINIRLI_YETKI_E_H = kul.SINIRLI_YETKI_E_H,
                                     YETKIISLEMTANITIM = new YetkiIslemTanitimVm()
                                     {
                                         ID = kul.YETKI_ISLEM_TANITIM.ID,
                                         AD = kul.YETKI_ISLEM_TANITIM.AD,
                                         KOD = kul.YETKI_ISLEM_TANITIM.KOD,
                                         TAG_NAME = kul.YETKI_ISLEM_TANITIM.TAG_NAME,
                                         HINT_NAME = kul.YETKI_ISLEM_TANITIM.HINT_NAME,
                                         IMAGE_NAME = kul.YETKI_ISLEM_TANITIM.IMAGE_NAME
                                     },
                                     YETKILI_ISLEM_SAHIBI_AD = kul.YETKI_ISLEM_TANITIM.YETKI_ISLEM_SAHIBI_TANITIM.AD,
                                 });
                     return list.ToList();
                 }
                 else
                 {
                     var list = (from kul in context.YETKI_ISLEMLER
                                 select new YetkiIslemlerVm
                                 {
                                     ID = kul.ID,
                                     KULLANICI_ID = kul.KULLANICI_ID,
                                     YETKI_ISLEM_TANTIM_ID = kul.YETKI_ISLEM_TANTIM_ID,
                                     YETKILI_E_H = kul.YETKILI_E_H,
                                     SINIRLI_YETKI_E_H = kul.SINIRLI_YETKI_E_H,
                                     YETKIISLEMTANITIM = new YetkiIslemTanitimVm()
                                     {
                                         ID = kul.YETKI_ISLEM_TANITIM.ID,
                                         AD = kul.YETKI_ISLEM_TANITIM.AD,
                                         KOD = kul.YETKI_ISLEM_TANITIM.KOD,
                                         TAG_NAME = kul.YETKI_ISLEM_TANITIM.TAG_NAME,
                                         HINT_NAME = kul.YETKI_ISLEM_TANITIM.HINT_NAME,
                                         IMAGE_NAME = kul.YETKI_ISLEM_TANITIM.IMAGE_NAME
                                     },
                                     YETKILI_ISLEM_SAHIBI_AD = kul.YETKI_ISLEM_TANITIM.YETKI_ISLEM_SAHIBI_TANITIM.AD,
                                 });
                     if (fVm != null)
                     {

                         if (fVm.ID == 0 && fVm.YETKI_ISLEM_TANTIM_ID==0)
                         {
                             return list.ToList();
                         }
                         else
                         {
                             List<YetkiIslemlerVm> t;
                             t = fVm.ID == 0 ? list.WhereByExample(fVm, "ID").ToList() : list.Where(x => x.ID == fVm.ID).ToList();
                             return t;
                         }
                       
                     }
                     else
                     {
                         return list.ToList();
                     }
                 }
                 
             }
 
        }
    }
}
