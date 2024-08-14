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
        pancake.GetComponent<Pancake>().SetPancakeMaker(this); // パンケーキにPancakeMakerをセット
    }

    public void SetGameMaster(GameMaster master){
        _gameMaster = master;
    }

    // 焼き目確認
    public void Baked(PancakePart part){
        if(part.IsBaked()){
            // 全パーツに焼き目が付いているか確認し次の処理へ
            // 必要に応じて全体の焼け状態を管理するコードを追加
            Debug.Log("baked");
        }
    }

    // 焦げ確認
    public void Burnt(PancakePart part){
        if(part.IsBurnt()){
            Debug.Log("burnt");
            _gameMaster.ReduceLife(); // ゲームマスターにライフを減らす指示を出す
        }
    }
}
