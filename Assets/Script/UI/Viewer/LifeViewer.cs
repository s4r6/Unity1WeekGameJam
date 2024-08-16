using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LifeViewer : MonoBehaviour
{
    [SerializeField] private List<RectMask2D> lifeSliders;

    private float currentHP;

    public void SetLife(float hp)
    {
        //Listが0からHPが0
        currentHP = hp;
        //currentHPの小数部分を切り捨てる。
        int onePlaceHP = Mathf.FloorToInt(currentHP);

        //hpの整数部分のスライダーを1にする。
        for (int i = 1; i < onePlaceHP; i++)
        {
            Debug.Log(i - 1);
            lifeSliders[i - 1].padding = new Vector4(0, 0, 0, 0);
        }

        float decimalHP = currentHP - onePlaceHP;
        //HPが3の時に少数部分の計算を行わないので3以上の時にreturnする。
        if (hp >= 3)
        {
            return;
        }
        //少数部分のスライダーを調整する
        lifeSliders[onePlaceHP].padding = new Vector4( 0, 0, 0,100-(100 * decimalHP));
    }
}