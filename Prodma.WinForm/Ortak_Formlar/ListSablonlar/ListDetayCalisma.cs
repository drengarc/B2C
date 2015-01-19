using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Controls;
using Prodma.SistemB2C.Controllers;
using Prodma.SistemB2C.Models;
using DevExpress.XtraPivotGrid;
using System.Globalization;
using Prodma.DataAccessB2C;
namespace Prodma.WinForms
{
    public partial class ListDetayCalisma : Sablon
    {
        string degerAlani = "";
        public int degerId = 0;
        public usrGridIslem grd = new usrGridIslem(GridIslemEn.Bilgilendirme);
        public string FormAdi = "";
        public object a;
      //  public List<SiparisGozlemVm> b;
        public ListDetayCalisma()
        {
            InitializeComponent();
            grd.Dock = DockStyle.None;
            this.saveFilterBtn.Click += new System.EventHandler(this.saveFilter_Click);
            this.filtreLke.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.filtreLke_Closed);
        }

        public void PivotGridDoldur()
        {
            BindingSource siparisGozlemVmBindingSource = new BindingSource();
            pivotGridControl1.Fields.Clear();
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in grd.gridView1.Columns)
            {
                pivotGridControl1.Fields.Add(item.FieldName, PivotArea.FilterArea);
            }
            siparisGozlemVmBindingSource.DataSource = a;
            pivotGridControl1.DataSource = siparisGozlemVmBindingSource;
            pivotGridControl1.RetrieveFields();
            GridDuzenle();
          
            filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(Globals.gnKullaniciId, FormAdi, (int)FiltreTipEn.DetayListeler);
            filtreLke.Properties.ValueMember = "ID";
            filtreLke.Properties.DisplayMember = "AD";
            filtreLke.Properties.NullText = "Filtreler";
            if (filtreLke.Properties.Columns.Count > 0)
            {
                filtreLke.Properties.Columns["ID"].Visible = false;
            }
            filtreLke.EditValue = degerId;

            pivotGridControl1.BestFit();

            //pivotGridControl1.Fields["FIS_MIKTAR"].Visible = false;
            //pivotGridControl1.Fields["BAKIYE_MIKTAR"].Visible = false;
            //pivotGridControl1.Fields["TARIH"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            ////pivotGridControl1.Fields["SIPARIS_MIKTAR"].Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            //pivotGridControl1.Fields["SIPARIS_MIKTAR"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            //pivotGridControl1.Fields["SIPARIS_MIKTAR"].Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            //pivotGridControl1.Dock = DockStyle.Fill;
        }
        public void GridDuzenle()
        {
            foreach (DevExpress.XtraPivotGrid.PivotGridField item in pivotGridControl1.Fields)
            {
               item.Visible = false;
            }
            if (Convert.ToBoolean(checkEdit1.EditValue) == true)
            {
                pivotGridControl1.OptionsView.ShowGrandTotalsForSingleValues = false;
                pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
                pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
            }
            else
            {
                pivotGridControl1.OptionsView.ShowGrandTotalsForSingleValues = true;
                pivotGridControl1.OptionsView.ShowColumnGrandTotals = true;
                pivotGridControl1.OptionsView.ShowRowGrandTotals = true;
            }
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in grd.gridView1.Columns)
            {
                if (pivotGridControl1.Fields[item.FieldName]!=null)
                {
                    pivotGridControl1.Fields[item.FieldName].Visible = item.Visible;
                    pivotGridControl1.Fields[item.FieldName].Caption = item.Caption;
                    if (item.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.Sum)
                    {
                        pivotGridControl1.Fields[item.FieldName].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
                        pivotGridControl1.Fields[item.FieldName].Options.ShowGrandTotal = false;
                    }
                    else
                    {
                        pivotGridControl1.Fields[item.FieldName].TotalCellFormat.FormatType = item.DisplayFormat.FormatType;
                        pivotGridControl1.Fields[item.FieldName].TotalCellFormat.FormatString = item.DisplayFormat.FormatString;
                        pivotGridControl1.Fields[item.FieldName].Options.ShowGrandTotal = true;
                    }
                    pivotGridControl1.Fields[item.FieldName].CellFormat.FormatType = item.DisplayFormat.FormatType;
                    pivotGridControl1.Fields[item.FieldName].CellFormat.FormatString = item.DisplayFormat.FormatString;
                }
              
                //if (item.ColumnType == typeof(System.String))
                //{
                //    pivotGridControl1.Fields[item.FieldName].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
                //    pivotGridControl1.Fields[item.FieldName].Options.ShowGrandTotal = false;
                //}
                //else if (item.ColumnType == typeof(System.Nullable))
                //{
                //    //pivotGridControl1.Fields[item.FieldName].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
                //    pivotGridControl1.Fields[item.FieldName].TotalCellFormat.FormatType = item.DisplayFormat.FormatType;
                //    pivotGridControl1.Fields[item.FieldName].TotalCellFormat.FormatString = item.DisplayFormat.FormatString;
                //}
                //else
                //{
                //    pivotGridControl1.Fields[item.FieldName].TotalCellFormat.FormatType = item.DisplayFormat.FormatType;
                //    pivotGridControl1.Fields[item.FieldName].TotalCellFormat.FormatString = item.DisplayFormat.FormatString;
                //}

                //if (pivotGridControl1.Fields[item.FieldName].Area == PivotArea.DataArea)
                //{
           
                //}
                //pivotGridControl1.Fields[item.FieldName].TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //pivotGridControl1.Fields[item.FieldName].TotalValueFormat.FormatString = "n2";
                //pivotGridControl1.Fields[item.FieldName].ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //pivotGridControl1.Fields[item.FieldName].ValueFormat.FormatString = "n2";
           
                ////pivotGridControl1.Fields[item.FieldName].CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                ////pivotGridControl1.Fields[item.FieldName].CellFormat.FormatString = "n2";

                //pivotGridControl1.Fields[item.FieldName].GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                //pivotGridControl1.Fields[item.FieldName].GrandTotalCellFormat.FormatString = "{0:D2}";
                //pivotGridControl1.Fields[item.FieldName].GrandTotalCellFormat.FormatString = "n2";
                //NumberFormatInfo temp = new NumberFormatInfo();
                //temp.CurrencySymbol = "Rs";
                //pivotGridControl1.Fields[item.FieldName].CellFormat.Format = temp;
                //temp.NumberGroupSeparator = ",";
                //pivotGridControl1.Fields[item.FieldName].CellFormat.FormatString = "c";
            }
            //pivotGridControl1.Fields["GRUP_SECIM"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            //ListHelper.Grid_Olustur_Tum(ListeOzellikleri.modelPath, ListeOzellikleri.modelName, "Prodma.DataAccess", gridControl.gridView1, gridControl.gridControl1, ListeOzellikleri.toplamAlanlari, parametersForm);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Export.ExportToGridControl(pivotGridControl1, "", ".xls", "XLS");
            pivotGridControl1.BestFit();

            grd.gridView1.OptionsPrint.AutoWidth = false;            
            string filepath = System.IO.Path.GetTempFileName();
            filepath = filepath.Remove(filepath.LastIndexOf('.') + 1);
            filepath = String.Concat(filepath, "xlsx");

            pivotGridControl1.ExportToXlsx(filepath);            
            System.Diagnostics.ProcessStartInfo startInfo =
                 new System.Diagnostics.ProcessStartInfo("Excel.exe", String.Format("/r \"{0}\"", filepath));
            System.Diagnostics.Process.Start(startInfo);
        }
        private void saveFilter_Click(object sender, EventArgs e)
        {
            FiltrelerCntrl cntrl = new FiltrelerCntrl();
            FiltrelerVm filtreVm = new FiltrelerVm();
            SiparisListeleriPopUp popUp = new SiparisListeleriPopUp();
            popUp.filterName = Convert.ToString(filtreLke.GetColumnValue("AD"));
            popUp.ShowDialog();
            if (popUp.FilterNametxt.Text.Trim() == "") return;
            filtreVm.RAPOR_ADI = popUp.FilterNametxt.Text;
            filtreVm.KULLANICI_ID = Globals.gnKullaniciId;
            filtreVm.FORM_ADI =FormAdi;
            List<PivotGridField> fieldList = pivotGridControl1.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea);

            string layaout = @"C:/" + popUp.FilterNametxt.Text;
            pivotGridControl1.SaveLayoutToXml(layaout);
            filtreVm.DEGER_ALANI = degerAlani + "‡" + "PivotGridDetayCalisma" + "»" + layaout;

            if (popUp.islem == 2)
            {
                filtreVm.FILTRE_TIP_ID = (int)FiltreTipEn.DetayListeler;
                cntrl.Ekle(filtreVm);
                //filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(nesne.kullaniciBilgileri.ID, formName);
            }
            else if (popUp.islem == 0)
            {
                filtreVm.FILTRE_TIP_ID = (int)FiltreTipEn.DetayListeler;
                filtreVm.ID = Convert.ToInt32(filtreLke.EditValue);
                cntrl.Guncelle(filtreVm, filtreVm.ID);
                //filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(nesne.kullaniciBilgileri.ID, formName);
            }
            else if (popUp.islem == 1)
            {
                filtreVm.ID = Convert.ToInt32(filtreLke.EditValue);
                cntrl.Sil(filtreVm.ID, filtreVm);
                //filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(nesne.kullaniciBilgileri.ID, formName);
            }
            filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(Globals.gnKullaniciId, FormAdi, (int)FiltreTipEn.DetayListeler);
            filtreLke.Properties.ValueMember = "ID";
            filtreLke.Properties.DisplayMember = "AD";
            filtreLke.Properties.NullText = "Filtreler";
            if (filtreLke.Properties.Columns.Count > 0)
            {
                filtreLke.Properties.Columns["ID"].Visible = false;
            }
        }
        private PivotArea GetOtherArea(PivotFieldValueEventArgs e)
        {
            return e.IsColumn ? PivotArea.RowArea : PivotArea.ColumnArea;
        }
        private void filtreLke_Closed(object sender, ClosedEventArgs e)
        {
            string layout = "";
            string filtreler = Convert.ToString(ListDenemeService.GetFILTRELER_DEGER_ALANI(Convert.ToInt32(filtreLke.EditValue)));
            if (filtreler != null && filtreler != "")
            {
                string[] selected = ListDenemeService.GetFILTRELER_DEGER_ALANI(Convert.ToInt32(filtreLke.EditValue)).ToString().Split('‡');
                foreach (var item in selected)
                {
                    if (item.Trim() != "")
                    {
                        string[] a = item.Split('»');
                        layout = a[1];
                        try
                        {
                            pivotGridControl1.RestoreLayoutFromXml(layout, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                            foreach (DevExpress.XtraGrid.Columns.GridColumn item1 in grd.gridView1.Columns)
                            {
                                if (pivotGridControl1.Fields[item1.FieldName] != null)
                                {
                                    pivotGridControl1.Fields[item1.FieldName].Caption = item1.Caption;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            
                        }
                    }
                }
            }
            else
            {
                PivotGridDoldur();
                GridDuzenle();
            }
            pivotGridControl1.BestFit();
        }

        private void ListDetayCalisma_Load(object sender, EventArgs e)
        {
            string layout = "";
            //if (degerId == 0) return;
            //    string[] selected = ListDenemeService.GetFILTRELER_DEGER_ALANI(degerId).ToString().Split('‡');

            //    foreach (var item in selected)
            //    {
            //        if (item.Trim() != "")
            //        {
            //            string[] a = item.Split('»');
            //            layout = a[1];
            //            pivotGridControl1.RestoreLayoutFromXml(layout, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            //            //pivotGridControl1.RetrieveFields();
            //            //GridDuzenle();
            //        }
                //}
            //GridDuzenle();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            GridDuzenle();
        }
    }
}