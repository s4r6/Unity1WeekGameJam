using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlypanPowerPresenter : MonoBehaviour
{
    //FlypanPowerだけプライパンの力を調整するコードを参照しています。

    [SerializeField] private FryingPan flypan;

    [SerializeField] private FlypanPowerViewer flypanPowerViewer;

    //ReactivePropertyで参照していないので改善したい。
    void Update()
    {
        float power = flypan.GetPowerCharagePercent();
        flypanPowerViewer.SetPowerSlider(power);
    }
}
