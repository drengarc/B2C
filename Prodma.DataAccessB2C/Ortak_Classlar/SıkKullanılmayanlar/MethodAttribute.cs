using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Data;

namespace Prodma.DataAccessB2C
{
    [AttributeUsage(AttributeTargets.Property)]
    class MetodAttribute : Attribute
    {
        private string _MetodAdi;
        private bool _identity;
        private bool _nullIcerebilir;

        public bool NullIcerebilir
        {
            get { return _nullIcerebilir; }
            set { _nullIcerebilir = value; }
        }

        public string MetodAdi
        {
            get { return _MetodAdi; }
            set { _MetodAdi = value; }
        }
        public bool Identity
        {
            get { return _identity; }
            set { _identity = value; }
        }

        public MetodAttribute(string MetodinAdi, bool identityMi, bool nullIcerirmi)
        {
            MetodAdi = MetodinAdi;
            Identity = identityMi;
            NullIcerebilir = nullIcerirmi;
        }
        public MetodAttribute(string MetodinAdi, bool identityMi)
            : this(MetodinAdi, identityMi, true)
        {
        }
        public MetodAttribute(string MetodinAdi)
            : this(MetodinAdi, false)
        {
        }
        public MetodAttribute()
        {
        }
    }
}