using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace won.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JenisPermohonanPage : ContentPage
    {
        public JenisPermohonanPage()
        {
            InitializeComponent();
            BindingContext = new JenisPermohonanViewModel();
        }
    }


    public class JenisPermohonanViewModel:BaseViewModel
    {
        public  ObservableCollection<JenisPermohonanModel> Items { get; set; }
        public Command LoadItemsCommand { get; }

        public JenisPermohonanViewModel()
        {
            Items = new ObservableCollection<JenisPermohonanModel>();
            LoadItemsCommand = new Command(LoadAction);
            LoadAction(null);
        }

        private async void LoadAction(object obj)
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                Items.Clear();
                var datas = await JenisPermohonan.Get();

                foreach (var item in datas)
                {
                    Items.Add(item);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {

                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = ex.Message,
                    Cancel = "OK"
                }, "message");
                IsBusy = false;
            }



          

        }
    }
}