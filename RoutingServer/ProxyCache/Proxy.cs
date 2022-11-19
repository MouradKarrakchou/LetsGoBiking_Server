using RoutingServer;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProxyCache
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Proxy" à la fois dans le code et le fichier de configuration.
    public class Proxy : IProxy
    {
        JcdecauxTool jcdecauxTool = new JcdecauxTool();

        public JCDStation GetNearestStation(GeoCoordinate coord)
        {
            List<JCDStation> list = new List<JCDStation>();
            return jcdecauxTool.GetNearestStation(coord, list);
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
