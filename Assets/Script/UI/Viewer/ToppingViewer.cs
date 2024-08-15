using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToppingViewer : MonoBehaviour
{
    [SerializeField] private Sprite[] toppingImageList;

    [SerializeField] private Image nextToppingImage;
    
    public void SetNextToppingImage(string nextTopping)
    {
        Debug.Log($"next:{nextTopping}");
        switch (nextTopping)
        {
            //case ""
        }
    }
}
