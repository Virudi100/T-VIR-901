using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBulletColor : MonoBehaviour
{
    // init the variable of the slider handle coreesponding to the circle point to move
    private GameObject handle;
    private Color handleColor;


    void Start()
    {
        // retrieve the handle of the slider with its corresponding tag
        handle = GameObject.FindWithTag("Handle");
        if (handle != null)
        {
            // retrieve handle color
            handleColor = handle.GetComponent<Image>().color;
            // set bullet color to handle specific color
            gameObject.GetComponent<MeshRenderer>().material.color = handleColor;
        }
    }


}
