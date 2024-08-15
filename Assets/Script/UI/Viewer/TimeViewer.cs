using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpText;
    public void SetTime(float time)
    {
        tmpText.text = time.ToString("f1");
    }
}
