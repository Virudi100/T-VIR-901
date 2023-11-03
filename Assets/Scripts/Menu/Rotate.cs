using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Ce script permet de faire une rotation continue d'un objet

public class Rotate : MonoBehaviour
{
    private float speed = 1.5f;                             //Vitesse de rotation

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(Vector3.back * speed);  //Rotation vers l'arrière avec une vitesse "speed"
    }
}
