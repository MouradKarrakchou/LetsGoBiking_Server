using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCache
{
    internal class JCDecauxItem <T>
    {
        List<T> item;

        public JCDecauxItem(List<T> item)
        {
            this.item = item;
        }
        public JCDecauxItem(string item)
        {
            JcdecauxTool jcdecaux = new JcdecauxTool();
            if (item.Equals("/contract"))
            {
                new JCDecauxItem<JCDContract>(jcdecaux.getAllContracts());
            }
        }
    }
}
