using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class LampeTorcheController : MonoBehaviour
{
    private AndroidJavaObject cameraManager;
    private bool isFlashlightOn = false;

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // Obtenez l'activit� principale de l'application
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            // R�cup�rez l'objet AndroidJavaObject pour le gestionnaire de cam�ra
            AndroidJavaClass cameraClass = new AndroidJavaClass("android.hardware.camera2.CameraManager");
            cameraManager = cameraClass.CallStatic<AndroidJavaObject>("fromContext", currentActivity);
        }
        else
        {
            Debug.LogError("Cette fonctionnalit� n'est support�e que sur Android.");
        }
    }

    public void ToggleFlashlight()
    {
        if (isFlashlightOn)
        {
            TurnOffFlashlight();
        }
        else
        {
            TurnOnFlashlight();
        }

        isFlashlightOn = !isFlashlightOn;
    }

    private void TurnOnFlashlight()
    {
        if (cameraManager != null)
        {
            string[] cameraIds = cameraManager.Call<string[]>("getCameraIdList");

            if (cameraIds.Length > 0)
            {
                cameraManager.Call("setTorchMode", cameraIds[0], true);
            }
        }
    }

    private void TurnOffFlashlight()
    {
        if (cameraManager != null)
        {
            string[] cameraIds = cameraManager.Call<string[]>("getCameraIdList");

            if (cameraIds.Length > 0)
            {
                cameraManager.Call("setTorchMode", cameraIds[0], false);
            }
        }
    }
}