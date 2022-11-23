
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
 *         &lt;element name="originGeoLoca" type="{http://schemas.datacontract.org/2004/07/RoutingServer}GeoLoca" minOccurs="0"/&gt;
 *         &lt;element name="originStation" type="{http://schemas.datacontract.org/2004/07/RoutingServer}JCDStation" minOccurs="0"/&gt;
 *         &lt;element name="destinationStation" type="{http://schemas.datacontract.org/2004/07/RoutingServer}JCDStation" minOccurs="0"/&gt;
 *         &lt;element name="destinationGeoLoca" type="{http://schemas.datacontract.org/2004/07/RoutingServer}GeoLoca" minOccurs="0"/&gt;
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
    "originGeoLoca",
    "originStation",
    "destinationStation",
    "destinationGeoLoca"
})
@XmlRootElement(name = "CreateItinary", namespace = "http://tempuri.org/")
public class CreateItinary {

    @XmlElementRef(name = "originGeoLoca", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<GeoLoca> originGeoLoca;
    @XmlElementRef(name = "originStation", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<JCDStation> originStation;
    @XmlElementRef(name = "destinationStation", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<JCDStation> destinationStation;
    @XmlElementRef(name = "destinationGeoLoca", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<GeoLoca> destinationGeoLoca;

    /**
     * Obtient la valeur de la propriété originGeoLoca.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link GeoLoca }{@code >}
     *     
     */
    public JAXBElement<GeoLoca> getOriginGeoLoca() {
        return originGeoLoca;
    }

    /**
     * Définit la valeur de la propriété originGeoLoca.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link GeoLoca }{@code >}
     *     
     */
    public void setOriginGeoLoca(JAXBElement<GeoLoca> value) {
        this.originGeoLoca = value;
    }

    /**
     * Obtient la valeur de la propriété originStation.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link JCDStation }{@code >}
     *     
     */
    public JAXBElement<JCDStation> getOriginStation() {
        return originStation;
    }

    /**
     * Définit la valeur de la propriété originStation.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link JCDStation }{@code >}
     *     
     */
    public void setOriginStation(JAXBElement<JCDStation> value) {
        this.originStation = value;
    }

    /**
     * Obtient la valeur de la propriété destinationStation.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link JCDStation }{@code >}
     *     
     */
    public JAXBElement<JCDStation> getDestinationStation() {
        return destinationStation;
    }

    /**
     * Définit la valeur de la propriété destinationStation.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link JCDStation }{@code >}
     *     
     */
    public void setDestinationStation(JAXBElement<JCDStation> value) {
        this.destinationStation = value;
    }

    /**
     * Obtient la valeur de la propriété destinationGeoLoca.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link GeoLoca }{@code >}
     *     
     */
    public JAXBElement<GeoLoca> getDestinationGeoLoca() {
        return destinationGeoLoca;
    }

    /**
     * Définit la valeur de la propriété destinationGeoLoca.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link GeoLoca }{@code >}
     *     
     */
    public void setDestinationGeoLoca(JAXBElement<GeoLoca> value) {
        this.destinationGeoLoca = value;
    }

}
