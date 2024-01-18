using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ManageSliderHandleColor : MonoBehaviour
{
    // Drag & drop slider
    public UnityEngine.UI.Slider slider;

    // Drag & drop handle
    public UnityEngine.UI.Image handle;

    [SerializeField] private ColorContainer colorCont;

    public void Start()
    {
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        handle.color = Color.HSVToRGB(slider.value, 1, 1);

        colorCont.handleColor = handle.color;
    }
}
