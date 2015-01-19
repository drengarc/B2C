using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.Sistem.Models;
using Prodma.Sistem.Controllers;
using Prodma.DataAccess;
using Prodma.Sistem.Services;
using Prodma.Parent;
using System.Threading;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using Prodma.DataAccess.Ortak_Formlar;
using Satis.Cari.Controllers;
using Satis.Cari.Models;
using System.Diagnostics;
using System.Net;
using Satis.StokAmbar.Forms;
using AlisSatis.Fis.Forms;
using Siparis.Fis.Forms;
using AlisSatis.Fis.Controllers;
namespace Prodma
{
    public partial class Login : Form  
    {
        SplashScreenForm frm;
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
           register1 = Registry.LocalMachine.OpenSubKey(@"Software\PRODMA_ERP", true);
           if (register1 == null)
           {
               Registry.LocalMachine.CreateSubKey(@"Software\PRODMA_ERP\YIL");
               register1 = Registry.LocalMachine.OpenSubKey(@"Software\PRODMA_ERP", true);
               register1.SetValue("YIL", "2012");
           }
           else
           {
               register1 = Registry.LocalMachine.OpenSubKey(@"Software\PRODMA_ERP", true);
           }
           if (register1.GetValue("YIL") != null)
           {
               YILtxt.Text = register1.GetValue("YIL").ToString();
           }
           if (register1.GetValue("SERVER") != null)
           {
               IPtxt.Text = register1.GetValue("SERVER").ToString();
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
           if (register1.GetValue("CALISMA_YILI") != null)
           {
               CALISMA_YILItxt.Text = register1.GetValue("CALISMA_YILI").ToString();
           }
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
                //frm = new SplashScreenForm();
                //frm.StartPosition = FormStartPosition.Manual;
                //Point p = new Point((this.ParentForm.Width / 2 - this.Width / 2), (this.ParentForm.Height / 2 - this.Height / 2));
                //frm.Location = p;
               // YardimciIslemler.BekleyinizUyarisiGoster(frm);
                string str1 = getConnecTionString();
                Globals.server = str1;
                bool blnGiris = false;
                KullaniciCntrl kul = new KullaniciCntrl();
                KullaniciVm k = new KullaniciVm();
                FirmaParametreVm f = new FirmaParametreVm();
                try
                {
                    f.FIRMA_ID = 1;
                    FirmaParametreService srvF = new FirmaParametreService();
                    f = srvF.Service_Liste_Al(f)[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    mfrm.splashScreenManager1.CloseWaitForm();
                }
                k.KULLANICI_AD = txtKullanici.Text.Trim();
                k.SIFRE = txtSifre.Text.Trim();
                k.LK_DURUM_ID = (int)DurumEn.Aktif;
                List<KullaniciVm> kullanici = kul.Liste_Al(k);
                if (kullanici.Count > 0)
                {
                    System.Reflection.Assembly assem = System.Reflection.Assembly.Load("Prodma.DataAccess");
                    try
                    {
                        RegistryKey register1;
                        register1 = Registry.LocalMachine.OpenSubKey(@"Software\PRODMA_ERP", true);
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
                            register1.SetValue("CALISMA_YILI", CALISMA_YILItxt.Text.Trim());
                       // }

                    }
                    catch (Exception)
                    {
                        
                        //throw;
                    }
                    if (kullanici[0].DIL_ID == (int)Dil.Turkce)
                    {
                        Globals.rman = new System.Resources.ResourceManager("Prodma.DataAccess.Resources.Resource1.trTR", assem);
                        Globals.rmanIng = new System.Resources.ResourceManager("Prodma.DataAccess.Resources.Resource1.enUS", assem);
                    }
                    else
                    {
                        Globals.rman = new System.Resources.ResourceManager("Prodma.DataAccess.Resources.Resource1.enU", assem);
                        Globals.rmanIng = new System.Resources.ResourceManager("Prodma.DataAccess.Resources.Resource1.enUS", assem);
                    }
                    GenelParametreSng nesne = GenelParametreSng.Nesne();
                    Globals.gnKullaniciId = kullanici[0].ID;
                    Globals.gnKullaniciAd = kullanici[0].AD;
                    Globals.mFormAc = true;
                    Globals.gnFirmaId = 1;
                    Globals.hataMesaji = "";
                    Globals.currentYear = Convert.ToInt32(YILtxt.Text);
                    nesne.kullaniciBilgileri = kullanici[0];
                    string ip = "";
                    ip = " && Server : " + IPtxt.Text;
                    Thread t = new Thread(KayitOyala);
                    t.Start();
                    Thread.Sleep(10);
                    // base.gridView1.VisibleColumns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    this.Hide();
                    mfrm.MenuleriDoldur();
                    mfrm.BilgilerYaz(" && " + Globals.gnFirmaAd + " && Kullanıcı : " + Globals.gnKullaniciAd + ip + " && Çalışma Yılı : " + CALISMA_YILItxt.Text + " && Tarih : " + DateTime.Now.ToString());
                    mfrm.MainMenuStrip.Enabled = true;
                    Cursor.Current = Cursors.Default;
                    mfrm.splashScreenManager1.CloseWaitForm();
                    DovizKurCntrl cntrl = new DovizKurCntrl();
                    if (cntrl.Liste_Al(null).Where(w => w.TARIH == DateTime.Today).ToList().Count == 0)
                    {
                        MessageBox.Show("Döviz Kuru Giriniz");
                    }

                    GumrukVarisTarihiYaklasanYolAmbarindakiFaturalariBul();

                        //YardimciIslemler.BekleyinizUyarisiDurdur(frm);
                    //YardimciIslemler.ProgramBeklet(1000000000);
                    //frm.Hide();
                }
                else
                {
                    txtKullanici.Text = "";
                    txtSifre.Text = "";
                    lblNot.Text = "Geçersiz Kullanıcı Adı Veya Şifre";
                    mfrm.splashScreenManager1.CloseWaitForm();
                }
        }

        public void GumrukVarisTarihiYaklasanYolAmbarindakiFaturalariBul()
        {
            using (ProdmaEntities context = new ProdmaEntities())
            {
                TimeSpan gun = new TimeSpan(2, 0, 0, 0, 0);
                DateTime sonTarih = DateTime.Today + gun;                    
                //StokFisSifirCntrl cntrlfis = new StokFisSifirCntrl();
                //if (cntrlfis.Liste_Al(null).Where(w => w.IRSALIYE_TARIH >= DateTime.Today && w.IRSALIYE_TARIH <= sonTarih && w.GIRIS_AMBAR.AMBAR_TIP_ID == Convert.ToInt32(AmbarTipEn.YOLAMBAR_GUMRUK)).ToList().Count > 0)
                //{
                //    MessageBox.Show("Yol Ambarında, Gümrük Varış tarihi yaklaşan faturalar var, Kontrol ediniz !...");
                //}
                var list = (from stok in context.STOK_FIS_SIFIRLI
                            where (stok.IRSALIYE_TARIH >= DateTime.Today && stok.IRSALIYE_TARIH <= sonTarih
                            && stok.AMBAR.AMBAR_TIP_ID == (int)AmbarTipEn.YOLAMBAR_GUMRUK)                   
                            select new 
                            {
                                IRSALIYE_NO = stok.IRSALIYE_NO
                                                                
                            }).ToList();
                if (list.Count > 0)
                {
                    MessageBox.Show("Yol Ambarında, Gümrük Varış tarihi yaklaşan faturalar var, Kontrol ediniz !...");
                }                
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
            FirmaParametreCntrl firma = new FirmaParametreCntrl(); 
            GenelParametreSng nesne = GenelParametreSng.Nesne();
            YetkiMenulerCntrl kulYetki = new YetkiMenulerCntrl();
            YetkiMenulerVm kYetki = new YetkiMenulerVm();
            kYetki.KULLANICI_ID = Globals.gnKullaniciId;
            kYetki.LK_DURUM_ID = (int)DurumEn.Aktif;

            nesne.kullaniciMenuYetkiBilgileri = kulYetki.Liste_Al(kYetki);
            nesne.firmaBilgileri = firma.Liste_Al(null)[0];

            Globals.gnFirmaId = nesne.firmaBilgileri.FIRMA_ID;
            Globals.gnLogoPath = nesne.firmaBilgileri.LOGO_PATH;
            Globals.gnFirmaAd = nesne.firmaBilgileri.FIRMA_ADI;
            Globals.stokKirilim = nesne.firmaBilgileri.STOK_KIRILMA;
            Globals.cariKirilim = nesne.firmaBilgileri.CARI_HESAP_KIRILMA;
            Globals.muhasebeKirilim = nesne.firmaBilgileri.MUHASEBE_KIRILMA;
            Globals.masrafYeriKirilim = nesne.firmaBilgileri.MASRAF_YERI_KIRILMA;
            Globals.dovizKurTip = Convert.ToInt32(nesne.firmaBilgileri.SATIS_DOVIZ_KUR_TIP);
            KullaniciYetkileriCntrl kullaniciYetkileriCntl = new KullaniciYetkileriCntrl();
            KullaniciYetkileriVm kYetkiVm = new KullaniciYetkileriVm();
            kYetkiVm.KULLANICI_ID = Globals.gnKullaniciId;
        
            if (kullaniciYetkileriCntl.Liste_Al(kYetkiVm).Count > 0)
            {
                nesne.kullaniciYetkileri = kullaniciYetkileriCntl.Liste_Al(kYetkiVm)[0];
                ListDenemeService.SetYETKI_ISLEM(nesne.kullaniciYetkileri);
            }
            else
            {
                nesne.kullaniciYetkileri = kYetkiVm;
                ListDenemeService.SetYETKI_ISLEM(nesne.kullaniciYetkileri);
                //return;
            }
            string[] a = new string[2];
            a = ListDenemeService.GetVARSAYILAN_AMBAR_ID(Globals.gnKullaniciId, (int)KullaniciAmbarTipEn.VARSAYILAN);
            if (a.Length > 0)
            {
                if (a[0]!="")nesne.kullaniciYetkileri.KULLANICI_VARSAYILAN_AMBAR_ID = Convert.ToInt32(a[0]);
                nesne.kullaniciYetkileri.KULLANICI_VARSAYILAN_AMBAR_KOD = a[1];
            }
            OrtakIslemlerService.CariErisimBul();
            FileVersionInfo myFI1 = FileVersionInfo.GetVersionInfo(Application.StartupPath.ToString() + "/Prodma.Satis.exe");
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
            LogHelper.LogInfoMessage(Globals.gnKullaniciAd + " giriş yapti : Version == " + myFI1.FileVersion + " İp == " + bilgisayarIp);
            Stok s = new Stok();
            s.Dispose();
            s.Close();
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
        public string getConnecTionString()
        {
            CALISMA_YILItxt.Text = CALISMA_YILItxt.Text == "" ? Convert.ToString(DateTime.Today.Year) : CALISMA_YILItxt.Text;
            if (IPtxt.Text.Trim() == "")
            {
                IPtxt.Text = ".";
                //YILtxt.Text = Convert.ToString(DateTime.Today.Year);
            }
            if (Dbtxt.Text == "" || Dbtxt.Text.Length != 3)
            {
                Dbtxt.Text = "TIC";
            }
            //if (IPtxt.Text.Trim() == "")
            //{
            //    IPtxt.Text = ".";
            //    Dbtxt.Text = "TIC0112";
            //    YILtxt.Text = Convert.ToString(DateTime.Today.Year);
            //}
            string providerName = "System.Data.SqlClient";
            string serverName = IPtxt.Text.Trim();
            //string databaseName = Dbtxt.Text.Trim();
            string databaseName = "TIC" + Convert.ToString(SIRKETgle.EditValue) + CALISMA_YILItxt.Text.Substring(2, 2);
            //Globals.sirketKod
            Globals.db = databaseName;
            Globals.serverIp = IPtxt.Text;
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
        public string getConnecTionString1()
        {
            CALISMA_YILItxt.Text = CALISMA_YILItxt.Text == "" ? Convert.ToString(DateTime.Today.Year) : CALISMA_YILItxt.Text;
            if (IPtxt.Text.Trim() == "")
            {
                IPtxt.Text = ".";
                //YILtxt.Text = Convert.ToString(DateTime.Today.Year);
            }
            if (Dbtxt.Text == "" || Dbtxt.Text.Length!=3 )
            {
                Dbtxt.Text = "TIC";
            }
            string providerName = "System.Data.SqlClient";
            string serverName = IPtxt.Text.Trim();
//            string databaseName = Dbtxt.Text.Trim();
            string databaseName = "TIC" + Convert.ToString(SIRKETgle.EditValue) + CALISMA_YILItxt.Text.Substring(2,2);
            Globals.db = databaseName;
            //Globals.serverIp = IPtxt.Text;
            //LogHelper.logger.setString("data source=.;initial catalog=" + Globals.db + ";integrated security=false;persist security info=True;User ID=sa;Password=bgssup");
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
            conString = "data source=.;initial catalog=TIC1012;integrated security=false;persist security info=True;User ID=sa;Password=bgssup";

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
    }
    public static class BTADataOperations
    {
        public static Func<ProdmaEntities, string, IQueryable<KULLANICI>> GetProductsByCatId = CompiledQuery.Compile((ProdmaEntities nwDc, string ad) =>
            from p in nwDc.KULLANICI
            where p.KULLANICI_AD == ad
            select p // bu ifade sonucu IQueryable türünden nesnedir!
        );
    }
    public static class deneme
    {
        public static void SORGU()
        {
            ProdmaEntities context = new ProdmaEntities();
            var entityConn = context.Connection as EntityConnection;
            var dbConn = entityConn.StoreConnection as SqlConnection;
            dbConn.Open();
            var cmd = new SqlCommand("SELECT * FROM KULLANICI", dbConn );
        }
    }


}
