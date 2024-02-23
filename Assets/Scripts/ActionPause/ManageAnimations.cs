using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ManageAnimations : MonoBehaviour
{
    [Header("UI Components")]
    public Sprite playIcon;
    public Sprite pauseIcon;
    public Button toggleButton;
    public GameObject pauseModeBubble;
    public GameObject playModeBubble;
    [SerializeField] private GameObject fForwardGif;

    public GameObject sliderRewind;

    [HideInInspector] public bool isPlaying = true;
    private bool goingFast = false;

    private void Start()
    {
        //Disable gif on start
        fForwardGif.SetActive(false);

        //Update icon if it's play or pause mode
        UpdateIcon();
    }

    public void ToggleState()
    {
        isPlaying = !isPlaying;
        UpdateIcon();
    }

    void UpdateIcon()
    {
        if (isPlaying)      //Is game is play
        {
            //Change UI for play UI
            toggleButton.image.sprite = pauseIcon;
            playModeBubble.gameObject.SetActive(true);
            pauseModeBubble.gameObject.SetActive(false);
            sliderRewind.gameObject.SetActive(false);

            //Resume time in game
            Time.timeScale = 1f;
        }
         else              //If game is pause
        {
            isPlaying = false;

            //Change UI for pause UI
            sliderRewind.gameObject.SetActive(true);
            toggleButton.image.sprite = playIcon;
            pauseModeBubble.gameObject.SetActive(true);
            playModeBubble.gameObject.SetActive(false);

            //Pause time in game
            Time.timeScale = 0f;
        }
    }
    
    public void FForward()
    {
        if(!goingFast)
        {
            goingFast = true;
            
            //Active gif
            fForwardGif.SetActive(true);

            //Speed up time
            Time.timeScale = 4.0f;
        }
        else
        {
            goingFast =false;

            //Desactive gif
            fForwardGif.SetActive(false);

            //Resume normal time
            Time.timeScale = 1.0f; 
        }
    }
}
