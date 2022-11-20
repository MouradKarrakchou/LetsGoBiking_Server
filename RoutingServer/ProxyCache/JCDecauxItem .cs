using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCache
{
    internal class JCDecauxItem <T>
    {
        T item;

        public JCDecauxItem(string requestItem)
        {
            JcdecauxTool jcdecaux = new JcdecauxTool();
            Task<String> result = jcdecaux.request(requestItem);
            item = JsonConvert.DeserializeObject<T>(result.Result);
        }

        internal T getItem()
        {
            return item;
        }
    }
}
