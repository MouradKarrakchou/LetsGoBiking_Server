
package com.soap.ws.client.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
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
 *         &lt;element name="left" type="{http://www.w3.org/2001/XMLSchema}int" minOccurs="0"/&gt;
 *         &lt;element name="right" type="{http://www.w3.org/2001/XMLSchema}int" minOccurs="0"/&gt;
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
    "left",
    "right"
})
@XmlRootElement(name = "Multiply")
public class Multiply {

    protected Integer left;
    protected Integer right;

    /**
     * Obtient la valeur de la propriété left.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getLeft() {
        return left;
    }

    /**
     * Définit la valeur de la propriété left.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setLeft(Integer value) {
        this.left = value;
    }

    /**
     * Obtient la valeur de la propriété right.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getRight() {
        return right;
    }

    /**
     * Définit la valeur de la propriété right.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setRight(Integer value) {
        this.right = value;
    }

}
