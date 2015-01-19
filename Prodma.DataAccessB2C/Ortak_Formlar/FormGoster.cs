using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;
using System.Diagnostics;
using Prodma.DataAccessB2C;

namespace Prodma.WinForms
{
    public partial class FormGoster : DevExpress.XtraEditors.XtraForm
    {
      
        public FormGoster()
        {
            InitializeComponent();
        }
        public void Sablon_Activated(object sender, System.EventArgs e)
        {
        }
        public void Sablon_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
          
        }
        public virtual bool KapatKontrol()
        {
            return false;
        }
        public void Isimlendir(Control.ControlCollection Control)
        {
            foreach (Control fc in Control)
            {
                if (fc.GetType() == typeof(System.Windows.Forms.TabControl))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.TabPage))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.UserControl))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.XtraUserControl))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
                {
                    DevExpress.XtraEditors.LabelControl label = fc as DevExpress.XtraEditors.LabelControl;
                    if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(labelName);
                        label.Text = s ?? label.Text;
                    }
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Label))
                {
                    Label label = fc as Label;
                    if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(labelName);
                        label.Text = s ?? label.Text;
                    }
                    
                }
            }
        }
        public virtual void Form_Acilis(object sender, EventArgs e){
        
        }
        private void Sablon_Shown(object sender, EventArgs e)
        {
           // Form_Acilis(sender, e);
        }
        private void Sablon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
        }
    }
}
