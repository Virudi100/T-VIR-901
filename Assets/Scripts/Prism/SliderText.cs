using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderText : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    [SerializeField] private PrismTouchHandler touchhandler;

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        //Change size slider text
        Debug.Log(_slider.value);
        if (touchhandler.isLaser == true) {
            touchhandler.selectedLaser.gameObject.transform.localScale = new Vector3(_slider.value, _slider.value, _slider.value);
            _sliderText.text = "Size: " + _slider.value.ToString();
        }

        if(touchhandler.isPrism == true)
        {
            touchhandler.selectedPrime.gameObject.transform.localScale = new Vector3(_slider.value, _slider.value, _slider.value);
            _sliderText.text = "Size: " + _slider.value.ToString();
        }
    }
}
