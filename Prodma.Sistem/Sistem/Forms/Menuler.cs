using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccessB2C; using Prodma.WinForms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Prodma.SistemB2C.Models;
using Prodma.SistemB2C.Controllers;

namespace Prodma.Sistem.Forms
{
    public partial class Menuler : TanitimSablon
    {
        #region degiskenler
        private MenulerCntrl kulcntrl = new MenulerCntrl();
        #endregion
        #region Constructors
        public Menuler()
        {
            escapeKapatma = true;
            InitializeComponent();
            tabloAdi = "M_MENU";
            this.Text = Gridi_Olustur();   
            Tab_Gizle_Ekle();
            //Doldur();
            
        }
        private void Tab_Gizle_Ekle()
        {

            tabPage1.Text = "Menü Bilgi Giriş";
            tabPage2.Text = "Ek Bilgiler";

            this.tabControl1.TabPages.Remove(tabPage2);
            controlNavigator2.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage3);
            //controlNavigator3.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage4);
            controlNavigator4.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage5);
            //controlNavigator5.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage6);
            //controlNavigator6.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage7);
            //controlNavigator7.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage8);
            //controlNavigator8.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage9);
            //controlNavigator9.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage10);
            //controlNavigator10.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage11);
            //controlNavigator11.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage12);
            //controlNavigator12.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage13);
            //controlNavigator13.NavigatableControl = base.gridControl1;



        }
        public override void Doldur()
        {
           MenulerVm k = new MenulerVm();  
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(null);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
          
        }
  
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            
            MenulerVm k = (MenulerVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            MenulerVm k = (MenulerVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            //soktfisEkle();
            ////return;
            alanlaridoldur();
            MessageBox.Show("İşlem Tamamlandı");
           // alanlariUpdate();
             return;
            MenulerVm k = (MenulerVm)ModelVm;
            kulcntrl.Sil(k.ID, k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yazdir()
        {
          //  alanlaridoldur(); 
            gridControl1.ShowPrintPreview();
        }
        public override void Bul()
        {
          //  alanlaridoldur(); 
        }
        public override void Vazgec()
        { 
        }
      
        #endregion

        private void alanlaridoldur()
        {
      //      return;
            int id = 1;
            int ust_id=1;
            int alan_sira = 0;
            string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = String.Format(strCon, ".", "sa", "bgssup", "PRODMA_HR");
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_tables", cn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter recordAdp = new SqlDataAdapter();
            recordAdp.SelectCommand = cmd;
            DataSet recordSet = new DataSet();
            DataRow dr;
            DataRow drcolumn;
            recordAdp.Fill(recordSet);
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from M_ALANLAR";
            cmd.ExecuteNonQuery();
            ust_id = 1;
            alan_sira = 0;
            int alan_tip = 1;
            for (int i = 0; i < recordSet.Tables[0].Rows.Count - 1; i++)
            {
                //dr = DataRow();
                dr = recordSet.Tables[0].Rows[i];
                if (dr["TABLE_OWNER"].Equals("dbo")==true)
                {
                    
                    cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + ",0,'" + dr["TABLE_NAME"] + "','',0,'','',0,1,2,1,0,1,1)";
                    cmd.ExecuteNonQuery();
                    ust_id = id;
                    id += 1;
                    cmd = new SqlCommand("sp_columns", cn);
                    recordAdp = new SqlDataAdapter();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@table_name", SqlDbType.NVarChar).Value = dr["TABLE_NAME"];
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    string tablo_adi;
                    tablo_adi = (string)dr["TABLE_NAME"];
                    if (tablo_adi == "STOK_AYRI_MALIYET")
                    {
                        //MessageBox.Show("ddd");
                    }
                    alan_sira = 1;
                    for (int j = 0; j < ds.Tables[0].Rows.Count ; j++)
                    {
                        drcolumn = ds.Tables[0].Rows[j];
                        string Ad = Convert.ToString(drcolumn["COLUMN_NAME"]);
                        string scale = Convert.ToString(drcolumn["SCALE"]);
                        //string scale = Convert.ToString(drcolumn["SCALE"]);
                        //string scale = Convert.ToString(drcolumn["SCALE"]); 
                        alan_tip = 1;
                        if (Regex.IsMatch(Ad, "_ID") == true && Ad!="ID")//fis sıfırlı isleri tamsayı yap
                        {
                            alan_tip = 2;
                        }
                        else if (Regex.IsMatch(Ad, "_E_H") == true)
                        {
                            alan_tip = 8;
                        }
                        else if (Regex.IsMatch(Ad, "TARIH") == true)
                        {
                            alan_tip = 3;
                        }
                        else if (scale == "")
                        {
                            alan_tip = 1;
                        }
                        else if (Convert.ToInt16(scale) == 0)
                        {
                            alan_tip = 5;
                        }
                        else if (Convert.ToInt16(scale) > 0)
                        {
                            alan_tip = 4;
                        }

                        cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        if (tablo_adi == "M_ALANLAR" && (Ad == "KULLANICI_ID" || Ad == "M_ALAN_KOPYALAMA_E_H"))
                        {
                            cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_PRECISION,ALAN_NULL_ICERIR,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + "," + ust_id + ",'" + drcolumn["COLUMN_NAME"] + "','" + drcolumn["COLUMN_NAME"] + "',5,'" + drcolumn["LENGTH"] + "','" + drcolumn["SCALE"] + "','" + drcolumn["PRECISION"] + "','" + drcolumn["NULLABLE"] + "'," + alan_sira + "," + alan_tip + ",2,1,0,1,1)";
                            cmd.ExecuteNonQuery();
                        }
                        else if (tablo_adi == "YETKI_ALANLAR" && Ad == "M_ALANLAR_ID")
                        {
                            cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_PRECISION,ALAN_NULL_ICERIR,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + "," + ust_id + ",'" + drcolumn["COLUMN_NAME"] + "','" + drcolumn["COLUMN_NAME"] + "',5,'" + drcolumn["LENGTH"] + "','" + drcolumn["SCALE"] + "','" + drcolumn["PRECISION"] + "','" + drcolumn["NULLABLE"] + "'," + alan_sira + "," + alan_tip + ",1,1,0,1,1)";
                            cmd.ExecuteNonQuery();
                            id += 1;
                            cmd = new SqlCommand();
                            cmd.Connection = cn;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_PRECISION,ALAN_NULL_ICERIR,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + "," + ust_id + ",'M_ALANLAR_UST_ID','M_ALANLAR_UST_ID',5,'" + drcolumn["LENGTH"] + "','" + drcolumn["SCALE"] + "','" + drcolumn["PRECISION"] + "','" + drcolumn["NULLABLE"] + "'," + alan_sira + "," + alan_tip + ",1,1,0,1,1)";
                            cmd.ExecuteNonQuery();
                            //id += 1;
                            //cmd = new SqlCommand();
                            //cmd.Connection = cn;
                            //cmd.CommandType = CommandType.Text;
                            //cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_PRECISION,ALAN_NULL_ICERIR,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + "," + ust_id + ",'M_ALANLAR_ID','M_ALANLAR_ID',5,'" + drcolumn["LENGTH"] + "','" + drcolumn["SCALE"] + "','" + drcolumn["PRECISION"] + "','" + drcolumn["NULLABLE"] + "'," + alan_sira + "," + alan_tip + ",1,1,0,1,1)";
                            //cmd.ExecuteNonQuery();
                        }
                        else if (tablo_adi == "KULLANICI")
                        {
                            if (j < 10)
                            {
                                cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_PRECISION,ALAN_NULL_ICERIR,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + "," + ust_id + ",'" + drcolumn["COLUMN_NAME"] + "','" + drcolumn["COLUMN_NAME"] + "',5,'" + drcolumn["LENGTH"] + "','" + drcolumn["SCALE"] + "','" + drcolumn["PRECISION"] + "','" + drcolumn["NULLABLE"] + "'," + alan_sira + "," + alan_tip + ",1,1,0,1,1)";
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_PRECISION,ALAN_NULL_ICERIR,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + "," + ust_id + ",'" + drcolumn["COLUMN_NAME"] + "','" + drcolumn["COLUMN_NAME"] + "',5,'" + drcolumn["LENGTH"] + "','" + drcolumn["SCALE"] + "','" + drcolumn["PRECISION"] + "','" + drcolumn["NULLABLE"] + "'," + alan_sira + "," + alan_tip + ",3,1,0,1,1)";
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_PRECISION,ALAN_NULL_ICERIR,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + "," + ust_id + ",'" + drcolumn["COLUMN_NAME"] + "','" + drcolumn["COLUMN_NAME"] + "',5,'" + drcolumn["LENGTH"] + "','" + drcolumn["SCALE"] + "','" + drcolumn["PRECISION"] + "','" + drcolumn["NULLABLE"] + "'," + alan_sira + "," + alan_tip + ",1,1,0,1,1)";
                            cmd.ExecuteNonQuery();
                        }
                       
                        id += 1;
                        alan_sira += 1; 
                    }

                }
            }

           MessageBox.Show("İşlem Tamamlandı");
                
        }

        private void alanlariUpdate()
        {
            //      return;
            SqlCommand  sqlYdekCommand = new SqlCommand(); 
            string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = String.Format(strCon, ".", "sa", "bgssup", "ISCI_PERFORMANS");
            cn.Open();
            string strCon1 = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
            SqlConnection cn1 = new SqlConnection();
            cn1.ConnectionString = String.Format(strCon1, ".", "sa", "bgssup", "B2BNET");
            cn1.Open();
            SqlCommand cmd = new SqlCommand("SELECT  M_ALANLAR.M_ALAN_KOPYALAMA_E_H,  M_ALANLAR.KIRILIM_TIP_ID, M_ALANLAR.M_TABLO_TIP_ID,  M_ALANLAR.M_ALAN_GOSTERILEN_ID,M_ALANLAR.M_ALAN_ARAMA_TIP_ID,M_ALANLAR.M_ALAN_CLASS_NAME,M_ALANLAR.ALAN_SIRA, M_ALANLAR.ID, M_ALANLAR.M_ALANLAR_ID, M_ALANLAR.ALAN_AD, M_ALANLAR_1.ID AS UST_ID, M_ALANLAR_1.ALAN_AD AS UST_ALAN FROM M_ALANLAR INNER JOIN M_ALANLAR AS M_ALANLAR_1 ON M_ALANLAR.M_ALANLAR_ID = M_ALANLAR_1.ID", cn1);
            cmd.ExecuteNonQuery();
            SqlDataAdapter recordAdp = new SqlDataAdapter();
            recordAdp.SelectCommand = cmd;
            DataSet recordSet = new DataSet();
            DataRow dr;
            recordAdp.Fill(recordSet);
         
            for (int i = 0; i < recordSet.Tables[0].Rows.Count - 1; i++)
            {

                dr = recordSet.Tables[0].Rows[i];
                string sql = "";
                SqlCommand cmd1 = new SqlCommand("SELECT ID,ALAN_AD,M_ALANLAR_ID  FROM M_ALANLAR where ALAN_AD='" + dr["UST_ALAN"] + "'", cn);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter recordAdp1 = new SqlDataAdapter();
                recordAdp1.SelectCommand = cmd1;
                DataSet recordSet1 = new DataSet();
                DataRow dr1;
                recordAdp1.Fill(recordSet1);
                if (recordSet1.Tables.Count > 0)
                {
                    if (recordSet1.Tables[0].Rows.Count > 0)
                    {
                        dr1 = recordSet1.Tables[0].Rows[0];
                        cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        sql= "update M_ALANLAR set M_TABLO_TIP_ID=" + dr["M_TABLO_TIP_ID"] + ",ALAN_SIRA=" + dr["ALAN_SIRA"] + ",M_ALAN_GOSTERILEN_ID=" + dr["M_ALAN_GOSTERILEN_ID"] + ",M_ALAN_CLASS_NAME='" + dr["M_ALAN_CLASS_NAME"] + "' where ALAN_AD='" + dr["ALAN_AD"] + "' AND M_ALANLAR_ID=" + dr1["ID"];
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("İşlem Tamamlandı");

        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
        }
        void soktfisEkle()
        {
            int id=20200;
            List<AlanlarVm> t = new List<AlanlarVm>();
            AlanlarCntrl alanlist = new AlanlarCntrl();
            t = alanlist.Liste_Al(null);
            foreach (var item in t)
            {
                if (item.ID >= 20000 && item.ID >= 20100)
                {
                    AlanlarVm Vm = new AlanlarVm();
                    Vm = item;
                    Vm.M_ALANLAR_ID = 20200;
                    Vm.ID = id;
                    alanlist.Ekle(Vm);
                    id++;    
                } 
                
            }
        }
    }
}