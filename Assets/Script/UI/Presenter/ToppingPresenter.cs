using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ToppingPresenter : MonoBehaviour
{
    [SerializeField] private GameMaster gameMaster;
    [SerializeField] private ToppingViewer toppingViewer;
    
    void Start()
    {
        //gameMaster.GetNextTopping().Subscribe(toppingViewer.SetNextToppingImage).AddTo(this);
    }
    
}
