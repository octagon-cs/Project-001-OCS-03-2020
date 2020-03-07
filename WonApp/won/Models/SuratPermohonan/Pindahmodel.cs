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
        public DateTime TanggalLahir
        {
            get { return _TanggalLahir; }
            set { SetProperty(ref _TanggalLahir, value); }
        }
        private DateTime _TanggalPindah;


        [JsonProperty("tanggalpindah")]
        public DateTime TanggalPindah
        {
            get { return _TanggalPindah; }
            set { SetProperty(ref _TanggalPindah, value); }
        }
        private string _KeteranganPindah;


        [JsonProperty("keteranganpindah")]
        public string KeteranganPindah
        {
            get { return _KeteranganPindah; }
            set { SetProperty(ref _KeteranganPindah, value); }
        }
        private string _PindahKe;


        [JsonProperty("pindahke")]
        public string PindahKe
        {
            get { return _PindahKe; }
            set { SetProperty(ref +_PindahKe, value); }
        }
        // private string _TanggalInputData;


        // [JsonProperty("tanggalinputdata")]
        // public string TanggalInputData
        // {
        //     get { return _TanggalInputData; }
        //     set { SetProperty(ref _TanggalInputData, value); }
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
            if (int.IsNullOrEmpty(NIK) || string.IsNullOrEmpty(Nama) || string.IsNullOrEmpty(TempatLahir) || DateTime.IsNullOrEmpty(TanggalLahir) || DateTime.IsNullOrEmpty(TanggalPindah) || string.IsNullOrEmpty(KeteranganPindah) || string.IsNullOrEmpty(PindahKe))
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