using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.Views.Progress;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PermohonanProgressView : ContentPage
    {

        public PermohonanProgressView(Models.PermohonanModel value)
        {
            InitializeComponent();
            var index = 0;
            ProgressNode lastPersetujuan = null;
            for (int i = 0; i < value.Persetujuan.Count; i++)
            {
                var node = new ProgressNode(value.Persetujuan[i]);
                if (index == 0)
                    node.Position = PositionNode.Start;
                else if (index == value.Persetujuan.Count - 1)
                {
                    lastPersetujuan = node;
                }

                if (lastPersetujuan == null)
                {
                    Main.Children.Add(new NodeView(node));
                }
             
                index++;
            }

            if(lastPersetujuan!=null)
            {
                var lasindex = (int)lastPersetujuan.Role;
                var totalIndex = typeof(ProgressRole).GetEnumValues();


                if (lastPersetujuan.Status == StatusPersetujuan.Dikembalikan)
                    lasindex = lasindex - 1;


                if (lasindex < totalIndex.Length - 1)
                {
                  
                    for (int i = lasindex; i < totalIndex.Length; i++)
                    {
                        var node = new ProgressNode(new Persetujuan());
                        node.Role = (ProgressRole)i;
                        node.Status = StatusPersetujuan.None;
                        if (i == totalIndex.Length - 1)
                        {
                            node.Position = PositionNode.End;
                        }

                        Main.Children.Add(new NodeView(node));

                    }
                }
                else
                {
                    lastPersetujuan.Position = PositionNode.End;
                    Main.Children.Add(new NodeView(lastPersetujuan));
                }
            }
          
        }

      /*  protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width < height)
            {
                Main.Orientation = StackOrientation.Vertical;
            }
            else
            {
                Main.Orientation = StackOrientation.Horizontal;
            }
        }*/
    }

}