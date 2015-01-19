using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Prodma.DataAccessB2C;

namespace Prodma.WinForms
{
    public partial class ListForm : DevExpress.XtraEditors.XtraForm
    {
        public usrGridIslem grd = new usrGridIslem(GridIslemEn.Bilgilendirme);
        public object a;
        public ListForm()
        {
            InitializeComponent();
            grd.Dock = DockStyle.Fill;
            pivotGridControl1.Visible = false;
            button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BindingSource siparisGozlemVmBindingSource = new BindingSource();
            //siparisGozlemVmBindingSource.DataSource = a;
            //pivotGridControl1.DataSource = grd.gridControl1.DataSource;
            //pivotGridControl1.RetrieveFields();
            //pivotGridControl1.Fields["FIS_MIKTAR"].Visible = false;
            //pivotGridControl1.Fields["BAKIYE_MIKTAR"].Visible = false;
            //pivotGridControl1.Fields["TARIH"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            ////pivotGridControl1.Fields["SIPARIS_MIKTAR"].Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            //pivotGridControl1.Fields["SIPARIS_MIKTAR"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            //pivotGridControl1.Fields["SIPARIS_MIKTAR"].Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            //pivotGridControl1.Dock = DockStyle.Fill;
            ////ListHelper.Grid_Olustur_Tum(ListeOzellikleri.modelPath, ListeOzellikleri.modelName, "Prodma.DataAccess", gridControl.gridView1, gridControl.gridControl1, ListeOzellikleri.toplamAlanlari, parametersForm);

        }
    }
}