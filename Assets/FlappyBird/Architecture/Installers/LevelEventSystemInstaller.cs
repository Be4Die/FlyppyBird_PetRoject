using UnityEngine;
using Zenject;
using Architecture.LevelEvents;

namespace Architecture.Installers
{
    public sealed class LevelEventSystemInstaller : MonoInstaller
    {
        [SerializeField] private LevelEventSystem m_levelEventSystem;
        public override void InstallBindings()
        {
            Container.Bind<LevelEventSystem>().FromInstance(m_levelEventSystem).
                AsSingle().NonLazy();
    
             Container.QueueForInject(m_levelEventSystem);
        }
    }
}