using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CustomImageTracker : MonoBehaviour
{
    [Header("AR Session Origin's Components")]
    [SerializeField] private ARTrackedImageManager manager;

    [Header("Prefabs")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject prismPrefab;

    private GameObject laserPrefabInstance;
    private GameObject prismPrefabInstance;

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
            if (addedImg.referenceImage.name == laserPrefab.name)
            {
                laserPrefabInstance = Instantiate(laserPrefab, addedImg.transform.position, addedImg.transform.rotation);
            }
            else if (addedImg.referenceImage.name == prismPrefab.name)
            {
                prismPrefabInstance = Instantiate(prismPrefab, addedImg.transform.position, addedImg.transform.rotation);
            }
        }
        foreach (ARTrackedImage updatedImg in args.updated)
        {
            if (updatedImg.referenceImage.name == laserPrefab.name)
            {
                updatedImg.transform.GetPositionAndRotation(out Vector3 position, out Quaternion rotation);
                laserPrefabInstance.transform.SetPositionAndRotation(position, rotation);
            }
            else if (updatedImg.referenceImage.name == prismPrefab.name)
            {
                updatedImg.transform.GetPositionAndRotation(out Vector3 position, out Quaternion rotation);
                prismPrefabInstance.transform.SetPositionAndRotation(position, rotation);
            }
        }
        foreach (ARTrackedImage removedImg in args.removed)
        {
            if (removedImg.referenceImage.name == laserPrefab.name) laserPrefabInstance.SetActive(false);
            else if (removedImg.referenceImage.name == prismPrefab.name) prismPrefabInstance.SetActive(false);

        }
    }
}
