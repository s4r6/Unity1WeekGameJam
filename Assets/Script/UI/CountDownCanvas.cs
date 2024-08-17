using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        StartCoroutine(ThreeCountDown());
    }

    IEnumerator ThreeCountDown()
    {
        int count = 3;
        while (count >= 0)
        {
            textMeshProUGUI.text = count.ToString();
            yield return new WaitForSeconds(1.0f);
            count -= 1;
            Debug.Log(count);
        }
        Destroy(this.gameObject);
    }
}
