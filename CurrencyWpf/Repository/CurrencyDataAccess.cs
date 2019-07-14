using CurrencyWpf.DailyInfoWebServ;
using CurrencyWpf.Helpers;
using CurrencyWpf.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CurrencyWpf.Repository
{    
    public static class CurrencyDataAccess
    {
        public static ObservableCollection<CurrencyKind> GetCurrencyKinds(DailyInfoSoapClient client)
        {
            var result = client.EnumValutesXML(false);
            var currencies = XmlHelper.DeserialiseXml<ValuteKindData>(result);
            return new ObservableCollection<CurrencyKind>(currencies.CurrencyKinds);
        }
        public static async Task<ObservableCollection<CurrencyData>> GetCurrencyList(DailyInfoSoapClient client, DateTime startDate, DateTime endDate, string valutaCode)
        {
            var result = await client.GetCursDynamicXMLAsync(startDate, endDate, valutaCode);
            var currencyList = XmlHelper.DeserialiseXml<ValuteData>(result);
            return new ObservableCollection<CurrencyData>(currencyList.CurrencyData);
        }
    }
}
