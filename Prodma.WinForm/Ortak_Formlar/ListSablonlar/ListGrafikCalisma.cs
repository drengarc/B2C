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
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;
using DevExpress.XtraPivotGrid;
using System.Globalization;
using Prodma.DataAccess;
using DevExpress.XtraCharts;

namespace Prodma.WinForms
{
    public partial class ListGrafikCalisma : Sablon
    {
        string degerAlani = "";
        public int degerId = 0;
        public usrGridIslem grd = new usrGridIslem(GridIslemEn.Bilgilendirme);
        public string FormAdi = "";
        public object a;
        //public List<SiparisGozlemVm> b;
        public ListGrafikCalisma()
        {
            InitializeComponent();
            grd.Dock = DockStyle.None;
            this.saveFilterBtn.Click += new System.EventHandler(this.saveFilter_Click);
            this.filtreLke.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.filtreLke_Closed);
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            
            //ListHelper.Grid_Olustur_Tum(ListeOzellikleri.modelPath, ListeOzellikleri.modelName, "Prodma.DataAccess", gridControl.gridView1, gridControl.gridControl1, ListeOzellikleri.toplamAlanlari, parametersForm);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //pivotGridControl1.BestFitColumnArea();
            //pivotGridControl1.BestFitRowArea();
            //return;
            //Export.ExportToGridControl(pivotGridControl1, "", ".xls", "XLS");
            //pivotGridControl1.OptionsPrint.AutoWidth = false;
            string filepath = System.IO.Path.GetTempFileName();
            filepath = filepath.Remove(filepath.LastIndexOf('.') + 1);
            filepath = String.Concat(filepath, "xlsx");
            chartControl1.ExportToXlsx(filepath);
            System.Diagnostics.ProcessStartInfo startInfo =
                 new System.Diagnostics.ProcessStartInfo("Excel.exe", String.Format("/r \"{0}\"", filepath));
            System.Diagnostics.Process.Start(startInfo);
            //chartControl1.ExportToXls()
        }
        private void saveFilter_Click(object sender, EventArgs e)
        {
            //FiltrelerCntrl cntrl = new FiltrelerCntrl();
            //FiltrelerVm filtreVm = new FiltrelerVm();
            //SiparisListeleriPopUp popUp = new SiparisListeleriPopUp();
            //popUp.filterName = Convert.ToString(filtreLke.GetColumnValue("AD"));
            //popUp.ShowDialog();
            //if (popUp.FilterNametxt.Text.Trim() == "") return;
            //filtreVm.RAPOR_ADI = popUp.FilterNametxt.Text;
            //filtreVm.KULLANICI_ID = Globals.gnKullaniciId;
            //filtreVm.FORM_ADI =FormAdi;
            //List<PivotGridField> fieldList = pivotGridControl1.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea);

            //string layaout = @"C" + "/" + popUp.FilterNametxt.Text;
            //layaout = @"C:" + "/" + popUp.FilterNametxt.Text;
            //pivotGridControl1.SaveLayoutToXml(layaout);
            //filtreVm.DEGER_ALANI = degerAlani + "‡" + "PivotGridDetayCalisma" + "»" + layaout;

            //if (popUp.islem == 2)
            //{
            //    filtreVm.FILTRE_TIP_ID = (int)FiltreTipEn.DetayListeler;
            //    cntrl.Ekle(filtreVm);
            //    //filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(nesne.kullaniciBilgileri.ID, formName);
            //}
            //else if (popUp.islem == 0)
            //{
            //    filtreVm.FILTRE_TIP_ID = (int)FiltreTipEn.DetayListeler;
            //    filtreVm.ID = Convert.ToInt32(filtreLke.EditValue);
            //    cntrl.Guncelle(filtreVm, filtreVm.ID);
            //    //filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(nesne.kullaniciBilgileri.ID, formName);
            //}
            //else if (popUp.islem == 1)
            //{
            //    filtreVm.ID = Convert.ToInt32(filtreLke.EditValue);
            //    cntrl.Sil(filtreVm.ID, filtreVm);
            //    //filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(nesne.kullaniciBilgileri.ID, formName);
            //}
            //filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(Globals.gnKullaniciId, FormAdi, (int)FiltreTipEn.DetayListeler);
            //filtreLke.Properties.ValueMember = "ID";
            //filtreLke.Properties.DisplayMember = "AD";
            //filtreLke.Properties.NullText = "Filtreler";
            //if (filtreLke.Properties.Columns.Count > 0)
            //{
            //    filtreLke.Properties.Columns["ID"].Visible = false;
            //}
        }
        
        private void filtreLke_Closed(object sender, ClosedEventArgs e)
        {
            //string layout = "";
            //string filtreler = Convert.ToString(ListDenemeService.GetFILTRELER_DEGER_ALANI(Convert.ToInt32(filtreLke.EditValue)));
            //if (filtreler != null && filtreler != "")
            //{
            //    string[] selected = ListDenemeService.GetFILTRELER_DEGER_ALANI(Convert.ToInt32(filtreLke.EditValue)).ToString().Split('‡');
            //    foreach (var item in selected)
            //    {
            //        if (item.Trim() != "")
            //        {
            //            string[] a = item.Split('»');
            //            layout = a[1];
            //            try
            //            {
            //                pivotGridControl1.RestoreLayoutFromXml(layout, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            //            }
            //            catch (Exception)
            //            {
                            
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    //PivotGridDoldur();
            //    //GridDuzenle();
            //}
            //pivotGridControl1.BestFit();
        }
        public void GridViewCheckedComboBoxLoad()
        {
            Dictionary<string, string> data1 = new Dictionary<string, string>();
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in this.grd.gridView1.Columns)
            {
                data1.Add(item.FieldName.ToString(), item.Caption.ToString());
            }
            ListHelper.GridLookUpEditDuzenle(DataAlanlarlke, data1);
            ListHelper.GridLookUpEditDuzenle(valuelke, data1);
        }
        private void ListDetayCalisma_Load(object sender, EventArgs e)
        {
            GridViewCheckedComboBoxLoad();
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
 

        void GrafikGoster(string dataMember,string valueMember)
        {
            //ArrayList listDataSource = new ArrayList();

            //// Populate the list with records.
            //listDataSource.Add(new Record(1, "Jane", 19));
            //listDataSource.Add(new Record(2, "Joe", 30));
            //listDataSource.Add(new Record(3, "Bill", 15));
            //listDataSource.Add(new Record(4, "Michael", 42));

            // Bind the chart to the list.
            ChartControl myChart = chartControl1;
            myChart.DataSource = a;

            // Create a series, and add it to the chart.
            Series series1 = new Series(this.Text, ViewType.SplineArea3D);
            myChart.Series.Clear();
            myChart.Series.Add(series1);

            //myChart.
            ///myChart.Size = new System.Drawing.Size()
            // Adjust the series data members.
            series1.ArgumentDataMember = dataMember;
            series1.ValueDataMembers.AddRange(new string[] { valueMember });

            // Access the view-type-specific options of the series.
            //((BarSeriesView)series1.View).ColorEach = true;
            series1.LegendPointOptions.Pattern = "{A}";
        }

        private void GOSTERbtn_Click(object sender, EventArgs e)
        {
            GrafikGoster(DataAlanlarlke.EditValue.ToString(), valuelke.EditValue.ToString());
        }
    }
}