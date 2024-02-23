using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    private GameObject arCamera;
    private void Start()
    {
        //Find gameobject named "ARCamera" using a tag
        arCamera = GameObject.FindWithTag("ARCamera");
    }

    private void FixedUpdate()
    {
        //Looking the camera
        transform.LookAt(arCamera.transform.position);
    }
}
