using Xamarin.Forms;
using won.Services;
using won.Views.Accounts;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace won
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            CultureInfo requestCulture;
            try
            {
                requestCulture = CultureInfo.CreateSpecificCulture("id-ID");
            }
            catch
            {
                requestCulture = CultureInfo.CurrentCulture;
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = requestCulture;
            MessagingCenter.Subscribe<MessagingCenterAlert>(this, "message", async (message) =>
            {
                await Current.MainPage.DisplayAlert(message.Title, message.Message, message.Cancel);

            });

            DependencyService.Register<AccountService>();
            DependencyService.Register<JenisPermohonanService>();
            DependencyService.Register<PermohonanService>();


            MainPage = new NavigationPage(new LoginPage());
            AppCenter.Start("371b628f-72e3-4305-805c-595bdaa16b97", typeof(Analytics), typeof(Crashes));
        }


        public async void ChangeMain(Page page)
        {
            await Task.Delay(200);
            Current.MainPage = page;
            //   MessagingCenter.Send(EventArgs.Empty, "GoHome");
        }

        public async void NavigateGo(Page page)
        {
            await Task.Delay(200);
            Current.MainPage = new NavigationPage(page);
            //   MessagingCenter.Send(EventArgs.Empty, "GoHome");
        }

        public async void NextPage(Page page)
        {
            await Current.MainPage.Navigation.PushAsync(page);
        }

        public async void BackPage()
        {
            await Current.MainPage.Navigation.PopAsync(true);
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


    }
}
