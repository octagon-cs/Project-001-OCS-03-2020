using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models
{
    public class DocumentPenduduk:BaseNotify
    {
        public int? iddokumenpenduduk { get; set; }
        public int? idpenduduk { get; set; }
        public string jenis { get; set; }
        public string extention { get; set; }
        private string _file;

        public string file
        {
            get { return _file; }
            set { _file = value;
                if (!string.IsNullOrEmpty(value))
                {
                    HasFile = true;
                }
            }
        }

        public string typefile { get; set; }
        public int? idpersyaratan { get; set; }
        public int? idpermohonan { get; set; }
        public string nama { get; set; }
        public string deskripsi { get; set; }
        public int status { get; set; }

        public byte[] data { get; set; }

        private bool hasFile;

        public bool HasFile
        {
            get { return hasFile; }
            set { SetProperty(ref hasFile , value); }
        }


    }
}
