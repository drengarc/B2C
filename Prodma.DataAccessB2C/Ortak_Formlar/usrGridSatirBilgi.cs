using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.DataAccessB2C;
namespace Prodma.WinForms
{
    /// <summary>
    /// iki Tablı formlarda birinci gridin satir bilgisini dinamik olarak olusturan user control.
    /// </summary>
    public partial class usrGridSatirBilgi : usrControlSablon
    {
        private DevExpress.XtraEditors.TextEdit[] textEdit1 = new DevExpress.XtraEditors.TextEdit[16];
        private Label[] lbl = new Label[16];
        public usrGridSatirBilgi()
        {
            InitializeComponent();
        }
        public void Dinamik_TextBox_Olustur(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int width = e.Bounds.Width;
            if (e.Column.VisibleIndex>15 || textEdit1[e.Column.VisibleIndex] == null) return;
            textEdit1[e.Column.VisibleIndex].Width = width;
            textEdit1[e.Column.VisibleIndex].Size = new System.Drawing.Size(e.Bounds.Width, 10);
            textEdit1[e.Column.VisibleIndex].TabIndex = 0;
            textEdit1[e.Column.VisibleIndex].Location = new System.Drawing.Point(e.Bounds.Left, textEdit1[e.Column.VisibleIndex].Location.Y);
            lbl[e.Column.VisibleIndex].Width = width;
            lbl[e.Column.VisibleIndex].Size = new System.Drawing.Size(e.Bounds.Width, 10);
            lbl[e.Column.VisibleIndex].TabIndex = 0;
            lbl[e.Column.VisibleIndex].Location = new System.Drawing.Point(e.Bounds.Left, lbl[e.Column.VisibleIndex].Location.Y);
        }
        public void Kart_Bilgi_Duzenle(GridView view)
        {
            int intIndex = 0;
            this.Dock = DockStyle.Fill;
            DevExpress.XtraGrid.Columns.GridColumn Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
            for (int i = 0; i < view.Columns.Count; i++)
            {

                Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                Column1 = view.Columns[i];
                if (i == 0)
                {
                    Column1.Visible = false;
                }
                else
                {

                    lbl[intIndex] = new Label();
                    lbl[intIndex].Font = new System.Drawing.Font("Tahoma", 7.25F);
                    lbl[intIndex].Text = Globals.rman.GetString(Column1.FieldName) + "";
                    lbl[intIndex].TabIndex = 0;
                    lbl[intIndex].Location = new System.Drawing.Point(60, 0);
                    this.Controls.Add(lbl[intIndex]);
                    textEdit1[intIndex] = new DevExpress.XtraEditors.TextEdit();
                    textEdit1[intIndex].Font = new System.Drawing.Font("Tahoma", 7.25F);
                    textEdit1[intIndex].Name = Column1.FieldName + " :";
                    textEdit1[intIndex].TabIndex = 0;
                    textEdit1[intIndex].Location = new System.Drawing.Point(60, 15);
                    this.Controls.Add(textEdit1[intIndex]);
                    intIndex += 1;
                }
            }

        }
        public void Dinamik_Text_Box_Doldur(GridView view)
        {
            int intIndex = 0;
            Object row = view.GetFocusedRow();
            view.GetRowCellValue(view.FocusedRowHandle, "ID");
            DevExpress.XtraGrid.Columns.GridColumn Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
            for (int i = 1; i < view.Columns.Count; i++)
            {
                if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns[i]) != null)
                {
                    textEdit1[i - 1].Text = Convert.ToString(view.GetRowCellDisplayText(view.FocusedRowHandle, view.Columns[i]));
                }
                intIndex += 1;
            }

        }
    }
}
