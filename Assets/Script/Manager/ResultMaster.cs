using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultMaster : MonoBehaviour
{
    [SerializeField]
    Text timeText;
    [SerializeField]
    Text successText; 

    float time;
    int success;

    void Awake()
    {
        Debug.Log("Awake:" + time);    
    }

    void Start()
    {
        Debug.Log("Start:" + time);
        timeText.text = "Time:" + time;
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
}
