using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Prodma.Parent;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using Prodma.DataAccessB2C; using Prodma.WinForms;
using DevExpress.XtraSplashScreen;
using Prodma.Guncelleme;
//using Prodma.Guncelleme;
namespace Prodma
{ 
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
       //     Application.ThreadException += new ThreadExceptionEventHandler(
       //Application_ThreadException);
            //SplashScreenManager.ShowForm(typeof(Forms.FSplashScreen));
            try
            {
                ResourceManager resman = new ResourceManager("Prodma.Resources.Resource1", Assembly.GetExecutingAssembly());
                string a = Application.StartupPath.ToString();
                string b = resman.GetString("Guncelleme_Yolu"); //@"C:/BOR12/";
                if (b != "")
                {
                    FileVersionInfo myFI = FileVersionInfo.GetVersionInfo(b + "/Prodma.B2C.exe");
                    FileVersionInfo myFI1 = FileVersionInfo.GetVersionInfo(Application.StartupPath.ToString() + "/Prodma.B2C.exe");
                    if (myFI.FileVersion != myFI1.FileVersion)
                    {
                        DialogResult res = MessageBox.Show("Yeni Versiyon Bulundu.Güncelleme Yapılsın Mı?", "", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            Process myProcess = new Process();
                            myProcess.StartInfo.UseShellExecute = false;
                            myProcess.StartInfo.FileName = a + "\\Prodma.Guncelleme.exe";
                            myProcess.StartInfo.CreateNoWindow = true;
                            myProcess.Start();
                            System.Environment.Exit(0);
                        }
                    }
                }
                //if (myFI.FileVersion != myFI1.FileVersion)
                //{
                //    DialogResult res = MessageBox.Show("Yeni Versiyon Bulundu.Güncelleme Yapılsın Mı?", "", MessageBoxButtons.YesNo);
                //    //BusyForm frm = new BusyForm();
                //    //frm.Show();
                //    //frm.calistir();
                //    if (res == DialogResult.Yes)
                //    {
                //        if (b != null && b != "")
                //        {
                //            Process myProcess = new Process();
                //            myProcess.StartInfo.UseShellExecute = false;
                //            // You can start any process, HelloWorld is a do-nothing example.
                //            myProcess.StartInfo.FileName = a + "\\Prodma.Guncelleme.exe";
                //            myProcess.StartInfo.CreateNoWindow = true;
                //            myProcess.Start();
                //            //Thread t = new Thread(GuncellemeIslemi.Kopyala);
                //            //t.Start();
                //            //Thread.Sleep(1);
                //            System.Environment.Exit(0);
                        
                //            //Form1 frm = new Form1();
                //            //Application.Exit();
                //            //frm.ShowDialog();
                //            //MessageBox.Show("Güncelleme Yapılıyor.Program otomatik Olarak Başlatılacaktır");
                //            ////File.Move(a + "/Prodma.exe", a + "/Prodma" + myFI.FileVersion.ToString() + ".exe");
                //            //File.Copy(b + "Prodma.Satis.exe", a + "/Prodma.Satis.exe", true);
                //            //File.Copy(b + "Prodma.DataAccess.dll", a + "/Prodma.DataAccess.dll", true);
                //            //File.Copy(b + "Prodma.Raporlar.exe", a + "/Prodma.Raporlar.exe", true);
                //            //File.Copy(b + "Prodma.Muhasebe.exe", a + "/Prodma.Muhasebe.exe", true);
                //            //File.Copy(b + "Prodma.Sistem.exe", a + "/Prodma.Sistem.exe", true);
                //            //File.Copy(b + "Logging.dll", a + "/Logging.dll", true);
                //            ////File.Copy(b + "Prodma.exe", a + "/Prodma.exe", true);
                //            ////Application.Restart();
                //            ////File.Delete(a + "/Prodma" + myFI.FileVersion.ToString() + ".exe");
                //        }
                //    }
                //}
              
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message.ToString() + " Güncellemede Problem Oluştu");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException +=
       new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //using (Form1 login = new Form1())
            // {
            // if (login.ShowDialog() == DialogResult.OK)

            Application.Run(new MDIParent());

            //}
        }
        public static void Application_ThreadException
        (object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            DialogResult result = DialogResult.Abort;
            try
            {
                string mesaj = Globals.gnKullaniciAd;
                if (e.Exception.Message.Length > 200)
                {
                    mesaj += e.Exception.Message.ToString().Substring(0, 200);
                }
                else
                {
                    mesaj += e.Exception.Message.ToString();
                }
                if (e.Exception.StackTrace.ToString().Length > 200)
                {
                    mesaj += "HATA:" + e.Exception.StackTrace.ToString().Substring(0, 200);
                }
                else
                {
                    mesaj += e.Exception.StackTrace.ToString();
                }
                if (Globals.serverIp == "") Globals.serverIp = "192.100.10.250";
                //LogHelperB2C.logger.setString("data source=" + Globals.serverIp + ";initial catalog=" + Globals.db + ";integrated security=false;persist security info=True;User ID=sa;Password=bgssup");
             //   LogHelperB2C.logger.LogError(mesaj);
                //MessageBox.Show(mesaj);
                Globals.programHataAldi = true;
                LogHelperB2C.LogError(mesaj);
                //result = MessageBox.Show("Dikkat!!! Program Hatalı İşlem Yürüttü "
                //  , "Application Error",
                //  MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                //MessageBox.Show(e.Exception.Message.Substring(0, 100)
                //  + e.Exception.StackTrace.Substring(0, 100));
                //LogHelperB2C.logger.LogError(Globals.gnKullaniciAd + e.Exception.Message.Substring(0, 100)
                //  + e.Exception.StackTrace.Substring(0, 100));
                //result = MessageBox.Show("Dikkat! Program Hatalı İşlem Yürüttü ", "Application Error",
                //  MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                
            }
            finally
            {
                //if (result == DialogResult.Abort)
                //{
                //    Application.Exit();
                //}
            }
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
                DialogResult result = DialogResult.Abort;
                try
                {
                    Exception ex = (Exception)e.ExceptionObject;
                    string mesaj = Globals.gnKullaniciAd;
                    if (ex.Message.Length > 200)
                    {
                        mesaj += ex.Message.ToString().Substring(0, 200);
                    }
                    else
                    {
                        mesaj += ex.Message.ToString();
                    }
                    if (ex.StackTrace.ToString().Length > 200)
                    {
                        mesaj += "HATA:" + ex.StackTrace.ToString().Substring(0, 200);
                    }
                    else
                    {
                        mesaj += ex.StackTrace.ToString();
                    }
                    //MessageBox.Show("Whoops! Please contact the developers with the following"
                    //      + " information:\n\n" + ex.Message + ex.StackTrace,
                    //      "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    if (Globals.serverIp == "") Globals.serverIp = "192.100.10.250";
                    //LogHelperB2C.logger.setString("data source=" + Globals.serverIp + ";initial catalog=" + Globals.db + ";integrated security=false;persist security info=True;User ID=sa;Password=bgssup");
                    Globals.programHataAldi = true;
                    LogHelperB2C.LogError(mesaj);
                    result = MessageBox.Show("Dikkat!!! Program Hatalı İşlem Yürüttü "
                      , "Application Error",
                      MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);

                }
                finally
                {
                    if (result == DialogResult.Abort)
                    {
                        Application.Exit();
                    }
                }
           // throw new NotImplementedException();
        }
    }
}
