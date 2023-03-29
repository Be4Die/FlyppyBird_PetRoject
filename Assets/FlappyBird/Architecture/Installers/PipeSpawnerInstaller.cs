using UnityEngine;
using Zenject;
using Architecture.Environment;

namespace Architecture.Installers
{
    public sealed class PipeSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private PipeSpawner m_pipeSpawner;
    
        public override void InstallBindings()
        {
            Container.Bind<PipeSpawner>().FromInstance(m_pipeSpawner).
                AsSingle().NonLazy();
    
             Container.QueueForInject(m_pipeSpawner);
        }
    }
}