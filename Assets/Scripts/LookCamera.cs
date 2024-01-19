using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    private GameObject arCamera;
    private void Start()
    {
        arCamera = GameObject.FindWithTag("ARCamera");
    }

    private void FixedUpdate()
    {
        transform.LookAt(arCamera.transform.position);
    }
}
