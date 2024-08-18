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
        _gameMaster.OnComment
            .Subscribe(pancakeComment =>
            {
                switch(pancakeComment)
                {
                    case PancakeComment.BURNT:
                        audioSource.PlayOneShot(burntSound);
                        break;
                    case PancakeComment.DROPED:
                        audioSource.PlayOneShot(dropedSound);
                        break;
                    case PancakeComment.PERFECT:
                        audioSource.PlayOneShot(perfectSound);
                        break;
                    case PancakeComment.BAKED:
                        audioSource.PlayOneShot(bakedSound);
                        break;
                }
                
            })
            .AddTo(this);
    }
}
