using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    [SerializeField][Tooltip("フライパンを振るときの最大の力")] private float _maxPower;
    [SerializeField][Tooltip("左右に動く最高速度です")] private float _chargePowerSpeed;
    /// <summary>
    /// 現在どれだけ力をため込んでいるかの値
    /// </summary>
    private float _chargePower;
    [SerializeField][Tooltip("左右に動く最高速度です")] private Rigidbody2D _myRB2D;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _maxPower > _chargePower)
        {
            _chargePower += _chargePowerSpeed * Time.deltaTime;
            if (_maxPower < _chargePower) { _chargePower = _maxPower; }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _myRB2D.AddForce(new Vector2(0, _chargePower), ForceMode2D.Impulse);
            _chargePower = 0;
        }
       
    }

    /// <summary>
    /// どれだけ力をためているかを返す
    /// </summary>
    /// <returns>1を100%としてチャージしている率を返す</returns>
    public float GetPowerCharagePercent() {
        float powerPercent = _chargePower / _maxPower;
        if (powerPercent > 1) { powerPercent = 1; }
        return powerPercent;
    }
}
