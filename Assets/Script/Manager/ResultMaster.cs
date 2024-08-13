using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultMaster : MonoBehaviour
{
    [SerializeField]
    Text timeText;
    [SerializeField]
    Text successText; 

    public float time = 0;
    public int success = 0;


    void Start()
    {
        timeText.text = "Time:" + time;
        successText.text = "SuccessNum:" + success;
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("ëÂêºTest");
    }
}
