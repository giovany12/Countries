using Countries.Prism.Helpers;
using Countries.Prism.Models;
using Newtonsoft.Json;
using Prism.Navigation;

namespace Countries.Prism.ViewModels
{
    public class TranslationsPageViewModel : ViewModelBase
    {
        private Country _country;        

        public TranslationsPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "Translations";
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
        }        

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }
    }
}
