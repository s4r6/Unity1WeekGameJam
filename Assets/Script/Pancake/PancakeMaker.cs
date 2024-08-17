using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeMaker : MonoBehaviour
{
    public GameObject pancakePrefab; // パンケーキオブジェクトのプレハブ

    //private PancakeMaker _pancakeMaker;
    [SerializeField]private GameMaster _gameMaster; // ゲームマスターの参照
    [SerializeField][Tooltip("フライパンからの相対位置")] private Vector3 _makePosition;
    [SerializeField] private GameObject _flyingPan;


    void Start(){
        //PancakeMake();
    }

    public void PancakeMake(){
        // パンケーキオブジェクトを生成、画面に表示
        GameObject pancake = Instantiate(pancakePrefab, _makePosition + _flyingPan.transform.position, Quaternion.identity);
        pancake.GetComponent<Pancake>().SetGameMaster(_gameMaster);
    }
}
