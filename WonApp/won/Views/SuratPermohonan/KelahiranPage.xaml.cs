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
    public partial class KelahiranPage : OcphPage
    {
        public KelahiranPage()
        {
            InitializeComponent();
        }
        public override void Create()
        {
            BindingContext = new KelahiranViewModel();
        }
        public override void Edit(PermohonanModel permohonan)
        {
            base.Edit(permohonan);
            BindingContext =  new KelahiranViewModel (permohonan);
        }
    }
    public class KelahiranViewModel : BaseViewModelSurat<Kelahiranmodel>
    {
        public KelahiranViewModel()
        {
            Load();
        }

        public KelahiranViewModel(PermohonanModel permohonan)
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