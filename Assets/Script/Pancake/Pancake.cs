using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Pancake : MonoBehaviour
{
    private GameMaster _gameMaster;

    [SerializeField] private List<PancakeParts> _pancakeParts;
    //[SerializeField] protected bool _debugMode;
    private int _bakedNum;
    private int _burntNum;

    private bool InjectComplete = false;

    /*private void Start()
    {
        foreach (var part in _pancakeParts)
        {
            part.SetgameMaster(_gameMaster);
        }

        InjectComplete = true;
    }*/

    [Inject]
    private void InjectGameMaster(GameMaster master)
    {
        _gameMaster = master;
        foreach (var part in _pancakeParts)
        {
            part.SetgameMaster(_gameMaster);
        }

        InjectComplete = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!InjectComplete) return;

        if (_burntNum/_pancakeParts.Count >= 0.5) {
            Debug.Log("Å‚°‚Ä‚µ‚Ü‚Á‚½");
            _gameMaster.PancakeComplete(true);
            Destroy(this.gameObject);
        }
        if (_bakedNum == _pancakeParts.Count) {
            Debug.Log("Ä‚«‚ ‚ª‚Á‚½");
            _gameMaster.PancakeComplete(true);
            Destroy(this.gameObject);
        }
    }

    public void SetGameMaster(GameMaster gameMaster)
    {
        _gameMaster = gameMaster;
    }

    public void BakedCount() 
    { 
        _bakedNum += 1;
    }

    public void BurntCount()
    {
        _burntNum += 1;
    }
}
