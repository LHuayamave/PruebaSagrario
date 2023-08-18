using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSagrario2
{
    public class HttpCliente
    {
        HttpClient cliente = new HttpClient();

        public async Task<string> Get(string url)
        {
            var response = await cliente.GetAsync(url);
            string json = response.Content.ReadAsStringAsync().Result;
            return json;
        }

        public async Task<HttpResponseMessage> Post(string url, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync(url, content);
            var result = response;
            return result;
        }

        public async Task<HttpResponseMessage> Put(string url, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync(url, content);
            var result = response;
            return result;
        }

        public async Task<string> Delete(string url)
        {
            var response = await cliente.DeleteAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
