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
    public partial class SudahmenikahPage : OcphPage
    {
        public SudahmenikahPage()
        {
            InitializeComponent();
        }
        public override void Create()
        {
            BindingContext = new SudahmenikahViewModel();
        }
        public override void Edit(PermohonanModel permohonan)
        {
            base.Edit(permohonan);
            BindingContext = new SudahmenikahViewModel (permohonan);
        }
    }
    public class SudahmenikahViewModel : BaseViewModelSurat<SudahMenikahmodel>
    {
        public SudahmenikahViewModel()
        {
            Load();
        }

        public SudahmenikahViewModel(PermohonanModel permohonan)
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