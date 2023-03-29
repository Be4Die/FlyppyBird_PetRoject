using UnityEngine;
using Zenject;
using Architecture.Player;

namespace Architecture.Installers
{
    public sealed class PlayerScoreInstaller : MonoInstaller
    {
        [SerializeField] private PlayerScore m_playerScore;
    
        public override void InstallBindings()
        {
            Container.Bind<PlayerScore>().FromInstance(m_playerScore).
                AsSingle().NonLazy();
    
             Container.QueueForInject(m_playerScore);
        }
    }
}