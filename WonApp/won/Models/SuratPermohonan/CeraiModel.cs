using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class CeraiModel : BaseNotify
    {

        private string _NIKSuami;


        [JsonProperty("niksuami")]
        public string NIKSuami
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

        private string _NIKIstri;


        [JsonProperty("nikistri")]
        public string NIKIstri
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
        private string _NoSurat;


        [JsonProperty("nosurat")]
        public string NOSurat
        {
            get { return _NoSurat; }
            set { SetProperty(ref _NoSurat, value); }
        }

        private string _ketCerai;


        [JsonProperty("ketcerai")]
        public string ketCerai
        {
            get { return _ketCerai; }
            set { SetProperty(ref _ketCerai, value); }
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


        [JsonProperty("jabatanama")]
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
        public string NIKNama
        {
            get { return _NIPNama; }
            set { SetProperty(ref _NIPNama, value); }
        }



       
    }
}
