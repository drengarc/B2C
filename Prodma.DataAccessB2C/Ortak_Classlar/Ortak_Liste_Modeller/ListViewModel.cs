using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.SistemB2C.Models;
namespace Prodma.DataAccessB2C
{
    public class ListViewModel
    {
       
    }
    [AttributeUsage(
    AttributeTargets.Property,
    AllowMultiple = false,
    Inherited = true)]
    public class TipAttribute : Attribute
    {
        string _Uzunluk;
        public string Uzunluk
        {
            get { return _Uzunluk; }
            set { _Uzunluk = value; }
        }
        bool _listViewModel;
        public bool listViewModel
        {
            get { return _listViewModel; }
            set { _listViewModel = value; }
        }
        bool _griddeGorunmesin;
        public bool griddeGorunmesin
        {
            get { return _griddeGorunmesin; }
            set { _griddeGorunmesin = value; }
        }
        int _toplamAlani;
        public int toplamAlani
        {
            get { return _toplamAlani; }
            set { _toplamAlani = value; }
        }
    }
}
