using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace won.Models
{
  public  class JenisPermohonanModel
    {
        public int IdJenisPermohonan { get; set; }

        public string Nama { get; set; }

        public string Deskripsi { get; set; }

        public List<string> Persyaratan { get; set; }


        [JsonIgnore]
        public Command BuatPermohonanCommand { get; set; } 
        [JsonIgnore]
        public Command DetailCommand { get; set; } 

        public JenisPermohonanModel()
        {
            BuatPermohonanCommand = new Command(CreateAction);
            DetailCommand = new Command(DetailAction);
        }

        private void DetailAction(object obj)
        {
            throw new NotImplementedException();
        }

        private void CreateAction(object obj)
        {
            throw new NotImplementedException();
        }
    }

}
