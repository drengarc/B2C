using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Prodma.DataAccessB2C;
using Prodma.WinForms;
namespace Listeler.UserControlStok
{
    public partial class usrStokGenel : usrControlSablon
    {
        public usrStokGenel()
        {
            InitializeComponent();
            listeBicimTip = (int)UserControlTipEn.Liste;
            YardimciIslemlerKontrols.InvokeChlSet("product_id", STOK_IDglebas);
            YardimciIslemlerKontrols.InvokeChlSet("manufacturer_id", manufacturer_idchl);
        }
        public override void Doldur()
        {
      
        }
        public void ParametreUsrSet()
        {
            parametersUsr.Clear();
            parametersUsr.Add("id", Convert.ToString(STOK_IDglebas.EditValue));
            parametersUsr.Add("manufacturer_id", Convert.ToString(manufacturer_idchl.EditValue));
        }

        private void STOK_IDglebit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
           //     STOK_IDglebit.EditValue = STOK_IDglebas.EditValue;
            }
        }

        private void usrStokGenel_Load(object sender, EventArgs e)
        {
            this.Control_Ayarla_Kayit(this.Controls, null, STOK_IDglebas, null, false);
        }

    }
}
