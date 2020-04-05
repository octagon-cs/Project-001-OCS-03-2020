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
    public partial class KkPage : OcphPage
    {
        public KkPage()
        {
            InitializeComponent();
        }
        public override void Create()
        {
            BindingContext = new KkViewModel();
        }
        public override void Edit(PermohonanModel permohonan)
        {
            base.Edit(permohonan);
            BindingContext = new KkViewModel (permohonan);
        }

    }
    public class KkViewModel : BaseViewModelSurat<KkModel>
    {
        public KkViewModel()
        {
            Load();
        }

        public KkViewModel(PermohonanModel permohonan)
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