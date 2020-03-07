using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class Kelahiranmodel : BaseNotify
    {

        private int _NoSurat;


        [JsonProperty("nosurat")]
        public int NoSurat
        {
            get { return _NoSurat; }
            set { SetProperty(ref _NoSurat, value); }
        }

        private string _Hari;


        [JsonProperty("hari")]
        public string Hari
        {
            get { return _Hari; }
            set { SetProperty(ref _Hari, value); }
        }
        private DateTime _Tanggal;


        [JsonProperty("tanggal")]
        public DateTime Tanggal
        {
            get { return _Tanggal; }
            set { SetProperty(ref _Tanggal, value); }
        }
        private string _JenisKelamin;


        [JsonProperty("jeniskelamin")]
        public string JenisKelamin
        {
            get { return _JenisKelamin; }
            set { SetProperty(ref _JenisKelamin, value); }
        }
        private string _Bernama;


        [JsonProperty("bernama")]
        public string Bernama
        {
            get { return _Bernama; }
            set { SetProperty(ref _Bernama, value); }
        }
        private string _Alamat;


        [JsonProperty("alamat")]
        public string Alamat
        {
            get { return _Alamat; }
            set { SetProperty(ref _Alamat, value); }
        }
        // private string _FootCetak;


        // [JsonProperty("footcetak")]
        // public string FootCetak
        // {
        //     get { return _FootCetak; }
        //     set { SetProperty(ref _FootCetak, value); }
        // }
        // private string _JudulNama;


        // [JsonProperty("judulnama")]
        // public string JudulNama
        // {
        //     get { return _JudulNama; }
        //     set { SetProperty(ref _JudulNama, value); }
        // }
        // private string _JabatanNama;


        // [JsonProperty("jabatannama")]
        // public string JabatanNama
        // {
        //     get { return _JabatanNama; }
        //     set { SetProperty(ref _JabatanNama, value); }
        // }
        // private string _AtasNama;


        // [JsonProperty("atasnama")]
        // public string AtasNama
        // {
        //     get { return _AtasNama; }
        //     set { SetProperty(ref _AtasNama, value); }
        // }
        // private string _NIPNama;


        // [JsonProperty("nipnama")]
        // public string nipnama
        // {
        //     get { return _NIPNama; }
        //     set { SetProperty(ref _NIPNama, value); }
        // }
    
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
            if (int.IsNullOrEmpty(NoSurat) || string.IsNullOrEmpty(Hari) || DateTime.IsNullOrEmpty(Tanggal) || string.IsNullOrEmpty(JenisKelamin) || string.IsNullOrEmpty(Bernama) || string.IsNullOrEmpty(Alamat))
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
}