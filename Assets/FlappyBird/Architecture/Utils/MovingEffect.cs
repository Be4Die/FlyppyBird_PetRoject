using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Architecture.Utils
{
    public class MovingEffect : MonoBehaviour
    {
        #region Variabels
        [SerializeField] private float m_lenght;
        [SerializeField] [Range(0, 4f)] private float m_duration;

        private Sequence m_animation;
        #endregion
    
        private void Start()
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