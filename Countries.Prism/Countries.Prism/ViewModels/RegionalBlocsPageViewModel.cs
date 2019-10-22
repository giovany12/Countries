using Countries.Prism.Helpers;
using Countries.Prism.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace Countries.Prism.ViewModels
{
    public class RegionalBlocsPageViewModel : ViewModelBase
    {
        private Country _country;
        private ObservableCollection<RegionalBloc> _regionalBlocs;

        public RegionalBlocsPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "RegBlocs";
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            LoadRegionalBlocs();
        }

        public ObservableCollection<RegionalBloc> RegionalBlocs
        {
            get => _regionalBlocs;
            set => SetProperty(ref _regionalBlocs, value);
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private void LoadRegionalBlocs()
        {
            RegionalBlocs = new ObservableCollection<RegionalBloc>(Country.RegionalBlocs);
        }
    }
}
