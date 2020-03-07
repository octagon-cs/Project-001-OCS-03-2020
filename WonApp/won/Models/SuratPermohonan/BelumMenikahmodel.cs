using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class BelumMenikahmodel : BaseNotify
    {

        private int _NoSurat;


        [JsonProperty("nosurat")]
        public int NoSurat
        {
            get { return _NoSurat; }
            set { SetProperty(ref _NoSurat, value); }
        }

        private int _Rt;


        [JsonProperty("rt")]
        public int Rt
        {
            get { return _Rt; }
            set { SetProperty(ref _Rt, value); }
        }
        private int _NomorSuratPengantar;


        [JsonProperty("nomorsuratpengantar")]
        public int NomorSuratPengantar
        {
            get { return _NomorSuratPengantar; }
            set { SetProperty(ref _NomorSuratPengantar, value); }
        }
        private DateTime _TanggalSuratPengantar;


        [JsonProperty("tanggalsuratpengantar")]
        public DateTime TanggalSuratPengantar
        {
            get { return _TanggalSuratPengantar; }
            set { SetProperty(ref _TanggalSuratPengantar, value); }
        }
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
        private string _TanggalCetakSurat;


        [JsonProperty("tanggalcetaksurat")]
        public string TanggalCetakSurat
        {
            get { return _TanggalCetakSurat; }
            set { SetProperty(ref _TanggalCetakSurat, value); }
        }
        private string _JudulNama;

        // [JsonProperty("nipnama")]
        // public string _NIPNama
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
            if (int.IsNullOrEmpty(NoSurat) || int.IsNullOrEmpty(Rt) || int.IsNullOrEmpty(NomorSuratPengantar) || DateTime.IsNullOrEmpty(TanggalSuratPengantar) || int.IsNullOrEmpty(NIK) || string.IsNullOrEmpty(Nama))
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
            if (string.IsNullOrEmpty(NoSurat) || Rt<=0 || string.IsNullOrEmpty(NoSuratPengantar) || TanggalSuratPengantar == new DateTime()||
                string.IsNullOrEmpty(NIK) || string.IsNullOrEmpty(Nama))
            {
                valid = false;
                ErrorMessage = "Data Tidak Boleh Kosong";
            }

        

            if (valid) ErrorMessage = "";
            return valid;
        }





    }
}