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
    public class FirmaService : AService<FIRMA, int, FirmaVm>
    {
       
        public override void doService_Guncelle(FIRMA entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }
            
        }
        public override void doService_Sil(FIRMA entity, int id)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
         
    
        }
        public override void doService_Ekle(FIRMA entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToFIRMA(entity);
                 context.SaveChanges();
             }
           
        }
        public override List<FirmaVm> doService_Liste_Al(FirmaVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 var list = (from kul in context.FIRMA
                             select new FirmaVm
                                 {
                                     ID = kul.ID,
                                     FIRMA_ID = kul.ID,
                                     AD = kul.AD,
                                     ADR1 = kul.ADR1,
                                     //ADR2 = kul.ADR2,
                                     //ADR3 = kul.ADR3,
                                     //VERGI_DAIRE = kul.VERGI_DAIRE,
                                     //VERGI_NO = kul.VERGI_NO,
                                     //TEL = kul.TEL,
                                     //FAX = kul.FAX,
                                     //MAIL = kul.MAIL,
                                     //WEB_ADRES = kul.WEB_ADRES,
                                     //FIRMA_TIP_ID = kul.FIRMA_TIP_ID,
                                     //FIRMA_TEHLIKE_TIP_ID = kul.FIRMA_TEHLIKE_TIP_ID,
                                     //ASIL_FIRMA_ID = kul.ASIL_FIRMA_ID,
                                     //ESKI_KOD = kul.ESKI_KOD,
                                     //LOGO_PATH = kul.LOGO_PATH,
                                     //RESIM_PATH = kul.RESIM_PATH,
                                     //GUNCELLEME_PATH = kul.GUNCELLEME_PATH,
                                     //RAPOR_PATH = kul.RAPOR_PATH,
                                     //DESTEK_ELEMAN_SAYISI = kul.DESTEK_ELEMAN_SAYISI,
                                     //ACIL_DURUM_YENILEME_PERIYOD = kul.ACIL_DURUM_YENILEME_PERIYOD,
                                     //YILLIK_EGITIM_YENILEME_PERIYOD = kul.YILLIK_EGITIM_YENILEME_PERIYOD,
                                     //PERIYODIK_EGITIM_DAKIKA = kul.PERIYODIK_EGITIM_DAKIKA,
                                     //ARSIV_PATH = kul.ARSIV_PATH,
                                 });
                 if (fVm != null)
                 {
                     List<FirmaVm> t;
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
