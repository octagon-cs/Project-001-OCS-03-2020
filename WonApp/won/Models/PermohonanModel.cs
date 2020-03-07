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
    }
}
