using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using won.Models;
using won.Models.SuratPermohonan;
using won.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views.SuratPermohonan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsahaPage : OcphPage
    {
        public UsahaPage()
        {
            InitializeComponent();

        }
        public override void Create()
        {
            BindingContext = new UsahaViewModel();
        }
        public override void Edit(PermohonanModel permohonan)
        {
            base.Edit(permohonan);
            BindingContext = new UsahaViewModel (permohonan);
        }
    }
    public class UsahaViewModel : BaseViewModelSurat<Usahamodel>
    {
        public UsahaViewModel()
        {
            Load();
        }

        public UsahaViewModel(PermohonanModel permohonan)
        {
            SetValue(permohonan);
        }

        public override async void SetValue(PermohonanModel permohonan)
        {
            await Task.Delay(500);
            await Load();
            Permohonan = permohonan;
           // Model.KeteranganPindah = permohonan.Data.GetValue("keteranganpindah").ToString();
           
        }

    }
}