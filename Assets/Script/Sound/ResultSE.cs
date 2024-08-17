using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSE : MonoBehaviour
{
    public float ponkotsu;
    public float hutu;
    public float ninki;
    public float gyoretsu;
    public float densetsu;
    public AudioClip ponkotsuSound;
    public AudioClip hutuSound;
    public AudioClip ninkiSound;
    public AudioClip gyoretsuSound;
    public AudioClip densetsuSound;
    private AudioSource _audioSource;
    private GameMaster _gameMaster;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _gameMaster = FindObjectOfType<GameMaster>();
    }

    void Start()
    {
        float Timer = _gameMaster.GetTimeProperty().Value;

        if(Timer > densetsu){
            _audioSource.PlayOneShot(densetsuSound);
        }else if(Timer > gyoretsu){
            _audioSource.PlayOneShot(gyoretsuSound);
        }else if(Timer > ninki){
            _audioSource.PlayOneShot(ninkiSound);
        }else if(Timer > hutu){
            _audioSource.PlayOneShot(hutuSound);
        }else{
            _audioSource.PlayOneShot(ponkotsuSound);
        }
    }
}
