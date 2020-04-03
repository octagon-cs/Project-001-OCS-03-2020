using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models
{
   public class Persyaratan:BaseNotify
    {
        public int IdPersyaratan { get; set; }
        public int IdDetailPersyaratan { get; set; }
        public string Nama { get; set; }
        public string Deskripsi { get; set; }
        public int Status { get; set; }

        private bool _NoHaveData=false;

        public bool NoHaveData
        {
            get { return _NoHaveData; }
            set {SetProperty(ref _NoHaveData , value); }
        }


        private bool _HaveData=true;

        public bool HaveData
        {
            get { return _HaveData; }
            set { SetProperty(ref _HaveData , value); }
        }

    }
}
