using UnityEngine;
using Architecture.Input;
using Zenject;

namespace Architecture.Installers
{
    public class InputServiceInstaller : MonoInstaller
    {
        [SerializeField] private InputService m_inputService;
        public override void InstallBindings()
        {
            Container.Bind<InputService>().FromInstance(m_inputService).
            AsSingle().NonLazy();

            Container.QueueForInject(m_inputService);
        }
    }
}