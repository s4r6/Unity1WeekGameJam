using UnityEngine;
using Zenject;

public class MasterInstaller : MonoInstaller
{
    [SerializeField]
    GameObject master;
    public override void InstallBindings()
    {
        Container
            .Bind<GameMaster>()
            .FromComponentOn(master)
            .AsCached();
    }
}