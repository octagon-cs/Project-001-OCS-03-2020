using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Infopersyaratan : ContentPage
    {
        public Infopersyaratan()
        {
            InitializeComponent();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }



    public class InfopersyaratanViewModel:BaseViewModel
    {
        public InfopersyaratanViewModel(string deskripsi, List<Models.Persyaratan> persyaratan)
        {
            Deskripsi = deskripsi;
            Persyaratan = new ObservableCollection<Persyaratan>();
            foreach (var item in persyaratan)
            {
                Persyaratan.Add(item);
            }
        }


        private string _deskripsi;

        public string Deskripsi
        {
            get { return _deskripsi; }
            set { SetProperty(ref _deskripsi ,value); }
        }


        private ObservableCollection<Persyaratan> _persyaratan;

        public ObservableCollection<Persyaratan> Persyaratan
        {
            get { return _persyaratan; }
            set { SetProperty(ref _persyaratan ,value); }
        }




    }

}