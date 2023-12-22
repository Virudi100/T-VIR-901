using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Determine l'angle de rebond du laser selon la zone d'impact

public class BulletRebond : MonoBehaviour
{
    private bool rebonded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!rebonded)  //Necessaire pour empecher le laser de rebondir sur l'autre face après avoir traversé le prisme
        {
            if (other.CompareTag("Prisme2Pente"))       //Quand le laser touche la pente du prisme 2
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * other.transform.parent.gameObject.GetComponent<IndiceDeRefraction>().iDR);      //Ajoute une force vers le haut influencer par l'indice de refraction
                gameObject.GetComponent<MeshRenderer>().material.color = other.transform.parent.gameObject.GetComponent<IndiceDeRefraction>().refractionColor;  //Change la couleur du laser influencer par la couleur de refraction
                rebonded = true;
            }

            if (other.CompareTag("PrismePenteGauche"))  //Quand le laser touche la pente du prisme
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR);     //Ajoute une force vers le haut influencer par l'indice de refraction
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR);   
                gameObject.GetComponent<MeshRenderer>().material.color = other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().refractionColor; //Change la couleur du laser influencer par la couleur de refraction
                rebonded = true;
            }
            if (other.CompareTag("PrismePenteDroite"))  //Quand le laser touche la pente du prisme
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR);     //Ajoute une force vers le haut influencer par l'indice de refraction
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR);
                gameObject.GetComponent<MeshRenderer>().material.color = other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().refractionColor; //Change la couleur du laser influencer par la couleur de refraction
                rebonded = true;
            }
        }
    }
}
