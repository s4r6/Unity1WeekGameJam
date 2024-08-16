using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ToppingPresenter : MonoBehaviour
{
    [SerializeField] private ToppingMaker toppingMaker;
    [SerializeField] private ToppingViewer toppingViewer;
    
    void Start()
    {
        toppingMaker.OnChangeNextTopping.Subscribe(toppingViewer.SetNextToppingImage).AddTo(this);
    }
    
}
