using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ToppingMaker : MonoBehaviour
{
    public GameObject blueberryPrefab;
    public GameObject strawberryPrefab;

    ReactiveProperty<ToppingList> nextTopping = new ReactiveProperty<ToppingList>();
    public IReactiveProperty<ToppingList> OnChangeNextTopping => nextTopping;


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
        }

        //プレハブが設定されている場合、ゲーム上に生成
        if (toppingPrefab != null){
            Instantiate(toppingPrefab, transform.position, Quaternion.identity);
            nextTopping.Value = SelectTopping();    //次のトッピングを抽選
        }
    }

    //トッピングを指定範囲内で抽選
    private ToppingList SelectTopping() 
    {
        var SelectedTopping = (ToppingList)Random.Range(1, 2);
        return SelectedTopping;
    }
}
