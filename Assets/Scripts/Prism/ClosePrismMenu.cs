using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ClosePrismMenu : MonoBehaviour
{
    public GameObject prismPanel;
    private BoxCollider panelCollider;
    public TouchHandler raycastHandler;

    // Start is called before the first frame update
    void Start()
    {
        panelCollider = prismPanel.GetComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

           /* if (touch.phase == TouchPhase.Began)
            {
                if (raycastHandler.RaycastScreenPosition(touch.position) &&
                    !RectTransformUtility.RectangleContainsScreenPoint(
                        prismPanel.GetComponent<RectTransform>(),
                        touch.position,
                        null))
                {
                    prismPanel.SetActive(false);
                }
            }*/
        }
    }


}
