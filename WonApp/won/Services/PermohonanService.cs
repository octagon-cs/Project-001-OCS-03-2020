
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using won.Models;

namespace won.Services
{
    public class PermohonanService : IPermohonanService<PermohonanModel>
    {
        private readonly string controller = "permohonan";
        public async Task<bool> Delete(PermohonanModel item)
        {
            try
            {
                using (var service = new RestService())
                {
                    var response = await service.DeleteAsync($"/api/{controller}/{item.IdPermohonan}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<bool>(content);
                        return result;
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
        public async Task<PermohonanModel> GetById(int id)
        {
            try
            {
                using (var service = new RestService())
                {
                    var response = await service.GetAsync($"/api/{controller}/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<PermohonanModel>(content);
                        return result;
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

        public async Task<IEnumerable<PermohonanModel>> Get()
        {
            try
            {
                using (var service = new RestService())
                {
                    var response = await service.GetAsync($"/api/{controller}/mine");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var settings = new JsonSerializerSettings()
                        {
                            DateParseHandling = DateParseHandling.DateTimeOffset,
                            DateFormatHandling = DateFormatHandling.IsoDateFormat,
                            DateTimeZoneHandling = DateTimeZoneHandling.Utc
                        };
                        var result = JsonConvert.DeserializeObject<List<PermohonanModel>>(content, settings);
                        return result;
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

        public async Task<PermohonanModel> Create(PermohonanModel item)
        {
            try
            {
                using (var service = new RestService())
                {
                    var response = await service.PostAsync($"/api/{controller}", service.GenerateHttpContent(item));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<PermohonanModel>(content);
                        return result;
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