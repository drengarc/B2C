using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Prodma.DataAccess;
using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection;
//using LinqKit;
using System.Collections;
using System.Text;
using System.Linq.Dynamic;
using Prodma.Sistem.Models;
using DevExpress.XtraEditors;
using System.Data.Objects.SqlClient;
using IsGuvenligi.Listeler.PersonelListeleri.Models;
using IsGuvenligi.Models;
namespace IsGuvenligi.Listeler.PersonelListeleri.Services
{
    public class ListeYap : ListeYapBase
    {
        public string metodName;
        public ListeYap(string _metodName, Dictionary<string, string> _parameters)
        {
            metodName = _metodName;
            parameters1 = _parameters;
         
        }
        public ListeYap()
        {
        }
        public Object InvokeMethod()
        {
            string ns = "IsGuvenligi.Listeler.PersonelListeleri.Services";
            string tn = "ListeYap";
            string an = "Prodma.DataAccess";
            Type calledType = Type.GetType(ns + "." + tn + "," + an);
            MethodInfo methodInfo = calledType.GetMethod(metodName);
            if (methodInfo != null)
            {
                object result = null;
                object[] parametersArray2 = new object[] { metodName, parameters1 };
                ParameterInfo[] parameters = methodInfo.GetParameters();
                object classInstance = Activator.CreateInstance(calledType, parametersArray2);
                if (parameters.Length == 0)
                {
                    //This works fine
                    result = methodInfo.Invoke(classInstance, null);
                    return result;
                }
                else
                {
                    object[] parametersArray = new object[] { parameters1 };
                    try
                    {
                        result = methodInfo.Invoke(classInstance, parametersArray);
                        ListeYap bosalt = (ListeYap)classInstance;
                        //bosalt.stokFiltreList = null;
                        //bosalt.cariFiltreList = null;
                       
                        bosalt = null;
                        GC.Collect();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Liste Çekiminde Bir Hata Oluştu.");
                        Prodma.LogHelper.LogError(ex.InnerException.ToString(), "Çek Listesi");
                        ListeYap bosalt = (ListeYap)classInstance;
                        //bosalt.stokFiltreList = null;
                        //bosalt.cariFiltreList = null;
        
                        bosalt = null;
                        GC.Collect();
                        return null;
                    }
                }
            }
            else
            { return null; }



            //Object s = (Object)calledType.InvokeMember(methodName, System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, null, null, null);

        }
        #region PersonelList
        public List<PersonelKontrolVm> PersonelKontrolList(Dictionary<string, string> parameters)
        {
            IsciPerformansEntities context1 = new IsciPerformansEntities();
            using (context1)
            {
                context1.CommandTimeout = 600;
                PersonelFiltrele(PersonelFiltreleTipEn.SadecePersonel);
                var list = (from c in personelFiltreList
                            join fis in
                                (from t in context1.PERSONEL_EGITIM
                                 where t.EGITIM_TANIMLAMALARI.EGITIM_TIP_TANIMLAMALARI_ID == (int)VarsayilanIdlerEn.EgitimKonuMevzuatSinirli
                                 select new
                                 {
                                     PERSONEL_ID = t.PERSONEL_ID,
                                     EGITIM_SURE = t.EGITIM_SURE,
                                 }) 
                             on c.ID equals fis.PERSONEL_ID into j2
                            from sonuc in j2.DefaultIfEmpty()
                            select new PersonelKontrolVm
                            {
                                AD = c.ADI,
                                SOYAD = c.SOYADI,
                                TC_NO = c.TC_KIMLIK_NO,
                                EGITIM_SAAT = sonuc!= null ? (int?)sonuc.EGITIM_SURE : 0,
                                PERSONEL_IDtemp = c.PERSONEL_ID,
                                PERSONELVM = c,
                            }).ToList();
               // return null;
                return ListIslemTum(list, parameters);
            }
        }
        static List<PersonelKontrolVm> ListIslemTum(List<PersonelKontrolVm> model, Dictionary<string, string> parameters)
        {
            List<PersonelKontrolVm> ModelList = new List<PersonelKontrolVm>();
            PersonelKontrolVm Vm = new PersonelKontrolVm();
            int? personelid = model[0].PERSONEL_IDtemp;
            Vm = model[0];
            int egitimSaat = 0;
            for (int i = 0; i < model.Count; i++)
            {
                if (personelid == model[i].PERSONEL_IDtemp)
                {
                    egitimSaat += Convert.ToInt32(model[i].EGITIM_SAAT);
                }
                else
                {
                    Vm.EGITIM_SAAT = egitimSaat;
                    Vm.TOPLAM_SAAT = Globals.toplamEgitimSaat;
                    Vm.GEREKEN_SAAT = Globals.toplamEgitimSaat - egitimSaat;
                //    grupSet(Vm, parameters);
                    ModelList.Add(Vm);
                    if (personelid == 0) break;// son kayit ise fordan ciksin diye
                    personelid = model[i].PERSONEL_IDtemp;
                    egitimSaat = 0;
                    Vm = model[i];
                    i--;// kayit bir oncekine geri donuyor.
                }
                if (i == model.Count - 1) { personelid = 0; i--; }// son kayit ise else'kayita''e girebilmesi icin               
            }
            return ModelList;
        }

        public List<KurulToplantilariSonucList> KurulSonuclarList(Dictionary<string, string> parameters)
        {
            int kurulToplantilariId= Convert.ToInt32(parameters["kurulToplantilariId"]);
            int kurullarId= 1;
            IsciPerformansEntities context1 = new IsciPerformansEntities();
            List<KurulToplantilariSonucList> sonucList = new List<KurulToplantilariSonucList>();
            List<KurulToplantilariVm> kurulToplantisi = new List<KurulToplantilariVm>();
            using (context1)
            {

                context1.CommandTimeout = 600;
                 kurulToplantisi = (from t in context1.KURUL_TOPLANTILARI 
                             where t.ID == kurulToplantilariId
                             select new KurulToplantilariVm
                             {
                                ID = t.ID,
                                YER = t.YER,
                                TARIH = t.TARIH,
                                SIRA = t.SIRA,
                             }).ToList();

                
                context1.CommandTimeout = 600;
               sonucList = (from t in context1.KURUL_TOPLANTILARI_SONUC
                                 where t.KURUL_TOPLANTILARI_ID == kurulToplantilariId
                                 select new KurulToplantilariSonucList
                                 {
                                     ID = t.ID,
                                     KONU = t.KONU,
                                     KONU_DEGERLENDIRME = t.KONU_DEGERLENDIRME,
                                     BASLANGIC_TARIH = t.BASLANGIC_TARIH,
                                     BITIS_TARIH = t.BITIS_TARIH,
                                     intTemp = t.KURUL_TOPLANTILARI.KURULLAR_ID,
                                 }).ToList();


               var sonucGorevlendirmeList = (from t in context1.KURUL_TOPLANTILARI_SONUC_GOREVLENDIRME
                            where t.KURUL_TOPLANTILARI_SONUC.KURUL_TOPLANTILARI_ID == kurulToplantilariId
                            select new
                            {
                                ID = t.KURUL_TOPLANTILARI_SONUC_ID,
                                ACIKLAMA = t.PERSONEL.ADI.ToUpper() + " " + t.PERSONEL.SOYADI, 
                            }).ToList();              
 
                
               foreach (var item in sonucList)
               {
                   var gorev = (from g in sonucGorevlendirmeList 
                                where g.ID == item.ID 
                                select new 
                                { 
                                    AD_SOYAD = g.ACIKLAMA
                                }).ToList();
                   foreach (var item1 in gorev)
                   {
                       item.SORUMLULAR += item1.AD_SOYAD.ToLower() +  " , ";
                   }
                  
               }
                // return null;
                kurullarId = sonucList[0].intTemp;
                var listkurul = (from t in context1.PERSONEL_KURUL_UYELIKLERI
                                 where t.KURULLAR_ID == kurullarId
                                 select new KurulUyeleri
                                 {
                                     ADI_SOYADI = t.PERSONEL.ADI + " " + t.PERSONEL.SOYADI,
                                     GOREVI = t.PERSONEL.UNVAN_TANITIM.ACIKLAMA,
                                 }).ToList();


                   var listgundem = (from t in context1.KURUL_TOPLANTILARI_GUNDEM
                                     where t.KURUL_TOPLANTILARI_ID == kurulToplantilariId
                                 select new KurulGundemi
                                 {
                                     ACIKLAMA = t.KONU
                                 }).ToList();

                sonucList[0].KURULUYELERI = listkurul;
                sonucList[0].KURULGUNDEMI = listgundem;
                sonucList[0].KURULTOPLANTISI = kurulToplantisi;

                return sonucList;
            }
        }
        #endregion
    }
}
