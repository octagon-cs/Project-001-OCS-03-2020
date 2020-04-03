using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using won.Models;
using won.Models.Accounts;

namespace won.Services
{
    public interface IPermohonanService<T>  
    {
        Task<T> Create(T item);
        Task<T> Put(T item);
        Task<bool> Delete(T item);
        Task<T> GetById(int id);
        Task<T> PostPersyaratan(int id, Persyaratan persyaratan);
        Task<bool> DeletePersyaratan(int id);
        Task<IEnumerable<T>> Get();
    }

}