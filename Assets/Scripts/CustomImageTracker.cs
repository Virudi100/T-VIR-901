using System.Numerics;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CustomImageTracker : MonoBehaviour
{
    [Header("AR Session Origin's Components")]
    [SerializeField] private ARTrackedImageManager manager;

    [Header("Prefabs")]
    [SerializeField] private GameObject baseLaser;
    [SerializeField] private GameObject basePrism;

    [HideInInspector] public GameObject newLaser;
    [HideInInspector] public GameObject newPrisme;

    [Header("Scripts")]
    [SerializeField] private ManageAnimations pauseScript;


    private void OnEnable()
    {
        //Enable image tracking event
        manager.trackedImagesChanged += OnTrackedImageChange;
    }

    private void OnDisable()
    {
        //Disable image tracking event
        manager.trackedImagesChanged -= OnTrackedImageChange;
    }

    private void OnTrackedImageChange(ARTrackedImagesChangedEventArgs args)
    {
        if (pauseScript.isPlaying == true)
        {
            foreach (ARTrackedImage addedImg in args.added)         //When reference picture is detected
            {
                if (addedImg.referenceImage.name == "Laser")
                {
                    //Create laser using laserPrefab at picture position
                    newLaser = Instantiate(baseLaser, addedImg.transform.position, UnityEngine.Quaternion.identity);
                }
                if (addedImg.referenceImage.name == "Prism")
                {
                    //Create prism using prismPrefab at picture position
                    newPrisme = Instantiate(basePrism, addedImg.transform.position, basePrism.transform.rotation);
                }
            }

            foreach (ARTrackedImage updatedImg in args.updated)     //While reference picture is detected
            {
                if (updatedImg.referenceImage.name == "Laser")
                {
                    //Update laser position on picture position
                    newLaser.transform.position = updatedImg.transform.position;
                }
                if (updatedImg.referenceImage.name == "Prism")
                {
                    //Update prism position on picture position
                    newPrisme.transform.position = updatedImg.transform.position;
                }
            }

            foreach (ARTrackedImage removedImg in args.removed)   //When reference picture is no longuer detected
            {
                if (removedImg.referenceImage.name == "Laser")
                {
                    //Kill laser gameobject
                    Destroy(newLaser);
                }
                if (removedImg.referenceImage.name == "Prism")
                {
                    //Kill prism gameobject
                    Destroy(newPrisme);
                }
            }
        }
    }
}
