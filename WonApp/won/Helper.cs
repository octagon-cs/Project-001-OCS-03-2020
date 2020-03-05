using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using won.Models.Accounts;
using Xamarin.Forms;

namespace won
{
    public static class Helper
    {
        public static UserAccount Account { get; internal set; }

        public async static void ChangeMainPage(Page page)
        {
            var app = await Task.FromResult(Application.Current) as App;
            if (app != null)
            {
                app.ChangeScreen(page);
            }
        }
    }
}
