using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CurrencyWpf.Model
{
    [Serializable, XmlRoot("ValuteData")]
    public class ValuteData
    {
        [XmlElement("ValuteCursDynamic")]
        public List<CurrencyData> CurrencyData { get; set; }
    }
    [Serializable]
    public class CurrencyData
    {
        [XmlElement("CursDate"), DisplayName("Дата")]
        public DateTime CurrencyDate { get; set; }
        [XmlElement("Vcurs"), DisplayName("Курс")]
        public decimal CurrencyValue { get; set; }
        [XmlElement("Vnom"), DisplayName("Номинал")]
        public decimal CurrencyNominal { get; set; }
    }
}
