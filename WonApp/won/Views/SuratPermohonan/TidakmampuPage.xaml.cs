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
    public partial class TidakmampuPage : ContentPage
    {
        public TidakmampuPage()
        {
            InitializeComponent();
            BindingContext = new TidakmampuViewModel();
        }
    }
    public class TidakmampuViewModel : BaseViewModel
    {
        public TidakmampuViewModel()
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