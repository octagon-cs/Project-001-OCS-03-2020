using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class Ketnikahmodel : BaseNotify
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
        private string _Ketnikah;


        [JsonProperty("ketnikah")]
        public string KetNikah
        {
            get { return _Ketnikah; }
            set { SetProperty(ref _Ketnikah, value); }
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
            if (NIKSuami<=0 || string.IsNullOrEmpty(NamaSuami) || NIKIstri<=0 || string.IsNullOrEmpty(NamaIstri) || NoSurat<=0 || string.IsNullOrEmpty(KetNikah))
            {
                valid = false;
                ErrorMessage = "Data Tidak Boleh Kosong";
            }

          

            if (valid) ErrorMessage = "";
            return valid;
        }
    }
  
}