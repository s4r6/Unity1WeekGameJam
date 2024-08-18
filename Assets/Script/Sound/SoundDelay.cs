using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Threading;

public class SoundDelay : MonoBehaviour
{
    private AudioSource _AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        
        SoundStart(this.GetCancellationTokenOnDestroy()).Forget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private async UniTask SoundStart(CancellationToken cancellationToken)
    {
        await UniTask.Delay(3 * 1000, cancellationToken: cancellationToken);
        _AudioSource.Play();

    }
}
