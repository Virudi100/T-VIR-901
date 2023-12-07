using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Ajoutez du code suppl�mentaire ici si n�cessaire

        // Gestion de la pause lorsque le bouton "Pause" est press�
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Met en pause le temps
        }
        else
        {
            Time.timeScale = 1f; // R�active le temps
        }
    }
}
