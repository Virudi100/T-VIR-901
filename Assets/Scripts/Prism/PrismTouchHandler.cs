using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrismTouchHandler : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private GameObject menuPrismeGameobject;
    [SerializeField] private GameObject menuLaserGameobject;
    [SerializeField] private Camera arCamera;

    [Header("Matérials")]
    [SerializeField] private Material[] PrismMat;


    [HideInInspector] public GameObject selectedPrime;
    [HideInInspector] public GameObject selectedLaser;

    [HideInInspector] public bool isLaser = false;
    [HideInInspector] public bool isPrism = false;


    void Start()
    {

        menuPrismeGameobject.SetActive(false);
        menuLaserGameobject.SetActive(false);


    }

    private void FixedUpdate()
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
                        isPrism = true;
                        isLaser = false;

                        menuPrismeGameobject.SetActive(true);
                        selectedPrime = hit.collider.gameObject;
                    }

                    if (hit.collider.tag == "Laser")
                    {
                        isLaser = true;
                        isPrism = false;
                        menuLaserGameobject.SetActive(true);
                        selectedLaser = hit.collider.gameObject;
                    }
                }
            }
        }
    }

    public void ChangeToGlass()
    {
        if (selectedPrime != null)
        {
            selectedPrime.GetComponent<MeshRenderer>().material = PrismMat[0];
        }
    }

    public void ChangeToDiamond()
    {
        if (selectedPrime != null)
        {
            selectedPrime.GetComponent<MeshRenderer>().material = PrismMat[1];
        }
    }

    public void ChangeToRuby()
    {
        if (selectedPrime != null)
        {
            selectedPrime.GetComponent<MeshRenderer>().material = PrismMat[2];
        }
    }

    public void ChangeToAmethyste()
    {
        if (selectedPrime != null)
        {
            selectedPrime.GetComponent<MeshRenderer>().material = PrismMat[3];
        }
    }

    public void ChangeToWater()
    {
        if (selectedPrime != null)
        {
            selectedPrime.GetComponent<MeshRenderer>().material = PrismMat[4];
        }
    }

    public void ChangeToHuile()
    {
        if (selectedPrime != null)
        {
            selectedPrime.GetComponent<MeshRenderer>().material = PrismMat[5];
        }
    }
}
