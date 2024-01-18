using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBulletColor : MonoBehaviour
{
    // init the variable of the slider handle coreesponding to the circle point to move
    private GameObject xrOrigin;
    private Color handleColor;


    void Start()
    {
        // retrieve the handle of the slider with its corresponding tag
        xrOrigin = GameObject.FindWithTag("XROrigin");
        if (xrOrigin != null)
        {
            // retrieve handle color
            handleColor = xrOrigin.GetComponent<ColorContainer>().handleColor;
            // set bullet color to handle specific color
            gameObject.GetComponent<MeshRenderer>().material.color = handleColor;
        }
    }
}
