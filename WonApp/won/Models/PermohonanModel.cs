using System.Collections.Generic;

namespace won.Models
{
    public class PermohonanModel
    {
        public List<Persetujuan> Persetujuan { get; set; }
        
    }



    public class Persetujuan{
        public Date Created { get; set; }

        public string Message { get; set; }
        public ProgressRole Role {get;set;}

        public  StatusPersetujuan Status{get;set;}
    }
}