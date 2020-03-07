using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }


    public class HomeViewModel:BaseViewModel
    {
        public ObservableCollection<PermohonanModel> Items { get; set; }
        public Command LoadItemsCommand { get; }

        public HomeViewModel()
        {
            Items = new ObservableCollection<PermohonanModel>();
            LoadItemsCommand = new Command(LoadAction);
            LoadItemsCommand.Execute(null);
        }

        private async void LoadAction(object obj)
        {
            try
            {
                if (IsBusy)
                    return;


                Items.Clear();
                var items = await PermohonanService.Get();
                foreach (var item in items)
                {
                    Items.Add(item);
                }

                if (items.Count() <= 0)
                {
                    MessagingCenter.Send(new MessagingCenterAlert
                    {
                        Title = "Error",
                        Message = "Anda Belum Membuat Permohonan Pemuatan Surat",
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
    }
}