using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;
using Cysharp.Threading.Tasks;

public class ToppingMaker : MonoBehaviour
{
    public GameObject blueberryPrefab;
    public GameObject strawberryPrefab;
    public GameObject bananaPrefab;
    public GameObject chocolatePrefab;
    public GameObject nutsPrefab;
    public GameObject butterPrefab;
    private int _toppingNum;
    ReactiveProperty<ToppingList> nextTopping = new ReactiveProperty<ToppingList>();
    public IReactiveProperty<ToppingList> OnChangeNextTopping => nextTopping;

    [SerializeField][Tooltip("フライパンからの相対位置")] private Vector3 _dropPosition;
    [SerializeField] private GameObject _FlyingPan;
    [SerializeField] private GameMaster _gameMaster;
    private GameObject toppingPrefab;

    private float time;

    void Start()
    {
        nextTopping.Value = SelectTopping();    //開始時に次のトッピングを抽選    
        RoopMake(this.GetCancellationTokenOnDestroy()).Forget();
    }

    





    private async UniTask RoopMake(CancellationToken cancellationToken)
    {

        while (true)
        {
            await UniTask.Delay(10 * 1000, cancellationToken: cancellationToken);
            if (_gameMaster.GetTimeProperty().Value > 200)
            {
                if (toppingPrefab != null) {
                    Instantiate(toppingPrefab, _FlyingPan.transform.position + _dropPosition  , Quaternion.identity);
                }

            }
            await UniTask.Delay(10 * 1000, cancellationToken: cancellationToken);
            if (_gameMaster.GetTimeProperty().Value > 350)
            {
                if (toppingPrefab != null)
                {
                    Instantiate(toppingPrefab, _FlyingPan.transform.position + _dropPosition , Quaternion.identity);
                }
            }
            await UniTask.Delay(10 * 1000, cancellationToken: cancellationToken);
            if (_gameMaster.GetTimeProperty().Value > 500)
            {
                if (toppingPrefab != null)
                {
                    Instantiate(toppingPrefab, _FlyingPan.transform.position + _dropPosition, Quaternion.identity);
                }
            }
        }
    }

public void ToppingMake(){
        toppingPrefab = null;

        switch (nextTopping.Value){
            case ToppingList.blueberry:
                toppingPrefab = blueberryPrefab;
                _toppingNum = 2 + (int)(_gameMaster.GetTimeProperty().Value / 60);
                break;
            case ToppingList.strawberry:
                toppingPrefab = strawberryPrefab;
                _toppingNum = 1 + (int)(_gameMaster.GetTimeProperty().Value / 100);
                break;
            case ToppingList.banana:
                toppingPrefab = bananaPrefab;
                _toppingNum = 1 +(int)(_gameMaster.GetTimeProperty().Value / 60);
                break;
            case ToppingList.chocolate:
                toppingPrefab = chocolatePrefab;
                _toppingNum = 1 + (int)(_gameMaster.GetTimeProperty().Value / 150);
                break;
            case ToppingList.nuts:
                toppingPrefab = nutsPrefab;
                _toppingNum = 1 +(int)(_gameMaster.GetTimeProperty().Value / 200);
                break;
            case ToppingList.butter:
                toppingPrefab = butterPrefab;
                _toppingNum = 1 + +(int)(_gameMaster.GetTimeProperty().Value / 200);
                break;
        }

        //プレハブが設定されている場合、ゲーム上に生成
        if (toppingPrefab != null){
            for (int i = 0;i < _toppingNum;i++) {
                Instantiate(toppingPrefab, _FlyingPan.transform.position + _dropPosition + new Vector3(i * 0.5f,0,0), Quaternion.identity);
            }           
            nextTopping.Value = SelectTopping();    //次のトッピングを抽選
        }
    }

    //トッピングを指定範囲内で抽選
    private ToppingList SelectTopping() 
    {
        var SelectedTopping = (ToppingList)Random.Range(1, 7);
        return SelectedTopping;
    }

    public void ChangeTopping() {
        nextTopping.Value = SelectTopping();
    }
}
