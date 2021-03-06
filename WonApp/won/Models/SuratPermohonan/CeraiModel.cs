﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class CeraiModel : BaseNotify
    {

        private int _NIKSuami;


        [JsonProperty("niksuami")]
        public int NIKSuami
        {
            get { return _NIKSuami; }
            set { SetProperty(ref _NIKSuami, value); }
        }
        private string _NamaSuami;


        [JsonProperty("namasuami")]
        public string NamaSuami
        {
            get { return _NamaSuami; }
            set { SetProperty(ref _NamaSuami, value); }
        }

        private int _NIKIstri;


        [JsonProperty("nikistri")]
        public int NIKIstri
        {
            get { return _NIKIstri; }
            set { SetProperty(ref _NIKIstri, value); }
        }
        private string _NamaIstri;


        [JsonProperty("namaistri")]
        public string NamaIstri
        {
            get { return _NamaIstri; }
            set { SetProperty(ref _NamaIstri, value); }
        }
        private int _NoSurat;


        [JsonProperty("nosurat")]
        public int NoSurat
        {
            get { return _NoSurat; }
            set { SetProperty(ref _NoSurat, value); }
        }

        private string _KetCerai;


        [JsonProperty("ketcerai")]
        public string KetCerai
        {
            get { return _KetCerai; }
            set { SetProperty(ref _KetCerai, value); }
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
            if (NIKSuami<=0 || string.IsNullOrEmpty(NamaSuami) || NIKIstri<=0 || string.IsNullOrEmpty(NamaIstri) ||
                NoSurat<=0 || string.IsNullOrEmpty(KetCerai))
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
