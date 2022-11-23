using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ProxyCache
{
    internal class JCDecauxItem <T>
    {
        T item;

        public JCDecauxItem(string requestItem)
        {
            JcdecauxToolProxy jcdecaux = new JcdecauxToolProxy();
            Task<String> result = JCDecauxAPICall(requestItem);
            item = JsonConvert.DeserializeObject<T>(result.Result);
        }
        static async Task<string> JCDecauxAPICall(string request)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        internal T getItem()
        {
            return item;
        }
    }
}
