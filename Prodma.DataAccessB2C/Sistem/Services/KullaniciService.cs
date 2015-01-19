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
    public class KullaniciService : AService<KULLANICI, int, KullaniciVm> 
    {
       
        public override void doService_Guncelle(KULLANICI entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }
            
        }
        public override void doService_Sil(KULLANICI entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {

                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                 context.SaveChanges();
             }
    
        }
        public override void doService_Ekle(KULLANICI entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToKULLANICI(entity);
                 context.SaveChanges();
                 insertId = entity.ID;
             }
           
        }
        public void Log_Kayit(Log entity)
        {
            try
            {
                b2cEntities context = new b2cEntities();
                using (context)
                {
                    context.AddToLog(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                
              //  throw;
            }
        

        }
        public override List<KullaniciVm> doService_Liste_Al(KullaniciVm fVm)
        {
             try
             {
                    b2cEntities context = new b2cEntities();
            
                    using (context)
                    {
                            if (fVm != null)
                            {
                            var list = (from kul in context.KULLANICI
                                        where kul.KULLANICI_AD == fVm.KULLANICI_AD && kul.SIFRE == fVm.SIFRE //&& kul.LK_DURUM_ID==fVm.LK_DURUM_ID
                                        select new KullaniciVm
                                            {
                                                ID = kul.ID,
                                                SIFRE = kul.SIFRE,
                                                AD = kul.AD,
                                                SOYAD = kul.SOYAD,
                                                MAIL = kul.MAIL,
                                                FOTO = kul.FOTO,
                                                //LOCAL_PATH = kul.LOCAL_PATH,
                                                FIRMA_ID = kul.FIRMA_ID,
                                                KULLANICI_AD = kul.KULLANICI_AD,
                                                ROL_ID = kul.ROL_ID,
                                                DIL_ID = kul.DIL_ID,
                                                LK_DURUM_ID = kul.LK_DURUM_ID,
                                                //FIRMA_DISI_E_H = kul.FIRMA_DISI_E_H,
                                                //FIRMA_DISI_MAX_ISK_YUZ = kul.FIRMA_DISI_MAX_ISK_YUZ,
                                                //SARF_AMBAR_ID = kul.SARF_AMBAR_ID,
                                                //ILERI_FIS_GIRIS_E_H = kul.ILERI_FIS_GIRIS_E_H == null ? (int)EvetHayirEn.Hayir : kul.ILERI_FIS_GIRIS_E_H,
                                                //GERI_FIS_GIRIS_E_H = kul.GERI_FIS_GIRIS_E_H == null ? (int)EvetHayirEn.Hayir : kul.GERI_FIS_GIRIS_E_H,
                                                //BAYI_SIPARIS_ONAY_E_H = kul.BAYI_SIPARIS_ONAY_E_H,
                                                //EK_ISK_YUZ = kul.EK_ISK_YUZ,
                                                //CARI_PLASIYER_ID = kul.CARI_PLASIYER_ID,
                                                //KULLANICI_FIRMA_TIP_ID = kul.KULLANICI_FIRMA_TIP_ID,
                                                //TEKLIF_TIP_ID = kul.TEKLIF_TIP_ID,
                                                //SIPARIS_TIP_ID = kul.SIPARIS_TIP_ID,
                                                //CARI_SATIS_ELEMANI_ID = kul.CARI_SATIS_ELEMANI_ID,
                                                //CARI_AGENT_ID = kul.CARI_AGENT_ID,
                                                //AGENT_SIFRE = kul.AGENT_SIFRE,
                                                //BARKOD_KULLANICI_E_H = kul.BARKOD_KULLANICI_E_H,
                                                //KULLANICI_ALANLAR_OZEL_E_H = kul.KULLANICI_ALANLAR_OZEL_E_H,
                                                //CARI_GOZLEM_AC_E_H = kul.CARI_GOZLEM_AC_E_H,
                                                //UST_KULLANICI_ID = kul.UST_KULLANICI_ID,
                                                //ESKI_KULLANICI_KOD = kul.ESKI_KULLANICI_KOD

                                            }).ToList();
                                    return list;
                            }
                            else
                            {
                                var list1 = (from kul in context.KULLANICI
                                        select new KullaniciVm
                                        {
                                            ID = kul.ID,
                                            SIFRE = kul.SIFRE,
                                            AD = kul.AD,
                                            SOYAD = kul.SOYAD,
                                            MAIL = kul.MAIL,
                                            FOTO = kul.FOTO,
                                            FIRMA_ID = kul.FIRMA_ID,
                                            KULLANICI_AD = kul.KULLANICI_AD,
                                            ROL_ID = kul.ROL_ID,
                                            DIL_ID = kul.DIL_ID,
                                            //LK_DURUM_ID = kul.LK_DURUM_ID,
                                            //FIRMA_DISI_E_H = kul.FIRMA_DISI_E_H,
                                            //FIRMA_DISI_MAX_ISK_YUZ = kul.FIRMA_DISI_MAX_ISK_YUZ,
                                            //SARF_AMBAR_ID = kul.SARF_AMBAR_ID,
                                            //ILERI_FIS_GIRIS_E_H = kul.ILERI_FIS_GIRIS_E_H,
                                            //GERI_FIS_GIRIS_E_H = kul.GERI_FIS_GIRIS_E_H,
                                            //BAYI_SIPARIS_ONAY_E_H = kul.BAYI_SIPARIS_ONAY_E_H,
                                            //EK_ISK_YUZ = kul.EK_ISK_YUZ,
                                            //CARI_PLASIYER_ID = kul.CARI_PLASIYER_ID,
                                            //KULLANICI_FIRMA_TIP_ID = kul.KULLANICI_FIRMA_TIP_ID,
                                            //TEKLIF_TIP_ID = kul.TEKLIF_TIP_ID,
                                            //SIPARIS_TIP_ID = kul.SIPARIS_TIP_ID,
                                            //CARI_SATIS_ELEMANI_ID = kul.CARI_SATIS_ELEMANI_ID,
                                            //CARI_AGENT_ID = kul.CARI_AGENT_ID,
                                            //AGENT_SIFRE = kul.AGENT_SIFRE,
                                            //BARKOD_KULLANICI_E_H = kul.BARKOD_KULLANICI_E_H,
                                            //KULLANICI_ALANLAR_OZEL_E_H = kul.KULLANICI_ALANLAR_OZEL_E_H,
                                            //CARI_GOZLEM_AC_E_H = kul.CARI_GOZLEM_AC_E_H,
                                            //UST_KULLANICI_ID = kul.UST_KULLANICI_ID,
                                            //ESKI_KULLANICI_KOD = kul.ESKI_KULLANICI_KOD,
                                        }).ToList();
                            return list1;
                            }
                      }
                 }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message.ToString() + " " + ex.InnerException.ToString());
             }
                 return null;
                 //if (fVm != null && fVm.KULLANICI_AD=="")
                 //{
                 //    List<KullaniciVm> t;
                 //    t = fVm.ID == 0 ? list.WhereByExample(fVm, "ID").ToList() : list.Where(x => x.ID == fVm.ID).ToList();
                 //    return t;
                 //}
                 //else
                 //{
                 //    return list.ToList();
                 //}
 
        }
       
    }
}
