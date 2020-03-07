using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models.Accounts;
using won.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views.Accounts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }
    }


    public class RegisterViewModel:BaseViewModel
    {
        public RegisterModel Model { get; set; }
        public RegisterViewModel()
        {
            Model = new RegisterModel();
            Model.PropertyChanged += Model_PropertyChanged;
            RegisterCommand = new Command(RegisterAction, x => Model.Valid);
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Model.Valid)
                RegisterCommand = new Command(RegisterAction, x => Model.Valid);
        }

        private async void RegisterAction(object obj)
        {
            if (IsBusy)
                return;

            try
            {
                var result = await AccountService.Register(Model);
                if (result)
                {
                    MessagingCenter.Send(new MessagingCenterAlert
                    {
                        Title = "Sukses",
                        Message = "Akun berhasil dibuat !. Anda belum dapat login, mohon periksa email anda untuk konfirmasi email",
                        Cancel = "OK"
                    }, "message");
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

        private Command registerCommand;

        public Command RegisterCommand
        {
            get { return registerCommand; }
            set { SetProperty(ref registerCommand, value); }
        }



    }
}