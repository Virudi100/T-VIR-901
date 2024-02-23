using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Switch scene on touch screen

public class MenuManager : MonoBehaviour
{
    private void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)      //Foreach finger touching the screen
        {
            if (touch.phase == TouchPhase.Began)    //When begin to touch the screen
            {
                SceneManager.LoadScene(1);          //Load scene with index 1
            }
        }
    }
}
