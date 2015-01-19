using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using Prodma.DataAccessB2C;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Prodma.SistemB2C.Controllers;
using Prodma.SistemB2C.Models;
using System.Drawing;
using Prodma.WinForms;

namespace Prodma.WinForms
{
    public class WinFormsHelper
    {
        //public static void GruplamaDoldur(GridLookUpEdit lke)
        //{
        //    Dictionary<string, string> a = new Dictionary<string, string>();
        //    a.Add("Seciniz", "Seciniz");
        //    a.Add("STOK_ID", "STOK");
        //    a.Add("ISLEM_TIPI_ID", "İŞLEM TİPİ");
        //    List<StokGrupVm> ListStokGrup = new List<StokGrupVm>();
        //    StokGrupVm k = new StokGrupVm();
        //    k.STOK_GRUP_ID = 0;
        //    StokGrupCntrl cntrl = new StokGrupCntrl();
        //    ListStokGrup = cntrl.Liste_Al(null);
        //    int i = 1;
        //    foreach (StokGrupVm item in ListStokGrup)
        //    {
        //        if (item.STOK_GRUP_ID == 0)
        //        {
        //            a.Add("GRUP" + i + "_ID", item.AD);
        //            i++;
        //        }
                
        //    }
        //    a.Add("AY", "AY");
        //    GridLookUpEditDuzenle(lke, a);
        //}
        //public static void GruplamaDoldurSecenekli(GridLookUpEdit lke, bool stokEkle, bool cariEkle, bool tarihEkle, bool fisEkle)
        //{
        //    Dictionary<string, string> a = new Dictionary<string, string>();
        //    a.Add("Seciniz", "Seciniz");
        //    if (fisEkle)
        //    {
        //        a.Add("ISLEM_TIPI_ID", "İŞLEM TİPİ");
        //    }
        //    if (tarihEkle)
        //    {
        //        a.Add("TARIH", "TARIH");
        //        a.Add("AY", "AY");
        //        a.Add("AY_YIL_GRUP", "AY_YIL_GRUP");
        //    }
        //    if (stokEkle)
        //    {
        //        a.Add("STOK_ID", "STOK");
        //        a.Add("MUHASEBE_MASRAF_YERI_ID", "MASRAF_YERI");
        //        List<StokGrupVm> ListStokGrup = new List<StokGrupVm>();
        //        StokGrupVm k = new StokGrupVm();
        //        k.STOK_GRUP_ID = 0;
        //        StokGrupCntrl cntrl = new StokGrupCntrl();
        //        ListStokGrup = cntrl.Liste_Al(null);
        //        int i = 1;
        //        foreach (StokGrupVm item in ListStokGrup)
        //        {
        //            if (item.STOK_GRUP_ID == 0)
        //            {
        //                a.Add("STOK_GRUP" + i + "_ID", item.AD);
        //                i++;
        //            }
        //        }
        //    }
        //    if (cariEkle)
        //    {
        //        a.Add("CARI_ID", "CARI");
        //        a.Add("CARI_BOLGE_ID", "CARI BÖLGE");
        //        a.Add("ITHALAT_CARI_HESAP_KOD", "ITHALAT DOSYA NO");
        //        List<CariGrupVm> ListCariGrup = new List<CariGrupVm>();
        //        CariGrupVm k = new CariGrupVm();
        //        k.CARI_GRUP_ID = 0;
        //        CariGrupCntrl cntrl = new CariGrupCntrl();
        //        ListCariGrup = cntrl.Liste_Al(null);
        //        int i = 1;
        //        foreach (CariGrupVm item in ListCariGrup)
        //        {
        //            if (item.CARI_GRUP_ID == 0)
        //            {
        //                a.Add("CARI_GRUP" + i + "_ID", item.AD);
        //                i++;
        //            }
        //        }
        //    }

        //    GridLookUpEditDuzenle(lke, a);

        //    //lke.EditValue = "CARI";
        //}
        //public static void GruplamaDoldurCek(GridLookUpEdit lke, bool stokEkle, bool cariEkle, bool tarihEkle, bool fisEkle)
        //{
        //    Dictionary<string, string> a = new Dictionary<string, string>();
        //    a.Add("Seciniz", "Seciniz");
        //    if (fisEkle)
        //    {
        //        a.Add("ISLEM_TIPI_ID", "İŞLEM TİPİ");
        //        a.Add("BANKA_KODU", "BANKA_KODU");
        //    }
        //    if (tarihEkle)
        //    {
        //        a.Add("FIS_TARIH", "FIS_TARIH");
        //        a.Add("VADE_TARIH", "VADE_TARIH");
        //        a.Add("FIS_TARIH_AY", "FIS_TARIH_AY");
        //        a.Add("VADE_TARIH_AY", "VADE_TARIH_AY");
        //        a.Add("FIS_TARIH_AY_YIL", "FIS_TARIH_AY_YIL");
        //        a.Add("VADE_TARIH_AY_YIL", "VADE_TARIH_AY_YIL");
        //    }

        //    if (cariEkle)
        //    {
        //        a.Add("CARI_ID", "CARI");
        //        a.Add("CARI_BOLGE_ID", "CARI BÖLGE");
        //        List<CariGrupVm> ListCariGrup = new List<CariGrupVm>();
        //        CariGrupVm k = new CariGrupVm();
        //        k.CARI_GRUP_ID = 0;
        //        CariGrupCntrl cntrl = new CariGrupCntrl();
        //        ListCariGrup = cntrl.Liste_Al(null);
        //        int i = 1;
        //        foreach (CariGrupVm item in ListCariGrup)
        //        {
        //            if (item.CARI_GRUP_ID == 0)
        //            {
        //                a.Add("CARI_GRUP" + i + "_ID", item.AD);
        //                i++;
        //            }
        //        }
        //    }

        //    GridLookUpEditDuzenle(lke, a);

        //}
        //public static void GruplamaDoldurMahsup(GridLookUpEdit lke, bool stokEkle, bool cariEkle, bool tarihEkle, bool fisEkle)
        //{
        //    Dictionary<string, string> a = new Dictionary<string, string>();
        //    a.Add("Seciniz", "Seciniz");
        //    if (fisEkle)
        //    {
        //        a.Add("ISLEM_TIPI_ID", "İŞLEM TİPİ");
        //    }
        //    if (tarihEkle)
        //    {
        //        a.Add("FIS_TARIH", "FIS_TARIH");
        //        a.Add("FIS_TARIH_AY", "FIS_TARIH_AY");
        //    }

        //    if (cariEkle)
        //    {
        //        a.Add("CARI_ID", "CARI");
        //        a.Add("CARI_BOLGE_ID", "CARI BÖLGE");
        //        a.Add("CARI_PLASIYER_ID", "CARI PLASİYER");
        //        List<CariGrupVm> ListCariGrup = new List<CariGrupVm>();
        //        CariGrupVm k = new CariGrupVm();
        //        k.CARI_GRUP_ID = 0;
        //        CariGrupCntrl cntrl = new CariGrupCntrl();
        //        ListCariGrup = cntrl.Liste_Al(null);
        //        int i = 1;
        //        foreach (CariGrupVm item in ListCariGrup)
        //        {
        //            if (item.CARI_GRUP_ID == 0)
        //            {
        //                a.Add("CARI_GRUP" + i + "_ID", item.AD);
        //                i++;
        //            }
        //        }
        //    }

        //    GridLookUpEditDuzenle(lke, a);

        //}
        //public static void GruplamaDoldurSabitKiymet(GridLookUpEdit lke)
        //{
        //    Dictionary<string, string> a = new Dictionary<string, string>();
        //    a.Add("Seciniz", "Seciniz");
        //    a.Add("TIP_KOD_1", "Demirbaş Kod 1");
        //    a.Add("TIP_KOD_2", "Demirbaş Kod 2");
        //    a.Add("MASRAF_YERI", "MASRAF_YERI_ID");
        //    GridLookUpEditDuzenle(lke, a);

        //}
        public static void GridLookUpEditDuzenle(GridLookUpEdit lke, Dictionary<string, string> a)
        {
            ArrayList list = new ArrayList(a);
            lke.Properties.DataSource = list;
            lke.Properties.NullText = "";
            lke.Properties.ValueMember = "Key";
            lke.Properties.DisplayMember = "Value";
            lke.Properties.View.PopulateColumns(lke.Properties.DataSource);
            GridlookupEditAlanlariDuzenle(lke);
        }
        public static void GridLookUpEditDuzenle(GridLookUpEdit lke)
        {
            lke.Properties.NullText = "";
            lke.Properties.ValueMember = "ID";
            lke.Properties.DisplayMember = "AD";
            GridlookupEditAlanlariDuzenle(lke);
        }
        public static void GridlookupEditAlanlariDuzenle(GridLookUpEdit lke)
        {
            lke.Properties.View.PopulateColumns(lke.Properties.DataSource);
            //lke.Properties.View.Columns["ID"].Visible = false;

            for (int i = 0; i < lke.Properties.View.Columns.Count; i++)
            {
                if (lke.Properties.View.Columns[i].FieldName != "AD" && lke.Properties.View.Columns[i].FieldName != "Value")
                    lke.Properties.View.Columns[i].Visible = false;
            }
        }
        //public static void Grid_Model_Ekle(GridView view, string model)
        //{
        //    DevExpress.XtraGrid.Columns.GridColumn Column1;
        //    if (model == "STOKVM")
        //    {
        //        Type calledType = Type.GetType("Satis.StokAmbar.Models.StokVm,Prodma.DataAccess");
        //        foreach (PropertyInfo propertyInfo in calledType.GetProperties())
        //        {
        //            Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
        //            Column1.FieldName = "STOKVM." + propertyInfo.Name;
        //            Column1.Visible = true;
        //            Column1.VisibleIndex = 1;
        //            view.Columns.Add(Column1);
        //        }
        //    }
        //    else if (model == "CariVm")
        //    {
        //        Type calledType = Type.GetType("Satis.Cari.Models.CariVm,Prodma.DataAccess");
        //        foreach (PropertyInfo propertyInfo in calledType.GetProperties())
        //        {
        //            Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
        //            Column1.FieldName = "CARIVM." + propertyInfo.Name;
        //            Column1.Visible = true;
        //            Column1.VisibleIndex = 1;
        //            view.Columns.Add(Column1);
        //        }
        //    }
        //}//KULLANILMIYOR  Modelden grid Olusumu 
        //public static void GruplamaDoldurMuhasebe(GridLookUpEdit lke, bool stokEkle, bool cariEkle, bool tarihEkle, bool fisEkle)
        //{
        //    Dictionary<string, string> a = new Dictionary<string, string>();
        //    a.Add("Seciniz", "Seciniz");
        //    if (fisEkle)
        //    {
        //        a.Add("ISLEM_TIPI_ID", "İŞLEM TİPİ");
        //    }
        //    if (tarihEkle)
        //    {
        //        a.Add("FIS_TARIH", "FIS_TARIH");
        //        a.Add("FIS_TARIH_AY", "FIS_TARIH_AY");
        //        a.Add("KEBIR_HESAP_KOD", "KEBİR HESAP");
        //    }

        //    if (cariEkle)
        //    {
        //        a.Add("MUHASEBE_HESAP_PLANI_ID", "MUHASEBE HESAP KOD");
        //        a.Add("MUHASEBE_MASRAF_YERI_ID", "MUHASEBE MASRAF YERI KOD");
        //        List<MuhasebeGrupVm> ListMuhasebeGrup = new List<MuhasebeGrupVm>();
        //        MuhasebeGrupVm k = new MuhasebeGrupVm();
        //        k.MUHASEBE_GRUP_ID = 0;
        //        MuhasebeGrupCntrl cntrl = new MuhasebeGrupCntrl();
        //        ListMuhasebeGrup = cntrl.Liste_Al(null);
        //        int i = 1;
        //        foreach (MuhasebeGrupVm item in ListMuhasebeGrup)
        //        {
        //            if (item.MUHASEBE_GRUP_ID == 0)
        //            {
        //                a.Add("MUHASEBE_HESAP_GRUP" + i + "_ID", item.AD);
        //                i++;
        //            }
        //        }

        //        List<MasrafYeriGrupVm> ListMasrafYeriGrup = new List<MasrafYeriGrupVm>();
        //        MasrafYeriGrupVm k2 = new MasrafYeriGrupVm();
        //        k2.MASRAF_YERI_GRUP_ID = 0;
        //        MasrafYeriGrupCntrl cntrl2 = new MasrafYeriGrupCntrl();
        //        ListMasrafYeriGrup = cntrl2.Liste_Al(null);
        //        i = 1;
        //        foreach (MasrafYeriGrupVm item in ListMasrafYeriGrup)
        //        {
        //            if (item.MASRAF_YERI_GRUP_ID == 0)
        //            {
        //                a.Add("MUHASEBE_MASRAF_YERI_GRUP" + i + "_ID", item.AD);
        //                i++;
        //            }
        //        }
        //    }

        //    GridLookUpEditDuzenle(lke, a);

        //}


        public static void Grid_Olustur(string ns, string tn, string an, GridView view, string[] toplamAlanlari, GridOzellikleri ozellikler)
        {
            if (ozellikler == null)
            {
                ozellikler = new GridOzellikleri();
                ozellikler.autoWidth = false;
                ozellikler.groupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            }
            else if (ozellikler.groupFooterShowMode==null)
            {
                ozellikler.groupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            }
            //if (ozellikler.AltToplamGosterme == true)
            //{
            //    ozellikler.groupFooterShowMode = GroupFooterShowMode.Hidden;
            //}
            //if (ozellikler.acilmamisSatirlariGosterme==true)
            //{
            //    view.OptionsPrint.PrintDetails = false;
            //    view.OptionsPrint.ExpandAllDetails = false;
            //    view.OptionsPrint.ExpandAllGroups = false;
            //    view.GroupFooterShowMode = GroupFooterShowMode.Hidden;
            //}
            //else
            //{
            //    view.OptionsPrint.PrintDetails = true;
            //    view.OptionsPrint.ExpandAllDetails = true;
            //    view.OptionsPrint.ExpandAllGroups = true;
            //    view.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            //}
            string alanAdiEk = "";
            int sira = 0;
            if (view.Columns.Count > 0)
            {
                sira = view.VisibleColumns.Count;
                if (tn == "PersonelListVm")
                {
                    alanAdiEk = "PERSONELVM.";
                }
                else if (tn == "CariListVm")
                {
                    alanAdiEk = "CARIVM.";
                }
                else if (tn == "StokHesaplananBilgilerVm")
                {
                    alanAdiEk = "STOKVM.STOKHESAPLANANBILGILERVM.";
                }
                else if (tn == "CariListeBilgileri")
                {
                    alanAdiEk = "CARIVM.CARITUMBILGILERVM.";
                }
            }
            else
            {
                view.GroupSummary.Clear();
            }
            view.GroupFooterShowMode = ozellikler.groupFooterShowMode;
            int toplamAlani = 0;
            bool griddeGorunsunMu = true;
            DevExpress.XtraGrid.Columns.GridColumn Column1;
            Type calledType = Type.GetType(ns + "." + tn + "," + an);
            view.OptionsView.ColumnAutoWidth = ozellikler.autoWidth;
            if (calledType==null)
            {
                MessageBox.Show("Grid Oluşturmada Problem oluştu. Yetkiliye Başvurunuz.");
                return;
            }
            foreach (PropertyInfo propertyInfo in calledType.GetProperties())
            {
                string format = "";
                griddeGorunsunMu = false;
                toplamAlani = 0;
                try
                {
                         TipAttribute tblAtr = ((TipAttribute[])propertyInfo.GetCustomAttributes(typeof(TipAttribute), false))[0];
                         griddeGorunsunMu = tblAtr.griddeGorunmesin;
                         if (tblAtr.Uzunluk!=null) format = "n" + tblAtr.Uzunluk.ToString();
                        toplamAlani = tblAtr.toplamAlani; 
                         
                }
                catch (Exception)
                {

                }
                Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                Column1.FieldName = alanAdiEk + propertyInfo.Name;
                Column1.Caption = IsimAl(alanAdiEk + propertyInfo.Name,ozellikler.dil);
                if (propertyInfo.Name.Length > 3 && propertyInfo.Name.Substring(propertyInfo.Name.Length - 3, 3) == "_ID")
                {
                    Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                }
                else
                {
                    Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                }
                if (griddeGorunsunMu == true || (alanAdiEk != "" && (Column1.Caption == "(SK)-" || Column1.Caption == "(CK)-" || Column1.Caption == "(SK)--" || Column1.Caption == "(HB)-")))
                {
                    Column1.Visible = false;
                    Column1.VisibleIndex = -1;
                }
                else
                {
                    Column1.Visible = true;
                    Column1.VisibleIndex = sira;
                    sira++;
                    view.Columns.Add(Column1);
                }
             
                if (toplamAlani == 3)
                {

                    GridGroupSummaryItem item = new GridGroupSummaryItem();
                    item.FieldName = alanAdiEk + Column1.FieldName;
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    if (format != "")
                    {
                        Column1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        item.DisplayFormat = format;
                    }
                    //item.DisplayFormat = Column1.FieldName.ToString() + "{0:N2}";
                    Column1.SummaryItem.FieldName = alanAdiEk + Column1.FieldName;
                    Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    view.GroupSummary.Add(item);
                }
                else if (toplamAlani == 4)
                {

                    GridGroupSummaryItem item = new GridGroupSummaryItem();
                    item.FieldName = alanAdiEk + Column1.FieldName;
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    if (format != "")
                    {
                        Column1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        item.DisplayFormat = format;
                    }
                    // item.DisplayFormat = Column1.FieldName.ToString() + "{0:N2}";
                    Column1.SummaryItem.FieldName = alanAdiEk + Column1.FieldName;
                    Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    view.GroupSummary.Add(item);
                }
                else if (toplamAlani == 1)
                {
                    GridGroupSummaryItem item = new GridGroupSummaryItem();
                    item.FieldName = alanAdiEk + Column1.FieldName;
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    if (format != "" )
                    {
                        if (ozellikler.acilmamisSatirlariGosterme == false)
                        {
                            item.ShowInGroupColumnFooter = Column1;
                        }
                        if (format == "n0")
                        {
                            item.DisplayFormat =  "{0:0}";
                        }
                        else
                        {
                          item.DisplayFormat =   "{0:" + format + "}";
                        }
                        
                    }
                    Column1.SummaryItem.FieldName = alanAdiEk + Column1.FieldName;
                    Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    if (format != "")
                    {
                        if (format == "n0")
                        {
                            Column1.SummaryItem.DisplayFormat = "{0:0}";
                        }
                        else
                        {
                            Column1.SummaryItem.DisplayFormat = "{0:" + format + "}";
                        }

                    }
                    //item.ShowInGroupColumnFooter = null;
                    view.GroupSummary.Add(item);
                }
                else if (toplamAlani == 2)
                {
                    GridGroupSummaryItem item = new GridGroupSummaryItem();
                    item.FieldName = alanAdiEk + Column1.FieldName;
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    if (format != "")
                    {
                        item.ShowInGroupColumnFooter = Column1;
                        if (format == "n0")
                        {
                            item.DisplayFormat = "{0:0}";
                        }
                        else
                        {
                            item.DisplayFormat = "{0:" + format + "}";
                        }

                    }
                    Column1.SummaryItem.FieldName = alanAdiEk + Column1.FieldName;
                    Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    if (format != "")
                    {
                        if (format == "n0")
                        {
                            Column1.SummaryItem.DisplayFormat = "{0:0}";
                        }
                        else
                        {
                            Column1.SummaryItem.DisplayFormat = "{0:" + format + "}";
                        }

                    }
                    view.GroupSummary.Add(item);
                }
                Column1.BestFit();
                if (format != "")
                {
                    Column1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        Column1.DisplayFormat.FormatString = format;
                }
            }
            if (ozellikler.ParentpPropertileriGosterme == true)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn item in view.Columns)
                {
                    if (item.FieldName == "GRUP_SECIM" || item.FieldName == "GRUP_SECIM1" || item.FieldName == "GRUP_SECIM2" || item.FieldName == "GRUP_SECIM_KOD_1" || item.FieldName == "GRUP_SECIM_KOD_2" || item.FieldName == "GRUP_SECIM_AD_1" || item.FieldName == "GRUP_SECIM_AD_2")
                    {
                        item.Visible = false;
                    }
                    // if (item.Visible == true) gridViewColumnschl.Properties.Items.Add(item.Caption.ToString(), item.Visible == true ? CheckState.Checked : CheckState.Unchecked, true);
                }
            }
            view.GroupPanelText = "Gruplamak İstediğiniz Alanı Bu Bölgeye Sürükleyiniz";
        }
        #region kullanılmayan gridolusturlar
        //public static void Grid_Olustur_Tum(string ns, string tn, string an, GridView view, GridControl gridControl, string[] toplamAlanlari, Dictionary<string, string> parameters)
        //{
        //    List<Alanlar> alanlar = new List<Alanlar>();
        //    int sira = 0;
        //    DevExpress.XtraGrid.Columns.GridColumn Column1;
        //    Type calledType = Type.GetType(ns + "." + tn + "," + an);
        //    view.OptionsView.ColumnAutoWidth = false;
        //    foreach (PropertyInfo propertyInfo in calledType.GetProperties())
        //    {
        //        if (propertyInfo.Name == "STOKVM" && parameters.ContainsKey("HAREKET_SECIM") && parameters["HAREKET_SECIM"].Contains("STOKVM"))
        //        {
        //            alanlar = ListDenemeService.GetALANLAR("STOK");

        //            Type calledType1 = Type.GetType("Satis.StokAmbar.Models.StokListVm," + an);
        //            foreach (PropertyInfo propertyInfo1 in calledType1.GetProperties())
        //            {
        //            }
        //            Gridi_OlusturbyList(alanlar, view, gridControl, sira + 1, "STOKVM.", false);
        //            sira += alanlar.Count;
        //        }
        //        else if (propertyInfo.Name == "CARIVM" && parameters.ContainsKey("HAREKET_SECIM") && parameters["HAREKET_SECIM"].Contains("CARIVM"))
        //        {
        //            alanlar = ListDenemeService.GetALANLAR("CARI");
        //            Gridi_OlusturbyList(alanlar, view, gridControl, sira + 1, "CARIVM.", false);
        //            sira += alanlar.Count;
        //        }
        //        else if (propertyInfo.Name == "TEKLIFSATIRVM" && parameters.ContainsKey("HAREKET_SECIM") && parameters["HAREKET_SECIM"].Contains("TEKLIFSATIRVM"))
        //        {
        //            alanlar = ListDenemeService.GetALANLAR("TEKLIF_FIS_SATIR");
        //            Gridi_OlusturbyList(alanlar, view, gridControl, sira + 1, "TEKLIFSATIRVM.", true);
        //            sira += alanlar.Count;
        //        }
        //        else if (propertyInfo.Name == "TEKLIFSIFIRVM" && parameters.ContainsKey("HAREKET_SECIM") && parameters["HAREKET_SECIM"].Contains("TEKLIFSIFIRVM"))
        //        {
        //            alanlar = ListDenemeService.GetALANLAR("TEKLIF_FIS_SIFIRLI");
        //            Gridi_OlusturbyList(alanlar, view, gridControl, sira + 1, "TEKLIFSIFIRVM.", true);
        //            sira += alanlar.Count;
        //        }
        //        else if (propertyInfo.Name == "SIPARISSATIRVM" && parameters.ContainsKey("HAREKET_SECIM") && parameters["HAREKET_SECIM"].Contains("SIPARISSATIRVM"))
        //        {
        //            alanlar = ListDenemeService.GetALANLAR("SIPARIS_FIS_SATIR");
        //            Gridi_OlusturbyList(alanlar, view, gridControl, sira + 1, "SIPARISSATIRVM.", true);
        //            sira += alanlar.Count;
        //        }
        //        else if (propertyInfo.Name == "SIPARISSIFIRVM" && parameters.ContainsKey("HAREKET_SECIM") && parameters["HAREKET_SECIM"].Contains("SIPARISSIFIRVM"))
        //        {
        //            alanlar = ListDenemeService.GetALANLAR("SIPARIS_FIS_SIFIRLI");
        //            Gridi_OlusturbyList(alanlar, view, gridControl, sira + 1, "SIPARISSIFIRVM.", true);
        //            sira += alanlar.Count;
        //        }
        //        else if (propertyInfo.Name == "STOKFISSATIRVM" && parameters.ContainsKey("HAREKET_SECIM") && parameters["HAREKET_SECIM"].Contains("STOKFISSATIRVM"))
        //        {
        //            alanlar = ListDenemeService.GetALANLAR("STOK_FIS_SATIR");
        //            Gridi_OlusturbyList(alanlar, view, gridControl, sira + 1, "STOKFISSATIRVM.", true);
        //            sira += alanlar.Count;
        //        }
        //        else if (propertyInfo.Name == "STOKFISSIFIRVM" && parameters.ContainsKey("HAREKET_SECIM") && parameters["HAREKET_SECIM"].Contains("STOKFISSIFIRVM"))
        //        {
        //            alanlar = ListDenemeService.GetALANLAR("STOK_FIS_SIFIRLI");
        //            Gridi_OlusturbyList(alanlar, view, gridControl, sira + 1, "STOKFISSIFIRVM.", true);
        //            sira += alanlar.Count;
        //        }
        //        else if (propertyInfo.Name == "STOKVM")
        //        {
        //            alanlar = ListDenemeService.GetALANLAR("STOK");
        //            Gridi_OlusturbyList(alanlar, view, gridControl, sira + 1, "STOKVM.", true);
        //            sira += alanlar.Count;
        //        }
        //        else if (propertyInfo.Name == "CARIVM")
        //        {
        //            alanlar = ListDenemeService.GetALANLAR("CARI");
        //            Gridi_OlusturbyList(alanlar, view, gridControl, sira + 1, "CARIVM.", true);
        //            sira += alanlar.Count;
        //        }
        //        else if (propertyInfo.Name.Length < 4 || (propertyInfo.Name.Substring(propertyInfo.Name.Length - 4, 4) != "temp"))
        //        {
        //            Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
        //            Column1.FieldName = propertyInfo.Name;
        //            Column1.Caption = IsimAl(propertyInfo.Name);
        //            Column1.Visible = true;
        //            Column1.VisibleIndex = sira;
        //            view.Columns.Add(Column1);
        //            if (toplamAlanlari != null)
        //            {
        //                if (Array.IndexOf(toplamAlanlari, Column1.FieldName) != -1)
        //                {
        //                    Column1.SummaryItem.FieldName = Column1.FieldName;
        //                    Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        //                }
        //            }
        //            Column1.BestFit();
        //            sira++;
        //        }
        //    }
        //    view.Columns["ID"].Visible = false;
        //    view.GroupPanelText = "Gruplamak İstediğiniz Alanı Bu Bölgeye Sürükleyiniz";
        //    //view.BestFitColumns(); 
        //}//gridiolusturbylisti cagırıyor.
        //public static void Grid_Olustur_Tum(string ns, string tn, string an, GridView view, GridControl gridControl)
        //{
        //    string[] a = { "TUTAR", "TUTAR_DOVIZ" };
        //    Dictionary<string, string> prm = new Dictionary<string, string>();
        //    prm.Add("temp", "");
        //    Grid_Olustur_Tum(ns, tn, an, view, gridControl, a, prm);
        //}

        #endregion
        public static void Grid_Olustur_Tum_Kayitlar(string ns, string tn, string an, GridView view, GridControl gridControl, string[] toplamAlanlari, int CariStokModelEn, GridOzellikleri ozl)
        {
            if (ozl == null)
            {
                ozl = new GridOzellikleri();
                ozl.autoWidth = false;
            }
            if (tn == "ListViewModelListe")
            {
                ns = "Personel.Listeler.PersonelListeleri.Models";
            }
            Grid_Olustur(ns, tn, an, view, toplamAlanlari, ozl);
            if (CariStokModelEn == (int)ListeEkModelEn.PersonelModelli || CariStokModelEn == (int)ListeEkModelEn.Tum)
            {
                Grid_Olustur("Personel.Listeler.PersonelListeleri.Models", "PersonelListVm", an, view, toplamAlanlari, ozl);
            }
            view.BestFitColumns();
        }
        public static void Gridi_OlusturbyList(List<Alanlar> alanlar, GridView view, GridControl gridControl1, int alanSira, string alanAdiEk,bool gridTemizle)
        {
            Gridi_OlusturbyList(alanlar, view, gridControl1, alanSira, alanAdiEk, gridTemizle, false);
        } // alanadiek dolu ise griddeki alanların basına alanadiEk geliyor
        public static void Gridi_OlusturbyList(List<Alanlar> alanlar, GridView view, GridControl gridControl1, int alanSira, string alanAdiEk,bool gridTemizle,bool autoWidth)
        {
            if (gridTemizle == true)
            {
                view.Columns.Clear();
            }
            if (alanAdiEk == "STOKTABLOSU") // eger dinamik updatede gelen bir istek ise
            {
                alanAdiEk = "";
            }
            else if (alanAdiEk == "CARITABLOSU")
            {
                alanAdiEk = "";
            }
            DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit;
            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit;
            DevExpress.XtraGrid.Columns.GridColumn Column1;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[] repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[128];
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit[] repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit[128];
            BindingSource[] bindingSourceArr = new BindingSource[128];
            int intBind = 0;
            int intBindTextEdit = 0;
            // view.OptionsBehavior.Editable = false;
            view.OptionsView.ColumnAutoWidth =!autoWidth;

            foreach (var ALAN in alanlar)
            {
                if (ALAN.ALAN_AD != "ID")
                {
                    Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                    Column1.OptionsColumn.AllowEdit = false;
                    if (ALAN.M_ALAN_TIP_ID == 1 || ALAN.M_ALAN_TIP_ID == null)  // TEXT
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD,(int)Dil.Turkce);
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemTextEdit[intBindTextEdit] = new RepositoryItemTextEdit();
                        if (ALAN.KIRLIM_TIP_ID != null)
                        {
                            string kirilim = YardimciIslemler.KirilimUygula(ALAN.KIRLIM_TIP_ID);
                            // this.repositoryItemTextEdit.Mask.EditMask = "\\w\\w\\w-\\w\\w-\\w\\w\\w\\w";
                            // this.repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = "\\w\\w\\w \\w\\w \\w\\w \\w\\w\\w";
                            repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = kirilim;
                            repositoryItemTextEdit[intBindTextEdit].Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                            repositoryItemTextEdit[intBindTextEdit].Mask.UseMaskAsDisplayFormat = true;
                        }
                        else
                        {
                            Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                        }
                        if (ALAN.M_ALAN_ARAMA_TIP_ID==2)
                        {
                            Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                        }
                        else
                        {
                            Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                        }
                        gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBindTextEdit]);
                        repositoryItemTextEdit[intBindTextEdit].AutoHeight = false;
                        repositoryItemTextEdit[intBindTextEdit].Name = alanAdiEk + ALAN.ALAN_AD;
                        //repositoryItemTextEdit[intBindTextEdit].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(MouseSpin);
                        //Column1.Width = 10;
                        Column1.ColumnEdit = repositoryItemTextEdit[intBindTextEdit];
                        intBindTextEdit++;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 2)
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_LISTE_AD;
                        Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD,(int)Dil.Turkce);
                        //Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                        repositoryItemLookUpEdit1[intBind].ExportMode = ExportMode.DisplayText;
                        string mt = "";
                        
                            mt = "Get" + ALAN.ALAN_AD;
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, 0, "", "", 0);
                        repositoryItemLookUpEdit1[intBind].NullText = "";
                        repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        repositoryItemLookUpEdit1[intBind].Name = alanAdiEk + ALAN.ALAN_AD;
                        repositoryItemLookUpEdit1[intBind].ValueMember = "ID";


                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);


                        if (ALAN.ALAN_AD == "STOK_ID" || ALAN.ALAN_AD == "CARI_ID") //M_ALANLAR tablosuna arama tipi konulacak
                        {
                            Column1.Width = 60;
                            repositoryItemLookUpEdit1[intBind].ImmediatePopup = true;
                            repositoryItemLookUpEdit1[intBind].TextEditStyle = TextEditStyles.Standard;
                            repositoryItemLookUpEdit1[intBind].PopupFilterMode = PopupFilterMode.Contains;
                        }
                        //if (repositoryItemLookUpEdit1[intBind].View.RowCount > 0)
                        //{
                        //    repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                        //}
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                             repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                            if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                            }
                        }
                        Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                        intBind += 1;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 8)// EVET HAYIR
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD, (int)Dil.Turkce);
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                        repositoryItemLookUpEdit1[intBind].ExportMode = ExportMode.DisplayText;

                        bindingSourceArr[intBind].DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, 0, "", "", 0);
                        repositoryItemLookUpEdit1[intBind].NullText = "";
                        repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        if (repositoryItemLookUpEdit1[intBind].View.RowCount > 0)
                        {
                            repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                        }
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            //List<IdAdVm> VM = (List<IdAdVm>)bindingSourceArr[intBind].DataSource;
                            if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                            }
                        }
                        repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        repositoryItemLookUpEdit1[intBind].Name = alanAdiEk + ALAN.ALAN_AD;
                        repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                        Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                        intBind += 1;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TARIH)//TARIH
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD, (int)Dil.Turkce);
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                        repositoryItemDateEdit.AutoHeight = false;
                        repositoryItemDateEdit.Name = alanAdiEk + ALAN.ALAN_AD;
                        repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton()});
                        gridControl1.RepositoryItems.Add(repositoryItemDateEdit);
                        Column1.ColumnEdit = repositoryItemDateEdit;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TARIHTAM)//TARIH
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD, (int)Dil.Turkce);
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        //    repositoryItemTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
                        //    repositoryItemTimeEdit.AutoHeight = false;
                        //    repositoryItemTimeEdit.Name = alanAdiEk + ALAN.ALAN_AD;
                        ////    repositoryItemTimeEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        ////new DevExpress.XtraEditors.Controls.EditorButton()});
                        //    gridControl1.RepositoryItems.Add(repositoryItemTimeEdit);
                        //    Column1.ColumnEdit = repositoryItemTimeEdit;

                        repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                        repositoryItemDateEdit.AutoHeight = false;
                        repositoryItemDateEdit.Name = alanAdiEk + ALAN.ALAN_AD;
                        repositoryItemDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                        repositoryItemDateEdit.Mask.EditMask = "G";
                        repositoryItemDateEdit.Mask.UseMaskAsDisplayFormat = true;

                        //repositoryItemDateEdit.Mask.UseMaskAsDisplayFormat =MaskFormat
                        repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton()});
                        gridControl1.RepositoryItems.Add(repositoryItemDateEdit);
                        Column1.ColumnEdit = repositoryItemDateEdit;

                    }
                    else if (ALAN.M_ALAN_TIP_ID == 4)//DECIMAL
                    {
                        string format = "n2";
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD, (int)Dil.Turkce);
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {

                            //GridGroupSummaryItem item = new GridGroupSummaryItem();
                            //item.FieldName = Column1.FieldName;
                            //item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            //item.DisplayFormat = Column1.FieldName.ToString() + "{0:N2}";
                            //Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
                            //Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            //view.GroupSummary.Add(item);

                            GridGroupSummaryItem item = new GridGroupSummaryItem();
                            item.FieldName = Column1.FieldName;
                            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            if (format != "")
                            {
                                item.ShowInGroupColumnFooter = Column1;
                                if (format == "n0")
                                {
                                    //item.DisplayFormat = Column1.FieldName.ToString() + " : {0:0}";
                                    item.DisplayFormat = "{0:0}";
                                }
                                else
                                {
                                    item.DisplayFormat = "{0:" + format + "}";
                                }

                            }
                            Column1.SummaryItem.FieldName = Column1.FieldName;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            if (format != "")
                            {
                                if (format == "n0")
                                {
                                    Column1.SummaryItem.DisplayFormat = "{0:0}";
                                }
                                else
                                {
                                    Column1.SummaryItem.DisplayFormat = "{0:" + format + "}";
                                }

                            }
                            view.GroupSummary.Add(item);




                        }
                        else if (ALAN.M_ALAN_ALT_BILGI == 2)
                        {

                            GridGroupSummaryItem item = new GridGroupSummaryItem();
                            item.FieldName = Column1.FieldName;
                            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                            if (format == "n0")
                            {
                                //item.DisplayFormat = Column1.FieldName.ToString() + " : {0:0}";
                                item.DisplayFormat = "{0:0}";
                            }
                            else
                            {
                                item.DisplayFormat = "{0:" + format + "}";
                            }
                          //  item.DisplayFormat = Column1.FieldName.ToString() + "{0:N2}";
                            Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                            if (format != "")
                            {
                                if (format == "n0")
                                {
                                    Column1.SummaryItem.DisplayFormat = "{0:0}";
                                }
                                else
                                {
                                    Column1.SummaryItem.DisplayFormat = "{0:" + format + "}";
                                }

                            }
                            view.GroupSummary.Add(item);
                        }
                        else
                        {
                            //GridGroupSummaryItem item = new GridGroupSummaryItem();
                            //item.FieldName = Column1.FieldName;
                            //item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            //item.DisplayFormat = Column1.FieldName.ToString() + " : " + "{0:N2}";
                            //Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
                            //Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            //view.GroupSummary.Add(item);
                        }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemTextEdit[intBindTextEdit] = new RepositoryItemTextEdit();
                        if (ALAN.ALAN_DECIMAL != null)
                        {
                            String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
                            String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
                            if (a == "##")
                            {
                                repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = "###,###,##0.00";
                            }
                            else
                            {
                                repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = "###,###,##0.00000";
                            }

                        }
                        else
                        {
                            if (format != "")
                            {
                                Column1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                //if (format == "n0")
                                //{
                                //    Column1.DisplayFormat.FormatString = "n1";
                                //}
                                //else
                                //{
                                Column1.DisplayFormat.FormatString = format;
                                //}
                            }
                            else
                            {
                                repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = "###,##0";
                            }

                        }
                        repositoryItemTextEdit[intBindTextEdit].Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        repositoryItemTextEdit[intBindTextEdit].Mask.UseMaskAsDisplayFormat = true;
                        repositoryItemTextEdit[intBindTextEdit].Name = alanAdiEk + ALAN.ALAN_AD;
                        gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBindTextEdit]);
                        Column1.ColumnEdit = repositoryItemTextEdit[intBindTextEdit];
                        //repositoryItemTextEdit[intBindTextEdit].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        intBindTextEdit++;
                    }

                    else if (ALAN.M_ALAN_TIP_ID == 5)//TAMSAYI
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD, (int)Dil.Turkce);
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {
                            Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemTextEdit[intBindTextEdit] = new RepositoryItemTextEdit();
                        gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBindTextEdit]);
                        repositoryItemTextEdit[intBindTextEdit].AutoHeight = false;
                        repositoryItemTextEdit[intBindTextEdit].Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.ColumnEdit = repositoryItemTextEdit[intBindTextEdit];
                        //repositoryItemTextEdit[intBindTextEdit].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        intBind += 1;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 6)//checkbox
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD, (int)Dil.Turkce);
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        repositoryItemCheckEdit.AutoHeight = false;
                        repositoryItemCheckEdit.Name = alanAdiEk + ALAN.ALAN_AD;
                        gridControl1.RepositoryItems.Add(repositoryItemCheckEdit);
                        Column1.ColumnEdit = repositoryItemCheckEdit;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 7) // baglı Alan
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD, (int)Dil.Turkce);
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                        string mt = "";
                        mt = "Get" + ALAN.ALAN_AD;
                        bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, 0, "", "", 0);
                        repositoryItemLookUpEdit.NullText = "";
                        repositoryItemLookUpEdit.DataSource = bindingSourceArr[intBind];
                        repositoryItemLookUpEdit.DisplayMember = "AD";
                        repositoryItemLookUpEdit.Name = alanAdiEk + ALAN.ALAN_AD;
                        repositoryItemLookUpEdit.ValueMember = "ID";
                        Column1.ColumnEdit = repositoryItemLookUpEdit;
                        intBind += 1;
                    }
                    Column1.BestFit();
                    //if (Globals.rman.GetString(ALAN.ALAN_AD) != null)// stok gozlem de calisabilmesi icin acildi
                    //{
                    //    view.Columns.Add(Column1);
                    //}
                    view.Columns.Add(Column1);
                }
            }
        }
        public static void Grid_Olustur_Dinamik(string ns, string tn, string an, GridView view, GridControl gridControl, string[] toplamAlanlari, string[] dinamikAlanlar,string dinamikAltAlan)
        {
            bool satirToplam = true;
            int i = 1;
            int ekAlanlar = 0;
            view.Columns.Clear();
            DevExpress.XtraGrid.Columns.GridColumn Column1;
            Type calledType = Type.GetType(ns + "." + tn + "," + an);
            foreach (PropertyInfo propertyInfo in calledType.GetProperties())
            {
                bool listViewModeldenMi = false;
                try
                {
                    TipAttribute tblAtr = ((TipAttribute[])propertyInfo.GetCustomAttributes(typeof(TipAttribute), false))[0];
                    listViewModeldenMi = tblAtr.listViewModel;
                }
                catch (Exception)
                {
                    listViewModeldenMi = false;
                    //  throw;
                }
                Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                Column1.FieldName = propertyInfo.Name;
                if (listViewModeldenMi == true)
                {
                    Column1.Visible = false;
                    Column1.VisibleIndex = -1;
                }
                else
                {
                    Column1.Caption = AlanAdi(propertyInfo.Name, dinamikAlanlar).Trim();
                    if (Column1.Caption  == "" && satirToplam == false)
                    {
                        Column1.Visible = false;
                        Column1.VisibleIndex = -1;
                    }
                    else
                    {
                        if (Column1.Caption== "" && ekAlanlar==0)
                        {
                            Column1.Caption = "DIGER_TOPLAM";
                            ekAlanlar = 1;
                        }
                        else if (Column1.Caption == "" && ekAlanlar == 1)
                        {
                            Column1.Caption = "SATIR_TOPLAM";
                            satirToplam = false;
                        }
                        Column1.Visible = true;
                        Column1.VisibleIndex = i;

                    }


                    if (Column1.Caption == "KODID")
                    {
                        Column1.Caption = "GRUPLANAN ALAN ADI";
                        BindingSource bindingSource  = new System.Windows.Forms.BindingSource();
                        RepositoryItemGridLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemGridLookUpEdit();
                        gridControl.RepositoryItems.Add(repositoryItemLookUpEdit1);
                       
                            bindingSource.DataSource = ListService.InvokeMethod("Get" + dinamikAltAlan, (int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "",0);
                        
                        repositoryItemLookUpEdit1.NullText = "";
                        repositoryItemLookUpEdit1.DataSource = bindingSource;
                        repositoryItemLookUpEdit1.DisplayMember = "AD";
                        repositoryItemLookUpEdit1.Name = propertyInfo.Name;
                        repositoryItemLookUpEdit1.ValueMember = "ID";
                        Column1.ColumnEdit = repositoryItemLookUpEdit1;
                    }




                    view.Columns.Add(Column1);
                    if (Column1.Caption != "KOD" && Column1.Caption != "GRUPLANAN ALAN ADI")
                    {
                        Column1.SummaryItem.FieldName = Column1.FieldName;
                        Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    }
                    i++;
                }
           
              

                //if (propertyInfo.Name.Length > 4)
                //{
                //    if (propertyInfo.Name.Substring(propertyInfo.Name.Length - 2, 2) != "VM" && propertyInfo.Name.Substring(propertyInfo.Name.Length - 4, 4) != "temp")
                //    {
                //        Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                //        Column1.FieldName = propertyInfo.Name;
                //        Column1.Caption = AlanAdi(propertyInfo.Name, dinamikAlanlar).Trim();
                //        Column1.Visible = true;
                //        Column1.VisibleIndex = i;
                //        view.Columns.Add(Column1);
                //        if (Column1.Caption != "KOD")
                //        {
                //            Column1.SummaryItem.FieldName = Column1.FieldName;
                //            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //        }
                //    }
                //}
                //else
                //{
                //    Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                //    Column1.FieldName = propertyInfo.Name;
                //    Column1.Caption = AlanAdi(propertyInfo.Name, dinamikAlanlar);
                //    if (Column1.Caption != "")
                //    {
                //        Column1.Visible = true;
                //        Column1.VisibleIndex = i;
                //        view.Columns.Add(Column1);
                //        if (Column1.Caption != "KOD")
                //        {
                //            Column1.SummaryItem.FieldName = Column1.FieldName;
                //            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //        }
                //    }
                //}
                
            }
         
         //   view.Columns["GUN"].Visible = false;
            view.GroupPanelText = "Gruplamak İstediğiniz Alanı Bu Bölgeye Sürükleyiniz";
            view.BestFitColumns();
            //DinamikListeVm k = (DinamikListeVm)model[index];
            //PropertyInfo pi = k.GetType().GetProperty("CARIVM");
            //CariVm c = new CariVm();
            //PropertyInfo pi1 = c.GetType().GetProperty(alanDinamik);
            //object deger = pi1.GetValue(c, null);
            //int degeri = 0;
            //if (deger != null)
            //{
            //    degeri = (int)deger;
            //    ambarlar[degeri] += (decimal)model[index].TUTARtemp;
            //}
        }
        public static void Gridi_OlusturbyListForExcelAktarma(List<Alanlar> alanlar, GridView view, GridControl gridControl1, int alanSira, string alanAdiEk, string[] tabloAd)
        {
            if (alanAdiEk == "STOKTABLOSU")
            {
                alanAdiEk = "";
            }
            else if (alanAdiEk == "CARITABLOSU")
            {
                alanAdiEk = "";
            }
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit;
            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit;
            DevExpress.XtraGrid.Columns.GridColumn Column1;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[] repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[128];
            BindingSource[] bindingSourceArr = new BindingSource[128];
            int intBind = 0;
            // view.OptionsBehavior.Editable = false;
            foreach (var ALAN in alanlar)
            {
                if (ALAN.ALAN_AD != "ID")
                {
                    Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                    Column1.OptionsColumn.AllowEdit = false;
                    if (ALAN.M_ALAN_TIP_ID == 1 || ALAN.M_ALAN_TIP_ID == null)  // TEXT
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD, (int)Dil.Turkce);
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                        repositoryItemTextEdit.AutoHeight = false;
                        repositoryItemTextEdit.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.ColumnEdit = repositoryItemTextEdit;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 2)
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        Column1.OptionsColumn.AllowEdit = true;
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                        gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        string mt = "";
                       
                         
                            mt = "Get" + ALAN.ALAN_AD;
                            List<IdAdVm> vmList = new List<IdAdVm>();
                            vmList = (List<IdAdVm>)YeniListService.InvokeMethod(mt, 0, ALAN.ID, 0, tabloAd[0]);
                            if (tabloAd[1] != "")
                            {
                                vmList.AddRange((List<IdAdVm>)YeniListService.InvokeMethod(mt, 0, ALAN.ID, 0, tabloAd[1]));
                            }
                            bindingSourceArr[intBind].DataSource = vmList;
                      
                        repositoryItemLookUpEdit1[intBind].NullText = "";
                        repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            //List<IdAdVm> VM = (List<IdAdVm>)bindingSourceArr[intBind].DataSource;
                            if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                            }
                        }
                        repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        repositoryItemLookUpEdit1[intBind].Name = alanAdiEk + ALAN.ALAN_AD;
                        repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        if (ALAN.ALAN_AD == "STOK_ID" || ALAN.ALAN_AD == "CARI_ID") //M_ALANLAR tablosuna arama tipi konulacak
                        {
                            Column1.Width = 60;
                            repositoryItemLookUpEdit1[intBind].ImmediatePopup = true;
                            repositoryItemLookUpEdit1[intBind].TextEditStyle = TextEditStyles.Standard;
                            repositoryItemLookUpEdit1[intBind].PopupFilterMode = PopupFilterMode.Contains;
                        }
                        if (repositoryItemLookUpEdit1[intBind].View.RowCount > 0)
                        {
                            repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                        }
                        Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                        intBind += 1;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 8)// EVET HAYIR
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }

                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                        bindingSourceArr[intBind].DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                        repositoryItemLookUpEdit1[intBind].NullText = "";
                        repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            //List<IdAdVm> VM = (List<IdAdVm>)bindingSourceArr[intBind].DataSource;
                            if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                            }
                        }
                        repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        repositoryItemLookUpEdit1[intBind].Name = alanAdiEk + ALAN.ALAN_AD;
                        repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                        Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                        intBind += 1;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 3)//TARIH
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                        repositoryItemDateEdit.AutoHeight = false;
                        repositoryItemDateEdit.Name = alanAdiEk + ALAN.ALAN_AD;
                        repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton()});
                        gridControl1.RepositoryItems.Add(repositoryItemDateEdit);
                        Column1.ColumnEdit = repositoryItemDateEdit;

                    }
                    else if (ALAN.M_ALAN_TIP_ID == 4)//DECIMAL
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {

                            GridGroupSummaryItem item = new GridGroupSummaryItem();
                            item.FieldName = Column1.FieldName;
                            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            item.DisplayFormat = Column1.FieldName.ToString() + "{0:N2}";
                            Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            view.GroupSummary.Add(item);
                        }
                        else if (ALAN.M_ALAN_ALT_BILGI == 2)
                        {

                            GridGroupSummaryItem item = new GridGroupSummaryItem();
                            item.FieldName = Column1.FieldName;
                            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            item.DisplayFormat = Column1.FieldName.ToString() + "{0:N2}";
                            Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                            view.GroupSummary.Add(item);
                        }
                        else
                        {
                            //GridGroupSummaryItem item = new GridGroupSummaryItem();
                            //item.FieldName = Column1.FieldName;
                            //item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            //item.DisplayFormat = Column1.FieldName.ToString() + " : " + "{0:N2}";
                            //Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
                            //Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            //view.GroupSummary.Add(item);
                        }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        if (ALAN.ALAN_DECIMAL != null)
                        {
                            String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
                            String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
                            repositoryItemTextEdit.Mask.EditMask = b + "." + a;
                            repositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                            repositoryItemTextEdit.Mask.UseMaskAsDisplayFormat = true;
                        }
                        repositoryItemTextEdit.Name = alanAdiEk + ALAN.ALAN_AD;
                        gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                        Column1.ColumnEdit = repositoryItemTextEdit;

                    }

                    else if (ALAN.M_ALAN_TIP_ID == 5)//TAMSAYI
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {
                            Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                        repositoryItemTextEdit.AutoHeight = false;
                        repositoryItemTextEdit.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.ColumnEdit = repositoryItemTextEdit;
                        intBind += 1;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 6)//checkbox
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        repositoryItemCheckEdit.AutoHeight = false;
                        repositoryItemCheckEdit.Name = alanAdiEk + ALAN.ALAN_AD;
                        gridControl1.RepositoryItems.Add(repositoryItemCheckEdit);
                        Column1.ColumnEdit = repositoryItemCheckEdit;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 7) // baglı Alan
                    {
                        Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Name = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
                        if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            Column1.OptionsColumn.AllowEdit = false;
                            Column1.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            Column1.OptionsColumn.ReadOnly = false;
                            Column1.OptionsColumn.AllowEdit = true;
                            Column1.OptionsColumn.AllowFocus = true;
                        }
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                        string mt = "";
                        mt = "Get" + ALAN.ALAN_AD;
                        bindingSourceArr[intBind].DataSource = YeniListService.InvokeMethod(mt, 0, ALAN.ID, 0, tabloAd[0]);
                        repositoryItemLookUpEdit.NullText = "";
                        repositoryItemLookUpEdit.DataSource = bindingSourceArr[intBind];
                        repositoryItemLookUpEdit.DisplayMember = "AD";
                        repositoryItemLookUpEdit.Name = alanAdiEk + ALAN.ALAN_AD;
                        repositoryItemLookUpEdit.ValueMember = "ID";
                        Column1.ColumnEdit = repositoryItemLookUpEdit;
                        intBind += 1;
                    }
                    Column1.BestFit();
                    //if (Globals.rman.GetString(ALAN.ALAN_AD) != null)// stok gozlem de calisabilmesi icin acildi
                    //{
                    //    view.Columns.Add(Column1);
                    //}
                    view.Columns.Add(Column1);
                }
            }
        }
        static string AlanAdi(string ad, string[] dinamikAlanlar)
        {
            if (ad.Length > 6)
            {
                if (ad.Substring(0, 6) == "MIKTAR")
                {
                    if (Convert.ToInt32(ad.Substring(ad.Length - 1, 1)) > dinamikAlanlar.Length)
                    {
                        return "";
                    }
                    else
                    {
                        if (ad.Length == 7)
                        {
                            if (Convert.ToInt32(ad.Substring(ad.Length - 1, 1)) <= dinamikAlanlar.Length)
                            {
                                    return dinamikAlanlar[Convert.ToInt32(ad.Substring(ad.Length - 1, 1)) - 1];
                            }
                            else
                            {
                                return "";
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ad.Substring(ad.Length - 2, 2)) <= dinamikAlanlar.Length)
                            {
                                return dinamikAlanlar[Convert.ToInt32(ad.Substring(ad.Length - 2, 2)) - 1];
                            }
                            else
                            {
                                return "";
                            }
                        }
                    }
                }
                else
                {
                    return ad;
                }
            }

            else
            {
                return ad;
            }
        }
        public static void Grid_Olustur_Dinamik1(string ns, string tn, string an, GridView view, GridControl gridControl, string[] toplamAlanlari, string[] dinamikAlanlar, string dinamikAltAlan, Dictionary<string, string> parameters)
        {
            int seciliIndex = 1;
            if (parameters["LISTE_TIP"].ToString() == "7")
            {
                seciliIndex = 2;
            }
            view.Columns.Clear();
            int i = 0;
            DevExpress.XtraGrid.Columns.GridColumn Column2= new DevExpress.XtraGrid.Columns.GridColumn();
            Column2.Caption = "GRUPLANAN ALAN ADI";
            Column2.Name = "KODID";
            BindingSource bindingSource = new System.Windows.Forms.BindingSource();
            RepositoryItemGridLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemGridLookUpEdit();
            gridControl.RepositoryItems.Add(repositoryItemLookUpEdit1);
            
                bindingSource.DataSource = ListService.InvokeMethod("Get" + dinamikAltAlan, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "",0);

            repositoryItemLookUpEdit1.NullText = "";
            repositoryItemLookUpEdit1.DataSource = bindingSource;
            repositoryItemLookUpEdit1.DisplayMember = "AD";
            repositoryItemLookUpEdit1.Name = "KODID";
            repositoryItemLookUpEdit1.ValueMember = "ID";
            Column2.ColumnEdit = repositoryItemLookUpEdit1;
            Column2.Visible = true;
            Column2.VisibleIndex = i;
            Column2.FieldName = "KODID";
            view.Columns.Add(Column2);

            int sira = 1;
            
            for (i = 0; i < dinamikAlanlar.Length; i++)
            {
                for (int j = 0; j < seciliIndex; j++)
			    {
			        Column2= new DevExpress.XtraGrid.Columns.GridColumn();
                    Column2.Caption = dinamikAlanlar[i].Trim();
                    Column2.Name = "MIKTAR" + sira;
                    Column2.FieldName = "MIKTAR" + sira;
                    Column2.Visible = true;
                    Column2.VisibleIndex = sira;
                    view.Columns.Add(Column2);
                    sira++;
			    }
            }
            Column2 = new DevExpress.XtraGrid.Columns.GridColumn();
            Column2.Caption = "DIGER TOPLAM";
            Column2.FieldName = "DIGER TOPLAM";
            Column2.Visible = true;
            Column2.VisibleIndex = sira;
            view.Columns.Add(Column2);
            Column2 = new DevExpress.XtraGrid.Columns.GridColumn();
            Column2.Caption = "DİĞER TOPLAM";
            Column2.FieldName = "DIGER TOPLAM";
            Column2.Visible = true;
            Column2.VisibleIndex = sira+1;
            view.Columns.Add(Column2);

            Column2 = new DevExpress.XtraGrid.Columns.GridColumn();
            Column2.Caption = "SATIR TOPLAM";
            Column2.FieldName = "SATIR TOPLAM";
            Column2.Visible = true;
            Column2.VisibleIndex = sira+2;
            view.Columns.Add(Column2);
            Column2 = new DevExpress.XtraGrid.Columns.GridColumn();
            Column2.Caption = "SATIR TOPLAM";
            Column2.FieldName = "SATIR TOPLAM";
            Column2.Visible = true;
            Column2.VisibleIndex = sira+3;
            view.Columns.Add(Column2);
        }
        static string AlanAdi1(string ad, string[] dinamikAlanlar)
        {
            if (ad.Length > 6)
            {
                if (ad.Substring(0, 6) == "MIKTAR")
                {
                    if (Convert.ToInt32(ad.Substring(ad.Length - 1, 1)) > dinamikAlanlar.Length)
                    {
                        return "";
                    }
                    else
                    {
                        if (ad.Length == 7)
                        {
                            if (Convert.ToInt32(ad.Substring(ad.Length - 1, 1)) <= dinamikAlanlar.Length)
                            {
                                return dinamikAlanlar[Convert.ToInt32(ad.Substring(ad.Length - 1, 1)) - 1];
                            }
                            else
                            {
                                return "";
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ad.Substring(ad.Length - 2, 2)) <= dinamikAlanlar.Length)
                            {
                                return dinamikAlanlar[Convert.ToInt32(ad.Substring(ad.Length - 2, 2)) - 1];
                            }
                            else
                            {
                                return "";
                            }
                        }
                    }
                }
                else
                {
                    return ad;
                }
            }

            else
            {
                return ad;
            }
        }
        static string IsimAl(string name, int dil)
        {
            if (dil == 0)
            {
                dil = (int)Dil.Turkce;
            }
            string temp = "";
            string[] a = name.Split('.');
            if (a.Length == 1)
            {
                if (dil != (int)Dil.Turkce)
                {
                    temp = Globals.rmanIng.GetString(name);
                }
                else
                {
                    temp = Globals.rman.GetString(name);

                }
            }
            else if (a.Length == 2)
            {
                if (dil != (int)Dil.Turkce)
                {
                    temp = Globals.rmanIng.GetString(a[0]);
                }
                else
                {
                    temp = Globals.rman.GetString(a[0]);
                }
                if (temp == null) { temp = a[0]; }
                if (dil != (int)Dil.Turkce)
                {
                    temp = temp.Trim() != "" ? temp + "-" + Globals.rmanIng.GetString(a[1]) : Globals.rman.GetString(a[1]);
                }
                else
                {
                    temp = temp.Trim() != "" ? temp + "-" + Globals.rman.GetString(a[1]) : Globals.rman.GetString(a[1]);

                }
            }
            else if (a.Length == 3)
            {
                if (dil != (int)Dil.Turkce)
                {
                    temp = Globals.rmanIng.GetString(a[0]);
                    temp = temp + "-" + Globals.rmanIng.GetString(a[1]);
                    temp = temp.Trim() != "" ? temp + "-" + Globals.rmanIng.GetString(a[2]) : Globals.rmanIng.GetString(a[2]);
                }
                else
                {
                  
                    temp = Globals.rman.GetString(a[0]);
                    temp = temp + "-" + Globals.rman.GetString(a[1]);
                    temp = temp.Trim() != "" ? temp + "-" + Globals.rman.GetString(a[2]) : Globals.rman.GetString(a[2]);
                }
            }
            return temp != null ? temp : name;
        }
     
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit[] repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit[64];
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn Column1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
        public DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[] repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[32];
        public BindingSource[] bindingSourceArr = new BindingSource[32];
        //public static void Gridi_OlusturOrtak(List<Alanlar> alanlar, Dictionary<string, int> AlanAdiIndexi, Dictionary<int, bool> koplalamaDurumu, RepositoryItemTextEdit[] repositoryItemTextEdit, RepositoryItemDateEdit repositoryItemDateEdit, RepositoryItemLookUpEdit repositoryItemLookUpEdit, RepositoryItemCheckEdit repositoryItemCheckEdit, RepositoryItemGridLookUpEdit[] repositoryItemLookUpEdit1, BindingSource[] bindingSourceArr, RepositoryItemTimeEdit repositoryItemTimeEdit, GridView view, GridControl gridControl1, int alanSira, string alanAdiEk, bool gridTemizle)
        //{
        //    if (gridTemizle == true)
        //    {
        //        view.Columns.Clear();
        //    }
        //    if (alanAdiEk == "STOKTABLOSU") // eger dinamik updatede gelen bir istek ise
        //    {
        //        alanAdiEk = "";
        //    }
        //    else if (alanAdiEk == "CARITABLOSU")
        //    {
        //        alanAdiEk = "";
        //    }
        //    DevExpress.XtraGrid.Columns.GridColumn Column1;
        //    int intBind = 0;
        //    int intBindTextEdit = 0;
        //    string alanadi = "";
        //    foreach (var ALAN in alanlar)
        //    {
        //        Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
        //        Column1.Width = 5;
        //        alanadi = ALAN.ALAN_AD;
        //        if (ALAN.ALAN_AD != "ID")
        //        {
        //            Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
        //            Column1.OptionsColumn.AllowEdit = false;
        //            if (ALAN.M_ALAN_TIP_ID == 1 || ALAN.M_ALAN_TIP_ID == null)  // TEXT
        //            {
        //                Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Name = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD);
        //                Column1.Visible = true;
        //                Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
        //                if ((ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
        //                {
        //                    Column1.Visible = false;
        //                }
        //                if ((int)ALAN.ALAN_LISTE_GENISLIK > 50) //M_ALANLAR tablosuna arama tipi konulacak
        //                {
        //                    Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
        //                }
        //                if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null)
        //                {
        //                    Column1.OptionsColumn.ReadOnly = true;
        //                }
        //                else
        //                {
        //                    Column1.OptionsColumn.ReadOnly = false;
        //                    Column1.OptionsColumn.AllowEdit = true;
        //                    Column1.OptionsColumn.AllowFocus = true;
        //                }
        //                AlanAdiIndexi[view.Name + ALAN.ALAN_AD] = intBind;
        //                if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
        //                {
        //                    koplalamaDurumu[intBind] = false;
        //                }
        //                repositoryItemTextEdit[intBindTextEdit] = new RepositoryItemTextEdit();
        //                if (ALAN.KIRLIM_TIP_ID != null)
        //                {
        //                    string kirilim = YardimciIslemler.KirilimUygula(ALAN.KIRLIM_TIP_ID);
        //                    repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = kirilim;
        //                    repositoryItemTextEdit[intBindTextEdit].Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
        //                    repositoryItemTextEdit[intBindTextEdit].Mask.UseMaskAsDisplayFormat = true;
        //                }
        //                else
        //                {
        //                    Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
        //                }
        //                gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBindTextEdit]);
        //                repositoryItemTextEdit[intBindTextEdit].AutoHeight = false;
        //                repositoryItemTextEdit[intBindTextEdit].Name = alanAdiEk + ALAN.ALAN_AD;
        //                repositoryItemTextEdit[intBindTextEdit].MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
        //                Column1.ColumnEdit = repositoryItemTextEdit[intBindTextEdit];
        //                //repositoryItemTextEdit[intBindTextEdit].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(MouseSpin);                        
        //                intBindTextEdit++;
        //            }
        //            else if (ALAN.M_ALAN_TIP_ID == 2)
        //            {
        //                Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Name = ALAN.ALAN_LISTE_AD;
        //                Column1.Caption = Globals.rman.GetString(alanAdiEk + ALAN.ALAN_LISTE_AD);
        //                //Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Visible = true;
        //                Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
        //                if ((ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
        //                {
        //                    Column1.Visible = false;
        //                    Column1.VisibleIndex = -1;
        //                }
        //                if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet && ALAN.M_ALANLAR_ALT_ID == null)
        //                {
        //                    Column1.OptionsColumn.ReadOnly = true;
        //                    //Column1.OptionsColumn.AllowEdit = false;
        //                    //Column1.OptionsColumn.AllowFocus = true;
        //                }
        //                if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
        //                bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
        //                gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
        //                repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
        //                string mt = "";
        //                if (ALAN.ALAN_AD.Length > 9 && ALAN.ALAN_AD.Substring(0, 9) == "STOK_GRUP")
        //                {
        //                    Column1.Caption = ALAN.ALAN_AD;
        //                    Column1.Name = ALAN.ALAN_AD;
        //                    int id = 0;
        //                    if (ALAN.ALAN_AD == "GRUP10_ID")
        //                    {
        //                        id = 10;
        //                    }
        //                    else
        //                    {
        //                        id = Convert.ToInt32(ALAN.ALAN_AD.Substring(9, 1));
        //                    }
        //                    bindingSourceArr[intBind].DataSource = ListDenemeService.GetSTOK_GRUPLAR_ID(id);
        //                }
        //                else if (ALAN.ALAN_AD.Length > 9 && ALAN.ALAN_AD.Substring(0, 9) == "CARI_GRUP")
        //                {
        //                    Column1.Caption = ALAN.ALAN_AD;
        //                    Column1.Name = ALAN.ALAN_AD;
        //                    int id = 0;
        //                    if (ALAN.ALAN_AD == "GRUP10_ID")
        //                    {
        //                        id = 10;
        //                    }
        //                    else
        //                    {
        //                        id = Convert.ToInt32(ALAN.ALAN_AD.Substring(9, 1));
        //                    }
        //                    bindingSourceArr[intBind].DataSource = ListDenemeService.GetCARI_GRUPLAR_ID(id);
        //                }
        //                else
        //                {
        //                    mt = "Get" + ALAN.ALAN_AD;
        //                    bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, 0, "", "", 0);
        //                }
        //                repositoryItemLookUpEdit1[intBind].NullText = "";
        //                repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
        //                repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
        //                repositoryItemLookUpEdit1[intBind].Name = alanAdiEk + ALAN.ALAN_AD;
        //                repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
        //                repositoryItemLookUpEdit1[intBind].CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
        //                if (ALAN.ALAN_AD == "STOK_ID" || ALAN.ALAN_AD == "CARI_ID") //M_ALANLAR tablosuna arama tipi konulacak
        //                {
        //                    Column1.Width = 60;
        //                    repositoryItemLookUpEdit1[intBind].ImmediatePopup = true;
        //                    repositoryItemLookUpEdit1[intBind].TextEditStyle = TextEditStyles.Standard;
        //                    repositoryItemLookUpEdit1[intBind].PopupFilterMode = PopupFilterMode.Contains;
        //                    Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
        //                }
        //                if (repositoryItemLookUpEdit1[intBind].View.RowCount > 0)
        //                {
        //                    repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
        //                }
        //                if (bindingSourceArr[intBind].DataSource != null)
        //                {
        //                    //List<IdAdVm> VM = (List<IdAdVm>)bindingSourceArr[intBind].DataSource;
        //                    if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
        //                    {
        //                        repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
        //                    }
        //                }
        //                Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
        //                intBind += 1;
        //            }
        //            else if (ALAN.M_ALAN_TIP_ID == 8)// EVET HAYIR
        //            {
        //                Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Name = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Visible = true;
        //                Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
        //                if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.Visible = false;
        //                    Column1.VisibleIndex = -1;
        //                }
        //                if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.OptionsColumn.ReadOnly = true;
        //                    Column1.OptionsColumn.AllowEdit = false;
        //                    Column1.OptionsColumn.AllowFocus = false;
        //                }
        //                else
        //                {
        //                    Column1.OptionsColumn.ReadOnly = false;
        //                    Column1.OptionsColumn.AllowEdit = true;
        //                    Column1.OptionsColumn.AllowFocus = true;
        //                }
        //                bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
        //                gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
        //                repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
        //                bindingSourceArr[intBind].DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, 0, "", "", 0);
        //                repositoryItemLookUpEdit1[intBind].NullText = "";
        //                repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
        //                if (repositoryItemLookUpEdit1[intBind].View.RowCount > 0)
        //                {
        //                    repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
        //                }
        //                if (bindingSourceArr[intBind].DataSource != null)
        //                {
        //                    //List<IdAdVm> VM = (List<IdAdVm>)bindingSourceArr[intBind].DataSource;
        //                    if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
        //                    {
        //                        repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
        //                    }
        //                }
        //                repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
        //                repositoryItemLookUpEdit1[intBind].Name = alanAdiEk + ALAN.ALAN_AD;
        //                repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
        //                repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
        //                Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
        //                intBind += 1;
        //            }
        //            else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TARIH)//TARIH
        //            {
        //                Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Name = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Visible = true;
        //                Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
        //                if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.Visible = false;
        //                    Column1.VisibleIndex = -1;
        //                }
        //                if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.OptionsColumn.ReadOnly = true;
        //                    Column1.OptionsColumn.AllowEdit = false;
        //                    Column1.OptionsColumn.AllowFocus = false;
        //                }
        //                else
        //                {
        //                    Column1.OptionsColumn.ReadOnly = false;
        //                    Column1.OptionsColumn.AllowEdit = true;
        //                    Column1.OptionsColumn.AllowFocus = true;
        //                }
        //                repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
        //                repositoryItemDateEdit.AutoHeight = false;
        //                repositoryItemDateEdit.Name = alanAdiEk + ALAN.ALAN_AD;
        //                repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
        //            new DevExpress.XtraEditors.Controls.EditorButton()});
        //                gridControl1.RepositoryItems.Add(repositoryItemDateEdit);
        //                Column1.ColumnEdit = repositoryItemDateEdit;
        //            }
        //            else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TARIHTAM)//TARIH
        //            {
        //                Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Name = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Visible = true;
        //                Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
        //                if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.Visible = false;
        //                    Column1.VisibleIndex = -1;
        //                }
        //                if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.OptionsColumn.ReadOnly = true;
        //                    Column1.OptionsColumn.AllowEdit = false;
        //                    Column1.OptionsColumn.AllowFocus = false;
        //                }
        //                else
        //                {
        //                    Column1.OptionsColumn.ReadOnly = false;
        //                    Column1.OptionsColumn.AllowEdit = true;
        //                    Column1.OptionsColumn.AllowFocus = true;
        //                }
        //                //    repositoryItemTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
        //                //    repositoryItemTimeEdit.AutoHeight = false;
        //                //    repositoryItemTimeEdit.Name = alanAdiEk + ALAN.ALAN_AD;
        //                ////    repositoryItemTimeEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
        //                ////new DevExpress.XtraEditors.Controls.EditorButton()});
        //                //    gridControl1.RepositoryItems.Add(repositoryItemTimeEdit);
        //                //    Column1.ColumnEdit = repositoryItemTimeEdit;

        //                repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
        //                repositoryItemDateEdit.AutoHeight = false;
        //                repositoryItemDateEdit.Name = alanAdiEk + ALAN.ALAN_AD;
        //                repositoryItemDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
        //                repositoryItemDateEdit.Mask.EditMask = "G";
        //                repositoryItemDateEdit.Mask.UseMaskAsDisplayFormat = true;

        //                //repositoryItemDateEdit.Mask.UseMaskAsDisplayFormat =MaskFormat
        //                repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
        //            new DevExpress.XtraEditors.Controls.EditorButton()});
        //                gridControl1.RepositoryItems.Add(repositoryItemDateEdit);
        //                Column1.ColumnEdit = repositoryItemDateEdit;

        //            }
        //            else if (ALAN.M_ALAN_TIP_ID == 4)//DECIMAL
        //            {
        //                string format = "n2";
        //                Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Name = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Visible = true;
        //                Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
        //                if (ALAN.M_ALAN_ALT_BILGI == 1)
        //                {

        //                    //GridGroupSummaryItem item = new GridGroupSummaryItem();
        //                    //item.FieldName = Column1.FieldName;
        //                    //item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        //                    //item.DisplayFormat = Column1.FieldName.ToString() + "{0:N2}";
        //                    //Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                    //Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        //                    //view.GroupSummary.Add(item);

        //                    GridGroupSummaryItem item = new GridGroupSummaryItem();
        //                    item.FieldName = Column1.FieldName;
        //                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        //                    if (format != "")
        //                    {
        //                        item.ShowInGroupColumnFooter = Column1;
        //                        if (format == "n0")
        //                        {
        //                            //item.DisplayFormat = Column1.FieldName.ToString() + " : {0:0}";
        //                            item.DisplayFormat = "{0:0}";
        //                        }
        //                        else
        //                        {
        //                            item.DisplayFormat = "{0:" + format + "}";
        //                        }

        //                    }
        //                    Column1.SummaryItem.FieldName = Column1.FieldName;
        //                    Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        //                    if (format != "")
        //                    {
        //                        if (format == "n0")
        //                        {
        //                            Column1.SummaryItem.DisplayFormat = "{0:0}";
        //                        }
        //                        else
        //                        {
        //                            Column1.SummaryItem.DisplayFormat = "{0:" + format + "}";
        //                        }

        //                    }
        //                    view.GroupSummary.Add(item);




        //                }
        //                else if (ALAN.M_ALAN_ALT_BILGI == 2)
        //                {

        //                    GridGroupSummaryItem item = new GridGroupSummaryItem();
        //                    item.FieldName = Column1.FieldName;
        //                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        //                    item.DisplayFormat = Column1.FieldName.ToString() + "{0:N2}";
        //                    Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                    Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
        //                    view.GroupSummary.Add(item);
        //                }
        //                else
        //                {
        //                    //GridGroupSummaryItem item = new GridGroupSummaryItem();
        //                    //item.FieldName = Column1.FieldName;
        //                    //item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        //                    //item.DisplayFormat = Column1.FieldName.ToString() + " : " + "{0:N2}";
        //                    //Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                    //Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        //                    //view.GroupSummary.Add(item);
        //                }
        //                if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.Visible = false;
        //                    Column1.VisibleIndex = -1;
        //                }
        //                if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.OptionsColumn.ReadOnly = true;
        //                    Column1.OptionsColumn.AllowEdit = false;
        //                    Column1.OptionsColumn.AllowFocus = false;
        //                }
        //                else
        //                {
        //                    Column1.OptionsColumn.ReadOnly = false;
        //                    Column1.OptionsColumn.AllowEdit = true;
        //                    Column1.OptionsColumn.AllowFocus = true;
        //                }
        //                repositoryItemTextEdit[intBindTextEdit] = new RepositoryItemTextEdit();
        //                if (ALAN.ALAN_DECIMAL != null)
        //                {
        //                    String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
        //                    String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
        //                    if (a == "##")
        //                    {
        //                        repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = "###,##0.00";
        //                    }
        //                    else
        //                    {
        //                        repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = "###,##0.00000";
        //                    }

        //                }
        //                else
        //                {
        //                    if (format != "")
        //                    {
        //                        Column1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //                        //if (format == "n0")
        //                        //{
        //                        //    Column1.DisplayFormat.FormatString = "n1";
        //                        //}
        //                        //else
        //                        //{
        //                        Column1.DisplayFormat.FormatString = format;
        //                        //}
        //                    }
        //                    else
        //                    {
        //                        repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = "###,##0";
        //                    }

        //                }
        //                repositoryItemTextEdit[intBindTextEdit].Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
        //                repositoryItemTextEdit[intBindTextEdit].Mask.UseMaskAsDisplayFormat = true;
        //                repositoryItemTextEdit[intBindTextEdit].Name = alanAdiEk + ALAN.ALAN_AD;
        //                gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBindTextEdit]);
        //                Column1.ColumnEdit = repositoryItemTextEdit[intBindTextEdit];
        //                //repositoryItemTextEdit[intBindTextEdit].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
        //                intBindTextEdit++;
        //            }

        //            else if (ALAN.M_ALAN_TIP_ID == 5)//TAMSAYI
        //            {
        //                Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Name = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Visible = true;
        //                Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
        //                if (ALAN.M_ALAN_ALT_BILGI == 1)
        //                {
        //                    Column1.SummaryItem.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                    Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        //                }
        //                if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.Visible = false;
        //                    Column1.VisibleIndex = -1;
        //                }
        //                if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.OptionsColumn.ReadOnly = true;
        //                    Column1.OptionsColumn.AllowEdit = false;
        //                    Column1.OptionsColumn.AllowFocus = false;
        //                }
        //                else
        //                {
        //                    Column1.OptionsColumn.ReadOnly = false;
        //                    Column1.OptionsColumn.AllowEdit = true;
        //                    Column1.OptionsColumn.AllowFocus = true;
        //                }
        //                repositoryItemTextEdit[intBindTextEdit] = new RepositoryItemTextEdit();
        //                gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBindTextEdit]);
        //                repositoryItemTextEdit[intBindTextEdit].AutoHeight = false;
        //                repositoryItemTextEdit[intBindTextEdit].Name = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.ColumnEdit = repositoryItemTextEdit[intBindTextEdit];
        //                //repositoryItemTextEdit[intBindTextEdit].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
        //                intBind += 1;
        //            }
        //            else if (ALAN.M_ALAN_TIP_ID == 6)//checkbox
        //            {
        //                Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Name = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Visible = true;
        //                Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
        //                if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
        //                if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.Visible = false;
        //                    Column1.VisibleIndex = -1;
        //                }
        //                if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.OptionsColumn.ReadOnly = true;
        //                    Column1.OptionsColumn.AllowEdit = false;
        //                    Column1.OptionsColumn.AllowFocus = false;
        //                }
        //                else
        //                {
        //                    Column1.OptionsColumn.ReadOnly = false;
        //                    Column1.OptionsColumn.AllowEdit = true;
        //                    Column1.OptionsColumn.AllowFocus = true;
        //                }
        //                repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
        //                repositoryItemCheckEdit.AutoHeight = false;
        //                repositoryItemCheckEdit.Name = alanAdiEk + ALAN.ALAN_AD;
        //                gridControl1.RepositoryItems.Add(repositoryItemCheckEdit);
        //                Column1.ColumnEdit = repositoryItemCheckEdit;
        //            }
        //            else if (ALAN.M_ALAN_TIP_ID == 7) // baglı Alan
        //            {
        //                Column1.FieldName = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Name = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Caption = alanAdiEk + ALAN.ALAN_AD;
        //                Column1.Visible = true;
        //                Column1.VisibleIndex = alanSira + (int)ALAN.ALAN_SIRA;
        //                if (ALAN.GORMESIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.Visible = false;
        //                    Column1.VisibleIndex = -1;
        //                }
        //                if (ALAN.YAZMASIN_E_H == (int)EvetHayirEn.Evet)
        //                {
        //                    Column1.OptionsColumn.ReadOnly = true;
        //                    Column1.OptionsColumn.AllowEdit = false;
        //                    Column1.OptionsColumn.AllowFocus = false;
        //                }
        //                else
        //                {
        //                    Column1.OptionsColumn.ReadOnly = false;
        //                    Column1.OptionsColumn.AllowEdit = true;
        //                    Column1.OptionsColumn.AllowFocus = true;
        //                }
        //                bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
        //                gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
        //                repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
        //                string mt = "";
        //                mt = "Get" + ALAN.ALAN_AD;
        //                bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, 0, "", "", 0);
        //                repositoryItemLookUpEdit.NullText = "";
        //                repositoryItemLookUpEdit.DataSource = bindingSourceArr[intBind];
        //                repositoryItemLookUpEdit.DisplayMember = "AD";
        //                repositoryItemLookUpEdit.Name = alanAdiEk + ALAN.ALAN_AD;
        //                repositoryItemLookUpEdit.ValueMember = "ID";
        //                Column1.ColumnEdit = repositoryItemLookUpEdit;
        //                intBind += 1;
        //            }
        //            Column1.BestFit();
        //            //if (Globals.rman.GetString(ALAN.ALAN_AD) != null)// stok gozlem de calisabilmesi icin acildi
        //            //{
        //            //    view.Columns.Add(Column1);
        //            //}
        //            view.Columns.Add(Column1);
        //        }
        //    }
        //} // alanadiek dolu ise griddeki alanların basına alanadiEk geliyor



        //public static void GridMoldeGrupSecimleriCikart(MyGridView myGridView)
        //{
        //    foreach (DevExpress.XtraGrid.Columns.GridColumn item in myGridView.Columns)
        //    {
        //        if (item.FieldName == "GRUP_SECIM" || item.FieldName == "GRUP_SECIM1" || item.FieldName == "FIS_TARIH" || item.FieldName == "FIS_TARIH" || item.FieldName == "FIS_TARIH" || item.FieldName == "FIS_TARIH" || item.FieldName == "FIS_TARIH")
        //        {
        //            item.Visible = false;
        //        }
        //        // if (item.Visible == true) gridViewColumnschl.Properties.Items.Add(item.Caption.ToString(), item.Visible == true ? CheckState.Checked : CheckState.Unchecked, true);
        //    }
        //}
 
        public static void Gridi_Goster(usrGridIslem frm, object olusturulmayanlar, string baslik, int genislik)
        {
            frm.gridControl1.DataSource = olusturulmayanlar;
            frm.gridView1.OptionsView.ColumnAutoWidth = false;
            frm.gridView1.BestFitColumns();
            FormGoster sbl = new FormGoster();
            sbl.Text = baslik;
            frm.Dock = DockStyle.Fill;
            frm.gridControl1.Dock = DockStyle.Fill;
            sbl.Controls.Add(frm);
            sbl.Size = new Size(genislik, frm.Height);
            sbl.ShowDialog();
        }
    }
    public class GridOzellikleri
    {
        public bool autoWidth { get; set; }
        public GroupFooterShowMode groupFooterShowMode { get; set; }
        public bool acilmamisSatirlariGosterme { get; set; }
        public bool ParentpPropertileriGosterme { get; set; }
        public bool AltToplamGosterme { get; set; }
        public int dil { get; set; } 
    }
}
