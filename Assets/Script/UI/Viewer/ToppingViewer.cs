using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToppingViewer : MonoBehaviour
{
    //0にブルーベリー、1にストロベリーを
    [SerializeField] private Sprite[] toppingImageList;

    [SerializeField] private Image nextToppingImage;

    public void SetNextToppingImage(ToppingList nextToppingList)
    {
        switch (nextToppingList)
        {
            case ToppingList.blueberry:
                nextToppingImage.sprite = toppingImageList[0];
                break;
            case ToppingList.strawberry:
                nextToppingImage.sprite = toppingImageList[1];
                break;
            default:
                Debug.Log("対応したトッピングがありません。");
                break;
        }
    }
}