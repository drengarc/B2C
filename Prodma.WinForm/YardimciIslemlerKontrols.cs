using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using Prodma.DataAccessB2C.Ortak_Classlar;
using Prodma.DataAccessB2C;
using Microsoft.Reporting.WinForms;
using Prodma.SistemB2C.Controllers;
using Prodma.SistemB2C.Models;
using System.Data.SqlClient;

namespace Prodma.WinForms
{
    public class YardimciIslemlerKontrols
    {
        #region kontrolDoldur
        public static void InvokeLkeContainSet(string mt, GridLookUpEdit lke)
        {
            lke.Properties.DataSource = ListService.InvokeMethod("Get" + mt, (int)ListServiceTipEn.LISTEKODSIRALAMALI, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
            lke.Properties.NullText = "";
            lke.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lke.Properties.PopupFilterMode = PopupFilterMode.Contains;
            lke.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            lke.Properties.ValueMember = "ID";
            lke.Properties.DisplayMember = "AD";
            //lke.Properties.View.Columns["ID"].Visible = false;  
        }
        public static void InvokeLkeContainSet(Object obj, GridLookUpEdit lke)
        {
            lke.Properties.DataSource = obj;
            lke.Properties.NullText = "";
            lke.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lke.Properties.PopupFilterMode = PopupFilterMode.Contains;
            lke.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            lke.Properties.ValueMember = "ID";
            lke.Properties.DisplayMember = "AD";
        }
        public static void InvokeLkeSet(string mt, GridLookUpEdit lke)
        {
            lke.Properties.DataSource = ListService.InvokeMethod("Get" + mt, (int)ListServiceTipEn.LISTEKODSIRALAMALI, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
            WinFormsHelper.GridLookUpEditDuzenle(lke);
        }
        public static void InvokeLueContainSet(string mt, LookUpEdit lke)
        {
            lke.Properties.DataSource = ListService.InvokeMethod("Get" + mt, (int)ListServiceTipEn.LISTEKODSIRALAMALI, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
            lke.Properties.NullText = "";
            lke.Properties.ValueMember = "ID";
            lke.Properties.DisplayMember = "AD";
        }
        public static void InvokeLueContainSet(Object obj, LookUpEdit lke)
        {
            lke.Properties.DataSource = obj;
            lke.Properties.NullText = "";
            lke.Properties.ValueMember = "ID";
            lke.Properties.DisplayMember = "AD";
            lke.Properties.ForceInitialize();
            lke.Properties.PopulateColumns();
            for (int i = 0; i < lke.Properties.Columns.Count; i++)
            {
                if (lke.Properties.Columns[i].FieldName != "AD")
                    lke.Properties.Columns[i].Visible = false;
            }
        }
        public static void InvokeChlMetodSet(Object data, CheckedComboBoxEdit chk)
        {
            chk.Properties.DataSource = data;
            chk.Properties.ValueMember = "ID";
            chk.Properties.DisplayMember = "AD";
        }
        public static void InvokeChlSet(string mt, CheckedComboBoxEdit chk)
        {
            Object a = ListService.InvokeMethod("Get" + mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
            try
            {
                List<IdAdVm> list = new List<IdAdVm>();
                List<IdAdVm> lst = (List<IdAdVm>)a;
                lst.Add(new IdAdVm { ID = 0, AD = "BOS OLANLAR" });
                list = lst.OrderBy(o => o.ID).ToList();
                chk.Properties.DataSource = list;
                chk.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                //chk.Properties.DataSource.
                chk.Properties.NullText = "Seçiniz";
                chk.Properties.ValueMember = "ID";
                chk.Properties.DisplayMember = "AD";
            }
            catch (Exception)
            {
                chk.Properties.DataSource = a;
                chk.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                //chk.Properties.DataSource.
                chk.Properties.NullText = "Seçiniz";
                chk.Properties.ValueMember = "ID";
                chk.Properties.DisplayMember = "AD";
            }
        }
        public static void InvokeChlSet(string mt, CustomEdit chk)
        {
            Object a = ListService.InvokeMethod("Get" + mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
            try
            {
                List<IdAdVm> list = new List<IdAdVm>();
                List<IdAdVm> lst = (List<IdAdVm>)a;
                lst.Add(new IdAdVm { ID = 0, AD = "BOS OLANLAR" });
                list = lst.OrderBy(o => o.ID).ToList();
                chk.Properties.DataSource = list;
                chk.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                //chk.Properties.DataSource.
                chk.Properties.NullText = "Seçiniz";
                chk.Properties.ValueMember = "ID";
                chk.Properties.DisplayMember = "AD";
            }
            catch (Exception)
            {
                chk.Properties.DataSource = a;
                chk.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                //chk.Properties.DataSource.
                chk.Properties.NullText = "Seçiniz";
                chk.Properties.ValueMember = "ID";
                chk.Properties.DisplayMember = "AD";
            }
        }
        public static void InvokeChlSet(object o, CheckedComboBoxEdit chk)
        {
            try
            {
                List<IdAdVm> list = new List<IdAdVm>();
                List<IdAdVm> lst = (List<IdAdVm>)o;
                IdAdVm vm = lst.Find(f => f.ID == 0);
                if (vm == null)
                {
                    lst.Add(new IdAdVm { ID = 0, AD = "BOS OLANLAR" });
                }
                list = lst.OrderBy(w => w.ID).ToList();
                chk.Properties.DataSource = list;
                chk.Properties.ValueMember = "ID";
                chk.Properties.DisplayMember = "AD";
            }
            catch
            {
                chk.Properties.DataSource = o;
                chk.Properties.ValueMember = "ID";
                chk.Properties.DisplayMember = "AD";
            }
        }
        public static void InvokeEnumSet(List<ListEnumVm> list, LookUpEdit lke)
        {

            lke.Properties.DataSource = list;
            lke.Properties.ValueMember = "ID";
            lke.Properties.DisplayMember = "AD";
            //lke.DataBindings.Add("EditValue", list, "EvetHayirEn");

            ////    BindingSource bn = new BindingSource();

            ////    foreach (var item in bn)
            ////    {
            ////        LookUpEditVm  list = new LookUpEditVm();
            ////        list.ID = 
            ////    }

            //    ListEnumVm list = new ListEnumVm();
            //    List<ListEnumVm> listG = new List<ListEnumVm>();

            //    list.ID = "0";
            //    list.AD = "fff";
            //    listG.Add(list);
            //    list = new ListEnumVm();
            //    list.ID = "1";
            //    list.AD = "Dsss";
            //    listG.Add(list);
            //    listG =  EnumToList<GirenCikanKalanEn>();
            //    lke.Properties.DataSource = listG;
            // //   listG = System.Enum.GetValues(typeof(GirenCikanKalanEn)).Cast<GirenCikanKalanEn>().ToList();
            //   // listG = GirenCikanKalanEn.GetValues(typeof(GirenCikanKalanEn));
            //    lke.EditValue = GirenCikanKalanEn.GIRIS;
        }
        public static void InvokeEvetHayirChlSet(string mt, CheckedComboBoxEdit chk)
        {
            chk.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
            chk.Properties.ValueMember = "ID";
            chk.Properties.DisplayMember = "AD";
        }
        public static List<ListEnumVm> EnumToList<T>()
        {
            // IList<T> myListOfEnum = (IList<T>)System.Enum.GetValues(typeof(T));
            // T[] myArrayOfEnum = (T[])System.Enum.GetValues(typeof(T));

            ////Type enumType ;
            //FieldInfo[] info = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public);
            //int a = info[0].;
            // System.Enum[] values = new System.Enum[info.Length];



            // foreach (var value in System.Enum.GetValues(typeof(T)))
            // {
            //     int value1 = (int)value;
            //     //int value2 = 
            //     //Console.WriteLine("{0,3}     0x{0:X8}     {1}",
            //     //                  (int)value, ((<T>)value));
            // } 


            var array = (T[])(System.Enum.GetValues(typeof(T)).Cast<T>());
            var array2 = System.Enum.GetNames(typeof(T)).ToArray<string>();
            List<ListEnumVm> lst = null;
            for (int i = 0; i < array.Length; i++)
            {
                if (lst == null)
                    lst = new List<ListEnumVm>();
                string name = Globals.rman.GetString(array2[i]);
                if (name == null)
                {
                    name = array2[i];
                }
                T value = array[i];
                lst.Add(new ListEnumVm { ID = Convert.ToInt32(value), AD = name });
            }
            return lst;
        }
        
        #endregion
        #region kontrolDuzenle
        public static void LueDsDuzenle(LookUpEdit cbo)
        {
            cbo.Properties.ValueMember = "ID";
            cbo.Properties.DisplayMember = "AD";
            cbo.Properties.NullText = "Seçiniz";
            cbo.Properties.ForceInitialize();
            cbo.Properties.PopulateColumns();
            cbo.EnterMoveNextControl = true;
            cbo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            if (cbo.Properties.Columns.Count > 0)
            {
                cbo.Properties.Columns["ID"].Visible = false;
            }
        } 
        public static void LueEnumDuzenle(LookUpEdit lke)
        {
            lke.Properties.ValueMember = "ID";
            lke.Properties.DisplayMember = "AD";
            lke.Properties.NullText = "Seçiniz";
            lke.Properties.PopulateColumns();
            lke.EnterMoveNextControl = true;
            lke.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            if (lke.Properties.Columns.Count > 0)
            {
                lke.Properties.Columns["ID"].Visible = false;
            }
        }
        public static void LkeSetValue(LookUpEdit lke ,int value)
        {
            lke.EditValue = value;
        }
     
        public static void NumerikDecimalSinirla(List<Control> cntrllist, int dec, int uzunluk)
        {
            foreach (var item in cntrllist)
            {
                DevExpress.XtraEditors.TextEdit txt = item as DevExpress.XtraEditors.TextEdit;
                txt.Properties.Mask.EditMask = "F" + dec;
                txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                txt.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
        }
        public static void NumerikIntegerSinirla(List<Control> cntrllist, int uzunluk)
        {
            foreach (var item in cntrllist)
            {
                DevExpress.XtraEditors.TextEdit txt = item as DevExpress.XtraEditors.TextEdit;
                txt.Properties.Mask.EditMask = "\\d{0," + uzunluk + "}";
                txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            }
        }
        public static void SetGridColumnUlasilamazlik(GridView _view, string column, bool ulasilamaz)
        {
            if (_view.Columns[column] != null)
            {
                _view.Columns[column].OptionsColumn.ReadOnly = ulasilamaz;
                _view.Columns[column].OptionsColumn.AllowEdit = !ulasilamaz;
                _view.Columns[column].OptionsColumn.AllowFocus = !ulasilamaz;
            }
        }
        #endregion
        #region tarihISlemleri
        public static void TarihSetBugun(DateEdit dt)
        {
            dt.EditValue = DateTime.Today;
        }
        public static void TarihSetBugun(TimeEdit dt)
        {
            dt.EditValue = DateTime.Today;
        }
        public static void TarihSetBugunSon(TimeEdit dt)
        {
            dt.EditValue = DateTime.Now;
        }
        public static void TarihSet1900(DateEdit dt)
        {
            dt.EditValue = Convert.ToDateTime("01.01.1900");
        }
        public static void TarihSet2049(DateEdit dt)
        {
            dt.EditValue = Convert.ToDateTime("31.12.2049");
        }
        public static void TarihSet2005(DateEdit dt)
        {
            dt.EditValue = Convert.ToDateTime("01.01.2005");
        }
        public static void TarihSetIlkGun(DateEdit dt)
        {
            dt.EditValue = Convert.ToDateTime("01.01.2012");
        }
        public static void TarihSetYilSonGun(DateEdit dt)
        {
            dt.EditValue = Convert.ToDateTime("31.12.2012");
        }
        public static void TarihSetAySonGun(string ay, DateEdit dt)
        {
            dt.EditValue = DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(ay)) + "." + ay + "." + DateTime.Now.Year.ToString();
        }
        public static void TarihSetAyIlkGun(string ay, DateEdit dt)
        {
            dt.EditValue = "01." + ay + "." + DateTime.Now.Year.ToString();
        }
        public static void TarihSetIlkAy(DateEdit dt)
        {
            dt.EditValue = Convert.ToDateTime("01.01.2012");
        }
        public static void TarihSetBugunAy(DateEdit dt)
        {
            dt.EditValue = Convert.ToDateTime("31.12.2012");
        }
        public static void TarihSetBugunYil(DateEdit dt)
        {
            dt.EditValue = Convert.ToDateTime("31.12.2012");
        }
        public static void DateEditSetMonthYear (DateEdit dt)
        {
            dt.Properties.DisplayFormat.FormatString = "MM/yyyy";
            dt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dt.Properties.Mask.EditMask = "MM/yyyy";
        }
        public static void DateEditSetMonth(DateEdit dt)
        {
            dt.Properties.DisplayFormat.FormatString = "MM";
            dt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dt.Properties.Mask.EditMask = "MM";
        }
        public static void DateEditSetYear(DateEdit dt)
        {
            dt.Properties.DisplayFormat.FormatString = "yyyy";
            dt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dt.Properties.Mask.EditMask = "yyyy";
        }
        #endregion
        #region gridOlustur
        //public static void GruplamaDoldur(GridLookUpEdit lke)
        //{
        //    Dictionary<string, string> a = new Dictionary<string, string>();
        //    a.Add("Seciniz", "Seciniz");
        //    a.Add("PERSONEL_ID", "STOK");
        //    a.Add("ISLEM_TIPI_ID", "İŞLEM TİPİ");
        //    List<StokGrupVm> ListStokGrup = new List<StokGrupVm>();
        //    StokGrupVm k = new StokGrupVm();
        //    k.PERSONEL_GRUP_ID = 0;
        //    StokGrupCntrl cntrl = new StokGrupCntrl();
        //    ListStokGrup = cntrl.Liste_Al(null);
        //    int i = 1;
        //    foreach (StokGrupVm item in ListStokGrup)
        //    {
        //        if (item.PERSONEL_GRUP_ID == 0)
        //        {
        //            a.Add("GRUP" + i + "_ID", item.AD);
        //            i++;
        //        }

        //    }
        //    WinFormsHelper.GridLookUpEditDuzenle(lke, a);
        //}
        public static void Grid_Olustur(string ns, string tn, string an, GridView view, string[] toplamAlanlari, GridOzellikleri ozellikler)
        {
            string[] isimler = new string[1500];
            int isimlerIndex = 0;
            int isimlerEkleme = 0;
            if (ozellikler == null)
            {
                ozellikler = new GridOzellikleri();
                ozellikler.autoWidth = false;
                ozellikler.groupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            }
            else if (ozellikler.groupFooterShowMode == null)
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
                if (tn == "StokListVm")
                {
                    alanAdiEk = "STOKVM.";
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
            if (calledType == null)
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
                    if (tblAtr.Uzunluk != null) format = "n" + tblAtr.Uzunluk.ToString();
                    toplamAlani = tblAtr.toplamAlani;

                }
                catch (Exception)
                {

                }
                Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                Column1.FieldName = alanAdiEk + propertyInfo.Name;
                string columnCaption = IsimAl(alanAdiEk + propertyInfo.Name, ozellikler.dil);
                if (Array.IndexOf(isimler, columnCaption) == -1)
                {
                    isimler[isimlerIndex] = columnCaption; isimlerIndex++; Column1.Caption = columnCaption;
                }
                else
                {
                    Column1.Caption = columnCaption + " " + isimlerEkleme; isimlerEkleme++;
                }
                //Column1.Caption = IsimAl(alanAdiEk + propertyInfo.Name,ozellikler.dil);
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
                    if (format != "")
                    {
                        if (ozellikler.acilmamisSatirlariGosterme == false)
                        {
                            item.ShowInGroupColumnFooter = Column1;
                        }
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
        public static void Grid_Olustur_Tum_Kayitlar(string ns, string tn, string an, GridView view, GridControl gridControl, string[] toplamAlanlari, int CariStokModelEn, GridOzellikleri ozl)
        {
            if (ozl == null)
            {
                ozl = new GridOzellikleri();
                ozl.autoWidth = false;
            }
            if (tn == "ListViewModelListe")
            {
                ns = "Satis.Listeler.StokListeleri.Models";
            }
            Grid_Olustur(ns, tn, an, view, toplamAlanlari, ozl);
            if (CariStokModelEn == (int)ListeEkModelEn.PersonelModelli || CariStokModelEn == (int)ListeEkModelEn.Tum)
            {
                Grid_Olustur("Personel.Listeler.PersonelListeleri.Models", "PersonelListVm", an, view, toplamAlanlari, ozl);
            }
            view.BestFitColumns();
        }
        public static void Gridi_OlusturbyList(List<Alanlar> alanlar, GridView view, GridControl gridControl1, int alanSira, string alanAdiEk, bool gridTemizle)
        {
            Gridi_OlusturbyList(alanlar, view, gridControl1, alanSira, alanAdiEk, gridTemizle, false);
        } // alanadiek dolu ise griddeki alanların basına alanadiEk geliyor
        public static void Gridi_OlusturbyList(List<Alanlar> alanlar, GridView view, GridControl gridControl1, int alanSira, string alanAdiEk, bool gridTemizle, bool autoWidth)
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
            view.OptionsView.ColumnAutoWidth = !autoWidth;

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
                        if (ALAN.M_ALAN_ARAMA_TIP_ID == 2)
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
                        Column1.Caption = IsimAl(alanAdiEk + ALAN.ALAN_AD, (int)Dil.Turkce);
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
                        if (ALAN.ALAN_AD.Length > 9 && ALAN.ALAN_AD.Substring(0, 9) == "PERSONEL_GRUP")
                        {
                            Column1.Caption = ALAN.ALAN_AD;
                            Column1.Name = ALAN.ALAN_AD;
                            int id = 0;
                            if (ALAN.ALAN_AD == "GRUP10_ID")
                            {
                                id = 10;
                            }
                            else
                            {
                                id = Convert.ToInt32(ALAN.ALAN_AD.Substring(9, 1));
                            }
                            bindingSourceArr[intBind].DataSource = ListDenemeService.GetPERSONEL_GRUPLAR_ID(id);
                        }
                        
                        else
                        {
                            mt = "Get" + ALAN.ALAN_AD;
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, 0, "", "", 0);
                        }
                        repositoryItemLookUpEdit1[intBind].NullText = "";
                        repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        repositoryItemLookUpEdit1[intBind].Name = alanAdiEk + ALAN.ALAN_AD;
                        repositoryItemLookUpEdit1[intBind].ValueMember = "ID";


                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);


                        if (ALAN.ALAN_AD == "PERSONEL_ID" || ALAN.ALAN_AD == "CARI_ID") //M_ALANLAR tablosuna arama tipi konulacak
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
        public static void Grid_Olustur_Dinamik(string ns, string tn, string an, GridView view, GridControl gridControl, string[] toplamAlanlari, string[] dinamikAlanlar, string dinamikAltAlan)
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
                    if (Column1.Caption == "" && satirToplam == false)
                    {
                        Column1.Visible = false;
                        Column1.VisibleIndex = -1;
                    }
                    else
                    {
                        if (Column1.Caption == "" && ekAlanlar == 0)
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
                        BindingSource bindingSource = new System.Windows.Forms.BindingSource();
                        RepositoryItemGridLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemGridLookUpEdit();
                        gridControl.RepositoryItems.Add(repositoryItemLookUpEdit1);
                        if (dinamikAltAlan.Length > 9 && dinamikAltAlan.Substring(0, 9) == "PERSONEL_GRUP")
                        {
                            int id = 0;
                            if (dinamikAltAlan == "PERSONEL_GRUP10_ID")
                            {
                                id = 10;
                            }
                            else
                            {
                                id = Convert.ToInt32(dinamikAltAlan.Substring(9, 1));
                            }
                            bindingSource.DataSource = ListDenemeService.GetPERSONEL_GRUPLAR_ID(id);
                        }
                        else if (dinamikAltAlan.Length > 9 && dinamikAltAlan.Substring(0, 9) == "CARI_GRUP")
                        {
                            int id = 0;
                            if (dinamikAltAlan == "CARI_GRUP10_ID")
                            {
                                id = 10;
                            }
                            else
                            {
                                id = Convert.ToInt32(dinamikAltAlan.Substring(9, 1));
                            }
                            bindingSource.DataSource = ListDenemeService.GetPERSONEL_GRUPLAR_ID(id);
                        }
                        else
                        {
                            bindingSource.DataSource = ListService.InvokeMethod("Get" + dinamikAltAlan, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                        }

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
                        if (ALAN.ALAN_AD.Length > 9 && ALAN.ALAN_AD.Substring(0, 9) == "PERSONEL_GRUP")
                        {
                            Column1.Caption = ALAN.ALAN_AD;
                            Column1.Name = ALAN.ALAN_AD;
                            int id = 0;
                            if (ALAN.ALAN_AD == "GRUP10_ID")
                            {
                                id = 10;
                            }
                            else
                            {
                                id = Convert.ToInt32(ALAN.ALAN_AD.Substring(9, 1));
                            }
                            bindingSourceArr[intBind].DataSource = ListDenemeService.GetPERSONEL_GRUPLAR_ID(id);
                        }
                        else
                        {
                            mt = "Get" + ALAN.ALAN_AD;
                            List<IdAdVm> vmList = new List<IdAdVm>();
                            vmList = (List<IdAdVm>)YeniListService.InvokeMethod(mt, 0, ALAN.ID, 0, tabloAd[0]);
                            if (tabloAd[1] != "")
                            {
                                vmList.AddRange((List<IdAdVm>)YeniListService.InvokeMethod(mt, 0, ALAN.ID, 0, tabloAd[1]));
                            }
                            bindingSourceArr[intBind].DataSource = vmList;
                        }

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
                        if (ALAN.ALAN_AD == "PERSONEL_ID" || ALAN.ALAN_AD == "CARI_ID") //M_ALANLAR tablosuna arama tipi konulacak
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
            DevExpress.XtraGrid.Columns.GridColumn Column2 = new DevExpress.XtraGrid.Columns.GridColumn();
            Column2.Caption = "GRUPLANAN ALAN ADI";
            Column2.Name = "KODID";
            BindingSource bindingSource = new System.Windows.Forms.BindingSource();
            RepositoryItemGridLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemGridLookUpEdit();
            gridControl.RepositoryItems.Add(repositoryItemLookUpEdit1);
            if (dinamikAltAlan.Length > 9 && dinamikAltAlan.Substring(0, 9) == "PERSONEL_GRUP")
            {
                int id = 0;
                if (dinamikAltAlan == "PERSONEL_GRUP10_ID")
                {
                    id = 10;
                }
                else
                {
                    id = Convert.ToInt32(dinamikAltAlan.Substring(9, 1));
                }
                bindingSource.DataSource = ListDenemeService.GetPERSONEL_GRUPLAR_ID(id);
            }
            else if (dinamikAltAlan.Length > 9 && dinamikAltAlan.Substring(0, 9) == "CARI_GRUP")
            {
                int id = 0;
                if (dinamikAltAlan == "CARI_GRUP10_ID")
                {
                    id = 10;
                }
                else
                {
                    id = Convert.ToInt32(dinamikAltAlan.Substring(9, 1));
                }
                bindingSource.DataSource = ListDenemeService.GetPERSONEL_GRUPLAR_ID(id);
            }
            else
            {
                bindingSource.DataSource = ListService.InvokeMethod("Get" + dinamikAltAlan, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
            }

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
                    Column2 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            Column2.VisibleIndex = sira + 1;
            view.Columns.Add(Column2);

            Column2 = new DevExpress.XtraGrid.Columns.GridColumn();
            Column2.Caption = "SATIR TOPLAM";
            Column2.FieldName = "SATIR TOPLAM";
            Column2.Visible = true;
            Column2.VisibleIndex = sira + 2;
            view.Columns.Add(Column2);
            Column2 = new DevExpress.XtraGrid.Columns.GridColumn();
            Column2.Caption = "SATIR TOPLAM";
            Column2.FieldName = "SATIR TOPLAM";
            Column2.Visible = true;
            Column2.VisibleIndex = sira + 3;
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
        public static void SonKarakterSil(string s)
        {
            if (s == "")
            {
                s = "";
            }
            else
            {
                s = s.Substring(0, s.Length - 1);
            }
        }
        public static string SonKarakteriSil(string s)
        {
            return s != "" ? s.Substring(0, s.Length - 1) : "";
        }
        public static string IsimAl07022013(string name, int dil)
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
        public static string IsimAl(string name, int dil)
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
                    if (Globals.rmanIng.GetString(a[0]) != null)
                    {
                        temp = Globals.rmanIng.GetString(a[0]);
                    }
                    else if (Globals.rman.GetString(a[0]) != null)
                    {
                        temp = Globals.rman.GetString(a[0]);
                    }
                    else
                    {
                        temp = a[0];
                    }
                    if (Globals.rmanIng.GetString(a[1]) != null)
                    {
                        temp = temp + "-" + Globals.rmanIng.GetString(a[1]);
                    }
                    else if (Globals.rman.GetString(a[1]) != null)
                    {
                        temp = temp + "-" + Globals.rman.GetString(a[1]);
                    }
                    else
                    {
                        temp = temp + "-" + a[1];
                    }
                }
                else
                {
                    if (Globals.rman.GetString(a[0]) != null)
                    {
                        temp = Globals.rman.GetString(a[0]);
                    }
                    else
                    {
                        temp = a[0];
                    }
                    if (Globals.rman.GetString(a[1]) != null)
                    {
                        temp = temp + "-" + Globals.rman.GetString(a[1]);
                    }
                    else
                    {
                        temp = temp + "-" + a[1];
                    }
                }
            }
            else if (a.Length == 3)
            {

                if (dil != (int)Dil.Turkce)
                {
                    if (Globals.rmanIng.GetString(a[0]) != null)
                    {
                        temp = Globals.rmanIng.GetString(a[0]);
                    }
                    else if (Globals.rman.GetString(a[0]) != null)
                    {
                        temp = Globals.rman.GetString(a[0]);
                    }
                    else
                    {
                        temp = a[0];
                    }
                    if (Globals.rmanIng.GetString(a[1]) != null)
                    {
                        temp = temp + "-" + Globals.rmanIng.GetString(a[1]);
                    }
                    else if (Globals.rman.GetString(a[1]) != null)
                    {
                        temp = temp + "-" + Globals.rman.GetString(a[1]);
                    }
                    else
                    {
                        temp = temp + "-" + a[1];
                    }
                    if (Globals.rmanIng.GetString(a[2]) != null)
                    {
                        temp = temp + "-" + Globals.rmanIng.GetString(a[2]);
                    }
                    else if (Globals.rman.GetString(a[2]) != null)
                    {
                        temp = temp + "-" + Globals.rman.GetString(a[2]);
                    }
                    else
                    {
                        temp = temp + "-" + a[2];
                    }
                }
                else
                {
                    if (Globals.rman.GetString(a[0]) != null)
                    {
                        temp = Globals.rman.GetString(a[0]);
                    }
                    else
                    {
                        temp = a[0];
                    }
                    if (Globals.rman.GetString(a[1]) != null)
                    {
                        temp = temp + "-" + Globals.rman.GetString(a[1]);
                    }
                    else
                    {
                        temp = temp + "-" + a[1];
                    }
                    if (Globals.rman.GetString(a[2]) != null)
                    {
                        temp = temp + "-" + Globals.rman.GetString(a[2]);
                    }
                    else
                    {
                        temp = temp + "-" + a[2];
                    }
                }
            }
            return temp != null ? temp : name;
        }
        #endregion
        //// DEGISKEN ISLEMLERI
        #region mesajislemleri
      
        public static bool UyariVer(string p)
        {
            if (p.Trim() != "")
            {
                DialogResult res = MessageBox.Show(p, "PRODMA ERP", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }
        public static void ProgramBeklemeGoster()
        {
            Cursor.Current = Cursors.WaitCursor;
        }
        public static void ProgramBeklemeDurdur()
        {
            Cursor.Current = Cursors.Default;
        }
  
        //public static void BekleyinizUyarisiGoster(SplashScreenForm frm)
        //{
        //  //  splashScreenManager2.ShowWaitForm();
        //    //SplashScreenForm fr = new SplashScreenForm();
        //    frm.Show();
        //    Application.DoEvents();
        //    ProgramBeklemeGoster();
        //}
        //public static void BekleyinizUyarisiDurdur(SplashScreenForm frm)
        //{
        //    frm.Hide();
        //    ProgramBeklemeDurdur();
        //}
        #endregion
    }
    public class ListEnumVm
    {
        public object ID { get; set; }
        public string AD { get; set; }
    }
   

}
