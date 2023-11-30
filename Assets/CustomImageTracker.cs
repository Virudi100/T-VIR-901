using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CustomImageTracker : MonoBehaviour
{
    [Header("AR Session Origin's Components")]
    [SerializeField] private ARTrackedImageManager manager;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] laserArray;
    [SerializeField] private GameObject[] prismeArray;

    private GameObject newLaser;
    private GameObject newPrisme;


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
        foreach (ARTrackedImage addedImg in args.added)
        {
            if (addedImg.referenceImage.name == "Laser")
            {
                newLaser = Instantiate(laserArray[0], addedImg.transform.position, addedImg.transform.rotation);
            }
            else if (addedImg.referenceImage.name == "Prism")
            {
                newPrisme = Instantiate(prismeArray[0], addedImg.transform.position, addedImg.transform.rotation);
            }
        }
        foreach (ARTrackedImage updatedImg in args.updated)
        {
            if (updatedImg.referenceImage.name == "Laser")
            {
                updatedImg.transform.GetPositionAndRotation(out Vector3 position, out Quaternion rotation);
                newLaser.transform.SetPositionAndRotation(position, rotation);
            }
            else if (updatedImg.referenceImage.name == "Prism")
            {
                updatedImg.transform.GetPositionAndRotation(out Vector3 position, out Quaternion rotation);
                newPrisme.transform.SetPositionAndRotation(position, rotation);
            }
        }
        /*foreach (ARTrackedImage removedImg in args.removed)
        {
            if (removedImg.referenceImage.name == laserPrefab.name) laserPrefabInstance.SetActive(false);
            else if (removedImg.referenceImage.name == prismPrefab.name) prismPrefabInstance.SetActive(false);

        }*/
    }
}
