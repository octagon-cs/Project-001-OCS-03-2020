
using won.Models;

namespace won.Services
{
    public class PermohonanService : IPermohonan<PermohonanModel>
    {
        private string controller = "permohonan";
        Task<PermohonanModel> Create(T item)
        {
            try
            {
                using (var service = new RestService())
                {
                    HtppResponseResult response = await service.PostAsync($"/api/{controller}",
                            service.GenerateHttpContent(model));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<PermohonanModel>(content);
                        return result;
                    }
                    else
                    {
                        service.Error(response);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
        Task<PermohonanModel> Delete(T item)
        {
            try
            {
                using (var service = new RestService())
                {
                    var response = await service.DeleteAsync($"/api/{controller}/{id}",
                            service.GenerateHttpContent(model));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<bool>(content);
                        return result;
                    }
                    else
                    {
                        service.Error(response);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
        Task<PermohonanModel> GetById(int id)
        {
            try
            {
                using (var service = new RestService())
                {
                    var response = await service.GetAsync($"/api/{controller}/{id}",
                            service.GenerateHttpContent(model));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<PermohonanModel>(content);
                        return result;
                    }
                    else
                    {
                        service.Error(response);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
        Task<List<PermohonanModel>> GetPermohonans()
        {
            try
            {
                using (var service = new RestService())
                {
                    var response = await service.GetAsync($"/api/{controller}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<PermohonanModel>>(content);
                        return result;
                    }
                    else
                    {
                        service.Error(response);
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