using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ToppingMaker : MonoBehaviour
{
    public GameObject blueberryPrefab;
    public GameObject strawberryPrefab;
    public GameObject bananaPrefab;
    public GameObject chocolatePrefab;
    public GameObject nutsPrefab;
    public GameObject butterPrefab;
    ReactiveProperty<ToppingList> nextTopping = new ReactiveProperty<ToppingList>();
    public IReactiveProperty<ToppingList> OnChangeNextTopping => nextTopping;

    [SerializeField][Tooltip("フライパンからの相対位置")] private Vector3 _dropPosition;
    [SerializeField] private GameObject _FlyingPan;

    void Start()
    {
        nextTopping.Value = SelectTopping();    //開始時に次のトッピングを抽選    
    }

    public void ToppingMake(){
        GameObject toppingPrefab = null;

        switch (nextTopping.Value){
            case ToppingList.blueberry:
                toppingPrefab = blueberryPrefab;
                break;
            case ToppingList.strawberry:
                toppingPrefab = strawberryPrefab;
                break;
            case ToppingList.banana:
                toppingPrefab = bananaPrefab;
                break;
            case ToppingList.chocolate:
                toppingPrefab = chocolatePrefab;
                break;
            case ToppingList.nuts:
                toppingPrefab = nutsPrefab;
                break;
            case ToppingList.butter:
                toppingPrefab = butterPrefab;
                break;
        }

        //プレハブが設定されている場合、ゲーム上に生成
        if (toppingPrefab != null){
            Instantiate(toppingPrefab, _FlyingPan.transform.position + _dropPosition, Quaternion.identity);
            nextTopping.Value = SelectTopping();    //次のトッピングを抽選
        }
    }

    //トッピングを指定範囲内で抽選
    private ToppingList SelectTopping() 
    {
        var SelectedTopping = (ToppingList)Random.Range(1, 6);
        return SelectedTopping;
    }
}
