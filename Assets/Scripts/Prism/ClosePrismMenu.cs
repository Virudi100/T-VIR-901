using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ClosePrismMenu : MonoBehaviour
{
    public GameObject prismPanel;
 

    public void CloseUi()
    {
        prismPanel.SetActive(false);
    }

    public void CloseUiLaser()
    {
        prismPanel.SetActive(false);
    }


}
