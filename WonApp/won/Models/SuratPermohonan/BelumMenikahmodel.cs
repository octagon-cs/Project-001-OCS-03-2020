using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class BelumMenikahmodel : BaseNotify
    {

        private string _NoSurat;


        [JsonProperty("nosurat")]
        public string NoSurat
        {
            get { return _NoSurat; }
            set { SetProperty(ref _NoSurat, value); }
        }

        private int _Rt;


        [JsonProperty("rt")]
        public int Rt
        {
            get { return _Rt; }
            set { SetProperty(ref _Rt, value); }
        }
        private string _NomorSuratPengantar;


        [JsonProperty("nomorsuratpengantar")]
        public string NoSuratPengantar
        {
            get { return _NomorSuratPengantar; }
            set { SetProperty(ref _NomorSuratPengantar, value); }
        }
        private DateTime _TanggalSuratPengantar;


        [JsonProperty("tanggalsuratpengantar")]
        public DateTime TanggalSuratPengantar
        {
            get { return _TanggalSuratPengantar; }
            set { SetProperty(ref _TanggalSuratPengantar, value); }
        }
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
        private DateTime _TanggalCetakSurat;


        [JsonProperty("tanggalcetaksurat")]
        public DateTime TanggalCetakSurat
        {
            get { return _TanggalCetakSurat; }
            set { SetProperty(ref _TanggalCetakSurat, value); }
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
        public string NIPNama
        {
            get { return _NIPNama; }
            set { SetProperty(ref _NIPNama, value); }
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
            if (string.IsNullOrEmpty(NIK) || Rt<=0 || string.IsNullOrEmpty(NoSuratPengantar) ||
                string.IsNullOrEmpty(NoSurat) || TanggalSuratPengantar==new DateTime())
            {
                valid = false;
                ErrorMessage = "Data Tidak Boleh Kosong";
            }


            if (valid) ErrorMessage = "";
            return valid;
        }





    }
}