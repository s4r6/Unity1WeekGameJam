using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlypanPowerViewer : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetPowerSlider(float powerPercent)
    {
        slider.value = powerPercent;
    }
}
