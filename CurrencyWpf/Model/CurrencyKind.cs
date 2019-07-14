using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CurrencyWpf.Model
{
    [Serializable, XmlRoot("ValuteData")]
    public class ValuteKindData
    {
        [XmlElement("EnumValutes")]
        public List<CurrencyKind> CurrencyKinds { get; set; }
    }

    [Serializable]
    public class CurrencyKind
    {
        [XmlElement]
        public string Vcode { get; set; } //Внутренний код валюты
        [XmlElement]
        public string Vname { get; set; } //Название валюты
    }
}
