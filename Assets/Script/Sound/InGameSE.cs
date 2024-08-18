using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InGameSE : MonoBehaviour
{
    public AudioClip burntSound;
    public AudioClip dropedSound;
    public AudioClip perfectSound;
    public AudioClip bakedSound;

    private AudioSource _audioSource;
    [SerializeField]
    private GameMaster _gameMaster;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        _gameMaster.OnComment
            .Subscribe(pancakeComment =>
            {
                switch(pancakeComment)
                {
                    case PancakeComment.BURNT:
                        _audioSource.PlayOneShot(burntSound);
                        break;
                    case PancakeComment.DROPED:
                        _audioSource.PlayOneShot(dropedSound);
                        break;
                    case PancakeComment.PERFECT:
                        _audioSource.PlayOneShot(perfectSound);
                        break;
                    case PancakeComment.COMMON:
                        _audioSource.PlayOneShot(bakedSound);
                        break;
                }
                
            })
            .AddTo(this);
    }
}
