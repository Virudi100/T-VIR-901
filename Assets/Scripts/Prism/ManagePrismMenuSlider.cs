using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePrismMenuSlider : MonoBehaviour
{
    private Slider sizeSlider;
    
    //Set up min & max size value
    public float sizeMinValue;
    public float sizeMaxValue;

    // Start is called before the first frame update
    void Start()
    {
        //Apply min and max value to the slider
        sizeSlider = GameObject.Find("SizeSlider").GetComponent<Slider>();
        sizeSlider.minValue = sizeMinValue;
        sizeSlider.maxValue = sizeMaxValue;
        sizeSlider.onValueChanged.AddListener(OnSliderChanged);
    }

   public void OnSliderChanged(float size)
    {
        //Change scale when slider value change
        transform.localScale = new Vector3(size, size, size);
    }
}
