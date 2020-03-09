using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace won.Models
{
    public class PermohonanModel :  BaseNotify
    {

        private int idPermohonan;
        private int idPenduduk;
        private DateTime tanggalPengajuan;

        [JsonProperty("idpermohonan")]
        public int IdPermohonan
        {
            get { return idPermohonan; }
            set { SetProperty(ref idPermohonan, value); }
        }


        [JsonProperty("idpenduduk")]
        public int IdPenduduk
        {
            get { return idPenduduk; }
            set { idPenduduk = value; }
        }

        [JsonProperty("tanggalpersetujuan")]
        public DateTime TanggalPengajuan
        {
            get { return tanggalPengajuan; }
            set { SetProperty(ref tanggalPengajuan, value); }
        }


        [JsonProperty("persetujuan")]
        public List<Persetujuan> Persetujuan { get; set; } = new List<Persetujuan>();



        [JsonProperty("status")]
        private StatusPersetujuan status;

        public StatusPersetujuan Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }



        [JsonProperty("data")]
        public dynamic Data { get; set; }



        private string namaPermohonan;
        private string jenis;
        private PermohonanType jenisPermohonan;

        [JsonProperty("namapermohonan")]
        public string NamaPermohonan
        {
            get { return namaPermohonan; }
            set { SetProperty(ref namaPermohonan ,value); }
        }


        [JsonProperty("jenis")]
        public string Jenis
        {
            get { return jenis; }
            set {
                SetProperty(ref jenis, value);
            }
        }


        public PermohonanType JenisPermohonan
        {
            get {
                if (!string.IsNullOrEmpty(Jenis))
                {
                    var text = Jenis.Replace(" ", "_");
                    return (PermohonanType)Enum.Parse(typeof(PermohonanType), text, true);
                }
                return jenisPermohonan; 
            }
            set
            {
                var text = value.ToString().Replace("-", " ");
                Jenis = text;
            }
        }

    }
}
