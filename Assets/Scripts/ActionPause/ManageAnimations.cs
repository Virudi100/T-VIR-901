using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ManageAnimations : MonoBehaviour
{
    public Sprite playIcon;
    public Sprite pauseIcon;
    public Button toggleButton;
    public GameObject pauseModeBubble;
    public GameObject playModeBubble;


    private bool isPlaying = true;

    private void Start()
    {
        UpdateIcon();
        toggleButton.onClick.AddListener(ToggleState);
    }

    void ToggleState()
    {
        isPlaying = !isPlaying;
        UpdateIcon();

        // Ici, ajoutez la logique pour mettre en pause ou reprendre le jeu
        //StopAnimation()
    }

    void UpdateIcon()
    {
        if (isPlaying)
        {
            toggleButton.image.sprite = pauseIcon;
            Time.timeScale = 1f;
            playModeBubble.gameObject.SetActive(true);
            pauseModeBubble.gameObject.SetActive(false);
        }

        else
        {
            toggleButton.image.sprite = playIcon;
            Time.timeScale = 0f;
            isPlaying = false;
            pauseModeBubble.gameObject.SetActive(true);
            playModeBubble.gameObject.SetActive(false);
        }


    }

    void StopAnimation()
    {
        if (!isPlaying)
        {
            Time.timeScale = 0f;
        }
    }
    //private bool isPaused = false;

    /*void Update()
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
    }*/
}
