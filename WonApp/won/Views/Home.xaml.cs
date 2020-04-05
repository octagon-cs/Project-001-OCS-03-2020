using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.ViewModels;
using won.Views.Progress;
using won.Views.SuratPermohonan;
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
            
        }


        private async void Vm_OnExecute(string ev, object data)
        {

            await Navigation.PushAsync((Page)data);
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

        private async void ProgressBar_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var progress = (ProgressBar)sender;
         
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            TappedEventArgs events = (TappedEventArgs)e;
            PermohonanModel value = (PermohonanModel)events.Parameter;
            if (value != null && value.Persetujuan != null && value.Persetujuan.Count > 0)
            {
                Navigation.PushAsync(new PermohonanProgressView(value));
            }
        }

        private void EditGesture(object sender, EventArgs e)
        {
            TappedEventArgs events = (TappedEventArgs)e;
            PermohonanModel value = (PermohonanModel)events.Parameter;

            OcphPage page = null;
            switch (value.JenisPermohonan)
            {
                case PermohonanType.Pengantar_KTP:
                    page = new Views.SuratPermohonan.KtpPage();
                    break;
                case PermohonanType.Pengantar_KK:
                    page = new Views.SuratPermohonan.KkPage();
                    break;
                case PermohonanType.Tidak_Mampu:
                    page = new Views.SuratPermohonan.TidakmampuPage();
                    break;
                case PermohonanType.Keterangan_Domisili:
                    page = new Views.SuratPermohonan.DomisiliPage();
                    break;
                case PermohonanType.Keterangan_SKCK:
                    page = new Views.SuratPermohonan.SkckPage();
                    break;
                case PermohonanType.Keterangan_Usaha:
                    page = new Views.SuratPermohonan.UsahaPage();
                    break;
                case PermohonanType.Penguasaan_Tanah:
                    page = new Views.SuratPermohonan.TanahPage();
                    break;
                case PermohonanType.Keterangan_Desa:
                    break;
                case PermohonanType.Keterangan_Cerai:
                    page = new Views.SuratPermohonan.CeraiPage();
                    break;
                case PermohonanType.Keterangan_eKTP:
                    page = new Views.SuratPermohonan.KtpPage();
                    break;
                case PermohonanType.Keterangan_Nikah:
                    page = new Views.SuratPermohonan.SudahmenikahPage();
                    break;
                case PermohonanType.Kelahiran:
                    page = new Views.SuratPermohonan.KelahiranPage();
                    break;
                case PermohonanType.Sudah_Menikah:
                    page = new Views.SuratPermohonan.SudahmenikahPage();
                    break;
                case PermohonanType.Belum_Menikah:
                    page = new Views.SuratPermohonan.BelummenikahPage();
                    break;
                case PermohonanType.Kematian:
                    page = new Views.SuratPermohonan.KematianPage();
                    break;
                case PermohonanType.Keterangan_Lainnya:
                    page = new Views.SuratPermohonan.LainnyaPage();
                    break;
                case PermohonanType.Pindah:
                    page = new Views.SuratPermohonan.PindahPage();
                    break;
                default:
                    break;
            }

            if (page == null)
            {
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Info",
                    Message = "Layanan ini Belum Tersedia",
                    Cancel = "OK"
                }, "message");
            }
            else
            {
                page.Edit(value);
                Helper.GoPage(page);
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
            DetailCommand = new Command(DetailAction);
            LoadItemsCommand.Execute(null);

        }

        private void DetailAction(object obj)
        {
            PermohonanModel value = (PermohonanModel)obj; 
            if (value != null && value.Persetujuan != null && value.Persetujuan.Count > 0)
                this.Execute("", new PermohonanProgressView(value));
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
                await Task.Delay(500);
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
                await Task.Delay(500);
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


        private Command _DetailCommand;

        public Command DetailCommand
        {
            get { return _DetailCommand; }
            set { SetProperty(ref _DetailCommand , value); }
        }


    }
}