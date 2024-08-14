using UnityEngine;
using Zenject;

public class RepositoryInstaller : MonoInstaller
{
    [SerializeField]
    GameObject repository;
    public override void InstallBindings()
    {
        Container
            .Bind<IRepositiory>()
            .To<UnityRoomRepositiory>()
            .FromComponentOn(repository)
            .AsCached();
    }
}