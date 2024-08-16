using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;
public class GameMaster : MonoBehaviour
{
    [SerializeField]
    string gameMode = "Debug";  //Debug,Buildでモードを切り替える(Rankingに送信するかしないか決定)

    [SerializeField][Tooltip("パンケーキメーカー")] private PancakeMaker _pancakeMaker;
    [SerializeField] [Tooltip("トッピングメーカー")] private ToppingMaker _toppingMaker;

    //[SerializeField][Tooltip("次に墜ちてくるトッピング")] private ToppingList _nextTopping;
    ReactiveProperty<ToppingList> nextTopping = new ReactiveProperty<ToppingList>();
    IReadOnlyReactiveProperty<ToppingList> nextToppingProperty => nextTopping;

    //Gameで使用する各パラメータ
    LifePoint lifePoint;
    Timer timer;
    FirePower firepower;
    SuccessCount successCount;

    //スコアを保存しておくデータベース(Ranking)
    [Inject]
    IRepositiory repository; 

    void Awake()
    {
        lifePoint = GetComponent<LifePoint>();
        timer = GetComponent<Timer>();
        firepower = GetComponent<FirePower>();
        successCount = GetComponent<SuccessCount>();

        lifePoint.lifeProperty
            .Where(x => x <= 0) //体力が0になったら
            .Subscribe(_ =>
            {
                //シーン遷移
                Debug.Log("シーン遷移");
                SceneManager.sceneLoaded += OnSceneTransition;
                SceneManager.LoadScene(
                    SceneDictionary.TypeOfName[SceneType.Result]
                    );
            }).AddTo(this);

    }

    void Start()
    {
        timer.OnStart(); //カウントアップスタート
        firepower.StartPowerUp(this.GetCancellationTokenOnDestroy()).Forget();
        //パンケーキを作成
        _pancakeMaker.PancakeMake();
        //トッピングを抽選
        //nextTopping.Value = (ToppingList)Random.Range(1, 2);
        _toppingMaker.ToppingMake();
    }


    void Update()
    {
        //デバッグ用
        if (Input.GetKeyDown(KeyCode.O))    //"O"キーが押されると失敗
            PancakeComplete(false);
        if (Input.GetKeyDown(KeyCode.I))    //"I"が押されると成功
            PancakeComplete(true);

    }

    //シーン遷移時の後処理
    void OnSceneTransition(Scene next, LoadSceneMode mode)
    {
        timer.OnStop(); 


        var resultMaster = GameObject.FindWithTag("Manager").GetComponent<ResultMaster>();  //resultManagerを取得

        resultMaster.time = timer.timeProperty.Value;   //現在の時間を渡す
        resultMaster.success = successCount.successProperty.Value;  //成功回数を渡す

        if(gameMode == "Build")
            repository.SendTimeToDataStore(timer.timeProperty.Value);   //時間を送信

        SceneManager.sceneLoaded -= OnSceneTransition;
    }

    //falseなら焦げた(失敗),trueならきれいに焼けた(成功)
    public void PancakeComplete(bool pancakeState)
    {
        if (!pancakeState)
            lifePoint.SubtractLife();
        else
            successCount.AddSuccessCount();


        //パンケーキ作成
        _pancakeMaker.PancakeMake();
        //トッピング作成
        //nextTopping.Value = (ToppingList)Random.Range(1, 2);
        _toppingMaker.ToppingMake();
    }

    //現在の火力を外部に公開
    public float GetFire()
    {
        return firepower.fireProperty.Value;
    }

    //次のトッピングを公開
    public IReadOnlyReactiveProperty<ToppingList> GetNextTopping()
    {
        return nextToppingProperty;
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

    public IReadOnlyReactiveProperty<int> GetSuccessProperty()
    {
        return successCount.successProperty;
    }


}
