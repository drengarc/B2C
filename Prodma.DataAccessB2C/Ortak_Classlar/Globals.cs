using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Prodma.DataAccessB2C
{
    public static class Globals
    {

        private static float _sablonFontSize = 11;
        public static float sablonFontSize
        {
            get { return _sablonFontSize; }
            set { _sablonFontSize = value; }
        }

        private static string _sablonFontFamilyName = "GenericSansSerif";
        public static string sablonFontFamilyName
        {
            get { return _sablonFontFamilyName; }
            set { _sablonFontFamilyName = value; }
        }

        private static int _toplamEgitimSaat = 0;
        public static int toplamEgitimSaat
        {
            get { return _toplamEgitimSaat; }
            set { _toplamEgitimSaat = value; }
        }

        private static bool _programKapatma = false;
        public static bool programKapatma
        {
            get { return _programKapatma; }
            set { _programKapatma = value; }
        }
        private static bool _programHataAldi = false;
        public static bool programHataAldi 
        {
            get { return _programHataAldi; }
            set { _programHataAldi = value; }
        }


        private static bool _escapeTabDegistir = true;
        public static bool  escapeTabDegistir//// invalidrowexceptionda disaridan form acilisi yapidiktan sonra giriyorsa hata mesajını mesajboxda gostermesin, ignore etsin kayidi da yapmasin//fissablon ve tanitisablon shownda false menu acilisinda true diye set ediliyor.
        {
            get { return _escapeTabDegistir; }
            set { _escapeTabDegistir = value; }
        }
        private static bool m_SifirliKayitKontrol = true;
        public static bool SifirliKayitKontrol//// invalidrowexceptionda disaridan form acilisi yapidiktan sonra giriyorsa hata mesajını mesajboxda gostermesin, ignore etsin kayidi da yapmasin//fissablon ve tanitisablon shownda false menu acilisinda true diye set ediliyor.
        {
            get { return m_SifirliKayitKontrol; }
            set { m_SifirliKayitKontrol = value; }
        }
        private static bool m_formAc =true;
        public static bool mFormAc//// invalidrowexceptionda disaridan form acilisi yapidiktan sonra giriyorsa hata mesajını mesajboxda gostermesin, ignore etsin kayidi da yapmasin//fissablon ve tanitisablon shownda false menu acilisinda true diye set ediliyor.
        {
            get { return m_formAc; }
            set { m_formAc = value; }
        }
        public static System.Resources.ResourceManager rman;
        public static System.Resources.ResourceManager rmanIng;
        //public static System.Resources.ResourceManager rmanRapor;
        private static int _fisSongun = 3000;
        public static int fisSongun
        {
            get { return _fisSongun; }
            set { _fisSongun = value; }
        }
        private static int _gnKullaniciId;
        public static int gnKullaniciId
        {
            get { return _gnKullaniciId; }
            set { _gnKullaniciId = value; }
        }

        private static string _gnKullaniciAd;
        public static string gnKullaniciAd
        {
            get { return _gnKullaniciAd; }
            set { _gnKullaniciAd = value; }
        }
        
        private static string _gnLogoPath;
        public static string gnLogoPath
        {
            get { return _gnLogoPath; }
            set { _gnLogoPath = value; }
        }

        private static string _gnResimPath;
        public static string gnResimPath
        {
            get { return _gnResimPath; }
            set { _gnResimPath = value; }
        }

        private static int _gnFirmaId;
        public static int gnFirmaId
        {
            get { return _gnFirmaId; }
            set { _gnFirmaId = value; }
        }
        private static string _gnFirmaAd;
        public static string gnFirmaAd
        {
            get { return _gnFirmaAd; }
            set { _gnFirmaAd = value; }
        }
        private static string _gnActiveForm;
        public static string gnActiveForm
        {
            get { return _gnActiveForm; }
            set { _gnActiveForm = value; }
        }

        private static int _gnYear;
        public static int gnYear
        {
            get { return _gnKapaliAy; }
            set { _gnKapaliAy = value; }
        }

        private static int _gnKapaliAy;
        public static int gnKapaliAy
        {
            get { return _gnKapaliAy; }
            set { _gnKapaliAy = value; }
        }
        private static int _gnKapaliYil;
        public static int gnKapaliYil
        {
            get { return _gnKapaliYil; }
            set { _gnKapaliYil = value; }
        }
        private static bool _menuKisayolCalissin;
        public static bool menuKisayolCalissin
        {
            get { return _menuKisayolCalissin; }
            set { _menuKisayolCalissin = value; }
        }
        private static bool _genelBoolean;
        public static bool genelBoolean
        {
            get { return _genelBoolean; }
            set { _genelBoolean = value; }
        }
       

        private static string _hataMesaji;
        public static string hataMesaji
        {
            get { return _hataMesaji; }
            set { _hataMesaji = value; }
        }

        private static string _server;
        public static string server
        {
            get { return _server; }
            set { _server = value; }
        }

        private static string _serverIp;
        public static string serverIp
        {
            get { return _serverIp; }
            set { _serverIp = value; }
        }
        private static string _db;
        public static string db
        {
            get { return _db; }
            set { _db = value; }
        }

        private static string _sirketKod;
        public static string sirketKod
        {
            get { return _sirketKod; }
            set { _sirketKod = value; }
        }

        private static bool _tabliCalis;
        public static bool tabliCalis
        {
            get { return _tabliCalis; }
            set { _tabliCalis = value; }
        }

        private static bool _xLiKullanici;
        public static bool xLiKullanici
        {
            get { return _xLiKullanici; }
            set { _xLiKullanici = value; }
        }

        private static bool _sablonKapatildi;
        public static bool sablonKapatildi
        {
            get { return _sablonKapatildi; }
            set { _sablonKapatildi = value; }
        }
        private static int _currentYear;
        public static int currentYear
        {
            get { return _currentYear; }
            set { _currentYear = value; }
        }
       
        private static string _islemYapilanTabloAdiServiceten;
        public static string islemYapilanTabloAdiServiceten
        {
            get { return _islemYapilanTabloAdiServiceten; }
            set { _islemYapilanTabloAdiServiceten = value; }
        }


        public static int gnKullaniciRolId { get; set; }

        public static int gnKullaniciDil { get; set; }

        public static int gnKullaniciFirmaTipId { get; set; }
    }
}
