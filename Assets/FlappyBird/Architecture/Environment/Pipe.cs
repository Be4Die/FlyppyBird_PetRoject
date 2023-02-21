using System.Collections;
using UnityEngine;

namespace Architecture.Environment
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField] private float m_speed;
        private bool m_isPause = false;
        private bool m_nonActiveInPause;
        public void SetLifeTime(float time)
        {
            Invoke(nameof(SetNonActive), time);
        }
        private void SetNonActive()
        {
            if(!m_isPause)
            {
                m_nonActiveInPause = true;
                this.gameObject.SetActive(false);
            }
        }

        public void Pause()
        {
            m_isPause = true;
        }
        public void UnPause()
        {
            m_isPause = false;
            if (m_nonActiveInPause)
            {
                SetNonActive();
            }
        }

        private void FixedUpdate()
        {
            if (!m_isPause)
                transform.position += Vector3.left * m_speed * Time.deltaTime;
        }
    }
}