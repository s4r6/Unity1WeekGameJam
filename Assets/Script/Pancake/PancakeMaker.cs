using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeMaker : MonoBehaviour
{
    public float BakedDegree; //焼け具合
    bool pancakeState = false; //焼けたとか焦げたとか

    void Start(){
        BakedDegree = 0;
    }

    void Update(){
        BakedDegree++;
        Baked(BakedDegree);
        if (pancakeState){
            Burnt(BakedDegree);
        }
    }

    /**
    *パーツが１つ焼けたことを認識
    *
    *引数
    *BakedDegree：焼け具合
    *
    *返値
    *なし
    */
    void Baked(float BakedDegree){
        if (BakedDegree >= 50){
            Debug.Log("焼けたぞ");
            bool pancakeState = true;
        }
    }

    /**
    *パーツが１つ焦げたことを認識
    *
    *引数
    *BakedDegree:焼け具合
    *
    *返値
    *なし
    */
    void Burnt(float BakedDegree){
        if (BakedDegree >= 100){
            Debug.Log("焦げたぞ！");
            bool pancakeState = false;
        }
    }
}
