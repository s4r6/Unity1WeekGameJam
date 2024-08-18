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

    private float lifeDecressSpeedUpTime;
    private GameMaster _gameMaster;

    void Start()
    {
        prevLife = life.Value;

        StartLifeDecrease(this.GetCancellationTokenOnDestroy()).Forget();
        _gameMaster = GetComponent<GameMaster>();

    }

    private void Update()
    {
        lifeDecressSpeedUpTime += Time.deltaTime;
    }

    public void PancakeComplete() { 
        lifeDecressSpeedUpTime = 0;
    }


    //指定時間ごとに体力減少
    public async UniTask StartLifeDecrease(CancellationToken cancellationToken)
    {
        while (true)
        {
            var ms_DecreaseTime = TranslateSecondToMs(DecreaseRate);
            await UniTask.Delay(ms_DecreaseTime, cancellationToken: cancellationToken);
            if (lifeDecressSpeedUpTime > (50 / _gameMaster.GetFire()) * 3) {
                SubtractLife(DecreaseValuePerSec);//ライフ減少
            } 
            if (lifeDecressSpeedUpTime > (50 / _gameMaster.GetFire()) * 5) {
                SubtractLife(DecreaseValuePerSec);//ライフ減少
            }
            if (lifeDecressSpeedUpTime > (50 / _gameMaster.GetFire()) * 6)
            {
                SubtractLife(DecreaseValuePerSec);//ライフ減少
            }
            SubtractLife(DecreaseValuePerSec);//ライフ減少
            if (life.Value - prevLife <= -1)
            {
                TimedOutEvent.OnNext(default);
                SetPrevLife();
            }
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
        if (life.Value < MINLIFE)
            life.Value = MINLIFE;
    }

    public void AddLife(int plus = 1)
    {
        if (plus <= 0)
            throw new ArgumentOutOfRangeException("引数は正の整数でなくてはいけません.");
        life.Value += plus;
        if (life.Value > MAXLIFE)
            life.Value = MAXLIFE;
    }

    public void AddLifePropotionFire(float firepower) {
        if (firepower <= 0)
            throw new ArgumentOutOfRangeException("引数は正の整数でなくてはいけません.");
        life.Value += (50 / firepower) * 4 * DecreaseValuePerSec;
        if (life.Value > MAXLIFE)
            life.Value = MAXLIFE;
    }

    public void SetPrevLife()
    {
        prevLife = life.Value;
    }

    public float CalcLifeDifference()   //現在の体力と前回の体力の差を返す
    {
        var returnValue = life.Value - prevLife;
        prevLife = life.Value;
        return returnValue;
    }
}
