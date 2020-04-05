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
    public partial class TidakmampuPage : OcphPage
    {
        public TidakmampuPage()
        {
            InitializeComponent();

        }
        public override void Create()
        {
            BindingContext = new TidakmampuViewModel();
        }
        public override void Edit(PermohonanModel permohonan)
        {
            base.Edit(permohonan);
            BindingContext = new TidakmampuViewModel(permohonan);
        }
    }
    public class TidakmampuViewModel : BaseViewModelSurat<TidakMampumodel>
    {
        public TidakmampuViewModel()
        {
            Load();
        }

        public TidakmampuViewModel(PermohonanModel permohonan)
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