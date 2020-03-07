using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.Models.Accounts;
using Xamarin.Forms;

namespace won
{
    public static class Helper
    {
        public static UserAccount Account { get;  set; }
        public static ObservableCollection<PermohonanModel> Permohonan { get; set; } = new ObservableCollection<PermohonanModel>();

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
                app.NextPage(page);
            }
        }

        public async static void BackPage(Page page)
        {
            if (await Task.FromResult(Application.Current) is App app)
            {
                app.BackPage();
            }
        }

        public async static void NavigateTo(Page page)
        {
            if (await Task.FromResult(Application.Current) is App app)
            {
                app.NavigateGo(page);
            }
        }
    }
}
