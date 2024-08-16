using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeParts : MonoBehaviour
{
    [SerializeField]
    private GameMaster _gameMaster;
    [SerializeField] private Pancake _pancake;
    [SerializeField] private float _bakedDegree;
    private bool _baked;
    private bool _burnt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_bakedDegree < 50)
        {//焼ける前

        }
        else if (_bakedDegree < 100)
        {//焦げる前
            if (!_baked)
            {
                Debug.Log("焼けた");
                _baked = true;
                _pancake.BakedCount();
            }
        }
        else {
            //焦げた後
            if (!_burnt) {
                Debug.Log("焦げた");
                _burnt = true;
                _pancake.BurntCount();
            }
        }
    }

    public void SetgameMaster(GameMaster gameMaster) { 
        _gameMaster = gameMaster;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("振れている");
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Flyingpan")
        {
            //Debug.Log(Time.deltaTime);
            _bakedDegree += _gameMaster.GetFire() * Time.deltaTime;//FixedUpdateなのでTime/Deltatimeは不要だけどこれがあるとフレーム換算しなくて済むので追加
        }
    }


}
