using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismMenuManager : MonoBehaviour
{
    [Header("Prism UI Elements")]
    [SerializeField] private GameObject selectPrismButton;
    [SerializeField] private GameObject selectPrismShape;
    [SerializeField] private GameObject prismMatEmpty;
    [SerializeField] private GameObject prismShapeEmpty;

    // Start is called before the first frame update
    void Start()
    {
        //Setup ui on start
        selectPrismButton.SetActive(true);
        selectPrismShape.SetActive(true);
        prismMatEmpty.SetActive(false);
        prismShapeEmpty.SetActive(false);
    }

    public void ActivateShape()
    {
        //Activate prism shape ui
        prismShapeEmpty.SetActive(true);
        prismMatEmpty.SetActive(false);

        selectPrismButton.SetActive(false);
        selectPrismShape.SetActive(false);
    }

    public void ActivateMat()
    {
        //Activate prism materials ui
        prismShapeEmpty.SetActive(false);
        prismMatEmpty.SetActive(true);

        selectPrismButton.SetActive(false);
        selectPrismShape.SetActive(false);
    }

    public void DeactivateShape()
    {
        //Deactivate prism shape ui
        prismShapeEmpty.SetActive(false);

        selectPrismButton.SetActive(true);
        selectPrismShape.SetActive(true);
    }

    public void DeactivateMat()
    {
        //Deactivate prism materials ui
        prismMatEmpty.SetActive(false);

        selectPrismButton.SetActive(true);
        selectPrismShape.SetActive(true);
    }
}
