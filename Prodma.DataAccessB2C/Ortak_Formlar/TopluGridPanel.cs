using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using Prodma.DataAccessB2C;

namespace Prodma.WinForms
{
    public partial class TopluGridPanel : DevExpress.XtraEditors.XtraUserControl
    {

        public TopluGridPanel()
        {
            InitializeComponent();
            
        }

        public void SetControlPlaces(TanitimSablon formGrid)
        {

            LabelControl formNameLabel = new LabelControl();
            this.formNamePanel.Controls.Add(formNameLabel);
            formNameLabel.Dock = DockStyle.Fill;
            formNameLabel.Text = formGrid.Text;
            formGrid.gridView1.OptionsView.ColumnAutoWidth = false;
            formGrid.gridControl1.Dock = DockStyle.Fill;
            this.gridPanel.Controls.Add(formGrid.gridControl1);
            this.gridPanel.Controls.Add(formGrid.controlNavigator1);
            formNameLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            formGrid.controlNavigator1.Height = 25;
            formGrid.gridControl1.Height = 160;
            //formGrid.gridControl1.Dock = DockStyle.None;
            formGrid.controlNavigator1.Dock = DockStyle.Bottom;
            List<Alanlar> q = ListDenemeService.GetALANLAR(formGrid.tabloAdi, 1);
            int gridWidth = 0;
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in formGrid.gridView1.Columns)
            {
                var uzunluk = (from uzn in q
                               where uzn.ALAN_AD == column.Name
                               select uzn).FirstOrDefault();
                column.Width = Convert.ToInt32(uzunluk.ALAN_LISTE_GENISLIK) * 7;
                if (column.Width < 70) column.Width = 70;
                gridWidth = gridWidth + column.Width;
            }
            formGrid.gridControl1.Width = gridWidth;
        }


    }
}
