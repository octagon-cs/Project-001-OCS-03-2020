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
        private int _NomorSuratPengantar;


        [JsonProperty("nomorsuratpengantar")]
        public int NomorSuratPengantar
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
        private string _TanggalCetakSurat;


        [JsonProperty("tanggalcetaksurat")]
        public string TanggalCetakSurat
        {
            get { return _TanggalCetakSurat; }
            set { SetProperty(ref _TanggalCetakSurat, value); }
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
            if (string.IsNullOrEmpty(NoSurat) || Rt<=0 || NomorSuratPengantar<=0 || TanggalSuratPengantar==new DateTime() || string.IsNullOrEmpty( NIK)|| string.IsNullOrEmpty(Nama))
            {
                valid = false;
                ErrorMessage = "Data Tidak Boleh Kosong";
            }

          

            if (valid) ErrorMessage = "";
            return valid;
        }

    }
}