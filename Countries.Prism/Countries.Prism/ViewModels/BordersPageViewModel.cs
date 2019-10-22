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
        private ObservableCollection<Borders> _borders;

        public BordersPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "Borders";
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            LoadBorders();
        }

        public ObservableCollection<Borders> Borders
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
            Borders = new ObservableCollection<Borders>();
            Country country = JsonConvert.DeserializeObject<Country>(Settings.Country);            

            foreach (string border in country.Borders)
                if (country != null) 
                    this.Borders.Add(new Borders { Border = border });


            if (this.Borders.Count == 0)
                this.Borders.Add(new Borders { Border = "the country has not limits" });
        }
    }
}
