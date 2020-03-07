using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models
{
    public class Persetujuan
    {
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("role")]
        public ProgressRole Role { get; set; }

        [JsonProperty("status")]
        public StatusPersetujuan Status { get; set; }
    }
}
