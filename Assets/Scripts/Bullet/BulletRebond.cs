using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRebond : MonoBehaviour
{
    private bool rebonded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!rebonded)
        {
            if (other.CompareTag("Prisme2PenteDroite"))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * other.transform.parent.gameObject.GetComponent<IndiceDeRefraction>().iDR * 50);
                gameObject.GetComponent<MeshRenderer>().material.color = other.transform.parent.gameObject.GetComponent<IndiceDeRefraction>().refractionColor;
                rebonded = true;
            }
            else if (other.CompareTag("Prisme2PenteGauche"))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * other.transform.parent.gameObject.GetComponent<IndiceDeRefraction>().iDR * 50);
                gameObject.GetComponent<MeshRenderer>().material.color = other.transform.parent.gameObject.GetComponent<IndiceDeRefraction>().refractionColor;
                rebonded = true;

            }
            /*else if (other.CompareTag("Prisme2Dessous"))
            {

            }
            else if (other.CompareTag("Prisme2Avant"))
            {

            }
            else if (other.CompareTag("Prisme2Arriere"))
            {

            }*/
        }
    }
}
