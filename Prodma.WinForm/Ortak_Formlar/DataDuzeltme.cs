using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlisSatis.Fis.Services;
using Prodma.DataAccess;
using System.Threading;
using AlisSatis.Fis.Models;
using System.Data.SqlClient;
using System.Data.EntityClient;
using Satis.StokAmbar.Controllers;
using Satis.StokAmbar.Models;
namespace Prodma.WinForms
{
    public partial class DataDuzeltme : Islemler
    {
        public DataDuzeltme()
        {
            InitializeComponent();
            this.Text = Globals.rman.GetString("TopluIrsaliyeSilmefrm"); //"Toplu İrsaliye Silme";
            YardimciIslemlerKontrols.TarihSet1900(TARIHdtbas);
            YardimciIslemlerKontrols.TarihSet2049(TARIHdtbit);
        }
        private void TopluIrsaliyeSilme_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, null, true);
       
        }
        public override void Doldur()
        {
             
        }
        public override void Tamam()
        {
            if (sorguBitti == false)
            {
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                Toplu_Irsaliye_Silme();
            }
            sorguBitti = true;
        }
  
        void Toplu_Irsaliye_Silme()
        {
               StokDuzelt();
               MessageBox.Show("İşlem Tamamlandı");
        }
        public void StokDuzelt()
        {
            Dictionary<string, string> parametersForm = new Dictionary<string, string>();
            DateTime ilkTarih = Convert.ToDateTime(TARIHdtbas.EditValue);
            DateTime sonTarih = Convert.ToDateTime(TARIHdtbit.EditValue);
            List<LogDetayVm> listGozlemDetay = OrtakIslemlerService.GetLogDetay(ilkTarih, sonTarih);
            List<IdAdVm> list = (from k in listGozlemDetay
                        where k.TABLO == "STOK"
                        select new IdAdVm { ID= k.AYR}).ToList();
            List<StokVm> listStok = new List<StokVm>();
            string strIdler = YardimciIslemler.ListiVirguleGoreAyir(list);
            parametersForm.Add("ID", strIdler);            
            listStok = StokBilgiService.StokList(parametersForm);
            string server = Globals.server;
            string kaynakServer = getConnecTionString();
            foreach (var item in listStok)
            {
                Globals.server = kaynakServer;
                StokCntrl cntrlEski = new StokCntrl();
                List<StokVm> vmEski = cntrlEski.Liste_Al(new StokVm { ID = item.ID });
                StokCntrl cntrlYeni = new StokCntrl();
                //StokVm vmYeni = cntrlYeni.Liste_Al(new StokVm { ID = 1 })[0];
                if (vmEski != null && vmEski.Count != 0)
                {
                    Globals.server = server;
                    item.BIRIM_IC_ID = vmEski[0].BIRIM_IC_ID;
                    cntrlYeni.Guncelle(item, item.ID);
                }
                
            }

        }
       
        public string getConnecTionString()
        {
         
            string providerName = "System.Data.SqlClient";
            string serverName = ".";
            //            string databaseName = Dbtxt.Text.Trim();
            string databaseName = "TIC0112SON";

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            //sqlBuilder.IntegratedSecurity = true;
            sqlBuilder.PersistSecurityInfo = false;
            sqlBuilder.UserID = "sa";
            sqlBuilder.Password = "bgssup";

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/ProdmaModel.csdl|
                            res://*/ProdmaModel.ssdl|
                            res://*/ProdmaModel.msl";
            return entityBuilder.ToString();

        }
    }
}
