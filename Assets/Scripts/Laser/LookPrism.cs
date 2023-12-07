using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Permet au laser de regarder le prisme quand il est détecté dans la scène

public class LookPrism : MonoBehaviour
{
    private GameObject prismeGo;

    private void FixedUpdate()
    {
        prismeGo = GameObject.FindWithTag("Prisme");    //Cherche l'objet Prisme dans la scène

        if(prismeGo != null )       //Si l'objet est présent
        {
            gameObject.transform.LookAt(prismeGo.transform.position);   //Le laser regarde le prisme
        }
    }
}
