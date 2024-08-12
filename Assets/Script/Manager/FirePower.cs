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
    float firePowerUpInterval = 20;
    [SerializeField]
    float fireIncreaseValue = 10;

    //一定間隔で火力アップ
    public async UniTask StartPowerUp(CancellationToken cancellationToken)
    {
        while(true)
        {
            await UniTask.Delay((int)firePowerUpInterval, cancellationToken: cancellationToken);
            IncreaseFirePower(fireIncreaseValue);
        }
    }

    void IncreaseFirePower(float increaseValue)
    {
        if (increaseValue <= 0)
            throw new ArgumentOutOfRangeException("引数は正の整数でなくてはいけません.");
        fire.Value += increaseValue;
    }

    void DecreaseFirePower(float decreaseValue)
    {
        if (decreaseValue <= 0)
            throw new ArgumentOutOfRangeException("引数は正の整数でなくてはいけません.");
        fire.Value -= decreaseValue;
    }
}
