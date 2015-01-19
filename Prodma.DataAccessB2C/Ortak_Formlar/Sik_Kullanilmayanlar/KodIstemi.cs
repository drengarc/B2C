using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Controls;
 
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using System.Reflection;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using Prodma.DataAccessB2C;

namespace Prodma.WinForms
{
	public partial class KodIstemi : Form
	{
		private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
		private DevExpress.XtraEditors.TextEdit [] textEdit1 = new DevExpress.XtraEditors.TextEdit[16];
		public BindingSource[] bindingSourceArr = new BindingSource[16];
		private Label  lblArama;
		public int Id;
		public string method;
		public GridColumn linkColumn;
		private BindingSource bn = new BindingSource(); 
		public KodIstemi()
		{
			InitializeComponent();
		}

		GridCheckMarksSelection selection;
		internal GridCheckMarksSelection Selection
		{
			get
			{
				return selection;
			}
		}
		public event EventHandler ButtonClick;
		private void OnButtonClicked(EventArgs e)
		{
			if (ButtonClick != null)
			{
				ButtonClick(this, e);
			}
		}
		private void TamamBtn_Click(object sender, EventArgs e)
		{
			OnButtonClicked(e);
		}
		public int Value
		{
			get
			{
				return Id;
			}

		}
	   
		private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
		{
			GridControl grid = sender as GridControl;
			GridView view = grid.FocusedView as GridView;
			if (e.KeyCode == Keys.Enter)
			{
				Id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
				OnButtonClicked(e);
				this.Visible = false;
			}
		   
		}

		private void KodIstemi_Activated(object sender, EventArgs e)
		{
			//string mt = "";
			//mt = "Get" + method;// +"(0)"; 
			//bn.DataSource = ListService.InvokeMethod(mt, 0,ALAN.ID,ust_id);
			//this.gridControl1.DataSource = bn;
		}

		private void KodIstemi_Shown(object sender, EventArgs e)
		{
			string mt = "";
			mt = "Get" + method;// +"(0)"; 
			bn.DataSource = ListService.InvokeMethod(mt,(int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"", "",0 );
			this.gridControl1.DataSource = bn;
		}

		private void KodIstemi_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible == true)
			{

				this.gridControl1 = new DevExpress.XtraGrid.GridControl();
				this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
				this.gridControl1.Dock = System.Windows.Forms.DockStyle.Top;
				this.gridControl1.Location = new System.Drawing.Point(0, 0);
				this.gridControl1.MainView = this.gridView1;
				this.gridControl1.Name = "gridControl1";
				this.gridControl1.Size = new System.Drawing.Size(626, 416);
				this.gridControl1.TabIndex = 0;
				this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
			this.gridView1});
				this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
				// 
				// gridView1
				// 
				this.gridView1.GridControl = this.gridControl1;
				this.gridView1.Name = "gridView1";
				this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
				this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseLeave);
				this.gridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseMove);
				this.gridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseMove);

				this.Controls.Add(this.gridControl1);

				string mt = "";
				mt = "Get" + method;// +"(0)"; 
				bn.DataSource = ListService.InvokeMethod(mt,(int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"", "",0 );
				DataRowView drv = bn.Current as DataRowView; 
				//System.Data.DataSet  cdt = (DataSet)bn.DataSource;
				//System.Data.DataTable dt = cdt.Tables[0]; 
				//drv.
				//nm= dt.Columns. 
				this.gridControl1.DataSource = bn;
				GridDuzenle();
 
				//DevExpress.XtraGrid.Columns.GridColumn Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
				//Column1 = gridView1.Columns[0];
				//Column1.Visible = false; 
				//linkColumn = gridView1.Columns[1];

				//repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
				//gridControl1.RepositoryItems.Add(repositoryItemHyperLinkEdit1);
				//repositoryItemHyperLinkEdit1.AutoHeight = false;
				//repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
				//linkColumn.Width = 5;
				//linkColumn.ColumnEdit = repositoryItemHyperLinkEdit1;

			   // FieldInfo fi = typeof(GridColumn).GetField("minWidth", BindingFlags.NonPublic | BindingFlags.Instance);
			   // fi.SetValue(Column1, 0);
			   // Column1.Width = 8;
				
				//gridView1.Columns.ColumnByFieldName("ID").Width = 1;
			}
		}

		private void GridDuzenle()
		{
			int intIndex = 0;
			foreach (Control ChildControls in panel1.Controls)
			{
				ChildControls.Dispose();
			}
			int eskilocation = 0;
			DevExpress.XtraGrid.Columns.GridColumn Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
			for (int i =0; i < gridView1.Columns.Count ; i++)
			{
			  
				Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
				Column1 = gridView1.Columns[i];
				if (i==0)
					{
					  Column1.Visible =false; 
					}
				else if (i == 1)
				{
					//lblArama  = new Label();
					//lblArama.Text = Column1.FieldName + " :";
					//lblArama.Size =  new System.Drawing.Size(Column1.Width, 20);
					//lblArama.Location = new System.Drawing.Point(60, 10);
					panel1.Controls.Add(lblArama);
					textEdit1[intIndex] = new DevExpress.XtraEditors.TextEdit();
					textEdit1[intIndex].Name = Column1.FieldName + " :";
					textEdit1[intIndex].TabIndex = 0;
					//textEdit1[intIndex].Size = new System.Drawing.Size(200, 20);
					textEdit1[intIndex].Location = new System.Drawing.Point(60, 30);
					eskilocation = 110 + Column1.Width;
					panel1.Controls.Add(textEdit1[intIndex]);
					repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
					gridControl1.RepositoryItems.Add(repositoryItemHyperLinkEdit1);
					repositoryItemHyperLinkEdit1.AutoHeight = false;
					repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
					Column1.Width = 5;
					Column1.ColumnEdit = repositoryItemHyperLinkEdit1;
					intIndex += 1;  
				}
				else
				{
					//lblArama = new Label();
					//lblArama.Text = Column1.FieldName + " :";
					//lblArama.Size = new System.Drawing.Size(50, 20);
					//lblArama.Location = new System.Drawing.Point(eskilocation+10, 7);
					panel1.Controls.Add(lblArama);
					textEdit1[intIndex] = new DevExpress.XtraEditors.TextEdit();
					this.textEdit1[intIndex].Name = Column1.FieldName;
				   // this.textEdit1[intIndex].Size = new System.Drawing.Size(Column1.Width, 20);
					this.textEdit1[intIndex].Location = new System.Drawing.Point(60, 30);
					this.panel1.Controls.Add(this.textEdit1[intIndex]);
					eskilocation = 110 + Column1.Width;
					intIndex += 1;  
				}
				
				   
			}

		}

		#region custombutton
		private int hoverRowHandle = GridControl.InvalidRowHandle;

		private void gridView1_Click(object sender, EventArgs e)
			{
				if (hoverRowHandle != GridControl.InvalidRowHandle)
				{
					//MyItem item = gridView1.GetRow(hoverRowHandle) as MyItem;
					//if (item != null)
						MessageBox.Show("Click");
						// Do whatever the "click" action is here
				}
			}

		private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			//if (e.Column.VisibleIndex  == "AD")
			//{
				int width = e.Bounds.Width;
				textEdit1[e.Column.VisibleIndex].Width = width;
				textEdit1[e.Column.VisibleIndex].Size = new System.Drawing.Size(e.Bounds.Width, e.Bounds.Height);
				textEdit1[e.Column.VisibleIndex].TabIndex = 0;
				textEdit1[e.Column.VisibleIndex].Location = new System.Drawing.Point(e.Bounds.Left, textEdit1[e.Column.VisibleIndex].Location.Y);
			//    bool hover = (hoverRowHandle == e.RowHandle);
			//    FontStyle style = hover ? FontStyle.Underline : FontStyle.Regular;
			//    TextFormatFlags formatFlags =
			//        TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
			//        TextFormatFlags.WordEllipsis;
			//    Color foreColor = Color.White; 
			//    //Color foreColor = gridView1.IsRowSelected(e.RowHandle) ?
			//    //    Color.White : (hover ? LinkHover : MyColors.Link);
			//    using (Font font = new Font(gridControl1.Font, style))
			//    {
			//        TextRenderer.DrawText(e.Graphics, "Link Text", font, e.Bounds,
			//            foreColor, formatFlags);
			//    }
			//    e.Handled = true;
		 //  }
		}

		private void gridView1_MouseLeave(object sender, EventArgs e)
		{
			int tempRowHandle = hoverRowHandle;
			hoverRowHandle = GridControl.InvalidRowHandle;
			if (tempRowHandle != GridControl.InvalidRowHandle)
			{
				gridView1.InvalidateRowCell(tempRowHandle, linkColumn);
			}
		}

		private void gridView1_MouseMove(object sender, MouseEventArgs e)
		{
			int tempRowHandle = hoverRowHandle;
			if (tempRowHandle != GridControl.InvalidRowHandle)
			{
				hoverRowHandle = GridControl.InvalidRowHandle;
				gridView1.InvalidateRowCell(tempRowHandle, linkColumn);
			}
			GridHitInfo hitInfo = gridView1.CalcHitInfo(e.Location);
			if (hitInfo.InRowCell && (hitInfo.Column == linkColumn))
			{
				hoverRowHandle = hitInfo.RowHandle;
				gridView1.InvalidateRowCell(hoverRowHandle, linkColumn);
			}

			bool hoverDetail = (hoverRowHandle != GridControl.InvalidRowHandle);
			gridControl1.Cursor = hoverDetail ? Cursors.Hand : Cursors.Default;
		}

		#endregion


	}
}
