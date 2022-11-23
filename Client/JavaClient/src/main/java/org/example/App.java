package org.example;

import com.soap.ws.client.generated.Bike;
import com.soap.ws.client.generated.GeoLoca;
import com.soap.ws.client.generated.IBikeService;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        System.out.println("Hello World! we are going to test a SOAP client written in Java");
        Bike bike = new Bike();
        IBikeService bikeService= bike.getBasicHttpBindingIBikeService();
        GeoLoca geoLoca = bikeService.getItinerary("102 rue de reuilly 75012","place d'italie paris");
        System.out.println(geoLoca.getFeatures().getValue().getFeature().get(0).getGeometry().getValue().getCoordinates());
    }
}
