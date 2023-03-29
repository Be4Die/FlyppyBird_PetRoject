using UnityEngine;
using Zenject;
using Architecture.Animations.Core;

namespace Architecture.Installers
{
    public sealed class AnimationsServiceInstaller : MonoInstaller
    {
        [SerializeField] private AnimationsService m_service;
        public override void InstallBindings()
        {
            Container.Bind<AnimationsService>().FromInstance(m_service).
            AsSingle().NonLazy();

            Container.QueueForInject(m_service);
        }
    }
}