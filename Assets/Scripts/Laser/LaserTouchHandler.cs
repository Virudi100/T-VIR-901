using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserTouchHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject menuGameObject;
    [SerializeField] private Camera arCamera;
    [HideInInspector] public GameObject selectedLaser;

    void Start()
    {
        menuGameObject.SetActive(false);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray=arCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.tag == "Laser")
                    {
                        menuGameObject.SetActive(true);
                        selectedLaser=hit.collider.gameObject;
                    }
                    
                }
            }
        }



    }
}
