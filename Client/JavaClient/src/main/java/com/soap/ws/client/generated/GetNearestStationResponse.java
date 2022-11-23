
package com.soap.ws.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour anonymous complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="GetNearestStationResult" type="{http://schemas.datacontract.org/2004/07/RoutingServer}JCDStation" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "getNearestStationResult"
})
@XmlRootElement(name = "GetNearestStationResponse", namespace = "http://tempuri.org/")
public class GetNearestStationResponse {

    @XmlElementRef(name = "GetNearestStationResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<JCDStation> getNearestStationResult;

    /**
     * Obtient la valeur de la propriété getNearestStationResult.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link JCDStation }{@code >}
     *     
     */
    public JAXBElement<JCDStation> getGetNearestStationResult() {
        return getNearestStationResult;
    }

    /**
     * Définit la valeur de la propriété getNearestStationResult.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link JCDStation }{@code >}
     *     
     */
    public void setGetNearestStationResult(JAXBElement<JCDStation> value) {
        this.getNearestStationResult = value;
    }

}
