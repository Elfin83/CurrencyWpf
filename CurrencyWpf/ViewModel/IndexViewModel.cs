using CurrencyWpf.DailyInfoWebServ;
using CurrencyWpf.Model;
using CurrencyWpf.Repository;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CurrencyWpf.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region INotifyPropertyChanged implementing
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region properties and fields
        private readonly DailyInfoSoapClient _client;
        private DateTime _periodStart;
        private DateTime _periodEnd;
        private CurrencyKind _currentCurrency;
        private ObservableCollection<CurrencyData> _currencyDataList;
        private ObservableCollection<CurrencyKind> _currencyKinds;
        public DateTime PeriodStart
        {
            get { return _periodStart; }
            set
            {
                _periodStart = value;
                OnPropertyChanged("PeriodStart");
            }
        }
        public DateTime PeriodEnd
        {
            get { return _periodEnd; }
            set
            {
                _periodEnd = value;
                OnPropertyChanged("PeriodEnd");
            }
        }
        public CurrencyKind CurrentCurrency
        {
            get { return _currentCurrency; }
            set
            {
                _currentCurrency = value;
                OnPropertyChanged("CurrentCurrency");
            }
        }
        public ObservableCollection<CurrencyData> CurrencyDataList
        {
            get { return _currencyDataList; }
            set
            {
                _currencyDataList = value;
                OnPropertyChanged("CurrencyDataList");
            }
        }
        public ObservableCollection<CurrencyKind> CurrencyKinds
        {
            get { return _currencyKinds; }
            set
            {
                _currencyKinds = value;
                OnPropertyChanged("CurrencyKinds");
            }
        }

        public string this[string controlName]
        {
            get
            {
                string error = String.Empty;
                switch (controlName)
                {
                    case "PeriodStart":
                        if(PeriodStart > DateTime.Today.AddDays(1))
                        {
                            error = "Дата начала периода должна быть раньше текущей даты. ";
                        }
                        if (PeriodStart > PeriodEnd)
                        {
                            error += "Дата начала периода должна быть меньше даты окончания.";
                        }
                        break;
                    case "PeriodEnd":
                        if (PeriodEnd > DateTime.Today.AddDays(1))
                        {
                            error = "Дата окончания периода должна быть раньше текущей даты. ";
                        }
                        if (PeriodStart > PeriodEnd)
                        {
                            error += "Дата окончания периода должна быть больше даты начала.";                            
                        }                        
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public IAsyncCommand GetDataCommand { get; private set; }
        #endregion
        public MainWindowViewModel(DailyInfoSoapClient client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            _client = client;
            _currencyKinds = CurrencyDataAccess.GetCurrencyKinds(client);            
            GetDataCommand = new AsyncCommand(async () =>
            {
                CurrencyDataList = await CurrencyDataAccess.GetCurrencyList(_client, PeriodStart, PeriodEnd, CurrentCurrency.Vcode);
            });
            
        }
    }
}
