using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpText;

    public void SetTime(float time)
    {
        int hour = (int) time / 60;
        int minute = (int) time % 60;
        tmpText.text = hour.ToString().PadLeft(2, '0') + ":" + minute.ToString().PadLeft(2, '0');
    }
}