using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LifeViewer : MonoBehaviour
{
    [SerializeField] private List<Image> lifeImages;

    private void Start()
    {
        AllActive();
    }

    public void SetLife(int hp)
    {
        lifeImages[hp-1].enabled = false;
    }

    void AllActive()
    {
        foreach (var image in lifeImages)
        {
            image.enabled = true;
        }
    }
}
