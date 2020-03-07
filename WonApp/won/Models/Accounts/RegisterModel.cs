using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace won.Models.Accounts
{
   public class RegisterModel:BaseNotify
    {
        private string email;
        private string password;
        private string confirmPassword;
        private string nkk;
        private string nik;

        [JsonProperty("nik")]
        public string NIK
        {
            get { return nik; }
            set     { SetProperty(ref nik ,value); }
        }

        [JsonProperty("nkk")]
        public string NKK
        {
            get { return nkk; }
            set {SetProperty(ref nkk ,value); }
        }


        [JsonProperty("email")]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value);  }
        }


        [JsonProperty("password")]
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }


        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { SetProperty(ref confirmPassword, value);  }
        }

        public override bool Valid
        {
            get
            {
                return Validation();

            }
        }

        private bool Validation()
        {
            var valid = true;
            var err = "";
            if (string.IsNullOrEmpty(NIK) || string.IsNullOrEmpty(NKK)|| string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
            {
                valid = false;
                err = "Data Tidak Boleh Kosong";
            }

            if (Password != ConfirmPassword)
            {
                valid = false;
                err = "Password dan Konfirmasi Password Tidak Sama";
            }

            const string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (!string.IsNullOrEmpty(Email) && !regex.IsMatch(Email))
            {
                err = "Email Anda Tidak Valid";
                valid = false;
            }

            ErrorMessage = err;
            return valid;
        }
    }
}
