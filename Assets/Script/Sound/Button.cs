using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private AudioSource _AudioSource;

    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    public void AudioPlay()
    {
        _AudioSource.PlayOneShot(_AudioSource.clip);
    }


}
