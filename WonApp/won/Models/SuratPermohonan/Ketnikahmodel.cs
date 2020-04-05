using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class Ketnikahmodel : BaseNotify
    {
        private int _NoSurat;


        [JsonProperty("nosurat")]
        public int NoSurat
        {
            get { return _NoSurat; }
            set { SetProperty(ref _NoSurat, value); }
        }

        private int _idSuami;

        [JsonProperty("idpenduduksuami")]
        public int IdSuami
        {
            get { return _idSuami; }
            set { SetProperty(ref _idSuami, value); }
        }

      
        private int _idIstri;


        [JsonProperty("idpendudukistri")]
        public int IdIstri
        {
            get { return _idIstri; }
            set { SetProperty(ref _idIstri, value); }
        }
       
       
        private string _Ketnikah;

        [JsonProperty("keterangan")]
        public string KetNikah
        {
            get { return _Ketnikah; }
            set { SetProperty(ref _Ketnikah, value); }
        }


        private Penduduk suami;

        [JsonIgnore]
        public Penduduk Suami
        {
            get { return suami; }
            set { SetProperty(ref suami, value); }
        }


        private Penduduk istri;

        [JsonIgnore]
        public Penduduk Istri
        {
            get { return istri; }
            set
            {
                SetProperty(ref istri, value);
            }
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
            if (IdSuami<=0 || IdIstri<=0 || NoSurat<=0 || string.IsNullOrEmpty(KetNikah))
            {
                valid = false;
                ErrorMessage = "Data Tidak Boleh Kosong";
            }

          

            if (valid) ErrorMessage = "";
            return valid;
        }
    }
  
}