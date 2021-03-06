﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;   

namespace won
{
    public class RestService : HttpClient
    {
        public static string DeviceToken { get; set; }

        public RestService()
        {
            // this.MaxResponseContentBufferSize = 256000;
            //var a = ConfigurationManager.AppSettings["IP"];
            string _server = Helper.Url;
            //string _server = "http://waena-desa.id/";
            this.BaseAddress = new Uri(_server);
            this.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //key api = 57557c4f25f436213fe34a2090a266e2
            if (Helper.Account != null)
            {
                SetToken(Helper.Account.Token);
            }
        }

        public RestService(string apiUrl)
        {
            this.BaseAddress = new Uri(apiUrl);

        }

        public void CekTokenAsync()
        {
            if (Helper.Account != null)
            {
                this.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("", Helper.Account.Token);
            }
        }


        public void SetToken(string token)
        {
            if (token != null)
            {
                this.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",
                    token);
                this.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Basic", token);
            }
        }

        internal Task DeleteAsync(string id, StringContent content)
        {

            throw new NotImplementedException();
        }

        public StringContent GenerateHttpContent(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }


        public async Task<string> Error(HttpResponseMessage response)
        {
            try
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ErrorMessage>(content);
                return result.Message;
            }
            catch (Exception)
            {
                return "Maaf Terjadi Kesalahan, Silahkan Ulangi Lagi Nanti";
            }
        }
    }



    public class ErrorMessage
    {
        public string Message { get; set; }
    }


}
