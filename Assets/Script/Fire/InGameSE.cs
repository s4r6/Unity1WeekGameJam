using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSE : MonoBehaviour
{
    public AudioClip burntSound;
    public AudioClip dropedSound;
    public AudioClip perfectSound;
    public AudioClip bakedSound;

    private AudioSource _audioSource;
    private GameMaster _gameMaster;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _gameMaster = FindObjectOfType<GameMaster>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
