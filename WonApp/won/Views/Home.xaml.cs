using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }


    public class HomeViewModel
    {
        public ObservableCollection<PermohonanModel> Items { get; set; }
        public HomeViewModel()
        {

        }
    }
}