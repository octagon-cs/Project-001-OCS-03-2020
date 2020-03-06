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
        private string _TanggalMeninggal;


        [JsonProperty("tanggalmeninggal")]
        public string TanggalMeninggal
        {
            get { return _TanggalMeninggal; }
            set { SetProperty(ref _TanggalMeninggal, value); }
        }
        private string _TempatMeninggal;


        [JsonProperty("tempatmeninggal")]
        public string TempatMeninggal
        {
            get { return _TempatMeninggal; }
            set { SetProperty(ref _TempatMeninggal, value); }
        }
        private string _DisebabkanKarena;


        [JsonProperty("disebabkankarena")]
        public string DisebabkanKarena
        {
            get { return _DisebabkanKarena; }
            set { SetProperty(ref +_DisebabkanKarena, value); }
        }
        private string _DikebumikanDi;


        [JsonProperty("dikebumikan")]
        public string DikebumikanDi
        {
            get { return _DikebumikanDi; }
            set { SetProperty(ref _DikebumikanDi, value); }
        }
         private string _HariDiKebumikanDi;


        [JsonProperty("haridikebumikan")]
        public string HariDiKebumikanDi
        {
            get { return _HariDiKebumikanDi; }
            set { SetProperty(ref _HariDikebumikanDi, value); }
        }
    }
}