using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace won.Models.Accounts
{
    public class LoginModel:BaseNotify
    {
        private string username;
        private string password;


        [JsonProperty("username")]
        public string UserName
        {
            get { return username; }
            set { SetProperty(ref username, value); Validation(); }
        }

        private bool Validation()
        {
            var valid = true;
            var err = "";
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                valid = false;
                err = "Email dan Password Tidak Boleh Kosong";
            }

            const string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (!string.IsNullOrEmpty(UserName) && !regex.IsMatch(UserName))
            {
                err = "Email Anda Tidak Valid";
                valid = false;
            }

           ErrorMessage = err;
            return valid;

        }


        [JsonProperty("password")]
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password,value); Validation(); }
        }

        public override  bool Valid { get {
               
                return Validation(); 
            
            }
        }



        private string url;
        [JsonIgnore]
        public string URL
        {
            get { return Helper.Url; }
            set { SetProperty(ref url ,value); Helper.Url = value; }
        }



    }
}
