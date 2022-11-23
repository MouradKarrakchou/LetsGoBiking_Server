package org.example;

import com.soap.ws.client.generated.Bike;
import com.soap.ws.client.generated.GeoLoca;
import com.soap.ws.client.generated.IBikeService;
import com.soap.ws.client.generated.Itinary;

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
        Itinary itinary = bikeService.getItinerary("150 Rue Saint-Sever, 76100 Rouen","139 Rue du Gros Horloge, 76000 Rouen");
        System.out.println(itinary.getFeatures().getValue().getFeatureItinary().get(0).getProperties().getValue().getSegments().getValue().getSegment().get(0).getSteps().getValue().getStep().get(0).getInstruction().getValue());
    }
}
