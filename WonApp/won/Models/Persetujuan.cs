using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models
{
    public class Persetujuan:BaseNotify
    {
        private DateTime _created;
        private StatusPersetujuan status;
        private ProgressRole role;
        private string message;

        [JsonProperty("created")]
        public DateTime Created
        {
            get { return _created; }
            set { SetProperty(ref _created,value); }
        }

        [JsonProperty("message")]
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }


        [JsonProperty("role")]
        public ProgressRole Role
        {
            get { return role; }
            set { SetProperty(ref role, value); }
        }


        [JsonProperty("status")]
        public StatusPersetujuan Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }

    }
}
