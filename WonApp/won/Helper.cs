using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.Models.Accounts;
using won.Views;
using Xamarin.Forms;

namespace won
{
    public static class Helper
    {
        public static UserAccount Account { get;  set; }
        public static ObservableCollection<PermohonanModel> Permohonan { get; set; } = new ObservableCollection<PermohonanModel>();
        public static string Url { get; set; } = "http://192.168.1.6:3000/";
        public static JObject Profile { get;  set; }

        public async static void ChangeMainPage(Page page)
        {
            if (await Task.FromResult(Application.Current) is App app)
            {
                app.ChangeMain(page);
            }
        }


        public async static void GoPage(Page page)
        {
            if (await Task.FromResult(Application.Current) is App app)
            {
                var mainPage = app.MainPage as MainPage;
                await   mainPage.Detail.Navigation.PushAsync(page);
            }
        }

        public async static void BackPage(Page page)
        {
            if (await Task.FromResult(Application.Current) is App app)
            {
                var mainPage = app.MainPage as MainPage;
                await mainPage.Detail.Navigation.PopAsync();
            }
        }


        public static Color GetJenisCorlor(StatusPersetujuan status)
        {
            switch (status)
            {
                case StatusPersetujuan.Dikembalikan:
                   return Color.FromHex("#F67B1C");
                case StatusPersetujuan.Disetujui:
                    return Color.FromHex("#857A7A");
                case StatusPersetujuan.Ditolak:
                    return Color.FromHex("#D23106");
                case StatusPersetujuan.Selesai:
                    return Color.FromHex("#0B9567");
                default:
                    return Color.White;
            }
        }
    }
}
