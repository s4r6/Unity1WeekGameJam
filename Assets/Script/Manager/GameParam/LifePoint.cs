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

    Subject<Unit> TimedOutEvent = new Subject<Unit>();
    public ISubject<Unit> OnTimeOut => TimedOutEvent;

    [SerializeField]
    float DecreaseValuePerSec = 0.005f;
    float DecreaseRate = 1;

    float prevLife = 0;

    void  Start()
    {
        prevLife = life.Value;

        StartLifeDecrease(this.GetCancellationTokenOnDestroy()).Forget();
    }

    //w’èŠÔ‚²‚Æ‚É‘Ì—ÍŒ¸­
    public async UniTask StartLifeDecrease(CancellationToken cancellationToken)
    {
        while (true)
        {
            var ms_DecreaseTime = TranslateSecondToMs(DecreaseRate);
            await UniTask.Delay(ms_DecreaseTime, cancellationToken: cancellationToken);
            SubtractLife(DecreaseValuePerSec);
            if(life.Value - prevLife <= -1)
            {
                TimedOutEvent.OnNext(default);
                SetPrevLife();
            }
            Debug.Log(life.Value);
        }
    }

    int TranslateSecondToMs(float second)   //•b‚ğƒ~ƒŠ•b‚É•ÏŠ·
    {
        var milliSecond = second * 1000;
        return (int)milliSecond;
    }

    public void SubtractLife(float minus = 1)
    {
        if (minus <= 0)
            throw new ArgumentOutOfRangeException("ˆø”‚Í³‚Ì®”‚Å‚È‚­‚Ä‚Í‚¢‚¯‚Ü‚¹‚ñ.");
        life.Value -= minus;
        if (life.Value < MINLIFE)
            life.Value = MINLIFE;
    }

    public void AddLife(int plus = 1)
    {
        if (plus <= 0)
            throw new ArgumentOutOfRangeException("ˆø”‚Í³‚Ì®”‚Å‚È‚­‚Ä‚Í‚¢‚¯‚Ü‚¹‚ñ.");
        life.Value += plus;
        if (life.Value > MAXLIFE)
            life.Value = MAXLIFE;
    }

    public void SetPrevLife()
    {
        prevLife = life.Value;
    }

    public float CalcLifeDifference()   //Œ»İ‚Ì‘Ì—Í‚Æ‘O‰ñ‚Ì‘Ì—Í‚Ì·‚ğ•Ô‚·
    {
        var returnValue = life.Value - prevLife;
        prevLife = life.Value;
        return returnValue;
    }
}
