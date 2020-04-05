using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.Models.Accounts;

namespace won.Services
{
    public interface IAccountService
    {
        Task<bool> Login(LoginModel item);
        Task<bool> Register(RegisterModel item);
        Task<object> Profile();

        Task<List<Penduduk>> GetAnggotakeluarga();
    }
}
