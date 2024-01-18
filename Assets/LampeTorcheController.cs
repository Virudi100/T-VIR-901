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
            // Obtenez l'activité principale de l'application
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            // Récupérez l'objet AndroidJavaObject pour le gestionnaire de caméra
            AndroidJavaClass cameraClass = new AndroidJavaClass("android.hardware.camera2.CameraManager");
            cameraManager = cameraClass.CallStatic<AndroidJavaObject>("fromContext", currentActivity);
        }
        else
        {
            Debug.LogError("Cette fonctionnalité n'est supportée que sur Android.");
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