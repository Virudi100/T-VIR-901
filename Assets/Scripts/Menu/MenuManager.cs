using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ce script permet de changer de sc�ne lorsque l'on appuie sur l'�cran

public class MenuManager : MonoBehaviour
{
    private void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)      //Pour chaque doigts qui touche l'�cran
        {
            if (touch.phase == TouchPhase.Began)    //Quand le doigt viens de commencer � toucher l'�cran
            {
                SceneManager.LoadScene(1);          //Lance la sc�ne avec l'index 1
            }
        }
    }
}
