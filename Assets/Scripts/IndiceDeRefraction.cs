using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndiceDeRefraction : MonoBehaviour
{
    [HideInInspector] public float iDR = 1;           //Indice de Refraction de l'objet
    [HideInInspector] public Color32 refractionColor = Color.white;       //Couleur de la refraction
    [SerializeField] private TextMeshProUGUI text;

    public void DisplayIdR()
    {
        text.text = "IdR = " + iDR;             //Affiche l'indice de refraction dans le text au dessus du prism
    }
}
