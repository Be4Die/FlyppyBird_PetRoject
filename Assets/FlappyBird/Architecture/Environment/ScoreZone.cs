using UnityEngine;
using Architecture.Player;

namespace Architecture.Environment
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(AudioSource))]
    public class ScoreZone : MonoBehaviour
    {
        #region Variabels
        [SerializeField] private AudioClip m_scoreSound;
        private AudioSource m_audioSource;
        private Collider2D m_collider;
        #endregion
        

        private void Awake()
        {
            m_audioSource = GetComponent<AudioSource>();
            m_collider = GetComponent<Collider2D>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerScore>(out var score))
            {
                score.AddScore();
                m_audioSource.PlayOneShot(m_scoreSound);
                m_collider.enabled = false;
            }
        }

        private void OnEnable()
        {
            m_collider.enabled = true;
        }
    }
}
