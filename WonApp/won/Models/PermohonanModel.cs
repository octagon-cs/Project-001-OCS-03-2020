using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

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

        [JsonProperty("tanggalpengajuan")]
        public DateTime TanggalPengajuan
        {
            get { return tanggalPengajuan; }
            set { SetProperty(ref tanggalPengajuan, value); }
        }


        [JsonProperty("persetujuan")]
        public List<Persetujuan> Persetujuan { get; set; }



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

        private double progress;
        [JsonIgnore]
        public double Progress
        {
            get
            {
                var datas = Persetujuan.OrderBy(x => x.Created).ToList();
                var lastPersetujuan = datas[datas.Count - 1];


                if (lastPersetujuan!=null)
                {
                    var lastIndex = (int)lastPersetujuan.Role;
                    if(lastPersetujuan.Status == StatusPersetujuan.Selesai)
                    {
                        ProgressColor = Color.FromHex("#0B9567");
                        return 1;
                    }else if(lastPersetujuan.Status == StatusPersetujuan.Ditolak)
                    {
                        ProgressColor = Color.FromHex("#D23106");
                        return 1;
                    }else 
                    {
                        var lastValue = (Convert.ToDouble(lastIndex) + 1) / Convert.ToDouble(4);
                        if(lastPersetujuan.Status == StatusPersetujuan.Dikembalikan)
                            lastValue = (Convert.ToDouble(lastIndex)) / Convert.ToDouble(4);
                        if (lastValue <= 0.25)
                            ProgressColor= Color.White;
                        else if (lastValue <= 0.75)
                            ProgressColor = Color.FromHex("#F67B1C");
                        else if (lastValue <= 1)
                            ProgressColor = Color.FromHex("#0B9567");
                        return lastValue;
                    }
                }
                return 0;
            }
            set
            {
                SetProperty(ref progress, value);
            }
        }


        private Color progressColor;
        [JsonIgnore]
        public Color ProgressColor
        {
            get { return progressColor; }
            set { SetProperty(ref progressColor ,value); }
        }


    }
}
