using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeParts : MonoBehaviour
{
    [SerializeField]
    private GameMaster _gameMaster;
    [SerializeField] private Pancake _pancake;
    [SerializeField] private float _bakedDegree;
    [SerializeField][Tooltip("この値より下のy座標にて落ちたと判定をする")] private float _dropAreaY;
    private bool _baked;
    private bool _burnt;
    [SerializeField][Tooltip("焼き色のイラスト")] private SpriteRenderer _bakedSprite;
    [SerializeField][Tooltip("焦げたイラスト")] private SpriteRenderer _burntSprite;

    // Update is called once per frame
    void Update()
    {
        if (_bakedDegree < 50)
        {//焼ける前
            _bakedSprite.color = new Color32(255, 255, 255, (byte)(_bakedDegree * 2.41f));
            _burntSprite.color = new Color32(255, 255, 255, 0);
        }
        else if (_bakedDegree < 100)
        {//焦げる前
            _bakedSprite.color = new Color32(255, 255, 255, 255);
            _burntSprite.color = new Color32(255, 255, 255, (byte)((_bakedDegree - 50f) * 2.41f));
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
                _bakedSprite.color = new Color32(255, 255, 255, 255);
                _burntSprite.color = new Color32(255, 255, 255, 255);
            }
        }

        if (this.transform.position.y < _dropAreaY) {
            _pancake.Drop();
        }
    }

    public void SetgameMaster(GameMaster gameMaster) {
        Debug.Log(gameMaster);
        _gameMaster = gameMaster;
    }

    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("振れている");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Flyingpan"))
        {
            Debug.Log(Time.deltaTime);
            _bakedDegree += _gameMaster.GetFire() * Time.deltaTime;//FixedUpdateなのでTime/Deltatimeは不要だけどこれがあるとフレーム換算しなくて済むので追加
        }
    }
    */
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("振れているTriger");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Flyingpan"))
        {
            //Debug.Log(Time.deltaTime);
            _bakedDegree += _gameMaster.GetFire() * Time.deltaTime;//FixedUpdateなのでTime/Deltatimeは不要だけどこれがあるとフレーム換算しなくて済むので追加
        }

    }
}
