using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace won.Models
{
    public class PermohonanModel
    {
        [JsonProperty("idpermohonan")]
        public int IdPermohonan { get; set; }
        public List<Persetujuan> Persetujuan { get; set; }
        
    }

    public class Persetujuan{
        public DateTime Created { get; set; }

        public string Message { get; set; }
        public ProgressRole Role {get;set;}

        public  StatusPersetujuan Status{get;set;}
    }
}