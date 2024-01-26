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
    [SerializeField] private GameObject fForwardGif;


     public bool isPlaying = false;
    private bool goingFast = false;

    private void Start()
    {
        fForwardGif.SetActive(false);
        UpdateIcon();
    }

    public void ToggleState()
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
            //Time.timeScale = 1f;
            playModeBubble.gameObject.SetActive(true);
            pauseModeBubble.gameObject.SetActive(false);
        }
         else
        {
            isPlaying = false;
            toggleButton.image.sprite = playIcon;
            //Time.timeScale = 0f;
            pauseModeBubble.gameObject.SetActive(true);
            playModeBubble.gameObject.SetActive(false);
        }
    }
    
    public void FForward()
    {
        if(!goingFast)
        {
            goingFast = true;
            Time.timeScale = 4.0f;
            fForwardGif.SetActive(true);
        }
        else
        {
            goingFast =false;
            Time.timeScale = 1.0f;
            fForwardGif.SetActive(false);
        }
    }
}
