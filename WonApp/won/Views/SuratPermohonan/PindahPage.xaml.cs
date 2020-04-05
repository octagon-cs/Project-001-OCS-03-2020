using System;
using System.Threading.Tasks;
using won.Models;
using won.Models.SuratPermohonan;
using won.ViewModels;
using Xamarin.Forms.Xaml;


namespace won.Views.SuratPermohonan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PindahPage : OcphPage
    {
        public PindahPage()
        {
            InitializeComponent();
        }

        public override void Create()
        {
            BindingContext = new PindahViewModel();
        }

        public override void Edit(PermohonanModel permohonan)
        {
            base.Edit(permohonan);
            BindingContext = new PindahViewModel(permohonan);
        }

    }



    public class PindahViewModel : BaseViewModelSurat<PindahModel>
    {
        public PindahViewModel()
        {
            Load();
        }

        public PindahViewModel(PermohonanModel permohonan)
        {
            SetValue(permohonan);
        }

        public override async void SetValue(PermohonanModel permohonan)
        {
            await Task.Delay(500);
            await Load();
            Permohonan = permohonan;
            Model.KeteranganPindah = permohonan.Data.GetValue("keteranganpindah").ToString();
            Model.PindahKe = permohonan.Data.GetValue("pindahke").ToString();
            Model.TanggalPindah = DateTime.Parse(permohonan.Data.GetValue("tanggalpindah").ToString());
        }

    }
}