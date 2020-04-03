using Newtonsoft.Json.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using won.Models;
using won.Models.SuratPermohonan;
using won.Services;
using won.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views.SuratPermohonan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PindahPage : ContentPage
    {
        public PindahPage()
        {
            InitializeComponent();
         //   BindingContext = new PindahViewModel();
        }

        private async void uploadAction(object sender, EventArgs e)
        {
            try
            {
                TappedEventArgs events = (TappedEventArgs)e;
                DocumentPenduduk persyaratan = (DocumentPenduduk)events.Parameter;
                string action = await DisplayActionSheet("Pilih ", "Cancel", null, "Camera", "File");
                var document = new DocumentPenduduk();
                if (!string.IsNullOrEmpty(action))
                {
                    MediaFile file = null;
                    if (action == "Camera")
                    {
                        file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                        {
                            AllowCropping = true,
                            PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
                            Directory = "Sample",
                            Name = "test.jpg"
                        });
                        document.typefile = "image";
                        document.extention = "jpg";
                        using (MemoryStream ms = new MemoryStream())
                        {
                            var stream = file.GetStream();
                            stream.CopyTo(ms);
                            document.data = ms.ToArray();
                        }
                    }
                    else
                    {
                        var fileData = await Plugin.FilePicker.CrossFilePicker.Current.PickFile();
                        if (fileData != null)
                        {
                            var fileNames = fileData.FileName.Split('.');
                            document.extention = fileNames[fileNames.Length - 1];
                            document.typefile = fileNames[fileNames.Length - 1];
                            document.data = fileData.DataArray;
                        }
                    }

                    if (!string.IsNullOrEmpty(document.extention))
                    {
                        var service = DependencyService.Get<IDocumentService>();
                        var result = await service.PostPhoto(document);
                        if (result != null)
                        {
                            persyaratan.file = result.file;
                            persyaratan.iddokumenpenduduk = result.iddokumenpenduduk;

                        }
                    }
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
    public class PindahViewModel : BaseViewModel
    {
        public PindahModel Model { get; set; } = new Models.SuratPermohonan.PindahModel ();
        private PermohonanModel permohonan;

        public ObservableCollection<DocumentPenduduk> Persyaratan { get; set; } = new ObservableCollection<DocumentPenduduk>();
        public PindahViewModel(PermohonanModel value)
        {
           
            permohonan = value;
            Model.KeteranganPindah = value.Data.GetValue("keteranganpindah").ToString();
            Model.PindahKe = value.Data.GetValue("pindahke").ToString();
            Model.TanggalPindah = DateTime.Parse( value.Data.GetValue("tanggalpindah").ToString());
            Load();

        }

        public PindahViewModel()
        {
            Load();
        }

        public async void Load()
        {
            Model.NIK =Helper.Profile.nik;
            Model.PropertyChanged += Model_PropertyChanged;
          
            if (permohonan != null)
            {
                var _Persyaratan =  await DocumentPenduduk.GetDocumentByPermohonanId(permohonan.IdPermohonan);
                foreach (var item in _Persyaratan)
                {
                    Persyaratan.Add(item);
                }
            }
            else
            {
                var jenisPermohonan = await JenisPermohonan.Get();
                var jenis = jenisPermohonan.Where(x => x.JenisPermohonan == PermohonanType.Pindah).FirstOrDefault();

                foreach (var item in jenis.Persyaratan)
                {
                    var data = new Models.DocumentPenduduk
                    {
                        idpersyaratan = item.IdDetailPersyaratan,
                        idpenduduk = Helper.Profile.idpenduduk,
                        nama = item.Nama
                    };

                    if (item.Status == 0)
                        data.idpermohonan = permohonan.IdPermohonan;
                        
                    Persyaratan.Add(data);
                }
            }

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


                if (permohonan == null)
                {
                    var jenisPermohonan = await JenisPermohonan.Get();
                    var jenis = jenisPermohonan.Where(x => x.JenisPermohonan == PermohonanType.Pindah).FirstOrDefault();
                    var lurah = await Pejabat.GetLurah();
                    if (jenis != null)
                    {
                        var idpenduduk = Helper.Profile.idpenduduk;
                        permohonan = new PermohonanModel()
                        {
                            IdPejabat = lurah.IdPejabat,
                            IdPenduduk = Convert.ToInt32(idpenduduk),
                            IdJenisPermohonan = jenis.IdJenisPermohonan,
                            TanggalPengajuan = DateTime.Now,
                            Data = JObject.FromObject(Model),
                            Status = StatusPersetujuan.Baru
                        };
                        var result = await PermohonanService.Create(permohonan);
                        if (result != null)
                        {
                            Helper.Permohonan.Add(result);
                            MessagingCenter.Send(new MessagingCenterAlert { Cancel = "OK", Message = "Permohonan Anda Berhasil dibuat !", Title = "Info" }, "message");
                        }
                    }
                }
                else
                {
                    permohonan.Data = JObject.FromObject(Model);
                    var result = await PermohonanService.Put(permohonan);
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