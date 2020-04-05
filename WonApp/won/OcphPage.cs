using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using won.Models;
using won.Services;
using Xamarin.Forms;

namespace won
{
    public  class OcphPage : ContentPage
    {
        public virtual void Create() { }
        public virtual void Edit(PermohonanModel permohonan) { }

        public async void uploadAction(object sender, EventArgs e)
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

}
