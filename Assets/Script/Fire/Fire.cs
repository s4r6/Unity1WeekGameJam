using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float rotationAmount = 5f; // 揺れの角度
    public float speed = 5f; // 揺れの速さ
    public float sizeChangeSpeed = 2f;
    public float fireSize = 1f;
    private float _randomOffset;
    private Vector3 _initialScale;
    private Vector3 _targetScale;

    void Start(){
        _randomOffset = Random.Range(0f, 2f * Mathf.PI);
        _initialScale = transform.localScale;
        _targetScale = _initialScale;
    }

    void Update(){
        float angle = rotationAmount * Mathf.Sin(Time.time * speed + _randomOffset);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // デバッグ用
        if (Input.GetKey(KeyCode.A)){
            fireSize = 0.8f;
        }
        if (Input.GetKey(KeyCode.S)){
            fireSize = 1.5f;
        }

        // サイズが変更された場合にのみChangeFireを呼び出す
        if (transform.localScale.x != fireSize * _initialScale.x) {
            ChangeFire(fireSize);
        }
    }

    public void ChangeFire(float newFireSize){
        _targetScale = _initialScale * newFireSize;
        transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, Time.deltaTime * sizeChangeSpeed);
    }
}
