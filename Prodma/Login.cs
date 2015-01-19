using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.SistemB2C.Models;
using Prodma.SistemB2C.Controllers;
using Prodma.DataAccessB2C; 
using Prodma.WinForms;
using Prodma.SistemB2C.Services;
using Prodma.Parent;
using System.Threading;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using Npgsql;
using System.Text.RegularExpressions;
namespace Prodma
{
    public partial class Login : Form  
    {
        Prodma.WinForms.SplashScreenForm frm;
        public string conString ="";
        public Login()
        {
            InitializeComponent();
            progressBar1.Visible = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            YardimciIslemler.SirketDoldur(SIRKETgle);
            Point p = new Point((this.ParentForm.Width / 2 - this.Width / 2)-30, (this.ParentForm.Height / 2 - this.Height / 2)-50);
            this.Location = p;
           RegistryKey register1;
           register1 = Registry.LocalMachine.OpenSubKey(@"Software\PRODMA_HR", true);
           if (register1 == null)
           {
               Registry.LocalMachine.CreateSubKey(@"Software\PRODMA_ERP\YIL");
               register1 = Registry.LocalMachine.OpenSubKey(@"Software\PRODMA_HR", true);
               register1.SetValue("YIL", "2012");
           }
           else
           {
               register1 = Registry.LocalMachine.OpenSubKey(@"Software\PRODMA_HR", true);
           }
           if (register1.GetValue("YIL") != null)
           {
               YILtxt.Text = register1.GetValue("YIL").ToString();
           }
           if (register1.GetValue("SERVER") != null)
           {
               IPtxt.Text =   register1.GetValue("SERVER").ToString();
           }
           if (register1.GetValue("DB") != null)
           {
               Dbtxt.Text = register1.GetValue("DB").ToString();
           }
           if (register1.GetValue("KULLANICI_AD") != null)
           {
               txtKullanici.Text = register1.GetValue("KULLANICI_AD").ToString();
           }
           if (register1.GetValue("SIRKET") != null)
           {
               SIRKETgle.EditValue = register1.GetValue("SIRKET").ToString();
           }
           //if (register1.GetValue("CALISMA_YILI") != null)
           //{
           //    CALISMA_YILItxt.Text = register1.GetValue("CALISMA_YILI").ToString();
           //}
           //Globals.server = getConnecTionString();
           txtSifre.Focus();

        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
           
                DialogResult diaResult;
                // Show Message to the User
                diaResult = MessageBox.Show("Program Kapatılacaktır Emin Misiniz?",
                                            "",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button2);
                // Checking which button as been pressed
                if (diaResult == DialogResult.No)
                {
                    // CANCEL pressed, set focus to the program
                    e.Cancel = true;
                }
                else
                {
                    MDIParent mfrm = (MDIParent)this.ParentForm;
                    mfrm.blnBaglantiyiKes = true;
                    mfrm.Dispose();
                    this.Dispose();
                    Application.Exit();
                }
                 
        }
        //[ComVisible(false)]
        //public unsafe RegistryKey CreateSubKey(string subkey, RegistryKeyPermissionCheck permissionCheck, RegistrySecurity registrySecurity)
        //{
        //    ValidateKeyName(subkey);
        //    ValidateKeyMode(permissionCheck);
        //    this.EnsureWriteable();
        //    subkey = FixupName(subkey);
        //    if (!this.remoteKey)
        //    {
        //        RegistryKey key = this.InternalOpenSubKey(subkey, permissionCheck != RegistryKeyPermissionCheck.ReadSubTree);
        //        if (key != null)
        //        {
        //            this.CheckSubKeyWritePermission(subkey);
        //            this.CheckSubTreePermission(subkey, permissionCheck);
        //            key.checkMode = permissionCheck;
        //            return key;
        //        }
        //    }
        //    this.CheckSubKeyCreatePermission(subkey);
        //    Win32Native.SECURITY_ATTRIBUTES structure = null;
        //    if (registrySecurity != null)
        //    {
        //        structure = new Win32Native.SECURITY_ATTRIBUTES();
        //        structure.nLength = Marshal.SizeOf(structure);
        //        byte[] securityDescriptorBinaryForm = registrySecurity.GetSecurityDescriptorBinaryForm();
        //        byte* pDest = stackalloc byte[1 * securityDescriptorBinaryForm.Length];
        //        Buffer.memcpy(securityDescriptorBinaryForm, 0, pDest, 0, securityDescriptorBinaryForm.Length);
        //        structure.pSecurityDescriptor = pDest;
        //    }
        //    int lpdwDisposition = 0;
        //    SafeRegistryHandle hkResult = null;
        //    int errorCode = Win32Native.RegCreateKeyEx(this.hkey, subkey, 0, null, 0, GetRegistryKeyAccess(permissionCheck != RegistryKeyPermissionCheck.ReadSubTree), structure, out hkResult, out lpdwDisposition);
        //    if ((errorCode == 0) && !hkResult.IsInvalid)
        //    {
        //        RegistryKey key2 = new RegistryKey(hkResult, permissionCheck != RegistryKeyPermissionCheck.ReadSubTree, false, this.remoteKey, false);
        //        this.CheckSubTreePermission(subkey, permissionCheck);
        //        key2.checkMode = permissionCheck;
        //        if (subkey.Length == 0)
        //        {
        //            key2.keyName = this.keyName;
        //            return key2;
        //        }
        //        key2.keyName = this.keyName + @"\" + subkey;
        //        return key2;
        //    }
        //    if (errorCode != 0)
        //    {
        //        this.Win32Error(errorCode, this.keyName + @"\" + subkey);
        //    }
        //    return null;
        //}
        private void cmdGiris_Click(object sender, EventArgs e)
        {
            GirisControl();
        }       
        private void GirisControl()
        {
                MDIParent mfrm = (MDIParent)this.ParentForm;
                Cursor.Current = Cursors.WaitCursor;
                mfrm.splashScreenManager1.ShowWaitForm();
                string str1 = getConnecTionStringB2c();
                Globals.server = str1;
                bool blnGiris = false;
                KullaniciCntrl kul = new KullaniciCntrl();
                KullaniciVm k = new KullaniciVm();
                //FirmaParametreVm f = new FirmaParametreVm();
                try
                {
                    //f.FIRMA_ID = 1;
                    //FirmaParametreService srvF = new FirmaParametreService();
                    //f = srvF.Service_Liste_Al(f)[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    mfrm.splashScreenManager1.CloseWaitForm();
                }
                k.KULLANICI_AD = txtKullanici.Text.Trim();
                k.SIFRE = txtSifre.Text.Trim();
                k.LK_DURUM_ID = (int)DurumEn.Aktif;
                List<KullaniciVm> kullanici = new List<KullaniciVm>();
                try
                {
                    kullanici = kul.Liste_Al(k);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "--" + ex.InnerException + "---" + ex.StackTrace.ToString());
                }
                try
                {
                    if (kullanici.Count>0)
                    {
                            System.Reflection.Assembly assem = System.Reflection.Assembly.Load("Prodma.DataAccessB2C");
                            try
                            {
                                RegistryKey register1;
                                register1 = Registry.LocalMachine.OpenSubKey(@"Software\PRODMA_HR", true);
                                //if (register1.GetValue("YIL") != null)
                                //{
                                    register1.SetValue("YIL", YILtxt.Text.Trim());
                                //}
                                //if (register1.GetValue("SERVER") != null)
                                //{
                                    register1.SetValue("SERVER", IPtxt.Text.Trim());
                                //}
                                //if (register1.GetValue("KULLANICI_AD") != null)
                                //{
                                    register1.SetValue("KULLANICI_AD", txtKullanici.Text.Trim());
                                //}
                                //if (register1.GetValue("DB") != null)
                                //{
                                    register1.SetValue("DB", Dbtxt.Text.Trim());
                                //}
                                //if (register1.GetValue("SIRKET") == null)
                               // {
                                    register1.SetValue("SIRKET", Convert.ToString(SIRKETgle.EditValue));
                               // }
                               // if (register1.GetValue("CALISMA_YILI") == null)
                               // {
                                    //register1.SetValue("CALISMA_YILI", CALISMA_YILItxt.Text.Trim());
                               // }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + "----" + ex.InnerException); 
                                //throw;
                            }
                            try
                            {
                                //Globals.rman = new System.Resources.ResourceManager();
                                //Globals.rmanIng = new System.Resources.ResourceManager();
                                if (kullanici[0].DIL_ID == (int)Dil.Turkce)
                                {
                                    Globals.rman = new System.Resources.ResourceManager("Prodma.DataAccessB2C.Resources.Resource1.trTR", assem);
                                    Globals.rmanIng = new System.Resources.ResourceManager("Prodma.DataAccessB2C.Resources.Resource1.enUS", assem);
                                }
                                else
                                {
                                    Globals.rman = new System.Resources.ResourceManager("Prodma.DataAccessB2C.Resources.Resource1.enUS", assem);
                                    Globals.rmanIng = new System.Resources.ResourceManager("Prodma.DataAccessB2C.Resources.Resource1.enUS", assem);
                                }
                                GenelParametreSng nesne = GenelParametreSng.Nesne();
                                Globals.gnKullaniciId = kullanici[0].ID;
                                Globals.gnKullaniciAd = kullanici[0].AD;
                                Globals.gnKullaniciRolId = Convert.ToInt32(kullanici[0].ROL_ID);
                                Globals.gnKullaniciDil = (int)Dil.Turkce;
                                Globals.gnKullaniciFirmaTipId = kullanici[0].KULLANICI_FIRMA_TIP_ID;
                                Globals.gnYear = DateTime.Now.Year;
                                if (kullanici[0].DIL_ID != null) { Globals.gnKullaniciDil = Convert.ToInt32(kullanici[0].DIL_ID); }
                                Globals.mFormAc = true;
                                Globals.gnFirmaId = 3;
                                Globals.hataMesaji = "";
                                Globals.currentYear = Convert.ToInt32(YILtxt.Text);
                                if (IPtxt.Text.Trim() == ".")
                                {
                                    Globals.gnResimPath = "C:/Resimler";
                                }
                                else
	                            {
                                    Globals.gnResimPath = @"\\192.168.0.3\resim/";
	                            }
                                nesne.kullaniciBilgileri = kullanici[0];

                                string ip = "";
                                ip = " && Server : " + IPtxt.Text;
                                Thread t = new Thread(KayitOyala);
                                t.Start();
                                Thread.Sleep(10);
                                // base.gridView1.VisibleColumns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                                this.Hide();
                                mfrm.MenuleriDoldur();

                                mfrm.BilgilerYaz(" && " + Globals.gnFirmaAd + " && Kullanıcı : " + Globals.gnKullaniciAd + ip + " && Tarih : " + DateTime.Now.ToString());
                                mfrm.MainMenuStrip.Enabled = true;
                                Cursor.Current = Cursors.Default;
                                mfrm.splashScreenManager1.CloseWaitForm();
                                //DovizKurCntrl cntrl = new DovizKurCntrl();
                                //if (cntrl.Liste_Al(null).Where(w => w.TARIH == DateTime.Today).ToList().Count == 0)
                                //{
                                //    MessageBox.Show("Döviz Kuru Giriniz");
                                //}

                                //GumrukVarisTarihiYaklasanYolAmbarindakiFaturalariBul();

                                //FiyatTablosundakiKayitlarinOnayTipiniAyarla();

                                //YardimciIslemler.BekleyinizUyarisiDurdur(frm);
                                //YardimciIslemler.ProgramBeklet(1000000000);
                                //frm.Hide();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + "----" + ex.InnerException);
                                //throw;
                            }
                        }
                        else
                        {
                            //   
                            txtKullanici.Text = "";
                            txtSifre.Text = "";
                            lblNot.Text = "Geçersiz Kullanıcı Adı Veya Şifre";
                            mfrm.splashScreenManager1.CloseWaitForm();
                        }
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message.ToString() + " inner :" + ex1.InnerException.ToString());
                }
        }
        void KayitOyala()
        {
          
            //StokFis fis = new StokFis();
            //SiparisFis fis1 = new SiparisFis();
            //fis.Dispose();
            //fis.Close();
            //fis1.Dispose();
            //fis1.Close();
            //FirmaParametreCntrl firma = new FirmaParametreCntrl(); 
            FirmaCntrl firma = new FirmaCntrl(); 
            GenelParametreSng nesne = GenelParametreSng.Nesne();
            YetkiMenulerCntrl kulYetki = new YetkiMenulerCntrl();
            YetkiMenulerVm kYetki = new YetkiMenulerVm();
            kYetki.KULLANICI_ID = Globals.gnKullaniciId;
            kYetki.LK_DURUM_ID = (int)DurumEn.Aktif;

            nesne.kullaniciMenuYetkiBilgileri = kulYetki.Liste_Al(kYetki);
            FirmaVm vmFirma = new FirmaVm();
           // vmFirma.ESKI_KOD = Convert.ToString(SIRKETgle.EditValue);
            vmFirma = firma.Liste_Al(null)[0];

            Globals.gnFirmaId = vmFirma.ID;
            //Globals.gnResimPath = vmFirma.RESIM_PATH;
            //Globals.gnLogoPath = vmFirma.LOGO_PATH;
            Globals.gnFirmaAd = vmFirma.AD;
            //Globals.toplamEgitimSaat = Convert.ToInt32(vmFirma.PERIYODIK_EGITIM_DAKIKA); 
            //KullaniciYetkileriCntrl kullaniciYetkileriCntl = new KullaniciYetkileriCntrl();
            //KullaniciYetkileriVm kYetkiVm = new KullaniciYetkileriVm();
            //kYetkiVm.KULLANICI_ID = Globals.gnKullaniciId;
        
            //if (kullaniciYetkileriCntl.Liste_Al(kYetkiVm).Count > 0)
            //{
            //    nesne.kullaniciYetkileri = kullaniciYetkileriCntl.Liste_Al(kYetkiVm)[0];
            //    ListDenemeService.SetYETKI_ISLEM(nesne.kullaniciYetkileri);
            //}
            //else
            //{
            //    nesne.kullaniciYetkileri = kYetkiVm;
            //    ListDenemeService.SetYETKI_ISLEM(nesne.kullaniciYetkileri);
            //    //return;
            //}
            //string[] a = new string[2];
            FileVersionInfo myFI1 = FileVersionInfo.GetVersionInfo(Application.StartupPath.ToString() + "/Prodma.B2C.exe");
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            string bilgisayarIp = "";
            if (addr.Length > 0)
            {
                for (int i = 0; i < addr.Length; i++)
                {
                    bilgisayarIp = addr[i].ToString() + "  /   ";   
                }
                 
            }
            LogHelperB2C.LogInfoMessage(Globals.gnKullaniciAd + " giriş yapti : Version == " + myFI1.FileVersion + " İp == " + bilgisayarIp);
            //Stok s = new Stok();
            //s.Dispose();
            //s.Close();
        }
        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)            
            {
                GirisControl();
            }
        }
        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }
        public string getConnecTionStringB2c()
        {

          //  connectionString="metadata=res://*/b2cModel.csdl|res://*/b2cModel.ssdl|res://*/b2cModel.msl;provider=Npgsql;provider connection string=&quot;HOST=localhost;PORT=5432;PROTOCOL=3;DATABASE=b2c;USER ID=postgres;PASSWORD=root;SSL=False;SSLMODE=Disable;TIMEOUT=15;SEARCHPATH=;POOLING=True;CONNECTIONLIFETIME=15;MINPOOLSIZE=1;MAXPOOLSIZE=20;SYNCNOTIFICATION=False;COMMANDTIMEOUT=20;ENLIST=False;PRELOADREADER=False;USEEXTENDEDTYPES=False;INTEGRATED SECURITY=False;COMPATIBLE=2.0.11.91&quot;" providerName="System.Data.EntityClient"

            string providerName = "Npgsql";
            string serverName = IPtxt.Text.Trim();
            //string databaseName = "b2c";// Dbtxt.Text.Trim() + Convert.ToString(SIRKETgle.EditValue) + CALISMA_YILItxt.Text.Substring(2, 2);
            //Globals.db = databaseName;
            //Globals.serverIp = IPtxt.Text;
            //SqlConnectionStringBuilder sqlBuilder =
            //    new SqlConnectionStringBuilder();

            //// Set the properties for the data source.
            //sqlBuilder.DataSource = serverName;
            //sqlBuilder.InitialCatalog = databaseName;
            ////sqlBuilder.IntegratedSecurity = true;
            //sqlBuilder.PersistSecurityInfo = false;
            //sqlBuilder.UserID = "sa";
            ////sqlBuilder.
            //sqlBuilder.Password = "bgssup";

            //// Build the SqlConnection connection string.
            //string providerString = sqlBuilder.ToString();

            //// Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
               new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = "Npgsql"; //providerName;

            string strCon = "HOST=185.22.184.145;PORT=5432;PROTOCOL=3;DATABASE=" + serverName + ";USER ID=postgres;PASSWORD=lok651*-;SSL=False;SSLMODE=Disable;TIMEOUT=15;POOLING=True;CONNECTIONLIFETIME=15;MINPOOLSIZE=1;MAXPOOLSIZE=20;SYNCNOTIFICATION=False;COMMANDTIMEOUT=20;ENLIST=False;PRELOADREADER=False;USEEXTENDEDTYPES=False;INTEGRATED SECURITY=False;COMPATIBLE=2.0.11.91;";
            entityBuilder.ProviderConnectionString = strCon;
         //   entityBuilder.ProviderConnectionString = "HOST=185.22.184.145;PORT=5432;PROTOCOL=3;DATABASE=b2c;USER ID=postgres;PASSWORD=lok651*-;SSL=False;SSLMODE=Disable;TIMEOUT=15;POOLING=True;CONNECTIONLIFETIME=15;MINPOOLSIZE=1;MAXPOOLSIZE=20;SYNCNOTIFICATION=False;COMMANDTIMEOUT=20;ENLIST=False;PRELOADREADER=False;USEEXTENDEDTYPES=False;INTEGRATED SECURITY=False;COMPATIBLE=2.0.11.91;";
            // Set the provider-specific connection string.
         //   entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/b2cModel.csdl|
                            res://*/b2cModel.ssdl|  
                            res://*/b2cModel.msl";
            return entityBuilder.ToString();

        }
        public string getConnecTionString()
        {
            //CALISMA_YILItxt.Text =  CALISMA_YILItxt.Text == "" ? Convert.ToString(DateTime.Today.Year) : CALISMA_YILItxt.Text;
            //if (IPtxt.Text.Trim() == "")
            //{
            //    IPtxt.Text = ".";
            //}
            //if (Dbtxt.Text == "" || Dbtxt.Text.Length != 3)
            //{
            //    Dbtxt.Text = "TIC";
            //}
             
            string providerName = "System.Data.SqlClient";
            string serverName = IPtxt.Text.Trim();

           

            string databaseName = "";//Dbtxt.Text.Trim() + Convert.ToString(SIRKETgle.EditValue) + CALISMA_YILItxt.Text.Substring(2, 2);

            databaseName = "TIC0112";
            serverName = ".";
            IPtxt.Text =".";
            Globals.db = databaseName;
            Globals.serverIp = serverName;
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.PersistSecurityInfo = false;
            sqlBuilder.UserID = "sa";
            sqlBuilder.Password = "bgssup";
            string providerString = sqlBuilder.ToString();

            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            entityBuilder.Provider = providerName;

            entityBuilder.ProviderConnectionString = providerString;

            entityBuilder.Metadata = @"res://*/ProdmaModel.csdl|
                            res://*/ProdmaModel.ssdl|
                            res://*/ProdmaModel.msl";
            return entityBuilder.ToString();

        }
        private void IPtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.P)
                {
                    IPtxt.PasswordChar = '\0';
                }
            }
        }
        private void Login_Activated(object sender, EventArgs e)
        {
            txtSifre.Focus();
        }
        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GirisControl();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                cmdGiris.Focus();
            }
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.O)
                {
                    AlanTablosunuOlustur();
                }
            }
        }
        private void Dbtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.P)
                {
                    Dbtxt.PasswordChar = '\0';
                }
            }
        }
        public  void AlanTablosunuOlustur()
        {
             
           // string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";

            string connstring = String.Format("Server={0};Port={1};" +
                   "User Id={2};Password={3};Database={4};",
                   "localhost", "5432", "postgres",
                   "root", "sh");
            NpgsqlConnection cn = new NpgsqlConnection(connstring);
            // quite complex sql statement
            string sql = "SELECT * FROM information_schema.\"tables\"";
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, cn);
            DataSet recordSet = new DataSet();
            DataTable dt = new DataTable();

            NpgsqlCommand cmd = new NpgsqlCommand();
            DataRow dr;
            recordSet.Reset();
            da.Fill(recordSet);
            //for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
            //{
            //    dr = ds.Tables[0].Rows[i];
            //    if (dr[1].ToString() =="public")
            //    {
            //        cmd = new NpgsqlCommand();
            //        cmd.Connection = cn;
            //        cmd.CommandType = CommandType.Text;
            //        cmd.CommandText = "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD,ALAN_LISTE_AD,ALAN_LISTE_GENISLIK,ALAN_UZUNLUK,ALAN_DECIMAL,ALAN_SIRA,M_ALAN_TIP_ID,M_ALAN_GOSTERILEN_ID,M_ALAN_ARAMA_TIP_ID,M_TABLO_TIP_ID,M_ALAN_TIP_2,LK_DURUM_ID) values(" + id + ",0,'" + dr["TABLE_NAME"] + "','',0,'','',0,1,2,1,0,1,1)";
            //        cmd.ExecuteNonQuery();
            //        //MessageBox.Show("1");
            //    }
            //}
            //dt = ds.Tables[0];
            //cn.ConnectionString = String.Format(strCon, ".", "sa", "bgssup", "PRODMA_HR");
            //cn.Open();
            //NpgsqlCommand cmd = new NpgsqlCommand("sp_tables", cn);
            //cmd.ExecuteNonQuery();
            //SqlDataAdapter recordAdp = new SqlDataAdapter();
            //recordAdp.SelectCommand = cmd;
            //DataSet recordSet = new DataSet();
            //DataRow dr;
            //DataRow drcolumn;
            //recordAdp.Fill(recordSet);
            cn.Open();
            cmd = new NpgsqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from \"M_ALANLAR\"";
            cmd.ExecuteNonQuery();
            int ust_id = 1;
            int alan_sira = 0;
            int alan_tip = 1;
            int id = 0;
            string scale = "1";
            string precision = "1";
            string nullable = "1";
            string length = "5";
            string Ad = "";
            for (int i = 0; i < recordSet.Tables[0].Rows.Count - 1; i++)
            {
                //dr = DataRow();
                dr = recordSet.Tables[0].Rows[i];
                if (dr[1].ToString() == "public")
                {
                    //string insertQuery=  "insert into M_ALANLAR(ID,M_ALANLAR_ID,ALAN_AD) values(" + id + ",0,'" + dr["TABLE_NAME"] + "')";
                    cmd = new NpgsqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into \"M_ALANLAR\" (\"ID\",\"M_ALANLAR_ID\",\"ALAN_AD\") values(" + id + ",0,'" + dr["TABLE_NAME"] + "')";
                    cmd.ExecuteNonQuery();
                    ust_id = id;
                    id += 1;

                    sql = "SELECT * FROM information_schema.\"columns\" WHERE \"table_name\"='" + dr[2].ToString() + "' order by ordinal_position";

                    NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sql, cn);
                    DataSet ds = new DataSet();
                    ds.Reset();
                    da1.Fill(ds);
                    string tablo_adi;
                    tablo_adi = dr[2].ToString();
                    alan_sira = 1;
                    DataRow drcolumn;
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        drcolumn = ds.Tables[0].Rows[j];
                        Ad = Convert.ToString(drcolumn["column_name"]);
                        //string scale = Convert.ToString(drcolumn["data_type"]);
                      
                        alan_tip = 1;
                        if ((Regex.IsMatch(Ad, "_id") == true || Regex.IsMatch(Ad, "_ID") == true) && Ad != "ID" && Ad != "id")//fis sıfırlı isleri tamsayı yap
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
                        //else if (Convert.ToInt16(scale) == 0)
                        //{
                        //    alan_tip = 5;
                        //}
                        //else if (Convert.ToInt16(scale) > 0)
                        //{
                        //    alan_tip = 4;
                        //}

                        cmd = new NpgsqlCommand();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        if (tablo_adi == "M_ALANLAR" && (Ad == "KULLANICI_ID" || Ad == "M_ALAN_KOPYALAMA_E_H"))
                        {
                            cmd.CommandText = "insert into \"M_ALANLAR\"(\"ID\",\"M_ALANLAR_ID\",\"ALAN_AD\",\"ALAN_LISTE_AD\",\"ALAN_LISTE_GENISLIK\",\"ALAN_UZUNLUK\",\"ALAN_DECIMAL\",\"ALAN_PRECISION\",\"ALAN_NULL_ICERIR\",\"ALAN_SIRA\",\"M_ALAN_TIP_ID\",\"M_ALAN_GOSTERILEN_ID\",\"M_ALAN_ARAMA_TIP_ID\",\"M_TABLO_TIP_ID\",\"M_ALAN_TIP_2\",\"LK_DURUM_ID\") values(" + id + "," + ust_id + ",'" + Ad + "','" + Ad + "',5,'" + length + "','" + scale + "','" + precision + "','" + nullable + "'," + alan_sira + "," + alan_tip + ",2,1,0,1,1)";
                            cmd.ExecuteNonQuery();
                        }
                        else if (tablo_adi == "YETKI_ALANLAR" && Ad == "M_ALANLAR_ID")
                        {
                            cmd.CommandText = "insert into \"M_ALANLAR\"(\"ID\",\"M_ALANLAR_ID\",\"ALAN_AD\",\"ALAN_LISTE_AD\",\"ALAN_LISTE_GENISLIK\",\"ALAN_UZUNLUK\",\"ALAN_DECIMAL\",\"ALAN_PRECISION\",\"ALAN_NULL_ICERIR\",\"ALAN_SIRA\",\"M_ALAN_TIP_ID\",\"M_ALAN_GOSTERILEN_ID\",\"M_ALAN_ARAMA_TIP_ID\",\"M_TABLO_TIP_ID\",\"M_ALAN_TIP_2\",\"LK_DURUM_ID\") values(" + id + "," + ust_id + ",'" + Ad + "','" + Ad + "',5,'" + length + "','" + scale + "','" + precision + "','" + nullable + "'," + alan_sira + "," + alan_tip + ",1,1,0,1,1)";
                            cmd.ExecuteNonQuery();
                            id += 1;
                            cmd = new NpgsqlCommand();
                            cmd.Connection = cn;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "insert into \"M_ALANLAR\"(\"ID\",\"M_ALANLAR_ID\",\"ALAN_AD\",\"ALAN_LISTE_AD\",\"ALAN_LISTE_GENISLIK\",\"ALAN_UZUNLUK\",\"ALAN_DECIMAL\",\"ALAN_PRECISION\",\"ALAN_NULL_ICERIR\",\"ALAN_SIRA\",\"M_ALAN_TIP_ID\",\"M_ALAN_GOSTERILEN_ID\",\"M_ALAN_ARAMA_TIP_ID\",\"M_TABLO_TIP_ID\",\"M_ALAN_TIP_2\",\"LK_DURUM_ID\") values(" + id + "," + ust_id + ",'M_ALANLAR_UST_ID','M_ALANLAR_UST_ID',5,'" + length + "','" + scale + "','" + precision + "','" + nullable + "'," + alan_sira + "," + alan_tip + ",1,1,0,1,1)";
                            cmd.ExecuteNonQuery();
                        }
                        else if (tablo_adi == "KULLANICI")
                        {
                            if (j < 10)
                            {
                                cmd.CommandText = "insert into \"M_ALANLAR\"(\"ID\",\"M_ALANLAR_ID\",\"ALAN_AD\",\"ALAN_LISTE_AD\",\"ALAN_LISTE_GENISLIK\",\"ALAN_UZUNLUK\",\"ALAN_DECIMAL\",\"ALAN_PRECISION\",\"ALAN_NULL_ICERIR\",\"ALAN_SIRA\",\"M_ALAN_TIP_ID\",\"M_ALAN_GOSTERILEN_ID\",\"M_ALAN_ARAMA_TIP_ID\",\"M_TABLO_TIP_ID\",\"M_ALAN_TIP_2\",\"LK_DURUM_ID\") values(" + id + "," + ust_id + ",'" + Ad + "','" + Ad + "',5,'" + length + "','" + scale + "','" + precision + "','" + nullable + "'," + alan_sira + "," + alan_tip + ",1,1,0,1,1)";
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                cmd.CommandText = "insert into \"M_ALANLAR\"(\"ID\",\"M_ALANLAR_ID\",\"ALAN_AD\",\"ALAN_LISTE_AD\",\"ALAN_LISTE_GENISLIK\",\"ALAN_UZUNLUK\",\"ALAN_DECIMAL\",\"ALAN_PRECISION\",\"ALAN_NULL_ICERIR\",\"ALAN_SIRA\",\"M_ALAN_TIP_ID\",\"M_ALAN_GOSTERILEN_ID\",\"M_ALAN_ARAMA_TIP_ID\",\"M_TABLO_TIP_ID\",\"M_ALAN_TIP_2\",\"LK_DURUM_ID\") values(" + id + "," + ust_id + ",'" + Ad + "','" + Ad + "',5,'" + length + "','" + scale + "','" + precision + "','" + nullable + "'," + alan_sira + "," + alan_tip + ",3,1,0,1,1)";
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            //cmd.CommandText = "insert into \"M_ALANLAR\" (\"ID\",\"M_ALANLAR_ID\",\"ALAN_AD\",\"ALAN_LISTE_AD\",\"M_ALAN_TIP_ID\",\"M_ALAN_GOSTERILEN_ID\") values(" + id + "," + ust_id + ",'" + Ad + "','" + Ad + "'," + alan_tip + ",1)";
                            cmd.CommandText = "insert into \"M_ALANLAR\"(\"ID\",\"M_ALANLAR_ID\",\"ALAN_AD\",\"ALAN_LISTE_AD\",\"ALAN_LISTE_GENISLIK\",\"ALAN_UZUNLUK\",\"ALAN_DECIMAL\",\"ALAN_PRECISION\",\"ALAN_NULL_ICERIR\",\"ALAN_SIRA\",\"M_ALAN_TIP_ID\",\"M_ALAN_GOSTERILEN_ID\",\"M_ALAN_ARAMA_TIP_ID\",\"M_TABLO_TIP_ID\",\"M_ALAN_TIP_2\",\"LK_DURUM_ID\") values(" + id + "," + ust_id + ",'" + Ad + "','" + Ad + "',5,'" + length + "','" + scale + "','" + precision + "','" + nullable + "'," + alan_sira + "," + alan_tip + ",1,1,0,1,1)";
                            cmd.ExecuteNonQuery();
                        }

                        id += 1;
                        alan_sira += 1;
                    }

                }
            }

           MessageBox.Show("İşlem Tamamlandı");
                
        }

    }
    public static class BTADataOperations
    {
        //public static Func<ProdmaEntities, string, IQueryable<KULLANICI>> GetProductsByCatId = CompiledQuery.Compile((ProdmaEntities nwDc, string ad) =>
        //    from p in nwDc.KULLANICI
        //    where p.KULLANICI_AD == ad
        //    select p // bu ifade sonucu IQueryable türünden nesnedir!
        //);
    }
    public static class deneme
    {
        public static void SORGU()
        {
            //ProdmaEntities context = new ProdmaEntities();
            //var entityConn = context.Connection as EntityConnection;
            //var dbConn = entityConn.StoreConnection as SqlConnection;
            //dbConn.Open();
            //var cmd = new SqlCommand("SELECT * FROM KULLANICI", dbConn);
        }
    }


}
