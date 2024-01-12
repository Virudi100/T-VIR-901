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
        selectPrismButton.SetActive(true);
        selectPrismShape.SetActive(true);
        prismMatEmpty.SetActive(false);
        prismShapeEmpty.SetActive(false);
    }

    public void ActivateShape()
    {
        prismShapeEmpty.SetActive(true);
        prismMatEmpty.SetActive(false);

        selectPrismButton.SetActive(false);
        selectPrismShape.SetActive(false);
    }

    public void ActivateMat()
    {
        prismShapeEmpty.SetActive(false);
        prismMatEmpty.SetActive(true);

        selectPrismButton.SetActive(false);
        selectPrismShape.SetActive(false);
    }

    public void DeactivateShape()
    {
        prismShapeEmpty.SetActive(false);

        selectPrismButton.SetActive(true);
        selectPrismShape.SetActive(true);
    }

    public void DeactivateMat()
    {
        prismMatEmpty.SetActive(false);

        selectPrismButton.SetActive(true);
        selectPrismShape.SetActive(true);
    }
}
