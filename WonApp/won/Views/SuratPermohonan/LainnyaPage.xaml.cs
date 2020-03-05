using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views.SuratPermohonan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LainnyaPage : ContentPage
    {
        public LainnyaPage()
        {
            InitializeComponent();
            BindingContext = new LainnyaViewModel();
        }
    }
    public class LainnyaViewModel : BaseViewModel
    {
        public LainnyaViewModel()
        {
            SaveCommand = new Command(SaveAction);
        }

        private void SaveAction(object obj)
        {
            throw new NotImplementedException();
        }

        private Command saveCommand;

        public Command SaveCommand
        {
            get { return saveCommand; }
            set { SetProperty(ref saveCommand, value); }
        }

    }
}