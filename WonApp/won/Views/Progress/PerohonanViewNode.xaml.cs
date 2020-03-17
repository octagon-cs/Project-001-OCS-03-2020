using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views.Progress
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerohonanViewNode : ContentView
    {
        public PerohonanViewNode()
        {

        }
        public PerohonanViewNode(PermohonanModel item)
        {
            InitializeComponent();
            BindingContext = this;
            Load(item);
        }

        private void Load(PermohonanModel item)
        {
            if (item.Persetujuan != null)
            {
                foreach (var data in item.Persetujuan)
                {
                    var view = new BoxView() { Margin = new Thickness(0, 0, 60, 0), HeightRequest = 30, WidthRequest = 30, CornerRadius = new CornerRadius(15), 
                        VerticalOptions = LayoutOptions.Start };
                    view.BackgroundColor = Helper.GetJenisCorlor(data.Status);
                    tanggal.Text = item.TanggalPengajuan.ToLongDateString();
                    nomorPengajuan.Text = "00001";
                    jenis.Text = item.NamaPermohonan;
                    progress.Children.Add(view);
                }
            }
        }
    }
}