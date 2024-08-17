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
            case ToppingList.banana:
                nextToppingImage.sprite = toppingImageList[2];
                break;
            case ToppingList.chocolate:
                nextToppingImage.sprite = toppingImageList[3];
                break;
            case ToppingList.nuts:
                nextToppingImage.sprite = toppingImageList[4];
                break;
            case ToppingList.butter:
                nextToppingImage.sprite = toppingImageList[5];
                break;
            default:
                break;
        }
    }
}