using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccessB2C;
using System.Globalization;
using Prodma.SistemB2C.Controllers;
using Prodma.SistemB2C.Models;
namespace Prodma.WinForms
{
    public partial class IslemNeden : Islemler
    {
        public IslemNeden()
        {
            InitializeComponent();
            this.Text = Globals.rman.GetString("IslemNedenfrm");
            IslemNedenleriCntrl cntrl = new IslemNedenleriCntrl();
            object a = cntrl.Liste_Al(new IslemNedenleriVm { ISLEM_NEDENLERI_TIP_ID = 2 });
            YardimciIslemlerKontrols.InvokeLueContainSet(a, ISLEM_NEDENLERIlke);
            this.TAMAM_1cmd.Click += new System.EventHandler(this.button1_Click);
            //this.TAMAM_1cmd.Enter += new System.EventHandler(this.TAMAMcmd_Enter);
            this.TAMAM_1cmd.Focus();
            this.IPTAL_1btn.Visible = false;

        }
        public event EventHandler ButtonClick;
        private void OnButtonClicked(EventArgs e)
        {
                if (ButtonClick != null)
                {
                    ButtonClick(this, e);
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _iptalNeden = Convert.ToInt32(ISLEM_NEDENLERIlke.EditValue);
             OnButtonClicked(e);
             this.Close();  
        }

        public DateTime? _fisTarih;
        int _iptalNeden;
        public int iptalNeden
        {
            get { return _iptalNeden; }
            set { _iptalNeden = value; }
        }
       
        private void FisKurGiris_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, null, ISLEM_NEDENLERIlke, false);
            ISLEM_NEDENLERIlke.EditValue = (int)IslemNedeniEn.DigerSebeplerden;
            this.panelTamam.Focus();
            this.ISLEM_NEDENLERIlke.Focus();
        }

        
    }
}
