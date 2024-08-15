using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TimePresenter : MonoBehaviour
{
    [SerializeField] private GameMaster gameMaster;

    [SerializeField] private TimeViewer timeViewer;

    // Start is called before the first frame update
    void Start()
    {
        gameMaster.GetTimeProperty().Subscribe(timeViewer.SetTime);
    }
}