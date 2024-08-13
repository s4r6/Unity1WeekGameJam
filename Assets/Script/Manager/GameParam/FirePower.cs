using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;

public class FirePower : MonoBehaviour
{
    ReactiveProperty<float> fire = new FloatReactiveProperty();
    public IReadOnlyReactiveProperty<float> fireProperty => fire;

    [SerializeField]
    float s_firePowerUpInterval = 20;
    [SerializeField]
    float fireIncreaseValue = 10;

    //一定間隔で火力アップ
    public async UniTask StartPowerUp(CancellationToken cancellationToken)
    {
        
        Debug.Log("火力アップ開始");
        while(true)
        {
            var ms_Interval = TranslateSecondToMs(s_firePowerUpInterval);
            await UniTask.Delay(ms_Interval, cancellationToken: cancellationToken);
            IncreaseFirePower(fireIncreaseValue);
        }
    }

    int TranslateSecondToMs(float second)   //秒をミリ秒に変換
    {
        var milliSecond = second * 1000;
        return (int)milliSecond;
    }

    void IncreaseFirePower(float increaseValue)
    {
        Debug.Log("火力アップ");
        if (increaseValue <= 0)
            throw new ArgumentOutOfRangeException("引数は正の整数でなくてはいけません.");
        fire.Value += increaseValue;
        Debug.Log("現在の火力:" + fire.Value);
    }

    void DecreaseFirePower(float decreaseValue)
    {
        if (decreaseValue <= 0)
            throw new ArgumentOutOfRangeException("引数は正の整数でなくてはいけません.");
        fire.Value -= decreaseValue;
    }
}
