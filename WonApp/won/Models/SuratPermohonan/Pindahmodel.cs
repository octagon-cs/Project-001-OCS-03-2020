using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class PindahModel : BaseNotify
    {
      
        private string _Nama;

        [JsonProperty("nama")]
        public string Nama
        {
            get { return _Nama; }
            set { SetProperty(ref _Nama, value); }
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
            set { SetProperty(ref _PindahKe, value); }
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
            if (string.IsNullOrEmpty(NIK) || string.IsNullOrEmpty(Nama) ||
                TanggalPindah == new DateTime() || string.IsNullOrEmpty(KeteranganPindah) || string.IsNullOrEmpty(PindahKe))
            {
                valid = false;
                ErrorMessage = "Data Tidak Boleh Kosong";
            }

            if (valid) ErrorMessage = "";
            return valid;
        }
    }

}