using UnityEngine;
using System.Collections.Generic;

namespace Architecture.Animations.Core
{
    public sealed class AnimationsService : MonoBehaviour
    {
        #region Variabels
        private HashSet<BaseAnimation> m_animations = new HashSet<BaseAnimation>();
        #endregion


        public void InitAnimation(BaseAnimation animation)
        {
            m_animations.Add(animation);
        }

        public void StopAll()
        {
            foreach(var anim in m_animations)
            {
                anim.Stop();
            }
        }
        public void PlayAll()
        {
            foreach(var anim in m_animations)
            {
                anim.Play();
            }
        }
    }
}