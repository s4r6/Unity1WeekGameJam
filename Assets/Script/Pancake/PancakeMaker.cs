using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeMaker : MonoBehaviour
{
    public GameObject pancakePrefab; // パンケーキオブジェクトのプレハブ
    private PancakeMaker _pancakeMaker;
    private GameMaster _gameMaster; // ゲームマスターの参照

    void Start(){
        PancakeMake();
    }

    public void PancakeMake(){
        // パンケーキオブジェクトを生成、画面に表示
        GameObject pancake = Instantiate(pancakePrefab, transform.position, Quaternion.identity);
        
        // 生成したパンケーキオブジェクトにGameMasterをセット
        if (_gameMaster != null){
            pancake.SendMessage("SetGameMaster", _gameMaster, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void SetGameMaster(GameMaster master){
        _gameMaster = master;
    }
}
