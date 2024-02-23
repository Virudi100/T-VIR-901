using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndiceDeRefraction : MonoBehaviour
{
    [HideInInspector] public float iDR = 1;           //Object's refraction
    [HideInInspector] public Color32 refractionColor = Color.white;       //Refraction's color
    [SerializeField] private TextMeshProUGUI text;      //Text used to display the refraction value

    public void DisplayIdR()
    {
        text.text = "IdR = " + iDR;             //Display refraction's value on text placed on the top of the prism
    }
}
