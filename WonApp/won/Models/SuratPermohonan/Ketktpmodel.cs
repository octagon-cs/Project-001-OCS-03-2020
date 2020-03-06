using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class Ketktpmodel : BaseNotify
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
        private int _NoSurat;


        [JsonProperty("nosurat")]
        public int NoSurat
        {
            get { return _NoSurat; }
            set { SetProperty(ref _NoSurat, value); }
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


        // [JsonProperty("jabatanNama")]
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
        // public string NIPNama
        // {
        //     get { return _NIPNama; }
        //     set { SetProperty(ref _NIPNama, value); }
        // }
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
            if (int.IsNullOrEmpty(NIK) || string.IsNullOrEmpty(Nama) || int.IsNullOrEmpty(NoSurat))
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