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

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); Validation(); }
        }

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); Validation(); }
        }


        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { SetProperty(ref confirmPassword, value); Validation(); }
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
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
            {
                valid = false;
                ErrorMessage = "Data Tidak Boleh Kosong";
            }

            if (Password != ConfirmPassword)
            {
                valid = false;
                ErrorMessage = "Email dan Password Tidak Sama";
            }
            const string pattern = @"^(? !\.)(""([^""\r\\] |\\[""\r\\])*""|" + @"([-a - z0 - 9!#$%&’*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            if (regex.IsMatch(Email))
            {
                ErrorMessage = "Email Anda Tidak Valid";valid = false;
            }

            if (valid) ErrorMessage = "";
            return valid;
        }
    }
}
