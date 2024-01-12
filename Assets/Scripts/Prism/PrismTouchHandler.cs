using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrismTouchHandler : MonoBehaviour
{
    [SerializeField] private CustomImageTracker imageTrackeur;

    [Header("Setup")]
    [SerializeField] private GameObject menuPrismeGameobject;
    [SerializeField] private GameObject menuLaserGameobject;
    [SerializeField] private Camera arCamera;

    [Header("Matérials")]
    [SerializeField] private Material[] PrismMat;

    [Header("Prism Shapes")]
    [SerializeField] private GameObject[] prisms;

    [Header("Laser Shapes")]
    [SerializeField] private GameObject[] lasers;


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

    ////////////////////////////////////////////////// MATERIALS///////////////////////////////
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

    ////////////////////////////////////////////////// Prism Shape///////////////////////////////

    public void ChangeToPrism1()
    {
        GameObject newPrism;
        newPrism = Instantiate(prisms[0], new Vector3(selectedPrime.transform.position.x, selectedPrime.transform.position.y, selectedPrime.transform.position.z), Quaternion.identity);
        Destroy(selectedPrime);
        selectedPrime = newPrism;
        imageTrackeur.newPrisme = selectedPrime;
    }

    public void ChangeToPrism2()
    {
        GameObject newPrism;
        newPrism = Instantiate(prisms[1], new Vector3(selectedPrime.transform.position.x, selectedPrime.transform.position.y, selectedPrime.transform.position.z), Quaternion.identity);
        Destroy(selectedPrime);
        selectedPrime = newPrism;
        imageTrackeur.newPrisme = selectedPrime;
    }

    public void ChangeToPrism3()
    {
        GameObject newPrism;
        newPrism = Instantiate(prisms[2], new Vector3(selectedPrime.transform.position.x, selectedPrime.transform.position.y, selectedPrime.transform.position.z), Quaternion.identity);
        Destroy(selectedPrime);
        selectedPrime = newPrism;
        imageTrackeur.newPrisme = selectedPrime;
    }

    ////////////////////////////////////////////////// LASERS///////////////////////////////

    public void ChangeToLaser1()
    {
        GameObject newLaser;
        newLaser = Instantiate(lasers[0], new Vector3(selectedLaser.transform.position.x, selectedLaser.transform.position.y, selectedLaser.transform.position.z), Quaternion.identity);
        Destroy(selectedLaser);
        selectedLaser = newLaser;
        imageTrackeur.newLaser = selectedLaser;
    }

    public void ChangeToLaser2()
    {
        GameObject newLaser;
        newLaser = Instantiate(lasers[1], new Vector3(selectedLaser.transform.position.x, selectedLaser.transform.position.y, selectedLaser.transform.position.z), Quaternion.identity);
        Destroy(selectedLaser);
        selectedLaser = newLaser;
        imageTrackeur.newLaser = selectedLaser;
    }

    public void ChangeToLaser3()
    {
        GameObject newLaser;
        newLaser = Instantiate(lasers[2], new Vector3(selectedLaser.transform.position.x, selectedLaser.transform.position.y, selectedLaser.transform.position.z), Quaternion.identity);
        Destroy(selectedLaser);
        selectedLaser = newLaser;
        imageTrackeur.newLaser = selectedLaser;
    }
}
