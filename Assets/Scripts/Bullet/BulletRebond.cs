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
            if (other.CompareTag("Prisme2Pente"))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * other.transform.parent.gameObject.GetComponent<IndiceDeRefraction>().iDR * 50);
                gameObject.GetComponent<MeshRenderer>().material.color = other.transform.parent.gameObject.GetComponent<IndiceDeRefraction>().refractionColor;
                rebonded = true;
            }

            if (other.CompareTag("PrismePenteGauche"))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR * 50);
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR * 50);
                gameObject.GetComponent<MeshRenderer>().material.color = other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().refractionColor;
                rebonded = true;
            }
            if (other.CompareTag("PrismePenteDroite"))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR * 50);
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().iDR * 50);
                gameObject.GetComponent<MeshRenderer>().material.color = other.transform.parent.gameObject.transform.parent.GetComponent<IndiceDeRefraction>().refractionColor;
                rebonded = true;
            }
        }
    }
}
