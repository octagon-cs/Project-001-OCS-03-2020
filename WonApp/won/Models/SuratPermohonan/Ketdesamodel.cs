using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class Ketdesamodel : BaseNotify
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
        private string _NoSurat;


        [JsonProperty("nosurat")]
        public string NoSurat
        {
            get { return _NoSurat; }
            set { SetProperty(ref _NoSurat, value); }
        }
        private string _FootCetak;


        [JsonProperty("footcetak")]
        public string FootCetak
        {
            get { return _FootCetak; }
            set { SetProperty(ref _FootCetak, value); }
        }
        private string _JudulNama;


        [JsonProperty("judulnama")]
        public string JudulNama
        {
            get { return _JudulNama; }
            set { SetProperty(ref _JudulNama, value); }
        }
        private string _JabatanNama;


        [JsonProperty("jabatanNama")]
        public string JabatanNama
        {
            get { return _JabatanNama; }
            set { SetProperty(ref _JabatanNama, value); }
        }
        private string _AtasNama;


        [JsonProperty("atasnama")]
        public string AtasNama
        {
            get { return _AtasNama; }
            set { SetProperty(ref _AtasNama, value); }
        }
        private string _NIPNama;


        [JsonProperty("nipnama")]
        public string NIPNama
        {
            get { return _NIPNama; }
            set { SetProperty(ref _NIPNama, value); }
        }
    }
}