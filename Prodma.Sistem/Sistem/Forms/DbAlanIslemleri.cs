using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccess; using Prodma.WinForms;
using System.Globalization;
using System.Data.OleDb;
using System.Reflection;
using DevExpress.XtraEditors.Controls;
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;
using System.Data.SqlClient;
namespace Prodma.Sistem
{
    public partial class DbAlanIslemleri :Sablon
    {
        private string dosyaYolu;
        private Dictionary<string, int> m_alanlar;
        DataSet ds;
        DataRow dr;
        private string tableName;
        private Dictionary<string, string> properties;
        private Dictionary<string, string> fieldTypes;
        private Dictionary<string, string> chechStates;
        private Dictionary<string, string> alanTips;
        private OleDbConnection con;
        private usrGridIslem gridIslem;
        List<ExcelAktarmaRowVm> rowList = new List<ExcelAktarmaRowVm>();
        public DbAlanIslemleri()
        {
            InitializeComponent();
            this.Text = "Excel Bilgi Taşıma";
           // this.AlanAdi.Enabled = false;
            m_alanlar = new Dictionary<string, int>();
            properties = new Dictionary<string, string>();
            fieldTypes = new Dictionary<string, string>();
            chechStates = new Dictionary<string, string>();
            alanTips = new Dictionary<string, string>();
            usrGridBilgilendirme frm = new usrGridBilgilendirme();
            
            //tableNameComboBox.Properties.Items.Add("DECIMAL");
            //tableNameComboBox.Properties.Items.Add("VARCHAR");
            //tableNameComboBox.Properties.Items.Add("INT");
            //tableNameComboBox.EditValue = "STOK";

            //NullIcerirMi.Properties.Items.Add("EVET");
            //NullIcerirMi.Properties.Items.Add("HAYIR");
            tableNameComboBox.EditValue = "EVET";
        }
      
        private void okBtn_Click_1(object sender, EventArgs e)
        {
            //string dataTip="";
            //if (tableNameComboBox.Text == "DECIMAL")
            //{
            //    dataTip = "decimal(18,5)";
            //}
            //else if (tableNameComboBox.Text == "VARCHAR")
            //{
            //    dataTip = "Varchar(20)";
            //}
            //if (tableNameComboBox.Text == "INT")
            //{
            //    dataTip = "int(18,5)";
            //}
            string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = String.Format(strCon, ".", "sa", "bgssup", "TIC0112");
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "ALTER TABLE " + tabloAdi.Text + " Add " + AlanAdi.Text + " " + tableNameComboBox.Text + " " + NullIcerirMi.Text;
            cmd.ExecuteNonQuery();
            
            AlanlarCntrl cntrl = new AlanlarCntrl();
            List<AlanlarVm> list = cntrl.Liste_Al(null);

            var sonuc = list.Find(f => f.ALAN_AD == tabloAdi.Text && f.M_ALANLAR_ID == 0);
            int m_AlanlarId = sonuc.ID;

            var sonuc2 = list.FindAll(f => f.ID > 10000 && f.ID < 20000).OrderByDescending(o => o.ID).FirstOrDefault();
            int id = sonuc2.ID+1;
            string alanlarUpdate = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK," ;
            alanlarUpdate += "ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,";
            alanlarUpdate += "M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(";
            alanlarUpdate += Convert.ToString(id) + "," + m_AlanlarId  + ",'" + AlanAdi.Text + "','',0,";
            alanlarUpdate += "'','',0,1,2,";
            alanlarUpdate += "1,0,1,1)"; 
            
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = alanlarUpdate;
            cmd.ExecuteNonQuery();
        }
    }
}
