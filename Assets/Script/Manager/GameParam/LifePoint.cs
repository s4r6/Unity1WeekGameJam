using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;

public class LifePoint : MonoBehaviour
{
    public static readonly int MINLIFE = 0;
    public static readonly int MAXLIFE = 3;

    [SerializeField]
    ReactiveProperty<float> life = new FloatReactiveProperty();
    public IReactiveProperty<float> lifeProperty => life;

    [SerializeField]
    float DecreaseValuePerSec = 0.005f;
    float DecreaseRate = 1;

    void  Start()
    {
        StartLifeDecrease(this.GetCancellationTokenOnDestroy()).Forget();
    }

    //éwíËéûä‘Ç≤Ç∆Ç…ëÃóÕå∏è≠
    public async UniTask StartLifeDecrease(CancellationToken cancellationToken)
    {
        while (true)
        {
            var ms_DecreaseTime = TranslateSecondToMs(DecreaseRate);
            await UniTask.Delay(ms_DecreaseTime, cancellationToken: cancellationToken);
            SubtractLife(DecreaseValuePerSec);
            Debug.Log(life.Value);
        }
    }

    int TranslateSecondToMs(float second)   //ïbÇÉ~ÉäïbÇ…ïœä∑
    {
        var milliSecond = second * 1000;
        return (int)milliSecond;
    }

    public void SubtractLife(float minus = 1)
    {
        if (minus <= 0)
            throw new ArgumentOutOfRangeException("à¯êîÇÕê≥ÇÃêÆêîÇ≈Ç»Ç≠ÇƒÇÕÇ¢ÇØÇ‹ÇπÇÒ.");
        life.Value -= minus;
        if (life.Value < MINLIFE)
            life.Value = MINLIFE;
    }

    public void AddLife(int plus = 1)
    {
        if (plus <= 0)
            throw new ArgumentOutOfRangeException("à¯êîÇÕê≥ÇÃêÆêîÇ≈Ç»Ç≠ÇƒÇÕÇ¢ÇØÇ‹ÇπÇÒ.");
        life.Value += plus;
        if (life.Value > MAXLIFE)
            life.Value = MAXLIFE;
    }
}
