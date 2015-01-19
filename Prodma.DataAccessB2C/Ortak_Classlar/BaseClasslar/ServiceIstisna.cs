using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prodma.DataAccessB2C
{
    public class ServiceIstisna : Exception
    {
        public string Mesaj;
        private SqlException exception;
        public ServiceIstisna(string msg)
            : base(msg)
        {
            Mesaj = msg;
        }

        public ServiceIstisna(string msg, Exception innerException)
            : base(msg, innerException)
        {
            Mesaj = msg + " inner:" + innerException;
        }

        public ServiceIstisna(Exception hata, bool _mesajGosterme)
        {
            Mesaj = hata.Message + " inner: " + hata.InnerException;
            exception = hata.InnerException as SqlException;
            string a = exception.Number.ToString();
            if(_mesajGosterme==false) HataMesaji();
        }

        public void HataMesaji()
        {
            switch (exception.Number)
            {
                case 547:
                    {
                        int ilkKarakter = Mesaj.IndexOf("dbo.") + 4;
                        int sonKarakter = Mesaj.IndexOf("column") - 3;
                        string tabloAdi = Mesaj.Substring(ilkKarakter, sonKarakter - ilkKarakter);
                        tabloAdi = Globals.rman.GetString(tabloAdi) ?? tabloAdi;
                        MessageBox.Show("Silmek istediğiniz veri \"" + tabloAdi + "\" tablosunda Kullanılmaktadır!");
                        break;
                    }
                case 2627:
                    MessageBox.Show("Kaydetmek istediğiniz veri, veri tabanında zaten mevcut.");
                    break;
                default:
                    MessageBox.Show("Hata Kodu: " + exception.Number);
                    break;
            }
        }
    }
}
