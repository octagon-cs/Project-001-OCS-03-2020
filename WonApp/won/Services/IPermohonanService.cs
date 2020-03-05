using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using won.Models.Accounts;

namespace won.Services
{
    public interface IPermohonan<T>
    {
        Task<T> Create(T item);
        Task<T> Delete(T item);
        Task<T> GetById(int id);
        Task<List<T>> GetPermohonans();
    }

}