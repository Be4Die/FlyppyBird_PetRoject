using UnityEngine;
using Zenject;
using Architecture.Player;

namespace Architecture.Installers
{
    public class PlayerControllerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerController m_playerController;
    
        public override void InstallBindings()
        {
            Container.Bind<PlayerController>().FromInstance(m_playerController).
                AsSingle().NonLazy();
    
             Container.QueueForInject(m_playerController);
        }
    }
}