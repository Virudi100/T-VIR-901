using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageLaserMenuSlider : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider sizeLaserSlider;

    public float sizeMinValue;
    public float sizeMaxValue;

    void Start()
    {
        sizeLaserSlider = GameObject.Find("SizeLaserSlider").GetComponent<Slider>();
        sizeLaserSlider.minValue = sizeMinValue;
        sizeLaserSlider.maxValue = sizeMaxValue;
         sizeLaserSlider.onValueChanged.AddListener(OnSliderChanged);
    }

    public void OnSliderChanged(float size)
    {
        transform.localScale = new Vector3(size, size, size);

    }


}
