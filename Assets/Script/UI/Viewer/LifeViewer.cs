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

        /*
        //hpの整数部分のスライダーを1にする。
        for (int i = 1; i < onePlaceHP; i++)
        {
            Debug.Log(i - 1);
            lifeSliders[i - 1].padding = new Vector4(0, 0, 0, 0);
        }
        */
        //完全に削れている星と完全に残っている星の見た目を変更する
        for (int i = 0; i < lifeSliders.Count; i++) {

            if (i <= onePlaceHP) {
                lifeSliders[i].padding = new Vector4(0, 0, 0, 0);
            } else if (i > onePlaceHP) {
                lifeSliders[i].padding = new Vector4(0, 0, 0, 100);
            }
        }

        float decimalHP = currentHP - onePlaceHP;
        //HPが3の時に少数部分の計算を行わないので3以上の時にreturnする。
        if (hp >= 3)
        {
            return;
        }
        if (onePlaceHP >= 0) {
            //少数部分のスライダーを調整する
            lifeSliders[onePlaceHP].padding = new Vector4(0, 0, 0, 36 - (36 * decimalHP));
        }       
    }
}