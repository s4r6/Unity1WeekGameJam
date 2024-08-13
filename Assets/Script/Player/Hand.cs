using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField][Tooltip("左右に動く最高速度です")] private float _maxSpeed;
    [SerializeField][Tooltip("動くために押し出される力です")] private float _pushPower;
    [SerializeField][Tooltip("x座標方向に許される最大の移動位置です")] private float _maxX;
    [SerializeField][Tooltip("x座標方向に許される最小の移動位置です")] private float _minX;
    [SerializeField][Tooltip("自信のRigidbody2Dです")] private Rigidbody2D _myRB2;

    [SerializeField][Tooltip("移動ボタンを話した後も慣性を持って移動し続けるかについてです")] private bool inertia;


    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.D) && _myRB2.velocity.x < _maxSpeed)
        {
            _myRB2.AddForce(new Vector2(_pushPower, 0));
        }
        if (Input.GetKey(KeyCode.A) && _myRB2.velocity.x > -_maxSpeed)
        {
            _myRB2.AddForce(new Vector2(-_pushPower, 0));
        }

        if (this.transform.position.x > _maxX && _myRB2.velocity.x > 0)
        { //右行き過ぎ予防
            _myRB2.velocity = new Vector2(0, 0);
        }
        if (this.transform.position.x < _minX && _myRB2.velocity.x < 0)
        { //右行き過ぎ予防
            _myRB2.velocity = new Vector2(0, 0);
        }

        if (!inertia && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            _myRB2.velocity = Vector2.zero;
        }

    }

}
