using System;
using Xamarin.Forms;

namespace won.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

           // OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

       // public ICommand OpenWebCommand { get; }
    }
}