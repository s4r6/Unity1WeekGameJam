using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using System;

public class LifePoint : MonoBehaviour
{
    [SerializeField]
    ReactiveProperty<int> life = new IntReactiveProperty();
    public IReactiveProperty<int> lifeProperty => life;

    public void SubtractLife(int minus = 1)
    {
        if (minus <= 0)
            throw new ArgumentOutOfRangeException("引数は正の整数でなくてはいけません.");
        life.Value -= minus;
        if (life.Value < 0)
            life.Value = 0;

        Debug.Log("Damage:" + minus);
        Debug.Log("現在体力:" + life.Value);
    }

    public void AddLife(int plus = 1)
    {
        if (plus >= 0)
            throw new ArgumentOutOfRangeException("引数は正の整数でなくてはいけません.");
        life.Value += plus;
    }
}
