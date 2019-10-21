using Countries.Prism.Helpers;
using Countries.Prism.Models;
using Newtonsoft.Json;
using Prism.Navigation;

namespace Countries.Prism.ViewModels
{
    public class CountryTabbedPageViewModel : ViewModelBase
    {
        public CountryTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            var country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            Title = $"Country: {country.Name}";
        }
    }
}
