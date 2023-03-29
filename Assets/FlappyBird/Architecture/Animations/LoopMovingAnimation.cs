using UnityEngine;
using DG.Tweening;
using Architecture.Animations.Core;

namespace Architecture.Animations
{
    public sealed class LoopMovingAnimation: BaseAnimation
    {
        #region Variabels
        [SerializeField] private float m_lenght;
        [SerializeField] [Range(0, 4f)] private float m_duration;

        private Sequence m_animation;
        #endregion


        public override void Play() => m_animation.Play();
        public override void Stop() => m_animation.Pause();

        protected override void SetUp()
        {
            var maxY = transform.position.y + m_lenght;
            var minY = transform.position.y -m_lenght;

            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);

            m_animation = DOTween.Sequence()
            .Append(transform.DOMoveY(minY, m_duration, true))
            .Append(transform.DOMoveY(maxY, m_duration, true))
            .SetLoops(-1, LoopType.Restart);
        }
        
        private void OnDestroy() {
            m_animation.Kill();
        }
    }
}