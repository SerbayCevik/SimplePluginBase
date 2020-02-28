using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Homework.CurrencyManagement.Models

{

    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "Tarih_Date", Namespace = "", IsNullable = false)]

    public class  TCMBCurrency
    {

        private List<Currency> currencyField;

        private string tarihField;

        private string dateField;

        private string bulten_NoField;

        /// <remarks/>
        [XmlElement("Currency")]
        public List<Currency> Currencies
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Tarih
        {
            get
            {
                return this.tarihField;
            }
            set
            {
                this.tarihField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Bulten_No
        {
            get
            {
                return this.bulten_NoField;
            }
            set
            {
                this.bulten_NoField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class Currency
    {

        private byte unitField;

        private string isimField;

        private string currencyNameField;

        private string forexBuyingField;

        private string forexSellingField;

        private string banknoteBuyingField;

        private string banknoteSellingField;

        private string crossRateUSDField;

        private string crossRateOtherField;

        private byte crossOrderField;

        private string kodField;

        private string currencyCodeField;

        /// <remarks/>
        public byte Unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        public string Isim
        {
            get
            {
                return this.isimField;
            }
            set
            {
                this.isimField = value;
            }
        }

        /// <remarks/>
        public string CurrencyName
        {
            get
            {
                return this.currencyNameField;
            }
            set
            {
                this.currencyNameField = value;
            }
        }

        /// <remarks/>
        public string ForexBuying
        {
            get
            {
                return this.forexBuyingField;
            }
            set
            {
                this.forexBuyingField = value;
            }
        }

        /// <remarks/>
        public string ForexSelling
        {
            get
            {
                return this.forexSellingField;
            }
            set
            {
                this.forexSellingField = value;
            }
        }

        /// <remarks/>
        public string BanknoteBuying
        {
            get
            {
                return this.banknoteBuyingField;
            }
            set
            {
                this.banknoteBuyingField = value;
            }
        }

        /// <remarks/>
        public string BanknoteSelling
        {
            get
            {
                return this.banknoteSellingField;
            }
            set
            {
                this.banknoteSellingField = value;
            }
        }

        /// <remarks/>
        public string CrossRateUSD
        {
            get
            {
                return this.crossRateUSDField;
            }
            set
            {
                this.crossRateUSDField = value;
            }
        }

        /// <remarks/>
        public string CrossRateOther
        {
            get
            {
                return this.crossRateOtherField;
            }
            set
            {
                this.crossRateOtherField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public byte CrossOrder
        {
            get
            {
                return this.crossOrderField;
            }
            set
            {
                this.crossOrderField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Kod
        {
            get
            {
                return this.kodField;
            }
            set
            {
                this.kodField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }
    }



}
