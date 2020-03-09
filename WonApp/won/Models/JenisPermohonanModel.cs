using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace won.Models
{
  public  class JenisPermohonanModel
    {
        private string jenis;
        private PermohonanType jenisPermohonan;

        public int IdJenisPermohonan { get; set; }

        public string Nama { get; set; }

        public string Jenis
        {
            get { return jenis; }
            set
            {
                jenis = value;
            }
        }


        public PermohonanType JenisPermohonan
        {
            get
            {
                if (!string.IsNullOrEmpty(Jenis))
                {
                    var text = Jenis.Replace(" ", "_");
                    return (PermohonanType)Enum.Parse(typeof(PermohonanType), text, true);
                }
                return jenisPermohonan;
            }
            set
            {
                var text = value.ToString().Replace("-", " ");
                Jenis = text;
            }
        }

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
            switch (JenisPermohonan)
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
