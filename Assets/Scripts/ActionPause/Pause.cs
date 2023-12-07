using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Ajoutez du code supplémentaire ici si nécessaire

        // Gestion de la pause lorsque le bouton "Pause" est pressé
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
            Time.timeScale = 1f; // Réactive le temps
        }
    }
}
