using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
  public  class CeraiModel:BaseNotify
    {

        private string nikSuami;


        [JsonProperty("niksuami")]
        public string NIKSuami
        {
            get { return nikSuami; }
            set { SetProperty(ref nikSuami ,value); }
        }

    }
}
