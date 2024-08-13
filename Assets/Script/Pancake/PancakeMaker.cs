using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeMaker : MonoBehaviour
{
    public GameObject Pancake;
    public Transform parentTransform;
    public float BakedDegree; //各パンケーキパーツの焼け具合
    private int BakedCount; //きれいに焼けた数
    private int BurntCount; //焦げた数
    bool pancakeState = false; //パンケーキ全体が焼けたか焦げたか

    void Start(){
        BakedDegree = 0;
        BakedCount = 0;
        BurntCount = 0;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.R)){
            BakedDegree = 0;
        }
        if (Input.GetKeyDown(KeyCode.H)){
            BakedDegree = 50;
        }
        if (Input.GetKeyDown(KeyCode.M)){
            BakedDegree = 100;
        }

        /*焼け焦げ確認*/
        if (BakedCount == 10){
            Destroy(Pancake);
            pancakeState = true;
        }
        else if (BurntCount == 5){
            Destroy(Pancake);
            pancakeState = false;
        }
        // 100%焼き目がつく or 50%焦げるまで確認
        else if (BakedCount < 10 || BurntCount < 5){
            if (Baked(BakedDegree) == 0){
                BakedCount++;
            }
            if (Burnt(BakedDegree) == 0){
                BurntCount++;
            }
        }
    }

    void PancakeMake(){
        Instantiate(Pancake, parentTransform);
    }

    /**
    *パーツが１つ焼けたことを認識
    *
    *引数
    *BakedDegree：焼け具合
    *
    *返値
    *   0：焼けてる
    *   負値：生焼け
    */
    int Baked(float BakedDegree){
        if (BakedDegree >= 50){
            Debug.Log("焼けたぞ");
            return 0;
        }
        return -1;
    }

    /**
    *パーツが１つ焦げたことを認識
    *
    *引数
    *BakedDegree:焼け具合
    *
    *返値
    *   0：焦げた
    *   負値:焦げてない(焼けてる)
    */
    int Burnt(float BakedDegree){
        if (BakedDegree >= 100){
            Debug.Log("焦げたぞ！");
            return 0;
        }
        return -1;
    }
}
