using System.Linq;
using System.Collections.Generic;
using System;
using Xamarin.Forms;

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


    public class ProgressNode: Persetujuan
    {
        private Color _ColorStatus;

        public Color ColorStatus
        {
            get { return _ColorStatus; }
            set { SetProperty(ref _ColorStatus, value); }
        }


        private bool isVisible=true;

        public bool IsVisible
        {
            get { return isVisible; }
            set { SetProperty(ref isVisible, value); }
        }

        private PositionNode _Position;

        public PositionNode Position
        {
            get { return _Position; }
            set { SetProperty(ref _Position, value); }
        }

        public ProgressNode(Persetujuan item)
        {

            this.Message = item.Message;
            this.Created = item.Created;
            this.Role = item.Role;
            this.Status = item.Status;

            switch (item.Status)
            {
                case StatusPersetujuan.Dikembalikan:
                    ColorStatus=Color.FromHex("#F67B1C");
                    break;
                case StatusPersetujuan.Disetujui:
                    ColorStatus=Color.FromHex("#857A7A");
                    break; 
                case StatusPersetujuan.Ditolak:
                ColorStatus=Color.FromHex("#D23106");
                    break;
                case StatusPersetujuan.Selesai:
                    ColorStatus=Color.FromHex("#0B9567");
                    break;
                default:
                     ColorStatus=Color.White;
                    break;
            }
        }
    }



    
}