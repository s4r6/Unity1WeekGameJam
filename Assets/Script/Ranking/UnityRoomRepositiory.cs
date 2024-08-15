using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using unityroom.Api;

public class UnityRoomRepositiory : MonoBehaviour, IRepositiory
{

    public void SendTimeToDataStore(float time)
    {
        UnityroomApiClient.Instance.SendScore(1, time, ScoreboardWriteMode.Always); //スコア送信
    }
}
