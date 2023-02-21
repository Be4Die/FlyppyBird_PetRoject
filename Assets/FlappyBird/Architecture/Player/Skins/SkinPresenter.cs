using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture.Player.Skins
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SkinPresenter : MonoBehaviour
    {
        #region Variabels
        [SerializeField] private Skin m_skin;

        private SpriteRenderer m_spriteRenderer;
        private bool m_isAnimate;
        #endregion

        private void Awake()
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            StartCoroutine(FlyAnimation());
        }

        public void StopAnimation()
        {
            m_isAnimate = false;
        }
        public void PlayAnimation()
        {
            m_isAnimate = true;
        }

        private IEnumerator FlyAnimation()
        {
            m_isAnimate = true;
            while (true)
            {
                var sprites = m_skin.FlyAnimationSprites;
                foreach (var sprite in sprites)
                {
                    if (m_isAnimate)
                        m_spriteRenderer.sprite = sprite;
                    var delay = m_skin.FlyAnimationDuration / sprites.Length;
                    yield return new WaitForSeconds(delay);
                }
            }
        }
    }
}