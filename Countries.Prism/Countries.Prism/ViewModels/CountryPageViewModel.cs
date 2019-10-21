using Countries.Prism.Helpers;
using Countries.Prism.Models;
using Newtonsoft.Json;
using Prism.Navigation;

namespace Countries.Prism.ViewModels
{
    public class CountryPageViewModel : ViewModelBase
    {
        private Country _country;

        public CountryPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "General";
        }

        public Country Country 
        { 
            get => _country; 
            set => SetProperty(ref _country, value); 
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
        }
    }
}
