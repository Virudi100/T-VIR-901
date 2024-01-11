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

    [Header("Mat�rials")]
    [SerializeField] private Material diamondMat;
    [SerializeField] private Material glassMat;


    [HideInInspector] public GameObject selectedPrime;
    [HideInInspector] public GameObject selectedLaser;

    public bool isLaser = false;
    public bool isPrism = false;


    void Start()
    {

        menuPrismeGameobject.SetActive(false);
        menuLaserGameobject.SetActive(false);


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

    public void ChangeToDiamond()
    {
        if (selectedPrime != null)
        {
            selectedPrime.GetComponent<MeshRenderer>().material = diamondMat;
        }
    }

    public void ChangeToGlass()
    {
        if (selectedPrime != null)
        {
            selectedPrime.GetComponent<MeshRenderer>().material = glassMat;
        }
    }
}
