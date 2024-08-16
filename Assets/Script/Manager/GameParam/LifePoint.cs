using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class LifePoint : MonoBehaviour
{
    [SerializeField]
    ReactiveProperty<float> life = new FloatReactiveProperty();
    public IReactiveProperty<float> lifeProperty => life;

    [SerializeField]
    float DecreaseValuePerSec = 0.005f;
    float DecreaseRate = 1;

    async void  Start()
    {
        await StartLifeDecrease();
    }

    //指定時間ごとに体力減少
    public async UniTask StartLifeDecrease()
    {
        Debug.Log("火力アップ開始");
        while (true)
        {
            var ms_DecreaseTime = TranslateSecondToMs(DecreaseRate);
            await UniTask.Delay(ms_DecreaseTime);
            SubtractLife(DecreaseValuePerSec);
            Debug.Log(life.Value);
        }
    }

    int TranslateSecondToMs(float second)   //秒をミリ秒に変換
    {
        var milliSecond = second * 1000;
        return (int)milliSecond;
    }

    public void SubtractLife(float minus = 1)
    {
        if (minus <= 0)
            throw new ArgumentOutOfRangeException("引数は正の整数でなくてはいけません.");
        life.Value -= minus;
        if (life.Value < 0)
            life.Value = 0;
    }

    public void AddLife(int plus = 1)
    {
        if (plus <= 0)
            throw new ArgumentOutOfRangeException("引数は正の整数でなくてはいけません.");
        life.Value += plus;
    }
}
