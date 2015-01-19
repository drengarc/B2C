using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq.DynamicB2C;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Prodma.SistemB2C.Models;
using System.Globalization;
using System.Data.Objects.SqlClient;
using Prodma.SistemB2C.Controllers;
namespace Prodma.DataAccessB2C
{
    public class ListDenemeService
    {
         
        public static List<YetkiIslemlerVm> GetYETKI_ISLEMLER(int kullaniciId, int yetkiIslemId,int islemListe)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                var list = (from kul in context.YETKI_ISLEMLER
                            where kul.KULLANICI_ID == kullaniciId && kul.YETKI_ISLEM_TANITIM.YETKI_ISLEM_SAHIBI_TANITIM_ID == yetkiIslemId 
                            && kul.YETKI_ISLEM_TANITIM.YETKI_ISLEM_SAHIBI_TIP_ID == islemListe && kul.YETKI_ISLEM_TANITIM.LK_DURUM_ID!=(int)DurumEn.Pasif
                            select new YetkiIslemlerVm
                            {
                                ID = kul.ID,
                                KULLANICI_ID = kul.KULLANICI_ID,
                                YETKI_ISLEM_TANTIM_ID = kul.YETKI_ISLEM_TANTIM_ID,
                                YETKILI_E_H = kul.YETKILI_E_H,
                                YETKIISLEMTANITIM = new YetkiIslemTanitimVm()
                                {
                                    ID = kul.YETKI_ISLEM_TANITIM.ID,
                                    AD = kul.YETKI_ISLEM_TANITIM.AD,
                                    KOD = kul.YETKI_ISLEM_TANITIM.KOD,
                                    TAG_NAME = kul.YETKI_ISLEM_TANITIM.TAG_NAME,
                                    HINT_NAME = kul.YETKI_ISLEM_TANITIM.HINT_NAME,
                                    IMAGE_NAME = kul.YETKI_ISLEM_TANITIM.IMAGE_NAME
                                },
                            }).ToList();
                return list;
            }
        }
        public static YetkiIslemlerVm GetYETKI_ISLEMLER(int kullaniciId, int yetkiIslemId, int islemListe,string tagName)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                try
                {
                    var list = (from kul in context.YETKI_ISLEMLER
                                where kul.KULLANICI_ID == kullaniciId && kul.YETKI_ISLEM_TANITIM.YETKI_ISLEM_SAHIBI_TANITIM_ID == yetkiIslemId && kul.YETKI_ISLEM_TANITIM.LK_DURUM_ID != (int)DurumEn.Pasif
                                && kul.YETKI_ISLEM_TANITIM.TAG_NAME == tagName
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
                                }).FirstOrDefault();
                    return list;
                }
                catch (Exception)
                {

                    return null;
                }
                
            }
        }
        public static YetkiIslemlerVm GetYETKI_ISLEM(int kullaniciId, int yetkiIslemId)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                var list = (from kul in context.YETKI_ISLEMLER
                            where kul.KULLANICI_ID == kullaniciId && kul.YETKI_ISLEM_TANTIM_ID == yetkiIslemId
                            select new YetkiIslemlerVm
                            {
                                ID = kul.ID,
                                KULLANICI_ID = kul.KULLANICI_ID,
                                YETKI_ISLEM_TANTIM_ID = kul.YETKI_ISLEM_TANTIM_ID,
                                YETKILI_E_H = kul.YETKILI_E_H,
                                YETKIISLEMTANITIM = new YetkiIslemTanitimVm()
                                {
                                    ID = kul.YETKI_ISLEM_TANITIM.ID,
                                    AD = kul.YETKI_ISLEM_TANITIM.AD,
                                    KOD = kul.YETKI_ISLEM_TANITIM.KOD,
                                    TAG_NAME = kul.YETKI_ISLEM_TANITIM.TAG_NAME,
                                    HINT_NAME = kul.YETKI_ISLEM_TANITIM.HINT_NAME,
                                    IMAGE_NAME = kul.YETKI_ISLEM_TANITIM.IMAGE_NAME
                                },
                            }).FirstOrDefault();
                return list;
            }
        }
        public static YetkiMenulerVm GetYETKI_MENULER(string url)
        {
           // MessageBox.Show("geldi");
            List<YetkiMenulerVm> listYetki;
            b2cEntities context = new  b2cEntities();
          //  MessageBox.Show("geldi 2");
            using (context)
            {
                try
                {
                  //  MessageBox.Show("geldi 3");
                    var list = (from kul in context.M_MENU
                                where kul.URL == url && kul.LK_DURUM_ID == (int)DurumEn.Aktif
                                select kul).OrderBy(x => x.M_MENU_ID).ThenBy(x => x.MENU_SIRA).ToList();
                    //MessageBox.Show("listi aldi");
                 //   MessageBox.Show("geldi 4");
                    if (list.Count > 0)
                    {
                        int id = list[0].ID;
                        listYetki = getYetki(id, Globals.gnKullaniciId);
                      //  MessageBox.Show("geldi 5");

                        if (listYetki != null && listYetki.Count > 0)
                        {
                            return listYetki[0];
                        }
                        else
                        {
                         //   MessageBox.Show("geldi 6 :" + id);

                            var list2 = (from kul in context.M_MENU
                                         where kul.ID == id && kul.LK_DURUM_ID == (int)DurumEn.Aktif
                                         select kul.M_MENU_ID).FirstOrDefault();
                       //     MessageBox.Show("geldi 7");

                            listYetki = getYetki(Convert.ToInt32(list2), Globals.gnKullaniciId);
                      //      MessageBox.Show("geldi 8");

                            if (listYetki != null && listYetki.Count > 0)
                            {
                                return listYetki[0];
                            }
                            else
                            {
                                id = Convert.ToInt32(list2);
                        //        MessageBox.Show("geldi 9");

                                var list3 = (from kul in context.M_MENU
                                             where kul.ID == id && kul.LK_DURUM_ID == (int)DurumEn.Aktif
                                             select kul.M_MENU_ID).FirstOrDefault();
                         //       MessageBox.Show("geldi 10");

                                listYetki = getYetki(Convert.ToInt32(list3), Globals.gnKullaniciId);
                    //            MessageBox.Show("geldi 11");

                                return listYetki != null && listYetki.Count > 0 ? listYetki[0] : null;
                            }
                        }

                    }
                }
                catch (EntitySqlException ex)
                {
                    MessageBox.Show("hata" + ex.InnerException + "ikinci" + ex.Message);
                    throw;
                }
         
            }
            return null;
        }
        public static List<YetkiMenulerVm> getYetki(int id , int kullaniciId)
        {
                b2cEntities context = new  b2cEntities();
                using (context)
                {
                    return (from n in context.YETKI
                                 where n.M_MENU_ID == id && n.KULLANICI_ID == Globals.gnKullaniciId && n.LK_DURUM_ID ==(int)DurumEn.Aktif
                                 select new YetkiMenulerVm
                                 {
                                     ID = n.ID,
                                     KULLANICI_ID = n.KULLANICI_ID,
                                     M_MENU_ID = n.M_MENU_ID,
                                     OKU_E_H = n.OKU_E_H,
                                     YAZ_E_H = n.YAZ_E_H,
                                     GUNCELLE_E_H = n.GUNCELLE_E_H,
                                     GORMESIN_E_H = n.GORMESIN_E_H,
                                     SIL_E_H = n.SIL_E_H,
                                 }).ToList();
                }
        }
        public static string AyAdiBul(int ay)
        {
            if (ay == 1)
            {
                return "OCAK";
            }
            else if (ay == 2)
            {
                return "ŞUBAT";
            }
            else if (ay == 3)
            {
                return "MART";
            }
            else if (ay == 4)
            {
                return "NİSAN";
            }
            else if (ay == 5)
            {
                return "MAYIS";
            }
            else if (ay == 6)
            {
                return "HAZIRAN";
            }
            else if (ay == 7)
            {
                return "TEMMUZ";
            }
            else if (ay == 8)
            {
                return "AĞUSTOS";
            }
            else if (ay == 9)
            {
                return "EYLÜL";
            }
            else if (ay == 10)
            {
                return "EKİM";
            }
            else if (ay == 11)
            {
                return "KASIM";
            }
            else if (ay == 12)
            {
                return "ARALIK";
            }
            else
            {
                return "";
            }

        }
        public static Object[] Gridi_Olustur(GridControl gridControl1, GridView gridView1, string tabloAdi)
        {
            int intBind = 1;
            PanelControl pnlArama = new DevExpress.XtraEditors.PanelControl();
            BindingSource[] bindingSourceArr = new BindingSource[30];
            DevExpress.XtraEditors.TextEdit[] textArama = new DevExpress.XtraEditors.TextEdit[32];
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit;
            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit[] repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit[30];
            DevExpress.XtraGrid.Columns.GridColumn Column1;

            string alanadi = "";
            int intArama = 0;
            try
            {
                var q = ListDenemeService.GetALANLAR(tabloAdi, 1);

                foreach (var ALAN in q)
                {

                    Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                    alanadi = ALAN.ALAN_AD;
                    if (ALAN.M_ALAN_TIP_ID == 1)  // TEXT
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = ALAN.ALAN_LISTE_AD;
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        Column1.Visible = true;
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME); }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.AllowEdit = false;
                        }
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                        repositoryItemTextEdit.AutoHeight = false;
                        repositoryItemTextEdit.MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                        repositoryItemTextEdit.Name = "repositoryItemTextEdit1";
                        Column1.ColumnEdit = repositoryItemTextEdit;

                    }
                    else if (ALAN.M_ALAN_TIP_ID == 2)
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = ALAN.ALAN_LISTE_AD;
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        Column1.Visible = true;

                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.AllowEdit = false;
                        }
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME); }
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemLookUpEdit();
                        string mt = "";
                        mt = "Get" + ALAN.ALAN_AD;
                        bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"", "",0 );
                       
                        repositoryItemLookUpEdit1[intBind].NullText = "";
                        repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            //List<IdAdVm> VM = (List<IdAdVm>)bindingSourceArr[intBind].DataSource;
                            if (repositoryItemLookUpEdit1[intBind].Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].Columns["CARIVM"].Visible = false;
                            }
                        } repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                        repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                        intBind += 1;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 8)// EVET HAYIR
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = ALAN.ALAN_LISTE_AD;
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        Column1.Visible = true;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.AllowEdit = false;
                        }
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME); }
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemLookUpEdit();
                        bindingSourceArr[intBind].DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"", "",0 );
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            //List<IdAdVm> VM = (List<IdAdVm>)bindingSourceArr[intBind].DataSource;
                            if (repositoryItemLookUpEdit1[intBind].Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].Columns["CARIVM"].Visible = false;
                            }
                        }
                        repositoryItemLookUpEdit1[intBind].NullText = "";
                        repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                        repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                        intBind += 1;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 3)//TARIH
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.Caption = ALAN.ALAN_LISTE_AD;
                        Column1.Width = 10;
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME); }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.AllowEdit = false;
                        }
                        repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                        repositoryItemDateEdit.AutoHeight = false;
                        repositoryItemDateEdit.Name = "repositoryItemDateEdit";
                        repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton()});
                        gridControl1.RepositoryItems.Add(repositoryItemDateEdit);
                        Column1.ColumnEdit = repositoryItemDateEdit;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 4)//DECIMAL
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = ALAN.ALAN_LISTE_AD;
                        Column1.BestFit();
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        Column1.Visible = true;
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME); }
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {
                            Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.AllowEdit = false;
                        }
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
                        String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
                        repositoryItemTextEdit.Mask.EditMask = b + "." + a;
                        repositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        repositoryItemTextEdit.Name = "repositoryItemTextEdit";
                        gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                        Column1.ColumnEdit = repositoryItemTextEdit;

                    }

                    else if (ALAN.M_ALAN_TIP_ID == 5)//TAMSAYI
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = ALAN.ALAN_LISTE_AD;
                        Column1.BestFit();
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        Column1.Visible = true;
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {
                            Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.AllowEdit = false;
                        }
                        Column1.VisibleIndex = 1;
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                        repositoryItemTextEdit.AutoHeight = false;
                        repositoryItemTextEdit.MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                        repositoryItemTextEdit.Name = "repositoryItemTextEdit1";
                        Column1.ColumnEdit = repositoryItemTextEdit;
                        intBind += 1;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 6)//checkbox
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = ALAN.ALAN_LISTE_AD;
                        Column1.BestFit();
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        Column1.Visible = true;
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME); }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.AllowEdit = false;
                        }
                        repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        repositoryItemCheckEdit.AutoHeight = false;
                        repositoryItemCheckEdit.Name = "repositoryItemCheckEdit";
                        gridControl1.RepositoryItems.Add(repositoryItemCheckEdit);
                        Column1.ColumnEdit = repositoryItemCheckEdit;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 7) // baglı Alan
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = ALAN.ALAN_LISTE_AD;
                        Column1.BestFit();
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        Column1.Visible = true;
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME); }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.AllowEdit = false;
                        }
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemLookUpEdit();
                        string mt = "";
                        mt = "Get" + ALAN.ALAN_AD;
                        bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"", "",0 );
                        repositoryItemLookUpEdit1[intBind].NullText = "";
                        repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                        repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                        intBind += 1;
                    }
                    gridView1.Columns.Add(Column1);


                    textArama[intArama] = new DevExpress.XtraEditors.TextEdit();
                    textArama[intArama].Name = Column1.FieldName + " :";
                    textArama[intArama].TabIndex = 0;
                    pnlArama.Controls.Add(textArama[intArama]);
                    textArama[intArama].Location = new System.Drawing.Point(60, 25);
                    //textArama[intArama].Enter += new System.EventHandler(Arama);
                    intArama += 1;
                }

            }
            catch (Exception)
            {

                MessageBox.Show("alan tanımlamasında sorun  " + alanadi);
            }

            Object[] dizi = { gridView1, gridControl1 };

            return dizi;
        }
        public static List<AlanlarVm> GetALANLAR_TABLO(int ustId, int? kullaniciId)
        {
            using (b2cEntities context = new  b2cEntities())
            {
                var list = (from kul in context.M_ALANLAR
                            where (kul.M_ALANLAR_ID == ustId || kul.ID == ustId) && kul.KULLANICI_ID == null
                            select new AlanlarVm
                            {
                                ID = kul.ID,
                                M_ALANLAR_ID = kul.M_ALANLAR_ID,
                                ALAN_AD = kul.ALAN_AD,
                                ALAN_LISTE_AD = kul.ALAN_LISTE_AD,
                                ALAN_LISTE_GENISLIK = kul.ALAN_LISTE_GENISLIK,
                                ALAN_UZUNLUK = kul.ALAN_UZUNLUK,
                                ALAN_DECIMAL = kul.ALAN_DECIMAL,
                                ALAN_SIRA = kul.ALAN_SIRA,
                                M_ALAN_TIP_ID = kul.M_ALAN_TIP_ID,
                                M_ALAN_GOSTERILEN_ID = kul.M_ALAN_GOSTERILEN_ID,
                                M_TABLO_TIP_ID = kul.M_ALAN_GOSTERILEN_ID,
                                M_ALAN_CLASS_NAME = kul.M_ALAN_CLASS_NAME,
                                LK_DURUM_ID = kul.LK_DURUM_ID,
                                KIRILIM_TIP_ID = kul.KIRILIM_TIP_ID,
                                M_ALAN_ARAMA_TIP_ID = kul.M_ALAN_ARAMA_TIP_ID,
                            }).OrderBy(o => o.M_ALANLAR_ID).ToList();
                return list;
            }
        }
        public static List<AlanlarVm> GetALANLAR_KULLANICI(int? kullaniciId)
        {
            using (b2cEntities context = new  b2cEntities())
            {
                var list = (from kul in context.M_ALANLAR
                            where kul.KULLANICI_ID == kullaniciId
                            select new AlanlarVm
                            {
                                ID = kul.ID,
                                M_ALANLAR_ID = kul.M_ALANLAR_ID,
                                ALAN_AD = kul.ALAN_AD,
                                ALAN_LISTE_AD = kul.ALAN_LISTE_AD,
                                ALAN_LISTE_GENISLIK = kul.ALAN_LISTE_GENISLIK,
                                ALAN_UZUNLUK = kul.ALAN_UZUNLUK,
                                ALAN_DECIMAL = kul.ALAN_DECIMAL,
                                ALAN_SIRA = kul.ALAN_SIRA,
                                M_ALAN_TIP_ID = kul.M_ALAN_TIP_ID,
                                M_ALAN_GOSTERILEN_ID = kul.M_ALAN_GOSTERILEN_ID,
                                M_TABLO_TIP_ID = kul.M_TABLO_TIP_ID,
                                M_ALAN_CLASS_NAME = kul.M_ALAN_CLASS_NAME,
                                LK_DURUM_ID = kul.LK_DURUM_ID,
                                KIRILIM_TIP_ID = kul.KIRILIM_TIP_ID,
                                M_ALAN_ARAMA_TIP_ID = kul.M_ALAN_ARAMA_TIP_ID,
                            }).OrderBy(o => o.M_ALANLAR_ID).ToList();
                return list;
            }
        }
        public static List<Alanlar> GetALANLAR(string tabloAdi, int alanGosterilenID)
        {
            int ust_id = 0;
            int kullaniciId = Globals.gnKullaniciId;
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                var q1 = (from d in context.M_ALANLAR
                          where d.ALAN_AD == tabloAdi && d.M_ALANLAR_ID == 0
                          && (d.KULLANICI_ID == kullaniciId || d.KULLANICI_ID == null)
                          select d).OrderByDescending(o => o.KULLANICI_ID).ToList();

                if (q1.Count > 1)
                {
                    ust_id = Convert.ToInt32(q1[1].ID);
                }
                else
                {
                    ust_id = Convert.ToInt32(q1[0].ID);
                }
                var q = (from d in context.M_ALANLAR
                         join ya in context.YETKI_ALANLAR
                         on d.ID equals ya.M_ALANLAR_ID into j1
                         from j2 in j1.Where(y => y.M_ALANLAR_ALT_ID == null && y.KULLANICI_ID == kullaniciId).DefaultIfEmpty()
                         orderby d.ALAN_SIRA
                         where d.M_ALANLAR_ID == ust_id && d.M_ALAN_GOSTERILEN_ID == alanGosterilenID
                         select new Alanlar
                         {
                             ID = d.ID,
                             ALAN_AD = d.ALAN_AD,
                             M_ALAN_TIP_ID = d.M_ALAN_TIP_ID,
                             M_ALAN_TIP_2 = d.M_ALAN_TIP_2,
                             ALAN_DECIMAL = d.ALAN_DECIMAL,
                             ALAN_UZUNLUK = d.ALAN_UZUNLUK,
                             ALAN_SIRA = d.ALAN_SIRA,
                             M_ALAN_GOSTERILEN_ID = d.M_ALAN_GOSTERILEN_ID,
                             ALAN_LISTE_AD = d.ALAN_LISTE_AD,
                             ALAN_LISTE_GENISLIK = d.ALAN_LISTE_GENISLIK,
                             M_ALAN_ALT_BILGI = d.M_ALAN_ALT_BILGI,
                             M_ALAN_CLASS_NAME = d.M_ALAN_CLASS_NAME,
                             GORMESIN_E_H = j2.GORMESIN_E_H,
                             YAZMASIN_E_H = j2.YAZMASIN_E_H,
                             M_ALANLAR_ALT_ID = j2.M_ALANLAR_ALT_ID,
                             KULLANICI_ID = d.KULLANICI_ID,
                             YETKI_KULLANICI_ID = j2.KULLANICI_ID,
                             KIRLIM_TIP_ID = d.KIRILIM_TIP_ID,
                             M_ALAN_ARAMA_TIP_ID = d.M_ALAN_ARAMA_TIP_ID,
                             M_ALANLAR_ID=d.M_ALANLAR_ID, 
                             M_ALAN_KOPYALAMA_E_H = d.M_ALAN_KOPYALAMA_E_H,
                         }).ToList();

                List<Alanlar> vmKullanici = new List<Alanlar>();

                vmKullanici = q.Where(w => w.KULLANICI_ID == Globals.gnKullaniciId).ToList();
                if (vmKullanici.Count > 0)
                {
                    return vmKullanici;
                }
                else
                {
                    return q;
                }

            }
        }
        public static List<Alanlar> GetALANLAR(string tabloAdi)
        {
            int ust_id = 0;
            int kullaniciId = Globals.gnKullaniciId;
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                var q1 = (from d in context.M_ALANLAR
                          where d.ALAN_AD == tabloAdi && d.M_ALANLAR_ID == 0
                          select d.ID).SingleOrDefault();
                ust_id = Convert.ToInt32(q1);
                var q = (from d in context.M_ALANLAR
                         join ya in context.YETKI_ALANLAR
                         on d.ID equals ya.M_ALANLAR_ID into j1
                         from j2 in j1.Where(y => y.M_ALANLAR_ALT_ID == null && y.KULLANICI_ID == kullaniciId).DefaultIfEmpty()
                         orderby d.ALAN_SIRA
                         where d.M_ALANLAR_ID == ust_id && (d.M_ALAN_GOSTERILEN_ID == 1 || d.M_ALAN_GOSTERILEN_ID == 2)
                         select new Alanlar
                         {
                             ID = d.ID,
                             ALAN_AD = d.ALAN_AD,
                             M_ALAN_TIP_ID = d.M_ALAN_TIP_ID,
                             M_ALAN_TIP_2 = d.M_ALAN_TIP_2,
                             ALAN_DECIMAL = d.ALAN_DECIMAL,
                             ALAN_UZUNLUK = d.ALAN_UZUNLUK,
                             ALAN_SIRA = d.ALAN_SIRA,
                             M_ALAN_GOSTERILEN_ID = d.M_ALAN_GOSTERILEN_ID,
                             ALAN_LISTE_AD = d.ALAN_LISTE_AD,
                             ALAN_LISTE_GENISLIK = d.ALAN_LISTE_GENISLIK,
                             M_ALAN_ALT_BILGI = d.M_ALAN_ALT_BILGI,
                             M_ALAN_CLASS_NAME = d.M_ALAN_CLASS_NAME,
                             GORMESIN_E_H = j2.GORMESIN_E_H,
                             YAZMASIN_E_H = j2.YAZMASIN_E_H,
                             M_ALANLAR_ALT_ID = j2.M_ALANLAR_ALT_ID,
                             KULLANICI_ID = j2.KULLANICI_ID,
                             M_ALAN_ARAMA_TIP_ID = d.M_ALAN_ARAMA_TIP_ID,
                         }).ToList();

                return q;
            }
        }
        public static Object GetFILTRELER_ID(int kullaniciId, string formAdi)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                var list = (from kul in context.FILTRELER
                            where kul.KULLANICI_ID == kullaniciId && kul.FORM_ADI == formAdi
                            && kul.LK_DURUM_ID == (int)DurumEn.Aktif
                            select new
                            {
                                ID = kul.ID,
                                AD = kul.RAPOR_ADI,
                            }).ToList();
                return list;
            }
        }
        public static Object GetFILTRELER_ID(int kullaniciId, string formAdi,int filtreTipId)
        {
            List<IdAdVm> listDonus = new List<IdAdVm>();
            IdAdVm vm = new IdAdVm { ID = -1, AD = "STANDART" };
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                var list = (from kul in context.FILTRELER
                            where kul.KULLANICI_ID == kullaniciId && kul.FORM_ADI == formAdi
                            && kul.LK_DURUM_ID == (int)DurumEn.Aktif
                            && kul.FILTRE_TIP_ID ==(int)filtreTipId
                            select new IdAdVm
                            {
                                ID = kul.ID,
                                AD = kul.RAPOR_ADI,
                            }).OrderBy(o=>o.AD).ToList();
                listDonus.Add(vm);
                listDonus.AddRange(list);
                return listDonus;
            }
        }
        public static string GetFILTRELER_DEGER_ALANI(int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.FILTRELER
                            where kul.ID == id
                            select kul).FirstOrDefault();
                if (list != null)
                {
                    if (list.KULLANICI_ID != list.FILTRE_OLUSTURAN_KULLANICI_ID)
                    {
                        var list2 = (from kul in context.FILTRELER
                                     where kul.ID == list.FILTRE_OLUSTURAN_KULLANICI_ID
                                     select kul.DEGER_ALANI).FirstOrDefault();
                        return list2 != null ? list2 : "";
                    }
                    return list != null ? list.DEGER_ALANI : "";
                }
            }
            return "";
        }
        public static string GetFILTRELER_DEGER_ALANI(int id, int filtreTipId)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.FILTRELER
                            where kul.ID == id && kul.FILTRE_TIP_ID == filtreTipId
                            select kul).FirstOrDefault();
                if (list != null)
                {
                    if (list.KULLANICI_ID != list.FILTRE_OLUSTURAN_KULLANICI_ID)
                    {
                        var list2 = (from kul in context.FILTRELER
                                     where kul.ID == list.FILTRE_OLUSTURAN_KULLANICI_ID && kul.FILTRE_TIP_ID == filtreTipId
                                     select kul.DEGER_ALANI).FirstOrDefault();
                        return list2 != null ? list2 : "";
                    }
                    return list != null ? list.DEGER_ALANI : "";
                }
                //var list = (from kul in context.FILTRELER
                //            where kul.ID == id && kul.FILTRE_TIP_ID==filtreTipId
                //            select kul.DEGER_ALANI).FirstOrDefault();
                //return list;
            }
            return "";

        }
        public static Object GetM_MENU_ID_BY_PARAM(int inID, int ust_id)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (inID == 0)
                {
                    var list = (from kul in context.M_MENU
                                where kul.M_MENU_ID == ust_id
                                select new
                                {
                                    ID = kul.ID,
                                    AD = kul.AD
                                }).ToList();
                    return list;
                }
                else
                {
                    var list = (from kul in context.M_MENU
                                where kul.ID == inID && kul.M_MENU_ID == ust_id
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }

            }
        }
        public static Object GetM_ALANLAR_ID_BY_PARAM(int inID, int ust_id)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (inID == 0)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.M_ALANLAR_ID == ust_id
                                select new
                                {
                                    ID = kul.ID,
                                    AD = kul.ALAN_AD
                                }).ToList();
                    return list;
                }
                else
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID && kul.M_ALANLAR_ID == ust_id
                                select kul.ALAN_AD).SingleOrDefault();
                    return Convert.ToString(list);
                }

            }
        }
        public static List<ExcelAktarmaRowVm> GetExcelFiltreRows(int p)
        {
             List<ExcelAktarmaRowVm> listRow = new List<ExcelAktarmaRowVm>();
            ExcelAktarmaRowVm Vm = new ExcelAktarmaRowVm();
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                var list = (from tes in context.EXCEL_ALANLAR
                            where tes.FILTRELER_ID == p
                            select tes).ToList();

                foreach (var item in list)
                {
                    Vm = new ExcelAktarmaRowVm();
                    Vm.ID = item.ID;
                    Vm.EXCEL_ALANLAR = item.ALAN_1;
                    if (item.ALAN_2 != "") Vm.TABLO_ALAN_ID = Convert.ToInt32(item.ALAN_2);
                    if (item.ALAN_3 != "") Vm.ALAN_TIP_ID = Convert.ToInt32(item.ALAN_3);
                    if (item.ALAN_4 != "") Vm.ALAN_DATA_TIP_ID = Convert.ToInt32(item.ALAN_4);
                    if (item.ALAN_5 != "") Vm.ANAHTAR_ALAN = Convert.ToByte(item.ALAN_5);
                    if (item.ALAN_6 != "") Vm.UZERINE_YAZMA_DURUM_TIP_ID = Convert.ToInt32(item.ALAN_6);
                    if (item.ALAN_7 != "") Vm.IKINCI_TABLO_E_H = Convert.ToByte(item.ALAN_7);

                    listRow.Add(Vm);
                }//    new ExcelAktarmaRowVm
                //            {
                //                EXCEL_ALANLAR = tes.ALAN_1,
                //                TABLO_ALAN_ID = tes.ALAN_2!="" ? int.Parse(tes.ALAN_2): 0,
                //                ALAN_TIP_ID = tes.ALAN_3 != "" ? int.Parse(tes.ALAN_3) : 0,
                //                ALAN_DATA_TIP_ID = tes.ALAN_4 != "" ? int.Parse(tes.ALAN_4) : 0,
                //                ANAHTAR_ALAN = tes.ALAN_5 != "" ? (byte)int.Parse(tes.ALAN_5) : (byte)0,
                //            }
                //}
                return listRow;
            }
        }
        public static string[] GetKullaniciByRol(string[] Roller)
        {

            b2cEntities context = new  b2cEntities();
            string sql = QueryOlustur.queryTekAlan("",Roller,"ROL_ID");
            using (context)
            {
                var list = (from tes in context.KULLANICI
                            select new { tes.ID, tes.ROL_ID }
                                ).Where(sql).ToList();
                if (list.Count > 0)
                {
                    string[] kullanicilar = new string[list.Count];
                    for (int i = 0; i < list.Count; i++)
                    {
                        kullanicilar[i] = Convert.ToString(list[i].ID);
                    }
                    return kullanicilar;
                }
                //var list = (from tes in context.KULLANICI
                //            where tes.ID != eskiKullaniciId && tes.ROL_ID == (from k in context.KULLANICI where k.ID == eskiKullaniciId select k.ROL_ID).FirstOrDefault()
                //            select tes).ToList();
                //if (list.Count > 0)
                //{
                //    string[] kullanicilar = new string[list.Count];
                //    for (int i = 0; i < list.Count; i++)
                //    {
                //        kullanicilar[i] = Convert.ToString(list[i].ID);
                //    }
                //    return kullanicilar;
                //}
            }
            return null;
        }
        public static void SetYETKI_ISLEM(KullaniciYetkileriVm kullaniciYetkileriVm)
        {
            List<YetkiIslemlerVm> listYetki = ListDenemeService.GetYETKI_ISLEMLER(Globals.gnKullaniciId, (int)IslemSahibiEn.EKIPMAN_OPERASYON_TANITIM,(int)IslemListeEn.DINAMIK);
            if (listYetki == null) return;
            foreach (var item in listYetki)
            {
                if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.CariGozlemAc)
                {
                    kullaniciYetkileriVm.CARI_GOZLEM_AC_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.FaturalanmamısIrsaliyelerinGosterimi)
                {
                    kullaniciYetkileriVm.FATURALANMAMIS_IRSALIYE_GOSTER_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.SiparisBakiyeKontrolu)
                {
                    kullaniciYetkileriVm.SIPARIS_BAKIYE_KONTROL_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.IrsaliyeAcilisUyarisi)
                {
                    kullaniciYetkileriVm.IRSALIYE_ACILIS_UYARI_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.AlisFiyatGorme)
                {
                    kullaniciYetkileriVm.ALIS_FIYAT_GOR_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.SatisFiyatGorme)
                {
                    kullaniciYetkileriVm.SATIS_FIYAT_GOR_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.SigortaKullanicisiMi)
                {
                    kullaniciYetkileriVm.SIGORTA_KULLANICISI_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.AltKullaniciIslemleriniYap)
                {
                    kullaniciYetkileriVm.ALT_KULLANICI_ISLEM_YAP_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.TeklifFiyatDegistir)
                {
                    kullaniciYetkileriVm.TEKLIF_FIYAT_DEGISTIR_E_H  = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.SiparisFiyatDegistir)
                {
                    kullaniciYetkileriVm.SIPARIS_FIYAT_DEGISTIR_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.IrsaliyeFiyatDegistir)
                {
                    kullaniciYetkileriVm.IRSALIYE_FIYAT_DEGISTIR_E_H  = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.IrsaliyeFiyatDegistir)
                {
                    kullaniciYetkileriVm.IRSALIYE_FIYAT_DEGISTIR_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.SiparisTeslimTarihUyarisi)
                {
                    kullaniciYetkileriVm.SIPARIS_TESLIM_TARIHI_UYARISI_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.FisGosterimSinirla)
                {
                    kullaniciYetkileriVm.FIS_GOSTERIM_SINIRLA_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.CekMuhasebeEntegrasyon)
                {
                    kullaniciYetkileriVm.CEK_MUHASEBE_ENTEGRASYON_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.MahsupMuhasebeEntegrasyon)
                {
                    kullaniciYetkileriVm.MAHSUP_MUHASEBE_ENTEGRASYON_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.FaturaMuhasebeEntegrasyon)
                {
                    kullaniciYetkileriVm.FATURA_MUHASEBE_ENTEGRASYON_E_H = item.YETKILI_E_H;
                }
                else if (item.YETKI_ISLEM_TANTIM_ID == (int)KullaniciDinamikYetkiEn.PlasiyerKullaniciMi)
                {
                    kullaniciYetkileriVm.PLASIYER_KULLANICI_E_H = item.YETKILI_E_H;
                }
            }
            kullaniciYetkileriVm.FIS_SON_GUN = 15;
        }
        public static void FirmaBilgileriGuncelle()
        {
            //FirmaParametreCntrl firma = new FirmaParametreCntrl();
            //GenelParametreSng nesne = GenelParametreSng.Nesne();
            //YetkiMenulerCntrl kulYetki = new YetkiMenulerCntrl();
            //YetkiMenulerVm kYetki = new YetkiMenulerVm();
            //kYetki.KULLANICI_ID = Globals.gnKullaniciId;
            //nesne.kullaniciMenuYetkiBilgileri = kulYetki.Liste_Al(kYetki);
            //nesne.firmaBilgileri = firma.Liste_Al(null)[0];
        }



        public static object GetPERSONEL_GRUPLAR_ID(int id)
        {
            throw new NotImplementedException();
        }

        public static int getGrupIdByVehicle(B2C.Models.vehicle_treeVm k)
        {
            throw new NotImplementedException();
        }
    }
}
