using UnityEngine;
using Architecture.Animations.Core;

namespace Architecture.Animations
{
    [RequireComponent(typeof(Renderer))]
    public sealed class ScrollAnimation: BaseAnimation
    {
        #region Variables
        [SerializeField] private float m_multiplier;
        private Material m_material;
        private bool m_isStop = false;
        private const string M_TEXTURENAME = "_MainTex";
        private float m_offset;
        #endregion
        

        public override void Play() => m_isStop = false;
        public override void Stop() => m_isStop = true;

        protected override void SetUp()
        {
            m_material = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            if(!m_isStop)
            {
                m_offset += Time.deltaTime * m_multiplier;
                m_material.SetTextureOffset(M_TEXTURENAME, new Vector2(m_offset, 0));
            }
        }
    }
}