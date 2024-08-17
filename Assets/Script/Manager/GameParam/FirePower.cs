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
    [SerializeField]
    float startFirePower;

    private void Start()
    {
        fire.Value = startFirePower;

    }

    //ˆê’èŠÔŠu‚Å‰Î—ÍƒAƒbƒv
    public async UniTask StartPowerUp(CancellationToken cancellationToken)
    {
        
        while(true)
        {
            var ms_Interval = TranslateSecondToMs(s_firePowerUpInterval);
            await UniTask.Delay(ms_Interval, cancellationToken: cancellationToken);
            IncreaseFirePower(fireIncreaseValue);
        }
    }

    int TranslateSecondToMs(float second)   //•b‚ðƒ~ƒŠ•b‚É•ÏŠ·
    {
        var milliSecond = second * 1000;
        return (int)milliSecond;
    }

    void IncreaseFirePower(float increaseValue)
    {
        if (increaseValue <= 0)
            throw new ArgumentOutOfRangeException("ˆø”‚Í³‚Ì®”‚Å‚È‚­‚Ä‚Í‚¢‚¯‚Ü‚¹‚ñ.");
        fire.Value += increaseValue;
    }
}
