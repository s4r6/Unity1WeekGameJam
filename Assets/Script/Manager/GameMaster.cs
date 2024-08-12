using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class GameMaster : MonoBehaviour
{
    LifePoint lifePoint;
    Timer timer;
    FirePower firepower;




    void Awake()
    {
        lifePoint = GetComponent<LifePoint>();
        timer = GetComponent<Timer>();
        firepower = GetComponent<FirePower>();

        timer.timeProperty    //カウントダウンが0以下になったらシーン遷移
            .Where(x => x <= 0)
            .Subscribe(_ =>
            {
                OnSceneTransition();
                //シーン遷移
                Debug.Log("シーン遷移");
            }).AddTo(this);

        lifePoint.lifeProperty
            .Where(x => x <= 0)
            .Subscribe(_ =>
            {
                OnSceneTransition();
                Debug.Log("シーン遷移");
                //シーン遷移
            }).AddTo(this);
    }

    void Start()
    {
        timer.OnStart();　//カウントダウンスタート
        firepower.StartPowerUp(this.GetCancellationTokenOnDestroy()).Forget();
        //パンケーキを作成
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))    //デバッグ用"O"キーが押されるとダメージ
            PancakeComplete(false);
        
            
    }

    //シーン遷移時の後処理
    void OnSceneTransition()
    {
        timer.OnStop();
    }

    //falseなら焦げた(失敗),trueならきれいに焼けた(成功)
    public void PancakeComplete(bool pancakeState)
    {
        if (!pancakeState)
            lifePoint.SubtractLife();

        //パンケーキ作成
        //トッピング作成

    }

    //現在の火力を外部に公開
    public float GetFire()
    {
        return firepower.fireProperty.Value;
    }

    //時間のReactivePropertyを外部に公開
    public IReadOnlyReactiveProperty<float> GetTimeProperty()
    {
        return timer.timeProperty;
    }

    //体力のReactivePropertyを外部に公開
    public IReadOnlyReactiveProperty<int> GetLifeProperty()
    {
        return lifePoint.lifeProperty;
    }

    //次のトッピングを公開(仮でstring型)
    public IReadOnlyReactiveProperty<string> GetNextTopping()
    {
        return default;
    }
}
