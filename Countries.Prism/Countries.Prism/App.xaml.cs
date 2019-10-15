using Prism;
using Prism.Ioc;
using Countries.Prism.ViewModels;
using Countries.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Countries.Prism.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Countries.Prism
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<CountriesPage, CountriesPageViewModel>();            
            containerRegistry.RegisterForNavigation<CountryPage, CountryPageViewModel>();
        }
    }
}
