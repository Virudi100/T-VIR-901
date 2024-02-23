using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPrism : MonoBehaviour
{
    private GameObject prismeGo;

    private void FixedUpdate()
    {
        prismeGo = GameObject.FindWithTag("Prisme");    //Find "Prisme" gameobject

        if(prismeGo != null )       
        {
            gameObject.transform.LookAt(prismeGo.transform.position);   //Laser lookat the prism
        }
    }
}
