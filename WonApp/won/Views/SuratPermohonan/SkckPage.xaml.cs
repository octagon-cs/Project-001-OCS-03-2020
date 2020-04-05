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
    public partial class SkckPage : OcphPage
    {
        public SkckPage()
        {
            InitializeComponent();
        }
        public override void Create()
        {
            BindingContext = new SkckViewModel();
        }
        public override void Edit(PermohonanModel permohonan)
        {
            base.Edit(permohonan);
            BindingContext = new SkckViewModel (permohonan);
        }

    }
    public class SkckViewModel : BaseViewModelSurat<Skckmodel>
    {
        public SkckViewModel()
        {
            Load();
        }

        public SkckViewModel(PermohonanModel permohonan)
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