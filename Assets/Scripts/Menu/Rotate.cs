using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float speed = 1.5f;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(Vector3.back * speed);
    }
}
