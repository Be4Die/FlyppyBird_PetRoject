using UnityEngine;
using Zenject;

namespace Architecture.Animations.Core
{
    public abstract class BaseAnimation : MonoBehaviour
    {
        #region Variabels
        [Inject] protected AnimationsService m_animationsService;
        #endregion


        public abstract void Stop();
        public abstract void Play();
        protected virtual void SetUp(){}

        private void Awake()
        {
            m_animationsService.InitAnimation(this);
        }
        
        private void Start()
        {
            SetUp();
        }
    }
}