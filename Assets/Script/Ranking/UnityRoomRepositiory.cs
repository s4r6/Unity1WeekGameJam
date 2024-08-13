using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityroom.Api;

public class UnityRoomRepositiory : MonoBehaviour, IRepositiory
{
    [SerializeField]
    GameObject ranking;
    [SerializeField]
    string HmacKey = "";

    public void SendTimeToDataStore(float time)
    {
        if(UnityroomApiClient.Instance == null) //Instanceが無ければ
            InitializeUnityRoomAPI();

        UnityroomApiClient.Instance.SendScore(1, time, ScoreboardWriteMode.Always); //スコア送信
    }

    void InitializeUnityRoomAPI()   //要求されたときに初めてUntiyroomAPIを生成
    {
        var UnityRoomAPI = Instantiate(ranking);
        UnityRoomAPI.GetComponent<UnityroomApiClient>().SetHmacKey(HmacKey);
    }
}
