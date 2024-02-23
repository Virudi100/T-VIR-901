using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class ChangeParticulesColor : MonoBehaviour
{
    private ParticleSystem _system;

    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {   //Get Particule Systeme component from current gameobject
        _system = gameObject.GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        //Create col variable getting the color over life time value
        var col = _system.colorOverLifetime;
        col.enabled = true;

        //Create new gratient
        Gradient grad = new Gradient();
        //Create gradient keys at 0 (start) and 1 (end) with the bullet color and alpha 1 at the beginning / bullet color ans alpha 0 at the end
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(bullet.GetComponent<MeshRenderer>().material.color, 0), new GradientColorKey(bullet.GetComponent<MeshRenderer>().material.color, 1) }, new GradientAlphaKey[] { new GradientAlphaKey(1, 0), new GradientAlphaKey(0, 1) });

        //Apply color to the gradient
        col.color = grad;
    }
}
