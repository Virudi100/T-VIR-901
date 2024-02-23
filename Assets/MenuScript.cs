using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void BackToMenu()
    {
        //Load scene with index 0
        SceneManager.LoadScene(0);
    }

    public void QuitApp()
    {
        //Quit the application
        Application.Quit();
    }
}
