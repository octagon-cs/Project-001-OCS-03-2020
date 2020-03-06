using System.Linq;
using System.Collections.Generic;
using System;
using System.Drawing;

namespace won.Models
{
    public class PermohonanProgress
    {
        private PermohonanModel Model { get; set; }
        public List<ProgressNode> Nodes{get;set;}
        public PermohonanProgress(PermohonanModel model)
        {
            Nodes= new List<ProgressNode>();
            this.Model = model;
            if (Model != null && Model.Persetujuan != null && Model.Persetujuan.Count > 0)
            {
                foreach (var item in Model.Persetujuan.OrderBy(x=>x.Created))
                {
                    Nodes.Add(new ProgressNode(item));    
                }


                var last = GetLastPersetujuanRole();
                var role = GetBackPersetujuanRole(last.Role);
                Nodes.Add(new ProgressNode(new Persetujuan { Created = DateTime.Now, Role = role, Status = StatusPersetujuan.Diterima }));
            }
        }


        public ProgressRole GetNextPersetujuanRole( ProgressRole item){
            int index = (int)item;
            if(item== ProgressRole.Lurah){
                return ProgressRole.Lurah;
            }else{
                return (ProgressRole)index+1;
            }
        }

         public ProgressRole GetBackPersetujuanRole( ProgressRole item){
            int index = (int)item;
            if(item== ProgressRole.Pemohon){
                return ProgressRole.Pemohon;
            }else{
                return (ProgressRole)index-1;
            }
        }

        public Persetujuan GetLastPersetujuanRole(){
            if (Model == null || Model.Persetujuan == null || Model.Persetujuan.Count <= 0){
                return null;
            }

            var last = Model.Persetujuan.OrderByDescending(x=>x.Created).FirstOrDefault();

            return last;
        }


    }


    public class ProgressNode
    {

        public string Caption { get; set; }
        public Color ColorStatus { get; set; }
        public ProgressNode(Persetujuan item)
        {
            Caption = item.Status.ToString();
            switch (item.Status)
            {
                case StatusPersetujuan.Dikembalikan:
                    ColorStatus=Color.Yellow;
                    break;
                case StatusPersetujuan.Disetujui:
                    ColorStatus=Color.Gray;
                    break;
                case StatusPersetujuan.Ditolak:
                ColorStatus=Color.Red;
                    break;
                case StatusPersetujuan.Selesai:
                    ColorStatus=Color.Green;
                    break;
                default:
                     ColorStatus=Color.DarkGray;
                    break;
            }
        }
    }
}