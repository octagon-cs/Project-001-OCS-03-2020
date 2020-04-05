using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.Models.Accounts;

namespace won.Services
{
    public class AccountService : IAccountService
    {
        private List<Penduduk> anggotaKeluarga;
        public async Task<List<Penduduk>> GetAnggotakeluarga()
        {
            try
            {
                if (anggotaKeluarga == null)
                {
                    using (var service = new RestService())
                    {
                        var response = await service.GetAsync("/api/penduduk/bynkk/"+Helper.Profile.nkk);
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            anggotaKeluarga = JsonConvert.DeserializeObject<List<Penduduk>>(content);
                        }
                        else
                        {
                            throw new SystemException(await service.Error(response));
                        }
                    }
                }

                return anggotaKeluarga;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

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

                        if (!string.IsNullOrEmpty(RestService.DeviceToken))
                        {
                            service.SetToken(Helper.Account.Token);
                               var token = new { token = RestService.DeviceToken };
                             await service.PostAsync("/api/auth/devicetoken", service.GenerateHttpContent(token));
                        }

                        return true;
                    }
                    else
                    {
                        throw new SystemException(await service.Error(response));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public async Task<object> Profile()
        {
            try
            {
                using (var service = new RestService())
                {
                    var response = await service.GetAsync("/api/auth/profile");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Penduduk rss = JsonConvert.DeserializeObject<Penduduk>(content);
                        Helper.Profile = rss;
                        return true;
                    }
                    else
                    {
                        throw new SystemException(await service.Error(response));
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
                    var response = await service.PostAsync("/api/auth/registrasi", service.GenerateHttpContent(model));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var penduduk = JsonConvert.DeserializeObject<PendudukModel>(content);
                        return true;
                    }
                    else
                    {
                        throw new SystemException(await service.Error(response));
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
