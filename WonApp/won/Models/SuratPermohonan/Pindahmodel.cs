using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class KematianModel : BaseNotify
    {

        private string _NIK;


        [JsonProperty("nik")]
        public string NIK
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
        public string tempatLahir
        {
            get { return _TempatLahir; }
            set { SetProperty(ref _TempatLahir, value); }
        }
        private string _TanggalLahir;


        [JsonProperty("tanggallahir")]
        public string Tanggallahir
        {
            get { return _TanggalLahir; }
            set { SetProperty(ref _TanggalLahir, value); }
        }
        private string _TanggalPindah;


        [JsonProperty("tanggalpindah")]
        public string TanggalPindah
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
        private string _TanggalInputData;


        [JsonProperty("tanggalinputdata")]
        public string TanggalInputData
        {
            get { return _TanggalInputData; }
            set { SetProperty(ref _TanggalInputData, value); }
        }
    }
}