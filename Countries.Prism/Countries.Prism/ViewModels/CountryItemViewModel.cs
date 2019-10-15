using Countries.Prism.Models;
using Prism.Commands;
using Prism.Navigation;

namespace Countries.Prism.ViewModels
{
    public class CountryItemViewModel : Country
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectCountryCommand;

        public CountryItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectCountryCommand => _selectCountryCommand ?? (_selectCountryCommand = new DelegateCommand(SelectCountry));

        private async void SelectCountry()
        {
            var parameters = new NavigationParameters
            {
                { "country", this }
            };

            await _navigationService.NavigateAsync("CountryPage", parameters);
        }
    }
}
