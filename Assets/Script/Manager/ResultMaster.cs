using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class ResultMaster : MonoBehaviour
{
    [SerializeField]
    Text timeText;
    [SerializeField]
    Text successText;

    public float time { get; private set; }
    public int success { get; private set; }

    void Start()
    {
        TranslateTime();
        //timeText.text = "Time:" + time;
        successText.text = "SuccessNum:" + success;
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(
            SceneDictionary.TypeOfName[SceneType.InGame]
            );
    }

    public void SetParam(float _time, int _success)
    {
        time = _time;
        success = _success;
    }

    private void TranslateTime()
    {
        int hour = (int)time / 60;
        UnityEngine.Debug.Log(hour);
        int minute = (int)time % 60;
        UnityEngine.Debug.Log(minute);
        timeText.text = hour.ToString().PadLeft(2, '0') + ":" + minute.ToString().PadLeft(2, '0');
    }
}
