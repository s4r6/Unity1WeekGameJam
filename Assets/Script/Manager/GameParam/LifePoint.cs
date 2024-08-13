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
            throw new ArgumentOutOfRangeException("ˆø”‚Í³‚Ì®”‚Å‚È‚­‚Ä‚Í‚¢‚¯‚Ü‚¹‚ñ.");
        life.Value -= minus;
        if (life.Value < 0)
            life.Value = 0;

        Debug.Log("Damage:" + minus);
        Debug.Log("Œ»İ‘Ì—Í:" + life.Value);
    }

    public void AddLife(int plus = 1)
    {
        if (plus >= 0)
            throw new ArgumentOutOfRangeException("ˆø”‚Í³‚Ì®”‚Å‚È‚­‚Ä‚Í‚¢‚¯‚Ü‚¹‚ñ.");
        life.Value += plus;
    }
}
