using CurrencyWpf.Model;
using CurrencyWpf.Repository;
using CurrencyWpf.ViewModel;
using System;
using System.Windows;

namespace CurrencyWpf
{
    public partial class App : Application
    {        
        App()
        {
            var client = ClientInitializer.GetClient();
            var mw = new MainWindow
            {
                
                DataContext = new MainWindowViewModel(client) {
                    PeriodStart = DateTime.Now,
                    PeriodEnd = DateTime.Now           
                }
            };
            mw.Show();
        }
        
    }
}
