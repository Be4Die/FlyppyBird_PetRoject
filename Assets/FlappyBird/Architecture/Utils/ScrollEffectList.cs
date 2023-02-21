using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture.Utils
{
    public class ScrollEffectList : MonoBehaviour
    {
        private List<ScrollEffect> m_list = new List<ScrollEffect>();

        public void AddScrollEffect(ScrollEffect effect)
        {
            m_list.Add(effect);
        }

        public void StopAll()
        {
            foreach (var effect in m_list)
            {
                effect.Stop();
            }
        }

        public void PlayAll()
        {
            foreach (var effect in m_list)
            {
                effect.Play();
            }
        }
    }
}