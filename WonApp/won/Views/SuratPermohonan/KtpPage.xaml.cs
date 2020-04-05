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
    public partial class KtpPage : OcphPage
    {
        public KtpPage()
        {
            InitializeComponent();
        }
        public override void Create()
        {
            BindingContext = new KtpViewModel();
        }
        public override void Edit(PermohonanModel permohonan)
        {
            base.Edit(permohonan);
            BindingContext = new KtpViewModel (permohonan);
        }
    }
    public class KtpViewModel : BaseViewModelSurat<ktpModel>
    {
        public KtpViewModel()
        {
            Load();
        }

        public KtpViewModel(PermohonanModel permohonan)
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