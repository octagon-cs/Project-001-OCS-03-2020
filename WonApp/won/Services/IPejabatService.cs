using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won.Models;

namespace won.Services
{
    public interface IPejabatService<T>
    {
        Task<T> GetLurah();
        Task<IEnumerable<T>> Get();
    }


    public class PejabatService : IPejabatService<PejabatModel>
    {
        private readonly string controller = "pejabat";

        private List<PejabatModel> items;

        public async Task<IEnumerable<PejabatModel>> Get()
        {
            try
            {
                if (items != null)
                    return items;
                using (var service = new RestService())
                {
                    var response = await service.GetAsync($"/api/{controller}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var settings = new JsonSerializerSettings()
                        {
                            DateParseHandling = DateParseHandling.DateTimeOffset,
                            DateFormatHandling = DateFormatHandling.IsoDateFormat,
                            DateTimeZoneHandling = DateTimeZoneHandling.Utc
                        };
                        items = JsonConvert.DeserializeObject<List<PejabatModel>>(content, settings);
                        return items;
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

        public async Task<PejabatModel> GetLurah()
        {
            var result = await Get();
            if(result != null)
            {
                return result.Where(x => x.Status == 1 && x.NamaJabatan.ToLower()=="lurah").FirstOrDefault();
            }
            return null;
        }
    }
}
