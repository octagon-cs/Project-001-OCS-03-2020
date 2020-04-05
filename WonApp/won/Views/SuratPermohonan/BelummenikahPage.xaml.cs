using System.Threading.Tasks;
using won.Models;
using won.Models.SuratPermohonan;
using won.ViewModels;
using Xamarin.Forms.Xaml;

namespace won.Views.SuratPermohonan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BelummenikahPage : OcphPage
    {
        public BelummenikahPage()
        { 
            InitializeComponent();
        }
        public override void Create()
        {
            BindingContext = new BelummenikahViewModel();
        }
        public override void Edit(PermohonanModel permohonan)
        {
            base.Edit(permohonan);
            BindingContext = new BelummenikahViewModel(permohonan);
        }


    }
    public class BelummenikahViewModel : BaseViewModelSurat<BelumMenikahmodel>
    {
        public BelummenikahViewModel()
        {
            Load();
        }

        public BelummenikahViewModel(PermohonanModel permohonan)
        {
            SetValue(permohonan);
        }

        public override async void SetValue(PermohonanModel permohonan)
        {
            await Task.Delay(500);
            await Load();
            Permohonan = permohonan;
            Model.Nama = Helper.Profile.nama;
            Model.NIK = Helper.Profile.nik;
            Model.NoSurat = permohonan.Data.GetValue("nosurat").ToString();
        }

    }
}