using UnityEngine;
using Architecture.Utils;
using Zenject;

namespace Architecture.Installers
{
    public class ScrollEffectListInstaller : MonoInstaller
    {
        [SerializeField] private ScrollEffectList m_list;
        public override void InstallBindings()
        {
            Container.Bind<ScrollEffectList>().FromInstance(m_list).
            AsSingle().NonLazy();

            Container.QueueForInject(m_list);
        }
    }
}