namespace MSmile.Mobile
{
    using Xamarin.Forms;

    using AutoMapper;

    using MSmile.Api.Client;

    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var mapper = CreateMapper();
            DependencyService.RegisterSingleton(mapper);
            DependencyService.Register<DifficultyLevelClient>();
            DependencyService.Register<EmployeeClient>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile>());
            return config.CreateMapper();
        }
    }
}
