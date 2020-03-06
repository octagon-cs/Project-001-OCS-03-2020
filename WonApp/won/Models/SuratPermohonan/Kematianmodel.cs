using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class KematianModel : BaseNotify
    {

        private int _NIK;


        [JsonProperty("nik")]
        public int NIK
        {
            get { return _NIK; }
            set { SetProperty(ref _NIK, value); }
        }

        private string _Nama;


        [JsonProperty("nama")]
        public string Nama
        {
            get { return _Nama; }
            set { SetProperty(ref _Nama, value); }
        }
        private string _TempatLahir;


        [JsonProperty("tempatlahir")]
        public string TempatLahir
        {
            get { return _TempatLahir; }
            set { SetProperty(ref _TempatLahir, value); }
        }
        private DateTime _TanggalLahir;


        [JsonProperty("tanggallahir")]
        public DateTime Tanggallahir
        {
            get { return _TanggalLahir; }
            set { SetProperty(ref _TanggalLahir, value); }
        }
        private DateTime _TanggalMeninggal;


        [JsonProperty("tanggalmeninggal")]
        public DateTime TanggalMeninggal
        {
            get { return _TanggalMeninggal; }
            set { SetProperty(ref _TanggalMeninggal, value); }
        }
        private string _TempatMeninggal;


        [JsonProperty("tempatmeninggal")]
        public string TempatMeninggal
        {
            get { return _TempatMeninggal; }
            set { SetProperty(ref _TempatMeninggal, value); }
        }
        private string _DisebabkanKarena;


        [JsonProperty("disebabkankarena")]
        public string DisebabkanKarena
        {
            get { return _DisebabkanKarena; }
            set { SetProperty(ref +_DisebabkanKarena, value); }
        }
        private string _DikebumikanDi;


        [JsonProperty("dikebumikandi")]
        public string DikebumikanDi
        {
            get { return _DikebumikanDi; }
            set { SetProperty(ref _DikebumikanDi, value); }
        }
         private DateTime _HariTanggalDikebumikan;


        [JsonProperty("haritanggaldikebumikan")]
        public DateTime HariTanggalDikebumikan
        {
            get { return _HariTanggalDikebumikan; }
            set { SetProperty(ref _HariTanggalDikebumikan, value); }
        }
    }
     public override bool Valid
        {
            get
            {
                return Validation();

            }
        }

        private bool Validation()
        {
            var valid = true;
            if (int.IsNullOrEmpty(NIK) || string.IsNullOrEmpty(Nama) || string.IsNullOrEmpty(TempatLahir) || DateTime.IsNullOrEmpty(Tanggallahir) || DateTime.IsNullOrEmpty(TanggalMeninggal) || string.IsNullOrEmpty(TempatMeninggal) || string.IsNullOrEmpty(DisebabkanKarena) || string.IsNullOrEmpty(DikebumikanDi) || string.IsNullOrEmpty(HariTanggalDikebumikan))
            {
                valid = false;
                ErrorMessage = "Data Tidak Boleh Kosong";
            }

            // if (Password != ConfirmPassword)
            // {
            //     valid = false;
            //     ErrorMessage = "Email dan Password Tidak Sama";
            // }
            // const string pattern = @"^(? !\.)(""([^""\r\\] |\\[""\r\\])*""|" + @"([-a - z0 - 9!#$%&’*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            // var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            // if (regex.IsMatch(Email))
            // {
            //     ErrorMessage = "Email Anda Tidak Valid";valid = false;
            // }

            if (valid) ErrorMessage = "";
            return valid;
        }
}