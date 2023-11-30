using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismSettings : MonoBehaviour
{   
    public GameObject prismPanel; 

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "Prisme")
                    {
                        // Activez votre menu panel ici
                        prismPanel.SetActive(true);
                    }
                }
            }
        }
    }
}
