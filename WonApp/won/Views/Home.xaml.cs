using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.ViewModels;
using won.Views.Progress;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        private HomeViewModel vm;
        private double width;
        private double height;

        public Home()
        {
            InitializeComponent();

            BindingContext = vm= new HomeViewModel();
            vm.OnExecute += Vm_OnExecute;
            Load();
            
        }

        private void Load()
        {
            foreach (var item in ItemsListView.ItemsSource)
            {

            }
        }

        private async void Vm_OnExecute(string ev, object data)
        {

            await Navigation.PushAsync((Page)data);
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<Page>(this, "homeview");
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
                //reconfigure layout
            }
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

                IsBusy = true;
                Items.Clear();
                var items = await PermohonanService.Get();
                foreach (var item in items.OrderByDescending(x=>x.TanggalPengajuan))
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
                await Task.Delay(200);
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



        private PermohonanModel selectedItem;

        public PermohonanModel SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem ,value);
                if(value!=null && value.Persetujuan!=null && value.Persetujuan.Count>0)
                  this.Execute("",new PermohonanProgressView(value));
            
            }
        }

    }
}