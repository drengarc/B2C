using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.SistemB2C.Models;
using Prodma.DataAccessB2C;
namespace Prodma.WinForms
{
    /// <summary>
    /// Form Stok Çıkışında Sipariş Bakiyesi Var Mı Diye Bakıyor.
    /// </summary>

    public partial class usrGridBilgilendirme : Sablon
    {
        private DevExpress.XtraGrid.Columns.GridColumn Column1;
        private System.Windows.Forms.BindingSource bindingSource1;
        public int stokId = 0;
        public int cariId = 0;
        public object listObject = null;
        public List<string> alanlist = new List<string>();
        public List<Alanlar> alanlarlist = new List<Alanlar>();
        public usrGridBilgilendirme()
        {
            InitializeComponent();
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
        }
        public virtual void ProcessGridKey(GridView view, KeyEventArgs args, int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn) { }
        public void Gridi_Olustur(List<string> alanlist)
        {
            gridView1.OptionsBehavior.Editable = false;
            foreach (var item in alanlist)
            {
                string[] _st = item.Split(',');

                if (_st.Length == 1)
                {
                    Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                    Column1.FieldName = item;
                    Column1.Visible = true;
                    Column1.VisibleIndex = 1;
                    this.gridView1.Columns.Add(Column1);
                }
                else
                {
                    Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                    Column1.FieldName = _st[0];
                    Column1.Visible = Convert.ToBoolean(_st[1]);
                    if (Column1.Visible == true)
                    {
                        Column1.VisibleIndex = 1;
                    }
                    this.gridView1.Columns.Add(Column1);
                }

            }
        }
        private void usrGridBilgilendirme_Load(object sender, EventArgs e)
        {
            if (alanlarlist.Count > 0)
            {
                YardimciIslemlerKontrols.Gridi_OlusturbyList(alanlarlist, gridView1, gridControl1);
            }
            else
            {
                Gridi_Olustur(alanlist);
            }
            
            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = listObject;
            gridControl1.DataSource = bindingSource1;
        }
        private void usrGridBilgilendirme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close(); 
            }
        }
        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
            ProcessGridKey(gridView1, e, gridView1.FocusedRowHandle, gridView1.FocusedColumn);
        }
 
        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            ControlNavigator navigator = (ControlNavigator)sender;
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                gridControl1.ShowPrintPreview();
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {

        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

        }
        
    }
}