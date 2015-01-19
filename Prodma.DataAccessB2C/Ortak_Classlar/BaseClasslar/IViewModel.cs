using System;
using System.Collections.Generic;

namespace Prodma.DataAccessB2C
{
    public class ModelFiltresi
    {
        public DateTime baslangicTarih { get; set; }
        public DateTime bitisTarih { get; set; }
        public DateTime baslangicTarih_2 { get; set; } // irsaliye_tarih icin kondu
        public DateTime bitisTarih_2 { get; set; }
        public DateTime baslangicTarih_3 { get; set; } // irsaliye_tarih icin kondu
        public DateTime bitisTarih_3 { get; set; }
    }
    public class IViewModel{
        public int ID { get; set; }
        public int insertId;
        public int intTemp;
        public int? intTempNull;
        public string tabloAdi;
        public string ayrimAlan;
        public string ListeFiltresi { get; set; }
        public bool modelDegiskligeUgradi { get; set; }
        public string CariFiltresi { get; set; }
        public ModelFiltresi modelFiltreleri { get; set; }
        public int IslemNedeni { get; set; }
        public string Islem { get; set; }
        public string yil { get; set; }
    }
    [AttributeUsage(
AttributeTargets.Property,
AllowMultiple = false,
Inherited = true)]
    public class TanitimAttribute : Attribute
    {
        string _Tip;
        public string Tip
        {
            get { return _Tip; }
            set { _Tip = value; }
        }
        bool _IViewModel;
        public bool IViewModel
        {
            get { return _IViewModel; }
            set { _IViewModel = value; }
        }
    }
}
