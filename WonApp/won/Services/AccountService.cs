using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using won.Models.Accounts;

namespace won.Services
{
    public class AccountService : IAccountService
    {
        public async Task<bool> Login(LoginModel model)
        {
            try
            {
                using (var service = new RestService())
                {
                    var response = await service.PostAsync("/api/auth/login",
                            service.GenerateHttpContent(model));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Helper.Account = JsonConvert.DeserializeObject<UserAccount>(content);
                        Helper.Account.Role = Helper.Account.Roles[0];
                        return true;
                    }
                    else
                    {
                        throw new SystemException("User atau  Password anda Salah");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }


        public async Task<bool> Register(RegisterModel model)
        {
            try
            {
                using (var service = new RestService())
                {
                    var response = await service.PostAsync("/api/users/register",service.GenerateHttpContent(model));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Helper.Account = JsonConvert.DeserializeObject<UserAccount>(content);
                        Helper.Account.Role = Helper.Account.Roles[0];
                        return true;
                    }
                    else
                    {
                        throw new SystemException("User atau  Password anda Salah");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

    }
}
