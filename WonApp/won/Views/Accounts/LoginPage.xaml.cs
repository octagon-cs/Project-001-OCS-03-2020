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
            var vm = new LoginViewModel();
            vm.OnExecute += Vm_onExecute;
            BindingContext = vm;
        }

        private void Vm_onExecute(string ev, object data)
        {
            if (ev == "go")
            {
                this.Navigation.PushAsync((Page)data);
            }
        }
    }


    public class LoginViewModel :BaseViewModel{
        public LoginModel Model { get; set; }

        public LoginViewModel()
        {
            Model = new LoginModel();
            Model.UserName = "kristt26@gmail.com";
            Model.Password = "12345";
            Model.PropertyChanged += Model_PropertyChanged;
            LoginCommand = new Command(LoginAction, x=> Model.Valid);
            RegistrasiCommand = new Command(RegisterAction);
            ForgotPasswordCommand = new Command(ForgotPasswordAction);
            this.URL = "http://192.168.1.9:3000/";
        }

        private void ForgotPasswordAction(object obj)
        {
            Helper.ChangeMainPage(new ForgotPasswordPage());
        }

        private void RegisterAction(object obj)
        {
            Execute("go", new RegisterPage());
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
                {
                   await AccountService.Profile();
                    Helper.ChangeMainPage(new MainPage() as Page);
                }
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
        public Command RegistrasiCommand { get; set; }



        private string url;
        public string URL
        {
            get { return url; }
            set { SetProperty(ref url, value); 
                Helper.Url = value; }
        }



    }
}