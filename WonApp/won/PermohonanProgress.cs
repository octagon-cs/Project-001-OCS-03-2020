using System.Linq;
using System.Collections.Generic;
using System;

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
                if(last.Status== StatusPersetujuan.Dikembalikan){
                    var role = GetBackPersetujuanRole(last.Role);
                    if(role!=null)
                        Nodes.Add(new ProgressNode(new Persetujuan{ Created=DateTime.Now, Role=role, Status=StatusPersetujuan.Diterima }));  
                }else{
                      var role = GetNextPersetujuanRole(last.Role);
                    if(role!=null)
                        Nodes.Add(new ProgressNode(new Persetujuan{ Created=DateTime.Now, Role=role, Status=StatusPersetujuan.Diterima }));  
               
                }
                
            }
        }


        public ProgressRole GetNextPersetujuanRole( ProgressRole item){
            int index = (int)item;
            if(item== ProgressRole.Admin){
                return null;
            }else{
                return (ProgressRole)index+1;
            }
        }

         public ProgressRole GetBackPersetujuanRole( ProgressRole item){
            int index = (int)item;
            if(item== ProgressRole.Pemohon){
                return null;
            }else{
                return (ProgressRole)index-1;
            }
        }

        public Persetujuan GetLastPersetujuanRole(){
            if (Model == null || Model.Persetujuan == null || Model.Persetujuan.Count <= 0){
                return ProgressRole.Pemohon;
            }

            var last = Model.Persetujuan.OrderByDescending(x=>x.Created).FirstOrDefault();
        }


        private CreateNode()
        {

        }
    }


    public class ProgressNode
    {

        public string Caption { get; set; }
        public Color ColorStatus { get; set; }
        public PermohonanProgress(Persetujuan item)
        {
            Caption = item.Status.ToString();
            switch (item.Status)
            {
                case StatusPersetujuan.Dikembalikan:
                    ColorStatus=Color.Yellow;
                    break;
                case StatusPersetujuan.Disetujui:
                    ColorStatus=Color.Grey;
                    break;
                case StatusPersetujuan.Ditolak:
                ColorStatus=Color.Red;
                    break;
                case StatusPersetujuan.Selesai:
                    ColorStatus=Color.Green;
                    break;
                default:
                     ColorStatus=Color.Diterima;
                    break;
            }
        }
    }
}