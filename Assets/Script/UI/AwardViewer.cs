using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardViewer : MonoBehaviour
{
    [SerializeField]
    GameObject BadAward;
    [SerializeField]
    GameObject CommonAward;
    [SerializeField]
    GameObject PopularAward;
    [SerializeField]
    GameObject GoodAward;
    [SerializeField]
    GameObject LegendAward;


    [SerializeField]
    ResultMaster master;

    void Start()
    {
        if(master.time <= 100)  //0 <= time <= 100
        {
            BadAward.SetActive(true);
        }
        else if(master.time <= 200) //100 <= time <= 200
        {
            CommonAward.SetActive(true); 
        }
        else if(master.time <= 300) //200 < time <= 300
        {
            PopularAward.SetActive(true);
        }
        else if(master.time <= 500) //300 < time <= 500
        {
            GoodAward.SetActive(true);
        }
        else if(master.time > 500) //500 < time 
        {
            //ƒŒƒWƒFƒ“ƒh
        }
    }


}
