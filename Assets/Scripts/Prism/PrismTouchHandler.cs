using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrismTouchHandler : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private GameObject menuGameobject;
    [SerializeField] private Camera arCamera;

    [Header("Mat�rials")]
    [SerializeField] private Material diamondMat;
    [SerializeField] private Material glassMat;


    [HideInInspector] public GameObject selectedPrime;

    void Start()
    {
        menuGameobject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("Je suis rentr�e");

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Prisme")
                    {
                        Debug.Log("Prisme touch�");

                        menuGameobject.SetActive(true);
                        selectedPrime = hit.collider.gameObject;
                    }
                }
            }
        }
    }

    public void ChangeToDiamond()
    {
        if(selectedPrime != null)
        {
            selectedPrime.GetComponent<MeshRenderer>().material = diamondMat;
        }
    }

    public void ChangeToGlass()
    {
        if(selectedPrime != null)
        {
            selectedPrime.GetComponent<MeshRenderer>().material = glassMat;
        }
    }
}
