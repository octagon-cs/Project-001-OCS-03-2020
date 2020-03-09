using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views.SuratPermohonan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DomisiliPage : ContentPage
    {
        public DomisiliPage()
        {
            InitializeComponent();
            BindingContext = new DomisiliViewModel();
        }
    }
    public class DomisiliViewModel : BaseViewModel
    {
        public Models.SuratPermohonan.Domisilimodel Model { get; set; } = new Models.SuratPermohonan.Domisilimodel();
        public DomisiliViewModel()
        {
            Model.PropertyChanged += Model_PropertyChanged;
            SaveCommand = new Command(SaveAction);
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Model.Valid)
                SaveCommand = new Command(SaveAction, x => Model.Valid);
        }

        private async void SaveAction(object obj)
        {
            try
            {

                if (IsBusy)
                    return;

                IsBusy = true;
                var permohonan = new PermohonanModel() { TanggalPengajuan = DateTime.Now, Data = Model, Status = StatusPersetujuan.Baru };
                var result = await PermohonanService.Create(permohonan);
                if (result != null)
                {
                    Helper.Permohonan.Add(result);
                    MessagingCenter.Send(new MessagingCenterAlert { Cancel = "OK", Message = "Permohonan Anda Berhasil dibuat !", Title = "Info" }, "message");
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = ex.Message,
                    Cancel = "OK"
                }, "message");
                IsBusy = false;
            }
        }

        private Command saveCommand;

        public Command SaveCommand
        {
            get { return saveCommand; }
            set { SetProperty(ref saveCommand, value); }
        }

    }
}