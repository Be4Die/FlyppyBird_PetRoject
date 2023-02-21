using UnityEngine;
using Zenject;

namespace Architecture.Utils
{
    [RequireComponent(typeof(Renderer))]
    public class ScrollEffect : MonoBehaviour
    {
        #region Variables
        [Inject] private ScrollEffectList m_list;
        [SerializeField] private float m_multiplier;
        private Material m_material;
        private bool m_isStop = false;
        private const string M_TEXTURENAME = "_MainTex";
        private float m_offset;
        #endregion

        private void Awake()
        {
            m_material = GetComponent<Renderer>().material;
            m_list.AddScrollEffect(this);
        }


        private void FixedUpdate()
        {
            if(!m_isStop)
            {
                m_offset += Time.deltaTime * m_multiplier;
                m_material.SetTextureOffset(M_TEXTURENAME, new Vector2(m_offset, 0));
            }
        }

        public void Stop()
        {
            m_isStop = true;
        }
        public void Play()
        {
            m_isStop = false;
        }
    }
}