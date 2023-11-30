using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismTouchHandler : MonoBehaviour
{
    public GameObject prismPanel;
    public Camera arCamera;


    void Start()
    {
        prismPanel.SetActive(false);
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("Je suis rentrée");

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Prisme")
                    {
                        Debug.Log("Prisme touché");

                        prismPanel.SetActive(true);
                    }
                }
            }
        }
    }
}
