using System;
using won.Models.Accounts;
using won.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views.Accounts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }


    public class LoginViewModel :BaseViewModel{
        public LoginModel Model { get; set; }

        public LoginViewModel()
        {
            Model = new LoginModel();
            Model.UserName = "admin@gmail.com";
            Model.Password = "admin";
            Model.PropertyChanged += Model_PropertyChanged;
            LoginCommand = new Command(LoginAction, x=> Model.Valid);
            RegisterCommand = new Command(RegisterAction);
            ForgotPasswordCommand = new Command(ForgotPasswordAction);
        }

        private void ForgotPasswordAction(object obj)
        {
            Helper.ChangeMainPage(new ForgotPasswordPage());
        }

        private void RegisterAction(object obj)
        {
            Helper.ChangeMainPage(new RegisterPage());
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName!="LoginCommand")
             LoginCommand = new Command(LoginAction, x=>Model.Valid);
        }

        private bool LoginValidate(object arg)
        {
            return Model.Valid;
        }
            
        private async void LoginAction(object obj)
        {
            try
            {
                if (IsBusy) return;

                var isLogin = await AccountService.Login(Model);
                if (isLogin)
                    Helper.ChangeMainPage(new MainPage() as Page);
                else
                {
                    throw new SystemException("Anda Tidak Memiliki Akses");
                }

            }
            catch (Exception ex)
            {
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = ex.Message,
                    Cancel = "OK"
                }, "message");

            }

        }

        private Command loginCommand;

        public Command LoginCommand
        {
            get { return loginCommand; }
            set { SetProperty(ref loginCommand ,value); }
        }


        public Command ForgotPasswordCommand { get; set; }
        public Command RegisterCommand { get; set; }


    }
}