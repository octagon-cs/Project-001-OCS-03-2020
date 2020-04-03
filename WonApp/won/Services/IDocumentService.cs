using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using won.Models;

namespace won.Services
{
   public interface IDocumentService
    {
       Task<List<Persyaratan>> GetPersyaratan();

       Task<DocumentPenduduk> PostPhoto(DocumentPenduduk document);

        Task<List<DocumentPenduduk>> GetDocumentPenduduk(int idpenduduk);
        Task<List<DocumentPenduduk>> GetDocumentByPermohonanId(int PermohonanId);
    }



    public class DocumentPendudukService : IDocumentService
    {

        private List<DocumentPenduduk> docPenduduk;
        public async Task<List<DocumentPenduduk>> GetDocumentPenduduk(int idpenduduk)
        {
            try
            {
                if (docPenduduk != null)
                {
                    return docPenduduk;
                }
                else
                {
                    using (var service = new RestService())
                    {
                        var response = await service.GetAsync($"/api/penduduk/dokumen/" + idpenduduk);
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            docPenduduk = JsonConvert.DeserializeObject<List<DocumentPenduduk>>(content);
                            return docPenduduk;
                        }
                        else
                        {
                            throw new SystemException(await service.Error(response));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }


        private List<Persyaratan> listPersyaratan;

        public async Task<List<Persyaratan>> GetPersyaratan()
        {
            try
            {
                if (listPersyaratan == null) {
                    using (var service = new RestService())
                    {
                        var response = await service.GetAsync($"/api/persyaratan");
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            listPersyaratan = JsonConvert.DeserializeObject<List<Persyaratan>>(content);
                            return listPersyaratan;
                        }
                        else
                        {
                            throw new SystemException(await service.Error(response));
                        }
                    }
                }
                else
                {
                    return listPersyaratan;
                }
               
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public async Task<DocumentPenduduk> PostPhoto(DocumentPenduduk model)
        {
            try
            {
                using (var service = new RestService())
                {
                    var response = await service.PostAsync("/api/penduduk/dokumen",
                            service.GenerateHttpContent(model));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<DocumentPenduduk>(content);
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

        public async Task<List<DocumentPenduduk>> GetDocumentByPermohonanId(int PermohonanId)
        {

            try
            {
                using (var service = new RestService())
                {
                    var response = await service.GetAsync($"/api/permohonan/dokumen/" + PermohonanId);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        docPenduduk = JsonConvert.DeserializeObject<List<DocumentPenduduk>>(content);
                        return docPenduduk;
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
