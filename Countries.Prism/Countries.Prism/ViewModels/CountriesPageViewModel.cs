using Countries.Prism.Helpers;
using Countries.Prism.Models;
using Countries.Prism.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Countries.Prism.ViewModels
{
    public class CountriesPageViewModel : ViewModelBase
    {
        private ObservableCollection<CountryItemViewModel> _countries;
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRefreshing;
        private DelegateCommand _orderByNameCommand;
        private DelegateCommand _orderByAreaCommand;
        private DelegateCommand _orderByPopulationCommand;
        private bool _isVisible;

        public CountriesPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Countries";
            LoadCountries();
        }

        public ObservableCollection<CountryItemViewModel> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        public DelegateCommand OrderByNameCommand => _orderByNameCommand ?? (_orderByNameCommand = new DelegateCommand(CountryByName));

        public DelegateCommand OrderByAreaCommand => _orderByAreaCommand ?? (_orderByAreaCommand = new DelegateCommand(CountryByArea));

        public DelegateCommand OrderByPopulationCommand => _orderByPopulationCommand ?? (_orderByPopulationCommand = new DelegateCommand(CountryByPopulation));

        private void CountryByName()
        {
            Countries = new ObservableCollection<CountryItemViewModel>(Countries.Select(c => c).OrderBy(c => c.Name).ToList());
        }

        private void CountryByArea()
        {
            Countries = new ObservableCollection<CountryItemViewModel>(Countries.Select(c => c).OrderByDescending(c => c.Area).ToList());
        }

        private void CountryByPopulation()
        {
            Countries = new ObservableCollection<CountryItemViewModel>(Countries.Select(c => c).OrderByDescending(c => c.Population).ToList());
        }        

        private async void LoadCountries()
        {
            IsRefreshing = true;            

            var url = App.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnection(url);
            if (!connection)
            {
                IsRefreshing = false;
                if (!string.IsNullOrEmpty(Settings.Countries))
                {                    
                    var countries = JsonConvert.DeserializeObject<List<Country>>(Settings.Countries);
                    Countries = new ObservableCollection<CountryItemViewModel>(this.CountriesToCountriesItemViewModel(countries));
                }
                else
                {
                    IsVisible = true;
                }
                return;
            }

            var response = await this._apiService.GetCountries(
                url,
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
            }

            var list = (List<Country>)response.Result;
            Countries = new ObservableCollection<CountryItemViewModel>(this.CountriesToCountriesItemViewModel(list));             
            IsRefreshing = false;
            Settings.Countries = JsonConvert.SerializeObject(Countries);
        }

        private IEnumerable<CountryItemViewModel> CountriesToCountriesItemViewModel(List<Country> countries)
        {
            return countries.Select(c => new CountryItemViewModel(_navigationService)
            {
                Alpha2Code = c.Alpha2Code,
                Alpha3Code = c.Alpha3Code,
                AltSpellings = c.AltSpellings,
                Area = c.Area,
                Borders = c.Borders,
                CallingCodes = c.CallingCodes,
                Capital = c.Capital,
                Cioc = c.Cioc,
                Currencies = c.Currencies,
                Demonym = c.Demonym,
                Flag = c.Flag,
                Gini = c.Gini,
                Languages = c.Languages,
                Latlng = c.Latlng,
                Name = c.Name,
                NativeName = c.NativeName,
                NumericCode = c.NumericCode,
                Population = c.Population,
                Region = c.Region,
                RegionalBlocs = c.RegionalBlocs,
                Subregion = c.Subregion,
                Timezones = c.Timezones,
                TopLevelDomain = c.TopLevelDomain,
                Translations = c.Translations,
            }).ToList();
        }
    }
}
