using Countries.Prism.Helpers;
using Countries.Prism.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace Countries.Prism.ViewModels
{
    public class CurrenciesPageViewModel : ViewModelBase
    {        
        private Country _country;
        private ObservableCollection<Currency> _currencies;

        public CurrenciesPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {            
            Title = "Currencies";
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            LoadCurrencies();
        }

        public ObservableCollection<Currency> Currencies
        {
            get => _currencies;
            set => SetProperty(ref _currencies, value);
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private void LoadCurrencies()
        {
            Currencies = new ObservableCollection<Currency>(Country.Currencies);
        }
    }
}
