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


    private void OnEnable()
    {
        manager.trackedImagesChanged += OnTrackedImageChange;
    }

    private void OnDisable()
    {
        manager.trackedImagesChanged -= OnTrackedImageChange;
    }

    private void OnTrackedImageChange(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage addedImg in args.added)         //Quand l'image est détecté
        {
            if (addedImg.referenceImage.name == "Laser")
            {
                newLaser = Instantiate(baseLaser, addedImg.transform.position, UnityEngine.Quaternion.identity);
            }
            if (addedImg.referenceImage.name == "Prism")
            {
                newPrisme = Instantiate(basePrism, addedImg.transform.position, UnityEngine.Quaternion.identity);
            }
        }

        foreach (ARTrackedImage updatedImg in args.updated)     //Le temps que l'image reste détecté
        {
            if (updatedImg.referenceImage.name == "Laser")
            {
                newLaser.transform.position = updatedImg.transform.position;
            }
            if (updatedImg.referenceImage.name == "Prism")
            {
                newPrisme.transform.position = updatedImg.transform.position;
            }
        }

        foreach (ARTrackedImage removedImg in args.removed)   //Quand l'image n'est plus détecté
        {
            if (removedImg.referenceImage.name == "Laser")
            {
                Destroy(newLaser);
            }
            if (removedImg.referenceImage.name == "Prism")
            {
                Destroy(newPrisme);
            }
        }
    }
}
