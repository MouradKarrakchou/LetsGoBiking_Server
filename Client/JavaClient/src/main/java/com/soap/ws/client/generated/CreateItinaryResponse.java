
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
 *         &lt;element name="CreateItinaryResult" type="{http://schemas.datacontract.org/2004/07/RoutingServer}GeoLoca" minOccurs="0"/&gt;
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
    "createItinaryResult"
})
@XmlRootElement(name = "CreateItinaryResponse", namespace = "http://tempuri.org/")
public class CreateItinaryResponse {

    @XmlElementRef(name = "CreateItinaryResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<GeoLoca> createItinaryResult;

    /**
     * Obtient la valeur de la propriété createItinaryResult.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link GeoLoca }{@code >}
     *     
     */
    public JAXBElement<GeoLoca> getCreateItinaryResult() {
        return createItinaryResult;
    }

    /**
     * Définit la valeur de la propriété createItinaryResult.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link GeoLoca }{@code >}
     *     
     */
    public void setCreateItinaryResult(JAXBElement<GeoLoca> value) {
        this.createItinaryResult = value;
    }

}
