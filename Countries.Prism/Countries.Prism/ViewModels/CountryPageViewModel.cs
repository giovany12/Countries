using Countries.Prism.Models;
using Prism.Navigation;

namespace Countries.Prism.ViewModels
{
    public class CountryPageViewModel : ViewModelBase
    {
        private Country _country;

        public CountryPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
        }

        public Country Country 
        { 
            get => _country; 
            set => SetProperty(ref _country, value); 
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("country"))
            {
                Country = parameters.GetValue<Country>("country");
                Title = Country.Name;
            }
        }
    }
}
