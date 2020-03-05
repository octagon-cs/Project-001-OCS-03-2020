using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class Kelahiranmodel : BaseNotify
    {

        private string _NoSurat;


        [JsonProperty("nosurat")]
        public string NoSurat
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
        private string _Tanggal;


        [JsonProperty("tanggal")]
        public string Tanggal
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


        [JsonProperty("jabatannama")]
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
        public string nipnama
        {
            get { return _NIPNama; }
            set { SetProperty(ref _NIPNama, value); }
        }
    }
}