using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class PindahModel : BaseNotify
    {

        private int nik;


        [JsonProperty("nik")]
        public int NIK
        {
            get { return nik; }
            set => SetProperty(ref nik, value);
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
            if (NIK <= 0 || string.IsNullOrEmpty(Nama) || string.IsNullOrEmpty(TempatLahir) || TanggalLahir == new DateTime() ||
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