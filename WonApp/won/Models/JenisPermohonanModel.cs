using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace won.Models
{
  public  class JenisPermohonanModel
    {
        public int IdJenisPermohonan { get; set; }

        public string Nama { get; set; }

        public PermohonanType Jenis { get; set; }

        public string Deskripsi { get; set; }

        public List<string> Persyaratan { get; set; }


        [JsonIgnore]
        public Command BuatPermohonanCommand { get; set; } 
        [JsonIgnore]
        public Command DetailCommand { get; set; } 

        public JenisPermohonanModel()
        {
            BuatPermohonanCommand = new Command(CreateAction);
            DetailCommand = new Command(DetailAction);
        }

        private void DetailAction(object obj)
        {
            MessagingCenter.Send(new MessagingCenterAlert
            {
                Title = "Deskripsi",
                Message = Deskripsi,
                Cancel = "OK"
            }, "message");
        }

        private void CreateAction(object obj)
        {
            Page page=null;
            switch (Jenis)
            {
                case PermohonanType.Cerai:
                    page = new Views.SuratPermohonan.CeraiPage();
                    break;
                case PermohonanType.Pindah:
                    page = new Views.SuratPermohonan.PindahPage();
                    break;
                case PermohonanType.Meninggal:
                    page = new Views.SuratPermohonan.KematianPage();
                    break;
                case PermohonanType.SKCK:
                    page = new Views.SuratPermohonan.SkckPage();
                    break;
                default:
                    break;
            }

            if(page == null) {
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Info",
                    Message = "Layanan ini Belum Tersedia",
                    Cancel = "OK"
                }, "message");
            }else
                Helper.NavigateTo(page);
        }
    }

}
