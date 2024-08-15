using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LifePresenter : MonoBehaviour
{
    [SerializeField] private GameMaster gameMaster;
    [SerializeField] private LifeViewer lifeViewer;

    private void Start()
    {
        gameMaster.GetLifeProperty().Subscribe(lifeViewer.SetLife).AddTo(this);
    }
}
