using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingMaker : MonoBehaviour
{
    public GameObject blueberryPrefab;
    public GameObject strawberryPrefab;

    public void ToppingMake(){
        GameObject toppingPrefab = null;
        var topping = SelectTopping();

        switch (topping){
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
        }
    }

    //トッピングを指定範囲内で抽選
    private ToppingList SelectTopping() 
    {
        var SelectedTopping = (ToppingList)Random.Range(1, 2);
        return SelectedTopping;
    }
}
