using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeParticulesColor : MonoBehaviour
{
    private ParticleSystem _system;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        _system = gameObject.GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        var col = _system.colorOverLifetime;
        col.enabled = true;

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(bullet.GetComponent<MeshRenderer>().material.color, 0), new GradientColorKey(bullet.GetComponent<MeshRenderer>().material.color, 1) }, new GradientAlphaKey[] { new GradientAlphaKey(1, 0), new GradientAlphaKey(0, 1) });

        col.color = grad;
    }
}
