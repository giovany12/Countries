using Countries.Prism.Models;
using Countries.Prism.Services;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Countries.Prism.ViewModels
{
    public class CountriesPageViewModel : ViewModelBase
    {
        private ObservableCollection<CountryItemViewModel> _countries;
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRefreshing;

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

        private async void LoadCountries()
        {
            IsRefreshing = true;

            var url = App.Current.Resources["UrlAPI"].ToString();
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
            Countries = new ObservableCollection<CountryItemViewModel>(list.Select(c => new CountryItemViewModel(_navigationService) 
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
            }).ToList());
            IsRefreshing = false;
        }
    }
}
