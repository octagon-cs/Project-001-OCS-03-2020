using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class Tanahmodel : BaseNotify
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
    
        private string _SebidangTanah;

        [JsonProperty("sebidangtanah")]
        public string SebidangTanah
        {
            get { return _SebidangTanah; }
            set { SetProperty(ref _SebidangTanah, value); }
        }
        private string _DigunakanUntuk;


        [JsonProperty("digunakanuntuk")]
        public string DigunakanUntuk
        {
            get { return _DigunakanUntuk; }
            set { SetProperty(ref _DigunakanUntuk, value); }
        }
        private string _SebelahUtara;


        [JsonProperty("sebelahutara")]
        public string SebelahUtara
        {
            get { return _SebelahUtara; }
            set { SetProperty(ref _SebelahUtara, value); }
        }
        private string _SebelahSelatan;


        [JsonProperty("sebelahselatan")]
        public string SebelahSelatan
        {
            get { return _SebelahSelatan; }
            set { SetProperty(ref _SebelahSelatan, value); }
        }
        private string _SebelahTimur;


        [JsonProperty("sebelahtimur")]
        public string SebelahTimur
        {
            get { return _SebelahTimur; }
            set { SetProperty(ref _SebelahTimur, value); }
        }
        private string _SebelahBarat;


        [JsonProperty("sebelahbarat")]
        public string SebelahBarat
        {
            get { return _SebelahBarat; }
            set { SetProperty(ref _SebelahBarat, value); }
        }
         private string _TerjadiPadaTahun;


        [JsonProperty("terjadipadatahun")]
        public string TerjadiPadaTahun
        {
            get { return _TerjadiPadaTahun; }
            set { SetProperty(ref _TerjadiPadaTahun, value); }
        }
         private string _DiusahakanSebagai;


        [JsonProperty("diusahakansebagai")]
        public string DiusahakanSebagai
        {
            get { return _DiusahakanSebagai; }
            set { SetProperty(ref _DiusahakanSebagai, value); }
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