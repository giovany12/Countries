using Countries.Prism.Models;
using Countries.Prism.Services;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Countries.Prism.ViewModels
{
    public class CountriesPageViewModel : ViewModelBase
    {
        private ObservableCollection<Country> _countries;
        private readonly IApiService _apiService;
        private bool _isRefreshing;

        public CountriesPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            Title = "Countries";
            LoadCountries();
        }

        public ObservableCollection<Country> Countries
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
            Countries = new ObservableCollection<Country>(list);
            IsRefreshing = false;
        }
    }
}
