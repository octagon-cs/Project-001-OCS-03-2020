using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.Services;
using won.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocumentPendudukView : ContentPage
    {
        private DocumentPendudukViewModel vm;

        public DocumentPendudukView()
        {
            InitializeComponent();
            BindingContext=vm = new DocumentPendudukViewModel();
        }

        private void detailAction(object sender, EventArgs e)
        {

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
                            document.typefile= fileNames[fileNames.Length - 1];
                            document.data = fileData.DataArray;
                        }
                    }

                    if (!string.IsNullOrEmpty(document.extention))
                    {
                        var service = DependencyService.Get<IDocumentService>();
                        document.idpersyaratan = persyaratan.idpersyaratan;
                        document.idpenduduk = Helper.Profile.idpenduduk;
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

    public class DocumentPendudukViewModel : BaseViewModel
    {
        public ObservableCollection<DocumentPenduduk> Items { get; set; }
        public Command LoadItemsCommand { get; }

        public DocumentPendudukViewModel()
        {
            Items = new ObservableCollection<DocumentPenduduk>();
            LoadItemsCommand = new Command(LoadAction);
            LoadAction(null);
        }

        private async void LoadAction(object obj)
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                Items.Clear();
                var datas = await DocumentPenduduk.GetDocumentPenduduk(Helper.Profile.idpenduduk);
                foreach (var item in datas)
                {
                    Items.Add(item);
                }
                var persyaratans = await DocumentPenduduk.GetPersyaratan();
                foreach (var item in persyaratans.Where(x=>x.Status>0))
                {
                    var doc = datas.Where(x => x.idpersyaratan == item.IdPersyaratan).FirstOrDefault();
                    if (doc == null)
                    {
                        Items.Add(new Models.DocumentPenduduk { idpersyaratan = item.IdPersyaratan, nama = item.Nama, status = item.Status });
                    }
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
    }
}