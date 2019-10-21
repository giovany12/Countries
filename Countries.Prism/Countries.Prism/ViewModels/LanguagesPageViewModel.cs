using Countries.Prism.Helpers;
using Countries.Prism.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace Countries.Prism.ViewModels
{
    public class LanguagesPageViewModel : ViewModelBase
    {
        private Country _country;
        private ObservableCollection<Language> _languages;

        public LanguagesPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "Languages";            
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            LoadLanguages();
        }

        public ObservableCollection<Language> Languages
        {
            get => _languages;
            set => SetProperty(ref _languages, value);
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private void LoadLanguages()
        {
            Languages = new ObservableCollection<Language>(Country.Languages);
        }
    }
}
