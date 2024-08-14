using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeMaker : MonoBehaviour
{
    public GameObject pancakePrefab; // パンケーキオブジェクトのプレハブ
    private GameMaster _gameMaster; // ゲームマスターの参照

    void Start(){
        PancakeMake();
    }

    public void PancakeMake(){
        // パンケーキオブジェクトを生成、画面に表示
        GameObject pancake = Instantiate(pancakePrefab, transform.position, Quaternion.identity);
        
        // パンケーキにPancakeMakerをセット
        Pancake pancakeScript = pancake.GetComponent<PancakeMake>();
        if (pancakeScript != null){
            pancakeScript.SetPancakeMaker(this);

            // 生成したパンケーキオブジェクトにGameMasterをセット
            pancakeScript.SetGameMaster(_gameMaster);
        }
    }

    public void SetGameMaster(GameMaster master){
        _gameMaster = master;
    }
}
