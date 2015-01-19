using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccessB2C; using Prodma.WinForms;
using System.Threading;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Prodma.SistemB2C.Controllers;
using Prodma.SistemB2C.Models;
namespace Prodma.Sistem.Forms
{
    public partial class TabloEkle : Islemler
    {
        public TabloEkle()
        {
            InitializeComponent();
            this.Text = Globals.rman.GetString("TopluIrsaliyeNoDuzenlemefrm"); //"Toplu İrsaliye No Duzenleme";
        }
        private void TopluIrsaliyeNoDuzenleme_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, TABLOtxt, true);
        }
       
       
        public override void Tamam()
        {
            if (sorguBitti == false)
            {
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                if (TABLOtxt.Text != "" && ALANtxt.Text.Trim()=="")
                {
                    tabloSil(TABLOtxt.Text);
                    TabloyuEkle(TABLOtxt.Text);
                }
                else
                {
                    TabloAlanEkle(TABLOtxt.Text,ALANtxt.Text);
                }
            }
            sorguBitti = true;
        }
        private void tabloSil(string tablo)
        {
            string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = String.Format(strCon, ".", "sa", "bgssup", "PRODMA_HR");
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("select * from M_ALANLAR where ALAN_AD='" + tablo + "'", cn);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter recordAdp1 = new SqlDataAdapter();
            recordAdp1.SelectCommand = cmd1;
            DataSet recordSet1 = new DataSet();
            DataRow dr1;
            DataRow drcolumn1;
            recordAdp1.Fill(recordSet1);
            if (recordSet1.Tables[0].Rows.Count > 0)
            {
                dr1 = recordSet1.Tables[0].Rows[0];
                int silinecekId = Convert.ToInt32(dr1["ID"]);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from M_ALANLAR where (ALAN_AD='" + tablo + "' OR M_ALANLAR_ID=" + silinecekId + ")";
                cmd.ExecuteNonQuery();
            }
        }
        private void alanlaridoldur(string tablo)
        {
            //      return;
            int id = 1;
            int ust_id = 1;
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


            SqlCommand cmd1 = new SqlCommand("select * from M_ALANLAR where ALAN_AD='" + tablo+ "'", cn);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter recordAdp1 = new SqlDataAdapter();
            recordAdp1.SelectCommand = cmd1;
            DataSet recordSet1 = new DataSet();
            DataRow dr1;
            DataRow drcolumn1;
            recordAdp1.Fill(recordSet1);
            dr1 = recordSet.Tables[0].Rows[0];
            int silinecekId = Convert.ToInt32(dr1["ID"]);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from M_ALANLAR where (ALAN_AD='" + tablo + "' || M_ALANLAR_ID=" + silinecekId + ")";
            cmd.ExecuteNonQuery();

            ust_id = 1;
            alan_sira = 0;
            int alan_tip = 1;
            for (int i = 0; i < recordSet.Tables[0].Rows.Count - 1; i++)
            {
                //dr = DataRow();
                dr = recordSet.Tables[0].Rows[i];
                if (dr["TABLE_OWNER"].Equals("dbo") == true && Convert.ToString(dr["TABLE_NAME"]) == tablo)
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
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        drcolumn = ds.Tables[0].Rows[j];
                        string Ad = Convert.ToString(drcolumn["COLUMN_NAME"]);
                        string scale = Convert.ToString(drcolumn["SCALE"]);
                        //string scale = Convert.ToString(drcolumn["SCALE"]);
                        //string scale = Convert.ToString(drcolumn["SCALE"]); 
                        alan_tip = 1;
                        if (Regex.IsMatch(Ad, "_ID") == true && Ad != "ID")//fis sıfırlı isleri tamsayı yap
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

        void TabloyuEkle(string tablo)
        {
            if (ustIdBul(tablo) != 0) return;
            int id = alanIdBul();
            int ust_id = 0;
            int alan_sira = 0;
            string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = String.Format(strCon, ".", "sa", "bgssup", Globals.db);
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_tables", cn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter recordAdp = new SqlDataAdapter();
            recordAdp.SelectCommand = cmd;
            DataSet recordSet = new DataSet();
            DataRow dr;
            DataRow drcolumn;
            recordAdp.Fill(recordSet);
            ust_id = 0;
            alan_sira = 0;
            int alan_tip = 1;
            for (int i = 0; i < recordSet.Tables[0].Rows.Count - 1; i++)
            {
                dr = recordSet.Tables[0].Rows[i];
                if (dr["TABLE_OWNER"].Equals("dbo") == true && Convert.ToString(dr["TABLE_NAME"]) == tablo)
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
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        drcolumn = ds.Tables[0].Rows[j];
                        string Ad = Convert.ToString(drcolumn["COLUMN_NAME"]);
                        string scale = Convert.ToString(drcolumn["SCALE"]);
                        //string scale = Convert.ToString(drcolumn["SCALE"]);
                        //string scale = Convert.ToString(drcolumn["SCALE"]); 
                        alan_tip = 1;
                        if (Regex.IsMatch(Ad, "_ID") == true && Ad != "ID")//fis sıfırlı isleri tamsayı yap
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
                        cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_PRECISION,ALAN_NULL_ICERIR,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + "," + ust_id + ",'" + drcolumn["COLUMN_NAME"] + "','" + drcolumn["COLUMN_NAME"] + "',5,'" + drcolumn["LENGTH"] + "','" + drcolumn["SCALE"] + "','" + drcolumn["PRECISION"] + "','" + drcolumn["NULLABLE"] + "'," + alan_sira + "," + alan_tip + ",1,1,0,1,1)";
                        cmd.ExecuteNonQuery();
                        id += 1;
                        alan_sira += 1;
                    }

                }
            }

            MessageBox.Show("işlem Tamamlandı");
        }
        void TabloAlanEkle(string tablo,string alan)
        {
            int id = alanIdBul();
            int ust_id = 1;
            int alan_sira = 0;
            string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = String.Format(strCon, ".", "sa", "bgssup", Globals.db);
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_tables", cn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter recordAdp = new SqlDataAdapter();
            recordAdp.SelectCommand = cmd;
            DataSet recordSet = new DataSet();
            DataRow dr;
            DataRow drcolumn;
            recordAdp.Fill(recordSet);
            alan_sira = 0;
            int alan_tip = 1;
            for (int i = 0; i < recordSet.Tables[0].Rows.Count - 1; i++)
            {
                dr = recordSet.Tables[0].Rows[i];
                if (dr["TABLE_OWNER"].Equals("dbo") == true && Convert.ToString(dr["TABLE_NAME"])==tablo)
                {
                    ust_id = ustIdBul(tablo);
                    cmd = new SqlCommand("sp_columns", cn);
                    recordAdp = new SqlDataAdapter();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@table_name", SqlDbType.NVarChar).Value = dr["TABLE_NAME"];
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    string tablo_adi;
                    tablo_adi = (string)dr["TABLE_NAME"];
                    alan_sira = 1;
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        drcolumn = ds.Tables[0].Rows[j];
                        string Ad = Convert.ToString(drcolumn["COLUMN_NAME"]);
                        if (Ad != alan) continue;
                        string scale = Convert.ToString(drcolumn["SCALE"]);
                        //string scale = Convert.ToString(drcolumn["SCALE"]);
                        //string scale = Convert.ToString(drcolumn["SCALE"]); 
                        alan_tip = 1;
                        if (Regex.IsMatch(Ad, "ID") == true && Ad != "ID")//fis sıfırlı isleri tamsayı yap
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
                        cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_PRECISION,ALAN_NULL_ICERIR,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + "," + ust_id + ",'" + drcolumn["COLUMN_NAME"] + "','" + drcolumn["COLUMN_NAME"] + "',5,'" + drcolumn["LENGTH"] + "','" + drcolumn["SCALE"] + "','" + drcolumn["PRECISION"] + "','" + drcolumn["NULLABLE"] + "'," + alan_sira + "," + alan_tip + ",2,1,0,1,1)";
                        cmd.ExecuteNonQuery();
                        id += 1;
                        alan_sira += 1;
                    }

                }
            }

           MessageBox.Show("işlem Tamamlandı");
        }

        void TabloAlanEkle1(string tablo, string alan)
        {
            int id = alanIdBul();
            int ust_id = 1;
            int alan_sira = 0;
            string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = String.Format(strCon, ".", "sa", "bgssup", Globals.db);
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_tables", cn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter recordAdp = new SqlDataAdapter();
            recordAdp.SelectCommand = cmd;
            DataSet recordSet = new DataSet();
            DataRow dr;
            DataRow drcolumn;
            recordAdp.Fill(recordSet);
            alan_sira = 0;
            int alan_tip = 1;
            for (int i = 0; i < recordSet.Tables[0].Rows.Count - 1; i++)
            {
                dr = recordSet.Tables[0].Rows[i];
                if (dr["TABLE_OWNER"].Equals("dbo") == true && Convert.ToString(dr["TABLE_NAME"]) == tablo)
                {
                    ust_id = ustIdBul(tablo);
                    cmd = new SqlCommand("sp_columns", cn);
                    recordAdp = new SqlDataAdapter();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@table_name", SqlDbType.NVarChar).Value = dr["TABLE_NAME"];
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    string tablo_adi;
                    tablo_adi = (string)dr["TABLE_NAME"];
                    alan_sira = 1;
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        drcolumn = ds.Tables[0].Rows[j];
                        string Ad = Convert.ToString(drcolumn["COLUMN_NAME"]);
                        if (Ad != alan) continue;
                        string scale = Convert.ToString(drcolumn["SCALE"]);
                        //string scale = Convert.ToString(drcolumn["SCALE"]);
                        //string scale = Convert.ToString(drcolumn["SCALE"]); 
                        alan_tip = 1;
                        if (Regex.IsMatch(Ad, "ID") == true && Ad != "ID")//fis sıfırlı isleri tamsayı yap
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
                        cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_PRECISION,ALAN_NULL_ICERIR,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + "," + ust_id + ",'" + drcolumn["COLUMN_NAME"] + "','" + drcolumn["COLUMN_NAME"] + "',5,'" + drcolumn["LENGTH"] + "','" + drcolumn["SCALE"] + "','" + drcolumn["PRECISION"] + "','" + drcolumn["NULLABLE"] + "'," + alan_sira + "," + alan_tip + ",2,1,0,1,1)";
                        cmd.ExecuteNonQuery();
                        id += 1;
                        alan_sira += 1;
                    }

                }
            }

            MessageBox.Show("işlem Tamamlandı");
        }
        int alanIdBul()
        {
            AlanlarCntrl cntrl = new AlanlarCntrl();
            List<AlanlarVm> list = cntrl.Liste_Al(null);
            var sonuc2 = list.FindAll(f => f.ID > 10000 && f.ID < 20000).OrderByDescending(o => o.ID).FirstOrDefault();
            if (sonuc2==null)
            {
                return 10000;
            }
            return sonuc2.ID + 1;
        }
        int ustIdBul(string tabloAdi)
        {
            AlanlarCntrl cntrl = new AlanlarCntrl();
            List<AlanlarVm> list = cntrl.Liste_Al(null);
            var sonuc2 = list.FindAll(f => f.ALAN_AD==tabloAdi).OrderByDescending(o => o.ID).FirstOrDefault();
            if (sonuc2 != null && sonuc2.ID != 0)
            {
                return sonuc2.ID ;
            }
            else
            {
                return 0;
            }
        }
          
    }
}
