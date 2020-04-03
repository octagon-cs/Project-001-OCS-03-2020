using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileView : ContentPage
    {
        public ProfileView()
        {
            InitializeComponent();
            BindingContext = Helper.Profile;
            Load();
        }

        private async void Load()
        {
            await CrossMedia.Current.Initialize();
          
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
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
                    }
                    else
                    {
                        file=await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions { PhotoSize = PhotoSize.Small });
                    }

                    if (file!=null)
                    {

                        using (MemoryStream ms = new MemoryStream())
                        {
                            var stream = file.GetStream();
                            stream.CopyTo(ms);
                            document.data = ms.ToArray();
                        }

                        var service = DependencyService.Get<IDocumentService>();
                        var persyaratans = await service.GetPersyaratan();
                        if (persyaratans != null)
                        {
                            var persyaratan = persyaratans.Where(x => x.Status == 1).FirstOrDefault();
                            if (persyaratan != null)
                            {
                                document.idpersyaratan = persyaratan.IdPersyaratan;
                                document.idpenduduk = Helper.Profile.idpenduduk;
                                document.typefile = "image";
                                document.extention = "jpg";
                                var result = await service.PostPhoto(document);
                                if (result != null)
                                {
                                    photo.Source = ImageSource.FromStream(() =>
                                    {
                                        var stream = file.GetStream();
                                        return stream;
                                    });
                                }
                            }
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
}