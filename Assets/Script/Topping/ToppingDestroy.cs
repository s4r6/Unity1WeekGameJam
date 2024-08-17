using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingDestroy : MonoBehaviour
{
    private void Update()
    {
        if (this.gameObject.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
