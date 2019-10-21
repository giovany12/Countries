using Countries.Prism.Helpers;
using Countries.Prism.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace Countries.Prism.ViewModels
{
    public class BordersPageViewModel : ViewModelBase
    {
        private Country _country;
        private ObservableCollection<Country> _borders;

        public BordersPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "Borders";
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            LoadBorders();
        }

        public ObservableCollection<Country> Borders
        {
            get => _borders;
            set => SetProperty(ref _borders, value);
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private void LoadBorders()
        {
            Borders = new ObservableCollection<Country>();
        }
    }
}
