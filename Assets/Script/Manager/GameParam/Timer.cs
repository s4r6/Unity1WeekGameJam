using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Timer : MonoBehaviour
{
    ReactiveProperty<float> time = new FloatReactiveProperty(0);
    public IReadOnlyReactiveProperty<float> timeProperty => time;

    bool isActive = false;
    void Update()
    {
        if (!isActive) return;
        time.Value += Time.deltaTime;
    }

    public void OnStart()
    {
        if (time.Value < 0)
            throw new ArgumentOutOfRangeException("開始時間が不正な値です");

        isActive = true;
    }

    public void OnStop()
    {
        isActive = false;
    }
}
