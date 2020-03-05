using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using won.Services;
using won.Views;
using won.Views.Accounts;
using System.Threading.Tasks;
using System.Globalization;

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


           
            MainPage = new LoginPage();
        }


        public async void ChangeScreen(Page page)
        {
            await Task.Delay(200);
            Current.MainPage = page;
            //   MessagingCenter.Send(EventArgs.Empty, "GoHome");
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
