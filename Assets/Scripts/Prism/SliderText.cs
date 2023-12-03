using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderText : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    [SerializeField] private GameObject _prism;
    private float _prismInitialScale;

    // Start is called before the first frame update
    void Start()
    {
        // retrive prism with tag
        string prismTag = _prism.gameObject.tag;
        if (prismTag.Equals("Prisme"))
        {
            _prismInitialScale = _prism.transform.localScale.x;
            _sliderText.text = "Size: " + _prismInitialScale.ToString();

        }



        _slider.onValueChanged.AddListener((v) =>
        {
            
            _sliderText.text = "Size: " + v.ToString("0");
        });
    }

    
}
