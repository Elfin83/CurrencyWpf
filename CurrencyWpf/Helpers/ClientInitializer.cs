using CurrencyWpf.DailyInfoWebServ;
using System.ServiceModel;


namespace CurrencyWpf
{
    public static class ClientInitializer
    {
        public static DailyInfoSoapClient GetClient()
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.TransferMode = TransferMode.Buffered;
            binding.UseDefaultWebProxy = true;            
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Windows;
            return new DailyInfoSoapClient(binding, new EndpointAddress("http://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx?wsdl"));
        }
    }
}
