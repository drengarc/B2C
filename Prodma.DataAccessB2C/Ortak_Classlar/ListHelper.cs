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
using Prodma.SistemB2C.Controllers;
using Prodma.SistemB2C.Models;
using System.Data.Objects.SqlClient;
using System.Drawing;
namespace Prodma.DataAccessB2C
{
    public class ListHelper
    {
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
           return s!="" ? s.Substring(0, s.Length - 1) : "";
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
                        if (ALAN.ALAN_AD.Length > 9 && ALAN.ALAN_AD.Substring(0, 9) == "STOK_GRUP")
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
                            //bindingSourceArr[intBind].DataSource = ListDenemeService.GetSTOK_GRUPLAR_ID(id);
                        }
                        else if (ALAN.ALAN_AD.Length > 9 && ALAN.ALAN_AD.Substring(0, 9) == "CARI_GRUP")
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
                            //bindingSourceArr[intBind].DataSource = ListDenemeService.GetCARI_GRUPLAR_ID(id);
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
    }
    public class CariListeBilgileri
    {
        public string KOD { get; set; }
        public string AD { get; set; }
        public string CARI_ADRES_AD { get; set; }
        public string FATURA_ADRES_1 { get; set; }
        public string FATURA_ADRES_2 { get; set; }
        public string FATURA_ADRES_3 { get; set; }
        public string VERGI_DAIRE { get; set; }
        public string VERGI_NO { get; set; }
        public string IRSALIYE_ADRES_1 { get; set; }
        public string IRSALIYE_ADRES_2 { get; set; }
        public string IRSALIYE_ADRES_3 { get; set; }
        public string NOT_1 { get; set; }
        public string NOT_2 { get; set; }
        public string FIRMA_SAHIBI { get; set; }
        public string UNVAN { get; set; }
        public string DAHILI { get; set; }
        public string MAIL { get; set; }
        public string WEB { get; set; }

        public string C_FAX { get; set; }
        public string C_TELEFON { get; set; }
        public string C_CEP_TELEFON { get; set; }
        public string C_ACIKLAMA { get; set; }

        public string Y_AD { get; set; }
        public string Y_UNVAN { get; set; }
        public string Y_TELEFON { get; set; }
        public string Y_DAHILI { get; set; }
        public string Y_FAX { get; set; }
        public string Y_MAIL { get; set; }
        public string Y_CEP_TELEFON { get; set; }
        public string Y_DEPARTMAN { get; set; }
        

        public string VALOR_GUN_1 { get; set; }
        public string VALOR_GUN_2 { get; set; }
        public string VALOR_YUZDE_1 { get; set; }
        public string VALOR_YUZDE_2 { get; set; }
        public string FIRMA_ADI { get; set; }
        public string FIRMA_ADRES1 { get; set; }
        public string FIRMA_ADRES2 { get; set; }
        public string FIRMA_ADRES3 { get; set; }
        public string FIRMA_TELEFON { get; set; }
        public string FIRMA_FAX { get; set; }
        public string FIRMA_MAIL { get; set; }
        public string FIRMA_WEB { get; set; }
        public string DOVIZ { get; set; }
        public string CARI_PLASIYER { get; set; }
        public string CARI_BOLGE { get; set; }
        public string CARI_SEKTOR { get; set; }
        public string CARI_PROBLEM_KOD { get; set; }
        public string CARI_ODEME_SEKLI { get; set; }
        public string VARSAYILAN_CARI_PROBLEM_KOD { get; set; }
        public string VARSAYILAN_CARI_PROBLEM_AD { get; set; }
        public string CARI_TESLIM_YERI { get; set; }
        public string CARI_IBAN_NO { get; set; }
        public string CARI_BANKA_NO { get; set; }
        public string CARI_SEKTOR_KOD { get; set; }
        public string CARI_SEKTOR_AD { get; set; }
     	public string VAT { get; set; }
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
