using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldRefraction : MonoBehaviour
{
    [SerializeField] private TMP_InputField mainInputField;
    [SerializeField] private PrismTouchHandler touchHandler;
    private float actualInput;

    private IndiceDeRefraction idrPrism;

    public void Start()
    {
        //Adds a listener to the main input field and invokes a method when the value changes.
        mainInputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the text field changes.
    public void ValueChangeCheck()
    {
        Debug.Log("Value Changed");
        float.TryParse(mainInputField.text,out actualInput);
        touchHandler.selectedPrime.GetComponent<IndiceDeRefraction>().iDR = actualInput;
    }
}
