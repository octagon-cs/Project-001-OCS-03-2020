using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;

namespace won.Services
{
    public interface IJenisPermohonanService<T>
    {
       Task<List<T>> Get();
        Task<T> GetById(int id);
    }


    public class JenisPermohonanService : IJenisPermohonanService<JenisPermohonanModel>
    {

        private List<JenisPermohonanModel> items = new List<JenisPermohonanModel>();

        private bool instance;

        public async Task<List<JenisPermohonanModel>> Get()
        {
            if (instance)
            {
                return items;
            }
            else
            {
                return  await GetData();
            }
        }

        public async Task<JenisPermohonanModel> GetById(int id)
        {
            if (instance)
            {
                return items.FirstOrDefault();
            }
            else
            {
                var result = await GetData();
                return result.FirstOrDefault();
            }
        }


        private async Task<List<JenisPermohonanModel>> GetData()
        {
            using (var service = new RestService())
            {
                var response = await service.GetAsync("/api/jenispermohonan");
                if (response.IsSuccessStatusCode)
                {
                    instance = true;
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<JenisPermohonanModel>>(content);
                    return items;
                }
                else
                {
                    throw new SystemException(await service.Error(response));
                }
            }
        }
    }
}
