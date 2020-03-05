using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models
{
   public class PendudukModel
    {


        private string nama;

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }


        private PendudukDataModel data;

        public PendudukDataModel Data
        {
            get { return data; }
            set { data = value; }
        }



    }




    public class PendudukDataModel
    {
        private string jenisKelamin;

        public string JenisKelamin
        {
            get { return jenisKelamin; }
            set { jenisKelamin = value; }
        }

    }
}
