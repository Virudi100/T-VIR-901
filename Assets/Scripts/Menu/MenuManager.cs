using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ce script permet de changer de scène lorsque l'on appuie sur l'écran

public class MenuManager : MonoBehaviour
{
    private void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)      //Pour chaque doigts qui touche l'écran
        {
            if (touch.phase == TouchPhase.Began)    //Quand le doigt viens de commencer à toucher l'écran
            {
                SceneManager.LoadScene(1);          //Lance la scéne avec l'index 1
            }
        }
    }
}
